namespace Proiect_Admitere_Facultate
{
    partial class AdmitereFaculate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdmitereFaculate));
            this.lvCandidati = new System.Windows.Forms.ListView();
            this.Nume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prenume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Facultate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NotaBac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NotaAdmitere = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MedieFinala = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsCandidati = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evidentiareStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdaugareCandidat = new System.Windows.Forms.Button();
            this.btnModificareCandidat = new System.Windows.Forms.Button();
            this.btnStergereCandidat = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimareRaportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.iesireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candidatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugareCandidatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificareCandidatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stergereCandidatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vizualizareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortareDupaMedieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afisareAdmisiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facultateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adaugaFacultateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afisareFacultatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vizualizareGraficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFac = new System.Windows.Forms.ComboBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblNrCandidati = new System.Windows.Forms.ToolStripStatusLabel();
            this.resetareStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCandidati.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvCandidati
            // 
            this.lvCandidati.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nume,
            this.Prenume,
            this.Facultate,
            this.NotaBac,
            this.NotaAdmitere,
            this.MedieFinala,
            this.Status});
            this.lvCandidati.ContextMenuStrip = this.cmsCandidati;
            this.lvCandidati.FullRowSelect = true;
            this.lvCandidati.GridLines = true;
            this.lvCandidati.HideSelection = false;
            this.lvCandidati.Location = new System.Drawing.Point(30, 106);
            this.lvCandidati.MultiSelect = false;
            this.lvCandidati.Name = "lvCandidati";
            this.lvCandidati.Size = new System.Drawing.Size(797, 219);
            this.lvCandidati.TabIndex = 0;
            this.lvCandidati.UseCompatibleStateImageBehavior = false;
            this.lvCandidati.View = System.Windows.Forms.View.Details;
            // 
            // Nume
            // 
            this.Nume.Text = "Nume";
            this.Nume.Width = 78;
            // 
            // Prenume
            // 
            this.Prenume.Text = "Prenume";
            this.Prenume.Width = 78;
            // 
            // Facultate
            // 
            this.Facultate.Text = "Facultate";
            this.Facultate.Width = 110;
            // 
            // NotaBac
            // 
            this.NotaBac.Text = "Nota Bac";
            this.NotaBac.Width = 73;
            // 
            // NotaAdmitere
            // 
            this.NotaAdmitere.Text = "Nota Admitere";
            this.NotaAdmitere.Width = 98;
            // 
            // MedieFinala
            // 
            this.MedieFinala.Text = "Medie Finala";
            this.MedieFinala.Width = 99;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 72;
            // 
            // cmsCandidati
            // 
            this.cmsCandidati.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsCandidati.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificaToolStripMenuItem,
            this.stergeToolStripMenuItem,
            this.evidentiareStatusToolStripMenuItem,
            this.resetareStatusToolStripMenuItem});
            this.cmsCandidati.Name = "cmsCandidati";
            this.cmsCandidati.Size = new System.Drawing.Size(211, 128);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.modificaToolStripMenuItem.Text = "Modifica";
            this.modificaToolStripMenuItem.Click += new System.EventHandler(this.modificaToolStripMenuItem_Click);
            // 
            // stergeToolStripMenuItem
            // 
            this.stergeToolStripMenuItem.Name = "stergeToolStripMenuItem";
            this.stergeToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.stergeToolStripMenuItem.Text = "Sterge";
            this.stergeToolStripMenuItem.Click += new System.EventHandler(this.stergeToolStripMenuItem_Click);
            // 
            // evidentiareStatusToolStripMenuItem
            // 
            this.evidentiareStatusToolStripMenuItem.Name = "evidentiareStatusToolStripMenuItem";
            this.evidentiareStatusToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.evidentiareStatusToolStripMenuItem.Text = "Evidentiare Status";
            this.evidentiareStatusToolStripMenuItem.Click += new System.EventHandler(this.evidentiareStatusToolStripMenuItem_Click);
            // 
            // btnAdaugareCandidat
            // 
            this.btnAdaugareCandidat.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAdaugareCandidat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdaugareCandidat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdaugareCandidat.ForeColor = System.Drawing.Color.White;
            this.btnAdaugareCandidat.Location = new System.Drawing.Point(30, 351);
            this.btnAdaugareCandidat.Name = "btnAdaugareCandidat";
            this.btnAdaugareCandidat.Size = new System.Drawing.Size(155, 44);
            this.btnAdaugareCandidat.TabIndex = 1;
            this.btnAdaugareCandidat.Text = "Adaugare Candidat";
            this.btnAdaugareCandidat.UseVisualStyleBackColor = false;
            this.btnAdaugareCandidat.Click += new System.EventHandler(this.btnAdaugareCandidat_Click);
            // 
            // btnModificareCandidat
            // 
            this.btnModificareCandidat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnModificareCandidat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificareCandidat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificareCandidat.ForeColor = System.Drawing.Color.White;
            this.btnModificareCandidat.Location = new System.Drawing.Point(343, 351);
            this.btnModificareCandidat.Name = "btnModificareCandidat";
            this.btnModificareCandidat.Size = new System.Drawing.Size(155, 44);
            this.btnModificareCandidat.TabIndex = 2;
            this.btnModificareCandidat.Text = "Modificare Candidat";
            this.btnModificareCandidat.UseVisualStyleBackColor = false;
            this.btnModificareCandidat.Click += new System.EventHandler(this.btnModificareCandidat_Click);
            // 
            // btnStergereCandidat
            // 
            this.btnStergereCandidat.BackColor = System.Drawing.Color.IndianRed;
            this.btnStergereCandidat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStergereCandidat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStergereCandidat.ForeColor = System.Drawing.Color.White;
            this.btnStergereCandidat.Location = new System.Drawing.Point(672, 351);
            this.btnStergereCandidat.Name = "btnStergereCandidat";
            this.btnStergereCandidat.Size = new System.Drawing.Size(155, 44);
            this.btnStergereCandidat.TabIndex = 3;
            this.btnStergereCandidat.Text = "Stergere Candidat";
            this.btnStergereCandidat.UseVisualStyleBackColor = false;
            this.btnStergereCandidat.Click += new System.EventHandler(this.btnStergereCandidat_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.candidatiToolStripMenuItem,
            this.vizualizareToolStripMenuItem,
            this.facultateToolStripMenuItem,
            this.graficToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtToolStripMenuItem,
            this.binToolStripMenuItem,
            this.exportXMLToolStripMenuItem,
            this.importXMLToolStripMenuItem,
            this.imprimareRaportToolStripMenuItem,
            this.toolStripSeparator2,
            this.iesireToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.fileToolStripMenuItem.Text = "Fisier";
            // 
            // txtToolStripMenuItem
            // 
            this.txtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.txtToolStripMenuItem.Name = "txtToolStripMenuItem";
            this.txtToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.txtToolStripMenuItem.Text = "Txt";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // binToolStripMenuItem
            // 
            this.binToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.openToolStripMenuItem1});
            this.binToolStripMenuItem.Name = "binToolStripMenuItem";
            this.binToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.binToolStripMenuItem.Text = "Bin";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // exportXMLToolStripMenuItem
            // 
            this.exportXMLToolStripMenuItem.Name = "exportXMLToolStripMenuItem";
            this.exportXMLToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.exportXMLToolStripMenuItem.Text = "Export XML";
            this.exportXMLToolStripMenuItem.Click += new System.EventHandler(this.exportXMLToolStripMenuItem_Click);
            // 
            // importXMLToolStripMenuItem
            // 
            this.importXMLToolStripMenuItem.Name = "importXMLToolStripMenuItem";
            this.importXMLToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.importXMLToolStripMenuItem.Text = "Import XML";
            this.importXMLToolStripMenuItem.Click += new System.EventHandler(this.importXMLToolStripMenuItem_Click);
            // 
            // imprimareRaportToolStripMenuItem
            // 
            this.imprimareRaportToolStripMenuItem.Name = "imprimareRaportToolStripMenuItem";
            this.imprimareRaportToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.imprimareRaportToolStripMenuItem.Text = "Imprimare Raport";
            this.imprimareRaportToolStripMenuItem.Click += new System.EventHandler(this.imprimareRaportToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // iesireToolStripMenuItem
            // 
            this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
            this.iesireToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.iesireToolStripMenuItem.Text = "Iesire";
            this.iesireToolStripMenuItem.Click += new System.EventHandler(this.iesireToolStripMenuItem_Click);
            // 
            // candidatiToolStripMenuItem
            // 
            this.candidatiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugareCandidatToolStripMenuItem,
            this.modificareCandidatToolStripMenuItem,
            this.stergereCandidatToolStripMenuItem});
            this.candidatiToolStripMenuItem.Name = "candidatiToolStripMenuItem";
            this.candidatiToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.candidatiToolStripMenuItem.Text = "Editare";
            // 
            // adaugareCandidatToolStripMenuItem
            // 
            this.adaugareCandidatToolStripMenuItem.Name = "adaugareCandidatToolStripMenuItem";
            this.adaugareCandidatToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.adaugareCandidatToolStripMenuItem.Text = "Adaugare candidat";
            this.adaugareCandidatToolStripMenuItem.Click += new System.EventHandler(this.adaugareCandidatToolStripMenuItem_Click);
            // 
            // modificareCandidatToolStripMenuItem
            // 
            this.modificareCandidatToolStripMenuItem.Name = "modificareCandidatToolStripMenuItem";
            this.modificareCandidatToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.modificareCandidatToolStripMenuItem.Text = "Modificare candidat";
            this.modificareCandidatToolStripMenuItem.Click += new System.EventHandler(this.modificareCandidatToolStripMenuItem_Click);
            // 
            // stergereCandidatToolStripMenuItem
            // 
            this.stergereCandidatToolStripMenuItem.Name = "stergereCandidatToolStripMenuItem";
            this.stergereCandidatToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.stergereCandidatToolStripMenuItem.Text = "Stergere candidat";
            this.stergereCandidatToolStripMenuItem.Click += new System.EventHandler(this.stergereCandidatToolStripMenuItem_Click);
            // 
            // vizualizareToolStripMenuItem
            // 
            this.vizualizareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortareDupaMedieToolStripMenuItem,
            this.afisareAdmisiToolStripMenuItem});
            this.vizualizareToolStripMenuItem.Name = "vizualizareToolStripMenuItem";
            this.vizualizareToolStripMenuItem.Size = new System.Drawing.Size(95, 24);
            this.vizualizareToolStripMenuItem.Text = "Vizualizare";
            // 
            // sortareDupaMedieToolStripMenuItem
            // 
            this.sortareDupaMedieToolStripMenuItem.Name = "sortareDupaMedieToolStripMenuItem";
            this.sortareDupaMedieToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sortareDupaMedieToolStripMenuItem.Text = "Sortare dupa medie";
            this.sortareDupaMedieToolStripMenuItem.Click += new System.EventHandler(this.sortareDupaMedieToolStripMenuItem_Click);
            // 
            // afisareAdmisiToolStripMenuItem
            // 
            this.afisareAdmisiToolStripMenuItem.Name = "afisareAdmisiToolStripMenuItem";
            this.afisareAdmisiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.afisareAdmisiToolStripMenuItem.Text = "Afisare admisi";
            this.afisareAdmisiToolStripMenuItem.Click += new System.EventHandler(this.afisareAdmisiToolStripMenuItem_Click);
            // 
            // facultateToolStripMenuItem
            // 
            this.facultateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adaugaFacultateToolStripMenuItem,
            this.afisareFacultatiToolStripMenuItem});
            this.facultateToolStripMenuItem.Name = "facultateToolStripMenuItem";
            this.facultateToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.facultateToolStripMenuItem.Text = "Facultate";
            // 
            // adaugaFacultateToolStripMenuItem
            // 
            this.adaugaFacultateToolStripMenuItem.Name = "adaugaFacultateToolStripMenuItem";
            this.adaugaFacultateToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.adaugaFacultateToolStripMenuItem.Text = "Adauga facultate";
            this.adaugaFacultateToolStripMenuItem.Click += new System.EventHandler(this.adaugaFacultateToolStripMenuItem_Click);
            // 
            // afisareFacultatiToolStripMenuItem
            // 
            this.afisareFacultatiToolStripMenuItem.Name = "afisareFacultatiToolStripMenuItem";
            this.afisareFacultatiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.afisareFacultatiToolStripMenuItem.Text = "Afisare facultati";
            this.afisareFacultatiToolStripMenuItem.Click += new System.EventHandler(this.afisareFacultatiToolStripMenuItem_Click);
            // 
            // graficToolStripMenuItem
            // 
            this.graficToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vizualizareGraficToolStripMenuItem});
            this.graficToolStripMenuItem.Name = "graficToolStripMenuItem";
            this.graficToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.graficToolStripMenuItem.Text = "Grafic";
            // 
            // vizualizareGraficToolStripMenuItem
            // 
            this.vizualizareGraficToolStripMenuItem.Name = "vizualizareGraficToolStripMenuItem";
            this.vizualizareGraficToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.vizualizareGraficToolStripMenuItem.Text = "Vizualizare Grafic";
            this.vizualizareGraficToolStripMenuItem.Click += new System.EventHandler(this.vizualizareGraficToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Facultate:";
            // 
            // cmbFac
            // 
            this.cmbFac.FormattingEnabled = true;
            this.cmbFac.Location = new System.Drawing.Point(83, 51);
            this.cmbFac.Name = "cmbFac";
            this.cmbFac.Size = new System.Drawing.Size(156, 24);
            this.cmbFac.TabIndex = 7;
            this.cmbFac.SelectedIndexChanged += new System.EventHandler(this.cmbFac_SelectedIndexChanged);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblNrCandidati});
            this.statusStrip1.Location = new System.Drawing.Point(0, 449);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(872, 26);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblNrCandidati
            // 
            this.lblNrCandidati.Name = "lblNrCandidati";
            this.lblNrCandidati.Size = new System.Drawing.Size(26, 20);
            this.lblNrCandidati.Text = "lbl";
            // 
            // resetareStatusToolStripMenuItem
            // 
            this.resetareStatusToolStripMenuItem.Name = "resetareStatusToolStripMenuItem";
            this.resetareStatusToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.resetareStatusToolStripMenuItem.Text = "Resetare Status";
            this.resetareStatusToolStripMenuItem.Click += new System.EventHandler(this.resetareStatusToolStripMenuItem_Click);
            // 
            // AdmitereFaculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(872, 475);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmbFac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStergereCandidat);
            this.Controls.Add(this.btnModificareCandidat);
            this.Controls.Add(this.btnAdaugareCandidat);
            this.Controls.Add(this.lvCandidati);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdmitereFaculate";
            this.Text = "Admitere Facultate";
            this.Load += new System.EventHandler(this.AdmitereFaculate_Load);
            this.cmsCandidati.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvCandidati;
        private System.Windows.Forms.ColumnHeader Nume;
        private System.Windows.Forms.ColumnHeader Prenume;
        private System.Windows.Forms.ColumnHeader Facultate;
        private System.Windows.Forms.ColumnHeader NotaBac;
        private System.Windows.Forms.ColumnHeader NotaAdmitere;
        private System.Windows.Forms.ColumnHeader MedieFinala;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Button btnAdaugareCandidat;
        private System.Windows.Forms.Button btnModificareCandidat;
        private System.Windows.Forms.Button btnStergereCandidat;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem candidatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugareCandidatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificareCandidatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergereCandidatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vizualizareToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem iesireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortareDupaMedieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afisareAdmisiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facultateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adaugaFacultateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afisareFacultatiToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFac;
        private System.Windows.Forms.ContextMenuStrip cmsCandidati;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stergeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evidentiareStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graficToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vizualizareGraficToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimareRaportToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblNrCandidati;
        private System.Windows.Forms.ToolStripMenuItem exportXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetareStatusToolStripMenuItem;
    }
}

