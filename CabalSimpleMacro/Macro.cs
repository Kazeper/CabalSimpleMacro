using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CabalSimpleMacro
{
	public static class Macro
	{
		//bScan - is a scancode which is produced by key press
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void keybd_event(uint bVk, uint bScan, uint dwFlags, uint dwExtraInfo);

		public static void Run(List<uint> keys, CancellationToken token, int delay = 30)
		{
			_ = Task.Run(() =>
			{
				while (true)
				{
					keys.ForEach(k =>
					{
						keybd_event(0, k, 0, 0);//press
						keybd_event(0, k, 0x0002, 0);//release
						Thread.Sleep(delay);
					});

					token.ThrowIfCancellationRequested();
				}
			});
		}
	}
}