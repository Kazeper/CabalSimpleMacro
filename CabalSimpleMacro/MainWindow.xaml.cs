using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CabalSimpleMacro
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private CancellationTokenSource cts = new CancellationTokenSource();

		private bool _isMacroRunning;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			if (_isMacroRunning)
			{
				cts.Cancel();

				_isMacroRunning = false;
				LogTextBlock.Dispatcher.Invoke(() => LogAdd("Macro successfully stopped"));
				StartButton.Content = "Start";
			}
			else
			{
				var keyList = GetKeyList();
				if (keyList.Contains(uint.MaxValue))
				{
					LogTextBlock.Dispatcher.Invoke(() => LogAdd("Please enter valid parameters"));
					return;
				}

				RunMacro(keyList);
				_isMacroRunning = true;

				LogTextBlock.Dispatcher.Invoke(() => LogAdd("Macro successfully run"));
				StartButton.Content = "Stop";
			}
		}

		private List<uint> GetKeyList()
		{
			string delimiter = DelimiterTextBox.Text;
			string keys = KeysTextBox.Text;

			var res = keys.Split(new string[] { delimiter }, StringSplitOptions.None).Select(k => Scancodes.GetScancode(k)).ToList();

			return res;
		}

		private void RunMacro(List<uint> keyList)
		{
			try
			{
				Macro.Run(keyList, cts.Token);
			}
			catch (OperationCanceledException)
			{
				LogTextBlock.Dispatcher.Invoke(() => LogAdd("Macro has been stopped."));
			}
		}

		private void LogAdd(string text)
		{
			LogTextBlock.Text += $"{text}" + Environment.NewLine;
			LogScrollViewer.ScrollToEnd();
		}

		private void AvailableKeysButton_Click(object sender, RoutedEventArgs e)
		{
			//print available keys
			LogTextBlock.Dispatcher.Invoke(() => LogAdd("Available keys:"));
			foreach (var pair in Scancodes.GetScancodesDictionary())
			{
				LogTextBlock.Dispatcher.Invoke(() => LogAdd($"  {pair.Key}"));
			}
		}
	}
}