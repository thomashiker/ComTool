using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
using DockSample.Customization;
using System.Diagnostics;
using FastColoredTextBoxNS;
using CSharpWin_JD.CaptureImage;
using ColorListBoxSelector;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using CCWin;
using CCWin.SkinClass;
using CCWin.SkinControl;
using CCWin.Win32;


namespace DockSample
{
    public partial class MainForm : CCSkinMain
    {
        private SendToolsBox m_solutionExplorer;// = new SendToolsBox(this);
        //private CommandWindow m_propertyWindow = new CommandWindow();
        //private DummyToolbox m_toolbox = new DummyToolbox();
        private SendWindow sendWindow;
        private NewPortWindow newPortForm = new NewPortWindow();
        private ReceiveWindowSetting rcvSettingWindow = null;
        private ReceiveWindow lastActivedRcvWindow = null;
        private string SavedLogPath;
        private string openLogFileApplication = "notepad++.exe";
        //private bool btRepeatedSendEnable = false;
        string[] CurrentPorts;

        private VisualStudioToolStripExtender vsToolStripExtender1;


        public string LogPath
        {
            get { return SavedLogPath; }
            set { SavedLogPath = value; }
        }

        public MainForm()
        {
            InitializeComponent();

            sbtLayoutToolStrip.DefaultItem = verticalToolStrip;
            //this.Icon = this.

            m_solutionExplorer = new SendToolsBox(this);
            sendWindow = new SendWindow(this);
            newPortForm.Owner = this;

            //dockPanel.Skin = new DockPanelSkin();

            //DocumentStyle newStyle = DocumentStyle.DockingMdi;
            //dockPanel.DocumentStyle = DocumentStyle.DockingMdi;

            SavedLogPath = Application.StartupPath + "\\log";

            //mainMenu.Visible = false;

            //textTimerSetting.Text = cyclicSendTimer.Interval.ToString();
            //sendTimerPeriodLabel.Text = textTimerSetting.Text + "ms";
            linkTimeLabel.Alignment = ToolStripItemAlignment.Right;

            vsToolStripExtender1 = new VisualStudioToolStripExtender();

            SetSchema(null);

            InitialNotifyMenu();
        }

        public void SetTimerPeriodLabel(string label)
        {
            sendTimerPeriodLabel.Text = label;
        }

        private void EnableVSRenderer(VisualStudioToolStripExtender.VsVersion version, ThemeBase theme)
        {
            //vsToolStripExtender1.SetStyle(toolBar, version, theme);
            //vsToolStripExtender1.SetStyle(systemStatusStrip, version, theme);
        }

        private void SetSchema(System.EventArgs e)
        {
            // Persist settings when rebuilding UI
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.temp.config");

            //dockPanel.SaveAsXml(configFile);
            //CloseAllContents();

            this.dockPanel.Theme = vS2015LightTheme1;
            this.EnableVSRenderer(VisualStudioToolStripExtender.VsVersion.Vs2015, vS2015LightTheme1);

            if (dockPanel.Theme.ColorPalette != null)
            {
                //systemStatusStrip.BackColor = dockPanel.Theme.ColorPalette.MainWindowStatusBarDefault.Background;
                //miniSendPanel.BackColor = dockPanel.Theme.ColorPalette.MainWindowStatusBarDefault.Background;
            }

            //if (File.Exists(configFile))
            //    dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
        }

        #region Methods

        public void SetOpenLogsApplication(string file)
        {
            openLogFileApplication = file;
        }

        public void SetOpenLogsPath(string path)
        {
            SavedLogPath = path;
        }

        public DockPanel getDockPanel()
        {
            return this.dockPanel;
        }

        public void SetMdiChildrenLogPath(string path)
        {
            ReceiveWindow rcvWin;

            SavedLogPath = path;
            foreach (Form form in MdiChildren)
            {
                rcvWin = (ReceiveWindow)form;
                rcvWin.SetSavedLogPath(SavedLogPath);
            }
        }

