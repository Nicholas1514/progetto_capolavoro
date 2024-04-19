using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progetto_capolavoro
{
    public class Campionato
    {
        public List<Partita> partite {  get; set; }
        public Dictionary<string, int> classifica { get; set; }
        public Campionato()
        {
            partite = new List<Partita>();
            classifica = new Dictionary<string, int>();
        }

        private void AggiornaClassifica(string sqcasa, string sqtrasf, int golcasa, int goltrasf)
        {
            if(!classifica.ContainsKey(sqcasa))
            {
                classifica[sqcasa] = 0;
            }
            if (!classifica.ContainsKey(sqtrasf))
            {
                classifica[sqtrasf] = 0;
            }

            if(golcasa > goltrasf)
            {
                classifica[sqcasa] += 3;
            }

            else if(goltrasf > golcasa)
            {
                classifica[sqtrasf] += 3;
            }
            else
            {
                classifica[sqcasa] += 1;
                classifica[sqtrasf] += 1;
            }
        }

        public void AggiungiPartita(Partita partita)
        {
            partite.Add(partita);
            AggiornaClassifica(partita.SqCasa, partita.SqTrasf, partita.GolCasa, partita.GolTrasf);
        }
    }
}
