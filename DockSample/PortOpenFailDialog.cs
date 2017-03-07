using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace DockSample
{
    public partial class PortOpenFailDialog : Form
    {
        private Point mouseOff;                          //鼠标移动位置变量
        private bool leftFlag;                               //标签是否为左键

        private SerialPort serialPort;

        public PortOpenFailDialog(SerialPort port)
        {
            InitializeComponent();

            if (null != port)
            {
                portNameLabel.Text = port.PortName;
                baudRateLabel.Text = port.BaudRate.ToString();
                parityLabel.Text   = port.Parity.ToString();
                dataBitsLabel.Text = port.DataBits.ToString();
                stopBitsLabel.Text = port.StopBits.ToString();
            }
        }

        public PortOpenFailDialog(SerialPort port, string btName)
        {
            InitializeComponent();

            btCancel.Text = btName;

            if (null != port)
            {
                portNameLabel.Text = port.PortName;
                baudRateLabel.Text = port.BaudRate.ToString();
                parityLabel.Text = port.Parity.ToString();
                dataBitsLabel.Text = port.DataBits.ToString();
                stopBitsLabel.Text = port.StopBits.ToString();
            }
        }

        private void btIgnore_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void PortOpenFailDialog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
                Cursor = Cursors.Arrow;
                this.Opacity = 0.90;
            }
        }

        private void PortOpenFailDialog_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y); //设置移动后的位置
                Location = mouseSet;
            }
        }

        private void PortOpenFailDialog_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
                Cursor = Cursors.Default;
                this.Opacity = 1;
            }
        }
    }
}
