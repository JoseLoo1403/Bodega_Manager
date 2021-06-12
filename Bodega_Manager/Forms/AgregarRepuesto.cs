using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bodega_Manager.Repositories;

namespace Bodega_Manager.Forms
{
    public partial class AgregarRepuesto : Form
    {
        public AgregarRepuesto()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            RepuestosRepository repository = new RepuestosRepository();

            repository.CrearNuevoRepuesto(Convert.ToInt32(TxtCodigo.Text),TxtLawson.Text, TxtDescripcion.Text,Convert.ToInt32(TxtStock.Text), Convert.ToDecimal(TxtPrecio.Text),TxtLocalidad.Text);

            Limpiar();
        }

        private void Limpiar()
        {
            TxtCodigo.Clear();
            TxtLawson.Clear();
            TxtDescripcion.Clear();
            TxtLocalidad.Clear();
            TxtPrecio.Clear();
            TxtStock.Clear();
        }
    }
}
