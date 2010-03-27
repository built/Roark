using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WindowsFormsApplication1.Renderers;

namespace WindowsFormsApplication1
{
    public partial class MainEditor : Form
    {
        string templateFilename = Application.StartupPath + "\\output_template.html";
       
        string currentFilename = "";

        public MainEditor()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFilename != "")
            {
                Save(currentFilename);
            }
            else if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFilename = this.saveFileDialog1.FileName;

                ShowFilenameInApplicationTitlebar(currentFilename);

                Save(this.saveFileDialog1.FileName);
            }
        }

        private void ShowFilenameInApplicationTitlebar(string filename)
        {
            this.Text = "Roark - [" + filename + "]";
        }

        private void Save(string filename)
        {
            string template = LoadTemplate(templateFilename);

            ICanRenderHtml renderer = RenderFactory.Create(designBoard1.RenderMode);

            File.WriteAllText( filename, renderer.Render(template, designBoard1.Divs) );
        }

        private string LoadTemplate(string templateFilename)
        {
            string template = "";

            try
            {
                if (File.Exists(templateFilename))
                {
                    template = File.ReadAllText(templateFilename);
                }
                else
                    throw new FileNotFoundException("Template file not found.", templateFilename);
            }
            catch
            {
                this.toolStripStatusLabel1.Text = string.Format("Can't find template at {0}. Proceeding without it. Output may suck!", templateFilename);
            }
            return template;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "Click and drag anywhere on grid to draw a DIV.";
        }

        private void hardcodedPositionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllRenderModes();

            this.hardcodedPositionsToolStripMenuItem.Checked = true;
            this.designBoard1.RenderMode = RenderModes.Hardcode;
        }

        private void blueprintCSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllRenderModes();

            this.blueprintCSSToolStripMenuItem.Checked = true;
            this.designBoard1.RenderMode = RenderModes.Blueprint;

            // Enforce the grid on the design board. Further, protect that in the menu system.
            this.alignDivsToGridToolStripMenuItem.Checked = true;
            this.alignDivsToGridToolStripMenuItem.Enabled = false;
            this.designBoard1.UseGridAlignment = true;
        }

        protected void UncheckAllRenderModes()
        {
            this.blueprintCSSToolStripMenuItem.Checked = false;
            this.hardcodedPositionsToolStripMenuItem.Checked = false;
            this.pureSemanticMarkupToolStripMenuItem.Checked = false;
        }

        private void pureSemanticMarkupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllRenderModes();

            this.pureSemanticMarkupToolStripMenuItem.Checked = true;
            this.designBoard1.RenderMode = RenderModes.Semantic;

            // If the grid is active go ahead and leave it alone but allow the designer to disable that from the menu.
            this.alignDivsToGridToolStripMenuItem.Enabled = true;
        }

        private void alignDivsToGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.alignDivsToGridToolStripMenuItem.Checked = !this.alignDivsToGridToolStripMenuItem.Checked;

            this.designBoard1.UseGridAlignment = alignDivsToGridToolStripMenuItem.Checked;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutBox = new About();

            // TO DO: Make this stupid thing center. I tried setting the Left and Top
            // but it wouldn't resize until it had been shown. And of course showing it and them moving 
            // it looked stupid. That is the kind of bug that makes me waste time on little details.

            // Right now this just shows up wherever.
            aboutBox.Show();

        }

        private void tracingModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tracingMode = sender as ToolStripMenuItem;

            toggleCheckmark(tracingMode);

            if (tracingMode.Checked)
            {
                this.Opacity = 0.5;
            }
            else
            {
                // Turn off tracing mode.
                this.Opacity = 1;
            }

        }

        private static void toggleCheckmark(ToolStripMenuItem tracingModeItem)
        {
            tracingModeItem.Checked = !tracingModeItem.Checked;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlPanel cp = new ControlPanel();

            cp.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void launchBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TO DO: Have OS launch browser to view current work.");
        }



    }
}