        private void SetDockPanelSkinOptions(bool isChecked)
        {
            if (isChecked)
            {
                // All of these options may be set in the designer.
                // This is not a complete list of possible options available in the skin.

                AutoHideStripSkin autoHideSkin = new AutoHideStripSkin();
                autoHideSkin.DockStripGradient.StartColor = Color.AliceBlue;
                autoHideSkin.DockStripGradient.EndColor = Color.Blue;
                autoHideSkin.DockStripGradient.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
                autoHideSkin.TabGradient.StartColor = SystemColors.Control;
                autoHideSkin.TabGradient.EndColor = SystemColors.ControlDark;
                autoHideSkin.TabGradient.TextColor = SystemColors.ControlText;
                autoHideSkin.TextFont = new Font("Showcard Gothic", 10);

                //dockPanel.Skin.AutoHideStripSkin = autoHideSkin;

                DockPaneStripSkin dockPaneSkin = new DockPaneStripSkin();
                dockPaneSkin.DocumentGradient.DockStripGradient.StartColor = Color.Red;
                dockPaneSkin.DocumentGradient.DockStripGradient.EndColor = Color.Pink;

                dockPaneSkin.DocumentGradient.ActiveTabGradient.StartColor = Color.Green;
                dockPaneSkin.DocumentGradient.ActiveTabGradient.EndColor = Color.Green;
                dockPaneSkin.DocumentGradient.ActiveTabGradient.TextColor = Color.White;

                dockPaneSkin.DocumentGradient.InactiveTabGradient.StartColor = Color.Gray;
                dockPaneSkin.DocumentGradient.InactiveTabGradient.EndColor = Color.Gray;
                dockPaneSkin.DocumentGradient.InactiveTabGradient.TextColor = Color.Black;

                dockPaneSkin.TextFont = new Font("SketchFlow Print", 10);

                //dockPanel.Skin.DockPaneStripSkin = dockPaneSkin;
            }
            else
            {
                //dockPanel.Skin = new DockPanelSkin();
            }
        }

        private void SetActiveTabColor(bool enable)
        {
            if (enable)
            {
                //dockPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.StartColor = SystemColors.Highlight;
                //dockPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.EndColor = SystemColors.Highlight;
            }
            else
            {
                //dockPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.StartColor = SystemColors.ControlDarkDark;
               // dockPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.EndColor = SystemColors.ControlDarkDark;
            }
        }

        #endregion

        #region Event Handlers

        /*private void menuItemClose_Click(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                ActiveMdiChild.Close();
            else if (dockPanel.ActiveDocument != null)
                dockPanel.ActiveDocument.DockHandler.Close();
            dockPanel.ActiveDocument.OnActivated();
        }*/

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            menuItemLayout();

            rcvSettingWindow = new ReceiveWindowSetting(this);
            rcvSettingWindow.Owner = this;
        }

        private void menuItemLayout()
        {
            dockPanel.SuspendLayout(true);

            //CloseAllDocuments();

            // m_solutionExplorer = new DummySolutionExplorer();
            //m_propertyWindow = new CommandWindow();
            //m_toolbox = new DummyToolbox();
            //sendwin = new SendWindow(this);

            //m_toolbox.Show(dockPanel, DockState.DockLeftAutoHide);
            //m_taskList.Show(m_toolbox.Pane, null);
            //sendwin.Show(dockPanel, DockState.DockBottom);
            m_solutionExplorer.Show(dockPanel, DockState.DockRight);
            sendWindow.Show(dockPanel);

            dockPanel.ResumeLayout(true, true);

            m_solutionExplorer.DockState = DockState.DockRightAutoHide;
        }

