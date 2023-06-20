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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Entidades.Previa> listaPrevia;

        private void Form1_Load(object sender, EventArgs e)
        {
            FrmVendedor frm = new FrmVendedor();
            frm.ShowDialog();

            Parametros.ParametrosIniciales.Periodo = DateTime.Now.AddMonths(-1);
            ActualizarPantalla();

        }

        private void ActualizarPantalla()
        {
            CargarDatosPrevia();
            CalcularPromedios();

            var semana = Daos.PreviaDao.GetSemanaAnio(Parametros.ParametrosIniciales.Periodo);

            this.txtVendedor.Text = Parametros.ParametrosIniciales.NombreAsesor;
            this.txtSemana.Text = semana.ToString();


            foreach (DataGridViewColumn item in grvPrevia.Columns)
            {

                item.Name = item.DataPropertyName;



            }

            foreach (DataGridViewRow item in grvPrevia.Rows)
            {

                if (item.Cells["CODI_PRO"].Value.ToString().Substring(0, 1) == "1")
                {


                    item.Cells["FACT_PREVIA1"].ReadOnly = false;
                    item.Cells["VOL_PREVIA1"].ReadOnly = true;



                    item.Cells["FACT_PREVIA1"].ReadOnly = false;
                    item.Cells["VOL_PREVIA1"].ReadOnly = true;

                    item.Cells["FACT_PREVIA2"].ReadOnly = false;
                    item.Cells["VOL_PREVIA2"].ReadOnly = true;

                    item.Cells["FACT_PREVIA3"].ReadOnly = false;
                    item.Cells["VOL_PREVIA3"].ReadOnly = true;

                    item.Cells["FACT_PREVIA4"].ReadOnly = false;
                    item.Cells["VOL_PREVIA4"].ReadOnly = true;


                    item.Cells["VOL_PREVIA1"].Value = 1;
                    item.Cells["VOL_PREVIA2"].Value = 1;
                    item.Cells["VOL_PREVIA3"].Value = 1;
                    item.Cells["VOL_PREVIA4"].Value = 1;




                }
                else
                {
                    item.Cells["FACT_PREVIA1"].ReadOnly = true;
                    item.Cells["VOL_PREVIA1"].ReadOnly = false;

                    item.Cells["FACT_PREVIA2"].ReadOnly = true;
                    item.Cells["VOL_PREVIA2"].ReadOnly = false;

                    item.Cells["FACT_PREVIA3"].ReadOnly = true;
                    item.Cells["VOL_PREVIA3"].ReadOnly = false;

                    item.Cells["FACT_PREVIA4"].ReadOnly = true;
                    item.Cells["VOL_PREVIA4"].ReadOnly = false;

                }



            }


            if (semana == 1)
            {
                grvPrevia.Columns["VOL_PREVIA1"].Visible = true;

                grvPrevia.Columns["FACT_PREVIA1"].Visible = true;


                grvPrevia.Columns["VOL_PREVIA2"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA2"].Visible = false;


                grvPrevia.Columns["VOL_PREVIA3"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA3"].Visible = false;


                grvPrevia.Columns["VOL_PREVIA4"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA4"].Visible = false;

                ColorPrevia();

            }
            if (semana == 2)
            {

                ColorPrevia();
                grvPrevia.Columns["VOL_PREVIA1"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA1"].Visible = false;

                grvPrevia.Columns["VOL_PREVIA2"].Visible = true;
                grvPrevia.Columns["FACT_PREVIA2"].Visible = true;

                grvPrevia.Columns["VOL_PREVIA3"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA3"].Visible = false;

                grvPrevia.Columns["VOL_PREVIA4"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA4"].Visible = false;
            }

            if (semana == 3)
            {
                ColorPrevia();
                grvPrevia.Columns["VOL_PREVIA1"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA1"].Visible = false;

                grvPrevia.Columns["VOL_PREVIA2"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA2"].Visible = false;

                grvPrevia.Columns["VOL_PREVIA3"].Visible = true;
                grvPrevia.Columns["FACT_PREVIA3"].Visible = true;

                grvPrevia.Columns["VOL_PREVIA4"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA4"].Visible = false;
            }


            if (semana == 4)
            {
                ColorPrevia();
                grvPrevia.Columns["VOL_PREVIA1"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA1"].Visible = false;

                grvPrevia.Columns["VOL_PREVIA2"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA2"].Visible = false;

                grvPrevia.Columns["VOL_PREVIA3"].Visible = false;
                grvPrevia.Columns["FACT_PREVIA3"].Visible = false;

                grvPrevia.Columns["VOL_PREVIA4"].Visible = true;
                grvPrevia.Columns["FACT_PREVIA4"].Visible = true;
            }
        }

        private void CargarDatosPrevia()
        {
            listaPrevia = new List<Entidades.Previa>();

            listaPrevia = Daos.PreviaDao.getVentasXasesor(Parametros.ParametrosIniciales.CodigoAsesor, DateTime.Now.AddMonths(-1),Parametros.ParametrosIniciales.Empresa);

            previaBindingSource.DataSource = listaPrevia;
        }

        private void ColorPrevia()
        {
            grvPrevia.Columns["FACT_PREVIA1"].DefaultCellStyle.BackColor = Color.Aquamarine;
            grvPrevia.Columns["VOL_PREVIA1"].DefaultCellStyle.BackColor = Color.Aquamarine;

            grvPrevia.Columns["FACT_PREVIA2"].DefaultCellStyle.BackColor = Color.Aquamarine;
            grvPrevia.Columns["VOL_PREVIA2"].DefaultCellStyle.BackColor = Color.Aquamarine;

            grvPrevia.Columns["FACT_PREVIA3"].DefaultCellStyle.BackColor = Color.Aquamarine;
            grvPrevia.Columns["VOL_PREVIA3"].DefaultCellStyle.BackColor = Color.Aquamarine;

            grvPrevia.Columns["FACT_PREVIA4"].DefaultCellStyle.BackColor = Color.Aquamarine;
            grvPrevia.Columns["VOL_PREVIA4"].DefaultCellStyle.BackColor = Color.Aquamarine;
        }

        private void tsbAgregarRegistroVentas_Click(object sender, EventArgs e)
        {

            var agencias= this.listaPrevia.Select(p => new Sucursal { cod_agencia = p.cod_agencia, Agencia = p.AGENCIA }).ToList();


            agencias.Add(new Sucursal { cod_agencia = "-1", Agencia = "SELECCIONE UNA SUCURSAL" });


            var query = from item in agencias
                        group item by new { item.Agencia, item.cod_agencia} into eg
                        select new  Sucursal{   cod_agencia=eg.Key.cod_agencia,  Agencia=eg.Key.Agencia};
            




            frmAgregaRegistro frm = new frmAgregaRegistro(query.OrderByDescending(p=>p.cod_agencia).ToList());
            frm.ShowDialog();

            CargarDatosPrevia();



        }

        private void grvPrevia_CellErrorTextChanged(object sender, DataGridViewCellEventArgs e)
        {

          
            

        }

        private void grvPrevia_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((grvPrevia.Columns[e.ColumnIndex].Name == "VOL_PREVIA1" ||
              grvPrevia.Columns[e.ColumnIndex].Name == "VOL_PREVIA2" ||
              grvPrevia.Columns[e.ColumnIndex].Name == "VOL_PREVIA3" ||
              grvPrevia.Columns[e.ColumnIndex].Name == "VOL_PREVIA4") && !grvPrevia.Rows[e.RowIndex].Cells["CODI_PRO"].Value.ToString().Substring(0, 1).Equals(1))
            {
                grvPrevia.Rows[e.RowIndex].Cells["FACT_PREVIA1"].Value = double.Parse(grvPrevia.Rows[e.RowIndex].Cells["PRECIO_MES"].Value.ToString()) *
                                                                        double.Parse(grvPrevia.Rows[e.RowIndex].Cells["VOL_PREVIA1"].Value.ToString());

                grvPrevia.Rows[e.RowIndex].Cells["FACT_PREVIA2"].Value = double.Parse(grvPrevia.Rows[e.RowIndex].Cells["PRECIO_MES"].Value.ToString()) *
                                                                        double.Parse(grvPrevia.Rows[e.RowIndex].Cells["VOL_PREVIA2"].Value.ToString());

                grvPrevia.Rows[e.RowIndex].Cells["FACT_PREVIA3"].Value = double.Parse(grvPrevia.Rows[e.RowIndex].Cells["PRECIO_MES"].Value.ToString()) *
                                                                        double.Parse(grvPrevia.Rows[e.RowIndex].Cells["VOL_PREVIA3"].Value.ToString());

                grvPrevia.Rows[e.RowIndex].Cells["FACT_PREVIA4"].Value = double.Parse(grvPrevia.Rows[e.RowIndex].Cells["PRECIO_MES"].Value.ToString()) *
                                                                        double.Parse(grvPrevia.Rows[e.RowIndex].Cells["VOL_PREVIA4"].Value.ToString());

                var registroEdicion = ((Previa)grvPrevia.Rows[e.RowIndex].DataBoundItem);
                registroEdicion.estadoEdicion = 1;

                var flete = PreviaDao.ValidaProducto(registroEdicion.CODI_PRO);

                if (flete!="-1")
                {

                    var productoCero = listaPrevia.FirstOrDefault(p => p.CODI_PRO == registroEdicion.CODI_PRO && p.CODI_CLI == registroEdicion.CODI_CLI);
                    var productoFlete = listaPrevia.FirstOrDefault(p => p.CODI_PRO == flete && p.CODI_CLI == registroEdicion.CODI_CLI);
                    var semana = Daos.PreviaDao.GetSemanaAnio(Parametros.ParametrosIniciales.Periodo);


                    if (productoFlete!=null)
                    {
                        productoFlete.estadoEdicion = 1;
                        if (semana == 1)
                        {
                            productoFlete.FACT_PREVIA1 = productoCero.VOL_PREVIA1 * productoFlete.PRECIO_MES;
                            productoFlete.VOL_PREVIA1 = 1;
                        }

                     
                        if (semana == 2)
                        {
                            productoFlete.FACT_PREVIA2 = productoCero.VOL_PREVIA2 * productoFlete.PRECIO_MES;
                            productoFlete.VOL_PREVIA2 = 1;
                        }
                        if (semana == 3)
                        {
                            productoFlete.FACT_PREVIA3 = productoCero.VOL_PREVIA3 * productoFlete.PRECIO_MES;
                            productoFlete.VOL_PREVIA3 = 1;
                        }
                        if (semana == 4)
                        {
                            productoFlete.FACT_PREVIA4 = productoCero.VOL_PREVIA4 * productoFlete.PRECIO_MES;
                                productoFlete.VOL_PREVIA4 = 1;
                        }

                        grvPrevia.Refresh();

                    }









                }




            }
            else if (grvPrevia.Columns[e.ColumnIndex].Name == "FACT_PREVIA1" ||
              grvPrevia.Columns[e.ColumnIndex].Name == "FACT_PREVIA2" ||
              grvPrevia.Columns[e.ColumnIndex].Name == "FACT_PREVIA3" ||
              grvPrevia.Columns[e.ColumnIndex].Name == "FACT_PREVIA4")
            {
                ((Previa)grvPrevia.Rows[e.RowIndex].DataBoundItem).estadoEdicion = 1;
            }

            CalcularPromedios();

        }

        private void CalcularPromedios()
        {
            txtPromedioVolumen1.Value = decimal.Parse(((IEnumerable<Previa>)this.previaBindingSource.DataSource).Sum(p => (p.VOL_PREVIA1)).ToString());
            txtPromedioVolumen2.Value = decimal.Parse(((IEnumerable<Previa>)this.previaBindingSource.DataSource).Sum(p => (p.VOL_PREVIA2)).ToString());
            txtPromedioVolumen3.Value = decimal.Parse(((IEnumerable<Previa>)this.previaBindingSource.DataSource).Sum(p => (p.VOL_PREVIA3)).ToString());
            txtPromedioVolumen4.Value = decimal.Parse(((IEnumerable<Previa>)this.previaBindingSource.DataSource).Sum(p => (p.VOL_PREVIA4)).ToString());

            txtVentaSemana1.Value = decimal.Parse(((IEnumerable<Previa>)this.previaBindingSource.DataSource).Sum(p => (p.FACT_PREVIA1)).ToString());
            txtVentaSemana2.Value = decimal.Parse(((IEnumerable<Previa>)this.previaBindingSource.DataSource).Sum(p => (p.FACT_PREVIA2)).ToString());
            txtVentaSemana3.Value = decimal.Parse(((IEnumerable<Previa>)this.previaBindingSource.DataSource).Sum(p => (p.FACT_PREVIA3)).ToString());
            txtVentaSemana4.Value = decimal.Parse(((IEnumerable<Previa>)this.previaBindingSource.DataSource).Sum(p => (p.FACT_PREVIA4)).ToString());
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
             
            try
            {
                GuardarCambiosPrevia();

                MessageBox.Show("Registros Almacenados con exito", "Previa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error almacenando los registros", "Previa", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GuardarCambiosPrevia()
        {
            var listaModificaciones = this.listaPrevia.Where(p => p.estadoEdicion == 1).ToList();

            var semana = Daos.PreviaDao.GetSemanaAnio(Parametros.ParametrosIniciales.Periodo);

            foreach (var item in listaModificaciones)
            {
                PreviaDao.ActualizarRegistro(item, semana);
                item.estadoEdicion = 0;

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FrmVendedor frm = new FrmVendedor();
            frm.ShowDialog(this);


            CargarDatosPrevia();
            CalcularPromedios();

            var semana = Daos.PreviaDao.GetSemanaAnio(Parametros.ParametrosIniciales.Periodo);

            this.txtVendedor.Text = Parametros.ParametrosIniciales.NombreAsesor;
            this.txtSemana.Text = semana.ToString();
        }

        private void grvPrevia_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //grvPrevia.Sort(grvPrevia.Columns[e.colu], ListSortDirection.Ascending);

            //previaBindingSource.Sort = grvPrevia.Columns[e.ColumnIndex].Name;

            //previaBindingSource.ResumeBinding();

            if (grvPrevia.Columns[e.ColumnIndex].Name== "RAZON_SOCIAL")
            {
                previaBindingSource.DataSource = listaPrevia.OrderBy(p => p.RAZON_SOCIAL);
            }


            if (grvPrevia.Columns[e.ColumnIndex].Name == "DESC_PRODUCTO")
            {
                previaBindingSource.DataSource = listaPrevia.OrderBy(p => p.DESC_PRODUCTO);
            }

            if (grvPrevia.Columns[e.ColumnIndex].Name == "PROM_FACT")
            {
                previaBindingSource.DataSource = listaPrevia.OrderByDescending(p => p.PROM_FACT);
            }

            if (grvPrevia.Columns[e.ColumnIndex].Name == "TOTAL_MES1")
            {
                previaBindingSource.DataSource = listaPrevia.OrderByDescending(p => p.TOTAL_MES1);
            }
            if (grvPrevia.Columns[e.ColumnIndex].Name == "TOTAL_MES2")
            {
                previaBindingSource.DataSource = listaPrevia.OrderByDescending(p => p.TOTAL_MES2);
            }
            if (grvPrevia.Columns[e.ColumnIndex].Name == "TOTAL_MES3")
            {
                previaBindingSource.DataSource = listaPrevia.OrderByDescending(p => p.TOTAL_MES3);
            }

            if (grvPrevia.Columns[e.ColumnIndex].Name == "LINEA_NEGOCIO")
            {
                previaBindingSource.DataSource = listaPrevia.OrderByDescending(p => p.LINEA_NEGOCIO);
            }

            if (grvPrevia.Columns[e.ColumnIndex].Name == "AGENCIA")
            {
                previaBindingSource.DataSource = listaPrevia.OrderByDescending(p => p.AGENCIA);
            }






        }

        private void btnFiltrarxCliente_Click(object sender, EventArgs e)
        {
            previaBindingSource.DataSource = listaPrevia.Where(p => (p.RAZON_SOCIAL.ToUpper().Contains(this.txtNombreCliente.Text) || this.txtNombreCliente.Text.Length==0)  
                                                                &&
                                                               ( p.LINEA_NEGOCIO == (this.txtFiltroLineaNegocio.Text) || this.txtFiltroLineaNegocio.Text.Length == 0) &&
                                                               (p.AGENCIA.ToUpper().Contains(txtFiltroSucursal.Text) || txtFiltroSucursal.Text.Length==0) &&
                                                               (p.CODI_CLI.ToUpper().Contains(txtCodigoCliente.Text) || txtCodigoCliente.Text.Length == 0)
                                                               );

            CalcularPromedios();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            previaBindingSource.DataSource = listaPrevia.Where(p => p.LINEA_NEGOCIO==(this.txtFiltroLineaNegocio.Text) || this.txtFiltroLineaNegocio.Text.Length == 0);

            CalcularPromedios();
        }

        private void tsb_Click(object sender, EventArgs e)
        {
            try
            {


                if (MessageBox.Show("El proceso de generacion de plantilla toma los datos de la semana anterior y reemplaza los valores en 0 de la semana actual. ¿Desea ejecutar el proceso?","Previas", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    return;
                }

            GuardarCambiosPrevia();
            Daos.PreviaDao.ActualizarvaloresPrevias();
                CargarDatosPrevia();



                MessageBox.Show("Plantilla Actualizada", "Previas", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception)
            {

                MessageBox.Show("Ocurrio un error almacenando previas", "Previas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
          

            FrmReporte f = new FrmReporte();
            f.ShowDialog(this);
        }

        private void tsbSemana_Click(object sender, EventArgs e)
        {
            if (!PreviaDao.Funcion_Usuario("ALTA_SEMANA_PREVIA", Parametros.ParametrosIniciales.UsrId))
            {
                MessageBox.Show("No tiene asignado permisos para modificar la semana actual", "Previa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            FrmSemana frm = new FrmSemana();
            frm.ShowDialog(this);

            ActualizarPantalla();
        }
    }
}
