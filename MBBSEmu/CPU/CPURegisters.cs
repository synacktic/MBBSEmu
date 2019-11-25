﻿using System;

namespace MBBSEmu.CPU
{
    public class CpuRegisters
    {
        /*
         * General Registers
         */

        /// <summary>
        ///     AX Register
        /// </summary>
        public int AX { get; set; }

        /// <summary>
        ///     AX Low Byte
        /// </summary>
        public int AL
        {
            get => AX & 0xFF;
            set
            {
                AX &= 0xFF00;
                AX |= value;
            }
        }

        /// <summary>
        ///     AX High Byte
        /// </summary>
        public int AH
        {
            get => AX >> 8;
            set
            {
                AX &= 0x00FF;
                AX |= value << 8;
            }
        }

        /// <summary>
        ///     Base Register
        /// </summary>
        public int BX { get; set; }

        /// <summary>
        ///     BX Low Byte
        /// </summary>
        public int BL
        {
            get => BX & 0xFF;
            set
            {
                BX &= 0xFF00;
                BX |= value;
            }
        }

        /// <summary>
        ///     BX High Byte
        /// </summary>
        public int BH
        {
            get => BX >> 8;
            set
            {
                BX &= 0x00FF;
                BX |= value << 8;
            }
        }



        public int CX { get; set; }

        /// <summary>
        ///     CX Low Byte
        /// </summary>
        public int CL
        {
            get => CX & 0xFF;
            set
            {
                CX &= 0xFF00;
                CX |= value;
            }
        }

        /// <summary>
        ///     CX High Byte
        /// </summary>
        public int CH
        {
            get => CX >> 8;
            set
            {
                CX &= 0x00FF;
                CX |= value << 8;
            }
        }

        public int DX { get; set; }

        /// <summary>
        ///     DX Low Byte
        /// </summary>
        public int DL
        {
            get => DX & 0xFF;
            set
            {
                DX &= 0xFF00;
                DX |= value;
            }
        }

        /// <summary>
        ///     DX High Byte
        /// </summary>
        public int DH
        {
            get => DX >> 8;
            set
            {
                DX &= 0x00FF;
                DX |= value << 8;
            }
        }

        /// <summary>
        ///     Pointer Register
        /// </summary>
        public int SP { get; set; }
        /// <summary>
        ///     Base Register
        /// </summary>
        public int BP { get; set; }
        /// <summary>
        ///     Index Register
        /// </summary>
        public int SI { get; set; }
        /// <summary>
        ///     Index Register
        /// </summary>
        public int DI { get; set; }

        /*
         * Memory Segmentation and Segment Registers
         */

        /// <summary>
        ///     Data Segment
        /// </summary>
        public int DS { get; set; }

        /// <summary>
        ///     Extra Segment
        /// </summary>
        public int ES { get; set; }

        /// <summary>
        ///     Stack Segment
        ///     Default Destination for String Operations
        /// </summary>
        public int SS { get; set; }

        /// <summary>
        ///     Code Segment
        /// </summary>
        public int CS { get; set; }

        /// <summary>
        ///     Flags
        /// </summary>
        public int F { get; set; }

        /// <summary>
        ///     Instruction Pointer
        /// </summary>
        public int IP { get; set; }

        /// <summary>
        ///     Machine Status Word
        /// </summary>
        public int MSW { get; set; }

        public CpuRegisters()
        {
            Console.WriteLine("X86_16 Registers Initialized!");
        }
    }
}