        private void menuItemCloseAllButThisOne_Click(object sender, System.EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                Form activeMdi = ActiveMdiChild;
                foreach (Form form in MdiChildren)
                {
                    if (form != activeMdi)
                        form.Close();
                }
            }
            else
            {
                //MessageBox.Show("menuItemCloseAllButThisOne_Click");
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    if (!document.DockHandler.IsActivated)
                        document.DockHandler.Close();
                }
            }
        }

        #endregion

        public void LayoutRcvWindows(MdiLayout layout)
        {
            int index = 0;
            IDockContent pre = null;
            DockStyle style = DockStyle.Fill;

            dockPanel.SuspendLayout(true);

            switch (layout)
            {
                case MdiLayout.TileHorizontal:
                    style = DockStyle.Bottom;
                    break;
                case MdiLayout.TileVertical:
                    style = DockStyle.Right;
                    break;
                case MdiLayout.Cascade:
                default:
                    style = DockStyle.Fill;
                    break;
            }

            foreach (IDockContent document in dockPanel.DocumentsToArray())
            {
                if (0 != index)
                {
                    document.DockHandler.DockTo(pre.DockHandler.Pane, style, index);
                }
                index++;
                pre = document;
            }

            dockPanel.ResumeLayout(true, true);
        }

        public int GetRcvWinID()
        {
            bool flag = false;

            for (int id = 0; id < 32768; id++)
            {
                flag = false;
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    try
                    {
                        ReceiveWindow rcvWin = (ReceiveWindow)document.DockHandler.Form;
                        if (id == rcvWin.WinID)
                        {
                            flag = true;
                            break;
                        }
                    }
                    catch
                    {
                        //
                        break;
                    }

                }

                if (false == flag)
                {
                    return id;
                }
            }

            return -1;
        }

        public void SetUserInput(string input)
        {
            if (null != sendWindow)
            {
                sendWindow.SendTextBoxMsg = input;
            }
        }

        public string GetUserInput()
        {
            if (null != sendWindow)
            {
                return sendWindow.SendTextBoxMsg;
            }
            else
            {
                return null;
            }
        }

        private void toolBarButtonNew_Click(object sender, EventArgs e)
        {
            newPortForm.ShowDialog(this);
        }

        public void SetToolBarButtonOpenState(bool open)
        {
            if (open)
            {
                toolBarButtonOpenClose.Image = global::DockSample.Properties.Resources.connect; //toolStripimageList.Images[0];
            } else {
                toolBarButtonOpenClose.Image = global::DockSample.Properties.Resources.connection_error; //toolStripimageList.Images[1];
            }
        }

        public ReceiveWindow getActivedReceiveWindow()
        {
            /*IDockContent dockContent = this.dockPanel.ActiveContent;
            if (dockContent == null)
            {
                //MessageBox.Show("dock null");
                return null;
            }
            else if (typeof(ReceiveWindow) != dockContent.GetType())
            {
                //MessageBox.Show("not ReceiveWindow");
                return null;
            }

            return (ReceiveWindow)dockContent;*/
            return (ReceiveWindow)dockPanel.ActiveDocument;
        }

        private FastColoredTextBox GetActivedFastColoredTextBox()
        {
            ReceiveWindow rcvWin = getActivedReceiveWindow();
            FastColoredTextBox activeFastColoredTextBox = null;

            if (rcvWin != null)
            {
                activeFastColoredTextBox = rcvWin.GetFastColoredTextBox();
            }

            return activeFastColoredTextBox;
        }

        public ReceiveWindow GetLastActivedReceiveWindow()
        {
            return lastActivedRcvWindow;
        }

        private void toolBarButtonOpen_Click(object sender, EventArgs e)
        {
            ReceiveWindow rvcWin;
            bool state = true;

            rvcWin = getActivedReceiveWindow();
            if (rvcWin != null)
            {
                state = rvcWin.IsPortOpen();
                if (state)
                {
                    state = rvcWin.CloseSerialPort();
                    SetToolBarButtonOpenState(!state);
                }
                else
                {
                    state = rvcWin.OpenSerialPort();
                    SetToolBarButtonOpenState(state);
                    if (!state)
                    {
                        PortOpenFailDialog failDialog = new PortOpenFailDialog(rvcWin.Port, "&Abandone");

                        if (DialogResult.Cancel == failDialog.ShowDialog())
                        {
                            rvcWin.CloseWindow();
                        }
                    }
                }
            }
        }

        private void toolBarButtonSolutionExplorer_Click(object sender, EventArgs e)
        {
            if (null == rcvSettingWindow)
            {
                rcvSettingWindow = new ReceiveWindowSetting(this);
                rcvSettingWindow.Owner = this;
            }
            else
            {
                rcvSettingWindow.CenterShow();
            } 
        }

        public bool SetRecordState(bool state)
        {
            if (state)
            {
                tBarButtonRecord.Image = global::DockSample.Properties.Resources.MD_record; //toolStripimageList.Images[11];
                tBarButtonRecord.ToolTipText = "Click to Stop Record";
            }
            else
            {
                tBarButtonRecord.Image = global::DockSample.Properties.Resources.MD_stop;//toolStripimageList.Images[12];
                tBarButtonRecord.ToolTipText = "Click to Start Record";
            }
            return true;
        }
        private void toolBarButtonLogEnable_Click(object sender, EventArgs e)
        {
            ReceiveWindow rvcWin = getActivedReceiveWindow();

            if (null != rvcWin)
            {
                rvcWin.RecordState = !(rvcWin.RecordState);
                SetRecordState(rvcWin.RecordState);
            }
        }

        private void toolStripButtonCloseWindow_Click(object sender, EventArgs e)
        {
            ReceiveWindow rvcWin = getActivedReceiveWindow();

            if (null != rvcWin)
            {
                rvcWin.CloseWindow();
            }
        }

        private void toolStripButtonScreenShot_Click(object sender, EventArgs e)
        {
            CaptureImageTool capture = new CaptureImageTool();

            capture.SelectCursor = Cursors.Default;
            capture.DrawCursor = Cursors.Default;
            if (capture.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void ColorSettingToolStripButton_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            //cd.Color = textBox1.ForeColor;

            //if (cd.ShowDialog() == DialogResult.OK)
                //textBox1.ForeColor = MyDialog.Color;

            cd.ShowDialog();
        }

        private void toolStripButtonFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            fd.ShowApply = true;
            //fd.AnyColor = true;
            fd.ShowDialog();
        }

        public void SetPortStateLabel(bool state, string portState)
        {
            conectStateLabel.Text = portState;
        }

        public void EnablePortToolBars(bool enable)
        {
            /*toolbar*/
            //toolStripButtonCloseWindow.Enabled = enable;
            toolBarButtonLinkSetting.Enabled = enable;
            toolBarButtonLinkSetting.Enabled = enable;
            saveAsButton.Enabled = enable;
            toolStripButtonClear.Enabled = enable;
            newLogToolStripButton.Enabled = enable;
            tBarButtonRecord.Enabled = enable;
            toolBarButtonOpenLog.Enabled = enable;
            showLineButton.Enabled = enable;
            rmAllBookmarksButton.Enabled = enable;
            SetToolBarButtonOpenState(enable);

            /*send tool bar*/
            if (null != sendWindow)
            {
                sendWindow.SendToolBarEnable(enable);
            }

            /*status strip*/
            if (enable)
            {
                conectStateLabel.Font = new Font(conectStateLabel.Font.Name, conectStateLabel.Font.Size, FontStyle.Regular);
            }
            else
            {
                conectStateLabel.Font = new Font(conectStateLabel.Font.Name, conectStateLabel.Font.Size, FontStyle.Strikeout);
            }

            /*receive window tab*/
            SetActiveTabColor(enable);
        }
        public void EnableToolBarButtonOpenClose(bool enable)
        {
            toolBarButtonOpenClose.Enabled = enable;
        }

        private void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            //ReceiveWindow rvcWin = getActivedReceiveWindow();
            ReceiveWindow rvcWin = GetLastActivedReceiveWindow();

            if (rvcWin != null)
            {
                rvcWin.ClearReceiveWindow();
                rcvCharNumLabel.Text = "0";
            }
        }

        private void newLogToolStripButton_Click(object sender, EventArgs e)
        {
            ReceiveWindow rvcWin = getActivedReceiveWindow();

            if (rvcWin != null)
            {
                rvcWin.CreateLogFile();
                rvcWin.ClearReceiveWindow();
            }
        }

        private void toolBarButtonOpenLog_Click(object sender, EventArgs e)
        {
            ReceiveWindow rvcWin = getActivedReceiveWindow();

            if (rvcWin != null)
            {
                try
                {
                    Process.Start(openLogFileApplication, rvcWin.LogFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } 
        }

        private void UpdateRcvWinToolBarState(ReceiveWindow rcv)
        {
            if (null != rcv)
            {
                bool state = rcv.IsPortOpen();

                SetToolBarButtonOpenState(state);
                SetRecordState(rcv.RecordState);
                SetPortStateLabel(state, rcv.GetPortInfo());
                EnablePortToolBars(state);
                EnableToolBarButtonOpenClose(true);

                UpdateLinkTimeDisplay(rcv.TimeElapse);
            }
        }

        private void dockPanel_ActiveDocumentChanged(object sender, EventArgs e)
        {
            lastActivedRcvWindow = (ReceiveWindow)dockPanel.ActiveDocument;

            UpdateRcvWinToolBarState(lastActivedRcvWindow);
        }

        private void showLineToolStripButton_Click(object sender, EventArgs e)
        {
            bool showState = true;
            ReceiveWindow rcvWin = GetLastActivedReceiveWindow();
            if (rcvWin != null)
            {
                showState = rcvWin.GetFastColoredTextBoxLineShowState();
                rcvWin.SetFastColoredTextBoxLineShowState(!showState);
            }
        }

        private void rmAllBookmarksButton_Click(object sender, EventArgs e)
        {
            ReceiveWindow rvcWin = null;

            rvcWin = getActivedReceiveWindow();
            if (rvcWin != null)
            {
                rvcWin.RemoveAllBookmarks();
            } 
        }

        private void tsBtFindNext_Click(object sender, EventArgs e)
        {
            ReceiveWindow rcvWin = GetLastActivedReceiveWindow();
            if (rcvWin != null)
            {
                //rcvWin.SearchDialog(null);
                FastColoredTextBox fcbox = rcvWin.GetFastColoredTextBox();
                if (null != fcbox)
                {
                    fcbox.findForm.FCBFindNext();
                }
            }
        }

        private void tsBtFindPrevious_Click(object sender, EventArgs e)
        {
            ReceiveWindow rcvWin = GetLastActivedReceiveWindow();
            if (rcvWin != null)
            {
                FastColoredTextBox fcbox = rcvWin.GetFastColoredTextBox();
                if (null != fcbox)
                {
                    fcbox.findForm.FCBFindPrevious();
                }
            }
        }

        private void topMostButton_Click(object sender, EventArgs e)
        {
            if (this.TopMost)
            {
                this.TopMost = false;
                topMostButton.Image = toolStripimageList.Images[6];
            }
            else{
                this.TopMost = true;
                topMostButton.Image = toolStripimageList.Images[7];
            }
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            ReceiveWindow rvcWin = getActivedReceiveWindow();

            if (rvcWin != null)
            {
                rvcWin.SaveToFileAs();
            }
        }

        private void openLogFolderButton_Click(object sender, EventArgs e)
        {
            ReceiveWindow rvcWin = getActivedReceiveWindow();

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            if (rvcWin != null)
            {
                psi.Arguments = "/e,/select," + rvcWin.LogFile;
            }
            else
            {
                psi.Arguments = "/e,/select," + SavedLogPath;
            }
            System.Diagnostics.Process.Start(psi);
            //System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void openFavourateButton_Click(object sender, EventArgs e)
        {
            //HistoryWindow history = new HistoryWindow();
            //history.ShowDialog(this);

            if (sendWindow.IsHidden)
            {
                sendWindow.Show();
                openFavourateButton.ToolTipText = "Click To Hide Send Window";
            }
            else
            {
                sendWindow.Hide();
                openFavourateButton.ToolTipText = "Click To Show Send Window";
            }
        }

        public bool SendMessage(string msg)
        {
            bool state = true;
            ReceiveWindow rcvWin = null;

            rcvWin = GetLastActivedReceiveWindow();
            if (rcvWin != null)
            {
                state = rcvWin.SendMessageToPort(msg);
            }

            return state;
        }

        public bool SendMessageWithoutLog(string msg)
        {
            bool state = true;
            ReceiveWindow rcvWin = null;

            rcvWin = GetLastActivedReceiveWindow();
            if (rcvWin != null)
            {
                state = rcvWin.SendMessageToPortWithoutLog(msg);
            }

            return state;
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            //ReceiveWindow rvcWin = null;
            //cbSendMsg.Text = this.Location.ToString();

            foreach (ReceiveWindow rvcWin in dockPanel.Documents)
            {
                if (rvcWin != null)
                {
                    rvcWin.SetLocationChangedEvent(e);
                }
            }

            if (null != sendWindow)
            {
                sendWindow.SetLocationChangedEvent(e);
            }
            /*if (null != sendwin)
            {
                sendwin.SetLocation();
            }*/
            //rvcWin = getActivedReceiveWindow();
            //if (rvcWin != null)
            // {
            //    rvcWin.setLocationChangedEvent(e);
            //}
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.T && e.Control)
            {
                e.Handled = true;

                //sendwin.Display();
                //MessageBox.Show("MainForm_KeyDown");
            }
        }

        private void btRepeatSend_MouseHover(object sender, EventArgs e)
        {
            //repeatSendToolTip.Show("repeat send", btRepeatSend);
        }

        public void UpdateLinkTimeDisplay(Int64 time)
        {
            Int64 seconds;
            Int64 hours;
            Int64 minutes;

            seconds = time % 60;
            hours = time / 60;
            minutes = (hours) % 60;
            hours = hours / 60;
            linkTimeLabel.Text = hours.ToString().PadLeft(2, '0') + ":" + minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
        }

        public void UpdateRcvCharDisplay(Int64 num)
        {
            rcvCharNumLabel.Text = num.ToString();
        }

        public void UpdateSendCharDisplay(Int64 num)
        {
            sendCharNumLabel.Text = num.ToString();
        }

        private void btUploadCmdList_Click(object sender, EventArgs e)
        {
            //sendComboBoxMenu.Show(MousePosition.X, MousePosition.Y);
        }

        private void addToList_Click(object sender, EventArgs e)
        {
            //cbSendMsg.Items.Add(cbSendMsg.Text);
        }

        private void removeFromList_Click(object sender, EventArgs e)
        {
            /*int index = cbSendMsg.SelectedIndex;
            if (index >= 0)
            {
                cbSendMsg.Text = null;
                cbSendMsg.Items.RemoveAt(index);
            }*/
        }

        private void addListFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            fileDialog.FilterIndex = 1;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fileDialog.FileName, Encoding.UTF8);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))//!cbSendMsg.Items.Contains(line) && 
                    {
                        //cbSendMsg.Items.Add(line);
                    }
                }
                sr.Close();
            }
        }

        private void clearList_Click(object sender, EventArgs e)
        {
           // cbSendMsg.Text = null;
            //cbSendMsg.Items.Clear();
        }

        private void saveListToFile_Click(object sender, EventArgs e)
        {
            /*SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "text(*.txt)|*.txt";
            sfd.InitialDirectory = Application.StartupPath;
            sfd.RestoreDirectory = true;
            FileStream fs;
            byte[] data;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);

                for (int i = 0; i < cbSendMsg.Items.Count; i++)
                {
                    data = new UTF8Encoding().GetBytes(cbSendMsg.Items[i].ToString() + "\r\n");
                    fs.Write(data, 0, data.Length);
                }
                fs.Flush();
                fs.Close();
            }*/
        }

        private void horizontalToolStrip_Click(object sender, EventArgs e)
        {
            sbtLayoutToolStrip.Image = horizontalToolStrip.Image;
            LayoutRcvWindows(MdiLayout.TileHorizontal);
        }

        private void verticalToolStrip_Click(object sender, EventArgs e)
        {
            sbtLayoutToolStrip.Image = verticalToolStrip.Image;
            LayoutRcvWindows(MdiLayout.TileVertical);
        }

        private void stackToolStrip_Click(object sender, EventArgs e)
        {
            sbtLayoutToolStrip.Image = stackToolStrip.Image;
            LayoutRcvWindows(MdiLayout.Cascade);
        }

        private void sbtLayoutToolStrip_ButtonClick(object sender, EventArgs e)
        {
            if (sbtLayoutToolStrip.Image == horizontalToolStrip.Image)
            {
                LayoutRcvWindows(MdiLayout.TileHorizontal);
            }
            else if (sbtLayoutToolStrip.Image == verticalToolStrip.Image)
            {
                LayoutRcvWindows(MdiLayout.TileVertical);
            }
            else if (sbtLayoutToolStrip.Image == stackToolStrip.Image)
            {
                LayoutRcvWindows(MdiLayout.Cascade);
            }
        }

        private void tsBtGoBack_Click(object sender, EventArgs e)
        {
            ReceiveWindow rcvWin = GetLastActivedReceiveWindow();
            if (rcvWin != null)
            {
                FastColoredTextBox fcbox = rcvWin.GetFastColoredTextBox();
                if (null != fcbox)
                {
                    fcbox.NavigateBackward();
                }
            }
        }

        private void tsBtGoForward_Click(object sender, EventArgs e)
        {
            ReceiveWindow rcvWin = GetLastActivedReceiveWindow();
            if (rcvWin != null)
            {
                FastColoredTextBox fcbox = rcvWin.GetFastColoredTextBox();
                if (null != fcbox)
                {
                    fcbox.NavigateForward();
                }
            }
        }

        private void DropDownPorts_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            //MessageBox.Show(item.Text);

            foreach (IDockContent document in dockPanel.DocumentsToArray())
            {
                ReceiveWindow rcv = (ReceiveWindow)document;
                if (rcv.GetPortName() == item.Text)
                {
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.Activate();
                        this.ShowInTaskbar = true;
                    }
                    rcv.Activate();
                    return;
                }
            }

            if (null != newPortForm)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                    this.ShowInTaskbar = true;
                }
                newPortForm.ShowNewPortDialog(this, item.Text);
            }
        }
   
        private void CreatDropDownPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            if (ports != CurrentPorts)
            {
                CurrentPorts = ports;
                notifyTSMINewPort.DropDownItems.Clear();
                foreach (string name in CurrentPorts)
                {
                    ToolStripItem item = notifyTSMINewPort.DropDownItems.Add(name);
                    item.BackColor = System.Drawing.SystemColors.ButtonFace;
                    item.Image = global::DockSample.Properties.Resources.ftp_alt_2;
                    item.Click += new System.EventHandler(DropDownPorts_Click);
                }
            }
        }

        private void InitialNotifyMenu()
        {
            notifyMenu.Icon = this.Icon;

            if (null != notifyMenu.ContextMenuStrip)
            {
                CreatDropDownPorts();
            }
            else
            {
                notifyMenu.ShowBalloonTip(1000, "Error", "Menu Create Failed!", ToolTipIcon.Error);
            }

            //mainTimer.Start();
        }

        private void notifyMenu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                    //this.ShowInTaskbar = true;
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                   // this.ShowInTaskbar = false;
                }
            }
        }

        private void notifyTSMIExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyTSMIShow_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
            }
            this.Visible = true;
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            CreatDropDownPorts();
        }

        private void MainForm_SysBottomClick(object sender, SysButtonEventArgs e)
        {
            if (e.SysButton.Name == "SysMenu")
            {
                sysMenu.Show(MousePosition);
            }
        }

        private void btTopMost_Click(object sender, EventArgs e)
        {
            if (this.TopMost)
            {
                this.TopMost = false;
                btTopMost.BackColor = this.BackColor;
            }
            else
            {
                this.TopMost = true;
                btTopMost.BackColor = Color.FromArgb(222, 77, 58);
            }
        }

        private void btSysMenu_Click(object sender, EventArgs e)
        {
            //Point p = btSysMenu.PointToClient(btSysMenu.Location);
            
            sysMenu.Show(Cursor.Position);//Cursor.Position);
        }

        private void btMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                btMaximize.Text = "2";
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                btMaximize.Text = "1";
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                btMaximize.Text = "1";
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                btMaximize.Text = "1";
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                btMaximize.Text = "2";
            }
        }
    }
}