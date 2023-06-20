using PreviaApp.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreviaApp
{
    public partial class FrmVendedor : Form
    {
        public FrmVendedor()
        {
            InitializeComponent();
        }

        private void FrmVendedor_Load(object sender, EventArgs e)
        {

            Parametros.listaVendedores= PreviaApp.Daos.PreviaDao.GetVendedoresAsociados(Parametros.ParametrosIniciales.UsrId, Parametros.ParametrosIniciales.Empresa);
            cmbVendedor.DataSource = Parametros.listaVendedores;
            cmbVendedor.ValueMember = "VendedorId";
            cmbVendedor.DisplayMember = "Nombre";
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            Parametros.ParametrosIniciales.CodigoAsesor=(int.Parse(((Vendedor)this.cmbVendedor.SelectedItem).VendedorId));
            Parametros.ParametrosIniciales.NombreAsesor = ((((Vendedor)this.cmbVendedor.SelectedItem).Nombre));


            this.Dispose();
        }

        private void FrmVendedor_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
