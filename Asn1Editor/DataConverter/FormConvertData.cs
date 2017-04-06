//+-------------------------------------------------------------------------------+
//| Copyright (c) 2003 Liping Dai. All rights reserved.                           |
//| Web: www.lipingshare.com                                                      |
//| Email: lipingshare@yahoo.com                                                  |
//|                                                                               |
//| Copyright and Permission Details:                                             |
//| =================================                                             |
//| Permission is hereby granted, free of charge, to any person obtaining a copy  |
//| of this software and associated documentation files (the "Software"), to deal |
//| in the Software without restriction, including without limitation the rights  |
//| to use, copy, modify, merge, publish, distribute, and/or sell copies of the   |
//| Software, subject to the following conditions:                                |
//|                                                                               |
//| 1. Redistributions of source code must retain the above copyright notice, this|
//| list of conditions and the following disclaimer.                              |
//|                                                                               |
//| 2. Redistributions in binary form must reproduce the above copyright notice,  |
//| this list of conditions and the following disclaimer in the documentation     |
//| and/or other materials provided with the distribution.                        |
//|                                                                               |
//| THE SOFTWARE PRODUCT IS PROVIDED “AS IS?WITHOUT WARRANTY OF ANY KIND,        |
//| EITHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED         |
//| WARRANTIES OF TITLE, NON-INFRINGEMENT, MERCHANTABILITY AND FITNESS FOR        |
//| A PARTICULAR PURPOSE.                                                         |
//+-------------------------------------------------------------------------------+

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using LipingShare.LCLib.Asn1Processor;

