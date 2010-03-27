namespace WindowsFormsApplication1
{
    partial class MainEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainEditor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.launchBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optiosnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alignToGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tracingPaperModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardcodedPositionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueprintCSSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pureSemanticMarkupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alignDivsToGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tracingModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designBoard1 = new WindowsFormsApplication1.DesignBoard();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.viewToolStripMenuItem1,
            this.toolsToolStripMenuItem1,
            this.helpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchBrowserToolStripMenuItem});
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem1.Text = "View";
            // 
            // launchBrowserToolStripMenuItem
            // 
            this.launchBrowserToolStripMenuItem.Name = "launchBrowserToolStripMenuItem";
            this.launchBrowserToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.launchBrowserToolStripMenuItem.Text = "Launch Browser";
            this.launchBrowserToolStripMenuItem.Click += new System.EventHandler(this.launchBrowserToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem1
            // 
            this.toolsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optiosnToolStripMenuItem,
            this.alignToGridToolStripMenuItem,
            this.tracingPaperModeToolStripMenuItem});
            this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
            this.toolsToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem1.Text = "Tools";
            // 
            // optiosnToolStripMenuItem
            // 
            this.optiosnToolStripMenuItem.Name = "optiosnToolStripMenuItem";
            this.optiosnToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optiosnToolStripMenuItem.Text = "Options";
            this.optiosnToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // alignToGridToolStripMenuItem
            // 
            this.alignToGridToolStripMenuItem.Name = "alignToGridToolStripMenuItem";
            this.alignToGridToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.alignToGridToolStripMenuItem.Text = "Align To Grid";
            this.alignToGridToolStripMenuItem.Click += new System.EventHandler(this.alignDivsToGridToolStripMenuItem_Click);
            // 
            // tracingPaperModeToolStripMenuItem
            // 
            this.tracingPaperModeToolStripMenuItem.Name = "tracingPaperModeToolStripMenuItem";
            this.tracingPaperModeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tracingPaperModeToolStripMenuItem.Text = "Tracing Mode";
            this.tracingPaperModeToolStripMenuItem.Click += new System.EventHandler(this.tracingModeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hardcodedPositionsToolStripMenuItem,
            this.blueprintCSSToolStripMenuItem,
            this.pureSemanticMarkupToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // hardcodedPositionsToolStripMenuItem
            // 
            this.hardcodedPositionsToolStripMenuItem.Checked = true;
            this.hardcodedPositionsToolStripMenuItem.CheckOnClick = true;
            this.hardcodedPositionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hardcodedPositionsToolStripMenuItem.Name = "hardcodedPositionsToolStripMenuItem";
            this.hardcodedPositionsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.hardcodedPositionsToolStripMenuItem.Text = "Hardcoded Positions (No CSS)";
            this.hardcodedPositionsToolStripMenuItem.Click += new System.EventHandler(this.hardcodedPositionsToolStripMenuItem_Click);
            // 
            // blueprintCSSToolStripMenuItem
            // 
            this.blueprintCSSToolStripMenuItem.Enabled = false;
            this.blueprintCSSToolStripMenuItem.Name = "blueprintCSSToolStripMenuItem";
            this.blueprintCSSToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.blueprintCSSToolStripMenuItem.Text = "Use Blueprint CSS";
            this.blueprintCSSToolStripMenuItem.Click += new System.EventHandler(this.blueprintCSSToolStripMenuItem_Click);
            // 
            // pureSemanticMarkupToolStripMenuItem
            // 
            this.pureSemanticMarkupToolStripMenuItem.Name = "pureSemanticMarkupToolStripMenuItem";
            this.pureSemanticMarkupToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.pureSemanticMarkupToolStripMenuItem.Text = "Semantic-ish (CSS separate)";
            this.pureSemanticMarkupToolStripMenuItem.Click += new System.EventHandler(this.pureSemanticMarkupToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // alignDivsToGridToolStripMenuItem
            // 
            this.alignDivsToGridToolStripMenuItem.Name = "alignDivsToGridToolStripMenuItem";
            this.alignDivsToGridToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.alignDivsToGridToolStripMenuItem.Text = "Align Divs To Grid";
            this.alignDivsToGridToolStripMenuItem.Click += new System.EventHandler(this.alignDivsToGridToolStripMenuItem_Click);
            // 
            // tracingModeToolStripMenuItem
            // 
            this.tracingModeToolStripMenuItem.Name = "tracingModeToolStripMenuItem";
            this.tracingModeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.tracingModeToolStripMenuItem.Text = "Tracing Mode";
            this.tracingModeToolStripMenuItem.Click += new System.EventHandler(this.tracingModeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "HTML files|*.htm*";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 519);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(982, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // designBoard1
            // 
            this.designBoard1.BackColor = System.Drawing.SystemColors.Window;
            this.designBoard1.Location = new System.Drawing.Point(10, 27);
            this.designBoard1.Name = "designBoard1";
            this.designBoard1.Size = new System.Drawing.Size(960, 800);
            this.designBoard1.TabIndex = 0;
            this.designBoard1.UseGridAlignment = false;
            // 
            // MainEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(982, 541);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.designBoard1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Roark - Web Layout Drafting Table";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DesignBoard designBoard1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardcodedPositionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueprintCSSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pureSemanticMarkupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alignDivsToGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tracingModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optiosnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem alignToGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tracingPaperModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchBrowserToolStripMenuItem;




    }
}

