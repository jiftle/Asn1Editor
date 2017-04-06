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
using System.Text;
using LipingShare.LCLib.Asn1Processor;

namespace LipingShare.Asn1Editor
{
	/// <summary>
	/// Summary description for FormNodeContentEditor.
	/// </summary>
	

    public class FormNodeContentEditor : System.Windows.Forms.Form
	{
        public enum DataChecker
        {
            Hex,
            Oid,
            Roid,
            None
        };

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxNodeContent;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public bool isOK = false;
		private System.Windows.Forms.TextBox textBox1;
        public Asn1Node aNode = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTag;
        private System.Windows.Forms.TextBox textBoxTag;
        public DataChecker checker = DataChecker.None;
        public bool enableTagEdit = false;
        private System.Windows.Forms.Panel panelUnusedBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUnusedBits;
        public bool pureHexMode = false;

        static public bool EditNode(IWin32Window parent, Asn1Node aNode, bool enableTagEdit, bool pureHexMode)
        {
            byte[] val;        
            byte[] data;
            FormNodeContentEditor ed = new FormNodeContentEditor();
            ed.aNode = aNode;
            MemoryStream ms = new MemoryStream();
            ed.checker = FormNodeContentEditor.DataChecker.None;
            ed.enableTagEdit = enableTagEdit;
            ed.pureHexMode = pureHexMode;
            if (
                ((aNode.Tag&Asn1Tag.TAG_MASK) == Asn1Tag.BIT_STRING) && 
                (aNode.ChildNodeCount<1))
            {
                ed.panelUnusedBits.Visible = true;
                ed.textBoxUnusedBits.Text = aNode.UnusedBits.ToString();
            }
            else
            {
                ed.panelUnusedBits.Visible = false;
            }
            if (pureHexMode)
            {
                ed.checker = DataChecker.Hex;
                ed.ShowDialog(parent);
                if (!ed.isOK) return false;
                data = Asn1Util.HexStrToBytes(ed.GetValueStr());
                aNode.Data = data;
            }
            else
            {
                byte[] oidVal;
                switch (aNode.Tag)
                {
                    case Asn1Tag.OBJECT_IDENTIFIER:
                        ed.checker = DataChecker.Oid;
                        ed.ShowDialog(parent);
                        if (!ed.isOK) return false;
                        Oid xoid = new Oid();
                        xoid.Encode(ms, ed.GetValueStr());
                        ms.Position = 0;				
                        oidVal = new byte[ms.Length];
                        ms.Read(oidVal, 0, (int)ms.Length);
                        ms.Close();
                        aNode.Data = oidVal;
                        break;
                    case Asn1Tag.RELATIVE_OID:
                        ed.checker = DataChecker.Roid;
                        ed.ShowDialog(parent);
                        if (!ed.isOK) return false;
                        RelativeOid roid = new RelativeOid();
                        roid.Encode(ms, ed.GetValueStr());
                        ms.Position = 0;				
                        oidVal = new byte[ms.Length];
                        ms.Read(oidVal, 0, (int)ms.Length);
                        ms.Close();
                        aNode.Data = oidVal;
                        break;
                    case Asn1Tag.PRINTABLE_STRING:
                    case Asn1Tag.IA5_STRING:
                    case Asn1Tag.UNIVERSAL_STRING:
                    case Asn1Tag.VISIBLE_STRING:
                    case Asn1Tag.NUMERIC_STRING:
                    case Asn1Tag.UTC_TIME:
					case Asn1Tag.GENERAL_STRING:
                    case Asn1Tag.GENERALIZED_TIME:
                        ed.ShowDialog(parent);
                        if (!ed.isOK) return false;
                        val = Asn1Util.StringToBytes(ed.GetValueStr());
                        aNode.Data = val;
                        break;
					case Asn1Tag.UTF8_STRING:
						ed.ShowDialog(parent);
						if (!ed.isOK) return false;
						UTF8Encoding u8 = new UTF8Encoding(false);
						val = u8.GetBytes(ed.GetValueStr());
						aNode.Data = val;
						break;
					case Asn1Tag.BMPSTRING:
						ed.ShowDialog(parent);
						if (!ed.isOK) return false;
                        //byte[] tmpval = Asn1Util.StringToBytes(ed.GetValueStr());
                        byte[] tmpval = Encoding.BigEndianUnicode.GetBytes(ed.GetValueStr());
						val = new byte[tmpval.Length*2];
						for (int i = 0; i<tmpval.Length; i++)
						{
							val[i*2] = 0;
							val[i*2+1] = tmpval[i];
						}
						aNode.Data = val;
                        break;
                    case Asn1Tag.INTEGER:
                    case Asn1Tag.BIT_STRING:
                        ed.checker = DataChecker.Hex;
                        ed.ShowDialog(parent);
                        if (!ed.isOK) return false;
                        aNode.UnusedBits = (byte)(Convert.ToUInt16(ed.textBoxUnusedBits.Text)%8);
                        data = Asn1Util.HexStrToBytes(ed.GetValueStr());
                        aNode.Data = data;
                        break;
                    default:
                        if ((aNode.Tag & Asn1Tag.TAG_MASK) == 6) // Visible string for certificate
                        {
                            ed.ShowDialog(parent);
                            if (!ed.isOK) return false;
                            val = Asn1Util.StringToBytes(ed.GetValueStr());
                            aNode.Data = val;
                        }
                        else
                        {
                            ed.checker = DataChecker.Hex;
                            ed.ShowDialog(parent);
                            if (!ed.isOK) return false;
                            data = Asn1Util.HexStrToBytes(ed.GetValueStr());
                            aNode.Data = data;
                        }
                        break;
                };
            }
            return true;
        }

