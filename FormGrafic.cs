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
    public partial class FormGrafic : Form
    {
        private List<Candidat> candidati;
        private List<Facultate> facultati;

        public FormGrafic(List<Candidat> candidati, List<Facultate> facultati)
        {
            InitializeComponent();
            this.candidati = candidati;
            this.facultati = facultati;
            this.Text = "Reprezentare Grafica Candidati / Facultate";
        }
        private void panelGrafic_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // 1. Verificare date
                if (facultati == null || facultati.Count == 0)
                {
                    g.DrawString("Nu exista facultati definite.", this.Font, Brushes.Red, 10, 10);
                    return;
                }

                // 2. Calcul statistici (Ignoram elementul "Toate" de la binding)
                Dictionary<string, int> dateGrafic = new Dictionary<string, int>();
                foreach (var f in facultati)
                {
                    // MODIFICARE: Sarim peste "Toate" pentru a nu desena o bara goala
                    if (f.Denumire == "Toate") continue;

                    int nr = candidati.Count(c => c.FacultateAleasa == f.Denumire);
                    dateGrafic.Add(f.Denumire, nr);
                }

                if (dateGrafic.Count == 0)
                {
                    g.DrawString("Nu exista date de afisat in grafic.", this.Font, Brushes.Gray, 10, 10);
                    return;
                }

                // 3. Parametri desen
                Rectangle zonaDesen = panelGrafic.ClientRectangle;
                int margina = 60;
                int spatiu = 20;

                // Calculam latimea barelor in functie de numarul de facultati reale
                int latimeBara = (zonaDesen.Width - 2 * margina) / dateGrafic.Count - spatiu;

                int maxCandidati = dateGrafic.Values.Max();
                if (maxCandidati == 0) maxCandidati = 1;

                // vScale: impartim inaltimea la max+1 ca sa nu atinga bara tavanul
                float vScale = (float)(zonaDesen.Height - 2 * margina) / (maxCandidati + 0.5f);

                Pen axaPen = new Pen(Color.Black, 3);
                Brush pensulaBare = new SolidBrush(Color.MediumSeaGreen);
                Font fontText = new Font("Segoe UI", 9, FontStyle.Bold);

                // 4. Desenare Axe
                g.DrawLine(axaPen, margina, margina, margina, zonaDesen.Height - margina);
                g.DrawLine(axaPen, margina, zonaDesen.Height - margina, zonaDesen.Width - margina, zonaDesen.Height - margina);

                // 5. Desenare Bare
                int contor = 0;
                foreach (var pereche in dateGrafic)
                {
                    int inaltimeBara = (int)(pereche.Value * vScale);
                    int xBara = margina + contor * (latimeBara + spatiu) + 10;
                    int yBara = zonaDesen.Height - margina - inaltimeBara;

                    // Desenare dreptunghi plin
                    g.FillRectangle(pensulaBare, xBara, yBara, latimeBara, inaltimeBara);
                    // Desenare contur
                    g.DrawRectangle(Pens.Black, xBara, yBara, latimeBara, inaltimeBara);

                    // Eticheta Facultate (axa X)
                    g.DrawString(pereche.Key, fontText, Brushes.Black, xBara, zonaDesen.Height - margina + 10);

                    // Valoarea numerica (deasupra barei)
                    g.DrawString(pereche.Value.ToString(), fontText, Brushes.DarkBlue, xBara + (latimeBara / 4), yBara - 20);

                    contor++;
                }
            }
            catch (Exception ex)
            {
                // Desenam eroarea direct pe ecran pentru debug fara a bloca executia
                e.Graphics.DrawString("Eroare la desenare: " + ex.Message, this.Font, Brushes.Red, 10, 10);
            }
        }

    }
}
