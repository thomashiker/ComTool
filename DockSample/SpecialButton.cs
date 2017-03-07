using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DockSample
{
    public partial class SpecialButton : Button
    {
        //定义delegate
        public delegate void BtClickEventHandler(object sender, EventArgs e);

        //用event 关键字声明事件对象
        public event BtClickEventHandler ClickEvent;

        //事件触发方法
        protected virtual void OnClickEvent(EventArgs e)
        {
            if (null != ClickEvent)
                ClickEvent(this, e);
        }


        private bool btChecked = false;
        private Image btCheckedImage;
        private Image btUnCheckedImage;
        private Color btCheckedColor;
        private Color btUnCheckedColor;
        private bool btCheckedColorEnable = false;




        public bool Checked
        {
            get { return btChecked; }
            set
            {
                btChecked = value;
                if (true == btChecked)
                {
                    this.Image = CheckedImage;
                    if (CheckedColorEnable)
                        this.BackColor = CheckedColor;
                }
                else
                {
                    this.Image = UnCheckedImage;
                    if (CheckedColorEnable)
                        this.BackColor = UnCheckedColor;
                }
            }
        }

        public bool CheckedColorEnable
        {
            get { return btCheckedColorEnable; }
            set {
                btCheckedColorEnable = value;
                if (false == btCheckedColorEnable)
                {
                    this.BackColor = UnCheckedColor;
                }
            }
        }

        public Image CheckedImage
        {
            get { return btCheckedImage; }
            set {
                btCheckedImage = value;
                Checked = Checked;
            }
        }

        public Image UnCheckedImage
        {
            get { return btUnCheckedImage; }
            set {
                btUnCheckedImage = value;
                Checked = Checked;
            }
        }

        public Color CheckedColor
        {
            get { return btCheckedColor; }
            set {
                btCheckedColor = value;
                Checked = Checked;
            }
        }

        private Color UnCheckedColor
        {
            get { return btUnCheckedColor; }
            set {
                btUnCheckedColor = value;
                Checked = Checked;
            }
        }

        public SpecialButton()
        {
            InitializeComponent();
            this.Click += new System.EventHandler(this.btClick);
            Checked = false;
            UnCheckedColor = this.BackColor;
        }

        private void btClick(object sender, EventArgs e)
        {
            Checked = !Checked;

            OnClickEvent(e);
        }

        private void specialButton_BackColorChanged(object sender, EventArgs e)
        {
            UnCheckedColor = this.BackColor;
        }
    }
}
