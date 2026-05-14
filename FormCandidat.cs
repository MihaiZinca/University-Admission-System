using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_Admitere_Facultate
{
    public enum ModForm
    {
        Adaugare,
        Modificare
    }

    public partial class FormCandidat : Form
    {
        public Candidat CandidatCreat { get; set; }
        private ModForm mod;
        private Candidat candidatInitial;
        public FormCandidat(List<Facultate> facultatiDisponibile)
        {
            InitializeComponent();
            mod = ModForm.Adaugare;
     
            // Populăm ComboBox-ul cu denumirile din listă
            foreach (var f in facultatiDisponibile)
            {
                cmbFacultate.Items.Add(f.Denumire);
            }

            string facultateDefault = facultatiDisponibile.Count > 0 ? facultatiDisponibile[0].Denumire : "";
            CandidatCreat = new Candidat("", "", "", "", DateTime.Now, "", new Medii(0, 0, 0, 0), facultateDefault);

            ConfigurareBindingCandidat(CandidatCreat);
            if (cmbFacultate.Items.Count > 0) cmbFacultate.SelectedIndex = 0;

        }
        //pt Modificare
        public FormCandidat(Candidat c,List<Facultate> facultatiDisponibile)
        {
            InitializeComponent();

            foreach (var f in facultatiDisponibile)
            {
                cmbFacultate.Items.Add(f.Denumire);
            }

            mod = ModForm.Modificare;
            candidatInitial = c;
            CandidatCreat = c;

            
            tbPrenume.Text = c.Prenume;
            
            tbDomiciliu.Text = c.Domiciliu;
            cmbSex.Text = c.Sex;
            dtpDataNasterii.Value = c.DataNasterii;

            tbMedieBac.Text = c.MediiExamen.MedieBac.ToString();
            tbNotaAdmitere.Text = c.MediiExamen.NotaAdmitere.ToString();
            tbPondereBac.Text = c.MediiExamen.PondereBac.ToString();
            tbPondereAdmitere.Text = c.MediiExamen.PondereAdmitere.ToString();

            cmbFacultate.Text = c.FacultateAleasa;

            //binding ul pt nume si cnp
            ConfigurareBindingCandidat(c);
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool valid = true;

            if (string.IsNullOrWhiteSpace(tbNume.Text))
            {
                errorProvider1.SetError(tbNume, "Numele este obligatoriu!");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(tbPrenume.Text))
            {
                errorProvider1.SetError(tbPrenume, "Prenumele este obligatoriu!");
                valid = false;
            }

            if (cmbSex.SelectedIndex == -1)
            {
                errorProvider1.SetError(cmbSex, "Selecteaza sexul!");
                valid = false;
            }

            if (tbCNP.Text.Length != 13 || !tbCNP.Text.All(char.IsDigit))
            {
                errorProvider1.SetError(tbCNP, "CNP trebuie sa aiba 13 cifre!");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(tbDomiciliu.Text))
            {
                errorProvider1.SetError(tbDomiciliu, "Domiciliu obligatoriu!");
                valid = false;
            }

            if (!double.TryParse(tbMedieBac.Text, out double bac) || bac < 1 || bac > 10)
            {
                errorProvider1.SetError(tbMedieBac, "Medie BAC invalida");
                valid = false;
            }

            if (!double.TryParse(tbNotaAdmitere.Text, out double nota) || nota < 1 || nota > 10)
            {
                errorProvider1.SetError(tbNotaAdmitere, "Nota invalida!");
                valid = false;
            }

            if (!double.TryParse(tbPondereBac.Text, out double pBac) || pBac < 0 || pBac > 1)
            {
                errorProvider1.SetError(tbPondereBac, "Pondere BAC invalida,trebuie sa fie cuprinsa intre (0,1)!");
                valid = false;
            }

            if (!double.TryParse(tbPondereAdmitere.Text, out double pAdm) || pAdm < 0 || pAdm > 1)
            {
                errorProvider1.SetError(tbPondereAdmitere, "Pondere admitere invalida,trebuie sa fie cuprinsa intre (0,1)!");
                valid = false;
            }

            if (cmbFacultate.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cmbFacultate.Text))
            {
                errorProvider1.SetError(cmbFacultate, "Selectati o facultate din lista!");
                valid = false;
            }

            if (!valid)
                return;

            try
            {
                Medii mediiNoi = new Medii(bac, nota, pBac, pAdm);

                if (mod == ModForm.Adaugare)
                {
                    
                    CandidatCreat.Prenume = tbPrenume.Text;
                    CandidatCreat.Sex = cmbSex.Text;
                    CandidatCreat.DataNasterii = dtpDataNasterii.Value;
                    CandidatCreat.Domiciliu = tbDomiciliu.Text;
                    CandidatCreat.MediiExamen = mediiNoi; 
                    CandidatCreat.FacultateAleasa = cmbFacultate.Text;
                }
                else if (mod == ModForm.Modificare && candidatInitial != null)
                {
                    
                    candidatInitial.Nume = tbNume.Text;
                    candidatInitial.Prenume = tbPrenume.Text;
                    candidatInitial.Sex = cmbSex.Text;
                    candidatInitial.CNP = tbCNP.Text;
                    candidatInitial.DataNasterii = dtpDataNasterii.Value;
                    candidatInitial.Domiciliu = tbDomiciliu.Text;
                    candidatInitial.MediiExamen = mediiNoi;
                    candidatInitial.FacultateAleasa = cmbFacultate.Text;

                    CandidatCreat = candidatInitial;
                }

                MessageBox.Show("Candidatul a fost salvat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ConfigurareBindingCandidat(Candidat c)
        {
            try
            {
                tbNume.DataBindings.Clear();
                tbCNP.DataBindings.Clear();

                // 1. Configurare Binding pentru Nume
                Binding bNume = new Binding("Text", c, "Nume", true, DataSourceUpdateMode.OnValidation);

                // Interceptăm eroarea de tip "Numele nu poate fi gol"
                bNume.BindingComplete += (sender,e) =>
                {
                    if (e.BindingCompleteState != BindingCompleteState.Success)
                    {
                        // Afișează eroarea din "throw new Exception" în ErrorProvider
                        errorProvider1.SetError(tbNume,e.ErrorText);
                    }
                    else
                    {
                        errorProvider1.SetError(tbNume, ""); // Curăță eroarea dacă e valid
                    }
                };
                tbNume.DataBindings.Add(bNume);

                // 2. Configurare Binding pentru CNP (păstrăm logica anterioară)
                Binding bCNP = new Binding("Text", c, "CNP", true, DataSourceUpdateMode.OnValidation);
                bCNP.BindingComplete += (s, args) =>
                {
                    if (args.BindingCompleteState != BindingCompleteState.Success)
                    {
                        errorProvider1.SetError(tbCNP, args.ErrorText);
                    }
                    else
                    {
                        errorProvider1.SetError(tbCNP, "");
                    }
                };
                tbCNP.DataBindings.Add(bCNP);

                tbCNP.MaxLength = 13;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la legarea datelor: " + ex.Message);
            }
        }
    }
}
