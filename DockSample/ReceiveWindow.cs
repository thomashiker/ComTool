using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.IO.Ports;
using System.Timers;
using FastColoredTextBoxNS;
using System.Threading;


namespace DockSample
{
    public partial class ReceiveWindow : DockContent
    {
        private bool recordState = true;
        private string logPath = "log";
        private string logFileName = null;
        private string sendLogFileName = null;
        private string textEncoding = "GB2312";
        private bool IsShowed = false;
        private MainForm mainForm;
        private Int64 timeElapse = 0;
        private Int64 rcvCharNum = 0;
        private Int64 sendCharNum = 0;
        private bool receiveWindowAutoScroll = true;
        private int winID = -1;

        public void SetLocationChangedEvent(EventArgs e)
        {
            this.OnLocationChanged(e);
        }

        public void SetActivatedEvent(EventArgs e)
        {
            //this.OnActivated(e);
            this.ActivateMdiChild(this);
        }

        public void SetDeactivatedEvent(EventArgs e)
        {
            this.OnDeactivate(e);
        }

        public string LogFile
        {
            get { return logFileName; }
            set { logFileName = value; }
        }

        public SerialPort Port
        {
            get { return serialPort; }
            set { serialPort = value; }
        }

        public int WinID
        {
            get { return winID; }
            set { winID = value; }
        }

        public Int64 TimeElapse
        {
            get { return timeElapse; }
            set { timeElapse = value; }
        }

        public bool RecordState
        {
            get { return recordState; }
            set { recordState = value; }
        }

        public ReceiveWindow()
        {
            mainForm = null;

            InitializeComponent();

            serialPort = null;
        }

        public ReceiveWindow(string winName, PortInfo info, MainForm parentForm, string path)
        {
            mainForm = parentForm;
            logPath = path;

            InitializeComponent();

            try
            {
                if (null != winName && 0 != winName.Length)
                {
                    this.Text = winName;//"[" + info.GetPortName() + "]" +
                }
                else
                {
                    WinID = parentForm.GetRcvWinID();
                    this.Text = info.GetPortName();
                }
                

                serialPort.PortName = info.GetPortName();
                serialPort.BaudRate = info.GetPortBaudRate();
                serialPort.Parity   = info.GetPortParity();
                serialPort.DataBits = info.GetPortDataBits();
                serialPort.StopBits = info.GetPortStopBits();
            }
            catch
            {
                MessageBox.Show("Create " + info.GetPortName() + " failed!");
                this.Close();
                return;
            }
        }

        private void StartOpenedTimer()
        {
            openedTimer.Enabled = true;
        }
        private void StopOpenedTimer()
        {
            openedTimer.Enabled = false;
        }

        private void DisplayTimeElapse(long elapse)
        {
            if (mainForm != null)
            {
                if (mainForm.GetLastActivedReceiveWindow() == this)
                {
                    mainForm.UpdateLinkTimeDisplay(elapse);
                }
            }
        }

        private void openedTimer_Tick(object sender, EventArgs e)
        {
            TimeElapse++;
            DisplayTimeElapse(TimeElapse);

            if (mainForm != null)
            {
                if (mainForm.GetLastActivedReceiveWindow() == this)
                {
                    mainForm.UpdateSendCharDisplay(sendCharNum);
                    mainForm.UpdateRcvCharDisplay(rcvCharNum);
                }
            }

            if (!IsPortOpen())
            {
                CloseSerialPort();
            }
        }

        public string GetPortInfo()
        {
            string portInfo = null;
            portInfo += serialPort.PortName + ",";
            portInfo += serialPort.BaudRate.ToString() + ",";
            portInfo += serialPort.DataBits.ToString() + ",";
            portInfo += Convert.ToDecimal(serialPort.StopBits);
            return portInfo;
        }

        public string GetPortName()
        {
            return serialPort.PortName;
        }

        public void SetSavedLogPath(string path)
        {
            logPath = path;
            this.logFileName = null;
        }

        public void ClearReceiveWindow()
        {
            fastColoredTextBox.Clear();
        }

        public bool GetFastColoredTextBoxLineShowState()
        {
            return fastColoredTextBox.ShowLineNumbers;
        }
        public void SetFastColoredTextBoxLineShowState(bool enable)
        {
            if (!enable)
            {
                fastColoredTextBox.Bookmarks.Clear();
            }

            fastColoredTextBox.ShowLineNumbers = enable;
        }

        public FastColoredTextBox GetFastColoredTextBox()
        {
            return fastColoredTextBox;
        }

