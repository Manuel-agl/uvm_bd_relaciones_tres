using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_B2
{
    
    public partial class Form1 : Form
    {
        private string idSeleccionado = null;
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("admin");
                var collection = database.GetCollection<Persona>("Empresa");

                List<Persona> lista = collection.Find(_ => true).ToList();
                dataGridView1.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con MongoDB: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];

                idSeleccionado = fila.Cells["_id"].Value.ToString();

                Nombre.Text = fila.Cells["Nombre"].Value.ToString();
                Apellido.Text = fila.Cells["Apellido"].Value.ToString();
                Edad.Text = fila.Cells["Edad"].Value.ToString();
                Correo.Text = fila.Cells["Correo"].Value.ToString();
                Telefono.Text = fila.Cells["Telefono"].Value.ToString();
                Ciudad.Text = fila.Cells["Ciudad"].Value.ToString();
                Saldo.Text = fila.Cells["Saldo"].Value.ToString();
                FN.Text = fila.Cells["FechaNacimiento"].Value.ToString();
                Ocupacion.Text = fila.Cells["Ocupacion"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("admin");
            var collection = database.GetCollection<Persona>("Empresa");

            var Persona = new Persona() { 
                Nombre = Nombre.Text,
                Apellido = Apellido.Text, 
                Ciudad = Ciudad.Text, 
                Correo = Correo.Text, 
                Edad = int.Parse(Edad.Text), 
                FechaNacimiento = FN.Text, 
                Ocupacion = Ocupacion.Text, 
                Saldo = double.Parse(Saldo.Text), 
                Telefono = Telefono.Text, 
            };

            collection.InsertOne(Persona);
            MessageBox.Show("Registro agregado");
            CargarDatos();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("admin");
            var collection = database.GetCollection<Persona>("Empresa");

            try
            {
                var filtro = Builders<Persona>.Filter.Eq(p => p._id, idSeleccionado);

                var actualizacion = Builders<Persona>.Update
                    .Set(p => p.Nombre, Nombre.Text)
                    .Set(p => p.Apellido, Apellido.Text)
                    .Set(p => p.Edad, int.Parse(Edad.Text))
                    .Set(p => p.Correo, Correo.Text)
                    .Set(p => p.Telefono, Telefono.Text)
                    .Set(p => p.Ciudad, Ciudad.Text)
                    .Set(p => p.Saldo, double.Parse(Saldo.Text))
                    .Set(p => p.FechaNacimiento, FN.Text)
                    .Set(p => p.Ocupacion, Ocupacion.Text);

                collection.UpdateOne(filtro, actualizacion);

                MessageBox.Show("Registro actualizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("admin");
            var collection = database.GetCollection<Persona>("Empresa");

            try
            {
                var filtro = Builders<Persona>.Filter.Eq(p => p._id, idSeleccionado);
                collection.DeleteOne(filtro);

                MessageBox.Show("Registro eliminado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
