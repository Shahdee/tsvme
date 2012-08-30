using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using OpenCLNet;
using System.Linq;


namespace vme
{
    public partial class VoxelImage : Form
    {
        private bool initialize;
        private bool first;
        private bool angleChange;
        private bool leftChange;
        private bool rightChange;
        private bool changeDistance;
        private Bitmap output = new Bitmap(1024, 1024, PixelFormat.Format32bppArgb);
        private VoxelVolume vol;
        private Float4 camPos;
        private Float4 camPosOld;
        private float  camAngle;
        private float  camDist = 1000;
        private Float4 light = new Float4() { S0 = 1000, S1 = -500, S2 = -400, S3 = 0 };
        private Float4 camLookAt;
        private Float4 camForward;
        private const int blocksize = 64; 
        private Float4 boxMinCon = new Float4(0, 0, 0, 0);
        private Float4 boxMaxCon = new Float4(512, 512, 512, 0);
        private float camfactorX;
        private float camfactorY;
        private float camfactorZ;
        private OpenCLManager manager;
        private OpenCLNet.Program program;
        private Kernel kernel;
        private Point oldMousePos;
        private Main form_this;
        private int winWidth_vox;
        private int winCentre_vox;
        private Mem outputBuffer;
        private Mem color_buffer;
        private Mem opacity;
        private Mem counter;
        private Stopwatch clock;
        private ulong voxelctr, realctr;

        public VoxelImage()
        {
            InitializeComponent();
            first = true;
            angleChange = false;
            changeDistance = false;
            leftChange = false;
            rightChange = false;
            voxelctr = 0;
            realctr = 0;

            this.lx.Text = Convert.ToString(light.S0);
            this.ly.Text = Convert.ToString(light.S1);
            this.lz.Text = Convert.ToString(light.S2);
            this.trackminX.SetRange(0, 512);
            this.trackminY.SetRange(0, 512);
            this.trackminZ.SetRange(0, 512);
            this.trackmaxX.SetRange(0, 512);
            this.trackmaxY.SetRange(0, 512);
            this.trackmaxZ.SetRange(0, 512);
            this.trackminX.Value = (int)(boxMinCon.S0);
            this.trackminY.Value = (int)(boxMinCon.S1);
            this.trackminZ.Value = (int)(boxMinCon.S2);
            this.trackmaxX.Value = (int)(boxMaxCon.S0);
            this.trackmaxY.Value = (int)(boxMaxCon.S1);
            this.trackmaxZ.Value = (int)(boxMaxCon.S2);
            this.minX.Text = Convert.ToString(boxMinCon.S0);
            this.minY.Text = Convert.ToString(boxMinCon.S1);
            this.minZ.Text = Convert.ToString(boxMinCon.S2);
            this.maxX.Text = Convert.ToString(boxMaxCon.S0);
            this.maxY.Text = Convert.ToString(boxMaxCon.S1);
            this.maxZ.Text = Convert.ToString(boxMaxCon.S2);
            this.kamb.Text = Convert.ToString(0.1);
            this.kdiff.Text = Convert.ToString(0.5);
            this.kspec.Text = Convert.ToString(0.4);
            this.tracklx.SetRange(-1000,1000);
            this.trackly.SetRange(-1000, 1000);
            this.tracklz.SetRange(-1000, 1000);
            this.tracklx.Value = (int)light.S0;
            this.trackly.Value = (int)light.S1;
            this.tracklz.Value = (int)light.S2;
            this.kc.Text = "1,0";
            this.kl.Text = "0,0";
            this.kq.Text = "0,0";
            this.specexp.Text = "1,0";
            outputBuffer = null;
            color_buffer =null;
            opacity = null;
            clock = new Stopwatch();
        }

