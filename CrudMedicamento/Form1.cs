using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrudMedicamento
{
    public partial class Form1 : Form
    {
        conectarBD cnx = new conectarBD();
        List<ClaseMedicamento> listaM = new List<ClaseMedicamento>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          listaM=  cnx.listarMedicamentos();
            dataGridView1.DataSource = listaM;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnx.InsertarMedicamento(txtNombre.Text, Convert.ToDouble(txtPrecio.Text),
                Convert.ToInt16(txtStockActual.Text), Convert.ToInt16(txtMinimo.Text));
        }
    }
}
