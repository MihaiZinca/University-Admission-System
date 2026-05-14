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
    public partial class FormFacultate : Form
    {
        public Facultate FacultateNoua { get; set; }
        public FormFacultate()
        {
            InitializeComponent();
        }

        private void btnSalvare_Click(object sender, EventArgs e)
        {
         
            errorProvider1.Clear();
            bool esteValid = true;

            // 1. Validare Denumire Facultate
            if (string.IsNullOrWhiteSpace(tbDenumire.Text))
            {
                errorProvider1.SetError(tbDenumire, "Denumirea facultatii este obligatorie!");
                esteValid = false;
            }

           
            if (!int.TryParse(tbNrLocuri.Text, out int nrLocuri) || nrLocuri <= 0)
            {
                errorProvider1.SetError(tbNrLocuri, "Introduceti un număr valid de locuri (intreg pozitiv)!");
                esteValid = false;
            }

           
            if (!esteValid) return;

            try
            {
                
                FacultateNoua = new Facultate(tbDenumire.Text, nrLocuri);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la crearea facultatii: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnulare_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