        public void  Draw(){
            // заблокировать поверхность
            BitmapData bd = output.LockBits(new Rectangle(0, 0, output.Width, output.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            DoRayCasting(bd);
            output.UnlockBits(bd);
        }

        #region DICOMLoading

        public void LoadHeadDICOMTestDataSet(List<ushort> buffer, ushort num_of_images, double winCentre, double winWidth, double intercept, bool signed) 
        {
            ushort i = 0;
            short k;
            winCentre_vox = (int)(winCentre);
            winWidth_vox = (int)(winWidth);
            int winMax = Convert.ToInt32(winCentre_vox + 0.5 * winWidth);
            int winMin = winMax - (int)(winWidth);
            winMax -= 32768;
            winMin -= 32768;
            vol = new VoxelVolume(517, manager);
            boxMinCon = new Float4(0, 0, 0, 0);
            boxMaxCon = new Float4(512, 512, 512, 0);
            /* для ускорения работы с буфером вокселей, ось x самая внутренняя. VolumetricMethodsInVisualEffects2010 */
            for (var f = 1; f <= num_of_images; f++){
                for (var y = 0; y < 512; y++){
                    for (var x = 0; x < 512; x++){
                        i = buffer[(f - 1) * 512 * 512 + (x * 512 + y)];
                        k = (short)(i - 32768);
                        if (k > winMin && k < winMax)  // учесть преобразование wincentre
                        {
                            var xx = (int)((x / 512.0) * (513.0 - 5));
                            var yy = 512 - (int)((y / 512.0) * (513.0 - 5));
                            var zz = (int)((f / 348.0) * (349.0));
                            vol.SetValue(xx, (330 - zz * 2), yy, k);
                            vol.SetValue(xx, (330 - zz * 2 + 1), yy, k);
                            vol.SetValue(xx, (330 - zz * 2 + 2), yy, k);
                        }
                    }
                }
                GC.Collect();
            }
            GC.Collect();
            camfactorX = 2;
            camfactorY = 2;
            camfactorZ = 2;
        }

        public void LoadDICOMTestDataSet(List<ushort> buffer, ushort num_of_images, double winCentre, double winWidth, double intercept, bool signed)
        {
            ushort i = 0;
            short k;
            winCentre_vox = (int)(winCentre);
            winWidth_vox = (int)(winWidth);
            int winMax = Convert.ToInt32(winCentre_vox + 0.5 * winWidth);
            int winMin = winMax - (int)(winWidth);
            winMax -= 32768;
            winMin -= 32768;
            vol = new VoxelVolume(517, manager);
            boxMinCon = new Float4(0, 0, 0, 0);
            boxMaxCon = new Float4(512, 512, 512, 0);
            /* для ускорения работы с буфером вокселей, ось x самая внутренняя. VolumetricMethodsInVisualEffects2010 */
            for (var f = 1; f <= num_of_images; f++)
            {
                for (var y = 0; y < 512; y++)
                {
                    for (var x = 0; x < 512; x++)
                    {
                        i = buffer[(f - 1) * 512 * 512 + (x * 512 + y)];
                        k = (short)(i - 32768);
                        if (k > winMin && k < winMax)  // учесть преобразование wincentre
                        {
                            var xx = (int)((x / 512.0) * (513.0 - 5));
                            var yy = 512 - (int)((y / 512.0) * (513.0 - 5));
                            var zz = (int)((f / 167.0) * (166.0));
                            //vol.SetValue(xx, (330 - zz * 2), yy, k);
                            //vol.SetValue(xx, (330 - zz * 2 + 1), yy, k);
                            //vol.SetValue(xx, (330 - zz * 2 + 2), yy, k);
                            vol.SetValue(xx, yy,(330 - zz * 2), k);
                            vol.SetValue(xx, yy,(330 - zz * 2 + 1), k);
                            vol.SetValue(xx, yy,(330 - zz * 2 + 2), k);
                        }
                    }

                }
                GC.Collect();
            }
            GC.Collect();
            camfactorX = 2;
            camfactorY = 2;
            camfactorZ = 2;
        }
        #endregion

        #region GetRegion

        private unsafe Mem GetColors()
        {
            fixed (uint* dataptr = form_this.colors)
            {
                color_buffer = manager.Context.CreateBuffer(MemFlags.COPY_HOST_PTR, form_this.colors.Count() * 4, new IntPtr(dataptr));
            }
            return color_buffer;
        }

    
        private unsafe Mem GetOpacity() 
        {
            fixed (float* dataptr = form_this.opacity)
            {
                opacity = manager.Context.CreateBuffer(MemFlags.COPY_HOST_PTR, form_this.opacity.Count(), new IntPtr(dataptr));
            }
            return opacity;
        }

        
        private unsafe Mem GetCounter() 
        {
            fixed (ulong* dataptr = &voxelctr)
            {
                counter = manager.Context.CreateBuffer(MemFlags.READ_WRITE, 8, new IntPtr(dataptr));
            }
            return counter;
        }

        #endregion

        private unsafe void DoRayCasting(BitmapData output){
            try{
                int deviceIndex = 0;
                outputBuffer = manager.Context.CreateBuffer(MemFlags.USE_HOST_PTR, output.Stride * output.Height, output.Scan0);
                if (first || changeDistance)
                {
                    // модель камеры UVN 
                    camPos = new Float4()
                    {
                        S0 =
                        vol.GetSize() / 2 - (float)Math.Cos(camAngle * Math.PI / 180) * camDist,
                        S1 = vol.GetSize() / 2,
                        S2 = vol.GetSize() / 2 - (float)Math.Sin(camAngle * Math.PI / 180) * camDist,
                        S3 = 0
                    };

                    first = false;
                    changeDistance = false;
                    camPosOld = camPos;
                }
                else{
                    // поворот вокруг оси куба визуализации
                    if (angleChange && leftChange){
                        camPosOld.S0 -= camLookAt.S0;
                        camPosOld.S2 -= camLookAt.S2;
                        camPos.S0 = (float)Math.Cos(camAngle * Math.PI / 180) * camPosOld.S0 + (float)Math.Sin(camAngle * Math.PI / 180) * camPosOld.S2;
                        camPos.S1 = vol.GetSize() / 2;
                        camPos.S2 = -(float)Math.Sin(camAngle * Math.PI / 180) * camPosOld.S0 + (float)Math.Cos(camAngle * Math.PI / 180) * camPosOld.S2;
                        camPos.S3 = 0;
                        camPos.S0 += camLookAt.S0;
                        camPos.S2 += camLookAt.S2;
                        camPosOld = camPos;
                        angleChange = false;
                        leftChange = false;
                    }
                    if (angleChange && rightChange){
                        camPosOld.S0 -= camLookAt.S0;
                        camPosOld.S2 -= camLookAt.S2;
                        camPos.S0 = (float)Math.Cos(camAngle * Math.PI / 180) * camPosOld.S0 - (float)Math.Sin(camAngle * Math.PI / 180) * camPosOld.S2;
                        camPos.S1 = vol.GetSize() / 2;
                        camPos.S2 = (float)Math.Sin(camAngle * Math.PI / 180) * camPosOld.S0 + (float)Math.Cos(camAngle * Math.PI / 180) * camPosOld.S2;
                        camPos.S3 = 0;
                        camPos.S0 += camLookAt.S0;
                        camPos.S2 += camLookAt.S2;
                        camPosOld = camPos;
                        angleChange = false;
                        leftChange = false;
                    }
                }

                camLookAt = new Float4(){
                    S0 = vol.GetSize() / camfactorX,
                    S1 = vol.GetSize() / camfactorX,
                    S2 = vol.GetSize() / camfactorZ,
                    S3 = 0
                };
                
                // направление камеры, UVN модель
                camForward = camLookAt.Sub(camPos).Normalize(); // направление просмотра
                var up = new Float4(0.0f, 1.0f, 0.0f, 0.0f);
                var right = MathClass.Cross(up, camForward).Normalize().Times(1.5f);
                up = MathClass.Cross(camForward, right).Normalize().Times(-1.5f);
                /*  обработка выходного изображения BitmapData в OpenCl устройстве */
                for (var x = 0; x < output.Width; x += blocksize){
                    for (var y = 0; y < output.Height; y += blocksize){
                        var rayTracingGlobalWorkSize = new IntPtr[2]; // work_dim = 2
                        rayTracingGlobalWorkSize[0] = (IntPtr)(output.Width - x > blocksize ? blocksize : output.Width - x);
                        rayTracingGlobalWorkSize[1] = (IntPtr)(output.Height - y > blocksize ? blocksize : output.Height - y);
                        var rayTracingGlobalOffset = new IntPtr[2];
                        rayTracingGlobalOffset[0] = (IntPtr)x; 
                        rayTracingGlobalOffset[1] = (IntPtr)y; 
                        float ka = (float)(Convert.ToDouble(kamb.Text));
                        float kd = (float)(Convert.ToDouble(kdiff.Text));
                        float ks = (float)(Convert.ToDouble(kspec.Text));
                        float exp = (float)(Convert.ToDouble(specexp.Text));
                        float kkc = (float)(Convert.ToDouble(this.kc.Text));
                        float kkl = (float)(Convert.ToDouble(this.kl.Text));
                        float kkq = (float)(Convert.ToDouble(this.kq.Text));
                        /* передали аргументы в kernel функцию */
                        kernel.SetArg(0, output.Width);
                        kernel.SetArg(1, output.Height);
                        kernel.SetArg(2, outputBuffer);  // в ядре с global, поскольку для выполнения требуется доступ к output
                        kernel.SetArg(3, output.Stride);
                        kernel.SetArg(4, camPos);
                        kernel.SetArg(5, camForward);
                        kernel.SetArg(6, right);
                        kernel.SetArg(7, up);
                        kernel.SetArg(8, vol.CreateBuffer());
                        kernel.SetArg(9, vol.GetSize());
                        kernel.SetArg(10, light);
                        kernel.SetArg(11, boxMinCon);
                        kernel.SetArg(12, boxMaxCon);
                        kernel.SetArg(13, Convert.ToInt16(colorMi.Text));
                        kernel.SetArg(14, Convert.ToInt16(colorMa.Text));
                        kernel.SetArg(15, _cutArrea.Checked ? (short)1 : (short)0);
                        kernel.SetArg(16, _trilinear.Checked ? (short)1 : (short)0);
                        kernel.SetArg(17, tf.Checked ? (short)1: (short)0 );
                        kernel.SetArg(18, GetColors());
                        kernel.SetArg(19, winWidth_vox);
                        kernel.SetArg(20, winCentre_vox);
                        kernel.SetArg(21, form_this.KnotsCounter);
                        kernel.SetArg(22, Convert.ToInt16(colorMi2.Text));
                        kernel.SetArg(23, Convert.ToInt16(colorMa2.Text));
                        kernel.SetArg(24, GetOpacity());
                        kernel.SetArg(25, ka);
                        kernel.SetArg(26, kd);
                        kernel.SetArg(27, ks);
                        kernel.SetArg(28, exp);
                        kernel.SetArg(29, kkc);
                        kernel.SetArg(30, kkl);
                        kernel.SetArg(31, kkq);
                        kernel.SetArg(32, GetCounter());
                        /* Ставит в очередь команду для исполнения kernel на устройстве */
                        /*  rayTracingGlobalOffset - 
                         *  globalWorkOffset: может использоваться для указания массива значений
                         *  размерности work_dim unsigned который описывает смещение используемое для расчета  global ID  work-item
                         *  вместо того чтобы global IDs всегда начинался со смещение (0, 0,... 0).
                         *  rayTracingGlobalWorkSize -
                         *  globalWorkSize: общее число global work-items вычисляется как global_work_size[0] *...* global_work_size[work_dim - 1].*/
                        manager.CQ[deviceIndex].EnqueueNDRangeKernel(kernel, 2, rayTracingGlobalOffset, rayTracingGlobalWorkSize, null);
                    }
                }

                /* подождали пока все work-items выполнятся */
                manager.CQ[deviceIndex].EnqueueBarrier();
                /* для того чтобы получить доступ к памяти и записать в выходное изображение мы просим у OpenCL *наложить* данные в хост-устройство */
                IntPtr p = manager.CQ[deviceIndex].EnqueueMapBuffer(outputBuffer, true, MapFlags.READ, IntPtr.Zero, (IntPtr)(output.Stride * output.Height));
                IntPtr z = manager.CQ[deviceIndex].EnqueueMapBuffer(counter, true, MapFlags.READ_WRITE, IntPtr.Zero, (IntPtr)(sizeof(ulong)));
                /* когда мы заканчиваем работать с буфером надо вызвать эту функцию */
                manager.CQ[deviceIndex].EnqueueUnmapMemObject(outputBuffer, p);
                manager.CQ[deviceIndex].EnqueueUnmapMemObject(counter, z);
                manager.CQ[deviceIndex].Finish();
                realctr += voxelctr;
                voxelCounter.Text = Convert.ToString(realctr);
            }
            catch (Exception ex){
                MessageBox.Show("Ray casting exception:" + ex.Message, "Exception");
                Environment.Exit(-1);
            }
            finally{
                if (outputBuffer != null){
                    outputBuffer.Dispose();
                }
            }
        }

        internal void Idle(){
            if (initialize){
                Draw();
                VSurface.Refresh();
            }
        }

        public void VoxelImage_Load(List<ushort> buffer, ushort num_of_images, double winCentre, double winWidth, double intercept, bool signed, Main form){
            try{
                InitializeOpenCL();
                LoadDICOMTestDataSet(buffer, num_of_images, winCentre, winWidth, intercept, signed);
                initialize = true;
                form_this = form;

            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, " Ошибка инициализации OpenCl  или проблема с загрузкой DICOM файлов!");
            }
        }

        private void InitializeOpenCL(){
            if (OpenCL.NumberOfPlatforms == 0){
                MessageBox.Show("OpenCL не поддерживается вашей системой!");
                Application.Exit();
            }
            manager = new OpenCLManager();
            manager.AttemptUseBinaries = true;
            manager.AttemptUseSource = true;
            manager.RequireImageSupport = false;
            manager.BuildOptions = "";
            manager.CreateDefaultContext(0, DeviceType.ALL);
            // Компиляция OpenCL кода
            program = manager.CompileSource(Properties.Resources.DVR);
            kernel = program.CreateKernel("DVR");
        }

        #region Transformations

        private void VSurface_Paint(object sender, PaintEventArgs e)
        {
            clock.Restart();

            Graphics g = e.Graphics;

            if (initialize)
            {
                Draw();
                g.DrawImage(output, 0, 0, VSurface.Width, VSurface.Height);
            }

            float fps = (float)(1000.0 / clock.ElapsedMilliseconds);
            this.fps.Text ="FPS: "+Convert.ToString(fps);
         
        }

        private void RotateCameraRight()
        {
            first = false;
            camAngle = 10;
        }

        private void RotateCameraLeft()
        {
            first = false;
            camAngle = 10;
         }

        private void ZoomIn() 
        {
            camDist += 10;
            if (camDist >= 1200)
            {
                camDist = 1200;
            }
        }

        private void ZoomOut()
        {
            camDist -= 10;
            if (camDist <= 0)
            {
                camDist = 0;
            }
        }

        public class DrawPanel : Panel
        {
            public DrawPanel()
                : base()
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                UpdateStyles();
            }
        }

