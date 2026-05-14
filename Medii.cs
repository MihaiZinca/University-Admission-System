using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Admitere_Facultate
{
    [Serializable]
    public class Medii:ICloneable,IComparable
    {
        private double medieBac;
        private double notaAdmitere;
        private double pondereBac;
        private double pondereAdmitere;


        public Medii() { }

        public Medii(double medieBac, double notaAdmitere, double pondereBac, double pondereAdmitere)
        {
            this.medieBac = medieBac;
            this.notaAdmitere = notaAdmitere;
            this.pondereBac = pondereBac;
            this.pondereAdmitere = pondereAdmitere;
        }

        public double MedieBac
        {
            get { return medieBac; }
            set
            {
                if (value < 1 || value > 10)
                    throw new Exception("Medie BAC invalida!");
                medieBac = value;
            }
        }

        public double NotaAdmitere
        {
            get { return notaAdmitere; }
            set
            {
                if (value < 1 || value > 10)
                    throw new Exception("Nota admitere invalida!");
                notaAdmitere = value;
            }
        }

        public double PondereBac
        {
            get { return pondereBac; }
            set
            {
                if (value < 0 || value > 1)
                    throw new Exception("Pondere invalida!");
                pondereBac = value;
            }
        }

        public double PondereAdmitere
        {
            get { return pondereAdmitere; }
            set
            {
                if (value < 0 || value > 1)
                    throw new Exception("Pondere invalida!");
                pondereAdmitere = value;
            }
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return medieBac;
                    case 1: return notaAdmitere;
                    case 2: return pondereBac;
                    case 3: return pondereAdmitere;
                    default: throw new Exception("Index invalid!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: MedieBac = value; break;
                    case 1: NotaAdmitere = value; break;
                    case 2: PondereBac = value; break;
                    case 3: PondereAdmitere = value; break;
                    default: throw new Exception("Index invalid!");
                }
            }
        }
        public object Clone()
        {
            return new Medii(MedieBac, NotaAdmitere, PondereBac, PondereAdmitere);
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (!(obj is Medii m))
                throw new Exception("Tip invalid");
            return CalculeazaMedieFinala().CompareTo(m.CalculeazaMedieFinala());
        }

        public double CalculeazaMedieFinala()
        {
            return (this[0] * this[2])+(this[1] * this[3]);
        }
        public override string ToString()
        {
            return $"{medieBac}|{notaAdmitere}|{pondereBac}|{pondereAdmitere}";
        }

        
    }
}
