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
//| THE SOFTWARE PRODUCT IS PROVIDED “AS IS” WITHOUT WARRANTY OF ANY KIND,        |
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

namespace LipingShare.Asn1Editor
{
	/// <summary>
	/// Summary description for HexViewer.
	/// </summary>
    public class HexViewer : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RichTextBox richTextBox;
        private System.ComponentModel.IContainer components;
        private Asn1Node rootNode;
        private Asn1Node selectedNode;
        private bool connected = false;
        public System.Windows.Forms.Form parentForm;
        public int pOldLeft, pOldWidth;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemView;
        private System.Windows.Forms.MenuItem menuItemCompact;
        private System.Windows.Forms.MenuItem menuItemDetial;

        public Color cNormal = Color.DarkGray;
        public Color cTag = Color.Red;
        public Color cLen = Color.Green;
        public Color cData = Color.Black;
        
        protected BinaryView bv = new BinaryView();
        ByteLocation loc = new ByteLocation();
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButtonQuick;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolBarButton toolBarButtonDetail;
        private System.Windows.Forms.ToolBarButton toolBarButtonExit;
        public const int compactWidth = 380;
        public const int detailWidth = 570;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItemBoldSelectedText;
        public const int fontSize = 9;

        public HexViewer()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        
        public void ResetWidth()
        {
            if (!menuItemDetial.Checked)
                this.Width = compactWidth;
            else
                this.Width = detailWidth;
        }
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HexViewer));
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemView = new System.Windows.Forms.MenuItem();
            this.menuItemDetial = new System.Windows.Forms.MenuItem();
            this.menuItemCompact = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemBoldSelectedText = new System.Windows.Forms.MenuItem();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButtonQuick = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonDetail = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonExit = new System.Windows.Forms.ToolBarButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.Location = new System.Drawing.Point(4, 32);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(524, 336);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "richTextBox";
            this.richTextBox.WordWrap = false;
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 373);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemView});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemExit});
            this.menuItemFile.Text = "&File";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 0;
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.Index = 1;
            this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemDetial,
            this.menuItemCompact,
            this.menuItem1,
            this.menuItemBoldSelectedText});
            this.menuItemView.Text = "&View";
            // 
            // menuItemDetial
            // 
            this.menuItemDetial.Checked = true;
            this.menuItemDetial.Index = 0;
            this.menuItemDetial.Text = "&Detail";
            this.menuItemDetial.Click += new System.EventHandler(this.menuItemDetial_Click);
            // 
            // menuItemCompact
            // 
            this.menuItemCompact.Index = 1;
            this.menuItemCompact.Text = "&Quick";
            this.menuItemCompact.Click += new System.EventHandler(this.menuItemCompact_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "-";
            // 
            // menuItemBoldSelectedText
            // 
            this.menuItemBoldSelectedText.Checked = true;
            this.menuItemBoldSelectedText.Index = 3;
            this.menuItemBoldSelectedText.Text = "Bold Selected Text";
            this.menuItemBoldSelectedText.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButtonQuick,
            this.toolBarButtonDetail,
            this.toolBarButton1,
            this.toolBarButtonExit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(532, 28);
            this.toolBar1.TabIndex = 4;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButtonQuick
            // 
            this.toolBarButtonQuick.ImageIndex = 0;
            this.toolBarButtonQuick.Name = "toolBarButtonQuick";
            this.toolBarButtonQuick.ToolTipText = "Quick View";
            // 
            // toolBarButtonDetail
            // 
            this.toolBarButtonDetail.ImageIndex = 1;
            this.toolBarButtonDetail.Name = "toolBarButtonDetail";
            this.toolBarButtonDetail.ToolTipText = "Detali View";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonExit
            // 
            this.toolBarButtonExit.ImageIndex = 2;
            this.toolBarButtonExit.Name = "toolBarButtonExit";
            this.toolBarButtonExit.ToolTipText = "Exit";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            // 
            // HexViewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(532, 373);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "HexViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Hex Viewer";
            this.Load += new System.EventHandler(this.HexViewer_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.HexViewer_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        
        }

        public bool Connected
        {
            get
            {
                return connected;
            }
            set
            {
                connected = value;
            }
        }

        private void HexViewer_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            parentForm.Left = this.pOldLeft;
            parentForm.Width = this.pOldWidth;
        }

        private void richTextBox_TextChanged(object sender, System.EventArgs e)
        {
        
        }

        private void SetParentForm()
        {
            parentForm.Left = this.Left + this.Width;
            parentForm.Width = pOldWidth;
            System.Drawing.Rectangle rect =
                System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            if ((parentForm.Left + parentForm.Width) > rect.Left + rect.Width)
            {
                parentForm.Width = rect.Width - parentForm.Left;
                if (parentForm.Width < 400) parentForm.Width = 450;
            }
        }

        private void SetButtons()
        {
            menuItemDetial.Enabled = !menuItemDetial.Checked;
            menuItemCompact.Enabled = !menuItemCompact.Checked;
            toolBarButtonQuick.Enabled = menuItemCompact.Enabled;
            toolBarButtonDetail.Enabled = menuItemDetial.Enabled;
        }

        private void menuItemDetial_Click(object sender, System.EventArgs e)
        {
            menuItemDetial.Checked = true;
            menuItemCompact.Checked = false;
            RefreshView();
        }

        private void menuItemCompact_Click(object sender, System.EventArgs e)
        {
            menuItemCompact.Checked = true;
            menuItemDetial.Checked = false;
            RefreshView();
        }

        private void RefreshView()
        {
            SetButtons();
            if (menuItemCompact.Checked)
                this.Width = compactWidth;
            else
                this.Width = detailWidth;
            SetParentForm();
            try
            {
                richTextBox.Visible = false;
                RootNode = rootNode;
                richTextBox.Visible = false;
                SelectedNode = selectedNode;
            }
            finally
            {
                richTextBox.Visible = true;
            }
        }

        public Asn1Node RootNode
        {
            get
            {
                return rootNode;
            }
            set
            {
                rootNode = value;
                if (rootNode == null)
                {
                    richTextBox.Text = "";
                    return;
                }
                MemoryStream ms = new MemoryStream();
                rootNode.SaveData(ms);
                ms.Position = 0;
                Byte[] data = new byte[ms.Length];
                ms.Read(data, 0, data.Length);
                ms.Close();
                string hexStr = "";
                if (menuItemCompact.Checked)
                {
                    hexStr = Asn1Util.FormatString(Asn1Util.ToHexString(data), 32, 2);
                }
                else
                {
                    hexStr = bv.GenerateText(data);
                }
                richTextBox.Text = hexStr;
            }
        }

        public Asn1Node SelectedNode
        {
            get
            {
                return selectedNode;
            }
            set
            {
                selectedNode = value;
                if (selectedNode == null) return;
                if ((!connected) || (!this.Visible)) return;
                int offset = (int)selectedNode.DataOffset;
                richTextBox.Select(0, richTextBox.TextLength);
                richTextBox.SelectionColor = this.cNormal;
                richTextBox.SelectionFont = new Font("Courier New", fontSize, FontStyle.Regular);

                if (menuItemCompact.Checked)
                {
                    int tagOff = offset*3;
                    tagOff += tagOff/48;
                    SetColor(tagOff, 2, this.cTag);

                    int lenOff = tagOff + 3;
                    int lenLen = (int) selectedNode.LengthFieldBytes * 3;
                    SetColor(lenOff, lenLen, this.cLen);

                    int dataOff = lenOff + lenLen;
                    int dataLen = (int) selectedNode.DataLength * 3;
                    dataLen += dataLen / 48;
                    SetColor(dataOff, dataLen, this.cData);
                    richTextBox.Select(richTextBox.Text.Length, 0);
                    richTextBox.Select(tagOff,0);
                }
                else
                {
                    int tagOff = offset;
                    int lenOff = tagOff + 1;
                    int dataOff = lenOff + (int)selectedNode.LengthFieldBytes;
                    SetBytesColor(this.cTag, tagOff, 1);
                    SetBytesColor(this.cLen, lenOff, (int)selectedNode.LengthFieldBytes);
                    try
                    {
                        if (selectedNode.DataLength > 300)
                        {
                            richTextBox.Visible = false;
                        }
                        if (selectedNode.Tag == Asn1Tag.BIT_STRING)
                            SetBytesColor(this.cData, dataOff, (int)selectedNode.DataLength);
                        else
                            SetBytesColor(this.cData, dataOff, (int)selectedNode.DataLength);
                    }
                    finally
                    {
                        richTextBox.Visible = true;
                    }
                    richTextBox.Select(richTextBox.Text.Length, 0);
                    bv.GetLocation(offset, loc);
                    richTextBox.Select(loc.hexOffset, 0);
                }
                richTextBox.Focus();
            }
        }

        public new void Show()
        {
            this.Visible = true;
            this.SelectedNode = selectedNode;
        }

        protected void SetBytesColor(Color color, int start, int len)
        {
            if (len == 0) return;
            int line = -1, hstart = 0, hend = 0, cstart = 0, cend = 0;
            for (int i=0; i<len; i++)
            {
                bv.GetLocation(start+i, loc);
                if (line != loc.line)
                {
                    if (hstart != hend)
                    {
                        SetColor(hstart, hend, cstart, cend, color);
                    }
                    line = loc.line;
                    hstart = loc.hexOffset;
                    cstart = loc.chOffset;
                    hend = loc.hexOffset + loc.hexColLen;
                    cend = loc.chOffset + loc.chColLen;
                }
                else
                {
                    hend = loc.hexOffset + loc.hexColLen;
                    cend = loc.chOffset + loc.chColLen;
                }
            }
            SetColor(hstart, hend, cstart, cend, color);
        }

        protected void SetColor(int start, int len, Color color)
        {
            richTextBox.Select(start, len);
            richTextBox.SelectionColor  = color;
            if (menuItemBoldSelectedText.Checked)
                richTextBox.SelectionFont = new Font("Courier New", fontSize, FontStyle.Bold);
        }

        private void SetColor(int hstart, int hend, int cstart, int cend, Color color)
        {
            richTextBox.Select(hstart, hend - hstart);
            richTextBox.SelectionColor = color;
            if (menuItemBoldSelectedText.Checked)
                richTextBox.SelectionFont = new Font("Courier New", fontSize, FontStyle.Bold);
            richTextBox.Select(cstart, cend - cstart);
            richTextBox.SelectionColor = color;
            if (menuItemBoldSelectedText.Checked)
                richTextBox.SelectionFont = new Font("Courier New", fontSize, FontStyle.Bold);
        }

        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void HexViewer_Load(object sender, System.EventArgs e)
        {
            // The following two parameters has been set by the caller.
            // It is for display correctly at first time.
            this.Top = parentForm.Top; 
            this.Height = parentForm.Height;

            SetButtons();       
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if (e.Button == toolBarButtonQuick)
            {
                menuItemCompact_Click(sender, e);
            }
            else if (e.Button == toolBarButtonDetail)
            {
                menuItemDetial_Click(sender, e);
            }
            else if (e.Button == toolBarButtonExit)
            {
                menuItemExit_Click(sender, e);
            }
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            menuItemBoldSelectedText.Checked = !menuItemBoldSelectedText.Checked;
            SelectedNode = selectedNode;
        }

        public void ResizeForm(int top, int left, int right, int bottom)
        {
            this.Top = top;
            this.Height = bottom - top;
        }

	}

    public enum DisplayStatus
    {
        quick,
        detail
    }
}
