namespace Proiect_Admitere_Facultate
{
    partial class FormGrafic
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
            this.panelGrafic = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelGrafic
            // 
            this.panelGrafic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrafic.Location = new System.Drawing.Point(0, 0);
            this.panelGrafic.Name = "panelGrafic";
            this.panelGrafic.Size = new System.Drawing.Size(800, 450);
            this.panelGrafic.TabIndex = 0;
            this.panelGrafic.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGrafic_Paint);
            // 
            // FormGrafic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelGrafic);
            this.Name = "FormGrafic";
            this.Text = "FormGrafic";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGrafic;
    }
}