using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cp_Entidad;
using Cp_Logica_Negocio;

namespace Cp_Presentacion
{
    public partial class C_Presentacion : Form
    {
        public C_Presentacion()
        {
            InitializeComponent();
        }

        private void C_Presentacion_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            ShowProducts();
        }

        C_Entidad Entidad = new C_Entidad();
        C_LN Logica = new C_LN();

        //Método para mostrar todos los productos
        void ShowProducts()
        {
            try
            {
                DataTable dt = Logica.LN_ShowProducts();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        //Método para borrar productos
        void DeleteProducts()
        {
            if (int.TryParse(textBox6.Text, out int id))
            {
                Logica.LN_DeleteProducts(id);
            }
        }

        //Método para buscar productos.
        void GetProducts()
        {
            if (int.TryParse(textBox6.Text, out int id))
            {
                DataTable dt = Logica.LN_GetProducts(id);
                dataGridView1.DataSource = dt;
            }
        }

        //Método para añadir productos
        void AddProducts()
        {
            string Nombre = textBox2.Text;
            string Codigo = textBox1.Text;
            string Fecha_entrada = textBox4.Text;
            string Fecha_expiracion = textBox5.Text;
            if (int.TryParse(textBox3.Text, out int Cantidad))
            {
                Logica.LN_AddProducts(Nombre, Codigo, Cantidad, Fecha_entrada, Fecha_expiracion);
                ShowProducts();
                ClearFields();
            }
            else
            {
                MessageBox.Show("La cantidad debe ser un número entero.");
            }
        }

        //Método para borrar el contenido de todos los textBox
        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        //Método para modificar productos
        void UpdateProducts()
        {
            string Nombre = textBox2.Text;
            string Codigo = textBox1.Text;
            string Fecha_entrada = textBox4.Text;
            string Fecha_expiracion = textBox5.Text;
            if (int.TryParse(textBox3.Text, out int Cantidad))
            {
                if (int.TryParse(textBox6.Text, out int id))
                {
                    Logica.LN_UpdateProducts(id, Nombre, Codigo, Cantidad, Fecha_entrada, Fecha_expiracion);
                    ShowProducts();
                    ClearFields();
                }

            }
        }

        //Controlando que todos los texbox necesarios estén llenos para que se active el botón "Añadir"
        //Así se evitan añadir registros vacíos o con campos sin llenar.
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            bool allFieldsFilled = new[] { textBox5, textBox4, textBox3, textBox1, textBox2 }
            .All(textBox => !string.IsNullOrWhiteSpace(textBox.Text));

            button4.Enabled = allFieldsFilled;
        }

        //Botón "Añadir".
        private void button4_Click(object sender, EventArgs e)
        {
            AddProducts();
            ShowProducts();
            MessageBox.Show("El registro ha sido insertado");
        }

        //Botón "Buscar".
        private void button2_Click(object sender, EventArgs e)
        {
            GetProducts();
        }

        //Botón "Eliminar".
        private void button3_Click(object sender, EventArgs e)
        {
            DeleteProducts();
            ShowProducts() ;
            MessageBox.Show("El registro ha sido eliminado. Si tienes dudas puedes probar a buscarlo en la sección llamada ID");
        }

        //Los botones 1, 2 y 3 solo se activan si un número está dentro del textBox6.
        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
                if (!string.IsNullOrWhiteSpace(textBox6.Text) && int.TryParse(textBox6.Text, out int result))
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
            }
                else
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateProducts();
            ShowProducts();
            MessageBox.Show("El registro ha sido actualizado");
        }
    }
}
