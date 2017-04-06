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
using LipingShare.LCLib.Asn1Processor;

namespace LipingShare.Asn1Editor
{
	/// <summary>
	/// Summary description for FormViewNodeText.
	/// </summary>
	public class FormViewText : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.RichTextBox richTextBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private Asn1Node node = null;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxLineWidth;
        private System.Windows.Forms.Button buttonApply;
        private int lineLen = 80;
        
        public Configuration config = null;

		public FormViewText()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormViewText));
            this.buttonClose = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLineWidth = new System.Windows.Forms.TextBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(696, 521);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 25);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "&Close";
            this.buttonClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.Location = new System.Drawing.Point(5, 4);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(783, 512);
            this.richTextBox.TabIndex = 3;
            this.richTextBox.Text = "richTextBox1";
            this.richTextBox.WordWrap = false;
            this.richTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(5, 529);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Line Width (characters):";
            // 
            // textBoxLineWidth
            // 
            this.textBoxLineWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxLineWidth.Location = new System.Drawing.Point(182, 525);
            this.textBoxLineWidth.Name = "textBoxLineWidth";
            this.textBoxLineWidth.Size = new System.Drawing.Size(149, 21);
            this.textBoxLineWidth.TabIndex = 5;
            this.textBoxLineWidth.Text = "textBoxLineWidth";
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonApply.Location = new System.Drawing.Point(336, 520);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(77, 26);
            this.buttonApply.TabIndex = 6;
            this.buttonApply.Text = "Apply";
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // FormViewText
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(792, 560);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.textBoxLineWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.buttonClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormViewText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Text Viewer";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormViewText_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public void SetText(Asn1Node node, int lineLen)
        {
            this.node = node;
            this.lineLen = lineLen;
            textBoxLineWidth.Text = lineLen.ToString();
            string text = Asn1Parser.GetNodeText(node, lineLen);
            richTextBox.Text = text;
        }

        private void richTextBox_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.LinkText);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to open the URL:\r\n" + e.LinkText + ".\r\n" + ex.Message + ".");
            }
        }

        private void buttonApply_Click(object sender, System.EventArgs e)
        {
            ResizeText();
            if (config != null)
            {
                config.textViewerTop    = this.Top;
                config.textViewerLeft   = this.Left;
                config.textViewerWidth  = this.Width;
                config.textViewerHeight = this.Height;
                config.textLength  = Convert.ToInt32(textBoxLineWidth.Text);
            }
        }

        public void ResizeText()
        {
            try
            {
                this.lineLen = Convert.ToInt32(this.textBoxLineWidth.Text);
                if (lineLen <Asn1Node.minLineLen)
                {
                    lineLen = Asn1Node.minLineLen;
                    textBoxLineWidth.Text = lineLen.ToString();
                }
                string text = Asn1Parser.GetNodeText(node, lineLen);
                richTextBox.Text = text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormViewText_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (config != null)
            {
                config.textViewerTop    = this.Top;
                config.textViewerLeft   = this.Left;
                config.textViewerWidth  = this.Width;
                config.textViewerHeight = this.Height;
                config.textLength  = Convert.ToInt32(textBoxLineWidth.Text);
            }
            this.Visible = false;
            e.Cancel = true;
        }
	}
}
