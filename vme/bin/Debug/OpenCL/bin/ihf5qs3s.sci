//
// Generated by NVIDIA NVVM Compiler
// Compiler built on Tue May 15 10:50:53 2012 (1337064653)
// Driver 
//

.version 3.0
.target sm_11, texmode_independent
.address_size 32


.entry DVR(
	.param .u32 DVR_param_0,
	.param .u32 DVR_param_1,
	.param .u32 .ptr .global .align 1 DVR_param_2,
	.param .u32 DVR_param_3,
	.param .align 16 .b8 DVR_param_4[16],
	.param .align 16 .b8 DVR_param_5[16],
	.param .align 16 .b8 DVR_param_6[16],
	.param .align 16 .b8 DVR_param_7[16],
	.param .u32 .ptr .global .align 2 DVR_param_8,
	.param .u32 DVR_param_9,
	.param .align 16 .b8 DVR_param_10[16],
	.param .align 16 .b8 DVR_param_11[16],
	.param .align 16 .b8 DVR_param_12[16],
	.param .u16 DVR_param_13,
	.param .u16 DVR_param_14,
	.param .u16 DVR_param_15,
	.param .u16 DVR_param_16,
	.param .u16 DVR_param_17,
	.param .u32 .ptr .global .align 4 DVR_param_18,
	.param .u32 .ptr .global .align 2 DVR_param_19,
	.param .u32 DVR_param_20,
	.param .u16 DVR_param_21,
	.param .u16 DVR_param_22
)
{
	.reg .f32 	%f<537>;
	.reg .s16 	%rs<100>;
	.reg .pred 	%p<124>;
	.reg .s32 	%r<343>;
	.reg .s16 	%rc<18>;


	ld.param.u32 	%r24, [DVR_param_0];
	ld.param.u32 	%r25, [DVR_param_1];
	ld.param.u32 	%r26, [DVR_param_2];
	ld.param.u32 	%r27, [DVR_param_3];
	ld.param.v4.f32 	{%f467, %f468, %f469, %f470}, [DVR_param_12];
	ld.param.v4.f32 	{%f463, %f464, %f465, %f466}, [DVR_param_11];
	ld.param.v4.f32 	{%f399, %f400, %f401, %f402}, [DVR_param_10];
	ld.param.v4.f32 	{%f471, %f472, %f473, %f474}, [DVR_param_7];
	ld.param.v4.f32 	{%f475, %f476, %f477, %f478}, [DVR_param_6];
	ld.param.v4.f32 	{%f479, %f480, %f481, %f482}, [DVR_param_5];
	ld.param.v4.f32 	{%f439, %f440, %f441, %f442}, [DVR_param_4];
	// inline asm
	mov.u32 	%r16, %envreg3;
	// inline asm
	// inline asm
	mov.u32 	%r17, %ntid.x;
	// inline asm
	// inline asm
	mov.u32 	%r18, %ctaid.x;
	// inline asm
	// inline asm
	mov.u32 	%r19, %tid.x;
	// inline asm
	add.s32 	%r28, %r19, %r16;
	mad.lo.s32 	%r6, %r18, %r17, %r28;
	// inline asm
	mov.u32 	%r20, %envreg4;
	// inline asm
	// inline asm
	mov.u32 	%r21, %ntid.y;
	// inline asm
	// inline asm
	mov.u32 	%r22, %ctaid.y;
	// inline asm
	// inline asm
	mov.u32 	%r23, %tid.y;
	// inline asm
	add.s32 	%r29, %r23, %r20;
	mad.lo.s32 	%r30, %r22, %r21, %r29;
	mad.lo.s32 	%r7, %r30, %r27, %r26;
	cvt.rn.f32.s32 	%f46, %r25;
	cvt.rn.f32.s32 	%f47, %r24;
	div.full.f32 	%f48, %f47, %f46;
	shr.u32 	%r31, %r24, 31;
	add.s32 	%r32, %r24, %r31;
	shr.s32 	%r33, %r32, 1;
	sub.s32 	%r34, %r6, %r33;
	cvt.rn.f32.s32 	%f49, %r34;
	add.f32 	%f50, %f47, %f47;
	div.full.f32 	%f51, %f49, %f50;
	mul.f32 	%f52, %f51, %f48;
	shr.u32 	%r35, %r25, 31;
	add.s32 	%r36, %r25, %r35;
	shr.s32 	%r37, %r36, 1;
	sub.s32 	%r38, %r30, %r37;
	cvt.rn.f32.s32 	%f53, %r38;
	add.f32 	%f54, %f46, %f46;
	div.full.f32 	%f55, %f53, %f54;
	mul.f32 	%f495, %f52, %f475;
	mul.f32 	%f496, %f52, %f476;
	mul.f32 	%f497, %f52, %f477;
	mul.f32 	%f498, %f52, %f478;
	add.f32 	%f499, %f479, %f495;
	add.f32 	%f500, %f480, %f496;
	add.f32 	%f501, %f481, %f497;
	add.f32 	%f502, %f482, %f498;
	mul.f32 	%f515, %f55, %f471;
	mul.f32 	%f516, %f55, %f472;
	mul.f32 	%f517, %f55, %f473;
	mul.f32 	%f518, %f55, %f474;
	add.f32 	%f519, %f499, %f515;
	add.f32 	%f520, %f500, %f516;
	add.f32 	%f521, %f501, %f517;
	add.f32 	%f522, %f502, %f518;
	mul.rn.f32 	%f63, %f519, %f519;
	mul.rn.f32 	%f65, %f520, %f520;
	add.f32 	%f66, %f63, %f65;
	mul.rn.f32 	%f68, %f521, %f521;
	add.f32 	%f69, %f66, %f68;
	mul.rn.f32 	%f71, %f522, %f522;
	add.f32 	%f45, %f69, %f71;
	// inline asm
	rsqrt.approx.f32 	%f44, %f45;
	// inline asm
	mul.rn.f32 	%f72, %f519, %f44;
	mul.rn.f32 	%f1, %f520, %f44;
	mul.rn.f32 	%f2, %f521, %f44;
	mul.rn.f32 	%f73, %f522, %f44;
	rcp.approx.f32 	%f74, %f72;
	sub.f32 	%f76, %f463, %f439;
	mul.f32 	%f77, %f76, %f74;
	sub.f32 	%f78, %f467, %f439;
	mul.f32 	%f79, %f78, %f74;
	setp.gt.f32 	%p6, %f77, %f79;
	selp.f32 	%f80, %f79, %f77, %p6;
	selp.f32 	%f81, %f77, %f79, %p6;
	setp.gt.f32 	%p7, %f80, 0f00800000;
	selp.f32 	%f5, %f80, 0f00800000, %p7;
	setp.lt.f32 	%p8, %f81, 0f7F7FFFFF;
	selp.f32 	%f6, %f81, 0f7F7FFFFF, %p8;
	setp.gt.f32 	%p9, %f5, %f6;
	@%p9 bra 	BB0_4;

	rcp.approx.f32 	%f82, %f1;
	sub.f32 	%f85, %f464, %f440;
	mul.f32 	%f86, %f85, %f82;
	sub.f32 	%f88, %f468, %f440;
	mul.f32 	%f89, %f88, %f82;
	setp.gt.f32 	%p10, %f86, %f89;
	selp.f32 	%f90, %f89, %f86, %p10;
	selp.f32 	%f91, %f86, %f89, %p10;
	setp.gt.f32 	%p11, %f90, %f5;
	selp.f32 	%f7, %f90, %f5, %p11;
	setp.lt.f32 	%p12, %f91, %f6;
	selp.f32 	%f8, %f91, %f6, %p12;
	setp.gt.f32 	%p13, %f7, %f8;
	@%p13 bra 	BB0_4;

	rcp.approx.f32 	%f92, %f2;
	sub.f32 	%f95, %f465, %f441;
	mul.f32 	%f96, %f95, %f92;
	sub.f32 	%f98, %f469, %f441;
	mul.f32 	%f99, %f98, %f92;
	setp.gt.f32 	%p14, %f96, %f99;
	selp.f32 	%f100, %f99, %f96, %p14;
	selp.f32 	%f101, %f96, %f99, %p14;
	setp.gt.f32 	%p15, %f100, %f7;
	selp.f32 	%f524, %f100, %f7, %p15;
	setp.lt.f32 	%p16, %f101, %f8;
	selp.f32 	%f523, %f101, %f8, %p16;
	setp.gt.f32 	%p17, %f524, %f523;
	@%p17 bra 	BB0_4;

	mov.pred 	%p123, -1;
	bra.uni 	BB0_5;

BB0_4:
	mov.pred 	%p123, 0;
	mov.f32 	%f524, 0f00000000;
	mov.f32 	%f523, %f524;

BB0_5:
	@!%p123 bra 	BB0_8;

	add.f32 	%f13, %f463, 0f3F800000;
	add.f32 	%f14, %f467, 0fBF800000;
	add.f32 	%f15, %f464, 0f3F800000;
	add.f32 	%f16, %f468, 0fBF800000;
	add.f32 	%f17, %f465, 0f3F800000;
	add.f32 	%f18, %f469, 0fBF800000;
	ld.param.u32 	%r338, [DVR_param_9];
	cvt.rn.f32.s32 	%f19, %r338;
	ld.param.u16 	%rs85, [DVR_param_16];
	setp.eq.s16 	%p2, %rs85, 0;
	ld.param.u16 	%rs84, [DVR_param_15];
	setp.eq.s16 	%p3, %rs84, 1;
	setp.eq.s16 	%p4, %rs85, 1;
	mov.u16 	%rs97, %rs25;
	mov.u16 	%rs98, %rs26;

BB0_7:
	setp.lt.f32 	%p20, %f524, %f523;
	@%p20 bra 	BB0_9;

BB0_8:
	mov.f32 	%f108, 0f00000000;
	mov.f32 	%f528, %f108;
	mov.f32 	%f529, %f108;
	mov.f32 	%f530, %f108;
	mov.f32 	%f346, %f108;
	bra.uni 	BB0_70;

BB0_9:
	mul.f32 	%f455, %f524, %f72;
	mul.f32 	%f456, %f524, %f1;
	mul.f32 	%f457, %f524, %f2;
	add.f32 	%f459, %f439, %f455;
	add.f32 	%f460, %f440, %f456;
	add.f32 	%f461, %f441, %f457;
	setp.lt.f32 	%p21, %f459, %f13;
	setp.gt.f32 	%p22, %f459, %f14;
	or.pred  	%p23, %p21, %p22;
	setp.lt.f32 	%p24, %f460, %f15;
	or.pred  	%p25, %p23, %p24;
	setp.gt.f32 	%p26, %f460, %f16;
	or.pred  	%p27, %p25, %p26;
	setp.lt.f32 	%p28, %f461, %f17;
	or.pred  	%p29, %p27, %p28;
	setp.gt.f32 	%p30, %f461, %f18;
	or.pred  	%p31, %p29, %p30;
	@%p31 bra 	BB0_18;

	setp.ge.f32 	%p32, %f459, %f19;
	setp.lt.f32 	%p33, %f459, 0f00000000;
	or.pred  	%p34, %p32, %p33;
	@%p34 bra 	BB0_18;

	setp.ge.f32 	%p35, %f460, %f19;
	setp.lt.f32 	%p36, %f460, 0f00000000;
	or.pred  	%p37, %p35, %p36;
	@%p37 bra 	BB0_18;

	setp.ge.f32 	%p38, %f461, %f19;
	setp.lt.f32 	%p39, %f461, 0f00000000;
	or.pred  	%p40, %p38, %p39;
	@%p40 bra 	BB0_18;

	@%p2 bra 	BB0_19;

	@%p4 bra 	BB0_15;
	bra.uni 	BB0_23;

BB0_15:
	add.f32 	%f112, %f459, 0fBF800000;
	sub.f32 	%f113, %f459, %f112;
	add.f32 	%f114, %f459, 0f3F800000;
	mov.f32 	%f115, 0f3F800000;
	sub.f32 	%f116, %f114, %f112;
	div.full.f32 	%f117, %f113, %f116;
	add.f32 	%f118, %f460, 0fBF800000;
	sub.f32 	%f119, %f460, %f118;
	add.f32 	%f120, %f460, 0f3F800000;
	sub.f32 	%f121, %f120, %f118;
	div.full.f32 	%f122, %f119, %f121;
	add.f32 	%f123, %f461, 0fBF800000;
	sub.f32 	%f124, %f461, %f123;
	add.f32 	%f125, %f461, 0f3F800000;
	sub.f32 	%f126, %f125, %f123;
	div.full.f32 	%f127, %f124, %f126;
	cvt.rzi.s32.f32 	%r39, %f112;
	cvt.rzi.s32.f32 	%r40, %f118;
	ld.param.u32 	%r337, [DVR_param_9];
	mad.lo.s32 	%r41, %r39, %r337, %r40;
	cvt.rzi.s32.f32 	%r42, %f123;
	mad.lo.s32 	%r43, %r41, %r337, %r42;
	shl.b32 	%r44, %r43, 1;
	ld.param.u32 	%r329, [DVR_param_8];
	add.s32 	%r45, %r329, %r44;
	ld.global.u16 	%rs27, [%r45];
	cvt.rn.f32.s16 	%f128, %rs27;
	sub.f32 	%f129, %f115, %f117;
	mul.f32 	%f130, %f128, %f129;
	cvt.rzi.s32.f32 	%r46, %f114;
	mad.lo.s32 	%r47, %r46, %r337, %r40;
	mad.lo.s32 	%r48, %r47, %r337, %r42;
	shl.b32 	%r49, %r48, 1;
	add.s32 	%r50, %r329, %r49;
	ld.global.u16 	%rs28, [%r50];
	cvt.rn.f32.s16 	%f131, %rs28;
	mul.f32 	%f132, %f131, %f117;
	add.f32 	%f133, %f130, %f132;
	cvt.rzi.s16.f32 	%rs29, %f133;
	cvt.rzi.s32.f32 	%r51, %f120;
	mad.lo.s32 	%r52, %r39, %r337, %r51;
	mad.lo.s32 	%r53, %r52, %r337, %r42;
	shl.b32 	%r54, %r53, 1;
	add.s32 	%r55, %r329, %r54;
	ld.global.u16 	%rs30, [%r55];
	cvt.rn.f32.s16 	%f134, %rs30;
	mul.f32 	%f135, %f134, %f129;
	mad.lo.s32 	%r56, %r46, %r337, %r51;
	mad.lo.s32 	%r57, %r56, %r337, %r42;
	shl.b32 	%r58, %r57, 1;
	add.s32 	%r59, %r329, %r58;
	ld.global.u16 	%rs31, [%r59];
	cvt.rn.f32.s16 	%f136, %rs31;
	mul.f32 	%f137, %f136, %f117;
	add.f32 	%f138, %f135, %f137;
	cvt.rzi.s16.f32 	%rs32, %f138;
	cvt.rzi.s32.f32 	%r60, %f125;
	mad.lo.s32 	%r61, %r41, %r337, %r60;
	shl.b32 	%r62, %r61, 1;
	add.s32 	%r63, %r329, %r62;
	ld.global.u16 	%rs33, [%r63];
	cvt.rn.f32.s16 	%f139, %rs33;
	mul.f32 	%f140, %f139, %f129;
	mad.lo.s32 	%r64, %r47, %r337, %r60;
	shl.b32 	%r65, %r64, 1;
	add.s32 	%r66, %r329, %r65;
	ld.global.u16 	%rs34, [%r66];
	cvt.rn.f32.s16 	%f141, %rs34;
	mul.f32 	%f142, %f141, %f117;
	add.f32 	%f143, %f140, %f142;
	cvt.rzi.s16.f32 	%rs35, %f143;
	mad.lo.s32 	%r67, %r52, %r337, %r60;
	shl.b32 	%r68, %r67, 1;
	add.s32 	%r69, %r329, %r68;
	ld.global.u16 	%rs36, [%r69];
	cvt.rn.f32.s16 	%f144, %rs36;
	mul.f32 	%f145, %f144, %f129;
	mad.lo.s32 	%r70, %r56, %r337, %r60;
	shl.b32 	%r71, %r70, 1;
	add.s32 	%r72, %r329, %r71;
	ld.global.u16 	%rs37, [%r72];
	cvt.rn.f32.s16 	%f146, %rs37;
	mul.f32 	%f147, %f146, %f117;
	add.f32 	%f148, %f145, %f147;
	cvt.rzi.s16.f32 	%rs38, %f148;
	cvt.rn.f32.s16 	%f149, %rs29;
	sub.f32 	%f150, %f115, %f122;
	mul.f32 	%f151, %f149, %f150;
	cvt.rn.f32.s16 	%f152, %rs32;
	mul.f32 	%f153, %f152, %f122;
	add.f32 	%f154, %f151, %f153;
	cvt.rzi.s16.f32 	%rs39, %f154;
	cvt.rn.f32.s16 	%f155, %rs35;
	mul.f32 	%f156, %f155, %f150;
	cvt.rn.f32.s16 	%f157, %rs38;
	mul.f32 	%f158, %f157, %f122;
	add.f32 	%f159, %f156, %f158;
	cvt.rzi.s16.f32 	%rs40, %f159;
	cvt.rn.f32.s16 	%f160, %rs39;
	sub.f32 	%f161, %f115, %f127;
	mul.f32 	%f162, %f160, %f161;
	cvt.rn.f32.s16 	%f163, %rs40;
	mul.f32 	%f164, %f163, %f127;
	add.f32 	%f165, %f162, %f164;
	cvt.rzi.s16.f32 	%rs97, %f165;
	@!%p3 bra 	BB0_23;

	ld.param.u16 	%rs78, [DVR_param_13];
	setp.gt.s16 	%p41, %rs97, %rs78;
	ld.param.u16 	%rs83, [DVR_param_14];
	setp.lt.s16 	%p42, %rs97, %rs83;
	and.pred  	%p43, %p41, %p42;
	@%p43 bra 	BB0_18;

	ld.param.u16 	%rs91, [DVR_param_21];
	setp.gt.s16 	%p44, %rs97, %rs91;
	ld.param.u16 	%rs96, [DVR_param_22];
	setp.lt.s16 	%p45, %rs97, %rs96;
	and.pred  	%p46, %p44, %p45;
	@%p46 bra 	BB0_18;
	bra.uni 	BB0_23;

BB0_18:
	mov.u16 	%rs97, 0;
	bra.uni 	BB0_23;

BB0_19:
	@!%p3 bra 	BB0_22;

	cvt.rzi.s32.f32 	%r73, %f459;
	cvt.rzi.s32.f32 	%r74, %f460;
	ld.param.u32 	%r336, [DVR_param_9];
	mad.lo.s32 	%r75, %r73, %r336, %r74;
	cvt.rzi.s32.f32 	%r76, %f461;
	mad.lo.s32 	%r77, %r75, %r336, %r76;
	shl.b32 	%r78, %r77, 1;
	ld.param.u32 	%r328, [DVR_param_8];
	add.s32 	%r79, %r328, %r78;
	ld.global.u16 	%rs11, [%r79];
	ld.param.u16 	%rs77, [DVR_param_13];
	setp.gt.s16 	%p47, %rs11, %rs77;
	ld.param.u16 	%rs82, [DVR_param_14];
	setp.lt.s16 	%p48, %rs11, %rs82;
	and.pred  	%p49, %p47, %p48;
	@%p49 bra 	BB0_18;

	ld.param.u16 	%rs90, [DVR_param_21];
	setp.gt.s16 	%p50, %rs11, %rs90;
	ld.param.u16 	%rs95, [DVR_param_22];
	setp.lt.s16 	%p51, %rs11, %rs95;
	and.pred  	%p52, %p50, %p51;
	@%p52 bra 	BB0_18;

BB0_22:
	cvt.rzi.s32.f32 	%r80, %f459;
	cvt.rzi.s32.f32 	%r81, %f460;
	ld.param.u32 	%r335, [DVR_param_9];
	mad.lo.s32 	%r82, %r80, %r335, %r81;
	cvt.rzi.s32.f32 	%r83, %f461;
	mad.lo.s32 	%r84, %r82, %r335, %r83;
	shl.b32 	%r85, %r84, 1;
	ld.param.u32 	%r327, [DVR_param_8];
	add.s32 	%r86, %r327, %r85;
	ld.global.u16 	%rs97, [%r86];

BB0_23:
	setp.eq.s16 	%p53, %rs97, 0;
	@%p53 bra 	BB0_81;

	add.f32 	%f525, %f524, 0fC0A00000;

BB0_25:
	setp.lt.f32 	%p54, %f525, %f523;
	@%p54 bra 	BB0_26;
	bra.uni 	BB0_81;

BB0_26:
	mul.f32 	%f431, %f525, %f72;
	mul.f32 	%f432, %f525, %f1;
	mul.f32 	%f433, %f525, %f2;
	mul.f32 	%f434, %f525, %f73;
	add.f32 	%f403, %f439, %f431;
	add.f32 	%f404, %f440, %f432;
	add.f32 	%f405, %f441, %f433;
	add.f32 	%f406, %f442, %f434;
	setp.lt.f32 	%p5, %f403, %f13;
	setp.gt.f32 	%p55, %f403, %f14;
	or.pred  	%p56, %p5, %p55;
	setp.lt.f32 	%p57, %f404, %f15;
	or.pred  	%p58, %p56, %p57;
	setp.gt.f32 	%p59, %f404, %f16;
	or.pred  	%p60, %p58, %p59;
	setp.lt.f32 	%p61, %f405, %f17;
	or.pred  	%p62, %p60, %p61;
	setp.gt.f32 	%p63, %f405, %f18;
	or.pred  	%p64, %p62, %p63;
	@%p64 bra 	BB0_35;

	setp.ge.f32 	%p65, %f403, %f19;
	setp.lt.f32 	%p66, %f403, 0f00000000;
	or.pred  	%p67, %p65, %p66;
	@%p67 bra 	BB0_35;

	setp.ge.f32 	%p68, %f404, %f19;
	setp.lt.f32 	%p69, %f404, 0f00000000;
	or.pred  	%p70, %p68, %p69;
	@%p70 bra 	BB0_35;

	setp.ge.f32 	%p71, %f405, %f19;
	setp.lt.f32 	%p72, %f405, 0f00000000;
	or.pred  	%p73, %p71, %p72;
	@%p73 bra 	BB0_35;

	@%p2 bra 	BB0_36;

	@%p4 bra 	BB0_32;
	bra.uni 	BB0_40;

BB0_32:
	add.f32 	%f169, %f403, 0fBF800000;
	sub.f32 	%f170, %f403, %f169;
	add.f32 	%f171, %f403, 0f3F800000;
	mov.f32 	%f172, 0f3F800000;
	sub.f32 	%f173, %f171, %f169;
	div.full.f32 	%f174, %f170, %f173;
	add.f32 	%f175, %f404, 0fBF800000;
	sub.f32 	%f176, %f404, %f175;
	add.f32 	%f177, %f404, 0f3F800000;
	sub.f32 	%f178, %f177, %f175;
	div.full.f32 	%f179, %f176, %f178;
	add.f32 	%f180, %f405, 0fBF800000;
	sub.f32 	%f181, %f405, %f180;
	add.f32 	%f182, %f405, 0f3F800000;
	sub.f32 	%f183, %f182, %f180;
	div.full.f32 	%f184, %f181, %f183;
	cvt.rzi.s32.f32 	%r87, %f169;
	cvt.rzi.s32.f32 	%r88, %f175;
	ld.param.u32 	%r334, [DVR_param_9];
	mad.lo.s32 	%r89, %r87, %r334, %r88;
	cvt.rzi.s32.f32 	%r90, %f180;
	mad.lo.s32 	%r91, %r89, %r334, %r90;
	shl.b32 	%r92, %r91, 1;
	ld.param.u32 	%r326, [DVR_param_8];
	add.s32 	%r93, %r326, %r92;
	ld.global.u16 	%rs42, [%r93];
	cvt.rn.f32.s16 	%f185, %rs42;
	sub.f32 	%f186, %f172, %f174;
	mul.f32 	%f187, %f185, %f186;
	cvt.rzi.s32.f32 	%r94, %f171;
	mad.lo.s32 	%r95, %r94, %r334, %r88;
	mad.lo.s32 	%r96, %r95, %r334, %r90;
	shl.b32 	%r97, %r96, 1;
	add.s32 	%r98, %r326, %r97;
	ld.global.u16 	%rs43, [%r98];
	cvt.rn.f32.s16 	%f188, %rs43;
	mul.f32 	%f189, %f188, %f174;
	add.f32 	%f190, %f187, %f189;
	cvt.rzi.s16.f32 	%rs44, %f190;
	cvt.rzi.s32.f32 	%r99, %f177;
	mad.lo.s32 	%r100, %r87, %r334, %r99;
	mad.lo.s32 	%r101, %r100, %r334, %r90;
	shl.b32 	%r102, %r101, 1;
	add.s32 	%r103, %r326, %r102;
	ld.global.u16 	%rs45, [%r103];
	cvt.rn.f32.s16 	%f191, %rs45;
	mul.f32 	%f192, %f191, %f186;
	mad.lo.s32 	%r104, %r94, %r334, %r99;
	mad.lo.s32 	%r105, %r104, %r334, %r90;
	shl.b32 	%r106, %r105, 1;
	add.s32 	%r107, %r326, %r106;
	ld.global.u16 	%rs46, [%r107];
	cvt.rn.f32.s16 	%f193, %rs46;
	mul.f32 	%f194, %f193, %f174;
	add.f32 	%f195, %f192, %f194;
	cvt.rzi.s16.f32 	%rs47, %f195;
	cvt.rzi.s32.f32 	%r108, %f182;
	mad.lo.s32 	%r109, %r89, %r334, %r108;
	shl.b32 	%r110, %r109, 1;
	add.s32 	%r111, %r326, %r110;
	ld.global.u16 	%rs48, [%r111];
	cvt.rn.f32.s16 	%f196, %rs48;
	mul.f32 	%f197, %f196, %f186;
	mad.lo.s32 	%r112, %r95, %r334, %r108;
	shl.b32 	%r113, %r112, 1;
	add.s32 	%r114, %r326, %r113;
	ld.global.u16 	%rs49, [%r114];
	cvt.rn.f32.s16 	%f198, %rs49;
	mul.f32 	%f199, %f198, %f174;
	add.f32 	%f200, %f197, %f199;
	cvt.rzi.s16.f32 	%rs50, %f200;
	mad.lo.s32 	%r115, %r100, %r334, %r108;
	shl.b32 	%r116, %r115, 1;
	add.s32 	%r117, %r326, %r116;
	ld.global.u16 	%rs51, [%r117];
	cvt.rn.f32.s16 	%f201, %rs51;
	mul.f32 	%f202, %f201, %f186;
	mad.lo.s32 	%r118, %r104, %r334, %r108;
	shl.b32 	%r119, %r118, 1;
	add.s32 	%r120, %r326, %r119;
	ld.global.u16 	%rs52, [%r120];
	cvt.rn.f32.s16 	%f203, %rs52;
	mul.f32 	%f204, %f203, %f174;
	add.f32 	%f205, %f202, %f204;
	cvt.rzi.s16.f32 	%rs53, %f205;
	cvt.rn.f32.s16 	%f206, %rs44;
	sub.f32 	%f207, %f172, %f179;
	mul.f32 	%f208, %f206, %f207;
	cvt.rn.f32.s16 	%f209, %rs47;
	mul.f32 	%f210, %f209, %f179;
	add.f32 	%f211, %f208, %f210;
	cvt.rzi.s16.f32 	%rs54, %f211;
	cvt.rn.f32.s16 	%f212, %rs50;
	mul.f32 	%f213, %f212, %f207;
	cvt.rn.f32.s16 	%f214, %rs53;
	mul.f32 	%f215, %f214, %f179;
	add.f32 	%f216, %f213, %f215;
	cvt.rzi.s16.f32 	%rs55, %f216;
	cvt.rn.f32.s16 	%f217, %rs54;
	sub.f32 	%f218, %f172, %f184;
	mul.f32 	%f219, %f217, %f218;
	cvt.rn.f32.s16 	%f220, %rs55;
	mul.f32 	%f221, %f220, %f184;
	add.f32 	%f222, %f219, %f221;
	cvt.rzi.s16.f32 	%rs98, %f222;
	@!%p3 bra 	BB0_40;

	ld.param.u16 	%rs76, [DVR_param_13];
	setp.gt.s16 	%p74, %rs98, %rs76;
	ld.param.u16 	%rs81, [DVR_param_14];
	setp.lt.s16 	%p75, %rs98, %rs81;
	and.pred  	%p76, %p74, %p75;
	@%p76 bra 	BB0_35;

	ld.param.u16 	%rs89, [DVR_param_21];
	setp.gt.s16 	%p77, %rs98, %rs89;
	ld.param.u16 	%rs94, [DVR_param_22];
	setp.lt.s16 	%p78, %rs98, %rs94;
	and.pred  	%p79, %p77, %p78;
	@%p79 bra 	BB0_35;
	bra.uni 	BB0_40;

BB0_35:
	mov.u16 	%rs98, 0;
	bra.uni 	BB0_40;

BB0_36:
	@!%p3 bra 	BB0_39;

	cvt.rzi.s32.f32 	%r121, %f403;
	cvt.rzi.s32.f32 	%r122, %f404;
	ld.param.u32 	%r333, [DVR_param_9];
	mad.lo.s32 	%r123, %r121, %r333, %r122;
	cvt.rzi.s32.f32 	%r124, %f405;
	mad.lo.s32 	%r125, %r123, %r333, %r124;
	shl.b32 	%r126, %r125, 1;
	ld.param.u32 	%r325, [DVR_param_8];
	add.s32 	%r127, %r325, %r126;
	ld.global.u16 	%rs16, [%r127];
	ld.param.u16 	%rs75, [DVR_param_13];
	setp.gt.s16 	%p80, %rs16, %rs75;
	ld.param.u16 	%rs80, [DVR_param_14];
	setp.lt.s16 	%p81, %rs16, %rs80;
	and.pred  	%p82, %p80, %p81;
	@%p82 bra 	BB0_35;

	ld.param.u16 	%rs88, [DVR_param_21];
	setp.gt.s16 	%p83, %rs16, %rs88;
	ld.param.u16 	%rs93, [DVR_param_22];
	setp.lt.s16 	%p84, %rs16, %rs93;
	and.pred  	%p85, %p83, %p84;
	@%p85 bra 	BB0_35;

BB0_39:
	cvt.rzi.s32.f32 	%r128, %f403;
	cvt.rzi.s32.f32 	%r129, %f404;
	ld.param.u32 	%r332, [DVR_param_9];
	mad.lo.s32 	%r130, %r128, %r332, %r129;
	cvt.rzi.s32.f32 	%r131, %f405;
	mad.lo.s32 	%r132, %r130, %r332, %r131;
	shl.b32 	%r133, %r132, 1;
	ld.param.u32 	%r324, [DVR_param_8];
	add.s32 	%r134, %r324, %r133;
	ld.global.u16 	%rs98, [%r134];

BB0_40:
	setp.eq.s16 	%p86, %rs98, 0;
	@%p86 bra 	BB0_80;

	cvt.rzi.s32.f32 	%r135, %f403;
	add.s32 	%r136, %r135, -2;
	cvt.rzi.s32.f32 	%r137, %f404;
	add.s32 	%r138, %r137, -1;
	ld.param.u32 	%r331, [DVR_param_9];
	mad.lo.s32 	%r139, %r136, %r331, %r138;
	cvt.rzi.s32.f32 	%r140, %f405;
	mad.lo.s32 	%r141, %r139, %r331, %r140;
	shl.b32 	%r142, %r141, 1;
	ld.param.u32 	%r323, [DVR_param_8];
	add.s32 	%r143, %r323, %r142;
	mad.lo.s32 	%r144, %r136, %r331, %r137;
	mad.lo.s32 	%r145, %r144, %r331, %r140;
	shl.b32 	%r146, %r145, 1;
	add.s32 	%r147, %r323, %r146;
	add.s32 	%r148, %r137, 1;
	mad.lo.s32 	%r149, %r136, %r331, %r148;
	mad.lo.s32 	%r150, %r149, %r331, %r140;
	shl.b32 	%r151, %r150, 1;
	add.s32 	%r152, %r323, %r151;
	add.s32 	%r153, %r135, -1;
	mul.lo.s32 	%r154, %r331, %r331;
	shl.b32 	%r155, %r154, 1;
	add.s32 	%r156, %r143, %r155;
	add.s32 	%r157, %r147, %r155;
	add.s32 	%r158, %r152, %r155;
	add.s32 	%r159, %r156, %r155;
	add.s32 	%r8, %r157, %r155;
	add.s32 	%r160, %r158, %r155;
	add.s32 	%r161, %r135, 1;
	mad.lo.s32 	%r162, %r161, %r331, %r138;
	add.s32 	%r163, %r159, %r155;
	add.s32 	%r164, %r8, %r155;
	add.s32 	%r165, %r160, %r155;
	add.s32 	%r166, %r135, 2;
	add.s32 	%r167, %r163, %r155;
	mad.lo.s32 	%r168, %r166, %r331, %r137;
	mad.lo.s32 	%r169, %r168, %r331, %r140;
	shl.b32 	%r170, %r169, 1;
	add.s32 	%r171, %r323, %r170;
	mad.lo.s32 	%r172, %r166, %r331, %r148;
	mad.lo.s32 	%r173, %r172, %r331, %r140;
	shl.b32 	%r174, %r173, 1;
	add.s32 	%r175, %r323, %r174;
	ld.global.s16 	%r176, [%r147];
	ld.global.s16 	%r177, [%r156];
	add.s32 	%r178, %r177, %r176;
	ld.global.s16 	%r179, [%r158];
	add.s32 	%r180, %r178, %r179;
	ld.global.s16 	%r181, [%r163];
	sub.s32 	%r182, %r181, %r180;
	ld.global.s16 	%r183, [%r165];
	add.s32 	%r184, %r182, %r183;
	ld.global.s16 	%r185, [%r171];
	add.s32 	%r186, %r184, %r185;
	ld.global.s16 	%r187, [%r157];
	ld.global.s16 	%r188, [%r164];
	sub.s32 	%r189, %r188, %r187;
	ld.global.s16 	%r190, [%r143];
	ld.global.s16 	%r191, [%r152];
	add.s32 	%r192, %r191, %r190;
	ld.global.s16 	%r193, [%r159];
	add.s32 	%r194, %r192, %r193;
	ld.global.s16 	%r195, [%r160];
	add.s32 	%r196, %r194, %r195;
	sub.s32 	%r197, %r193, %r196;
	add.s32 	%r198, %r197, %r195;
	ld.global.s16 	%r199, [%r167];
	add.s32 	%r200, %r198, %r199;
	ld.global.s16 	%r201, [%r175];
	add.s32 	%r202, %r200, %r201;
	mad.lo.s32 	%r203, %r186, 3, %r202;
	mad.lo.s32 	%r204, %r189, 6, %r203;
	cvt.rn.f32.s32 	%f225, %r204;
	mad.lo.s32 	%r205, %r153, %r331, %r137;
	add.s32 	%r206, %r205, -2;
	mad.lo.s32 	%r207, %r206, %r331, %r140;
	shl.b32 	%r208, %r207, 1;
	add.s32 	%r209, %r323, %r208;
	add.s32 	%r210, %r209, %r155;
	add.s32 	%r211, %r210, %r155;
	add.s32 	%r212, %r205, 2;
	mad.lo.s32 	%r213, %r212, %r331, %r140;
	shl.b32 	%r214, %r213, 1;
	add.s32 	%r215, %r323, %r214;
	add.s32 	%r216, %r215, %r155;
	add.s32 	%r217, %r216, %r155;
	ld.global.s16 	%r218, [%r8];
	ld.global.s16 	%r219, [%r210];
	sub.s32 	%r220, %r219, %r218;
	add.s32 	%r221, %r220, %r177;
	sub.s32 	%r222, %r221, %r179;
	add.s32 	%r223, %r222, %r181;
	sub.s32 	%r224, %r223, %r183;
	add.s32 	%r225, %r224, %r218;
	ld.global.s16 	%r226, [%r216];
	sub.s32 	%r227, %r225, %r226;
	sub.s32 	%r228, %r193, %r195;
	ld.global.s16 	%r229, [%r209];
	sub.s32 	%r230, %r229, %r187;
	ld.global.s16 	%r231, [%r211];
	add.s32 	%r232, %r230, %r231;
	sub.s32 	%r233, %r232, %r188;
	add.s32 	%r234, %r233, %r187;
	ld.global.s16 	%r235, [%r215];
	sub.s32 	%r236, %r234, %r235;
	add.s32 	%r237, %r236, %r188;
	ld.global.s16 	%r238, [%r217];
	sub.s32 	%r239, %r237, %r238;
	mad.lo.s32 	%r240, %r227, 3, %r239;
	mad.lo.s32 	%r241, %r228, 6, %r240;
	cvt.rn.f32.s32 	%f226, %r241;
	ld.global.s16 	%r242, [%r157+-2];
	ld.global.s16 	%r243, [%r164+-2];
	sub.s32 	%r244, %r243, %r242;
	sub.s32 	%r245, %r244, %r177;
	sub.s32 	%r246, %r245, %r179;
	add.s32 	%r247, %r246, %r181;
	add.s32 	%r248, %r247, %r183;
	ld.global.s16 	%r249, [%r157+2];
	sub.s32 	%r250, %r248, %r249;
	ld.global.s16 	%r251, [%r164+2];
	add.s32 	%r252, %r250, %r251;
	ld.global.s16 	%r253, [%r156+-2];
	ld.global.s16 	%r254, [%r158+-2];
	add.s32 	%r255, %r254, %r253;
	mad.lo.s32 	%r256, %r162, %r331, %r140;
	shl.b32 	%r257, %r256, 1;
	add.s32 	%r258, %r257, %r323;
	ld.global.s16 	%r259, [%r258+-2];
	sub.s32 	%r260, %r259, %r255;
	ld.global.s16 	%r261, [%r165+-2];
	add.s32 	%r262, %r260, %r261;
	mad.lo.s32 	%r263, %r187, -6, %r262;
	ld.global.s16 	%r264, [%r156+2];
	sub.s32 	%r265, %r263, %r264;
	ld.global.s16 	%r266, [%r158+2];
	sub.s32 	%r267, %r265, %r266;
	ld.global.s16 	%r268, [%r258+2];
	add.s32 	%r269, %r267, %r268;
	ld.global.s16 	%r270, [%r165+2];
	add.s32 	%r271, %r269, %r270;
	mad.lo.s32 	%r272, %r252, 3, %r271;
	cvt.rn.f32.s32 	%f227, %r272;
	neg.f32 	%f228, %f226;
	neg.f32 	%f229, %f227;
	mul.rn.f32 	%f230, %f225, %f225;
	mul.rn.f32 	%f231, %f228, %f228;
	add.f32 	%f232, %f230, %f231;
	mul.rn.f32 	%f233, %f229, %f229;
	add.f32 	%f234, %f232, %f233;
	mov.f32 	%f526, 0f00000000;
	mul.rn.f32 	%f236, %f526, %f526;
	add.f32 	%f224, %f234, %f236;
	// inline asm
	rsqrt.approx.f32 	%f223, %f224;
	// inline asm
	mul.rn.f32 	%f29, %f225, %f223;
	mul.rn.f32 	%f30, %f228, %f223;
	mul.rn.f32 	%f31, %f229, %f223;
	mul.rn.f32 	%f32, %f526, %f223;
	@%p64 bra 	BB0_49;

	setp.ge.f32 	%p97, %f403, %f19;
	setp.lt.f32 	%p98, %f403, 0f00000000;
	or.pred  	%p99, %p97, %p98;
	@%p99 bra 	BB0_49;

	setp.ge.f32 	%p100, %f404, %f19;
	setp.lt.f32 	%p101, %f404, 0f00000000;
	or.pred  	%p102, %p100, %p101;
	@%p102 bra 	BB0_49;

	setp.ge.f32 	%p103, %f405, %f19;
	setp.lt.f32 	%p104, %f405, 0f00000000;
	or.pred  	%p105, %p103, %p104;
	@%p105 bra 	BB0_49;

	@%p2 bra 	BB0_48;

	@%p4 bra 	BB0_47;
	bra.uni 	BB0_50;

BB0_47:
	add.f32 	%f237, %f403, 0fBF800000;
	sub.f32 	%f238, %f403, %f237;
	add.f32 	%f239, %f403, 0f3F800000;
	mov.f32 	%f240, 0f3F800000;
	sub.f32 	%f241, %f239, %f237;
	div.full.f32 	%f242, %f238, %f241;
	add.f32 	%f243, %f404, 0fBF800000;
	sub.f32 	%f244, %f404, %f243;
	add.f32 	%f245, %f404, 0f3F800000;
	sub.f32 	%f246, %f245, %f243;
	div.full.f32 	%f247, %f244, %f246;
	add.f32 	%f248, %f405, 0fBF800000;
	sub.f32 	%f249, %f405, %f248;
	add.f32 	%f250, %f405, 0f3F800000;
	sub.f32 	%f251, %f250, %f248;
	div.full.f32 	%f252, %f249, %f251;
	cvt.rzi.s32.f32 	%r273, %f237;
	cvt.rzi.s32.f32 	%r274, %f243;
	ld.param.u32 	%r330, [DVR_param_9];
	mad.lo.s32 	%r275, %r273, %r330, %r274;
	cvt.rzi.s32.f32 	%r276, %f248;
	mad.lo.s32 	%r277, %r275, %r330, %r276;
	shl.b32 	%r278, %r277, 1;
	ld.param.u32 	%r322, [DVR_param_8];
	add.s32 	%r279, %r322, %r278;
	ld.global.u16 	%rs58, [%r279];
	cvt.rn.f32.s16 	%f253, %rs58;
	sub.f32 	%f254, %f240, %f242;
	mul.f32 	%f255, %f253, %f254;
	cvt.rzi.s32.f32 	%r280, %f239;
	mad.lo.s32 	%r281, %r280, %r330, %r274;
	mad.lo.s32 	%r282, %r281, %r330, %r276;
	shl.b32 	%r283, %r282, 1;
	add.s32 	%r284, %r322, %r283;
	ld.global.u16 	%rs59, [%r284];
	cvt.rn.f32.s16 	%f256, %rs59;
	mul.f32 	%f257, %f256, %f242;
	add.f32 	%f258, %f255, %f257;
	cvt.rzi.s16.f32 	%rs60, %f258;
	cvt.rzi.s32.f32 	%r285, %f245;
	mad.lo.s32 	%r286, %r273, %r330, %r285;
	mad.lo.s32 	%r287, %r286, %r330, %r276;
	shl.b32 	%r288, %r287, 1;
	add.s32 	%r289, %r322, %r288;
	ld.global.u16 	%rs61, [%r289];
	cvt.rn.f32.s16 	%f259, %rs61;
	mul.f32 	%f260, %f259, %f254;
	mad.lo.s32 	%r290, %r280, %r330, %r285;
	mad.lo.s32 	%r291, %r290, %r330, %r276;
	shl.b32 	%r292, %r291, 1;
	add.s32 	%r293, %r322, %r292;
	ld.global.u16 	%rs62, [%r293];
	cvt.rn.f32.s16 	%f261, %rs62;
	mul.f32 	%f262, %f261, %f242;
	add.f32 	%f263, %f260, %f262;
	cvt.rzi.s16.f32 	%rs63, %f263;
	cvt.rzi.s32.f32 	%r294, %f250;
	mad.lo.s32 	%r295, %r275, %r330, %r294;
	shl.b32 	%r296, %r295, 1;
	add.s32 	%r297, %r322, %r296;
	ld.global.u16 	%rs64, [%r297];
	cvt.rn.f32.s16 	%f264, %rs64;
	mul.f32 	%f265, %f264, %f254;
	mad.lo.s32 	%r298, %r281, %r330, %r294;
	shl.b32 	%r299, %r298, 1;
	add.s32 	%r300, %r322, %r299;
	ld.global.u16 	%rs65, [%r300];
	cvt.rn.f32.s16 	%f266, %rs65;
	mul.f32 	%f267, %f266, %f242;
	add.f32 	%f268, %f265, %f267;
	cvt.rzi.s16.f32 	%rs66, %f268;
	mad.lo.s32 	%r301, %r286, %r330, %r294;
	shl.b32 	%r302, %r301, 1;
	add.s32 	%r303, %r322, %r302;
	ld.global.u16 	%rs67, [%r303];
	cvt.rn.f32.s16 	%f269, %rs67;
	mul.f32 	%f270, %f269, %f254;
	mad.lo.s32 	%r304, %r290, %r330, %r294;
	shl.b32 	%r305, %r304, 1;
	add.s32 	%r306, %r322, %r305;
	ld.global.u16 	%rs68, [%r306];
	cvt.rn.f32.s16 	%f271, %rs68;
	mul.f32 	%f272, %f271, %f242;
	add.f32 	%f273, %f270, %f272;
	cvt.rzi.s16.f32 	%rs69, %f273;
	cvt.rn.f32.s16 	%f274, %rs60;
	sub.f32 	%f275, %f240, %f247;
	mul.f32 	%f276, %f274, %f275;
	cvt.rn.f32.s16 	%f277, %rs63;
	mul.f32 	%f278, %f277, %f247;
	add.f32 	%f279, %f276, %f278;
	cvt.rzi.s16.f32 	%rs70, %f279;
	cvt.rn.f32.s16 	%f280, %rs66;
	mul.f32 	%f281, %f280, %f275;
	cvt.rn.f32.s16 	%f282, %rs69;
	mul.f32 	%f283, %f282, %f247;
	add.f32 	%f284, %f281, %f283;
	cvt.rzi.s16.f32 	%rs71, %f284;
	cvt.rn.f32.s16 	%f285, %rs70;
	sub.f32 	%f286, %f240, %f252;
	mul.f32 	%f287, %f285, %f286;
	cvt.rn.f32.s16 	%f288, %rs71;
	mul.f32 	%f289, %f288, %f252;
	add.f32 	%f290, %f287, %f289;
	cvt.rzi.s16.f32 	%rs99, %f290;
	bra.uni 	BB0_50;

BB0_48:
	ld.global.u16 	%rs99, [%r8];
	bra.uni 	BB0_50;

BB0_49:
	mov.u16 	%rs99, 0;

BB0_50:
	ld.param.u16 	%rs79, [DVR_param_14];
	setp.lt.s16 	%p106, %rs99, %rs79;
	ld.param.u16 	%rs74, [DVR_param_13];
	setp.gt.s16 	%p107, %rs99, %rs74;
	and.pred  	%p108, %p107, %p106;
	@%p108 bra 	BB0_65;

	ld.param.u16 	%rs87, [DVR_param_21];
	setp.gt.s16 	%p109, %rs99, %rs87;
	ld.param.u16 	%rs92, [DVR_param_22];
	setp.lt.s16 	%p110, %rs99, %rs92;
	and.pred  	%p111, %p109, %p110;
	@%p111 bra 	BB0_65;

	ld.param.u16 	%rs86, [DVR_param_17];
	setp.eq.s16 	%p112, %rs86, 0;
	@%p112 bra 	BB0_64;

	ld.param.u32 	%r341, [DVR_param_20];
	add.s32 	%r9, %r341, -1;
	mov.u16 	%rc14, 0;

BB0_54:
	cvt.u32.u8 	%r10, %rc14;
	shl.b32 	%r307, %r10, 1;
	ld.param.u32 	%r340, [DVR_param_19];
	add.s32 	%r308, %r340, %r307;
	ld.global.u16 	%rs73, [%r308];
	setp.gt.s16 	%p113, %rs99, %rs73;
	setp.lt.s32 	%p114, %r10, %r9;
	and.pred  	%p115, %p113, %p114;
	@%p115 bra 	BB0_63;

	shl.b32 	%r309, %r10, 2;
	ld.param.u32 	%r339, [DVR_param_18];
	add.s32 	%r310, %r339, %r309;
	ld.global.u32 	%r342, [%r310];
	setp.gt.u32 	%p116, %r342, 16777215;
	@%p116 bra 	BB0_56;
	bra.uni 	BB0_57;

BB0_56:
	shr.u32 	%r311, %r342, 24;
	and.b32  	%r342, %r342, 16777215;
	cvt.rn.f32.s32 	%f526, %r311;

BB0_57:
	setp.gt.u32 	%p117, %r342, 65535;
	@%p117 bra 	BB0_59;

	mov.f32 	%f527, 0f00000000;
	bra.uni 	BB0_60;

BB0_59:
	shr.u32 	%r312, %r342, 16;
	and.b32  	%r342, %r342, 65535;
	and.b32  	%r313, %r312, 255;
	cvt.rn.f32.s32 	%f527, %r313;

BB0_60:
	div.full.f32 	%f293, %f526, 0f437F0000;
	div.full.f32 	%f294, %f527, 0f437F0000;
	and.b32  	%r314, %r342, 255;
	cvt.rn.f32.s32 	%f297, %r314;
	div.full.f32 	%f37, %f297, 0f437F0000;
	setp.gt.u32 	%p118, %r342, 255;
	@%p118 bra 	BB0_62;

	mov.f32 	%f298, 0f00000000;
	div.full.f32 	%f299, %f298, 0f437F0000;
	mov.f32 	%f534, %f293;
	mov.f32 	%f535, %f294;
	mov.f32 	%f536, %f299;
	mov.f32 	%f382, %f37;
	bra.uni 	BB0_66;

BB0_62:
	shr.u32 	%r315, %r342, 8;
	and.b32  	%r316, %r315, 255;
	cvt.rn.f32.s32 	%f300, %r316;
	div.full.f32 	%f301, %f300, 0f437F0000;
	mov.f32 	%f534, %f293;
	mov.f32 	%f535, %f294;
	mov.f32 	%f536, %f301;
	mov.f32 	%f386, %f37;
	bra.uni 	BB0_66;

BB0_63:
	add.s16 	%rc14, %rc14, 1;
	bra.uni 	BB0_54;

BB0_64:
	mov.f32 	%f302, 0f00000000;
	mov.f32 	%f303, 0f3F800000;
	mov.f32 	%f534, %f303;
	mov.f32 	%f535, %f303;
	mov.f32 	%f536, %f303;
	mov.f32 	%f390, %f302;
	bra.uni 	BB0_66;

BB0_65:
	mov.f32 	%f304, 0f00000000;
	mov.f32 	%f305, 0f3F800000;
	mov.f32 	%f534, %f305;
	mov.f32 	%f535, %f304;
	mov.f32 	%f536, %f304;
	mov.f32 	%f394, %f305;

BB0_66:
	sub.f32 	%f395, %f399, %f403;
	sub.f32 	%f396, %f400, %f404;
	sub.f32 	%f397, %f401, %f405;
	sub.f32 	%f398, %f402, %f406;
	mul.rn.f32 	%f309, %f395, %f395;
	mul.rn.f32 	%f311, %f396, %f396;
	add.f32 	%f312, %f309, %f311;
	mul.rn.f32 	%f314, %f397, %f397;
	add.f32 	%f315, %f312, %f314;
	mul.rn.f32 	%f317, %f398, %f398;
	add.f32 	%f307, %f315, %f317;
	// inline asm
	rsqrt.approx.f32 	%f306, %f307;
	// inline asm
	mul.rn.f32 	%f318, %f395, %f306;
	mul.rn.f32 	%f319, %f396, %f306;
	mul.rn.f32 	%f320, %f397, %f306;
	mul.rn.f32 	%f321, %f398, %f306;
	mul.rn.f32 	%f322, %f318, %f29;
	mul.rn.f32 	%f323, %f319, %f30;
	add.f32 	%f324, %f322, %f323;
	mul.rn.f32 	%f325, %f320, %f31;
	add.f32 	%f326, %f324, %f325;
	mul.rn.f32 	%f327, %f321, %f32;
	add.f32 	%f38, %f326, %f327;
	setp.gt.f32 	%p119, %f38, 0f00000000;
	@%p119 bra 	BB0_68;

	mov.f32 	%f328, 0f00000000;
	mov.f32 	%f531, %f328;
	mov.f32 	%f532, %f328;
	mov.f32 	%f533, %f328;
	mov.f32 	%f358, %f328;
	bra.uni 	BB0_69;

BB0_68:
	mul.f32 	%f531, %f38, %f534;
	mul.f32 	%f532, %f38, %f535;
	mul.f32 	%f533, %f38, %f536;

BB0_69:
	mov.f32 	%f335, 0f00000000;
	mov.f32 	%f528, %f531;
	mov.f32 	%f529, %f532;
	mov.f32 	%f530, %f533;
	mov.f32 	%f350, %f335;

BB0_70:
	setp.gt.f32 	%p120, %f528, 0f3F800000;
	@%p120 bra 	BB0_72;

	mul.f32 	%f336, %f528, 0f437F0000;
	cvt.rzi.s32.f32 	%r317, %f336;
	cvt.u8.u32 	%rc15, %r317;
	bra.uni 	BB0_73;

BB0_72:
	mov.u16 	%rc15, -1;

BB0_73:
	setp.gt.f32 	%p121, %f529, 0f3F800000;
	@%p121 bra 	BB0_75;

	mul.f32 	%f337, %f529, 0f437F0000;
	cvt.rzi.s32.f32 	%r318, %f337;
	cvt.u8.u32 	%rc16, %r318;
	bra.uni 	BB0_76;

BB0_75:
	mov.u16 	%rc16, -1;

BB0_76:
	setp.gt.f32 	%p122, %f530, 0f3F800000;
	@%p122 bra 	BB0_78;

	mul.f32 	%f338, %f530, 0f437F0000;
	cvt.rzi.s32.f32 	%r319, %f338;
	cvt.u8.u32 	%rc17, %r319;
	bra.uni 	BB0_79;

BB0_78:
	mov.u16 	%rc17, -1;

BB0_79:
	shl.b32 	%r320, %r6, 2;
	add.s32 	%r321, %r7, %r320;
	st.global.u8 	[%r321], %rc16;
	st.global.u8 	[%r321+1], %rc15;
	st.global.u8 	[%r321+2], %rc17;
	mov.u16 	%rc13, -1;
	st.global.u8 	[%r321+3], %rc13;
	ret;

BB0_80:
	add.f32 	%f525, %f525, 0f3DCCCCCD;
	bra.uni 	BB0_25;

BB0_81:
	add.f32 	%f524, %f524, 0f40A00000;
	bra.uni 	BB0_7;
}

