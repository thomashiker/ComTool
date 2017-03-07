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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCloseAllButThisOne = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.exitWithoutSavingLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSolutionExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemPropertyWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemToolbox = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOutputWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTaskList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemToolBar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemStatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemLayoutByCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLayoutByXml = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLockLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemSchemaVS2003 = new System.Windows.Forms.ToolStripMenuItem();
            this.showRightToLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowDocumentIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemDockingWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDockingMdi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSystemMdi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
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
            this.screenShotButton = new System.Windows.Forms.ToolStripButton();
            this.openFavourateButton = new System.Windows.Forms.ToolStripButton();
            this.sbtLayoutToolStrip = new System.Windows.Forms.ToolStripSplitButton();
            this.horizontalToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.stackToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.hideMenuButton = new System.Windows.Forms.ToolStripButton();
            this.topMostButton = new System.Windows.Forms.ToolStripButton();
            this.tsBtFindPrevious = new System.Windows.Forms.ToolStripButton();
            this.tsBtFindNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtGoBack = new System.Windows.Forms.ToolStripButton();
            this.tsBtGoForward = new System.Windows.Forms.ToolStripButton();
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
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.mainMenu.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.systemStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemView,
            this.menuItemTools,
            this.menuItemWindow,
            this.menuItemHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.MdiWindowListItem = this.menuItemWindow;
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.mainMenu.Size = new System.Drawing.Size(684, 25);
            this.mainMenu.TabIndex = 7;
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNew,
            this.menuItemOpen,
            this.menuItemClose,
            this.menuItemCloseAll,
            this.menuItemCloseAllButThisOne,
            this.menuItem4,
            this.menuItemExit,
            this.exitWithoutSavingLayout});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(39, 21);
            this.menuItemFile.Text = "&File";
            // 
            // menuItemNew
            // 
            this.menuItemNew.Name = "menuItemNew";
            this.menuItemNew.Size = new System.Drawing.Size(229, 22);
            this.menuItemNew.Text = "&New Receive Window";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.Size = new System.Drawing.Size(229, 22);
            this.menuItemOpen.Text = "&New Send Window";
            // 
            // menuItemClose
            // 
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Size = new System.Drawing.Size(229, 22);
            this.menuItemClose.Text = "&New Tool Window";
            // 
            // menuItemCloseAll
            // 
            this.menuItemCloseAll.Name = "menuItemCloseAll";
            this.menuItemCloseAll.Size = new System.Drawing.Size(229, 22);
            this.menuItemCloseAll.Text = "Close &All";
            // 
            // menuItemCloseAllButThisOne
            // 
            this.menuItemCloseAllButThisOne.Name = "menuItemCloseAllButThisOne";
            this.menuItemCloseAllButThisOne.Size = new System.Drawing.Size(229, 22);
            this.menuItemCloseAllButThisOne.Text = "Close All &But This One";
            this.menuItemCloseAllButThisOne.Click += new System.EventHandler(this.menuItemCloseAllButThisOne_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Size = new System.Drawing.Size(226, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(229, 22);
            this.menuItemExit.Text = "&Exit";
            // 
            // exitWithoutSavingLayout
            // 
            this.exitWithoutSavingLayout.Name = "exitWithoutSavingLayout";
            this.exitWithoutSavingLayout.Size = new System.Drawing.Size(229, 22);
            this.exitWithoutSavingLayout.Text = "Exit &Without Saving Layout";
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSolutionExplorer,
            this.menuItemPropertyWindow,
            this.menuItemToolbox,
            this.menuItemOutputWindow,
            this.menuItemTaskList,
            this.menuItem1,
            this.menuItemToolBar,
            this.menuItemStatusBar,
            this.menuItem2,
            this.menuItemLayoutByCode,
            this.menuItemLayoutByXml});
            this.menuItemView.MergeIndex = 1;
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(47, 21);
            this.menuItemView.Text = "&View";
            // 
            // menuItemSolutionExplorer
            // 
            this.menuItemSolutionExplorer.Name = "menuItemSolutionExplorer";
            this.menuItemSolutionExplorer.Size = new System.Drawing.Size(198, 22);
            this.menuItemSolutionExplorer.Text = "&Solution Explorer";
            // 
            // menuItemPropertyWindow
            // 
            this.menuItemPropertyWindow.Name = "menuItemPropertyWindow";
            this.menuItemPropertyWindow.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.menuItemPropertyWindow.Size = new System.Drawing.Size(198, 22);
            this.menuItemPropertyWindow.Text = "&Property Window";
            // 
            // menuItemToolbox
            // 
            this.menuItemToolbox.Name = "menuItemToolbox";
            this.menuItemToolbox.Size = new System.Drawing.Size(198, 22);
            this.menuItemToolbox.Text = "&Toolbox";
            // 
            // menuItemOutputWindow
            // 
            this.menuItemOutputWindow.Name = "menuItemOutputWindow";
            this.menuItemOutputWindow.Size = new System.Drawing.Size(198, 22);
            this.menuItemOutputWindow.Text = "&Output Window";
            // 
            // menuItemTaskList
            // 
            this.menuItemTaskList.Name = "menuItemTaskList";
            this.menuItemTaskList.Size = new System.Drawing.Size(198, 22);
            this.menuItemTaskList.Text = "Task &List";
            // 
            // menuItem1
            // 
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Size = new System.Drawing.Size(195, 6);
            // 
            // menuItemToolBar
            // 
            this.menuItemToolBar.Checked = true;
            this.menuItemToolBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemToolBar.Name = "menuItemToolBar";
            this.menuItemToolBar.Size = new System.Drawing.Size(198, 22);
            this.menuItemToolBar.Text = "Tool &Bar";
            // 
            // menuItemStatusBar
            // 
            this.menuItemStatusBar.Checked = true;
            this.menuItemStatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemStatusBar.Name = "menuItemStatusBar";
            this.menuItemStatusBar.Size = new System.Drawing.Size(198, 22);
            this.menuItemStatusBar.Text = "Status B&ar";
            // 
            // menuItem2
            // 
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Size = new System.Drawing.Size(195, 6);
            // 
            // menuItemLayoutByCode
            // 
            this.menuItemLayoutByCode.Name = "menuItemLayoutByCode";
            this.menuItemLayoutByCode.Size = new System.Drawing.Size(198, 22);
            this.menuItemLayoutByCode.Text = "Layout By &Code";
            // 
            // menuItemLayoutByXml
            // 
            this.menuItemLayoutByXml.Name = "menuItemLayoutByXml";
            this.menuItemLayoutByXml.Size = new System.Drawing.Size(198, 22);
            this.menuItemLayoutByXml.Text = "Layout By &XML";
            // 
            // menuItemTools
            // 
            this.menuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLockLayout,
            this.menuItem3,
            this.menuItemSchemaVS2003,
            this.showRightToLeft,
            this.menuItemShowDocumentIcon,
            this.menuItem6,
            this.menuItemDockingWindow,
            this.menuItemDockingMdi,
            this.menuItemSystemMdi,
            this.menuItem5});
            this.menuItemTools.MergeIndex = 2;
            this.menuItemTools.Name = "menuItemTools";
            this.menuItemTools.Size = new System.Drawing.Size(60, 21);
            this.menuItemTools.Text = "&Setting";
            // 
            // menuItemLockLayout
            // 
            this.menuItemLockLayout.Name = "menuItemLockLayout";
            this.menuItemLockLayout.Size = new System.Drawing.Size(243, 22);
            this.menuItemLockLayout.Text = "&Log Setting";
            // 
            // menuItem3
            // 
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Size = new System.Drawing.Size(240, 6);
            // 
            // menuItemSchemaVS2003
            // 
            this.menuItemSchemaVS2003.Name = "menuItemSchemaVS2003";
            this.menuItemSchemaVS2003.Size = new System.Drawing.Size(243, 22);
            this.menuItemSchemaVS2003.Text = "&Serial Port";
            // 
            // showRightToLeft
            // 
            this.showRightToLeft.Name = "showRightToLeft";
            this.showRightToLeft.Size = new System.Drawing.Size(243, 22);
            this.showRightToLeft.Text = "&Main Window";
            // 
            // menuItemShowDocumentIcon
            // 
            this.menuItemShowDocumentIcon.Name = "menuItemShowDocumentIcon";
            this.menuItemShowDocumentIcon.Size = new System.Drawing.Size(243, 22);
            this.menuItemShowDocumentIcon.Text = "&Receive Windows";
            // 
            // menuItem6
            // 
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Size = new System.Drawing.Size(240, 6);
            // 
            // menuItemDockingWindow
            // 
            this.menuItemDockingWindow.Checked = true;
            this.menuItemDockingWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemDockingWindow.Image = ((System.Drawing.Image)(resources.GetObject("menuItemDockingWindow.Image")));
            this.menuItemDockingWindow.Name = "menuItemDockingWindow";
            this.menuItemDockingWindow.Size = new System.Drawing.Size(243, 22);
            this.menuItemDockingWindow.Text = "&Top Most";
            // 
            // menuItemDockingMdi
            // 
            this.menuItemDockingMdi.Checked = true;
            this.menuItemDockingMdi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemDockingMdi.Image = ((System.Drawing.Image)(resources.GetObject("menuItemDockingMdi.Image")));
            this.menuItemDockingMdi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menuItemDockingMdi.Name = "menuItemDockingMdi";
            this.menuItemDockingMdi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuItemDockingMdi.Size = new System.Drawing.Size(243, 22);
            this.menuItemDockingMdi.Text = "&Locked";
            // 
            // menuItemSystemMdi
            // 
            this.menuItemSystemMdi.Name = "menuItemSystemMdi";
            this.menuItemSystemMdi.Size = new System.Drawing.Size(243, 22);
            this.menuItemSystemMdi.Text = "Document Style: S&ystem MDI";
            // 
            // menuItem5
            // 
            this.menuItem5.Name = "menuItem5";
            this.menuItem5.Size = new System.Drawing.Size(240, 6);
            // 
            // menuItemWindow
            // 
            this.menuItemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNewWindow});
            this.menuItemWindow.MergeIndex = 2;
            this.menuItemWindow.Name = "menuItemWindow";
            this.menuItemWindow.Size = new System.Drawing.Size(67, 21);
            this.menuItemWindow.Text = "&Window";
            // 
            // menuItemNewWindow
            // 
            this.menuItemNewWindow.Name = "menuItemNewWindow";
            this.menuItemNewWindow.Size = new System.Drawing.Size(153, 22);
            this.menuItemNewWindow.Text = "&New Window";
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout});
            this.menuItemHelp.MergeIndex = 3;
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(47, 21);
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Image = ((System.Drawing.Image)(resources.GetObject("menuItemAbout.Image")));
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(111, 22);
            this.menuItemAbout.Text = "&About";
            // 
            // toolBar
            // 
            this.toolBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
            this.hideMenuButton,
            this.topMostButton,
            this.tsBtGoBack,
            this.tsBtGoForward,
            this.toolStripSeparator1,
            this.tsBtFindPrevious,
            this.tsBtFindNext,
            this.toolStripSeparator3,
            this.screenShotButton,
            this.openFavourateButton,
            this.sbtLayoutToolStrip});
            this.toolBar.Location = new System.Drawing.Point(0, 25);
            this.toolBar.Name = "toolBar";
            this.toolBar.Padding = new System.Windows.Forms.Padding(0);
            this.toolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolBar.Size = new System.Drawing.Size(684, 25);
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
            this.toolStripButtonClear.Image = global::DockSample.Properties.Resources.brush_alt_1;
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
            this.sbtLayoutToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horizontalToolStrip,
            this.verticalToolStrip,
            this.stackToolStrip});
            this.sbtLayoutToolStrip.Image = global::DockSample.Properties.Resources.window_stack;
            this.sbtLayoutToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbtLayoutToolStrip.Name = "sbtLayoutToolStrip";
            this.sbtLayoutToolStrip.Size = new System.Drawing.Size(32, 22);
            this.sbtLayoutToolStrip.Text = "Layout";
            this.sbtLayoutToolStrip.ButtonClick += new System.EventHandler(this.sbtLayoutToolStrip_ButtonClick);
            // 
            // horizontalToolStrip
            // 
            this.horizontalToolStrip.Image = global::DockSample.Properties.Resources.window_tile_horizontally;
            this.horizontalToolStrip.Name = "horizontalToolStrip";
            this.horizontalToolStrip.Size = new System.Drawing.Size(152, 22);
            this.horizontalToolStrip.Text = "&Horizontal";
            this.horizontalToolStrip.Click += new System.EventHandler(this.horizontalToolStrip_Click);
            // 
            // verticalToolStrip
            // 
            this.verticalToolStrip.Image = global::DockSample.Properties.Resources.window_tile_vertically;
            this.verticalToolStrip.Name = "verticalToolStrip";
            this.verticalToolStrip.Size = new System.Drawing.Size(152, 22);
            this.verticalToolStrip.Text = "&Vertical";
            this.verticalToolStrip.Click += new System.EventHandler(this.verticalToolStrip_Click);
            // 
            // stackToolStrip
            // 
            this.stackToolStrip.Image = global::DockSample.Properties.Resources.window_stack;
            this.stackToolStrip.Name = "stackToolStrip";
            this.stackToolStrip.Size = new System.Drawing.Size(152, 22);
            this.stackToolStrip.Text = "&Stack";
            this.stackToolStrip.Click += new System.EventHandler(this.stackToolStrip_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 20);
            // 
            // hideMenuButton
            // 
            this.hideMenuButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.hideMenuButton.Image = global::DockSample.Properties.Resources.arrow_8_down;
            this.hideMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hideMenuButton.Margin = new System.Windows.Forms.Padding(1);
            this.hideMenuButton.Name = "hideMenuButton";
            this.hideMenuButton.Size = new System.Drawing.Size(23, 23);
            this.hideMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.hideMenuButton.Click += new System.EventHandler(this.hideMenuButton_Click);
            // 
            // topMostButton
            // 
            this.topMostButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.topMostButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.topMostButton.Image = global::DockSample.Properties.Resources.padlock_open;
            this.topMostButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.topMostButton.Name = "topMostButton";
            this.topMostButton.Size = new System.Drawing.Size(23, 22);
            this.topMostButton.Text = "TopMost";
            this.topMostButton.Click += new System.EventHandler(this.topMostButton_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 20);
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
            // dockPanel
            // 
            this.dockPanel.BackColor = System.Drawing.SystemColors.Control;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.SystemColors.ControlLight;
            this.dockPanel.DockBottomPortion = 150D;
            this.dockPanel.DockLeftPortion = 200D;
            this.dockPanel.DockRightPortion = 200D;
            this.dockPanel.DockTopPortion = 150D;
            this.dockPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dockPanel.Location = new System.Drawing.Point(0, 50);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.ShowDocumentIcon = true;
            this.dockPanel.Size = new System.Drawing.Size(684, 408);
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
            this.systemStatusStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
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
            this.systemStatusStrip.Location = new System.Drawing.Point(0, 458);
            this.systemStatusStrip.Name = "systemStatusStrip";
            this.systemStatusStrip.Size = new System.Drawing.Size(684, 22);
            this.systemStatusStrip.TabIndex = 14;
            this.systemStatusStrip.Text = "statusStrip1";
            // 
            // conectStateLabel
            // 
            this.conectStateLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conectStateLabel.Name = "conectStateLabel";
            this.conectStateLabel.Size = new System.Drawing.Size(88, 17);
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
            this.sendTimerPeriodLabel.Name = "sendTimerPeriodLabel";
            this.sendTimerPeriodLabel.Size = new System.Drawing.Size(69, 17);
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
            this.sendCharNumLabel.Name = "sendCharNumLabel";
            this.sendCharNumLabel.Size = new System.Drawing.Size(31, 17);
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
            this.rcvCharNumLabel.Name = "rcvCharNumLabel";
            this.rcvCharNumLabel.Size = new System.Drawing.Size(31, 17);
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
            this.linkTimeLabel.Name = "linkTimeLabel";
            this.linkTimeLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.linkTimeLabel.Size = new System.Drawing.Size(72, 17);
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
            // mainTimer
            // 
            this.mainTimer.Interval = 2000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(684, 480);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.systemStatusStrip);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Port";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.systemStatusStrip.ResumeLayout(false);
            this.systemStatusStrip.PerformLayout();
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
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemNew;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseAll;
        private System.Windows.Forms.ToolStripMenuItem menuItemCloseAllButThisOne;
        private System.Windows.Forms.ToolStripSeparator menuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemSolutionExplorer;
        private System.Windows.Forms.ToolStripMenuItem menuItemPropertyWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolbox;
        private System.Windows.Forms.ToolStripMenuItem menuItemOutputWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemTaskList;
        private System.Windows.Forms.ToolStripSeparator menuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemToolBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemStatusBar;
        private System.Windows.Forms.ToolStripSeparator menuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutByCode;
        private System.Windows.Forms.ToolStripMenuItem menuItemLayoutByXml;
        private System.Windows.Forms.ToolStripMenuItem menuItemTools;
        private System.Windows.Forms.ToolStripMenuItem menuItemLockLayout;
        private System.Windows.Forms.ToolStripSeparator menuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuItemSchemaVS2003;
        private System.Windows.Forms.ToolStripSeparator menuItem6;
        private System.Windows.Forms.ToolStripMenuItem menuItemDockingMdi;
        private System.Windows.Forms.ToolStripMenuItem menuItemDockingWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemSystemMdi;
        private System.Windows.Forms.ToolStripSeparator menuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowDocumentIcon;
        private System.Windows.Forms.ToolStripMenuItem menuItemWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewWindow;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem showRightToLeft;
        private System.Windows.Forms.ToolStripMenuItem exitWithoutSavingLayout;
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
        private ToolStripButton hideMenuButton;
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
        private Timer mainTimer;
    }
}