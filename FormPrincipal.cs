using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Serialization;

namespace Proiect_Admitere_Facultate
{
    public partial class AdmitereFaculate : Form
    {
        List<Candidat> candidati = new List<Candidat>();
        List<Facultate> facultatiDisponibile = new List<Facultate>();

        private int candidatCurentIndice = 0;

        DatabaseManager db = new DatabaseManager();

        BindingSource bsFacultati = new BindingSource();
        public AdmitereFaculate()
        {
            InitializeComponent();
            facultatiDisponibile.Add(new Facultate("Toate", 0));
            facultatiDisponibile.Add(new Facultate("CSIE", 4));
            facultatiDisponibile.Add(new Facultate("Marketing", 5));

            bsFacultati.DataSource = facultatiDisponibile;

            cmbFac.DataSource = bsFacultati;
            cmbFac.DisplayMember = "Denumire";

           
        }
        private void AdmitereFaculate_Load(object sender, EventArgs e)
        {
            IncarcaDateDinDB();
        }
        private void IncarcaDateDinDB()
        {
            try
            {
                
                var dateDinDB = db.IncarcaCandidati();

                if (dateDinDB != null && dateDinDB.Count > 0)
                {
                    candidati.Clear();
                    candidati.AddRange(dateDinDB);

                   
                    foreach (var c in candidati)
                    {
                        if (!facultatiDisponibile.Any(f => f.Denumire == c.FacultateAleasa))
                        {
                            facultatiDisponibile.Add(new Facultate(c.FacultateAleasa, 10));
                        }
                    }
                    bsFacultati.ResetBindings(false);

                    AfisareInListView();
                    ActualizeazaComboFiltrare();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Atentie! Nu am putut incarca datele din baza de date: " + ex.Message,
                                "Eroare Conexiune", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ActualizeazaComboFiltrare()
        {
            bsFacultati.ResetBindings(false);
            if (cmbFac.Items.Count > 0) cmbFac.SelectedIndex = 0;
        }
        private void AfisareInListView()
        {
            lvCandidati.Items.Clear();

            foreach (Candidat c in candidati)
            {
                ListViewItem item = new ListViewItem(c.Nume);
                item.SubItems.Add(c.Prenume);
                item.SubItems.Add(c.FacultateAleasa);
                item.SubItems.Add(c.MediiExamen.MedieBac.ToString("0.00"));
                item.SubItems.Add(c.MediiExamen.NotaAdmitere.ToString("0.00"));
                item.SubItems.Add(c.MedieCalculata.ToString("0.00"));
                item.SubItems.Add(c.ObtineStatusAdmitere());

                lvCandidati.Items.Add(item);
            }
            
            lblNrCandidati.Text = "Numar candidati afisati: " + lvCandidati.Items.Count.ToString(); 
            
        }

      
        private void btnAdaugareCandidat_Click(object sender, EventArgs e)
        {
            try
            {
                var facultatiReale = facultatiDisponibile.Where(f => f.Denumire != "Toate").ToList();
                FormCandidat frm = new FormCandidat(facultatiReale);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Candidat nou = frm.CandidatCreat;

                   
                    Facultate facSelected = facultatiDisponibile.FirstOrDefault(f => f.Denumire == nou.FacultateAleasa);
                    if (facSelected != null)
                    {
                        int dejaInscrisi = candidati.Count(c => c.FacultateAleasa == nou.FacultateAleasa);
                        if (dejaInscrisi >= facSelected.NrLocuri)
                        {
                            MessageBox.Show($"Locuri insuficiente la {facSelected.Denumire}!\n" + $"Capacitate maxima: {facSelected.NrLocuri} locuri.","Eroare Capacitate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }

                    candidati.Add(nou);
                    db.InserareCandidat(nou);
                    AfisareInListView();

                    MessageBox.Show("Candidat adăugat!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la adăugare: " + ex.Message);
            }
        }

        private void btnModificareCandidat_Click(object sender, EventArgs e)
        {

            try
            {
               
                if (lvCandidati.SelectedItems.Count == 0)
                {
                    
                    MessageBox.Show("Va rugam sa selectati un candidat din lista pentru a-l modifica!", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

              
                string nume = lvCandidati.SelectedItems[0].Text;
                Candidat c = candidati.FirstOrDefault(x => x.Nume == nume);

                if (c == null)
                {
                    MessageBox.Show("Candidatul selectat nu a fost gasit in baza de date.");
                    return;
                }

                string facultateInainte = c.FacultateAleasa;
                var facultatiReale = facultatiDisponibile.Where(f => f.Denumire != "Toate").ToList();
                FormCandidat frm = new FormCandidat(c, facultatiReale);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    db.ActualizeazaCandidat(c, c.CNP);
                    if (c.FacultateAleasa != facultateInainte)
                    {
                        Facultate facNoua = facultatiDisponibile.FirstOrDefault(f => f.Denumire == c.FacultateAleasa);
                        int ocupate = candidati.Count(can => can.FacultateAleasa == c.FacultateAleasa);

                        if (facNoua != null && ocupate > facNoua.NrLocuri)
                        {
                            MessageBox.Show($"Nu mai sunt locuri libere la {facNoua.Denumire}! Revenim la facultatea anterioara.");
                            c.FacultateAleasa = facultateInainte;
                            db.ActualizeazaCandidat(c, c.CNP);
                        }
                    }

                    if (cmbFac.SelectedIndex > 0)
                    {
                        cmbFac_SelectedIndexChanged(sender, e); 
                    }
                    else
                    {
                        AfisareInListView(); 
                    }

                    MessageBox.Show("Candidatul a fost modificat cu succes!", "Succes",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A aparut o eroare la modificare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStergereCandidat_Click(object sender, EventArgs e)
        {
            try
            {
              
                if (lvCandidati.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Va rugam sa selectati candidatul pe care doriti sa il stergeti!", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

             
                DialogResult confirmare = MessageBox.Show("Sunteti sigur că doriti sa stergeti acest candidat?", "Confirmare Stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmare == DialogResult.Yes)
                {
                
                    string numeSelectat = lvCandidati.SelectedItems[0].Text;
                    Candidat deSters = candidati.FirstOrDefault(c => c.Nume == numeSelectat);

                    if (deSters != null)
                    {
                        db.StergeCandidat(deSters.CNP);
                        candidati.Remove(deSters);

                        if (cmbFac.SelectedIndex > 0 && cmbFac.SelectedItem.ToString() != "Toate")
                        {
                            cmbFac_SelectedIndexChanged(sender, e); 
                        }
                        else
                        {
                            AfisareInListView(); 
                        }

                        MessageBox.Show("Candidatul a fost sters cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("A aparut o eroare la stergere: " + ex.Message, "Eroare Critica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "(*.txt)|*.txt";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);

                    foreach (Candidat c in candidati)
                    {
                        sw.WriteLine(c.Export());
                    }

                    sw.Close();
                    MessageBox.Show("Fisier.txt salvat cu succes!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "(*.txt)|*.txt";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    candidati.Clear();
                    lvCandidati.Items.Clear();
                    

                    StreamReader sr = new StreamReader(openFileDialog1.FileName);

                    lvCandidati.Items.Clear();

                    string linie;

                    while ((linie = sr.ReadLine()) != null)
                    {
                        string[] p = linie.Split('|');

                        string nume = p[0];
                        string prenume = p[1];
                        string sex = p[2];
                        string cnp = p[3];
                        DateTime data = DateTime.Parse(p[4]);
                        string domiciliu = p[5];

                        double bac = double.Parse(p[6]);
                        double nota = double.Parse(p[7]);
                        double pb = double.Parse(p[8]);
                        double pa = double.Parse(p[9]);

                        string facultate = p[10];

                        if (!facultatiDisponibile.Any(f => f.Denumire == facultate))
                        {
                            facultatiDisponibile.Add(new Facultate(facultate, 50));
                        }

                        Medii m = new Medii(bac, nota, pb, pa);

                        Candidat c = new Candidat(nume, prenume, sex, cnp, data, domiciliu, m, facultate);

                        candidati.Add(c);
                    }

                    sr.Close();

                    foreach (var cand in db.IncarcaCandidati())
                        { db.StergeCandidat(cand.CNP); }
                    foreach (Candidat c_nou in candidati)
                    {
                        db.InserareCandidat(c_nou);
                    }

                    foreach (var f in facultatiDisponibile)
                    {
                        int nr = candidati.Count(can => can.FacultateAleasa == f.Denumire);
                        if (nr > f.NrLocuri)
                        {
                            MessageBox.Show($"Atentie! Fisierul contine {nr} candidati la {f.Denumire}, depasind limita de {f.NrLocuri} locuri!",
                                            "Supra-aglomerare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    AfisareInListView();
                    ActualizeazaComboFiltrare();

                    MessageBox.Show("Citire TXT realizata cu succes!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("candidati.dat", FileMode.Create, FileAccess.Write);

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, candidati);

                MessageBox.Show("Salvare candidati.dat reusita!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la salvare: " + ex.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream("candidati.dat", FileMode.Open, FileAccess.Read);

                BinaryFormatter bf = new BinaryFormatter();
                List<Candidat> listaNoua = (List<Candidat>)bf.Deserialize(fs);

                candidati.Clear();
                lvCandidati.Items.Clear();
                foreach (var cand in db.IncarcaCandidati()) 
                    { db.StergeCandidat(cand.CNP); }

                foreach (var c in listaNoua)
                {
                    if (!facultatiDisponibile.Any(f => f.Denumire == c.FacultateAleasa))
                    {
                        facultatiDisponibile.Add(new Facultate(c.FacultateAleasa, 50));
                    }
                    candidati.Add(c);
                    db.InserareCandidat(c);
                }

                foreach (var f in facultatiDisponibile)
                {
                    int nr = candidati.Count(can => can.FacultateAleasa == f.Denumire);
                    if (nr > f.NrLocuri)
                    {
                        MessageBox.Show($"Atentie! Datele binare incarcate contin {nr} candidati la {f.Denumire}, " +
                                        $"depasind limita de {f.NrLocuri} locuri!",
                                        "Supra-aglomerare (Binar)", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                AfisareInListView();
                ActualizeazaComboFiltrare();

                MessageBox.Show("Date încărcate cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la citire: " + ex.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }

        private void adaugareCandidatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAdaugareCandidat_Click(sender, e);
        }

        private void modificareCandidatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnModificareCandidat_Click(sender, e);
        }

        private void stergereCandidatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStergereCandidat_Click(sender, e);
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sortareDupaMedieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                candidati.Sort();
                AfisareInListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la sortare: " + ex.Message);
            }

        }

        private void afisareAdmisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
            lvCandidati.Items.Clear();
            foreach (Candidat c in candidati)
            {
         
                if (c.ObtineStatusAdmitere() == "Admis")
                {
                    
                    ListViewItem item = new ListViewItem(c.Nume);
                    item.SubItems.Add(c.Prenume);
                    item.SubItems.Add(c.FacultateAleasa);
                    item.SubItems.Add(c.MediiExamen.MedieBac.ToString("0.00"));
                    item.SubItems.Add(c.MediiExamen.NotaAdmitere.ToString("0.00"));
                    item.SubItems.Add(c.MedieCalculata.ToString("0.00"));
                    item.SubItems.Add(c.ObtineStatusAdmitere());

            
                    item.ForeColor = Color.DarkGreen;

                    lvCandidati.Items.Add(item);
                }
            }

        
            if (lvCandidati.Items.Count == 0)
            {
                MessageBox.Show("Momentan nu exista niciun candidat cu statusul 'Admis' (medie < 6.00).");
            }
        }

        private void adaugaFacultateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFacultate frm = new FormFacultate();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                bsFacultati.Add(frm.FacultateNoua);
                bsFacultati.ResetBindings(false);
                ActualizeazaComboFiltrare();
                MessageBox.Show("Facultatea a fost adaugata în lista!");
            }
        }

        private void afisareFacultatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (facultatiDisponibile.Count == 0)
            {
                MessageBox.Show("Lista de facultati este goala!");
                return;
            }

            
            int totalLocuri = facultatiDisponibile
                .Where(f => f.Denumire != "Toate")
                .Sum(f => f.NrLocuri);

            string text = "Facultați disponibile:\n";

            foreach (var f in facultatiDisponibile)
            {
                if (f.Denumire == "Toate")
                {
                    text += $"- {f.Denumire} (Total Locuri: {totalLocuri})\n";
                }
                else
                {
                    text += $"- {f.Denumire} (Locuri: {f.NrLocuri})\n";
                }
            }

            MessageBox.Show(text, "Info Capacitate");
        }

        private void cmbFac_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbFac.SelectedItem == null) return;
            Facultate facSelectata = (Facultate)cmbFac.SelectedItem;
            string selectie = facSelectata.Denumire;


            if (selectie == "Toate")
            {
                AfisareInListView();
            }
            else
            {
                
                lvCandidati.Items.Clear();
                foreach (Candidat c in candidati)
                {
                    if (c.FacultateAleasa == selectie)
                    {
                        ListViewItem item = new ListViewItem(c.Nume);
                        item.SubItems.Add(c.Prenume);
                        item.SubItems.Add(c.FacultateAleasa);
                        item.SubItems.Add(c.MediiExamen.MedieBac.ToString("0.00"));
                        item.SubItems.Add(c.MediiExamen.NotaAdmitere.ToString("0.00"));
                        item.SubItems.Add(c.MedieCalculata.ToString("0.00"));
                        item.SubItems.Add(c.ObtineStatusAdmitere());

                        lvCandidati.Items.Add(item);
                    }
                }
                lblNrCandidati.Text = "Numar candidati afisati: " + lvCandidati.Items.Count.ToString();
            }

            
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnModificareCandidat_Click(sender, e);
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnStergereCandidat_Click(sender, e);
        }

        private void evidentiareStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvCandidati.Items)
            {
                
                string status = item.SubItems[6].Text;

                if (status == "Admis")
                    item.ForeColor = Color.DarkGreen;
                else if (status == "Respins")
                    item.ForeColor = Color.Red;
            }
        }

        private void vizualizareGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (candidati == null || candidati.Count == 0)
                {
                    MessageBox.Show("Nu exista candidati introdusi pentru a genera graficul!","Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (facultatiDisponibile == null || facultatiDisponibile.Count == 0)
                {
                    MessageBox.Show("Nu exista facultati definite pentru axele graficului!","Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               
                FormGrafic frm = new FormGrafic(candidati, facultatiDisponibile);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show("A aparut o eroare la deschiderea graficului: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimareRaportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (candidati == null || candidati.Count == 0)
                {
                    MessageBox.Show("Nu exista date pentru imprimare!", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                candidatCurentIndice = 0;

                
                printDocument1.DocumentName = "Raport Candidati Admitere";

                
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.WindowState = FormWindowState.Maximized;

                
                printPreviewDialog1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la initializarea imprimarii: " + ex.Message, "Eroare Fatala", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                Font fontTitlu = new Font("Arial", 16, FontStyle.Bold);
                Font fontAntet = new Font("Arial", 10, FontStyle.Bold);
                Font fontText = new Font("Arial", 10);
                Brush pensulaText = Brushes.Black;

                float marginaStanga = e.MarginBounds.Left;
                float marginaSus = e.MarginBounds.Top;
                float latimePagina = e.MarginBounds.Width;

                float yCurent = marginaSus;

                // 1. Desenare Titlu
                string titlu = "RAPORT CANDIDATI ADMITERE - 2026";
                g.DrawString(titlu, fontTitlu, pensulaText, marginaStanga + (latimePagina / 4), yCurent);
                yCurent += 50;

                // 2. Desenare Antet Tabel
                g.DrawLine(Pens.Black, marginaStanga, yCurent, marginaStanga + latimePagina, yCurent);
                yCurent += 5;
                g.DrawString("Nume si Prenume", fontAntet, pensulaText, marginaStanga, yCurent);
                g.DrawString("Facultate", fontAntet, pensulaText, marginaStanga + 250, yCurent);
                g.DrawString("Medie Finala", fontAntet, pensulaText, marginaStanga + 450, yCurent);
                g.DrawString("Status", fontAntet, pensulaText, marginaStanga + 550, yCurent);
                yCurent += 20;
                g.DrawLine(Pens.Black, marginaStanga, yCurent, marginaStanga + latimePagina, yCurent);
                yCurent += 10;

                // 3. Desenare Linii Candidati (Paginare)
                while (candidatCurentIndice < candidati.Count)
                {
                    Candidat c = candidati[candidatCurentIndice];

                    // Verificam daca mai avem loc pe pagina curenta
                    if (yCurent + 25 > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true; // Spunem sistemului ca mai urmeaza o pagina
                        return; // Iesim din metoda, va fi apelata din nou pentru pagina 2
                    }

                    // Scriem datele candidatului
                    g.DrawString($"{c.Nume} {c.Prenume}", fontText, pensulaText, marginaStanga, yCurent);
                    g.DrawString(c.FacultateAleasa, fontText, pensulaText, marginaStanga + 250, yCurent);
                    g.DrawString(c.MedieCalculata.ToString("0.00"), fontText, pensulaText, marginaStanga + 450, yCurent);

                    // Status colorat simbolic (ramane negru pentru imprimantele alb-negru)
                    g.DrawString(c.ObtineStatusAdmitere(), fontText, pensulaText, marginaStanga + 550, yCurent);

                    yCurent += 25;
                    candidatCurentIndice++;
                }

                // 4. Subsol (Numar pagina sau data)
                e.HasMorePages = false; // Am terminat toti candidatii
                candidatCurentIndice= 0;
                g.DrawString("Data generarii: " + DateTime.Now.ToShortDateString(), fontText, Brushes.Gray, marginaStanga, e.MarginBounds.Bottom + 20);
            }
            catch (Exception ex)
            {
                throw new Exception("Eroare in timpul generarii paginii: " + ex.Message);
            }
        }

        private void exportXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (candidati.Count == 0)
                {
                    MessageBox.Show("Nu exista date pentru export!", "Atentie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                saveFileDialog1.Filter = "Fisiere XML (*.xml)|*.xml";
                saveFileDialog1.Title = "Exporta datele în format XML";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Cream serializatorul pentru tipul List<Candidat>
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Candidat>));

                    using (TextWriter writer = new StreamWriter(saveFileDialog1.FileName))
                    {
                        serializer.Serialize(writer, candidati);
                    }

                    MessageBox.Show("Datele au fost exportate cu succes în format XML!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la exportul XML: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void importXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Fisiere XML (*.xml)|*.xml";
                openFileDialog1.Title = "Importa date din fisier XML";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Candidat>));

                    using (FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open))
                    {
                        // Citim datele și facem cast catre List<Candidat>
                        List<Candidat> listaImportata = (List<Candidat>)serializer.Deserialize(fs);

                        if (listaImportata != null)
                        {
                            // Curatam lista actuala si baza de date pentru a evita duplicatele
                            candidati.Clear();
                            foreach (var cand in db.IncarcaCandidati()) { db.StergeCandidat(cand.CNP); }

                            // Adaugam noile date în lista si în DB
                            foreach (Candidat c in listaImportata)
                            {
                                candidati.Add(c);
                                db.InserareCandidat(c);

                                // Verificam daca facultatea importata exista în lista de facultati
                                if (!facultatiDisponibile.Any(f => f.Denumire == c.FacultateAleasa))
                                {
                                    facultatiDisponibile.Add(new Facultate(c.FacultateAleasa, 50));
                                }
                            }

                            // Actualizam interfata
                            AfisareInListView();
                            ActualizeazaComboFiltrare();
                            MessageBox.Show("Importul XML a fost realizat cu succes!", "Succes");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la importul XML: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetareStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvCandidati.Items)
            {
                item.ForeColor = SystemColors.WindowText;
                item.BackColor = SystemColors.Window;
            }
        }
    }
}
