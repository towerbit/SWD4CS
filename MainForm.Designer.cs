namespace SWD4CS;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.mainWndSplitContainer = new System.Windows.Forms.SplitContainer();
        this.ctrlsTab = new System.Windows.Forms.TabControl();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.ctrlLstBox = new System.Windows.Forms.ListBox();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.ctrlTreeView = new System.Windows.Forms.TreeView();
        this.subWndSplitContainer = new System.Windows.Forms.SplitContainer();
        this.designTab = new System.Windows.Forms.TabControl();
        this.designPage = new System.Windows.Forms.TabPage();
        this.designSplitContainer = new System.Windows.Forms.SplitContainer();
        this.otherCtlPanel = new System.Windows.Forms.FlowLayoutPanel();
        this.sourcePage = new System.Windows.Forms.TabPage();
        this.sourceTxtBox = new System.Windows.Forms.TextBox();
        this.tabControl1 = new System.Windows.Forms.TabControl();
        this.tabPage3 = new System.Windows.Forms.TabPage();
        this.propertyBox = new System.Windows.Forms.PropertyGrid();
        this.tabPage4 = new System.Windows.Forms.TabPage();
        this.nameTxtBox = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        ((System.ComponentModel.ISupportInitialize)(this.mainWndSplitContainer)).BeginInit();
        this.mainWndSplitContainer.Panel1.SuspendLayout();
        this.mainWndSplitContainer.Panel2.SuspendLayout();
        this.mainWndSplitContainer.SuspendLayout();
        this.ctrlsTab.SuspendLayout();
        this.tabPage1.SuspendLayout();
        this.tabPage2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.subWndSplitContainer)).BeginInit();
        this.subWndSplitContainer.Panel1.SuspendLayout();
        this.subWndSplitContainer.Panel2.SuspendLayout();
        this.subWndSplitContainer.SuspendLayout();
        this.designTab.SuspendLayout();
        this.designPage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.designSplitContainer)).BeginInit();
        this.designSplitContainer.Panel2.SuspendLayout();
        this.designSplitContainer.SuspendLayout();
        this.sourcePage.SuspendLayout();
        this.tabControl1.SuspendLayout();
        this.tabPage3.SuspendLayout();
        this.SuspendLayout();
        // 
        // mainWndSplitContainer
        // 
        this.mainWndSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.mainWndSplitContainer.BackColor = System.Drawing.Color.WhiteSmoke;
        this.mainWndSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.mainWndSplitContainer.Location = new System.Drawing.Point(0, 31);
        this.mainWndSplitContainer.Name = "mainWndSplitContainer";
        // 
        // mainWndSplitContainer.Panel1
        // 
        this.mainWndSplitContainer.Panel1.Controls.Add(this.ctrlsTab);
        // 
        // mainWndSplitContainer.Panel2
        // 
        this.mainWndSplitContainer.Panel2.Controls.Add(this.subWndSplitContainer);
        this.mainWndSplitContainer.Size = new System.Drawing.Size(1003, 608);
        this.mainWndSplitContainer.SplitterDistance = 199;
        this.mainWndSplitContainer.TabIndex = 0;
        this.mainWndSplitContainer.Text = "mainWndSplitContainer";
        // 
        // ctrlsTab
        // 
        this.ctrlsTab.Controls.Add(this.tabPage1);
        this.ctrlsTab.Controls.Add(this.tabPage2);
        this.ctrlsTab.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ctrlsTab.ItemSize = new System.Drawing.Size(59, 20);
        this.ctrlsTab.Location = new System.Drawing.Point(0, 0);
        this.ctrlsTab.Name = "ctrlsTab";
        this.ctrlsTab.SelectedIndex = 0;
        this.ctrlsTab.Size = new System.Drawing.Size(199, 608);
        this.ctrlsTab.TabIndex = 1;
        this.ctrlsTab.Text = "ctrlsTab";
        this.ctrlsTab.SelectedIndexChanged += new System.EventHandler(this.ctrlsTab_SelectedIndexChanged);
        // 
        // tabPage1
        // 
        this.tabPage1.BackColor = System.Drawing.Color.Transparent;
        this.tabPage1.Controls.Add(this.ctrlLstBox);
        this.tabPage1.Location = new System.Drawing.Point(4, 24);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Size = new System.Drawing.Size(191, 580);
        this.tabPage1.TabIndex = 2;
        this.tabPage1.Text = "ToolsBox";
        // 
        // ctrlLstBox
        // 
        this.ctrlLstBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ctrlLstBox.FormattingEnabled = true;
        this.ctrlLstBox.ItemHeight = 12;
        this.ctrlLstBox.Location = new System.Drawing.Point(0, 0);
        this.ctrlLstBox.Name = "ctrlLstBox";
        this.ctrlLstBox.Size = new System.Drawing.Size(191, 580);
        this.ctrlLstBox.TabIndex = 3;
        // 
        // tabPage2
        // 
        this.tabPage2.BackColor = System.Drawing.Color.Transparent;
        this.tabPage2.Controls.Add(this.ctrlTreeView);
        this.tabPage2.Location = new System.Drawing.Point(4, 24);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Size = new System.Drawing.Size(191, 580);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "TreeView";
        // 
        // ctrlTreeView
        // 
        this.ctrlTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ctrlTreeView.ItemHeight = 18;
        this.ctrlTreeView.Location = new System.Drawing.Point(0, 0);
        this.ctrlTreeView.Name = "ctrlTreeView";
        this.ctrlTreeView.Size = new System.Drawing.Size(191, 580);
        this.ctrlTreeView.TabIndex = 5;
        this.ctrlTreeView.Text = "ctrlTreeView";
        this.ctrlTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ctrlTreeView_AfterSelect);
        // 
        // subWndSplitContainer
        // 
        this.subWndSplitContainer.BackColor = System.Drawing.Color.WhiteSmoke;
        this.subWndSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.subWndSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.subWndSplitContainer.Location = new System.Drawing.Point(0, 0);
        this.subWndSplitContainer.Name = "subWndSplitContainer";
        // 
        // subWndSplitContainer.Panel1
        // 
        this.subWndSplitContainer.Panel1.Controls.Add(this.designTab);
        // 
        // subWndSplitContainer.Panel2
        // 
        this.subWndSplitContainer.Panel2.Controls.Add(this.tabControl1);
        this.subWndSplitContainer.Panel2.Controls.Add(this.nameTxtBox);
        this.subWndSplitContainer.Panel2.Controls.Add(this.label1);
        this.subWndSplitContainer.Size = new System.Drawing.Size(800, 608);
        this.subWndSplitContainer.SplitterDistance = 527;
        this.subWndSplitContainer.TabIndex = 6;
        this.subWndSplitContainer.Text = "subWndSplitContainer";
        // 
        // designTab
        // 
        this.designTab.Controls.Add(this.designPage);
        this.designTab.Controls.Add(this.sourcePage);
        this.designTab.Dock = System.Windows.Forms.DockStyle.Fill;
        this.designTab.ItemSize = new System.Drawing.Size(54, 20);
        this.designTab.Location = new System.Drawing.Point(0, 0);
        this.designTab.Name = "designTab";
        this.designTab.SelectedIndex = 0;
        this.designTab.Size = new System.Drawing.Size(527, 608);
        this.designTab.TabIndex = 1;
        this.designTab.Text = "designTab";
        this.designTab.SelectedIndexChanged += new System.EventHandler(this.designTab_SelectedIndexChanged);
        // 
        // designPage
        // 
        this.designPage.AutoScroll = true;
        this.designPage.BackColor = System.Drawing.Color.Transparent;
        this.designPage.Controls.Add(this.designSplitContainer);
        this.designPage.Location = new System.Drawing.Point(4, 24);
        this.designPage.Name = "designPage";
        this.designPage.Size = new System.Drawing.Size(519, 580);
        this.designPage.TabIndex = 8;
        this.designPage.Text = "Design";
        // 
        // designSplitContainer
        // 
        this.designSplitContainer.BackColor = System.Drawing.Color.Transparent;
        this.designSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.designSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
        this.designSplitContainer.Location = new System.Drawing.Point(0, 0);
        this.designSplitContainer.Name = "designSplitContainer";
        this.designSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
        // 
        // designSplitContainer.Panel2
        // 
        this.designSplitContainer.Panel2.Controls.Add(this.otherCtlPanel);
        this.designSplitContainer.Size = new System.Drawing.Size(519, 580);
        this.designSplitContainer.SplitterDistance = 467;
        this.designSplitContainer.TabIndex = 22;
        this.designSplitContainer.Text = "SplitContainer2";
        // 
        // otherCtlPanel
        // 
        this.otherCtlPanel.AutoScroll = true;
        this.otherCtlPanel.BackColor = System.Drawing.Color.White;
        this.otherCtlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.otherCtlPanel.Location = new System.Drawing.Point(0, 0);
        this.otherCtlPanel.Name = "otherCtlPanel";
        this.otherCtlPanel.Size = new System.Drawing.Size(519, 109);
        this.otherCtlPanel.TabIndex = 23;
        this.otherCtlPanel.Text = "FlowLayoutPanel0";
        // 
        // sourcePage
        // 
        this.sourcePage.BackColor = System.Drawing.Color.Transparent;
        this.sourcePage.Controls.Add(this.sourceTxtBox);
        this.sourcePage.Location = new System.Drawing.Point(4, 24);
        this.sourcePage.Name = "sourcePage";
        this.sourcePage.Size = new System.Drawing.Size(519, 580);
        this.sourcePage.TabIndex = 1;
        this.sourcePage.Text = "Source";
        // 
        // sourceTxtBox
        // 
        this.sourceTxtBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.sourceTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.sourceTxtBox.Location = new System.Drawing.Point(0, 0);
        this.sourceTxtBox.Multiline = true;
        this.sourceTxtBox.Name = "sourceTxtBox";
        this.sourceTxtBox.ReadOnly = true;
        this.sourceTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
        this.sourceTxtBox.Size = new System.Drawing.Size(519, 580);
        this.sourceTxtBox.TabIndex = 10;
        this.sourceTxtBox.Text = "TextBox0";
        this.sourceTxtBox.WordWrap = false;
        // 
        // tabControl1
        // 
        this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.tabControl1.Controls.Add(this.tabPage3);
        this.tabControl1.Controls.Add(this.tabPage4);
        this.tabControl1.ItemSize = new System.Drawing.Size(57, 20);
        this.tabControl1.Location = new System.Drawing.Point(4, 32);
        this.tabControl1.Name = "tabControl1";
        this.tabControl1.SelectedIndex = 0;
        this.tabControl1.Size = new System.Drawing.Size(269, 600);
        this.tabControl1.TabIndex = 15;
        this.tabControl1.Text = "TabControl2";
        // 
        // tabPage3
        // 
        this.tabPage3.BackColor = System.Drawing.Color.Transparent;
        this.tabPage3.Controls.Add(this.propertyBox);
        this.tabPage3.Location = new System.Drawing.Point(4, 24);
        this.tabPage3.Name = "tabPage3";
        this.tabPage3.Size = new System.Drawing.Size(261, 572);
        this.tabPage3.TabIndex = 16;
        this.tabPage3.Text = "Property";
        // 
        // propertyBox
        // 
        this.propertyBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.propertyBox.Location = new System.Drawing.Point(0, 0);
        this.propertyBox.Name = "propertyBox";
        this.propertyBox.Size = new System.Drawing.Size(261, 572);
        this.propertyBox.TabIndex = 19;
        // 
        // tabPage4
        // 
        this.tabPage4.Location = new System.Drawing.Point(4, 24);
        this.tabPage4.Name = "tabPage4";
        this.tabPage4.Size = new System.Drawing.Size(261, 572);
        this.tabPage4.TabIndex = 20;
        this.tabPage4.Text = "Event";
        // 
        // nameTxtBox
        // 
        this.nameTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.nameTxtBox.Location = new System.Drawing.Point(58, 6);
        this.nameTxtBox.Name = "nameTxtBox";
        this.nameTxtBox.Size = new System.Drawing.Size(206, 21);
        this.nameTxtBox.TabIndex = 2;
        this.nameTxtBox.Text = "TextBox3";
        this.nameTxtBox.TextChanged += new System.EventHandler(this.nameTxtBox_TextChanged);
        //this.nameTxtBox.LostFocus += new System.EventHandler(this.nameTxtBox_LostFocus);
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Location = new System.Drawing.Point(8, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(29, 12);
        this.label1.TabIndex = 1;
        this.label1.Text = "Name";
        // 
        // statusStrip1
        // 
        this.statusStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
        this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.statusStrip1.Location = new System.Drawing.Point(0, 642);
        this.statusStrip1.Name = "statusStrip1";
        this.statusStrip1.Size = new System.Drawing.Size(1003, 22);
        this.statusStrip1.TabIndex = 1;
        this.statusStrip1.Text = "statusStrip1";
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.WhiteSmoke;
        this.ClientSize = new System.Drawing.Size(1003, 664);
        this.Controls.Add(this.mainWndSplitContainer);
        this.Controls.Add(this.statusStrip1);
        this.KeyPreview = true;
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "SWD4CS";
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
        this.mainWndSplitContainer.Panel1.ResumeLayout(false);
        this.mainWndSplitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.mainWndSplitContainer)).EndInit();
        this.mainWndSplitContainer.ResumeLayout(false);
        this.ctrlsTab.ResumeLayout(false);
        this.tabPage1.ResumeLayout(false);
        this.tabPage2.ResumeLayout(false);
        this.subWndSplitContainer.Panel1.ResumeLayout(false);
        this.subWndSplitContainer.Panel2.ResumeLayout(false);
        this.subWndSplitContainer.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.subWndSplitContainer)).EndInit();
        this.subWndSplitContainer.ResumeLayout(false);
        this.designTab.ResumeLayout(false);
        this.designPage.ResumeLayout(false);
        this.designSplitContainer.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.designSplitContainer)).EndInit();
        this.designSplitContainer.ResumeLayout(false);
        this.sourcePage.ResumeLayout(false);
        this.sourcePage.PerformLayout();
        this.tabControl1.ResumeLayout(false);
        this.tabPage3.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();

    } 

    #endregion 

    private System.Windows.Forms.SplitContainer mainWndSplitContainer;
    private System.Windows.Forms.TabControl ctrlsTab;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.ListBox ctrlLstBox;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TreeView ctrlTreeView;
    private System.Windows.Forms.SplitContainer subWndSplitContainer;
    private System.Windows.Forms.TabControl designTab;
    private System.Windows.Forms.TabPage designPage;
    private System.Windows.Forms.TabPage sourcePage;
    private System.Windows.Forms.TextBox sourceTxtBox;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TextBox nameTxtBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PropertyGrid propertyBox;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.SplitContainer designSplitContainer;
    private System.Windows.Forms.FlowLayoutPanel otherCtlPanel;
}

// private void ctrlsTab_SelectedIndexChanged(System.Object? sender, System.EventArgs e)
// {
// 
// }

// private void ctrlTreeView_AfterSelect(System.Object? sender, System.Windows.Forms.TreeViewEventArgs e)
// {
// 
// }

// private void designTab_SelectedIndexChanged(System.Object? sender, System.EventArgs e)
// {
// 
// }

// private void nameTxtBox_TextChanged(System.Object? sender, System.EventArgs e)
// {
// 
// }

// private void MainForm_KeyDown(System.Object? sender, System.Windows.Forms.KeyEventArgs e)
// {
//
// }

