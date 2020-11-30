using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto131datagridviewArchivotexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GrabarDatos();
            dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void GrabarDatos()
        {
            StreamWriter archivo = new StreamWriter("agenda.txt", true); //con true indico que se abra el archivo (para hacerle add)
            archivo.WriteLine(textBox1.Text);
            archivo.WriteLine(textBox2.Text);
            archivo.WriteLine(textBox3.Text);
            archivo.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("agenda.txt")) //importo la clase File, using System.IO / Si no existe el archivo, lo crea
            {
                StreamWriter archivo = new StreamWriter("agenda.txt");
                archivo.Close();
            }
            else
            {
                StreamReader archivo = new StreamReader("agenda.txt");
                while (!archivo.EndOfStream)
                {
                    String nombre = archivo.ReadLine();
                    String telefono = archivo.ReadLine();
                    String mail = archivo.ReadLine();
                    dataGridView1.Rows.Add(nombre, telefono, mail);
                }
                archivo.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int f=0; f<dataGridView1.Rows.Count; f++)
            {
                if (textBox1.Text == dataGridView1.Rows[f].Cells[0].Value.ToString())
                {
                    dataGridView1.Rows.RemoveAt(f);
                    GrabarBorrado();
                    MessageBox.Show("Se borró la persona");
                }
            }
        }

        private void GrabarBorrado()
        {
            StreamWriter archivo = new StreamWriter("agenda.txt"); //acá no uso true como segundo parámetro porque no abriré el archivo, sino que lo crearé de vuelta (lo cual sobreescribe el archivo ya existente)
            for (int f = 0; f < dataGridView1.Rows.Count; f++)
            {
                archivo.WriteLine(dataGridView1.Rows[f].Cells[0].Value.ToString());
                archivo.WriteLine(dataGridView1.Rows[f].Cells[1].Value.ToString());
                archivo.WriteLine(dataGridView1.Rows[f].Cells[2].Value.ToString());
            }
            archivo.Close();
        }
    }
}
