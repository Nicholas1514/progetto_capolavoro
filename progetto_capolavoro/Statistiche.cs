using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progetto_capolavoro
{
	public class Statistiche : Partita
	{
		public int GolFattiCasa { get; set; }
		public int GolSubitiCasa { get; set; }
		public int GolFattiTrasf { get; set; }
		public int GolSubitiTrasf { get; set; }

		public int DRCASA { get; set; }
		public int DRTRASF { get; set; }

		public Statistiche()
		{
			GolFattiCasa = GolCasa;
			GolSubitiCasa = GolTrasf;
			GolFattiTrasf = GolTrasf;
			GolSubitiTrasf = GolCasa; 

		}

		public void DiffReti()
		{
			DRCASA = GolFattiCasa - GolSubitiCasa;
			DRTRASF = GolFattiTrasf - GolSubitiTrasf;
		}

		
	}
}