		private FormNodeContentEditor()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNodeContentEditor));
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNodeContent = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelTag = new System.Windows.Forms.Panel();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelUnusedBits = new System.Windows.Forms.Panel();
            this.textBoxUnusedBits = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTag.SuspendLayout();
            this.panelUnusedBits.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data Content:";
            // 
            // textBoxNodeContent
            // 
            this.textBoxNodeContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNodeContent.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNodeContent.Location = new System.Drawing.Point(4, 155);
            this.textBoxNodeContent.MaxLength = 0;
            this.textBoxNodeContent.Multiline = true;
            this.textBoxNodeContent.Name = "textBoxNodeContent";
            this.textBoxNodeContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxNodeContent.Size = new System.Drawing.Size(547, 138);
            this.textBoxNodeContent.TabIndex = 2;
            this.textBoxNodeContent.Text = "textBoxNodeContent";
            this.textBoxNodeContent.WordWrap = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(461, 309);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 25);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "&Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(353, 309);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(90, 25);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "&OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(4, 10);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(547, 119);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "textBox1";
            // 
            // panelTag
            // 
            this.panelTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTag.Controls.Add(this.textBoxTag);
            this.panelTag.Controls.Add(this.label1);
            this.panelTag.Location = new System.Drawing.Point(4, 303);
            this.panelTag.Name = "panelTag";
            this.panelTag.Size = new System.Drawing.Size(140, 38);
            this.panelTag.TabIndex = 9;
            // 
            // textBoxTag
            // 
            this.textBoxTag.Location = new System.Drawing.Point(83, 6);
            this.textBoxTag.MaxLength = 2;
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.Size = new System.Drawing.Size(47, 21);
            this.textBoxTag.TabIndex = 1;
            this.textBoxTag.Text = "textBoxTag";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tag (hex) :";
            // 
            // panelUnusedBits
            // 
            this.panelUnusedBits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelUnusedBits.Controls.Add(this.textBoxUnusedBits);
            this.panelUnusedBits.Controls.Add(this.label3);
            this.panelUnusedBits.Location = new System.Drawing.Point(151, 303);
            this.panelUnusedBits.Name = "panelUnusedBits";
            this.panelUnusedBits.Size = new System.Drawing.Size(187, 38);
            this.panelUnusedBits.TabIndex = 10;
            // 
            // textBoxUnusedBits
            // 
            this.textBoxUnusedBits.Location = new System.Drawing.Point(97, 6);
            this.textBoxUnusedBits.MaxLength = 1;
            this.textBoxUnusedBits.Name = "textBoxUnusedBits";
            this.textBoxUnusedBits.Size = new System.Drawing.Size(79, 21);
            this.textBoxUnusedBits.TabIndex = 1;
            this.textBoxUnusedBits.Text = "0";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Unused Bits:";
            // 
            // FormNodeContentEditor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(556, 348);
            this.Controls.Add(this.panelUnusedBits);
            this.Controls.Add(this.panelTag);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBoxNodeContent);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FormNodeContentEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Node Content Editor";
            this.Load += new System.EventHandler(this.FormNodeContentEditor_Load);
            this.Activated += new System.EventHandler(this.FormNodeContentEditor_Activated);
            this.panelTag.ResumeLayout(false);
            this.panelTag.PerformLayout();
            this.panelUnusedBits.ResumeLayout(false);
            this.panelUnusedBits.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion

        private void FormNodeContentEditor_Load(object sender, System.EventArgs e)
        {
            textBoxTag.Text = String.Format("{0:X2}",aNode.Tag);
            textBoxNodeContent.Text = aNode.GetDataStr(pureHexMode);
			string msg = "";
			msg = String.Format(  "Tag:{0} (0x{0:X2}) : {1} \r\n"  
                                + "Offset:{2,4} (0x{2:X8})\r\n"  
                                + "Length:{3,4} (0x{3:X8})\r\n"
                                + "Deepness: {4}\r\n"
                                ,
				                aNode.Tag, 
				                Asn1Util.GetTagName(aNode.Tag), 
				                aNode.DataOffset,
				                aNode.DataLength,
                                aNode.Deepness
                                );
            if ((aNode.Tag & Asn1Tag.TAG_MASK) == Asn1Tag.BIT_STRING)
            {
                msg += "Unused Bits: " + aNode.UnusedBits.ToString() + "\r\n";
            }
            msg += "Path: " + aNode.Path + "\r\n";
			textBox1.Text = msg;
            if (aNode.ChildNodeCount>0)
            {
                textBoxNodeContent.Enabled = false;
                buttonOK.Enabled = false;
            }
            else
            {
                textBoxNodeContent.Enabled = true;
                buttonOK.Enabled = true;
            }
            textBoxTag.ReadOnly = !enableTagEdit;
            if (textBoxNodeContent.Enabled)
                textBoxNodeContent.Enabled = !enableTagEdit;
        }

		public string GetValueStr()
		{
			return textBoxNodeContent.Text;
		}

        public static bool IsOidStr(string inStr)
        {
            bool retval = false;
            MemoryStream ms = new MemoryStream();
            Oid xoid = new Oid();
            xoid.Encode(ms, inStr);
            ms.Close();
            retval = true;
            return retval;
        }

        public static bool IsRoidStr(string inStr)
        {
            bool retval = false;
            MemoryStream ms = new MemoryStream();
            RelativeOid roid = new RelativeOid();
            roid.Encode(ms, inStr);
            ms.Close();
            retval = true;
            return retval;
        }

        public static bool IsHexStr(string inStr)
        {
            bool retval = false;
            byte[] hex = Asn1Util.HexStrToBytes(inStr);
            retval = true;
            return retval;
        }

        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            string msg = "";
            string heading = "";
            try
            {
                switch (checker)
                {
                    case DataChecker.Hex:
                        heading = "Verify Hex String";
                        isOK = IsHexStr(textBoxNodeContent.Text);
                        break;
                    case DataChecker.Oid:
                        heading = "Verify OID String";
                        isOK = IsOidStr(textBoxNodeContent.Text);
                        break;
                    case DataChecker.Roid:
                        heading = "Verify RELATIVE-OID String";
                        isOK = IsRoidStr(textBoxNodeContent.Text);
                        break;
                    default:
                        isOK = true;
                        break;
                };
                if (!textBoxTag.ReadOnly)
                {
                    isOK = IsHexStr(textBoxTag.Text);
                    byte[] xb = Asn1Util.HexStrToBytes(textBoxTag.Text);
                    if (xb.Length>0)
                        aNode.Tag = xb[0];
                }
                int unusedBits = Convert.ToInt16(textBoxUnusedBits.Text);
            }
            catch(Exception ex)
            {
                msg += ex.Message;
                isOK = false;
            }
            if (!isOK)
                MessageBox.Show(this, msg, heading);
            else
                this.Close();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            isOK = false;
            this.Close();       
        }

        private void FormNodeContentEditor_Activated(object sender, System.EventArgs e)
        {
            isOK = false;
            buttonCancel.Focus();
        }
	}
}