namespace LipingShare.DataConverter
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
        private System.Windows.Forms.StatusBarPanel statusBarPanelFileName;
        public const int base64LineLen = 64;
        public string currentFileName = "";
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel statusBarPanelFileSize;
        private System.Windows.Forms.StatusBarPanel statusBarPanelLines;
        private System.Windows.Forms.StatusBarPanel statusBarPanelCurrentLine;
        private System.Windows.Forms.StatusBarPanel statusBarPanelCurrentColumn;
        private System.Windows.Forms.ToolBarButton toolBarButtonUndo;
        private System.Windows.Forms.MenuItem menuItemUndo;
        public long currentFileSize = 0;
        public string pemHeader = "";
        private string dataStr = "";
        private string baseFormHeader = "Data Converter";

        [STAThread]
        static void Main(string[] args) 
        {
            FormConvertData dc = new FormConvertData();
            if (args.Length > 0)
            {
                dc.currentFileName = args[0];
            }
            Application.Run(dc);
        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConvertData));
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.buttonToBase64 = new System.Windows.Forms.Button();
            this.buttonToHex = new System.Windows.Forms.Button();
            this.buttonToPem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.imageListToolBar = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemCopy = new System.Windows.Forms.MenuItem();
            this.menuItemPaste = new System.Windows.Forms.MenuItem();
            this.menuItemCut = new System.Windows.Forms.MenuItem();
            this.menuItemUndo = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemCopyTextToClipboard = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemClear = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.toolBarButtonOpen = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonSaveAs = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonCopyText = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonPaste = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonCut = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonUndo = new System.Windows.Forms.ToolBarButton();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanelFileName = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelFileSize = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelLines = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelCurrentLine = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelCurrentColumn = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelFileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelCurrentLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelCurrentColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.Location = new System.Drawing.Point(4, 74);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(512, 332);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "richTextBox";
            this.richTextBox.WordWrap = false;
            this.richTextBox.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
            // 
            // buttonToBase64
            // 
            this.buttonToBase64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToBase64.Location = new System.Drawing.Point(526, 123);
            this.buttonToBase64.Name = "buttonToBase64";
            this.buttonToBase64.Size = new System.Drawing.Size(100, 29);
            this.buttonToBase64.TabIndex = 3;
            this.buttonToBase64.Text = "To &BASE64";
            this.buttonToBase64.Click += new System.EventHandler(this.buttonToBase64_Click);
            // 
            // buttonToHex
            // 
            this.buttonToHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToHex.Location = new System.Drawing.Point(526, 81);
            this.buttonToHex.Name = "buttonToHex";
            this.buttonToHex.Size = new System.Drawing.Size(100, 29);
            this.buttonToHex.TabIndex = 4;
            this.buttonToHex.Text = "To &HEX";
            this.buttonToHex.Click += new System.EventHandler(this.buttonToHex_Click);
            // 
            // buttonToPem
            // 
            this.buttonToPem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToPem.Location = new System.Drawing.Point(526, 39);
            this.buttonToPem.Name = "buttonToPem";
            this.buttonToPem.Size = new System.Drawing.Size(100, 29);
            this.buttonToPem.TabIndex = 5;
            this.buttonToPem.Text = "To &PEM";
            this.buttonToPem.Click += new System.EventHandler(this.buttonToPem_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Current Data Format:";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Text File (*.PEM; *.txt)|*.PEM;*.txt|Binary File (*.der;*.cer;*.bin;*.pfx)|*.der;" +
                "*.cer;*.bin;*.pfx|All (*.*)|*.*";
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
            this.comboBoxFormat.Location = new System.Drawing.Point(155, 39);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(360, 20);
            this.comboBoxFormat.TabIndex = 10;
            this.comboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormat_SelectedIndexChanged);
            // 
            // imageListToolBar
            // 
            this.imageListToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolBar.ImageStream")));
            this.imageListToolBar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListToolBar.Images.SetKeyName(0, "");
            this.imageListToolBar.Images.SetKeyName(1, "");
            this.imageListToolBar.Images.SetKeyName(2, "");
            this.imageListToolBar.Images.SetKeyName(3, "");
            this.imageListToolBar.Images.SetKeyName(4, "");
            this.imageListToolBar.Images.SetKeyName(5, "");
            this.imageListToolBar.Images.SetKeyName(6, "");
            this.imageListToolBar.Images.SetKeyName(7, "");
            this.imageListToolBar.Images.SetKeyName(8, "");
            this.imageListToolBar.Images.SetKeyName(9, "");
            this.imageListToolBar.Images.SetKeyName(10, "");
            this.imageListToolBar.Images.SetKeyName(11, "");
            this.imageListToolBar.Images.SetKeyName(12, "");
            this.imageListToolBar.Images.SetKeyName(13, "");
            this.imageListToolBar.Images.SetKeyName(14, "");
            this.imageListToolBar.Images.SetKeyName(15, "");
            this.imageListToolBar.Images.SetKeyName(16, "");
            this.imageListToolBar.Images.SetKeyName(17, "");
            this.imageListToolBar.Images.SetKeyName(18, "");
            this.imageListToolBar.Images.SetKeyName(19, "");
            this.imageListToolBar.Images.SetKeyName(20, "");
            this.imageListToolBar.Images.SetKeyName(21, "");
            this.imageListToolBar.Images.SetKeyName(22, "");
            this.imageListToolBar.Images.SetKeyName(23, "");
            this.imageListToolBar.Images.SetKeyName(24, "");
            this.imageListToolBar.Images.SetKeyName(25, "");
            this.imageListToolBar.Images.SetKeyName(26, "");
            this.imageListToolBar.Images.SetKeyName(27, "");
            this.imageListToolBar.Images.SetKeyName(28, "");
            this.imageListToolBar.Images.SetKeyName(29, "");
            this.imageListToolBar.Images.SetKeyName(30, "");
            this.imageListToolBar.Images.SetKeyName(31, "");
            this.imageListToolBar.Images.SetKeyName(32, "");
            this.imageListToolBar.Images.SetKeyName(33, "");
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
            this.menuItemUndo,
            this.menuItem3,
            this.menuItemCopyTextToClipboard,
            this.menuItem2,
            this.menuItemClear});
            this.menuItemEdit.Text = "&Edit";
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Index = 0;
            this.menuItemCopy.Text = "&Copy";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Index = 1;
            this.menuItemPaste.Text = "Paste";
            this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // menuItemCut
            // 
            this.menuItemCut.Index = 2;
            this.menuItemCut.Text = "C&ut";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // menuItemUndo
            // 
            this.menuItemUndo.Index = 3;
            this.menuItemUndo.Text = "&Undo";
            this.menuItemUndo.Visible = false;
            this.menuItemUndo.Click += new System.EventHandler(this.menuItemUndo_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.Text = "-";
            // 
            // menuItemCopyTextToClipboard
            // 
            this.menuItemCopyTextToClipboard.Index = 5;
            this.menuItemCopyTextToClipboard.Text = "Copy &all text";
            this.menuItemCopyTextToClipboard.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 6;
            this.menuItem2.Text = "-";
            // 
            // menuItemClear
            // 
            this.menuItemClear.Index = 7;
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
                "*.cer;*.bin;*.pfx|All (*.*)|*.*";
            // 
            // toolBar
            // 
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButtonOpen,
            this.toolBarButtonSaveAs,
            this.toolBarButton4,
            this.toolBarButtonCopyText,
            this.toolBarButtonPaste,
            this.toolBarButtonCut,
            this.toolBarButtonUndo});
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
            this.toolBarButtonOpen.Name = "toolBarButtonOpen";
            this.toolBarButtonOpen.ToolTipText = "Open";
            // 
            // toolBarButtonSaveAs
            // 
            this.toolBarButtonSaveAs.ImageIndex = 33;
            this.toolBarButtonSaveAs.Name = "toolBarButtonSaveAs";
            this.toolBarButtonSaveAs.ToolTipText = "Save as";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonCopyText
            // 
            this.toolBarButtonCopyText.ImageIndex = 20;
            this.toolBarButtonCopyText.Name = "toolBarButtonCopyText";
            this.toolBarButtonCopyText.ToolTipText = "Copy";
            // 
            // toolBarButtonPaste
            // 
            this.toolBarButtonPaste.ImageIndex = 31;
            this.toolBarButtonPaste.Name = "toolBarButtonPaste";
            this.toolBarButtonPaste.ToolTipText = "Paste";
            // 
            // toolBarButtonCut
            // 
            this.toolBarButtonCut.ImageIndex = 18;
            this.toolBarButtonCut.Name = "toolBarButtonCut";
            this.toolBarButtonCut.ToolTipText = "Cut";
            // 
            // toolBarButtonUndo
            // 
            this.toolBarButtonUndo.ImageIndex = 32;
            this.toolBarButtonUndo.Name = "toolBarButtonUndo";
            this.toolBarButtonUndo.ToolTipText = "Undo";
            this.toolBarButtonUndo.Visible = false;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 410);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanelFileName,
            this.statusBarPanelFileSize,
            this.statusBarPanelLines,
            this.statusBarPanelCurrentLine,
            this.statusBarPanelCurrentColumn});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(632, 23);
            this.statusBar.TabIndex = 12;
            this.statusBar.Text = "statusBar";
            // 
            // statusBarPanelFileName
            // 
            this.statusBarPanelFileName.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanelFileName.Name = "statusBarPanelFileName";
            this.statusBarPanelFileName.Text = "File Name:";
            this.statusBarPanelFileName.Width = 415;
            // 
            // statusBarPanelFileSize
            // 
            this.statusBarPanelFileSize.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelFileSize.Name = "statusBarPanelFileSize";
            this.statusBarPanelFileSize.Text = "File Size:";
            this.statusBarPanelFileSize.Width = 76;
            // 
            // statusBarPanelLines
            // 
            this.statusBarPanelLines.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelLines.Name = "statusBarPanelLines";
            this.statusBarPanelLines.Text = "Lines:";
            this.statusBarPanelLines.Width = 52;
            // 
            // statusBarPanelCurrentLine
            // 
            this.statusBarPanelCurrentLine.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelCurrentLine.Name = "statusBarPanelCurrentLine";
            this.statusBarPanelCurrentLine.Text = "Ln:";
            this.statusBarPanelCurrentLine.Width = 33;
            // 
            // statusBarPanelCurrentColumn
            // 
            this.statusBarPanelCurrentColumn.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.statusBarPanelCurrentColumn.Name = "statusBarPanelCurrentColumn";
            this.statusBarPanelCurrentColumn.Text = "Col:";
            this.statusBarPanelCurrentColumn.Width = 39;
            // 
            // FormConvertData
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(632, 433);
            this.Controls.Add(this.statusBar);
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
            this.Load += new System.EventHandler(this.FormConvertData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelFileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelCurrentLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelCurrentColumn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

        private void buttonClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public byte[] ChangeDataFormat(DataFormat dataFormat)
        {
            byte[] data = null;
            dataStr = richTextBox.Text;
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
                        pemHeader = Asn1Util.GetPemHeader(dataStr);
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
                    dataStr = Asn1Util.BytesToPem(data, pemHeader);
                    break;
            }
            currentFormat = dataFormat;
            richTextBox.Text = dataStr;
            SetButtons();
            richTextBox.Focus();
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
            ShowFileName();
            if (currentFileName.Length > 0)
            {
                try
                {
                    openFileDialog.FileName = currentFileName;
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(currentFileName);
                    string ext = System.IO.Path.GetExtension(currentFileName).ToUpper();
                    if (ext == ".PEM" || ext == ".TXT")
                    {
                        openFileDialog.FilterIndex = 1;
                    }
                    else
                    {
                        openFileDialog.FilterIndex = 2;
                    }
                    OpenFile();
                }
                catch
                {
                    currentFileName = "";
                    ShowFileName();
                }
            }
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
                        currentFileName = saveFileDialog.FileName;
                        currentFileSize = fs.Length;
                        fs.Close();
                    }
                }
                else
                {
                    ChangeDataFormat(DataFormat.PEM);
                    byte[] data = Asn1Util.StringToBytes(dataStr);
                    Stream fs = saveFileDialog.OpenFile();
                    fs.Write(data, 0, data.Length);
                    currentFileName = saveFileDialog.FileName;
                    currentFileSize = fs.Length;
                    fs.Close();
                }

                openFileDialog.FilterIndex      = saveFileDialog.FilterIndex;
                openFileDialog.FileName         = saveFileDialog.FileName;
                openFileDialog.InitialDirectory = saveFileDialog.InitialDirectory;
                ShowFileName();

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
                OpenFile();
            }
        }

        private void OpenBinaryFile()
        {
            Stream stream = openFileDialog.OpenFile();
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            currentFileName = openFileDialog.FileName;
            currentFileSize = stream.Length;
            stream.Close();
            string hexStr = Asn1Util.ToHexString(data);
            hexStr = Asn1Util.FormatString(hexStr, hexLineLen, 2);
            richTextBox.Text = hexStr;
            currentFormat = DataFormat.HEX;
            SetButtons();
            ShowFileName();
        }

        private void OpenPemFile()
        {
            Stream stream = openFileDialog.OpenFile();
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            currentFileName = openFileDialog.FileName;
            currentFileSize = stream.Length;
            stream.Close();
            string dataStr = Asn1Util.BytesToString(data);
            if (Asn1Util.IsPemFormated(dataStr))
            {
                currentFormat = DataFormat.PEM;
                pemHeader = Asn1Util.GetPemHeader(dataStr);
            }
            else if (Asn1Util.IsHexStr(dataStr))
            {
                currentFormat = DataFormat.HEX;
            }
            else
            {
                currentFormat = DataFormat.BASE64;
            }
            richTextBox.Text = dataStr;
            SetButtons();
            currentFileName = openFileDialog.FileName;
            ShowFileName();
        }

        private void OpenFile()
        {
            pemHeader = System.IO.Path.GetFileName(openFileDialog.FileName).Replace("-", "");
            if (openFileDialog.FilterIndex == 2) // Binary file
            {
                OpenBinaryFile();
            }
            else if (openFileDialog.FilterIndex == 1) // PEM File
            {
                OpenPemFile();
            }
            else
            {
                if (Asn1Util.IsPemFormatedFile(openFileDialog.FileName))
                {
                    OpenPemFile();
                    openFileDialog.FilterIndex = 1;
                }
                else
                {
                    OpenBinaryFile();
                    openFileDialog.FilterIndex = 2;
                }
            }
            saveFileDialog.FilterIndex = openFileDialog.FilterIndex;
            saveFileDialog.FileName = openFileDialog.FileName;
            saveFileDialog.InitialDirectory = openFileDialog.InitialDirectory;
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
            else if (e.Button == toolBarButtonUndo)
            {
                menuItemUndo_Click(sender, e);
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

        public void ShowFileName()
        {
            statusBarPanelFileName.Text = "File Name: " + currentFileName;
            statusBarPanelFileName.ToolTipText = statusBarPanelFileName.Text;
            statusBarPanelFileSize.Text = "File Size: " + currentFileSize.ToString() + " (byte)";
            if (currentFileName.Length > 0)
            {
                this.Text = baseFormHeader + " -- Opening File: " + 
                    System.IO.Path.GetFileName(currentFileName);
            }
            else
            {
                this.Text = baseFormHeader;
            }
            ShowCursorPar();
        }

        public void ShowCursorPar()
        {
            int currentLine = 0;
            int currentColumn = 0;
            GetCurrentPos(richTextBox, ref currentLine, ref currentColumn);  
            statusBarPanelLines.Text = "TotLn:" + richTextBox.Lines.Length.ToString();
            statusBarPanelCurrentLine.Text = "Ln:" + currentLine.ToString();
            statusBarPanelCurrentColumn.Text = "Col:" + currentColumn.ToString();
        }

        private void richTextBox_SelectionChanged(object sender, System.EventArgs e)
        {
            ShowCursorPar();        
        }

        public static void GetCurrentPos(RichTextBox rtfMain, ref int line, ref int col)
        {
            Point pt;
            int index;
            index = rtfMain.SelectionStart;
            line = rtfMain.GetLineFromCharIndex(index);
            pt = rtfMain.GetPositionFromCharIndex(index);
            pt.X = 0;
            col = index - rtfMain.GetCharIndexFromPosition(pt);
            line ++;
            col ++;
            return;
        }

        private void menuItemUndo_Click(object sender, System.EventArgs e)
        {
            richTextBox.Undo();
        }

        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show(this,
                "Usage:\r\n" +
                "   1. Open binary file or encoded text file.\r\n" +
                "   2. Click convert buttons to convert the data.\r\n" +
                "   3. Save the data as binary or text format.\r\n" +
                "   4. Instead open a file, copy and past text into edit panel, select the current data format then convert it.\r\n" +
                "   5. Give a file name as command line parameter.\r\n" +
                "\r\nThanks,\r\n" +
                "\r\nAuthor: " + VersionInfo.Author +
                "\r\n" + VersionInfo.ReleaseDate,
                "Data Converter - " + VersionInfo.VersionStr);
        }

    
    }

    public enum DataFormat
    {
        PEM,
        HEX,
        BASE64
    }

}
