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
        public string [] squadre;
        int indexsqcasa;
        int indexsqtrasf;
        int dim;
        public Form1()
        {
            InitializeComponent();
            indexsqcasa = 0;
            indexsqtrasf = 0;
            dim = 19;
            squadre = new string [20];
            squadre[0] = "Atalanta";
            squadre[1] = "Bologna";
            squadre[2] = "Cagliari";
            squadre[3] = "Empoli";
            squadre[4] = "Fiorentina";
            squadre[5] = "Frosinone";
            squadre[6] = "Genoa";
            squadre[7] = "Hellas Verona";
            squadre[8] = "Inter";
            squadre[9] = "Juventus";
            squadre[10] = "Lazio";
            squadre[11] = "Lecce";
            squadre[12] = "Milan";
            squadre[13] = "Monza";
            squadre[14] = "Napoli";
            squadre[15] = "Roma";
            squadre[16] = "Salernitana";
            squadre[17] = "Sassuolo";
            squadre[18] = "Torino";
            squadre[19] = "Udinese";
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
          
            Random r = new Random();
            indexsqcasa = r.Next(1, 20);
            indexsqtrasf = r.Next(1, 20);
            textBox1.Text = squadre[indexsqcasa];
            RimuoviCasa();
            textBox2.Text = squadre[indexsqcasa];
            RimuoviTrasferta();
            int golcasa = r.Next(1,5);
            int goltrasf = r.Next(1, 5);
            Partita partita = new Partita(textBox1.Text, textBox2.Text);
            partita.AggiornaPunteggio(golcasa, goltrasf);
            Campionato campionato = new Campionato();
            campionato.AggiungiPartita(partita);
            listView1.Items.Add($"{golcasa} - {goltrasf}");
            listView2.Items.Add(partita.ToString());
            MessageBox.Show("La partita è stata aggiunta al campionato");
        }

        public void RimuoviCasa()
        {
            for(int i = 0; i < 20; i++)
            {
                if (squadre[i] == squadre[indexsqcasa])
                {
                    squadre[indexsqcasa] = squadre[i + 1];
                    squadre[i + 1] = squadre[indexsqcasa];
                    dim--;
                   
                   
                }
               
            }
            MessageBox.Show("Sqadra di casa rimossa");
        }

        public void RimuoviTrasferta()
        {
            for(int i = 0; i < 20; i++)
            {
                if (squadre[i] == squadre[indexsqtrasf])
                {
                    squadre[indexsqtrasf] = squadre[i + 1];
                    squadre[i + 1] = squadre[indexsqtrasf];
                    dim--;
                   
                   
                }
            }
            MessageBox.Show("Sqadra in trasferta rimossa");
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
