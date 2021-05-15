using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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

using NativeUtils;

namespace MouseClickEmulationWPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RealButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("RealButton_Click");
        }

        private void DummyButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("DummyButton_Click");
            Point position = RealButton.PointToScreen(
                new Point(RealButton.ActualWidth / 2, RealButton.ActualHeight / 2));
            NativeMethods.SetCursorPos((int)position.X, (int)position.Y);

            INPUT[] inputs = new INPUT[] {
                new INPUT {
                    type = NativeMethods.INPUT_MOUSE,
                    ui = new INPUT_UNION {
                        mouse = new MOUSEINPUT {
                            dwFlags = NativeMethods.MOUSEEVENTF_LEFTDOWN,
                            dx = (int)position.X,
                            dy = (int)position.Y,
                            mouseData = 0,
                            dwExtraInfo = IntPtr.Zero,
                            time = 0
                        }
                    }
                },
                new INPUT {
                    type = NativeMethods.INPUT_MOUSE,
                    ui = new INPUT_UNION {
                        mouse = new MOUSEINPUT {
                            dwFlags = NativeMethods.MOUSEEVENTF_LEFTUP,
                            dx = (int)position.X,
                            dy = (int)position.Y,
                            mouseData = 0,
                            dwExtraInfo = IntPtr.Zero,
                            time = 0
                        }
                    }
                },
            };
            for (int i = 0; i < 10; i++)
                NativeMethods.SendInput(2, ref inputs[0], Marshal.SizeOf(inputs[0]));
        }
    }
}
