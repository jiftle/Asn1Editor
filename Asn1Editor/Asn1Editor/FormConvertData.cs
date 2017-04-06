using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using LCLib.Asn1Processor;

namespace DerEditor
{
	/// <summary>
	/// Summary description for FormConvertData.
	/// </summary>
	public class FormConvertData : System.Windows.Forms.Form
	{
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button buttonToBase64;
        private System.Windows.Forms.Button buttonToHex;
        private System.Windows.Forms.Button buttonToPem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.ImageList imageListToolBar;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemOpen;
        private System.Windows.Forms.MenuItem menuItemSaveAs;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemEdit;
        private System.Windows.Forms.MenuItem menuItemCopyTextToClipboard;
        private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DataFormat currentFormat = DataFormat.PEM;
        public const int hexLineLen = 32;
        private System.Windows.Forms.MenuItem menuItemClear;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemPaste;
        private System.Windows.Forms.ToolBar toolBar;
        private System.Windows.Forms.ToolBarButton toolBarButtonOpen;
        private System.Windows.Forms.ToolBarButton toolBarButtonSaveAs;
        private System.Windows.Forms.ToolBarButton toolBarButtonCopyText;
        private System.Windows.Forms.ToolBarButton toolBarButton4;
        private System.Windows.Forms.ToolBarButton toolBarButtonPaste;
        private System.Windows.Forms.ToolBarButton toolBarButtonCut;
        private System.Windows.Forms.MenuItem menuItemCut;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItemCopy;
        public const int base64LineLen = 64;

