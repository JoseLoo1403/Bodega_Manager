using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bodega_Manager.Forms;

namespace Bodega_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var frm in this.MdiChildren)
            {
                if (frm is AgregarRepuesto)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                        frm.Focus();
                    }
                    return;
                }
            }

            AgregarRepuesto NewForm = new AgregarRepuesto();
            NewForm.MdiParent = this;
            NewForm.Show();
        }

        private void facturarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (var frm in this.MdiChildren)
            {
                if (frm is Facturar)
                {
                    if (frm.WindowState == FormWindowState.Minimized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                        frm.Focus();
                    }
                    return;
                }
            }

            Facturar NewForm = new Facturar();
            NewForm.MdiParent = this;
            NewForm.Show();
        }
    }
}
