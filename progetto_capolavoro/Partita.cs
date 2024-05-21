using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progetto_capolavoro
{
    public class Partita
    {
        public string SqCasa {  get; set; }
        public string SqTrasf {  get; set; }
        public int GolCasa { get; set; }
        public int GolTrasf { get;set; }

        public Partita()
        {
            SqCasa = string.Empty;
            SqTrasf = string.Empty;
            GolCasa = 0;
            GolTrasf = 0;
        }

        public Partita(string sqCasa, string sqTrasf)
        {
            SqCasa = sqCasa;
            SqTrasf = sqTrasf;
            GolCasa = 0;
            GolTrasf = 0;
        }

        public void AggiornaPunteggio(int golcasa, int goltrasf)
        {
            Random r = new Random();
            GolCasa = golcasa;
            GolTrasf = goltrasf;
        }

        public override string ToString()
        {
            return $"{SqCasa} {GolCasa} - {GolTrasf} {SqTrasf}";
        }


    }
}