		public FormConvertData()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormConvertData));
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.buttonToBase64 = new System.Windows.Forms.Button();
            this.buttonToHex = new System.Windows.Forms.Button();
            this.buttonToPem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.imageListToolBar = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemCopyTextToClipboard = new System.Windows.Forms.MenuItem();
            this.menuItemPaste = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemClear = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.toolBarButtonOpen = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonSaveAs = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonCopyText = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonPaste = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonCut = new System.Windows.Forms.ToolBarButton();
            this.menuItemCopy = new System.Windows.Forms.MenuItem();
            this.menuItemCut = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.richTextBox.Location = new System.Drawing.Point(3, 69);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(532, 357);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "richTextBox";
            this.richTextBox.WordWrap = false;
            // 
            // buttonToBase64
            // 
            this.buttonToBase64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToBase64.Location = new System.Drawing.Point(543, 114);
            this.buttonToBase64.Name = "buttonToBase64";
            this.buttonToBase64.Size = new System.Drawing.Size(84, 27);
            this.buttonToBase64.TabIndex = 3;
            this.buttonToBase64.Text = "To &BASE64";
            this.buttonToBase64.Click += new System.EventHandler(this.buttonToBase64_Click);
            // 
            // buttonToHex
            // 
            this.buttonToHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToHex.Location = new System.Drawing.Point(543, 75);
            this.buttonToHex.Name = "buttonToHex";
            this.buttonToHex.Size = new System.Drawing.Size(84, 27);
            this.buttonToHex.TabIndex = 4;
            this.buttonToHex.Text = "To &HEX";
            this.buttonToHex.Click += new System.EventHandler(this.buttonToHex_Click);
            // 
            // buttonToPem
            // 
            this.buttonToPem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToPem.Location = new System.Drawing.Point(543, 36);
            this.buttonToPem.Name = "buttonToPem";
            this.buttonToPem.Size = new System.Drawing.Size(84, 27);
            this.buttonToPem.TabIndex = 5;
            this.buttonToPem.Text = "To &PEM";
            this.buttonToPem.Click += new System.EventHandler(this.buttonToPem_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Current Data Format:";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Text File (*.PEM; *.txt)|*.PEM;*.txt|Binary File (*.der;*.cer;*.bin;*.pfx)|*.der;" +
                "*.cer;*.bin;*.pfx";
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormat.Items.AddRange(new object[] {
                                                                "PEM",
                                                                "HEX",
                                                                "BASE64"});
            this.comboBoxFormat.Location = new System.Drawing.Point(129, 36);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(405, 21);
            this.comboBoxFormat.TabIndex = 10;
            this.comboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormat_SelectedIndexChanged);
            // 
            // imageListToolBar
            // 
            this.imageListToolBar.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolBar.ImageStream")));
            this.imageListToolBar.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.menuItemFile,
                                                                                     this.menuItemEdit,
                                                                                     this.menuItemHelp});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.menuItemOpen,
                                                                                         this.menuItemSaveAs,
                                                                                         this.menuItem4,
                                                                                         this.menuItemExit});
            this.menuItemFile.Text = "&File";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Index = 0;
            this.menuItemOpen.Text = "&Open";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Index = 1;
            this.menuItemSaveAs.Text = "Save &as ...";
            this.menuItemSaveAs.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 3;
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 1;
            this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.menuItemCopy,
                                                                                         this.menuItemPaste,
                                                                                         this.menuItemCut,
                                                                                         this.menuItem3,
                                                                                         this.menuItemCopyTextToClipboard,
                                                                                         this.menuItem2,
                                                                                         this.menuItemClear});
            this.menuItemEdit.Text = "&Edit";
            // 
            // menuItemCopyTextToClipboard
            // 
            this.menuItemCopyTextToClipboard.Index = 4;
            this.menuItemCopyTextToClipboard.Text = "Copy &all text";
            this.menuItemCopyTextToClipboard.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Index = 1;
            this.menuItemPaste.Text = "Paste";
            this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 5;
            this.menuItem2.Text = "-";
            // 
            // menuItemClear
            // 
            this.menuItemClear.Index = 6;
            this.menuItemClear.Text = "Clea&r";
            this.menuItemClear.Click += new System.EventHandler(this.menuItemClear_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 2;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                         this.menuItemAbout});
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 0;
            this.menuItemAbout.Text = "&About";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text File (*.PEM; *.txt)|*.PEM;*.txt|Binary File (*.der;*.cer;*.bin;*.pfx)|*.der;" +
                "*.cer;*.bin;*.pfx";
            // 
            // toolBar
            // 
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                       this.toolBarButtonOpen,
                                                                                       this.toolBarButtonSaveAs,
                                                                                       this.toolBarButton4,
                                                                                       this.toolBarButtonCopyText,
                                                                                       this.toolBarButtonPaste,
                                                                                       this.toolBarButtonCut});
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.imageListToolBar;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(632, 28);
            this.toolBar.TabIndex = 11;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // toolBarButtonOpen
            // 
            this.toolBarButtonOpen.ImageIndex = 21;
            // 
            // toolBarButtonSaveAs
            // 
            this.toolBarButtonSaveAs.ImageIndex = 28;
            // 
            // toolBarButtonCopyText
            // 
            this.toolBarButtonCopyText.ImageIndex = 20;
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonPaste
            // 
            this.toolBarButtonPaste.ImageIndex = 31;
            // 
            // toolBarButtonCut
            // 
            this.toolBarButtonCut.ImageIndex = 18;
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Index = 0;
            this.menuItemCopy.Text = "&Copy";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemCut
            // 
            this.menuItemCut.Index = 2;
            this.menuItemCut.Text = "C&ut";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.Text = "-";
            // 
            // FormConvertData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 433);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.comboBoxFormat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonToPem);
            this.Controls.Add(this.buttonToHex);
            this.Controls.Add(this.buttonToBase64);
            this.Controls.Add(this.richTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "FormConvertData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Converter";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormConvertData_Closing);
            this.Load += new System.EventHandler(this.FormConvertData_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void buttonClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public byte[] ChangeDataFormat(DataFormat dataFormat)
        {
            byte[] data = null;
            string dataStr = richTextBox.Text;
            string msg = "";
            try
            {
                switch(currentFormat)
                {
                    case DataFormat.BASE64:
                        msg = "BASE64";
                        data = Convert.FromBase64String(dataStr);
                        break;
                    case DataFormat.HEX:
                        msg = "Hex";
                        data = Asn1Util.HexStrToBytes(dataStr);
                        break;
                    case DataFormat.PEM:
                        msg = "PEM";
                        data = Asn1Util.PemToBytes(dataStr);
                        break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid " + msg + " data: " + ex.Message);
                return data;
            }
            switch(dataFormat)
            {
                case DataFormat.BASE64:
                    dataStr = Convert.ToBase64String(data);
                    dataStr = Asn1Util.FormatString(dataStr, base64LineLen, 0);
                    break;
                case DataFormat.HEX:
                    dataStr = Asn1Util.ToHexString(data);
                    dataStr = Asn1Util.FormatString(dataStr, hexLineLen, 2);
                    break;
                case DataFormat.PEM:
                    dataStr = Asn1Util.BytesToPem(data);
                    break;
            }
            currentFormat = dataFormat;
            richTextBox.Text = dataStr;
            SetButtons();
            return data;
        }

        private void SetButtons()
        {
            switch(currentFormat)
            {
                case DataFormat.BASE64:
                    buttonToBase64.Enabled = false;
                    buttonToHex.Enabled = true;
                    buttonToPem.Enabled = true;
                    comboBoxFormat.SelectedIndex = (int) DataFormat.BASE64;
                    break;
                case DataFormat.HEX:
                    buttonToBase64.Enabled = true;
                    buttonToHex.Enabled = false;
                    buttonToPem.Enabled = true;
                    comboBoxFormat.SelectedIndex = (int) DataFormat.HEX;
                    break;
                case DataFormat.PEM:
                    buttonToBase64.Enabled = true;
                    buttonToHex.Enabled = true;
                    buttonToPem.Enabled = false;
                    comboBoxFormat.SelectedIndex = (int) DataFormat.PEM;
                    break;
            }
        }

        private void buttonToBase64_Click(object sender, System.EventArgs e)
        {
            ChangeDataFormat(DataFormat.BASE64);
        }

        private void buttonToHex_Click(object sender, System.EventArgs e)
        {
            ChangeDataFormat(DataFormat.HEX);                
        }

        private void buttonToPem_Click(object sender, System.EventArgs e)
        {
            ChangeDataFormat(DataFormat.PEM);        
        }

        private void FormConvertData_Load(object sender, System.EventArgs e)
        {
            richTextBox.Text = "";
            SetButtons();
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 2)
                {
                    byte[] data = ChangeDataFormat(currentFormat);
                    if (data!=null)
                    {
                        Stream fs = saveFileDialog.OpenFile();
                        fs.Write(data, 0, data.Length);
                        fs.Close();
                    }
                }
                else
                {
                    string dataStr = richTextBox.Text;
                    byte[] data = Asn1Util.StringToBytes(dataStr);
                    Stream fs = saveFileDialog.OpenFile();
                    fs.Write(data, 0, data.Length);
                    fs.Close();
                }
            }
        }

        private void comboBoxFormat_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            currentFormat = (DataFormat) comboBoxFormat.SelectedIndex;
            SetButtons();
        }

        private void menuItemOpen_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FilterIndex == 2)
                {
                    Stream stream = openFileDialog.OpenFile();
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                    stream.Close();
                    string hexStr = Asn1Util.ToHexString(data);
                    hexStr = Asn1Util.FormatString(hexStr, hexLineLen, 2);
                    richTextBox.Text = hexStr;
                    currentFormat = DataFormat.HEX;
                    SetButtons();
                }
                else
                {
                    Stream stream = openFileDialog.OpenFile();
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                    stream.Close();
                    string dataStr = Asn1Util.BytesToString(data);
                    richTextBox.Text = dataStr;
                }
            }        
        }

        private void FormConvertData_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void menuItemClear_Click(object sender, System.EventArgs e)
        {
            richTextBox.Text = "";
        }

        private void buttonCopy_Click(object sender, System.EventArgs e)
        {
            richTextBox.SelectAll();
            richTextBox.Copy();
            richTextBox.Focus();
        }

        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(this,
                "Usage:\r\n" +
                "   1. Open binary file or encoded text file.\r\n" +
                "   2. Click convert buttons to convert the data.\r\n" +
                "   3. Save the data as binary or text format.\r\n" +
                "   4. Instead open a file, copy and past text into edit panel then convert it.\r\n" +
                "\r\nThanks,\r\n" +
                "\r\nAuthor: Liping Dai\r\nJuly, 2003",
                "Data Converter");
        }

        private void menuItemPaste_Click(object sender, System.EventArgs e)
        {
            richTextBox.Paste();        
        }

        private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if (e.Button == toolBarButtonOpen)
            {
                menuItemOpen_Click(sender, e);
            }
            else if (e.Button == toolBarButtonSaveAs)
            {
                buttonSave_Click(sender, e);
            }
            else if (e.Button == toolBarButtonCopyText)
            {
                menuItemCopy_Click(sender, e);
            }
            else if (e.Button == toolBarButtonPaste)
            {
                menuItemPaste_Click(sender, e);
            }
            else if (e.Button == toolBarButtonCut)
            {
                menuItemCut_Click(sender, e);
            }
        }

        private void menuItemCut_Click(object sender, System.EventArgs e)
        {
            richTextBox.Cut();
        }

        private void menuItemCopy_Click(object sender, System.EventArgs e)
        {
            richTextBox.Copy();        
        }
	}

    public enum DataFormat
    {
        PEM,
        HEX,
        BASE64
    }
}
