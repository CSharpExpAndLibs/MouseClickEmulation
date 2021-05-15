using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClickEmulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dummyButton_Click(object sender, EventArgs e)
        {
            for (int cnt = 0; cnt < 10; cnt++)
            {
                Console.WriteLine("InvokeOnClick()");
                this.InvokeOnClick(realButton, EventArgs.Empty);
            }
        }

        private void realButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Click emulated");
        }
    }
}