        public void ConfigSetting(FastColoredTextBox fctb)
        {
            if (null != fctb)
            {
                fastColoredTextBox.Font = fctb.Font;
                fastColoredTextBox.ForeColor = fctb.ForeColor;
                fastColoredTextBox.BackColor = fctb.BackColor;
                fastColoredTextBox.SelectionColor = fctb.SelectionUnFormatColor;

                fastColoredTextBox.LineNumberColor = fctb.LineNumberColor;
                fastColoredTextBox.IndentBackColor = fctb.IndentBackColor;
                fastColoredTextBox.BookmarkColor = fctb.BookmarkColor;
            }
        }

        public bool IsPortOpen()
        {
            try
            {
                return serialPort.IsOpen;
            }
            catch
            {
                MessageBox.Show(serialPort.PortName + " unavailable!");
                CloseWindow();
            }

            return false;
        }

        private void SetContextMenuStripState(bool whenOpen)
        {
            if (whenOpen)
            {
                openToolStripMenuItem.Text = "Disconnect";
                openToolStripMenuItem.Image = menuStripImageList.Images[0];
            }
            else
            {
                openToolStripMenuItem.Text = "Connect";
                openToolStripMenuItem.Image = menuStripImageList.Images[1];
            }
        }

        private void RefreshIcon()
        {
            this.CloseButtonVisible = false;
            this.CloseButtonVisible = true;
        }

        public bool OpenSerialPort()
        {
            if (null == serialPort)
            {
                CloseWindow();
                return false;
            }

            if (IsPortOpen())
            {
                MessageBox.Show(serialPort.PortName + " is openning!");
                return true;
            }

            try
            {
                serialPort.Open();
                Bitmap bmp = new Bitmap(global::DockSample.Properties.Resources.connect);
                IntPtr h = bmp.GetHicon();
                this.Icon = System.Drawing.Icon.FromHandle(h);
                //DeleteObject(h);
                //this.Icon = new Icon("E:\\COM Terminal\\COMx\\COM Terminal\\DockSample\\Resources\\DefaultIcon\\ico\\connect.ico");
            }
            catch
            {
                Bitmap bmp = new Bitmap(global::DockSample.Properties.Resources.connection_error);
                IntPtr h = bmp.GetHicon();
                this.Icon = System.Drawing.Icon.FromHandle(h);
                //this.Icon = new Icon("E:\\COM Terminal\\COMx\\COM Terminal\\DockSample\\Resources\\DefaultIcon\\ico\\connection_error.ico");
                return false;
            }

            RefreshIcon();

            if (mainForm != null)
            {
                mainForm.SetPortStateLabel(IsPortOpen(), GetPortInfo());
                mainForm.EnablePortToolBars(true);
                mainForm.EnableToolBarButtonOpenClose(true);
            }

            serialPort.Encoding = System.Text.Encoding.GetEncoding("GB2312");

            SetContextMenuStripState(true);

            CreateLogFile();

            StartOpenedTimer();

            return true;
        }

        public bool CloseSerialPort()
        {
            try
            {
                serialPort.Close();
                Bitmap bmp = new Bitmap(global::DockSample.Properties.Resources.connection_error);
                IntPtr h = bmp.GetHicon();
                this.Icon = System.Drawing.Icon.FromHandle(h);
                //this.Icon = new Icon("E:\\COM Terminal\\COMx\\COM Terminal\\DockSample\\Resources\\DefaultIcon\\ico\\connection_error.ico");
            }
            catch// (IOException)
            {
                MessageBox.Show(serialPort.PortName + "unavailable!");
                StopOpenedTimer();
                CloseWindow();
                return false;
            }

            RefreshIcon();

            if (mainForm != null)
            {
                mainForm.SetPortStateLabel(IsPortOpen(), GetPortInfo());
                mainForm.EnablePortToolBars(false);
            }

            SetContextMenuStripState(false);
            

            StopOpenedTimer();

            return true;
        }

        public void ShowWindow()
        {
            if (!IsShowed)
            {
                DockPanel dockPanel = mainForm.getDockPanel();

                //dockPanel.SuspendLayout(true);
                //this.Text = serialPort.PortName;
                this.Show(dockPanel, DockState.Document);
                //dockPanel.ResumeLayout(true, true);
            }
            IsShowed = true;
        }

        public void CloseWindow()
        {
            if (serialPort != null)
            {
                try {
                    serialPort.Close();
                } catch{}
            }

            this.Close();
        }

        private void Log(string msg)
        {
            this.fastColoredTextBox.Invoke(new EventHandler(delegate
            {
                this.fastColoredTextBox.AppendText(msg);
                if (receiveWindowAutoScroll)
                {
                    fastColoredTextBox.GoEnd();
                }
            }));
        }

        public string CreateLogFile()
        {
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            //if (this.LogFile == null)
            //{
                this.LogFile = logPath + "\\" + "[" + serialPort.PortName + "]" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            //}
/*            else
            {
                this.LogFile = "[" + serialPort.PortName + "]" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            }*/

            if (!File.Exists(this.LogFile))
            {
                FileStream fs = new FileStream(this.LogFile, FileMode.Create, FileAccess.ReadWrite);
                fs.Close();
            }

            return this.LogFile;
        }

