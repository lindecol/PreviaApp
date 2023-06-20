
using PivotGrid_FlatDataBinding;
using PreviaApp.Daos;
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
    public partial class FrmReporte : Form
    {

        List<Vendedor> _ListaVendedores;
        public FrmReporte()
        {
            InitializeComponent();
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {

          var ds= Daos.PreviaDao.GetPreviaCompleta();

            _ListaVendedores = Parametros.listaVendedores;

            /*
             var query = from clients in db.Clients  
         join orders in db.Orders on clients.Id equals orders.ClientId  
         select new { Clients = clients, Orders = orders }; 
             */

            var query = from registro in ds
                        join vendedores in _ListaVendedores on int.Parse(registro.VENDED_CLI) equals int.Parse(vendedores.VendedorId)
                       select registro;

            this.previaBindingSource.DataSource = query.ToList();
            //reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource { Name = "DataSet1", Value = ds });
            


          this.reportViewer1.RefreshReport();
        }
    }
}