        private void VSurface_Click(object sender, EventArgs e)
        {
            VSurface.Focus();
        }

        private void left_Click(object sender, EventArgs e)
        {
            angleChange = true;
            leftChange = true;
            RotateCameraLeft();
    
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            angleChange = true;
            rightChange = true;
            RotateCameraRight();

            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }

        private void up_Click(object sender, EventArgs e)
        {
            changeDistance = true;
            ZoomIn();
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }

        }

        private void down_Click(object sender, EventArgs e)
        {
            changeDistance = true;
            ZoomOut();
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }

        }

        private void tf_CheckedChanged(object sender, EventArgs e) 
        {
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }

        private void VSurface_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                changeDistance = true;
                for (var repeat = 0; repeat < 3; repeat++)
                    ZoomOut();
                if (initialize)
                {
                    Draw();
                    VSurface.Refresh();
                }
            }
            if (e.Delta < 0)
            {
                changeDistance = true;
                for (var repeat = 0; repeat < 3; repeat++)
                    ZoomIn();
                if (initialize)
                {
                    Draw();
                    VSurface.Refresh();
                }
            }

        }

        private void VSurface_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (oldMousePos != null)
                {
                    int horizontalMovement = e.Location.X - oldMousePos.X;

                    if (horizontalMovement > 0)
                    {
                        angleChange = true;
                        leftChange = true;
                        RotateCameraLeft();
                      
                    }
                    if (horizontalMovement < 0)
                    {
                        angleChange = true;
                        rightChange = true;
                        RotateCameraRight();
                    }

                    if (initialize)
                    {
                        Draw();
                        VSurface.Refresh();
                    }
                }
                oldMousePos = e.Location;
            }
        }


    #endregion


        private void VoxelImage_FormClosing(object sender, EventArgs e){
            vol.ReturnBuffer().Dispose();
            color_buffer.Dispose();
            opacity.Dispose();
            manager.CQ[0].Dispose();
            kernel.Dispose();
            program.Dispose();
            manager.Context.Dispose();
            manager.Dispose();
            VSurface.Dispose();
            GC.Collect();
        }

        #region TrackBars

        private void trackminX_Scroll(object sender, EventArgs e)
        {
            boxMinCon.S0 = (float)(this.trackminX.Value);
            minX.Text = Convert.ToString(trackminX.Value);
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }

        private void trackminY_Scroll(object sender, EventArgs e)
        {
            boxMinCon.S1 = (float)(trackminY.Value); 
            minY.Text = Convert.ToString(trackminY.Value);

            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }

        private void trackminZ_Scroll(object sender, EventArgs e)
        {
            boxMinCon.S2 = (float)(this.trackminZ.Value);
            minZ.Text = Convert.ToString(trackminZ.Value);
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }

        private void trackmaxX_Scroll(object sender, EventArgs e)
        {
            boxMaxCon.S0 = (float)(this.trackmaxX.Value);
            maxX.Text = Convert.ToString(trackmaxX.Value);
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }

        private void trackmaxY_Scroll(object sender, EventArgs e)
        {
            boxMaxCon.S1 = (float)(this.trackmaxY.Value);
            maxY.Text = Convert.ToString(trackmaxY.Value);
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }

        private void trackmaxZ_Scroll(object sender, EventArgs e)
        {
            boxMaxCon.S2 = (float)(this.trackmaxZ.Value);
            maxZ.Text = Convert.ToString(trackmaxZ.Value);
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }

        #endregion

        private void tracklx_Scroll(object sender, EventArgs e){
            light.S0 = (float)tracklx.Value;
            lx.Text = Convert.ToString(tracklx.Value);
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }

        private void trackly_Scroll(object sender, EventArgs e){
            light.S1 = (float)trackly.Value;
            ly.Text = Convert.ToString(trackly.Value);
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }

        private void tracklz_Scroll(object sender, EventArgs e){
            light.S2 = (float)tracklz.Value;
            lz.Text = Convert.ToString(tracklz.Value);
            if (initialize)
            {
                Draw();
                VSurface.Refresh();
            }
        }
    }
}
