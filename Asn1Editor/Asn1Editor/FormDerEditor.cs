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
//| THE SOFTWARE PRODUCT IS PROVIDED 揂S IS?WITHOUT WARRANTY OF ANY KIND,        |
//| EITHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED         |
//| WARRANTIES OF TITLE, NON-INFRINGEMENT, MERCHANTABILITY AND FITNESS FOR        |
//| A PARTICULAR PURPOSE.                                                         |
//+-------------------------------------------------------------------------------+

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.IO;
using LipingShare.LCLib.Asn1Processor;

namespace LipingShare.Asn1Editor
{
	/// <summary>
	/// Summary description for Form1.
	/// 
	/// 09/25/2003:
	/// RefreshTreeView() is added to replace BuildTreeView() to do the tree refreshing during the editing.
	/// The treeView refreshing is smoother now.
	/// </summary>
    public class FormDerEditor : System.Windows.Forms.Form
    {
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel FileNamePanel;
        private System.Windows.Forms.StatusBarPanel FileSizePanel;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemOpen;
        private System.Windows.Forms.MenuItem menuItemSaveAs;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemEdit;
        private System.Windows.Forms.MenuItem menuItemCopy;
        private System.Windows.Forms.MenuItem menuItemCut;
        private System.Windows.Forms.MenuItem menuItemDelete;
        private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private System.Windows.Forms.ContextMenu contextMenuTreeNode;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItemNodeCopy;
        private System.Windows.Forms.MenuItem menuItemNodeCut;
        private System.Windows.Forms.MenuItem menuItemNodeDelete;
        private System.Windows.Forms.MenuItem menuItemNodeEdit;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MenuItem menuItem1Append;
        private System.Windows.Forms.MenuItem menuItemInsert;
        private System.Windows.Forms.MenuItem menuItemEditNode;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem menuItemShowDataOffset;
        private System.Windows.Forms.MenuItem menuItemShowDataContent;
        private System.Windows.Forms.MenuItem menuItemView;
        private System.Windows.Forms.MenuItem menuItemNodeSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuItem menuItemNodeRefresh;

        // User defined objects:
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItemNodeUseHexOffset;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItemSave;
        private System.Windows.Forms.MenuItem menuItemNodePasteBeforeCurrentNode;
        private System.Windows.Forms.MenuItem menuItemNodePasteAfterCurrentNode;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItemNodePasteAsLastChildNode;
        private System.Windows.Forms.MenuItem menuItemShowTagNumber;
        private System.Windows.Forms.MenuItem menuItemClearAll;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolBarButton toolBarButtonOpen;
        private System.Windows.Forms.ToolBarButton toolBarButtonSave;
        private System.Windows.Forms.ToolBarButton toolBarButtonSaveAs;
        private System.Windows.Forms.ToolBarButton toolBarButtonCopy;
        private System.Windows.Forms.ToolBarButton toolBarButtonPastAsLast;
        private System.Windows.Forms.ToolBarButton toolBarButtonPasteBefore;
        private System.Windows.Forms.ToolBarButton toolBarButtonPasteAfter;
        private System.Windows.Forms.ToolBarButton toolBarButtonCut;
        private System.Windows.Forms.ToolBarButton toolBarButtonDelete;
        private System.Windows.Forms.ImageList imageListToolBar;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.MenuItem menuItemViewNodeText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolBarButton toolBarButtonNewNode;
        private System.Windows.Forms.MenuItem menuItemNewNode;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItemBase64ToHex;
        private System.Windows.Forms.MenuItem menuItemEditInHexMode;
        private const string WinBaseTitle = "ASN.1 Editor李旭修改版 ---修改时间：2014.3.11";
        Asn1Parser xParser = new Asn1Parser();
        string editingFile = "";
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuItemHexViewer;
        int editingFileSize = 0;
        private System.Windows.Forms.MenuItem menuItemShowNodePath;
        private System.Windows.Forms.ImageList imageListDataType;
        private System.Windows.Forms.MenuItem menuItemIntroduction;
        private HexViewer hexViewer = new HexViewer();
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItemParseEncapsulatedData;
        private int refreshNodeCounter = 1;
        private FormViewText textViewer = new FormViewText();
        private bool firstRunTextViewer = true;

