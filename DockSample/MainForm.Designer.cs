using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO.Ports;
using System.IO;
using System.Collections;


namespace DockSample
{
    public class PortInfo
    {
        private string port;
        private string baudrate;
        private string databits;
        private string stopbits;
        private string parity;
        private string flow;
        public string Port
        {
            get { return port; }
            set { port = value; }
        }
        public string BaudRate
        {
            get { return baudrate; }
            set { baudrate = value; }
        }
        public string DataBits
        {
            get { return databits; }
            set { databits = value; }
        }
        public string Stopbits
        {
            get { return stopbits; }
            set { stopbits = value; }
        }
        public string Parity
        {
            get { return parity; }
            set { parity = value; }
        }
        public string Flow
        {
            get { return flow; }
            set { flow = value; }
        }

        public string GetPortName()
        {
            return port;
        }
        public int GetPortBaudRate()
        {
            return int.Parse(baudrate);
        }
        public int GetPortDataBits()
        {
            return int.Parse(databits);
        }
        public StopBits GetPortStopBits()
        {
            switch (stopbits)
                {
                    case "1":
                        return StopBits.One;
                    case "1.5":
                        return StopBits.OnePointFive;
                    case "2":
                        return StopBits.Two;
                    default:
                        break;
                }
            return StopBits.One;
        }

