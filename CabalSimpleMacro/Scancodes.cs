using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabalSimpleMacro
{
	public static class Scancodes
	{
		private static Dictionary<string, uint> _scancodes = new Dictionary<string, uint>
		{
			{ "esc", 0x01},
			{ "1", 0x02},
			{ "2", 0x03},
			{ "3", 0x04},
			{ "4", 0x05},
			{ "5", 0x06},
			{ "6", 0x07},
			{ "7", 0x08},
			{ "8", 0x09},
			{ "9", 0x0a},
			{ "0", 0x0b},
			{ "-", 0x0c},
			{ "=", 0x0d},
			{ "backspace", 0x0e},
			{ "q", 0x10},
			{ "w", 0x11},
			{ "e", 0x12},
			{ "r", 0x13},
			{ "t", 0x14},
			{ "y", 0x15},
			{ "u", 0x16},
			{ "i", 0x17},
			{ "o", 0x18},
			{ "p", 0x19},
			{ "[", 0x1a},
			{ "]", 0x1b},
			{ "enter", 0x1c},
			{ "a", 0x1e},
			{ "s", 0x1f},
			{ "d", 0x20},
			{ "f", 0x21},
			{ "g", 0x22},
			{ "h", 0x23},
			{ "j", 0x24},
			{ "k", 0x25},
			{ "l", 0x26},
			{ ";", 0x27},
			{ "'", 0x28},
			{ "`", 0x29},
			{ "\\", 0x2b},
			{ "z", 0x2c},
			{ "x", 0x2d},
			{ "c", 0x2e},
			{ "v", 0x2f},
			{ "b", 0x30},
			{ "n", 0x31},
			{ "m", 0x32},
			{ ",", 0x33},
			{ ".", 0x34},
			{ "/", 0x35},
			{ " ", 0x39},
			{ "f1", 0x3b},
			{ "f2", 0x3c},
			{ "f3", 0x3d},
			{ "f4", 0x3e},
			{ "f5", 0x3f},
			{ "f6", 0x40},
			{ "f7", 0x41},
			{ "f8", 0x42},
			{ "f9", 0x43},
			{ "f10", 0x44},
			{ "f11", 0x57},
			{ "f12", 0x58},
		};

		public static uint GetScancode(string key)
		{
			if (_scancodes.TryGetValue(key, out uint value))
				return value;

			return uint.MaxValue;
		}

		public static Dictionary<string, uint> GetScancodesDictionary()
		{
			return _scancodes;
		}
	}
}