        public FormDerEditor()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            treeView.HideSelection = false;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDerEditor));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node13");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node14");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node15");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node11");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node12");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node6", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node9");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node10");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node5", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Node8");
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.FileNamePanel = new System.Windows.Forms.StatusBarPanel();
            this.FileSizePanel = new System.Windows.Forms.StatusBarPanel();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemClearAll = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemCopy = new System.Windows.Forms.MenuItem();
            this.menuItemCut = new System.Windows.Forms.MenuItem();
            this.menuItemDelete = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItemInsert = new System.Windows.Forms.MenuItem();
            this.menuItem1Append = new System.Windows.Forms.MenuItem();
            this.menuItemEditNode = new System.Windows.Forms.MenuItem();
            this.menuItemView = new System.Windows.Forms.MenuItem();
            this.menuItemShowDataContent = new System.Windows.Forms.MenuItem();
            this.menuItemShowNodePath = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemShowDataOffset = new System.Windows.Forms.MenuItem();
            this.menuItemNodeUseHexOffset = new System.Windows.Forms.MenuItem();
            this.menuItemShowTagNumber = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItemHexViewer = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItemBase64ToHex = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemIntroduction = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.contextMenuTreeNode = new System.Windows.Forms.ContextMenu();
            this.menuItemNodeEdit = new System.Windows.Forms.MenuItem();
            this.menuItemViewNodeText = new System.Windows.Forms.MenuItem();
            this.menuItemNodeSave = new System.Windows.Forms.MenuItem();
            this.menuItemEditInHexMode = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItemNodeCopy = new System.Windows.Forms.MenuItem();
            this.menuItemNodeCut = new System.Windows.Forms.MenuItem();
            this.menuItemNodeDelete = new System.Windows.Forms.MenuItem();
            this.menuItemNewNode = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemNodePasteAsLastChildNode = new System.Windows.Forms.MenuItem();
            this.menuItemNodePasteBeforeCurrentNode = new System.Windows.Forms.MenuItem();
            this.menuItemNodePasteAfterCurrentNode = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemNodeRefresh = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItemParseEncapsulatedData = new System.Windows.Forms.MenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButtonOpen = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonSave = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonSaveAs = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonCopy = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonPastAsLast = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonPasteBefore = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonPasteAfter = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonCut = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonDelete = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonNewNode = new System.Windows.Forms.ToolBarButton();
            this.imageListToolBar = new System.Windows.Forms.ImageList(this.components);
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageListDataType = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FileNamePanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileSizePanel)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 530);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.FileNamePanel,
            this.FileSizePanel});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(792, 23);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "statusBar";
            // 
            // FileNamePanel
            // 
            this.FileNamePanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.FileNamePanel.Name = "FileNamePanel";
            this.FileNamePanel.Text = "File Name: c:\\temp\\x.der";
            this.FileNamePanel.Width = 699;
            // 
            // FileSizePanel
            // 
            this.FileSizePanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.FileSizePanel.Name = "FileSizePanel";
            this.FileSizePanel.Text = "Size: 2048";
            this.FileSizePanel.Width = 76;
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemView,
            this.menuItem7,
            this.menuItemHelp});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpen,
            this.menuItemSaveAs,
            this.menuItem6,
            this.menuItemSave,
            this.menuItem2,
            this.menuItemClearAll,
            this.menuItemExit});
            this.menuItemFile.Text = "&File";
            this.menuItemFile.Popup += new System.EventHandler(this.menuItemFile_Popup);
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Index = 0;
            this.menuItemOpen.Text = "&Open ...";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Index = 1;
            this.menuItemSaveAs.Text = "Save &as ...";
            this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "-";
            // 
            // menuItemSave
            // 
            this.menuItemSave.Index = 3;
            this.menuItemSave.Text = "&Save";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 4;
            this.menuItem2.Text = "-";
            // 
            // menuItemClearAll
            // 
            this.menuItemClearAll.Index = 5;
            this.menuItemClearAll.Text = "&Clear all";
            this.menuItemClearAll.Click += new System.EventHandler(this.menuItemClearAll_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 6;
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 1;
            this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemCopy,
            this.menuItemCut,
            this.menuItemDelete,
            this.menuItem8,
            this.menuItemInsert,
            this.menuItem1Append,
            this.menuItemEditNode});
            this.menuItemEdit.Text = "&Edit";
            this.menuItemEdit.Visible = false;
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Index = 0;
            this.menuItemCopy.Text = "&Copy";
            // 
            // menuItemCut
            // 
            this.menuItemCut.Index = 1;
            this.menuItemCut.Text = "C&ut";
            // 
            // menuItemDelete
            // 
            this.menuItemDelete.Index = 2;
            this.menuItemDelete.Text = "&Delete";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 3;
            this.menuItem8.Text = "-";
            // 
            // menuItemInsert
            // 
            this.menuItemInsert.Index = 4;
            this.menuItemInsert.Text = "&Insert";
            // 
            // menuItem1Append
            // 
            this.menuItem1Append.Index = 5;
            this.menuItem1Append.Text = "&Append";
            // 
            // menuItemEditNode
            // 
            this.menuItemEditNode.Index = 6;
            this.menuItemEditNode.Text = "Edi&t";
            this.menuItemEditNode.Click += new System.EventHandler(this.menuItemNodeEdit_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.Index = 2;
            this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemShowDataContent,
            this.menuItemShowNodePath,
            this.menuItem4,
            this.menuItemShowDataOffset,
            this.menuItemNodeUseHexOffset,
            this.menuItemShowTagNumber,
            this.menuItem9,
            this.menuItemHexViewer});
            this.menuItemView.Text = "&View";
            this.menuItemView.Popup += new System.EventHandler(this.menuItemView_Popup);
            // 
            // menuItemShowDataContent
            // 
            this.menuItemShowDataContent.Checked = true;
            this.menuItemShowDataContent.Index = 0;
            this.menuItemShowDataContent.Text = "Show &data content";
            this.menuItemShowDataContent.Click += new System.EventHandler(this.menuItemShowDataContent_Click);
            // 
            // menuItemShowNodePath
            // 
            this.menuItemShowNodePath.Index = 1;
            this.menuItemShowNodePath.Text = "Show node path";
            this.menuItemShowNodePath.Click += new System.EventHandler(this.menuItemShowNodePath_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // menuItemShowDataOffset
            // 
            this.menuItemShowDataOffset.Checked = true;
            this.menuItemShowDataOffset.Index = 3;
            this.menuItemShowDataOffset.Text = "Show data &offset";
            this.menuItemShowDataOffset.Click += new System.EventHandler(this.menuItemShowDataOffset_Click);
            // 
            // menuItemNodeUseHexOffset
            // 
            this.menuItemNodeUseHexOffset.Index = 4;
            this.menuItemNodeUseHexOffset.Text = "Show offset in &hex";
            this.menuItemNodeUseHexOffset.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItemShowTagNumber
            // 
            this.menuItemShowTagNumber.Index = 5;
            this.menuItemShowTagNumber.Text = "Show tag number";
            this.menuItemShowTagNumber.Click += new System.EventHandler(this.menuItemShowTagNumber_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 6;
            this.menuItem9.Text = "-";
            // 
            // menuItemHexViewer
            // 
            this.menuItemHexViewer.Index = 7;
            this.menuItemHexViewer.Text = "Hex &Viewer";
            this.menuItemHexViewer.Click += new System.EventHandler(this.menuItemHexViewer_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 3;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemBase64ToHex});
            this.menuItem7.Text = "&Tools";
            // 
            // menuItemBase64ToHex
            // 
            this.menuItemBase64ToHex.Index = 0;
            this.menuItemBase64ToHex.Text = "&Data Converter";
            this.menuItemBase64ToHex.Click += new System.EventHandler(this.menuItemBase64ToHex_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 4;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemIntroduction,
            this.menuItemAbout});
            this.menuItemHelp.Text = "&Help";
            // 
            // menuItemIntroduction
            // 
            this.menuItemIntroduction.Index = 0;
            this.menuItemIntroduction.Text = "Introduction";
            this.menuItemIntroduction.Click += new System.EventHandler(this.menuItemIntroduction_Click);
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 1;
            this.menuItemAbout.Text = "&About";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // contextMenuTreeNode
            // 
            this.contextMenuTreeNode.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNodeEdit,
            this.menuItemViewNodeText,
            this.menuItemNodeSave,
            this.menuItemEditInHexMode,
            this.menuItem5,
            this.menuItemNodeCopy,
            this.menuItemNodeCut,
            this.menuItemNodeDelete,
            this.menuItemNewNode,
            this.menuItem3,
            this.menuItemNodePasteAsLastChildNode,
            this.menuItemNodePasteBeforeCurrentNode,
            this.menuItemNodePasteAfterCurrentNode,
            this.menuItem1,
            this.menuItemNodeRefresh,
            this.menuItem10,
            this.menuItemParseEncapsulatedData});
            this.contextMenuTreeNode.Popup += new System.EventHandler(this.contextMenuTreeNode_Popup);
            // 
            // menuItemNodeEdit
            // 
            this.menuItemNodeEdit.Index = 0;
            this.menuItemNodeEdit.Text = "Edit ...";
            this.menuItemNodeEdit.Click += new System.EventHandler(this.menuItemNodeEdit_Click);
            // 
            // menuItemViewNodeText
            // 
            this.menuItemViewNodeText.Index = 1;
            this.menuItemViewNodeText.Text = "View node text ...";
            this.menuItemViewNodeText.Click += new System.EventHandler(this.menuItemViewNodeText_Click);
            // 
            // menuItemNodeSave
            // 
            this.menuItemNodeSave.Index = 2;
            this.menuItemNodeSave.Text = "Save selected node as ...";
            this.menuItemNodeSave.Click += new System.EventHandler(this.menuItemNodeSave_Click);
            // 
            // menuItemEditInHexMode
            // 
            this.menuItemEditInHexMode.Index = 3;
            this.menuItemEditInHexMode.Text = "Edit in hex mode ...";
            this.menuItemEditInHexMode.Click += new System.EventHandler(this.menuItemEditInHexMode_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.menuItem5.Text = "-";
            // 
            // menuItemNodeCopy
            // 
            this.menuItemNodeCopy.Index = 5;
            this.menuItemNodeCopy.Text = "Copy";
            this.menuItemNodeCopy.Click += new System.EventHandler(this.menuItemNodeCopy_Click);
            // 
            // menuItemNodeCut
            // 
            this.menuItemNodeCut.Index = 6;
            this.menuItemNodeCut.Text = "Cut";
            this.menuItemNodeCut.Click += new System.EventHandler(this.menuItemNodeCut_Click);
            // 
            // menuItemNodeDelete
            // 
            this.menuItemNodeDelete.Index = 7;
            this.menuItemNodeDelete.Text = "Delete";
            this.menuItemNodeDelete.Click += new System.EventHandler(this.menuItemNodeDelete_Click);
            // 
            // menuItemNewNode
            // 
            this.menuItemNewNode.Index = 8;
            this.menuItemNewNode.Text = "New";
            this.menuItemNewNode.Click += new System.EventHandler(this.menuItemNewNode_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 9;
            this.menuItem3.Text = "-";
            // 
            // menuItemNodePasteAsLastChildNode
            // 
            this.menuItemNodePasteAsLastChildNode.Index = 10;
            this.menuItemNodePasteAsLastChildNode.Text = "Paste as last child node";
            this.menuItemNodePasteAsLastChildNode.Click += new System.EventHandler(this.menuItemNodePasteAsLastChildNode_Click);
            // 
            // menuItemNodePasteBeforeCurrentNode
            // 
            this.menuItemNodePasteBeforeCurrentNode.Index = 11;
            this.menuItemNodePasteBeforeCurrentNode.Text = "Paste before current node";
            this.menuItemNodePasteBeforeCurrentNode.Click += new System.EventHandler(this.menuItemNodePasteBeforeCurrentNode_Click);
            // 
            // menuItemNodePasteAfterCurrentNode
            // 
            this.menuItemNodePasteAfterCurrentNode.Index = 12;
            this.menuItemNodePasteAfterCurrentNode.Text = "Paste after current node";
            this.menuItemNodePasteAfterCurrentNode.Click += new System.EventHandler(this.menuItemNodePasteAfterCurrentNode_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 13;
            this.menuItem1.Text = "-";
            // 
            // menuItemNodeRefresh
            // 
            this.menuItemNodeRefresh.Index = 14;
            this.menuItemNodeRefresh.Text = "Refresh";
            this.menuItemNodeRefresh.Click += new System.EventHandler(this.menuItemRefresh_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 15;
            this.menuItem10.Text = "-";
            // 
            // menuItemParseEncapsulatedData
            // 
            this.menuItemParseEncapsulatedData.Index = 16;
            this.menuItemParseEncapsulatedData.Text = "Parse encapsulated data";
            this.menuItemParseEncapsulatedData.Click += new System.EventHandler(this.menuItemParseEncapsulatedData_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Binary (*.der; *.cer; *.pfx)|*.der;*.cer;*.pfx|PEM Encoded (*.pem; *.txt)|*.pem; " +
                "*.txt|All (*.*)|*.*";
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButtonOpen,
            this.toolBarButtonSave,
            this.toolBarButtonSaveAs,
            this.toolBarButton1,
            this.toolBarButtonCopy,
            this.toolBarButtonPastAsLast,
            this.toolBarButtonPasteBefore,
            this.toolBarButtonPasteAfter,
            this.toolBarButton2,
            this.toolBarButtonCut,
            this.toolBarButtonDelete,
            this.toolBarButtonNewNode});
            this.toolBar1.ButtonSize = new System.Drawing.Size(23, 23);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageListToolBar;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(792, 28);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButtonOpen
            // 
            this.toolBarButtonOpen.ImageIndex = 21;
            this.toolBarButtonOpen.Name = "toolBarButtonOpen";
            this.toolBarButtonOpen.ToolTipText = "Open";
            // 
            // toolBarButtonSave
            // 
            this.toolBarButtonSave.ImageIndex = 27;
            this.toolBarButtonSave.Name = "toolBarButtonSave";
            this.toolBarButtonSave.ToolTipText = "Save";
            // 
            // toolBarButtonSaveAs
            // 
            this.toolBarButtonSaveAs.ImageIndex = 31;
            this.toolBarButtonSaveAs.Name = "toolBarButtonSaveAs";
            this.toolBarButtonSaveAs.ToolTipText = "Save as";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonCopy
            // 
            this.toolBarButtonCopy.ImageIndex = 20;
            this.toolBarButtonCopy.Name = "toolBarButtonCopy";
            this.toolBarButtonCopy.ToolTipText = "Copy";
            // 
            // toolBarButtonPastAsLast
            // 
            this.toolBarButtonPastAsLast.ImageIndex = 15;
            this.toolBarButtonPastAsLast.Name = "toolBarButtonPastAsLast";
            this.toolBarButtonPastAsLast.ToolTipText = "Past";
            // 
            // toolBarButtonPasteBefore
            // 
            this.toolBarButtonPasteBefore.ImageIndex = 16;
            this.toolBarButtonPasteBefore.Name = "toolBarButtonPasteBefore";
            this.toolBarButtonPasteBefore.ToolTipText = "Paste before";
            // 
            // toolBarButtonPasteAfter
            // 
            this.toolBarButtonPasteAfter.ImageIndex = 26;
            this.toolBarButtonPasteAfter.Name = "toolBarButtonPasteAfter";
            this.toolBarButtonPasteAfter.ToolTipText = "Paste after";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonCut
            // 
            this.toolBarButtonCut.ImageIndex = 18;
            this.toolBarButtonCut.Name = "toolBarButtonCut";
            this.toolBarButtonCut.ToolTipText = "Cut";
            // 
            // toolBarButtonDelete
            // 
            this.toolBarButtonDelete.ImageIndex = 29;
            this.toolBarButtonDelete.Name = "toolBarButtonDelete";
            this.toolBarButtonDelete.ToolTipText = "Delete";
            // 
            // toolBarButtonNewNode
            // 
            this.toolBarButtonNewNode.ImageIndex = 30;
            this.toolBarButtonNewNode.Name = "toolBarButtonNewNode";
            this.toolBarButtonNewNode.ToolTipText = "New node";
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
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.ContextMenu = this.contextMenuTreeNode;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.ImageIndex = 29;
            this.treeView.ImageList = this.imageListDataType;
            this.treeView.Location = new System.Drawing.Point(0, 28);
            this.treeView.Name = "treeView";
            treeNode1.Name = "";
            treeNode1.Text = "Node13";
            treeNode2.Name = "";
            treeNode2.Text = "Node14";
            treeNode3.Name = "";
            treeNode3.Text = "Node15";
            treeNode4.Name = "";
            treeNode4.Text = "Node0";
            treeNode5.Name = "";
            treeNode5.Text = "Node7";
            treeNode6.Name = "";
            treeNode6.Text = "Node11";
            treeNode7.Name = "";
            treeNode7.Text = "Node12";
            treeNode8.Name = "";
            treeNode8.Text = "Node6";
            treeNode9.Name = "";
            treeNode9.Text = "Node9";
            treeNode10.Name = "";
            treeNode10.Text = "Node10";
            treeNode11.Name = "";
            treeNode11.Text = "Node5";
            treeNode12.Name = "";
            treeNode12.Text = "Node1";
            treeNode13.Name = "";
            treeNode13.Text = "Node2";
            treeNode14.Name = "";
            treeNode14.Text = "Node3";
            treeNode15.Name = "";
            treeNode15.Text = "Node4";
            treeNode16.Name = "";
            treeNode16.Text = "Node8";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            this.treeView.SelectedImageIndex = 0;
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(792, 502);
            this.treeView.TabIndex = 2;
            this.treeView.DoubleClick += new System.EventHandler(this.menuItemNodeEdit_Click);
            this.treeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_DragDrop);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            this.treeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_DragEnter);
            this.treeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_KeyDown);
            // 
            // imageListDataType
            // 
            this.imageListDataType.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListDataType.ImageStream")));
            this.imageListDataType.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListDataType.Images.SetKeyName(0, "");
            this.imageListDataType.Images.SetKeyName(1, "");
            this.imageListDataType.Images.SetKeyName(2, "");
            this.imageListDataType.Images.SetKeyName(3, "");
            this.imageListDataType.Images.SetKeyName(4, "");
            this.imageListDataType.Images.SetKeyName(5, "");
            this.imageListDataType.Images.SetKeyName(6, "");
            this.imageListDataType.Images.SetKeyName(7, "");
            this.imageListDataType.Images.SetKeyName(8, "");
            this.imageListDataType.Images.SetKeyName(9, "");
            this.imageListDataType.Images.SetKeyName(10, "");
            this.imageListDataType.Images.SetKeyName(11, "");
            this.imageListDataType.Images.SetKeyName(12, "");
            this.imageListDataType.Images.SetKeyName(13, "");
            this.imageListDataType.Images.SetKeyName(14, "");
            this.imageListDataType.Images.SetKeyName(15, "");
            this.imageListDataType.Images.SetKeyName(16, "");
            this.imageListDataType.Images.SetKeyName(17, "");
            this.imageListDataType.Images.SetKeyName(18, "");
            this.imageListDataType.Images.SetKeyName(19, "");
            this.imageListDataType.Images.SetKeyName(20, "");
            this.imageListDataType.Images.SetKeyName(21, "");
            this.imageListDataType.Images.SetKeyName(22, "");
            this.imageListDataType.Images.SetKeyName(23, "");
            this.imageListDataType.Images.SetKeyName(24, "");
            this.imageListDataType.Images.SetKeyName(25, "");
            this.imageListDataType.Images.SetKeyName(26, "");
            this.imageListDataType.Images.SetKeyName(27, "");
            this.imageListDataType.Images.SetKeyName(28, "");
            this.imageListDataType.Images.SetKeyName(29, "");
            this.imageListDataType.Images.SetKeyName(30, "");
            this.imageListDataType.Images.SetKeyName(31, "");
            this.imageListDataType.Images.SetKeyName(32, "");
            this.imageListDataType.Images.SetKeyName(33, "");
            this.imageListDataType.Images.SetKeyName(34, "");
            this.imageListDataType.Images.SetKeyName(35, "");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 553);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Refreshing TreeView ...";
            // 
            // FormDerEditor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(792, 553);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "FormDerEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ASN.1 Editor";
            this.Load += new System.EventHandler(this.FormDerEditor_Load);
            this.SizeChanged += new System.EventHandler(this.FormDerEditor_SizeChanged);
            this.Activated += new System.EventHandler(this.FormDerEditor_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDerEditor_FormClosed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormDerEditor_Closing);
            this.Move += new System.EventHandler(this.FormDerEditor_Move);
            ((System.ComponentModel.ISupportInitialize)(this.FileNamePanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileSizePanel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) 
        {
            FormDerEditor dc = new FormDerEditor();
            try
            {
                dc.statusBar.Panels[0].Text = "File Name:";
                dc.statusBar.Panels[1].Text = "Size:";
                dc.Text = WinBaseTitle;
                dc.treeView.Nodes.Clear();
                if (args.Length > 0)
                {
                    dc.OpenFile(args[0]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to open file");
            }
            Application.Run(dc);
        }

        /// <summary>
        /// Parse more arguments.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="head"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        static private bool ArgContains(string[] args, string head, out string operand)
        {
            operand = "";
            bool retval = false;
            int headLen = head.Length;
            for (int i=0; i<args.Length; i++)
            {
                if (head.ToUpper() == args[i].Substring(0, headLen).ToUpper())
                {
                    retval = true;
                    string[] operands = args[i].Split(':');
                    if (operands.Length > 1)
                        operand = operands[1];
                }
            }
            return retval;
        }

        Asn1Node RootNode
        {
            get
            {
                return xParser.RootNode;
            }
        }

        /// <summary>
        /// Return file type:
        /// 1: Binary  2: PEM 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public void OpenFile(string fileName)
        {
            int retval = 1;
            hexViewer.Connected = false;
            try
            {
                if (Asn1Util.IsPemFormatedFile(fileName))
                {
                    xParser.LoadPemData(fileName);
                    retval = 2;
                }
                else
                {
                    xParser.LoadData(fileName);
                    retval = 1;
                }

                openFileDialog.FileName = fileName;
                editingFile = openFileDialog.FileName;
                editingFileSize = xParser.RawData.Length;
                ShowCurrentFileInfo();
                BuildTreeView(treeView, GenMask());
                RefreshTree();
                if (treeView.Nodes != null)
                    treeView.SelectedNode = treeView.Nodes[0];
                saveFileDialog.FilterIndex = openFileDialog.FilterIndex;
                saveFileDialog.FileName = openFileDialog.FileName;
                saveFileDialog.InitialDirectory = openFileDialog.InitialDirectory;
                openFileDialog.FilterIndex = retval;
            }
            catch(Exception ex)
            {
                throw(ex);
            }
            finally
            {
                hexViewer.Connected = true;
                ShowCurrentFileInfo();
            }
        }

        private void menuItemOpen_Click(object sender, System.EventArgs e)
        {
            openFileDialog.Filter = "Binary (*.der; *.cer; *.pfx;*.dat;*.csr)|*.der;*.cer;*.pfx;*.dat;*.csr|PEM Encoded (*.pem; *.txt; *.dat;*.csr)|*.pem; *.txt;*.dat;*.csr|All (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenFile(openFileDialog.FileName);
                }
                catch(Exception ex)
                {
                    menuItemClearAll_Click(sender, e);
                    string msg = ex.Message;
                    MessageBox.Show(msg);
                }
            }
        }

        private void ShowCurrentFileInfo()
        {
            statusBar.Panels[0].Text = "File Name: " + editingFile;
            statusBar.Panels[1].Text = "Size: " + editingFileSize.ToString() + " (bytes)";
            string baseFileName = System.IO.Path.GetFileName(editingFile);
            if (baseFileName.Length > 0)
            {
                this.Text = WinBaseTitle + " - Opening File: " + baseFileName;
            }
            else
            {
                this.Text = WinBaseTitle;
            }
        }

        private void menuItemShowDataOffset_Click(object sender, System.EventArgs e)
        {
            menuItemShowDataOffset.Checked = !menuItemShowDataOffset.Checked;
            RefreshTree();
        }

        private void menuItemShowDataContent_Click(object sender, System.EventArgs e)
        {
            menuItemShowDataContent.Checked = !menuItemShowDataContent.Checked;
            RefreshTree();
        }

        private void menuItemShowNodePath_Click(object sender, System.EventArgs e)
        {
            menuItemShowNodePath.Checked = !menuItemShowNodePath.Checked;
            RefreshTree();
        }

		private uint GenMask()
		{
			uint mask = 0;
			if (menuItemShowDataOffset.Checked)
				mask |=Asn1Node.TagTextMask.SHOW_OFFSET;
			if (menuItemShowDataContent.Checked)
				mask |=Asn1Node.TagTextMask.SHOW_DATA;
			if (menuItemNodeUseHexOffset.Checked)
				mask |=Asn1Node.TagTextMask.USE_HEX_OFFSET;
			if (menuItemShowTagNumber.Checked)
				mask |=Asn1Node.TagTextMask.SHOW_TAG_NUMBER;
			if (menuItemShowNodePath.Checked)
				mask |=Asn1Node.TagTextMask.SHOW_PATH;
			return mask;
		}

        private void RefreshTree()
        {
            Asn1Node selected = null;
            if (treeView.SelectedNode !=null) 
                selected = ((Asn1TreeNode)treeView.SelectedNode).ANode;
            uint mask = GenMask();
            hexViewer.Connected = false;
            RefreshTreeView(treeView, mask);
            hexViewer.Connected = true;
            hexViewer.RootNode = xParser.RootNode;
            if (treeView.Nodes.Count > 0)
            {
                treeView.SelectedNode = null;
                treeView.SelectedNode = Asn1TreeNode.SearchTreeNode(treeView.Nodes[0], selected);
                if (treeView.SelectedNode == null)
                {
                    if (treeView.Nodes.Count>0)
                    {
                        treeView.SelectedNode = treeView.Nodes[0];
                    }
                }
            }
            SetHexView();
            treeView.Focus();
        }

        private void menuItemRefresh_Click(object sender, System.EventArgs e)
        {
            RefreshTree();
        }

        private void SetMenuItems(Menu cMenu, bool visible)
        {
            for (int i = 0; i<contextMenuTreeNode.MenuItems.Count; i++)
            {
                contextMenuTreeNode.MenuItems[i].Visible = visible;
            }
        }

        private void contextMenuTreeNode_Popup(object sender, System.EventArgs e)
        {
            bool visible = (treeView.SelectedNode != null);
            bool isDataReady = Asn1ClipboardData.IsDataReady();
            SetMenuItems(contextMenuTreeNode, visible);
            if (visible)
            {
                Asn1Node aNode = ((Asn1TreeNode) treeView.SelectedNode).ANode;
                menuItemNodePasteBeforeCurrentNode.Enabled = 
                     isDataReady && (aNode.ParentNode != null);
                menuItemNodePasteAfterCurrentNode.Enabled = 
                    isDataReady && (aNode.ParentNode != null);
                menuItemNodePasteAsLastChildNode.Enabled = 
                    isDataReady && (aNode.IsEmptyData);
                menuItemNodeCut.Enabled = (aNode.ParentNode != null);
                menuItemNodeDelete.Enabled = (aNode.ParentNode != null);
                menuItemViewNodeText.Enabled = visible;
                menuItemNewNode.Enabled = toolBarButtonNewNode.Enabled;
            }
        }

        public void SaveNodeAsPemFile(Asn1Node aNode, string fileName, string pemHeader)
        {
            MemoryStream ms = new MemoryStream();
            aNode.SaveData(ms);
            editingFileSize = (int)ms.Length;
            ShowCurrentFileInfo();
            byte[] bytes = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(bytes, 0, bytes.Length);
            ms.Close();
            string pemStr = Asn1Util.BytesToPem(bytes, pemHeader);
            FileStream fs = new FileStream(fileName, System.IO.FileMode.Create);
            bytes = Asn1Util.StringToBytes(pemStr);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }

        private void menuItemNodeSave_Click(object sender, System.EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 1)
                {
                    Stream fs = saveFileDialog.OpenFile();
                    Asn1Node aNode = ((Asn1TreeNode) treeView.SelectedNode).ANode;
                    aNode.SaveData(fs);
                    fs.Close();
                }
                else
                {
                    Asn1Node aNode = ((Asn1TreeNode) treeView.SelectedNode).ANode;
                    SaveNodeAsPemFile(aNode, saveFileDialog.FileName, "");
                }
            }
        }

        private void menuItemNodeEdit_Click(object sender, System.EventArgs e)
        {
            Asn1Node aNode = ((Asn1TreeNode) treeView.SelectedNode).ANode;
            if (FormNodeContentEditor.EditNode(this,aNode, false, false))
                RefreshTree();
        }

        private void menuItemEditInHexMode_Click(object sender, System.EventArgs e)
        {
            Asn1Node aNode = ((Asn1TreeNode) treeView.SelectedNode).ANode;
            if (FormNodeContentEditor.EditNode(this, aNode, false, true))
                RefreshTree();       
        }

        private void treeView_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            SetButton();
            if (e.KeyValue == 13)
            {
                Asn1Node aNode = ((Asn1TreeNode) treeView.SelectedNode).ANode;
                if (FormNodeContentEditor.EditNode(this, aNode, false, false))
                    RefreshTree();
            }
        }

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			menuItemNodeUseHexOffset.Checked = !menuItemNodeUseHexOffset.Checked;
			RefreshTree();
		}

        private void menuItemSaveAs_Click(object sender, System.EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FilterIndex == 1)
                {
                    Stream fs = saveFileDialog.OpenFile();
                    Asn1Node aNode = xParser.RootNode;
                    aNode.SaveData(fs);
                    editingFile = saveFileDialog.FileName;
                    editingFileSize = (int)fs.Length;
                    fs.Close();
                }
                else
                {
                    Asn1Node aNode = xParser.RootNode;
                    string pemHeader = "";
                    if (editingFile.Length > 0)
                    {
                        pemHeader = Asn1Util.GetPemFileHeader(editingFile);
                    }
                    if (pemHeader == null || pemHeader.Length < 1)
                    {
                        pemHeader = System.IO.Path.GetFileName(editingFile).Replace("-", "");
                    }
                    SaveNodeAsPemFile(aNode, saveFileDialog.FileName, pemHeader);
                    editingFile = saveFileDialog.FileName;
                }
                openFileDialog.FilterIndex = saveFileDialog.FilterIndex;
                openFileDialog.FileName = saveFileDialog.FileName;
                openFileDialog.InitialDirectory = saveFileDialog.InitialDirectory;
                ShowCurrentFileInfo();
            }
        }

        private void menuItemFile_Popup(object sender, System.EventArgs e)
        {
            menuItemSave.Enabled = (editingFile != "");
            menuItemSaveAs.Enabled = (treeView.Nodes.Count > 0);
        }

        private void menuItemSave_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog.FilterIndex == 1)
            {
                FileStream fs = new FileStream(editingFile, System.IO.FileMode.Create);
                Asn1Node aNode = xParser.RootNode;
                aNode.SaveData(fs);
                editingFileSize = (int)fs.Length;
                ShowCurrentFileInfo();
                fs.Close();        
            }
            else
            {
                Asn1Node aNode = xParser.RootNode;
                string pemHeader = Asn1Util.GetPemFileHeader(editingFile);
                SaveNodeAsPemFile(aNode, editingFile, pemHeader);              
            }
        }

        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private Asn1Node SelectedAsn1Node()
        {
            if (treeView.SelectedNode != null)
                return ((Asn1TreeNode) treeView.SelectedNode).ANode;
            else
                return null;
        }

        private void menuItemNodeCopy_Click(object sender, System.EventArgs e)
        {
            Asn1Node aNode = SelectedAsn1Node();
            Asn1ClipboardData.Copy(aNode);
            SetButton();
        }

        private void menuItemNodePasteBeforeCurrentNode_Click(object sender, System.EventArgs e)
        {
            Asn1Node selectedNode = SelectedAsn1Node();
            Asn1Node tempNode = Asn1ClipboardData.Paste();
            int index = selectedNode.ParentNode.InsertChild(tempNode, selectedNode);
			Asn1TreeNode tNode = new Asn1TreeNode(tempNode, GenMask());
			treeView.SelectedNode.Parent.Nodes.Insert(index, tNode);
			try
			{
				if (Asn1Node.GetDescendantNodeCount(tNode.ANode) > refreshNodeCounter)
				{
					treeView.Visible = false;
					hexViewer.Connected = false;
				}
				Asn1TreeNode.AddSubNode(tNode, GenMask(), treeView);
				RefreshTree();
				if (treeView.Nodes.Count > 0)
					treeView.SelectedNode = Asn1TreeNode.SearchTreeNode(treeView.Nodes[0], tempNode);
			}
			finally
			{
				hexViewer.Connected = true;
				treeView.Visible = true;
			}
        }

        private void menuItemNodePasteAsLastChildNode_Click(object sender, System.EventArgs e)
        {
            Asn1Node selectedNode = SelectedAsn1Node();
            Asn1Node tempNode = Asn1ClipboardData.Paste();
            selectedNode.AddChild(tempNode);
			Asn1TreeNode tNode = new Asn1TreeNode(tempNode, GenMask());
			treeView.SelectedNode.Nodes.Add(tNode);
			try
			{
				if (Asn1Node.GetDescendantNodeCount(tNode.ANode) > refreshNodeCounter)
				{
					treeView.Visible = false;
					hexViewer.Connected = false;
				}
				Asn1TreeNode.AddSubNode(tNode, GenMask(), treeView);
				RefreshTree();
				if (treeView.Nodes.Count > 0)
					treeView.SelectedNode = Asn1TreeNode.SearchTreeNode(treeView.Nodes[0], tempNode);
			}
			finally
			{
				hexViewer.Connected = true;
				treeView.Visible = true;
			}
        }

		private void menuItemShowTagNumber_Click(object sender, System.EventArgs e)
		{
			menuItemShowTagNumber.Checked = !menuItemShowTagNumber.Checked;		
			RefreshTree();
		}

		private void menuItemClearAll_Click(object sender, System.EventArgs e)
		{
            treeView.Visible = false;
            try
            {
                hexViewer.Connected = false;
                ClearChildTreeNodes(treeView.Nodes);
                xParser.RootNode.ClearAll();
                hexViewer.RootNode = null;
                editingFile = "";
                editingFileSize = 0;
                ShowCurrentFileInfo();
                SetButton();
            }
            finally
            {
                treeView.Visible = true;
                hexViewer.Connected = true;
            }
		}

        private void menuItemView_Popup(object sender, System.EventArgs e)
        {
            bool checker = (treeView.SelectedNode != null);
            for (int i=0; i<menuItemView.MenuItems.Count; i++)
            {
                menuItemView.MenuItems[i].Enabled = checker;
            }
            menuItemShowTagNumber.Enabled = menuItemShowDataOffset.Checked && 
                menuItemShowDataOffset.Enabled;
            menuItemNodeUseHexOffset.Enabled = menuItemShowDataOffset.Checked && 
                menuItemShowDataOffset.Enabled;
        }

        private void menuItemNodePasteAfterCurrentNode_Click(object sender, System.EventArgs e)
        {
            Asn1Node selectedNode = SelectedAsn1Node();
            Asn1Node tempNode = Asn1ClipboardData.Paste();
            int index = selectedNode.ParentNode.InsertChildAfter(tempNode, selectedNode);
			Asn1TreeNode tNode = new Asn1TreeNode(tempNode, GenMask());
			treeView.SelectedNode.Parent.Nodes.Insert(index, tNode);
			try
			{
				if (Asn1Node.GetDescendantNodeCount(tNode.ANode) > refreshNodeCounter)
				{
					treeView.Visible = false;
					hexViewer.Connected = false;
				}
				Asn1TreeNode.AddSubNode(tNode, GenMask(), treeView);
				RefreshTree();
				if (treeView.Nodes.Count > 0)
					treeView.SelectedNode = Asn1TreeNode.SearchTreeNode(treeView.Nodes[0], tempNode);        
			}
			finally
			{
				hexViewer.Connected = true;
				treeView.Visible = true;
			}
        }

        private void menuItemNodeCut_Click(object sender, System.EventArgs e)
        {
            Asn1Node tempNode = SelectedAsn1Node();
			Asn1ClipboardData.Copy(tempNode);
            tempNode = tempNode.ParentNode.RemoveChild(tempNode);
			treeView.Nodes.Remove(treeView.SelectedNode);
			RefreshTree();
            if (treeView.Nodes.Count > 0)
                treeView.SelectedNode = Asn1TreeNode.SearchTreeNode(treeView.Nodes[0], tempNode);
        }

        private void menuItemNodeDelete_Click(object sender, System.EventArgs e)
        {
            DialogResult dret = 
                MessageBox.Show(this, "Do you want to delete selected node/branch ?", 
                    "Delete", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dret == DialogResult.No) return;
            Asn1Node tempNode = SelectedAsn1Node();
            tempNode = tempNode.ParentNode.RemoveChild(tempNode);
			treeView.Nodes.Remove(treeView.SelectedNode);
			RefreshTree();
            if (treeView.Nodes.Count > 0)
                treeView.SelectedNode = Asn1TreeNode.SearchTreeNode(treeView.Nodes[0], tempNode);       
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if (e.Button == toolBarButtonOpen)
            {
                menuItemOpen_Click(sender, e);
            }
            else if (e.Button == toolBarButtonSave)
            {
                menuItemSave_Click(sender, e);
            }
            else if (e.Button == toolBarButtonSaveAs)
            {
                menuItemSaveAs_Click(sender, e);
            }
            else if (e.Button == toolBarButtonCopy)
            {
                menuItemNodeCopy_Click(sender, e);
            }
            else if(e.Button == toolBarButtonPastAsLast)
            {
                menuItemNodePasteAsLastChildNode_Click(sender, e);
            }
            else if(e.Button == toolBarButtonPasteBefore)
            {
                menuItemNodePasteBeforeCurrentNode_Click(sender, e);
            }
            else if(e.Button == toolBarButtonPasteAfter)
            {
                menuItemNodePasteAfterCurrentNode_Click(sender, e);
            }
            else if(e.Button == toolBarButtonCut)
            {
                menuItemNodeCut_Click(sender, e);
            }
            else if(e.Button == toolBarButtonDelete)
            {
                menuItemNodeDelete_Click(sender, e);
            }
            else if(e.Button == toolBarButtonNewNode)
            {
                menuItemNewNode_Click(sender, e);
            }
        }

        private void SetButton()
        {
            bool isDataReady = Asn1ClipboardData.IsDataReady();
            toolBarButtonOpen.Enabled = true; // Open
            toolBarButtonSave.Enabled = editingFile.Length > 0; // Save
            toolBarButtonSaveAs.Enabled = (xParser.RootNode != null) &&
                ((xParser.RootNode.Data != null) || (xParser.RootNode.ChildNodeCount > 0)); // Save as
            toolBarButtonCopy.Enabled = treeView.SelectedNode != null; // Copy
            toolBarButtonPastAsLast.Enabled = 
                (treeView.SelectedNode != null) && 
                ((((Asn1TreeNode)(treeView.SelectedNode)).ANode.IsEmptyData) || 
                ((Asn1TreeNode)(treeView.SelectedNode)).ANode.Data.Length<1) &&
                isDataReady; // PasteLast
            toolBarButtonPasteBefore.Enabled = 
                (treeView.SelectedNode != null) && 
                ((Asn1TreeNode)(treeView.SelectedNode)).ANode.ParentNode != null &&
                isDataReady; // PasteBefore
            toolBarButtonPasteAfter.Enabled = 
                (treeView.SelectedNode != null) && 
                ((Asn1TreeNode)(treeView.SelectedNode)).ANode.ParentNode != null &&
                isDataReady; // PasteAfter
            toolBarButtonCut.Enabled = 
                (treeView.SelectedNode != null) && 
                ((Asn1TreeNode)(treeView.SelectedNode)).ANode.ParentNode != null; // Cut
            toolBarButtonDelete.Enabled = 
                (treeView.SelectedNode != null) && 
                ((Asn1TreeNode)(treeView.SelectedNode)).ANode.ParentNode != null; // Delete

            // Set new node button
            toolBarButtonNewNode.Enabled = false;
            toolBarButtonNewNode.Enabled = (treeView.Nodes.Count < 1);
            if (!toolBarButtonNewNode.Enabled)
            {
                Asn1Node stmpNode = SelectedAsn1Node();
                if (stmpNode != null)
                {
                    toolBarButtonNewNode.Enabled = (stmpNode.IsEmptyData) || (stmpNode.Data.Length < 1);
                }
            }
			
			if (treeView.SelectedNode != null)
			{
				menuItemParseEncapsulatedData.Enabled = 
					(((Asn1TreeNode)(treeView.SelectedNode)).ANode.Tag & Asn1TagClasses.CONSTRUCTED) == 0; 
				menuItemParseEncapsulatedData.Checked = 
					(((Asn1TreeNode)(treeView.SelectedNode)).ANode.ParseEncapsulatedData); 
			}
			else
			{
				menuItemParseEncapsulatedData.Enabled = false;
			}
			menuItemParseEncapsulatedData.Enabled = true;
        }

        private void treeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            SetButton();
            SetHexView();
        }

        private void menuItemNewNode_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (treeView.Nodes.Count < 1)
                {
                    if (FormNodeContentEditor.EditNode(this, xParser.RootNode, true, true))
                    {
                        BuildTreeView(treeView, this.GenMask());
                        RefreshTree();
                        if (treeView.Nodes.Count>0)
                            treeView.SelectedNode = treeView.Nodes[0];
                    }
                }
                else
                {
                    Asn1Node selectedNode = SelectedAsn1Node();
                    Asn1Node tempNode = new Asn1Node();
                    if (FormNodeContentEditor.EditNode(this, tempNode, true, true))
                    {
                        if (selectedNode.IsEmptyData || selectedNode.Data.Length < 1)
                        {
                            selectedNode.AddChild(tempNode);
                            Asn1TreeNode tNode = new Asn1TreeNode(tempNode, GenMask());
                            treeView.SelectedNode.Nodes.Add(tNode);
                        }
                        else
                        {
                            if (selectedNode.ParentNode != null)
                            {
                                selectedNode.ParentNode.AddChild(tempNode);
                                Asn1TreeNode tNode = new Asn1TreeNode(tempNode, GenMask());
                                treeView.SelectedNode.Parent.Nodes.Add(tNode);
                            }
                            else
                                MessageBox.Show("Failed to add new node.");
                        }
                        RefreshTree();
                        treeView.SelectedNode = Asn1TreeNode.SearchTreeNode(treeView.Nodes[0], tempNode);
                    }
                }
                SetButton();
            }
            catch( Exception ex )
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuItemBase64ToHex_Click(object sender, System.EventArgs e)
        {
            try
            {
                string path = System.IO.Path.GetDirectoryName(
                    System.Windows.Forms.Application.ExecutablePath);
                string exeName = path + "\\DataConverter.exe";
                string arg = editingFile;
                System.Diagnostics.Process.Start(exeName, "\"" +arg + "\"");
            }
            catch
            {
                MessageBox.Show("Failed to lunch Data Converter.");
            }
        }

        private void treeView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right) 
            { 
                TreeNode tmpNode = treeView.GetNodeAt (e.X ,e.Y );
                if (tmpNode != null)
                {
                    treeView.SelectedNode = tmpNode;
                }
            }         
        }

        private void FormDerEditor_Activated(object sender, System.EventArgs e)
        {
            SetButton(); //To check if clipboard data is changed.
        }

        private void SetHexView()
        {
            hexViewer.SelectedNode = SelectedAsn1Node();
            treeView.Focus();
        }

        private void menuItemHexViewer_Click(object sender, System.EventArgs e)
        {
            if (hexViewer.Visible)
            {
                hexViewer.BringToFront();
                return;
            }
            hexViewer.ResetWidth();
            hexViewer.parentForm = this;
            hexViewer.pOldLeft = this.Left;
            hexViewer.pOldWidth = this.Width;
            System.Drawing.Rectangle rect;
            if (this.Left < System.Windows.Forms.Screen.GetBounds(this).Width) // On main screen
            {
                rect = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                this.Left = hexViewer.Left + hexViewer.Width;
                int width = this.Width;
                if ((this.Left + width) > rect.Left + rect.Width)
                {
                    width = rect.Width - this.Left;
                    if (width < 400) width = 450;
                    this.Width = width;
                }
            }
            else
            {
                hexViewer.Left = this.Left - hexViewer.Width;
                if (hexViewer.Left < 0)
                {
                    hexViewer.Left = 0;
                    this.Left = hexViewer.Left + 10;
                }
            }
            hexViewer.Top = this.Top;
            hexViewer.Height = this.Height;
            hexViewer.Show();
        }

        protected enum ImgIndex
        {
            BOOLEAN 			= 21, //  1
            INTEGER 			=  1, //  2
            BIT_STRING		    = 23, //  2
            OCTET_STRING		= 25, //  4
            TAG_NULL			= 18, //  5
            OBJECT_IDENTIFIER	= 11, //  6
            OBJECT_DESCRIPTOR	= 11, //  7
            EXTERNAL			=  6, //  8
            REAL				=  1, //  9
            ENUMERATED		    =  1, // 10
            UTF8_STRING		    =  7, // 12
            RELATIVE_OID        = 35, // 13
            SEQUENCE			= 32, // 16
            SET 				= 33, // 17
            NUMERIC_STRING	    =  8, // 18
            PRINTABLE_STRING 	=  7, // 19
            T61_STRING		    =  7, // 20
            VIDEOTEXT_STRING 	=  7, // 21
            IA5_STRING		    =  7, // 22
            UTC_TIME 			= 34, // 23
            GENERALIZED_TIME 	= 34, // 24
            GRAPHIC_STRING	    =  7, // 25
            VISIBLE_STRING	    =  7, // 26
            GENERAL_STRING	    =  7, // 27
            UNIVERSAL_STRING	=  7, // 28
            BMPSTRING		    =  7, // 30
            CONTEXT_SPECIFIC    = 24, // 31
            ROOT                = 32,
            ROOT_SELECTED       = 32
        }

        public void BuildTreeView(TreeView treeView, uint mask)
        {
            treeView.Visible = false;
            try
            {
                ClearChildTreeNodes(treeView.Nodes);
                Asn1TreeNode rootTreeNode = new Asn1TreeNode(RootNode, mask);
                rootTreeNode.ImageIndex = (int)ImgIndex.ROOT;
                rootTreeNode.SelectedImageIndex = (int)ImgIndex.ROOT_SELECTED;
                BuildChildTreeNode(rootTreeNode, mask);
                treeView.Nodes.Add(rootTreeNode);
                rootTreeNode.ExpandAll();
                treeView.SelectedNode = rootTreeNode;
            }
            finally
            {
                treeView.Visible = true;
            }
        }

		public void RefreshTreeView(TreeView treeView, uint mask)
		{
			treeView.Visible = false;
			try
			{
				if (treeView.Nodes.Count<1) return;
				Asn1TreeNode rootTreeNode = (Asn1TreeNode)treeView.Nodes[0];
				rootTreeNode.Text = rootTreeNode.ANode.GetLabel(mask);
				RefreshChildTreeNode(rootTreeNode, mask);
			}
			finally
			{
				treeView.Visible = true;
			}
		}

		public void SetNodeImgIndex(Asn1TreeNode node)
		{
			int tag = node.ANode.Tag;
			int tagClass = (tag & Asn1TagClasses.CLASS_MASK);
			if (tagClass == Asn1TagClasses.CONTEXT_SPECIFIC ||
				tagClass == Asn1TagClasses.APPLICATION ||
				tagClass == Asn1TagClasses.PRIVATE)
			{
				SetNodeImgIndex(node, ImgIndex.CONTEXT_SPECIFIC);
			}
			else
			{
				switch (tag & Asn1Tag.TAG_MASK)
				{
					case Asn1Tag.BOOLEAN:
						SetNodeImgIndex(node, ImgIndex.BOOLEAN);
						break;
					case Asn1Tag.INTEGER:
						SetNodeImgIndex(node, ImgIndex.INTEGER);
						break;
					case Asn1Tag.BIT_STRING:
						SetNodeImgIndex(node, ImgIndex.BIT_STRING);
						break;
					case Asn1Tag.OCTET_STRING:
						SetNodeImgIndex(node, ImgIndex.OCTET_STRING);
						break;
					case Asn1Tag.TAG_NULL:
						SetNodeImgIndex(node, ImgIndex.TAG_NULL);
						break;
					case Asn1Tag.OBJECT_IDENTIFIER:
						SetNodeImgIndex(node, ImgIndex.OBJECT_IDENTIFIER);
						break;
                    case Asn1Tag.RELATIVE_OID:
                        SetNodeImgIndex(node, ImgIndex.RELATIVE_OID);
                        break;
					case Asn1Tag.OBJECT_DESCRIPTOR:
						SetNodeImgIndex(node, ImgIndex.OBJECT_DESCRIPTOR);
						break;
					case Asn1Tag.EXTERNAL:
						SetNodeImgIndex(node, ImgIndex.EXTERNAL);
						break;
					case Asn1Tag.REAL:
						SetNodeImgIndex(node, ImgIndex.REAL);
						break;
					case Asn1Tag.ENUMERATED:
						SetNodeImgIndex(node, ImgIndex.ENUMERATED);
						break;
					case Asn1Tag.UTF8_STRING:
						SetNodeImgIndex(node, ImgIndex.UTF8_STRING);
						break;
					case Asn1Tag.SEQUENCE:
						SetNodeImgIndex(node, ImgIndex.SEQUENCE);
						break;
					case Asn1Tag.SET:
						SetNodeImgIndex(node, ImgIndex.SET);
						break;
					case Asn1Tag.NUMERIC_STRING:
						SetNodeImgIndex(node, ImgIndex.NUMERIC_STRING);
						break;
					case Asn1Tag.PRINTABLE_STRING:
						SetNodeImgIndex(node, ImgIndex.PRINTABLE_STRING);
						break;
					case Asn1Tag.T61_STRING:
						SetNodeImgIndex(node, ImgIndex.T61_STRING);
						break;
					case Asn1Tag.VIDEOTEXT_STRING:
						SetNodeImgIndex(node, ImgIndex.VIDEOTEXT_STRING);
						break;
					case Asn1Tag.IA5_STRING:
						SetNodeImgIndex(node, ImgIndex.IA5_STRING);
						break;
					case Asn1Tag.UTC_TIME:
						SetNodeImgIndex(node, ImgIndex.UTC_TIME);
						break;
					case Asn1Tag.GENERALIZED_TIME:
						SetNodeImgIndex(node, ImgIndex.GENERALIZED_TIME);
						break;
					case Asn1Tag.GRAPHIC_STRING:
						SetNodeImgIndex(node, ImgIndex.GRAPHIC_STRING);
						break;
					case Asn1Tag.VISIBLE_STRING:
						SetNodeImgIndex(node, ImgIndex.VISIBLE_STRING);
						break;
					case Asn1Tag.GENERAL_STRING:
						SetNodeImgIndex(node, ImgIndex.GENERAL_STRING);
						break;
					case Asn1Tag.UNIVERSAL_STRING:
						SetNodeImgIndex(node, ImgIndex.UNIVERSAL_STRING);
						break;
					case Asn1Tag.BMPSTRING:
						SetNodeImgIndex(node, ImgIndex.BMPSTRING);
						break;
					default:
						SetNodeImgIndex(node, ImgIndex.CONTEXT_SPECIFIC);
						break;
				};
			}
		}

		public void RefreshChildTreeNode(Asn1TreeNode node, uint mask)
		{
			SetNodeImgIndex(node);
			for (int i=0; i<node.Nodes.Count; i++)
			{
				node.Nodes[i].Text = ((Asn1TreeNode)node.Nodes[i]).ANode.GetLabel(mask);
				RefreshChildTreeNode((Asn1TreeNode)node.Nodes[i], mask);
			}
		}

        public void ClearChildTreeNodes(TreeNodeCollection nodes)
        {
            for (int i=0; i<nodes.Count; i++)
            {
                ClearChildTreeNodes(nodes[i].Nodes);
                nodes[i].Nodes.Clear();
            }
            nodes.Clear();
        }

        protected void SetNodeImgIndex(TreeNode node, ImgIndex i)
        {
            node.ImageIndex = (int) i;
            node.SelectedImageIndex = (int) i;
            return;
        }

        private void BuildChildTreeNode(Asn1TreeNode tNode, uint mask)
        {
            int i;
			SetNodeImgIndex(tNode);
            Asn1TreeNode tmpNode; 
            for (i=0; i<tNode.ANode.ChildNodeCount; i++)
            {
                tmpNode = new Asn1TreeNode(tNode.ANode.GetChildNode(i), mask);
                tNode.Nodes.Add(tmpNode);
                BuildChildTreeNode(tmpNode, mask);
            }
        }

        private void menuItemIntroduction_Click(object sender, System.EventArgs e)
        {
            string linkUrl = "http://www.lipingshare.com/Asn1Editor/Introduction.htm";
            try
            {
                System.Diagnostics.Process.Start(linkUrl);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + linkUrl);
            }
        }

        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
			About about = new About();
			about.Text = "ASN.1 Editor - " + VersionInfo.VersionStr;
			about.ShowDialog(this);
        }

		private void menuItemParseEncapsulatedData_Click(object sender, System.EventArgs e)
		{
			hexViewer.Connected = false;
			treeView.Visible = false;
			try
			{
				menuItemParseEncapsulatedData.Checked = !menuItemParseEncapsulatedData.Checked;
				Asn1Node selectedNode = SelectedAsn1Node();
				selectedNode.ParseEncapsulatedData = menuItemParseEncapsulatedData.Checked;
				TreeNode sTreeNode = treeView.SelectedNode;
				treeView.SelectedNode.Nodes.Clear();
				Asn1TreeNode.AddSubNode((Asn1TreeNode)treeView.SelectedNode, GenMask(), treeView);
				RefreshTree();
				if (treeView.Nodes.Count > 0)
					  treeView.SelectedNode = Asn1TreeNode.SearchTreeNode(treeView.Nodes[0], selectedNode);
			}
			finally
			{
				hexViewer.Connected = true;
				treeView.Visible = true;
			}
		}

        private void FormDerEditor_SizeChanged(object sender, System.EventArgs e)
        {
            if (WindowState != System.Windows.Forms.FormWindowState.Normal)
            {
                return;
            }
            hexViewer.ResizeForm(this.Top, this.Left, this.Right, this.Bottom);
        }

        public Configuration config = new Configuration();

        public bool IsValidScreenLocation(int top, int left, int width, int height)
        {
            if (top < 1) return false;
            if (left < 1) return false;
            if (width + left > System.Windows.Forms.Screen.GetBounds(this).Width) return false;
            if (top + height > System.Windows.Forms.Screen.GetBounds(this).Height) return false;
            if (width < 200) return false;
            if (height < 200) return false;
            return true;
        }

        private void FormDerEditor_Load(object sender, System.EventArgs e)
        {
            SetButton();
            config.GetData();
            if (config.useRegSettings)
            {
                if (System.Windows.Forms.Screen.GetBounds(this).Height == config.currentScreenHeight &&
                    System.Windows.Forms.Screen.GetBounds(this).Width == config.currentScreenWidth)
                {
                    if (IsValidScreenLocation(config.mainEditorTop, config.mainEditorLeft,
                        config.mainEditorWidth, config.mainEditorHeight))
                    {
                        this.Left = config.mainEditorLeft;
                        this.Top = config.mainEditorTop;
                        this.Width = config.mainEditorWidth;
                        this.Height = config.mainEditorHeight;
                    }
                    else
                    {
                        config.useRegSettings = false;
                    }
                }
                else
                {
                    config.useRegSettings = false;
                }
                if (!config.useRegSettings)
                {
                    this.Width = 800;
                    this.Height = 600;
                    this.Top = (System.Windows.Forms.Screen.GetBounds(this).Height - this.Height) / 2;
                    if (this.Top < 0) this.Top = 0;
                    this.Left = (System.Windows.Forms.Screen.GetBounds(this).Width - this.Width) / 2;
                    if (this.Left < 0) this.Left = 0;
                }
            }
        }

        private void FormDerEditor_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            config.currentScreenWidth    = System.Windows.Forms.Screen.GetBounds(this).Width;
            config.currentScreenHeight   = System.Windows.Forms.Screen.GetBounds(this).Height;

            config.mainEditorLeft    = this.Left;
            config.mainEditorTop     = this.Top;
            config.mainEditorWidth   = this.Width;
            config.mainEditorHeight  = this.Height;

            if (!firstRunTextViewer)
            {
                config.textViewerTop    = textViewer.Top;
                config.textViewerLeft   = textViewer.Left;
                config.textViewerWidth  = textViewer.Width;
                config.textViewerHeight = textViewer.Height;
                config.textLength  = Convert.ToInt32(textViewer.textBoxLineWidth.Text);
            }

            config.SaveData();        
        }

        private void menuItemViewNodeText_Click(object sender, System.EventArgs e)
        {
            Asn1Node tempNode = SelectedAsn1Node();
            if (firstRunTextViewer)
            {
                int lineLen = Asn1Node.defaultLineLen;
                textViewer.SetText(tempNode, lineLen);
                textViewer.config = this.config;
                if (IsValidScreenLocation(
                    textViewer.config.textViewerTop,
                    textViewer.config.textViewerLeft,
                    textViewer.config.textViewerWidth,
                    textViewer.config.textViewerHeight) && !textViewer.config.setTextViewSameAsTreeViewScreen)
                {
                    textViewer.Top = textViewer.config.textViewerTop;
                    textViewer.Left = textViewer.config.textViewerLeft;
                    textViewer.Width = textViewer.config.textViewerWidth;
                    textViewer.Height = textViewer.config.textViewerHeight;
                    textViewer.textBoxLineWidth.Text = textViewer.config.textLength.ToString();
                }
                else
                {
                    textViewer.Top = this.Top;
                    textViewer.Left = this.Left;
                    textViewer.Width = this.Width;
                    textViewer.Height = this.Height;
                    textViewer.textBoxLineWidth.Text = textViewer.config.textLength.ToString();
                }
                textViewer.ResizeText();
                firstRunTextViewer = false;
            }
            else
            {
                int lineLen = textViewer.config.textLength;
                textViewer.SetText(tempNode, lineLen);
                textViewer.ResizeText();
            }
            textViewer.Show();       
        }

        private void FormDerEditor_Move(object sender, EventArgs e)
        {
            if (hexViewer.Visible)
            {
                hexViewer.Left = this.Left - hexViewer.Width;
                hexViewer.Top = this.Top;
                hexViewer.Height = this.Height;
            }
        }

        private void FormDerEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void treeView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Effect == DragDropEffects.All)
                {
                    string[] arFileName = (string[])(e.Data.GetData(DataFormats.FileDrop));
                    OpenFile(arFileName[0]);
                }
            }
            catch (Exception ex)
            {
                menuItemClearAll_Click(sender, e);
                string msg = ex.Message;
                MessageBox.Show(msg);
            }
        }
	}
}
