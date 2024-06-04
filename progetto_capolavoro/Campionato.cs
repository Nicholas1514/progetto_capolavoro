using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progetto_capolavoro
{
	public class Campionato
	{
		public List<Partita> partite { get; set; }
		public Dictionary<string, int> classifica { get; set; }
		public Campionato()
		{
			partite = new List<Partita>();
			classifica = new Dictionary<string, int>();
		}

		public void AggiungiPartita(Partita partita)
		{
			partite.Add(partita);

		}

		


	}
}
