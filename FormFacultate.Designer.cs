namespace Proiect_Admitere_Facultate
{
    partial class FormFacultate
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDenumire = new System.Windows.Forms.TextBox();
            this.tbNrLocuri = new System.Windows.Forms.TextBox();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnAnulare = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Denumire:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numar Locuri:";
            // 
            // tbDenumire
            // 
            this.tbDenumire.Location = new System.Drawing.Point(145, 61);
            this.tbDenumire.Name = "tbDenumire";
            this.tbDenumire.Size = new System.Drawing.Size(100, 22);
            this.tbDenumire.TabIndex = 0;
            // 
            // tbNrLocuri
            // 
            this.tbNrLocuri.Location = new System.Drawing.Point(145, 111);
            this.tbNrLocuri.Name = "tbNrLocuri";
            this.tbNrLocuri.Size = new System.Drawing.Size(100, 22);
            this.tbNrLocuri.TabIndex = 1;
            // 
            // btnSalvare
            // 
            this.btnSalvare.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSalvare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvare.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvare.ForeColor = System.Drawing.Color.White;
            this.btnSalvare.Location = new System.Drawing.Point(51, 186);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(86, 33);
            this.btnSalvare.TabIndex = 2;
            this.btnSalvare.Text = "Salveaza";
            this.btnSalvare.UseVisualStyleBackColor = false;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // btnAnulare
            // 
            this.btnAnulare.BackColor = System.Drawing.Color.LightGray;
            this.btnAnulare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnulare.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnulare.Location = new System.Drawing.Point(159, 186);
            this.btnAnulare.Name = "btnAnulare";
            this.btnAnulare.Size = new System.Drawing.Size(86, 33);
            this.btnAnulare.TabIndex = 3;
            this.btnAnulare.Text = "Anuleaza";
            this.btnAnulare.UseVisualStyleBackColor = false;
            this.btnAnulare.Click += new System.EventHandler(this.btnAnulare_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormFacultate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(303, 255);
            this.Controls.Add(this.btnAnulare);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.tbNrLocuri);
            this.Controls.Add(this.tbDenumire);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormFacultate";
            this.Text = "Facultate";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDenumire;
        private System.Windows.Forms.TextBox tbNrLocuri;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button btnAnulare;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}