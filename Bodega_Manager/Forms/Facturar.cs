using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bodega_Manager.Entities;
using Bodega_Manager.Repositories;

namespace Bodega_Manager.Forms
{
    public partial class Facturar : Form
    {
        List<Factura_Detail> RepuestoSalida = new List<Factura_Detail>();
        public Repuesto RepuestoActual { get; set; }
        public Factura_Header FacturaActual { get; set; }
        public Mecanico MecanicoActual { get; set; }

        int cantidadTotal = 0;
        decimal Total = 0;

        public Facturar()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text.Length < 1)
            {
                return;
            }

            int id = Convert.ToInt32(TxtCodigo.Text);

            RepuestosRepository repo = new RepuestosRepository();

            var resultado = repo.EncontrarRepuestoCodigo(id);

            if (resultado == null)
            {
                MessageBox.Show("No se encontro ningun repuesto con ese codigo");
                return;
            }

            SetValores(resultado);
            RepuestoActual = resultado;
        }

        private void RefreshGrid()
        {
            RepuestosDataGrid.DataSource = null;
            RepuestosDataGrid.Refresh();
            RepuestosDataGrid.DataSource = RepuestoSalida;
            RepuestosDataGrid.Columns["Id_Factura_Header"].Visible = false;
            RepuestosDataGrid.Columns["Factura_Header"].Visible = false;
            RepuestosDataGrid.Columns["Maquina1"].Visible = false;
            RepuestosDataGrid.Columns["Repuesto1"].Visible = false;

        }

        private void SetValores(Repuesto repuesto)
        {
            LblDesc.Text = $"Descripcion: {repuesto.Descripcion}";
            LblPrecio.Text = $"Precio: {repuesto.Precio.ToString()}";
            LblLocalidad.Text = $"Localidad: {repuesto.Localidad}";
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (RepuestoActual == null)
            {
                MessageBox.Show("Elija un repuesto porfavor");
                return;
            }

            if (TxtCantidad.Text.Length < 1)
            {
                MessageBox.Show("Ingrese porfavor una cantidad");
                return;
            }

            if (TxtMaquina.Text.Length < 1)
            {
                MessageBox.Show("Ingrese una maquina porfavor");
                return;
            }

            Factura_Detail adder = new Factura_Detail()
            {
                Codigo_Repuesto = RepuestoActual.Codigo,
                Cantidad = Convert.ToInt32(TxtCantidad.Text),
                Total = Convert.ToDecimal(TxtCantidad.Text) * RepuestoActual.Precio,
                Tag_Maquina = TxtMaquina.Text
            };

            cantidadTotal += adder.Cantidad.Value;
            Total += adder.Total.Value;

            RepuestoActual = null;
            RepuestoSalida.Add(adder);
            RefreshGrid();
            RefreshDatosMaestros();
            Limpiar();
        }

        private void Limpiar()
        {
            TxtCantidad.Clear();
            TxtCodigo.Clear();
            TxtMaquina.Clear();

            LblDesc.Text = "Descripcion:";
            LblLocalidad.Text = "Localidad:";
            LblPrecio.Text = "Precio: ";
        }
        private void RefreshDatosMaestros()
        {
            LblTotalFac.Text = $"Total: {Total}";
            LblCantRepuestos.Text = $"Cantidad Total: {cantidadTotal}";
        }
        private void BtnFacturar_Click(object sender, EventArgs e)
        {
            if (RepuestoSalida.Count() < 1)
            {
                MessageBox.Show("no hay ningun elemento por facturar");
                return;
            }

            Factura_HeaderRepository HeaderRepo = new Factura_HeaderRepository();
            Factura_DetailsRepository detailsRepository = new Factura_DetailsRepository();
            RepuestosRepository repuestosRepository = new RepuestosRepository();

            try
            {
                //crear factura
                int Id = HeaderRepo.CrearFacturaHeader(MecanicoActual.Codigo, Total, cantidadTotal);

                //Crear items de factura
                detailsRepository.CrearDetails(RepuestoSalida, Id);

                //restar inventario
                repuestosRepository.RestarInventarioFactura(RepuestoSalida);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Factura hecha!");
            FacturaTerminada();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (RepuestosDataGrid.CurrentRow == null)
            {
                return;
            }

            int ProductId = Convert.ToInt32(RepuestosDataGrid.CurrentRow.Cells["Codigo_Repuesto"].Value);

            var Product = RepuestoSalida.First(x => x.Codigo_Repuesto == ProductId);

            cantidadTotal -= Product.Cantidad.Value;
            Total -= Product.Total.Value;
            RefreshDatosMaestros();


            RepuestoSalida.RemoveRange(RepuestosDataGrid.CurrentRow.Index, 1);
            RefreshGrid();
        }

        private void BtnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            if (TxtMecanicoCode.Text.Length < 1)
            {
                return;
            }

            int Id = Convert.ToInt32(TxtMecanicoCode.Text);

            MecanicoRepository repo = new MecanicoRepository();

            MecanicoActual = repo.BuscarMecanicoId(Id);

            LblNombreM.Text = $"Nombre: {MecanicoActual.Nombre}";
        }

        private void FacturaTerminada()
        {
            Limpiar();
            FacturaActual = null;
            RepuestoActual = null;
            RepuestoSalida = null;
            MecanicoActual = null;
            Total = 0;
            cantidadTotal = 0;

            LblNombreM.Text = "Nombre: ";

            RepuestosDataGrid.DataSource = null;
            RepuestosDataGrid.Refresh();
        }
    }
}
