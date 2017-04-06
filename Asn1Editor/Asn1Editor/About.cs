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

namespace LipingShare.Asn1Editor
{
	/// <summary>
	/// Summary description for About.
	/// </summary>
	public class About : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.TabPage tabPageCopyright;
        private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.RichTextBox richTextBox2;
		public System.Windows.Forms.RichTextBox richTextBoxAbout;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public About()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.richTextBoxAbout = new System.Windows.Forms.RichTextBox();
            this.tabPageCopyright = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            this.tabPageCopyright.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageAbout);
            this.tabControl1.Controls.Add(this.tabPageCopyright);
            this.tabControl1.Location = new System.Drawing.Point(4, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(500, 329);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageAbout.Controls.Add(this.richTextBoxAbout);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 22);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Size = new System.Drawing.Size(492, 303);
            this.tabPageAbout.TabIndex = 0;
            this.tabPageAbout.Text = "About";
            // 
            // richTextBoxAbout
            // 
            this.richTextBoxAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAbout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxAbout.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxAbout.Location = new System.Drawing.Point(4, 3);
            this.richTextBoxAbout.Name = "richTextBoxAbout";
            this.richTextBoxAbout.ReadOnly = true;
            this.richTextBoxAbout.Size = new System.Drawing.Size(482, 293);
            this.richTextBoxAbout.TabIndex = 1;
            this.richTextBoxAbout.Text = resources.GetString("richTextBoxAbout.Text");
            this.richTextBoxAbout.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox2_LinkClicked);
            // 
            // tabPageCopyright
            // 
            this.tabPageCopyright.Controls.Add(this.richTextBox2);
            this.tabPageCopyright.Location = new System.Drawing.Point(4, 22);
            this.tabPageCopyright.Name = "tabPageCopyright";
            this.tabPageCopyright.Size = new System.Drawing.Size(593, 333);
            this.tabPageCopyright.TabIndex = 1;
            this.tabPageCopyright.Text = "Copyright Info.";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.CausesValidation = false;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(4, 6);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(583, 320);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = resources.GetString("richTextBox2.Text");
            this.richTextBox2.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox2_LinkClicked);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(414, 342);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(90, 24);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "&Close";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // About
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(505, 387);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About ASN.1 Editor";
            this.tabControl1.ResumeLayout(false);
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageCopyright.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void richTextBox2_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
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
	}
}