        private void LogToFile(string data)
        {
            if (recordState)
            {
                if (this.LogFile == null)
                {
                    CreateLogFile();
                }

                try
                {
                    File.AppendAllText(this.LogFile, data);
                    //File.AppendAllText��String�� String�� Encoding��
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Read all the data waiting in the buffer
            string data = serialPort.ReadExisting();

            rcvCharNum += data.Length;

            LogToFile(data);

            // Display the text to the user in the terminal
            Log(data);
        }

        public void CreateSendLogFile()
        {
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            sendLogFileName = logPath + "\\" + "[" + serialPort.PortName + "]" + "SendLog.txt";

            if (!File.Exists(sendLogFileName))
            {
                FileStream fs = new FileStream(sendLogFileName, FileMode.Create, FileAccess.ReadWrite);
                fs.Close();
            }
        }

        private static Mutex mutex = new Mutex();
        private void SaveSendLogToFile(string data)
        {
            if (sendLogFileName == null)
            {
                CreateSendLogFile();
            }

            mutex.WaitOne(1000);
            try
            {
                File.AppendAllText(sendLogFileName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff" + "\n"));
                File.AppendAllText(sendLogFileName, data);
                //File.AppendAllText��String�� String�� Encoding��
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //MessageBox.Show("SaveSendLogToFile");
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        private bool SendMessage(string msg, bool save2file)
        {
            bool isOpen = IsPortOpen();

            if (msg == null)
            {
                return true;
            }

            if (isOpen)
            {
                try
                {
                    serialPort.Write(msg);

                    sendCharNum += msg.Length;

                    if (save2file)
                    {
                        SaveSendLogToFile(msg);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                //MessageBox.Show(serialPort.PortName + "  Not Opened!");
                return false;
            }

            return true;
        }

        public bool SendMessageToPort(string msg)
        {
            return SendMessage(msg, true);
        }

        public bool SendMessageToPortWithoutLog(string msg)
        {
            return SendMessage(msg, false);
        }

        private void SetSendMsg(string input)
        {
            if (null != mainForm)
            {
                mainForm.SetUserInput(input);
            }
        }

        private string GetSendMsg()
        {
            if (null != mainForm)
            {
                return mainForm.GetUserInput();
            }
            return null;
        }

        private void AddSendMsg(string input)
        {
            SetSendMsg(GetSendMsg() + input);
        }

        private void ReceiveUserInput(string input)
        {
            AddSendMsg(input);
        }

        private void MinusUserInputChar()
        {
            string userInputMsg = GetSendMsg();
            if (null != userInputMsg)
            {
                if (userInputMsg.Length > 1)
                {
                    userInputMsg = userInputMsg.Remove(userInputMsg.Length - 1);
                }
                else
                {
                    ClearUserInput();
                }
            }

            SetSendMsg(userInputMsg);
        }

        private void ClearUserInput()
        {
            SetSendMsg(null);
        }

        private void fastColoredTextBox_KeyPressed(object sender, KeyPressEventArgs e)
        {
            ReceiveUserInput(e.KeyChar.ToString());
            //MessageBox.Show(e.KeyChar.ToString());
        }

        private void fastColoredTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char input = e.KeyChar;
            //ReceiveUserInput(e.KeyChar.ToString());
            if (input > 31 && input < 126)
            {
                ReceiveUserInput(input.ToString());
                //MessageBox.Show(code.ToString());
            }
        }

        private void receiveRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ReceiveUserInput("\n");
                    StringBuilder sendMsgBuilder = new StringBuilder(GetSendMsg());
                    //sendMsgBuilder.Append("\n");

                    SendMessageToPort(sendMsgBuilder.ToString());

                    ClearUserInput();
                    e.Handled = true;
                    break;
                case Keys.Back:
                    MinusUserInputChar();
                    e.Handled = true;
                    break;
                case Keys.Delete:
                    e.Handled = true;
                    break;
                default:
                    break;
            }
        }

        private void SetRightMenusState()
        {
            if (fastColoredTextBox.SelectedText.Equals(""))
            {
                copyToolStripMenuItem.Enabled = false;
            }
            else
            {
                copyToolStripMenuItem.Enabled = true;
            }

            if (fastColoredTextBox.Text.Length > 0)
            {
                clearToolStripMenuItem.Enabled = true;
            }
            else
            {
                clearToolStripMenuItem.Enabled = false;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fastColoredTextBox.SelectedText.Equals(""))
                return;
            Clipboard.SetDataObject(fastColoredTextBox.SelectedText, true);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox.SelectAll();
            Clipboard.SetDataObject(fastColoredTextBox.SelectedText, true);
        }

        public void SearchDialog(string find)
        {
            fastColoredTextBox.ShowFindDialog();
        }

        private void fastColoredTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.X < fastColoredTextBox.LeftIndent)
            {
                var place = fastColoredTextBox.PointToPlace(e.Location);
                if (fastColoredTextBox.Bookmarks.Contains(place.iLine))
                    fastColoredTextBox.Bookmarks.Remove(place.iLine);
                else
                    fastColoredTextBox.Bookmarks.Add(place.iLine);
            }
        }

        public void AddAllBookmark()
        {
            fastColoredTextBox.Bookmarks.Add(fastColoredTextBox.Selection.Start.iLine);
        }

        public void RemoveBookmark()
        {
            fastColoredTextBox.Bookmarks.Remove(fastColoredTextBox.Selection.Start.iLine);
        }

        public void RemoveAllBookmarks()
        {
            int line = 0;
            while (line < fastColoredTextBox.LinesCount)
            {
                fastColoredTextBox.Bookmarks.Remove(line);
                line++;
            }
        }

        private void clearAllBookmarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAllBookmarks();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        private void stopScrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!receiveWindowAutoScroll)
            {
                //stopScrollToolStripMenuItem.Image = menuStripImageList.Images[0];
                stopScrollToolStripMenuItem.Text = "Auto Scroll";
            }
            else
            {
                //stopScrollToolStripMenuItem.Image = menuStripImageList.Images[1];
                stopScrollToolStripMenuItem.Text = "Stop Scroll";
            }
            receiveWindowAutoScroll = !receiveWindowAutoScroll;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsPortOpen())
            {
                CloseSerialPort();
            }
            else
            {
                if (!OpenSerialPort())
                {
                    PortOpenFailDialog failDialog = new PortOpenFailDialog(serialPort, "&Abandone");

                    if (DialogResult.Cancel == failDialog.ShowDialog())
                    {
                        CloseWindow();
                        return;
                    }
                }
            }
        }

