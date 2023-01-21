using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escaperoomforms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UsbNotification.RegisterUsbDeviceNotification(this.Handle);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UsbNotification.WmDevicechange)
            {
                switch ((int)m.WParam)
                {
                    case UsbNotification.DbtDeviceremovecomplete:
                        System.Console.WriteLine("USB removed");
                        this.pictureBox1.ImageLocation = "C:/Users/gtraw/OneDrive/Pulpit/app/media/codes.jpg";
                        break;
                    case UsbNotification.DbtDevicearrival:
                        System.Console.WriteLine("USB injected");
                        this.pictureBox1.ImageLocation = "C:/Users/gtraw/OneDrive/Pulpit/app/media/wiezienie komp gif.gif";
                        System.Console.WriteLine(this.pictureBox1.Size);
                        System.Console.WriteLine(this.pictureBox1.Image.Size);
                        break;
                }
            }
        }
    }
}
