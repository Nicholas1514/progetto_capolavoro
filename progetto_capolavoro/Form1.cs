using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progetto_capolavoro
{
	public partial class Form1 : Form
	{

		public List<string> Lsquadre;
		public bool [] indici;
		public int indexsqcasa;
		public int indexsqtrasf;
		public int npartite;
		public Form1()
		{
			InitializeComponent();
			indexsqcasa = 0;
			indexsqtrasf = 0;
			indici = new bool[20];
			Lsquadre = new List<string>();
			npartite= 0;
			Lsquadre.Add("Atalanta");
			Lsquadre.Add("Bologna");
			Lsquadre.Add("Cagliari");
			Lsquadre.Add("Empoli");
			Lsquadre.Add("Fiorentina");
			Lsquadre.Add("Frosinone");
			Lsquadre.Add("Genoa");
			Lsquadre.Add("Hellas Verona");
			Lsquadre.Add("Inter");
			Lsquadre.Add("Juventus");
			Lsquadre.Add("Lazio");
			Lsquadre.Add("Lecce");
			Lsquadre.Add("Milan");
			Lsquadre.Add("Monza");
			Lsquadre.Add("Napoli");
			Lsquadre.Add("Roma");
			Lsquadre.Add("Salernitana");
			Lsquadre.Add("Sassuolo");
			Lsquadre.Add("Torino");
			Lsquadre.Add("Udinese");
			button2.Hide();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();

			Random r = new Random();
			npartite++;
			if(npartite == 10)
			{
				MessageBox.Show("Hai aggiunto tutte le partite per questa giornata");
				button1.Hide();
				button2.Show();
			}
			indexsqcasa = EstIndici(r, indici);
			indexsqtrasf = EstIndici(r, indici);
			textBox1.Text = Lsquadre[indexsqcasa - 1];
			textBox2.Text = Lsquadre[indexsqtrasf - 1];
			int golcasa = r.Next(1, 5);
			int goltrasf = r.Next(1, 5);
			Partita partita = new Partita(textBox1.Text, textBox2.Text);
			partita.AggiornaPunteggio(golcasa, goltrasf);
			Campionato campionato = new Campionato();
			campionato.AggiungiPartita(partita);
			listView1.Items.Add($"{golcasa} - {goltrasf}");
			listView2.Items.Add(partita.ToString());
			
				
				
			
		}





		private void button2_Click(object sender, EventArgs e)
		{
			
			int ngiornata = 2;
			listView1.Items.Clear();
			listView2.Items.Clear();
			textBox1.Text = "";
			textBox2.Text = "";
			button1.Show();
			indexsqcasa = 0;
			indexsqtrasf = 0;
			indici = new bool[20];
			Lsquadre = new List<string>();
			npartite = 0;
			Lsquadre.Add("Atalanta");
			Lsquadre.Add("Bologna");
			Lsquadre.Add("Cagliari");
			Lsquadre.Add("Empoli");
			Lsquadre.Add("Fiorentina");
			Lsquadre.Add("Frosinone");
			Lsquadre.Add("Genoa");
			Lsquadre.Add("Hellas Verona");
			Lsquadre.Add("Inter");
			Lsquadre.Add("Juventus");
			Lsquadre.Add("Lazio");
			Lsquadre.Add("Lecce");
			Lsquadre.Add("Milan");
			Lsquadre.Add("Monza");
			Lsquadre.Add("Napoli");
			Lsquadre.Add("Roma");
			Lsquadre.Add("Salernitana");
			Lsquadre.Add("Sassuolo");
			Lsquadre.Add("Torino");
			Lsquadre.Add("Udinese");
			label4.Text = $"GIORNATA {ngiornata}";
			ngiornata++;
		}


		public int EstIndici(Random ran, bool[] ind)
		{
			int indice;
			do
			{
				indice = ran.Next(1, 21);
			} while (ind[indice - 1] == true);
			ind[indice- 1] = true;
	

			return indice;
			
		}

		
	}
}
