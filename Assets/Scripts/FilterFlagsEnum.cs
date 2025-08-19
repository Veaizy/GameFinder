using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFinder
{
    /// <summary> Labels used to classify video games. </summary>
#pragma warning disable format
    [Flags]
    public enum FilterFlags
    {
        isSingleplayer = 0b00_00000001,    // 1 << 1 = 1
        isMultiplayer  = 0b00_00000010,    // 1 << 2 = 2
        isTopdown      = 0b00_00000100,    // 1 << 3 = 4
        isFirstperson  = 0b00_00001000,    // 1 << 4 = 8
        isThirdperson  = 0b00_00010000,    // 1 << 5 = 16
        isSandbox      = 0b00_00100000,    // 1 << 6 = 32
        isLinear       = 0b00_01000000,    // 1 << 7 = 64
        isShooter      = 0b00_10000000,    // 1 << 8 = 128
        isSurvival     = 0b01_00000000,    // 1 << 9 = 256
        isPuzzle       = 0b10_00000000,    // 1 << 10 = 512
    }
#pragma warning restore format

    public static class Extensions
    {
        public static string Bits(this FilterFlags value, int pad = 10)
        {
            return Bits((int)value, pad);
        }

        public static string Bits(this int value, int pad = 8)
        {
            return Convert.ToString(value, 2).PadLeft(pad, '0');
        }
    }
}
