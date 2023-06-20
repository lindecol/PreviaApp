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
    public partial class FrmSemana : Form
    {
        public FrmSemana()
        {
            InitializeComponent();
        }

        public List<Semana> semanas = new List<Semana>();

        private void FrmSemana_Load(object sender, EventArgs e)
        {

            semanas.Add(new Semana { Codigo = 1, Descripcion = "SEMANA 1" });
            semanas.Add(new Semana { Codigo = 2, Descripcion = "SEMANA 2" });
            semanas.Add(new Semana { Codigo = 3, Descripcion = "SEMANA 3" });
            semanas.Add(new Semana { Codigo = 4, Descripcion = "SEMANA 4" });


            this.cmbSemana.DataSource = semanas;

            this.cmbSemana.DisplayMember = "Descripcion";
            this.cmbSemana.ValueMember = "Codigo";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var semana = ((Semana)this.cmbSemana.SelectedItem).Codigo;


            try
            {

            
            PreviaDao.AsignarSemana(Parametros.ParametrosIniciales.UsrId, semana);
                MessageBox.Show("Semana Actualizada ", "Previa de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error actualizando la semana  "+ex.Message, "Previa de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
