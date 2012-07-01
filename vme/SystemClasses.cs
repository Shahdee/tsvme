using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using OpenCLNet;

namespace vme
{
    public enum Imagebpp { Eightbpp, Sixteenbpp };

    /* Бинарное дерево */
    public class TreeNode
    {
        public int value;
        public TreeNode left, right;
        public string code;


        public TreeNode()
        {
            value = 0;
            left = null;
            right = null;
            code = "";
        }
    }

    public class TBinarySTree
    {
        public TreeNode root;

        public TBinarySTree()
        {
            root = null;
        }
    }

    public struct Knot 
    {
        public Point p;
        public Color c;
    }

   

    public class VoxelVolume 
    {
        private readonly short[] data;
        private readonly int size_this;
        private readonly OpenCLNet.OpenCLManager manager_this;
        public OpenCLNet.Mem buffer;

        /* Создает новый объем размера size*size*size */
        public VoxelVolume(int size, OpenCLManager openClManager)
        {
            data = new short[size * size * size];
            size_this = size;
            manager_this = openClManager;
            
        }

        public Mem ReturnBuffer()
        {
            return buffer;
        }
         

        /* Возвращает значение данных в заданной позиции объема */
        public short GetValue(int x, int y, int z)
        {
            if (x < 0 || x >= size_this)
            {
                throw new ArgumentOutOfRangeException("x");
            }
            if (y < 0 || y >= size_this)
            {
                throw new ArgumentOutOfRangeException("y");
            }
            if (z < 0 || z >= size_this)
            {
                throw new ArgumentOutOfRangeException("z");
            }
            return data[x * size_this * size_this + y * size_this + z];
        }

        /* Устанавливает определенное значение данных в определенной позиции объема */
        public void SetValue(int x, int y, int z, short value) // !!!
        {
            if (x < 0 || x >= size_this)
            {
                throw new ArgumentOutOfRangeException("x");
            }
            if (y < 0 || y >= size_this)
            {
                throw new ArgumentOutOfRangeException("y");
            }
            if (z < 0 || z >= size_this)
            {
                throw new ArgumentOutOfRangeException("z");
            }
            data[x * size_this * size_this + y * size_this + z] = value;
        }

        /* возвращает буфер */
        public unsafe Mem CreateBuffer()
        {
            if (buffer == null)
            {
                /* указатели в C# используются с fixed (противодействие для GC) */
                fixed (short* dataptr = data)
                {
                    buffer = manager_this.Context.CreateBuffer(MemFlags.COPY_HOST_PTR, data.Count() * 2, new IntPtr(dataptr));
                }
            }
            return buffer;
        }

        /* Возвращает размер объема */
        public int GetSize()
        {
            return size_this;
        }      



    }

    public struct InkPoint 
    {
        public int x;
        public int y;
    }

    public static class MathClass
    {
       
        public static Float4 Add(this Float4 a, Float4 b)
        {
            return new Float4(a.S0 + b.S0, a.S1 + b.S1, a.S2 + b.S2, a.S3 + b.S3);
        }

        public static Float4 Sub(this Float4 a, Float4 b)
        {
            return new Float4(a.S0 - b.S0, a.S1 - b.S1, a.S2 - b.S2, a.S3 - b.S3);
        }

        /* функция скалярного произведения */
        public static float Dot(Float4 a, Float4 b)
        {
            return (a.S0 * b.S0) + (a.S1 * b.S1) + (a.S2 * b.S2);
        }

        /* модуль вектора */
        public static float Magnitude(this Float4 v)
        {
            return (float)Math.Sqrt(Dot(v, v));
        }

        /* умножение вектора на число */
        public static Float4 Times(this Float4 v, float scalar)
        {
            return new Float4(scalar * v.S0, scalar * v.S1, scalar * v.S2, scalar * v.S3);
        }

        /* нормализация вектора */
        public static Float4 Normalize(this Float4 v)
        {
            float mag = Magnitude(v);
            float div = mag == 0 ? float.MaxValue : 1 / mag;
            return v.Times(div);
        }

        /* функция векторного произведения */
        public static Float4 Cross(Float4 a, Float4 b)
        {
            return new Float4(((a.S1 * b.S2) - (a.S2 * b.S1)),
                     ((a.S2 * b.S0) - (a.S0 * b.S2)),
                     ((a.S0 * b.S1) - (a.S1 * b.S0)), 0);
        }
    }

}