        public Parity GetPortParity()
        {
            return (Parity)Enum.Parse(typeof(Parity), parity);;
        }
        public string GetPortFlow()
        {
            return flow;
        }
        public override string ToString()
        {
            return (baudrate + "," + databits + "," + stopbits + "," + parity + "," + flow);
        }
    };

    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.toolBarButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolBarButtonOpenClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCloseWindow = new System.Windows.Forms.ToolStripButton();
            this.toolBarButtonLinkSetting = new System.Windows.Forms.ToolStripButton();
            this.toolBarButtonSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.showLineButton = new System.Windows.Forms.ToolStripButton();
            this.rmAllBookmarksButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tBarButtonRecord = new System.Windows.Forms.ToolStripButton();
            this.newLogToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolBarButtonOpenLog = new System.Windows.Forms.ToolStripButton();
            this.openLogFolderButton = new System.Windows.Forms.ToolStripButton();
            this.toolBarButtonSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.topMostButton = new System.Windows.Forms.ToolStripButton();
            this.tsBtGoBack = new System.Windows.Forms.ToolStripButton();
            this.tsBtGoForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtFindPrevious = new System.Windows.Forms.ToolStripButton();
            this.tsBtFindNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.screenShotButton = new System.Windows.Forms.ToolStripButton();
            this.openFavourateButton = new System.Windows.Forms.ToolStripButton();
            this.sbtLayoutToolStrip = new System.Windows.Forms.ToolStripSplitButton();
            this.horizontalToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.stackToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.notifyImageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStripimageList = new System.Windows.Forms.ImageList(this.components);
            this.systemStatusStrip = new System.Windows.Forms.StatusStrip();
            this.conectStateLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sendTimerPeriodLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sendCharNumLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.rcvCharNumLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.vS2015LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            this.notifyMenu = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyTSMIShow = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyTSMINewPort = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyTSMIExit = new System.Windows.Forms.ToolStripMenuItem();
            this.sysMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingSysMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.themeSysMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btTopMost = new System.Windows.Forms.Button();
            this.btSysMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.btMaximize = new System.Windows.Forms.Button();
            this.btMinimize = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.toolBar.SuspendLayout();
            this.systemStatusStrip.SuspendLayout();
            this.cmsNotifyMenu.SuspendLayout();
            this.sysMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.toolBar.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarButtonNew,
            this.toolBarButtonOpenClose,
            this.toolStripButtonCloseWindow,
            this.toolBarButtonLinkSetting,
            this.toolBarButtonSeparator1,
            this.saveAsButton,
            this.toolStripButtonClear,
            this.showLineButton,
            this.rmAllBookmarksButton,
            this.toolStripSeparator2,
            this.tBarButtonRecord,
            this.newLogToolStripButton,
            this.toolBarButtonOpenLog,
            this.openLogFolderButton,
            this.toolBarButtonSeparator2,
            this.topMostButton,
            this.tsBtGoBack,
            this.tsBtGoForward,
            this.toolStripSeparator1,
            this.tsBtFindPrevious,
            this.tsBtFindNext,
            this.toolStripSeparator3,
            this.screenShotButton,
            this.openFavourateButton,
            this.sbtLayoutToolStrip,
            this.toolStripButton1});
            this.toolBar.Location = new System.Drawing.Point(4, 28);
            this.toolBar.Name = "toolBar";
            this.toolBar.Padding = new System.Windows.Forms.Padding(0);
            this.toolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolBar.Size = new System.Drawing.Size(692, 25);
            this.toolBar.TabIndex = 6;
            // 
            // toolBarButtonNew
            // 
            this.toolBarButtonNew.Image = global::DockSample.Properties.Resources.display_mac;
            this.toolBarButtonNew.Margin = new System.Windows.Forms.Padding(1);
            this.toolBarButtonNew.Name = "toolBarButtonNew";
            this.toolBarButtonNew.Size = new System.Drawing.Size(23, 23);
            this.toolBarButtonNew.ToolTipText = "New Port";
            this.toolBarButtonNew.Click += new System.EventHandler(this.toolBarButtonNew_Click);
            // 
            // toolBarButtonOpenClose
            // 
            this.toolBarButtonOpenClose.Enabled = false;
            this.toolBarButtonOpenClose.Image = global::DockSample.Properties.Resources.connection_error;
            this.toolBarButtonOpenClose.Margin = new System.Windows.Forms.Padding(1);
            this.toolBarButtonOpenClose.Name = "toolBarButtonOpenClose";
            this.toolBarButtonOpenClose.Size = new System.Drawing.Size(23, 23);
            this.toolBarButtonOpenClose.ToolTipText = "Open/Close";
            this.toolBarButtonOpenClose.Click += new System.EventHandler(this.toolBarButtonOpen_Click);
            // 
            // toolStripButtonCloseWindow
            // 
            this.toolStripButtonCloseWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCloseWindow.Image = global::DockSample.Properties.Resources.MD_eject;
            this.toolStripButtonCloseWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCloseWindow.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonCloseWindow.Name = "toolStripButtonCloseWindow";
            this.toolStripButtonCloseWindow.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonCloseWindow.ToolTipText = "Close";
            this.toolStripButtonCloseWindow.Click += new System.EventHandler(this.toolStripButtonCloseWindow_Click);
            // 
            // toolBarButtonLinkSetting
            // 
            this.toolBarButtonLinkSetting.Enabled = false;
            this.toolBarButtonLinkSetting.Image = global::DockSample.Properties.Resources.toolbox;
            this.toolBarButtonLinkSetting.Margin = new System.Windows.Forms.Padding(1);
            this.toolBarButtonLinkSetting.Name = "toolBarButtonLinkSetting";
            this.toolBarButtonLinkSetting.Size = new System.Drawing.Size(23, 23);
            this.toolBarButtonLinkSetting.ToolTipText = "Connect Setting";
            this.toolBarButtonLinkSetting.Click += new System.EventHandler(this.toolBarButtonSolutionExplorer_Click);
            // 
            // toolBarButtonSeparator1
            // 
            this.toolBarButtonSeparator1.AutoSize = false;
            this.toolBarButtonSeparator1.Name = "toolBarButtonSeparator1";
            this.toolBarButtonSeparator1.Size = new System.Drawing.Size(6, 20);
            // 
            // saveAsButton
            // 
            this.saveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAsButton.Enabled = false;
            this.saveAsButton.Image = global::DockSample.Properties.Resources.save;
            this.saveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAsButton.Margin = new System.Windows.Forms.Padding(1);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(23, 23);
            this.saveAsButton.Text = "toolStripButton2";
            this.saveAsButton.ToolTipText = "Save As";
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClear.Enabled = false;
            this.toolStripButtonClear.Image = global::DockSample.Properties.Resources.eraser;
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Margin = new System.Windows.Forms.Padding(1);
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(23, 23);
            this.toolStripButtonClear.Text = "ClearReceive";
            this.toolStripButtonClear.ToolTipText = "Clear";
            this.toolStripButtonClear.Click += new System.EventHandler(this.toolStripButtonClear_Click);
            // 
            // showLineButton
            // 
            this.showLineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showLineButton.Enabled = false;
            this.showLineButton.Image = global::DockSample.Properties.Resources.list_numbered;
            this.showLineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showLineButton.Name = "showLineButton";
            this.showLineButton.Size = new System.Drawing.Size(23, 22);
            this.showLineButton.Text = "Show Line";
            this.showLineButton.ToolTipText = "Show Line Number";
            this.showLineButton.Click += new System.EventHandler(this.showLineToolStripButton_Click);
            // 
            // rmAllBookmarksButton
            // 
            this.rmAllBookmarksButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rmAllBookmarksButton.Enabled = false;
            this.rmAllBookmarksButton.Image = global::DockSample.Properties.Resources.tags;
            this.rmAllBookmarksButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rmAllBookmarksButton.Name = "rmAllBookmarksButton";
            this.rmAllBookmarksButton.Size = new System.Drawing.Size(23, 22);
            this.rmAllBookmarksButton.Text = "Clear Tags";
            this.rmAllBookmarksButton.Click += new System.EventHandler(this.rmAllBookmarksButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 20);
            // 
            // tBarButtonRecord
            // 
            this.tBarButtonRecord.Enabled = false;
            this.tBarButtonRecord.Image = global::DockSample.Properties.Resources.MD_record;
            this.tBarButtonRecord.Margin = new System.Windows.Forms.Padding(1);
            this.tBarButtonRecord.Name = "tBarButtonRecord";
            this.tBarButtonRecord.Size = new System.Drawing.Size(23, 23);
            this.tBarButtonRecord.ToolTipText = "Record\r\n";
            this.tBarButtonRecord.Click += new System.EventHandler(this.toolBarButtonLogEnable_Click);
            // 
            // newLogToolStripButton
            // 
            this.newLogToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newLogToolStripButton.Enabled = false;
            this.newLogToolStripButton.Image = global::DockSample.Properties.Resources.file;
            this.newLogToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newLogToolStripButton.Name = "newLogToolStripButton";
            this.newLogToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newLogToolStripButton.Text = "New Log";
            this.newLogToolStripButton.Click += new System.EventHandler(this.newLogToolStripButton_Click);
            // 
            // toolBarButtonOpenLog
            // 
            this.toolBarButtonOpenLog.Enabled = false;
            this.toolBarButtonOpenLog.Image = global::DockSample.Properties.Resources.notepad_alt;
            this.toolBarButtonOpenLog.Margin = new System.Windows.Forms.Padding(1);
            this.toolBarButtonOpenLog.Name = "toolBarButtonOpenLog";
            this.toolBarButtonOpenLog.Size = new System.Drawing.Size(23, 23);
            this.toolBarButtonOpenLog.ToolTipText = "Open Log";
            this.toolBarButtonOpenLog.Click += new System.EventHandler(this.toolBarButtonOpenLog_Click);
            // 
            // openLogFolderButton
            // 
            this.openLogFolderButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openLogFolderButton.Image = global::DockSample.Properties.Resources.folder_open;
            this.openLogFolderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openLogFolderButton.Name = "openLogFolderButton";
            this.openLogFolderButton.Size = new System.Drawing.Size(23, 22);
            this.openLogFolderButton.Text = "OpenLogFolder";
            this.openLogFolderButton.ToolTipText = "Open Folder";
            this.openLogFolderButton.Click += new System.EventHandler(this.openLogFolderButton_Click);
            // 
            // toolBarButtonSeparator2
            // 
            this.toolBarButtonSeparator2.AutoSize = false;
            this.toolBarButtonSeparator2.Name = "toolBarButtonSeparator2";
            this.toolBarButtonSeparator2.Size = new System.Drawing.Size(6, 20);
            // 
            // topMostButton
            // 
            this.topMostButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.topMostButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.topMostButton.Image = ((System.Drawing.Image)(resources.GetObject("topMostButton.Image")));
            this.topMostButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.topMostButton.Name = "topMostButton";
            this.topMostButton.Size = new System.Drawing.Size(23, 22);
            this.topMostButton.Text = "TopMost";
            this.topMostButton.Click += new System.EventHandler(this.topMostButton_Click);
            // 
            // tsBtGoBack
            // 
            this.tsBtGoBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtGoBack.Image = global::DockSample.Properties.Resources.arrow_2_left;
            this.tsBtGoBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtGoBack.Name = "tsBtGoBack";
            this.tsBtGoBack.Size = new System.Drawing.Size(23, 22);
            this.tsBtGoBack.Text = "toolStripButton1";
            this.tsBtGoBack.ToolTipText = "Go Back";
            this.tsBtGoBack.Click += new System.EventHandler(this.tsBtGoBack_Click);
            // 
            // tsBtGoForward
            // 
            this.tsBtGoForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtGoForward.Image = global::DockSample.Properties.Resources.arrow_2_right;
            this.tsBtGoForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtGoForward.Name = "tsBtGoForward";
            this.tsBtGoForward.Size = new System.Drawing.Size(23, 22);
            this.tsBtGoForward.Text = "toolStripButton2";
            this.tsBtGoForward.ToolTipText = "Go Forward";
            this.tsBtGoForward.Click += new System.EventHandler(this.tsBtGoForward_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 20);
            // 
            // tsBtFindPrevious
            // 
            this.tsBtFindPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtFindPrevious.Image = global::DockSample.Properties.Resources.zoom_out;
            this.tsBtFindPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtFindPrevious.Name = "tsBtFindPrevious";
            this.tsBtFindPrevious.Size = new System.Drawing.Size(23, 22);
            this.tsBtFindPrevious.Text = "FindPrevious";
            this.tsBtFindPrevious.ToolTipText = "Previous";
            this.tsBtFindPrevious.Click += new System.EventHandler(this.tsBtFindPrevious_Click);
            // 
            // tsBtFindNext
            // 
            this.tsBtFindNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtFindNext.Image = global::DockSample.Properties.Resources.zoom_in;
            this.tsBtFindNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtFindNext.Name = "tsBtFindNext";
            this.tsBtFindNext.Size = new System.Drawing.Size(23, 22);
            this.tsBtFindNext.Text = "Search";
            this.tsBtFindNext.ToolTipText = "Next";
            this.tsBtFindNext.Click += new System.EventHandler(this.tsBtFindNext_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 20);
            // 
            // screenShotButton
            // 
            this.screenShotButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.screenShotButton.Image = global::DockSample.Properties.Resources.screenshot;
            this.screenShotButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.screenShotButton.Margin = new System.Windows.Forms.Padding(1);
            this.screenShotButton.Name = "screenShotButton";
            this.screenShotButton.Size = new System.Drawing.Size(23, 23);
            this.screenShotButton.ToolTipText = "Screenshot";
            this.screenShotButton.Click += new System.EventHandler(this.toolStripButtonScreenShot_Click);
            // 
            // openFavourateButton
            // 
            this.openFavourateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFavourateButton.Image = global::DockSample.Properties.Resources.view;
            this.openFavourateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFavourateButton.Margin = new System.Windows.Forms.Padding(1);
            this.openFavourateButton.Name = "openFavourateButton";
            this.openFavourateButton.Size = new System.Drawing.Size(23, 23);
            this.openFavourateButton.Text = "toolStripButton1";
            this.openFavourateButton.ToolTipText = "Click To Hide Send Window";
            this.openFavourateButton.Click += new System.EventHandler(this.openFavourateButton_Click);
            // 
            // sbtLayoutToolStrip
            // 
            this.sbtLayoutToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sbtLayoutToolStrip.DropDownButtonWidth = 10;
            this.sbtLayoutToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalToolStrip,
            this.verticalToolStrip,
            this.stackToolStrip});
            this.sbtLayoutToolStrip.Image = global::DockSample.Properties.Resources.window_tile_vertically;
            this.sbtLayoutToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbtLayoutToolStrip.Name = "sbtLayoutToolStrip";
            this.sbtLayoutToolStrip.Size = new System.Drawing.Size(31, 22);
            this.sbtLayoutToolStrip.Text = "Layout";
            this.sbtLayoutToolStrip.ButtonClick += new System.EventHandler(this.sbtLayoutToolStrip_ButtonClick);
            // 
            // horizontalToolStrip
            // 
            this.horizontalToolStrip.Image = global::DockSample.Properties.Resources.window_tile_horizontally;
            this.horizontalToolStrip.Name = "horizontalToolStrip";
            this.horizontalToolStrip.Size = new System.Drawing.Size(136, 22);
            this.horizontalToolStrip.Text = "&Horizontal";
            this.horizontalToolStrip.Click += new System.EventHandler(this.horizontalToolStrip_Click);
            // 
            // verticalToolStrip
            // 
            this.verticalToolStrip.Image = global::DockSample.Properties.Resources.window_tile_vertically;
            this.verticalToolStrip.Name = "verticalToolStrip";
            this.verticalToolStrip.Size = new System.Drawing.Size(136, 22);
            this.verticalToolStrip.Text = "&Vertical";
            this.verticalToolStrip.Click += new System.EventHandler(this.verticalToolStrip_Click);
            // 
            // stackToolStrip
            // 
            this.stackToolStrip.Image = global::DockSample.Properties.Resources.window_stack;
            this.stackToolStrip.Name = "stackToolStrip";
            this.stackToolStrip.Size = new System.Drawing.Size(136, 22);
            this.stackToolStrip.Text = "&Stack";
            this.stackToolStrip.Click += new System.EventHandler(this.stackToolStrip_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // dockPanel
            // 
            this.dockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.dockPanel.DockBottomPortion = 150D;
            this.dockPanel.DockLeftPortion = 200D;
            this.dockPanel.DockRightPortion = 200D;
            this.dockPanel.DockTopPortion = 150D;
            this.dockPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dockPanel.Location = new System.Drawing.Point(4, 53);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.ShowDocumentIcon = true;
            this.dockPanel.Size = new System.Drawing.Size(692, 401);
            this.dockPanel.TabIndex = 0;
            this.dockPanel.ActiveDocumentChanged += new System.EventHandler(this.dockPanel_ActiveDocumentChanged);
            // 
            // notifyImageList
            // 
            this.notifyImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("notifyImageList.ImageStream")));
            this.notifyImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.notifyImageList.Images.SetKeyName(0, "connect.png");
            this.notifyImageList.Images.SetKeyName(1, "connection-error.png");
            this.notifyImageList.Images.SetKeyName(2, "connect-alt-1.png");
            this.notifyImageList.Images.SetKeyName(3, "connection-error-alt-1.png");
            this.notifyImageList.Images.SetKeyName(4, "connect-alt-2.png");
            this.notifyImageList.Images.SetKeyName(5, "connection-error-alt-2.png");
            this.notifyImageList.Images.SetKeyName(6, "MD-repeat-alt.png");
            this.notifyImageList.Images.SetKeyName(7, "MD-repeat-once.png");
            // 
            // toolStripimageList
            // 
            this.toolStripimageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolStripimageList.ImageStream")));
            this.toolStripimageList.TransparentColor = System.Drawing.Color.Transparent;
            this.toolStripimageList.Images.SetKeyName(0, "connect.png");
            this.toolStripimageList.Images.SetKeyName(1, "connection-error.png");
            this.toolStripimageList.Images.SetKeyName(2, "connect-alt-1.png");
            this.toolStripimageList.Images.SetKeyName(3, "connection-error-alt-1.png");
            this.toolStripimageList.Images.SetKeyName(4, "arrow-8-up.png");
            this.toolStripimageList.Images.SetKeyName(5, "arrow-8-down.png");
            this.toolStripimageList.Images.SetKeyName(6, "padlock-open.png");
            this.toolStripimageList.Images.SetKeyName(7, "padlock-closed.png");
            this.toolStripimageList.Images.SetKeyName(8, "MD-play.png");
            this.toolStripimageList.Images.SetKeyName(9, "MD-pause.png");
            this.toolStripimageList.Images.SetKeyName(10, "MD-resume.png");
            this.toolStripimageList.Images.SetKeyName(11, "MD-record.png");
            this.toolStripimageList.Images.SetKeyName(12, "MD-stop.png");
            this.toolStripimageList.Images.SetKeyName(13, "MD-next.png");
            this.toolStripimageList.Images.SetKeyName(14, "MD-previous.png");
            this.toolStripimageList.Images.SetKeyName(15, "MD-levels-decrease.png");
            this.toolStripimageList.Images.SetKeyName(16, "MD-levels-increase.png");
            this.toolStripimageList.Images.SetKeyName(17, "MD-reload.png");
            this.toolStripimageList.Images.SetKeyName(18, "MD-repeat.png");
            this.toolStripimageList.Images.SetKeyName(19, "MD-repeat-alt.png");
            this.toolStripimageList.Images.SetKeyName(20, "MD-repeat-once.png");
            this.toolStripimageList.Images.SetKeyName(21, "MD-shuffle.png");
            this.toolStripimageList.Images.SetKeyName(22, "file-upload.png");
            // 
            // systemStatusStrip
            // 
            this.systemStatusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.systemStatusStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.systemStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectStateLabel,
            this.toolStripStatusLabel4,
            this.sendTimerPeriodLabel,
            this.toolStripStatusLabel1,
            this.sendCharNumLabel,
            this.toolStripStatusLabel8,
            this.rcvCharNumLabel,
            this.toolStripStatusLabel5,
            this.linkTimeLabel});
            this.systemStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.systemStatusStrip.Location = new System.Drawing.Point(4, 454);
            this.systemStatusStrip.Name = "systemStatusStrip";
            this.systemStatusStrip.Size = new System.Drawing.Size(692, 22);
            this.systemStatusStrip.SizingGrip = false;
            this.systemStatusStrip.TabIndex = 14;
            this.systemStatusStrip.Text = "statusStrip1";
            // 
            // conectStateLabel
            // 
            this.conectStateLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conectStateLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.conectStateLabel.Name = "conectStateLabel";
            this.conectStateLabel.Size = new System.Drawing.Size(88, 19);
            this.conectStateLabel.Text = "No Conection";
            this.conectStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // sendTimerPeriodLabel
            // 
            this.sendTimerPeriodLabel.Image = global::DockSample.Properties.Resources.alarm;
            this.sendTimerPeriodLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.sendTimerPeriodLabel.Name = "sendTimerPeriodLabel";
            this.sendTimerPeriodLabel.Size = new System.Drawing.Size(69, 19);
            this.sendTimerPeriodLabel.Text = "1000ms";
            this.sendTimerPeriodLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // sendCharNumLabel
            // 
            this.sendCharNumLabel.Image = global::DockSample.Properties.Resources.arrow_4_up;
            this.sendCharNumLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sendCharNumLabel.IsLink = true;
            this.sendCharNumLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.sendCharNumLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.sendCharNumLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.sendCharNumLabel.Name = "sendCharNumLabel";
            this.sendCharNumLabel.Size = new System.Drawing.Size(31, 19);
            this.sendCharNumLabel.Text = "0";
            this.sendCharNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sendCharNumLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel8.Text = "|";
            // 
            // rcvCharNumLabel
            // 
            this.rcvCharNumLabel.Image = global::DockSample.Properties.Resources.arrow_4_down;
            this.rcvCharNumLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rcvCharNumLabel.IsLink = true;
            this.rcvCharNumLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.rcvCharNumLabel.LinkColor = System.Drawing.SystemColors.ControlText;
            this.rcvCharNumLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.rcvCharNumLabel.Name = "rcvCharNumLabel";
            this.rcvCharNumLabel.Size = new System.Drawing.Size(31, 19);
            this.rcvCharNumLabel.Text = "0";
            this.rcvCharNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rcvCharNumLabel.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel5.Text = "|";
            // 
            // linkTimeLabel
            // 
            this.linkTimeLabel.Image = global::DockSample.Properties.Resources.stopwatch;
            this.linkTimeLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.linkTimeLabel.Name = "linkTimeLabel";
            this.linkTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.linkTimeLabel.Size = new System.Drawing.Size(72, 19);
            this.linkTimeLabel.Text = "00:00:00";
            this.linkTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkTimeLabel.ToolTipText = "Link Time";
            // 
            // notifyMenu
            // 
            this.notifyMenu.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyMenu.BalloonTipText = "Notify";
            this.notifyMenu.BalloonTipTitle = "Notify Menu";
            this.notifyMenu.ContextMenuStrip = this.cmsNotifyMenu;
            this.notifyMenu.Text = "Notify Menu";
            this.notifyMenu.Visible = true;
            this.notifyMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyMenu_MouseClick);
            // 
            // cmsNotifyMenu
            // 
            this.cmsNotifyMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmsNotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyTSMIShow,
            this.notifyTSMINewPort,
            this.toolStripSeparator4,
            this.notifyTSMIExit});
            this.cmsNotifyMenu.Name = "cmsNotifyIcon";
            this.cmsNotifyMenu.Size = new System.Drawing.Size(108, 76);
            // 
            // notifyTSMIShow
            // 
            this.notifyTSMIShow.Image = global::DockSample.Properties.Resources.view;
            this.notifyTSMIShow.Name = "notifyTSMIShow";
            this.notifyTSMIShow.Size = new System.Drawing.Size(107, 22);
            this.notifyTSMIShow.Text = "&Show";
            this.notifyTSMIShow.Click += new System.EventHandler(this.notifyTSMIShow_Click);
            // 
            // notifyTSMINewPort
            // 
            this.notifyTSMINewPort.Image = global::DockSample.Properties.Resources.add;
            this.notifyTSMINewPort.Name = "notifyTSMINewPort";
            this.notifyTSMINewPort.Size = new System.Drawing.Size(107, 22);
            this.notifyTSMINewPort.Text = "&New";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(104, 6);
            // 
            // notifyTSMIExit
            // 
            this.notifyTSMIExit.Image = global::DockSample.Properties.Resources.door_closed;
            this.notifyTSMIExit.Name = "notifyTSMIExit";
            this.notifyTSMIExit.Size = new System.Drawing.Size(107, 22);
            this.notifyTSMIExit.Text = "&Exit";
            this.notifyTSMIExit.Click += new System.EventHandler(this.notifyTSMIExit_Click);
            // 
            // sysMenu
            // 
            this.sysMenu.BackColor = System.Drawing.Color.White;
            this.sysMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingSysMenu,
            this.themeSysMenu});
            this.sysMenu.Name = "sysMenu";
            this.sysMenu.Size = new System.Drawing.Size(117, 48);
            // 
            // settingSysMenu
            // 
            this.settingSysMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.settingSysMenu.Image = global::DockSample.Properties.Resources._3D_Cube;
            this.settingSysMenu.Name = "settingSysMenu";
            this.settingSysMenu.Size = new System.Drawing.Size(116, 22);
            this.settingSysMenu.Text = "&Setting";
            // 
            // themeSysMenu
            // 
            this.themeSysMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.themeSysMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.lightToolStripMenuItem,
            this.colorToolStripMenuItem});
            this.themeSysMenu.Image = global::DockSample.Properties.Resources.paintroller;
            this.themeSysMenu.Name = "themeSysMenu";
            this.themeSysMenu.Size = new System.Drawing.Size(116, 22);
            this.themeSysMenu.Text = "&Theme";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(108, 22);
            this.toolStripMenuItem1.Text = "Dark";
            this.toolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.lightToolStripMenuItem.Text = "Light";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // btTopMost
            // 
            this.btTopMost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTopMost.FlatAppearance.BorderSize = 0;
            this.btTopMost.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(149)))), ((int)(((byte)(222)))));
            this.btTopMost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTopMost.Image = global::DockSample.Properties.Resources.pin_24px_1083523_easyicon_net;
            this.btTopMost.Location = new System.Drawing.Point(542, 1);
            this.btTopMost.Margin = new System.Windows.Forms.Padding(0);
            this.btTopMost.Name = "btTopMost";
            this.btTopMost.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btTopMost.Size = new System.Drawing.Size(27, 27);
            this.btTopMost.TabIndex = 16;
            this.btTopMost.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btTopMost.UseVisualStyleBackColor = true;
            this.btTopMost.Click += new System.EventHandler(this.btTopMost_Click);
            // 
            // btSysMenu
            // 
            this.btSysMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSysMenu.FlatAppearance.BorderSize = 0;
            this.btSysMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(149)))), ((int)(((byte)(222)))));
            this.btSysMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSysMenu.Image = global::DockSample.Properties.Resources.list;
            this.btSysMenu.Location = new System.Drawing.Point(572, 1);
            this.btSysMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btSysMenu.Name = "btSysMenu";
            this.btSysMenu.Size = new System.Drawing.Size(27, 27);
            this.btSysMenu.TabIndex = 19;
            this.btSysMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btSysMenu.UseVisualStyleBackColor = true;
            this.btSysMenu.Click += new System.EventHandler(this.btSysMenu_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Location = new System.Drawing.Point(600, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 16);
            this.panel1.TabIndex = 20;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(77)))), ((int)(((byte)(58)))));
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btClose.Location = new System.Drawing.Point(499, 1);
            this.btClose.Margin = new System.Windows.Forms.Padding(0);
            this.btClose.Name = "btClose";
            this.btClose.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btClose.Size = new System.Drawing.Size(34, 24);
            this.btClose.TabIndex = 23;
            this.btClose.Text = "r";
            this.btClose.UseVisualStyleBackColor = true;
            // 
            // btMaximize
            // 
            this.btMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMaximize.FlatAppearance.BorderSize = 0;
            this.btMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(149)))), ((int)(((byte)(222)))));
            this.btMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMaximize.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btMaximize.Location = new System.Drawing.Point(471, 1);
            this.btMaximize.Margin = new System.Windows.Forms.Padding(0);
            this.btMaximize.Name = "btMaximize";
            this.btMaximize.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btMaximize.Size = new System.Drawing.Size(27, 24);
            this.btMaximize.TabIndex = 24;
            this.btMaximize.Text = "1";
            this.btMaximize.UseVisualStyleBackColor = true;
            this.btMaximize.Click += new System.EventHandler(this.btMaximize_Click);
            // 
            // btMinimize
            // 
            this.btMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMinimize.FlatAppearance.BorderSize = 0;
            this.btMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(149)))), ((int)(((byte)(222)))));
            this.btMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMinimize.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btMinimize.Location = new System.Drawing.Point(443, 1);
            this.btMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btMinimize.Name = "btMinimize";
            this.btMinimize.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.btMinimize.Size = new System.Drawing.Size(27, 24);
            this.btMinimize.TabIndex = 25;
            this.btMinimize.Text = "0";
            this.btMinimize.UseVisualStyleBackColor = true;
            this.btMinimize.Click += new System.EventHandler(this.btMinimize_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(149)))), ((int)(((byte)(222)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button2.Location = new System.Drawing.Point(400, 1);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 26);
            this.button2.TabIndex = 27;
            this.button2.Text = "6";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 2000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.BackRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.BackShade = false;
            this.BackToColor = false;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.BorderRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ClientSize = new System.Drawing.Size(700, 480);
            this.CloseBoxSize = new System.Drawing.Size(30, 27);
            this.CloseDownBack = global::DockSample.Properties.Resources.sysbtn_close_down;
            this.CloseMouseBack = global::DockSample.Properties.Resources.sysbtn_close_hover;
            this.CloseNormlBack = global::DockSample.Properties.Resources.sysbtn_close_normal;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btMinimize);
            this.Controls.Add(this.btMaximize);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btSysMenu);
            this.Controls.Add(this.btTopMost);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.systemStatusStrip);
            this.Controls.Add(this.toolBar);
            this.EffectCaption = CCWin.TitleType.Title;
            this.EffectWidth = 0;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.IsMdiContainer = true;
            this.MaxDownBack = global::DockSample.Properties.Resources.sysbtn_max_down;
            this.MaxMouseBack = global::DockSample.Properties.Resources.sysbtn_max_hover;
            this.MaxNormlBack = global::DockSample.Properties.Resources.sysbtn_max_normal;
            this.MaxSize = new System.Drawing.Size(30, 27);
            this.MdiBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MiniDownBack = global::DockSample.Properties.Resources.sysbtn_min_down;
            this.MiniMouseBack = global::DockSample.Properties.Resources.sysbtn_min_hover;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.MiniNormlBack = global::DockSample.Properties.Resources.sysbtn_min_normal;
            this.MiniSize = new System.Drawing.Size(30, 27);
            this.Name = "MainForm";
            this.Radius = 0;
            this.RestoreDownBack = global::DockSample.Properties.Resources.sysbtn_restore_down;
            this.RestoreMouseBack = global::DockSample.Properties.Resources.sysbtn_restore_hover;
            this.RestoreNormlBack = global::DockSample.Properties.Resources.sysbtn_restore_normal;
            this.Shadow = false;
            this.ShadowRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ShadowWidth = 1;
            this.ShowBorder = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Com Tool";
            this.SysBottomClick += new CCWin.CCSkinMain.SysBottomEventHandler(this.MainForm_SysBottomClick);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.systemStatusStrip.ResumeLayout(false);
            this.systemStatusStrip.PerformLayout();
            this.cmsNotifyMenu.ResumeLayout(false);
            this.sysMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton toolBarButtonNew;
        private System.Windows.Forms.ToolStripButton toolBarButtonOpenClose;
        private System.Windows.Forms.ToolStripSeparator toolBarButtonSeparator1;
        private System.Windows.Forms.ToolStripButton toolBarButtonLinkSetting;
        private System.Windows.Forms.ToolStripButton tBarButtonRecord;
        private System.Windows.Forms.ToolStripButton toolBarButtonOpenLog;
        private System.Windows.Forms.ToolStripSeparator toolBarButtonSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private ImageList notifyImageList;
        private ToolStripButton toolStripButtonCloseWindow;
        private ToolStripButton openFavourateButton;
        private ToolStripButton saveAsButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton screenShotButton;
        private ImageList toolStripimageList;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton topMostButton;
        private ToolStripButton newLogToolStripButton;
        private ToolStripButton showLineButton;
        private ToolStripButton rmAllBookmarksButton;
        private ToolStripButton openLogFolderButton;
        private ToolStripButton tsBtFindPrevious;
        private ToolStripButton tsBtFindNext;
        private StatusStrip systemStatusStrip;
        private ToolStripStatusLabel conectStateLabel;
        private ToolStripStatusLabel sendTimerPeriodLabel;
        private ToolStripStatusLabel linkTimeLabel;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel5;
        private ToolStripStatusLabel rcvCharNumLabel;
        private ToolStripStatusLabel sendCharNumLabel;
        private ToolStripStatusLabel toolStripStatusLabel8;
        private ToolStripSplitButton sbtLayoutToolStrip;
        private ToolStripMenuItem horizontalToolStrip;
        private ToolStripMenuItem verticalToolStrip;
        private ToolStripMenuItem stackToolStrip;
        private VS2015LightTheme vS2015LightTheme1;
        private ToolStripButton tsBtGoBack;
        private ToolStripButton tsBtGoForward;
        private ToolStripSeparator toolStripSeparator1;
        private NotifyIcon notifyMenu;
        private ContextMenuStrip cmsNotifyMenu;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem notifyTSMIExit;
        private ToolStripMenuItem notifyTSMIShow;
        private ToolStripMenuItem notifyTSMINewPort;
        private ContextMenuStrip sysMenu;
        private ToolStripMenuItem settingSysMenu;
        private ToolStripMenuItem themeSysMenu;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem lightToolStripMenuItem;
        private ToolStripMenuItem colorToolStripMenuItem;
        private Button btTopMost;
        private Button btSysMenu;
        private Panel panel1;
        private Button btClose;
        private Button btMaximize;
        private Button btMinimize;
        private Button button2;
        private ToolStripButton toolStripButton1;
        private Timer mainTimer;
    }
}