        public void SaveToFileAs()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            fileDialog.DefaultExt = "txt";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fastColoredTextBox.SaveToFile(fileDialog.FileName, Encoding.GetEncoding("GB2312"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void windowSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            fastColoredTextBox.ShowFindDialog();
        }

        public void SetFindFormTopMost(bool flag)
        {
            if (null != fastColoredTextBox.findForm)
            {
                fastColoredTextBox.findForm.TopMost = flag;
            }
        }
        /// <summary>
        /// Size Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fastColoredTextBox_SizeChanged(object sender, EventArgs e)
        {
            //SetFctbFindForm_Location();
            //MessageBox.Show("fastColoredTextBox_SizeChanged");
            if (null != fastColoredTextBox.findForm)
            {
                //fastColoredTextBox.findForm.TopMost = true;
                fastColoredTextBox.findForm.Location = new Point(-this.PointToClient(this.Location).X + this.Width - fastColoredTextBox.findForm.Width - 20, -this.PointToClient(this.Location).Y + this.Top);
            }
            if (null != fastColoredTextBox.replaceForm)
            {
                fastColoredTextBox.replaceForm.Location = new Point(-this.PointToClient(this.Location).X + this.Width - fastColoredTextBox.replaceForm.Width - 20, -this.PointToClient(this.Location).Y + this.Top);
            }
        }

        /// <summary>
        /// Location Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fastColoredTextBox_LocationChanged(object sender, EventArgs e)
        {
            if (null != fastColoredTextBox.findForm)
            {
                //fastColoredTextBox.findForm.TopMost = true;
                fastColoredTextBox.findForm.Location = new Point(-this.PointToClient(this.Location).X + this.Width - fastColoredTextBox.findForm.Width - 20, -this.PointToClient(this.Location).Y + this.Top);
            }
            if (null != fastColoredTextBox.replaceForm)
            {
                fastColoredTextBox.replaceForm.Location = new Point(-this.PointToClient(this.Location).X + this.Width - fastColoredTextBox.replaceForm.Width - 20, -this.PointToClient(this.Location).Y + this.Top);
            }
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != mainForm)
            {
                mainForm.LayoutRcvWindows(MdiLayout.TileHorizontal);
            }
        }

        private void verticalToolStrip_Click(object sender, EventArgs e)
        {
            if (null != mainForm)
            {
                mainForm.LayoutRcvWindows(MdiLayout.TileVertical);
            }
        }

        private void stackToolStrip_Click(object sender, EventArgs e)
        {
            if (null != mainForm)
            {
                mainForm.LayoutRcvWindows(MdiLayout.Cascade);
            }
        }

        private void ReceiveWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort != null)
            {
                try
                {
                    serialPort.Close();
                }
                catch { }
            }
        }
    }
}