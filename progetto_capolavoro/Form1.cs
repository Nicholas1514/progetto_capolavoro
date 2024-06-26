﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;



namespace progetto_capolavoro
{
	public partial class Form1 : Form
	{

		public List<string> Lsquadre;
		public Dictionary<string, int> Classifica;
		public Dictionary<string, int> Golfatti;
		public Dictionary<string, int> Golsubiti;
		public Dictionary<string, int> DR;
		public bool[] indici;
		public int indexsqcasa;
		public int ngiornata;
		public int indexsqtrasf;
		public int npartite;
		public string path;
		public string pathJSON;
		public Partita partita;
		public Campionato camp;
		public Statistiche s;
		public Form1()
		{
			InitializeComponent();
			indexsqcasa = 0;
			indexsqtrasf = 0;
			ngiornata = 1;
			path = "squadre.txt";
			pathJSON = "file.json";
			indici = new bool[20];
			Lsquadre = new List<string>();
			Classifica = new Dictionary<string, int>();
			Golfatti = new Dictionary<string, int>();
			Golsubiti = new Dictionary<string, int>();
			DR = new Dictionary<string, int>();
			npartite = 0;
			PrendiDatiFile(path);
			InserimentoChiaviClassifica(path);
			File.Delete(pathJSON);
			button2.Hide();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		public void InserimentoChiaviClassifica(string path)
		{
			string linee;
			if (File.Exists(path))
			{
				StreamReader sr = new StreamReader(path);
				while ((linee = sr.ReadLine()) != null)
				{
					Classifica.Add(linee, 0);
					Golfatti.Add(linee, 0);
					Golsubiti.Add(linee, 0);
					DR.Add(linee, 0);
				}
				sr.Close();
				MessageBox.Show("Dati inseriti nella dictionary dal file");
			}
			else
			{
				MessageBox.Show("Il file non esiste");

			}
		}

		public void PrendiDatiFile(string path)
		{
			string linee;
			if (File.Exists(path))
			{
				StreamReader sr = new StreamReader(path);
				while ((linee = sr.ReadLine()) != null)
				{
					Lsquadre.Add(linee);

				}
				sr.Close();
				//MessageBox.Show("Dati inseriti nella lista dal file");
			}
			else
			{
				MessageBox.Show("Il file non esiste");

			}

		}
		private void button1_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();

			Random r = new Random();
			npartite++;
			if (npartite == 10)
			{
				//MessageBox.Show("Hai aggiunto tutte le partite per questa giornata");
				button1.Hide();
				button2.Show();

			}

			indexsqcasa = EstIndici(r, indici);
			indexsqtrasf = EstIndici(r, indici);
			textBox1.Text = Lsquadre[indexsqcasa - 1];
			textBox2.Text = Lsquadre[indexsqtrasf - 1];
			int golcasa = r.Next(0, 4);
			int goltrasf = r.Next(0, 4);
			partita = new Partita(textBox1.Text, textBox2.Text, golcasa, goltrasf);
			camp = new Campionato();
			camp.AggiungiPartita(partita);
			
			SerializzaJSON();
			//partita.AggiornaPunteggio(golcasa, goltrasf);
			AggiornaClassifica();
			listView1.Items.Add($"{golcasa} - {goltrasf}");
			listView2.Items.Add(partita.ToString());
			Golfatti[partita.SqCasa] += partita.GolCasa;
			Golfatti[partita.SqTrasf] += partita.GolTrasf;
			Golsubiti[partita.SqCasa] += partita.GolTrasf;
			Golsubiti[partita.SqTrasf] += partita.GolCasa;
			DR[partita.SqCasa] = Golfatti[partita.SqCasa] - Golsubiti[partita.SqCasa];
			DR[partita.SqTrasf] = Golfatti[partita.SqTrasf] - Golsubiti[partita.SqTrasf];
			//dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Programmatic;
			dataGridView1.Rows.Add(partita.SqCasa, Classifica[partita.SqCasa].ToString(), Golfatti[partita.SqCasa].ToString(), Golsubiti[partita.SqCasa].ToString(), DR[partita.SqCasa].ToString());
			dataGridView1.Rows.Add(partita.SqTrasf, Classifica[partita.SqTrasf].ToString(), Golfatti[partita.SqTrasf].ToString(), Golsubiti[partita.SqTrasf].ToString(), DR[partita.SqTrasf].ToString());

			DataGridViewColumn punti = dataGridView1.Columns[1];

			dataGridView1.Sort(punti, ListSortDirection.Descending);


		}





		private void button2_Click(object sender, EventArgs e)
		{


			listView1.Items.Clear();
			listView2.Items.Clear();
			dataGridView1.Rows.Clear();
			textBox1.Text = "";
			textBox2.Text = "";
			button1.Show();
			indexsqcasa = 0;
			indexsqtrasf = 0;
			indici = new bool[20];
			Lsquadre = new List<string>();
			npartite = 0;
			PrendiDatiFile(path);

			if (ngiornata < 38)
			{
				ngiornata++;
				label4.Text = $"GIORNATA {ngiornata}";
			}
			else
			{
				MessageBox.Show("Campionato terminato");
				int a = Classifica.Values.Max();
				string vincitori;
				StreamReader sr = new StreamReader(path);
				while ((vincitori = sr.ReadLine()) != null)
				{
					if (Classifica[vincitori] == a)
					{
						MessageBox.Show("Il campionato è stato vinto da:" + " " + vincitori + " !!!");
					}

				}
				sr.Close();

				button1.Hide();
			}
			button2.Hide();

		}

		public void AggiornaClassifica()
		{
			if (partita.GolCasa > partita.GolTrasf)
			{
				Classifica[partita.SqCasa] += 3;
			}
			else if (partita.GolTrasf > partita.GolCasa)
			{
				Classifica[partita.SqTrasf] += 3;
			}
			else
			{
				Classifica[partita.SqCasa] += 1;
				Classifica[partita.SqTrasf] += 1;
			}
		}


		public int EstIndici(Random ran, bool[] ind)
		{
			int indice;
			do
			{
				indice = ran.Next(1, 21);
			} while (ind[indice - 1] == true);
			ind[indice - 1] = true;


			return indice;

		}

		public void SerializzaJSON()
		{
			string JSON = JsonSerializer.Serialize(partita);
			//MessageBox.Show(JSON);
			StreamWriter sw = new StreamWriter(pathJSON, true);
			if (!File.Exists(pathJSON))
			{
				File.Create(pathJSON);
				sw.WriteLine(JSON);
				sw.Close();
			}
			else
			{
				sw.WriteLine(JSON);
				sw.Close();
			}
			//MessageBox.Show("Partita serializzata su file JSON");



		}



	}
}
