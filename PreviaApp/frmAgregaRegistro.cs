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
    public partial class frmAgregaRegistro : Form
    {
        public frmAgregaRegistro(List<Sucursal> Sucursales)
        {
            InitializeComponent();
            _sucursales = Sucursales;
        }

        private void cODI_PROTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CargarProducto();
            }

        }

        private void CargarProducto()
        {
            var ds = Daos.PreviaDao.GetProducto(this.cODI_PROTextBox.Text, cODI_CLITextBox.Text, Parametros.ParametrosIniciales.Empresa);

            if (ds.Tables[0].Rows.Count == 0)
            {
                button1.Enabled = false;
                cmbAgencia.Enabled = false;
                MessageBox.Show("El Codigo de producto ingresado no existe", "Previa", MessageBoxButtons.OK);
                return;

            }


            obj.DESC_PRODUCTO = ds.Tables[0].Rows[0]["artdsccorta"].ToString();
            obj.PRECIO_MES = double.Parse(ds.Tables[0].Rows[0]["precio"].ToString());
            obj.LINEA_NEGOCIO = ds.Tables[0].Rows[0]["lineaNegocio"].ToString();
            obj.CODI_PRO = ds.Tables[0].Rows[0]["artid"].ToString();

            button1.Enabled = true;
            cmbAgencia.Enabled = true;

            if (((Sucursal)cmbAgencia.SelectedItem).cod_agencia == "-1")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }

            if (obj.CODI_PRO.Substring(0, 1) == "1")
            {


                grpPrevia.Enabled = true;
                grpVolumen.Enabled = false;
                grpPrevia.Focus();


                obj.VOL_PREVIA1 = 1;
                obj.VOL_PREVIA2 = 1;
                obj.VOL_PREVIA3 = 1;
                obj.VOL_PREVIA4 = 1;


                if (semana == 1)
                {
                    this.fACT_PREVIA1TextBox.Enabled = true;
                    this.fACT_PREVIA2TextBox.Enabled = false;
                    this.fACT_PREVIA3TextBox.Enabled = false;
                    this.fACT_PREVIA4TextBox.Enabled = false;

                }

                if (semana == 2)
                {
                    this.fACT_PREVIA1TextBox.Enabled = false;
                    this.fACT_PREVIA2TextBox.Enabled = true;
                    this.fACT_PREVIA3TextBox.Enabled = false;
                    this.fACT_PREVIA4TextBox.Enabled = false;

                }

                if (semana == 3)
                {
                    this.fACT_PREVIA1TextBox.Enabled = false;
                    this.fACT_PREVIA2TextBox.Enabled = false;
                    this.fACT_PREVIA3TextBox.Enabled = true;
                    this.fACT_PREVIA4TextBox.Enabled = false;

                }
                if (semana == 4)
                {
                    this.fACT_PREVIA1TextBox.Enabled = false;
                    this.fACT_PREVIA2TextBox.Enabled = false;
                    this.fACT_PREVIA3TextBox.Enabled = false;
                    this.fACT_PREVIA4TextBox.Enabled = true;

                }




            }
            else
            {
                grpPrevia.Enabled = false;
                grpVolumen.Enabled = true;

                grpVolumen.Focus();
                if (semana == 1)
                {
                    this.vOL_PREVIA1TextBox.Enabled = true;
                    this.vOL_PREVIA2TextBox.Enabled = false;
                    this.vOL_PREVIA3TextBox.Enabled = false;
                    this.vOL_PREVIA4TextBox.Enabled = false;
                }

                if (semana == 2)
                {
                    this.vOL_PREVIA1TextBox.Enabled = false;
                    this.vOL_PREVIA2TextBox.Enabled = true;
                    this.vOL_PREVIA3TextBox.Enabled = false;
                    this.vOL_PREVIA4TextBox.Enabled = false;


                }
                if (semana == 3)
                {
                    this.vOL_PREVIA1TextBox.Enabled = false;
                    this.vOL_PREVIA2TextBox.Enabled = false;
                    this.vOL_PREVIA3TextBox.Enabled = true;
                    this.vOL_PREVIA4TextBox.Enabled = false;


                }
                if (semana == 4)
                {
                    this.vOL_PREVIA1TextBox.Enabled = false;
                    this.vOL_PREVIA2TextBox.Enabled = false;
                    this.vOL_PREVIA3TextBox.Enabled = false;
                    this.vOL_PREVIA4TextBox.Enabled = true;


                }



            }





        }

        private void cODI_PROTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void cODI_CLITextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void cODI_CLITextBox_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (e.KeyChar== '\r')
            {
                CargarCliente();
            }
        }

        private void CargarCliente()
        {


            var ds = Daos.PreviaDao.GetCliente(this.cODI_CLITextBox.Text, (string)this.cmbEmpresa.SelectedValue);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            else
            {

                this.obj.RAZON_SOCIAL = ds.Tables[0].Rows[0]["razon__cli"].ToString();
                //this.rAZON_SOCIALTextBox.Text= ds.Tables[0].Rows[0]["razon__cli"].ToString();
                //this.previaBindingSource.ResumeBinding();

                cODI_PROTextBox.Focus();

            }
        }

        Previa obj = new Previa();
        int semana = 0;

        public List<Sucursal> _sucursales { get;  set; }

        private void frmAgregaRegistro_Load(object sender, EventArgs e)
        {
            this.previaBindingSource.DataSource = obj;
            semana = Daos.PreviaDao.GetSemanaAnio(Parametros.ParametrosIniciales.Periodo);

            this.cmbAgencia.DataSource = _sucursales;
            this.cmbAgencia.DisplayMember = "Agencia";
            this.cmbAgencia.ValueMember = "cod_agencia";


            this.cmbEmpresa.DataSource = PreviaDao.GetEmpresas().Tables[0];

            this.cmbEmpresa.DisplayMember = "EMPNMB";
            this.cmbEmpresa.ValueMember = "EMPALIAS";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.previaBindingSource.EndEdit();

         var registro=   (Previa)this.previaBindingSource.DataSource;
            registro.cod_agencia = ((Sucursal)this.cmbAgencia.SelectedItem).cod_agencia.ToString();
            registro.AGENCIA = ((Sucursal)this.cmbAgencia.SelectedItem).Agencia.ToString();
            
            //registro.VENDED_CLI = Parametros.ParametrosIniciales.CodigoAsesor.ToString();

            try
            {

                if (PreviaDao.VallidaExisteRegistro(registro)>0)
                {
                    MessageBox.Show("Ya existe un valor de venta igual al que intenta ingresar para el cliente", "Previa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            
            PreviaDao.InsertarRegistro(registro);

                MessageBox.Show("REGISTRO INSERTADO");
                this.Dispose();

            }
            catch (Exception EX)
            {

                MessageBox.Show("OCURRIO UN ERROR AGREGANDO EL REGISTRO");
            }

        }

        private void vOL_PREVIA1TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                return;
            }

            obj.FACT_PREVIA1 = double.Parse(vOL_PREVIA1TextBox.Text) * obj.PRECIO_MES;

            button1.Focus();

         


        }

        private void vOL_PREVIA2TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                return;
            }

            obj.FACT_PREVIA2= double.Parse(vOL_PREVIA2TextBox.Text) * obj.PRECIO_MES;

            button1.Focus();

        }

        private void vOL_PREVIA3TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                return;
            }

            obj.FACT_PREVIA3= double.Parse(vOL_PREVIA3TextBox.Text) * obj.PRECIO_MES;

            button1.Focus();

        }

        private void vOL_PREVIA4TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
            {
                return;
            }

            obj.FACT_PREVIA4= double.Parse(vOL_PREVIA4TextBox.Text) * obj.PRECIO_MES;

            button1.Focus();
        }

        private void cODI_CLITextBox_Leave(object sender, EventArgs e)
        {
            CargarCliente();
        }

        private void cODI_PROTextBox_Leave(object sender, EventArgs e)
        {
            CargarProducto();
        }

        private void cmbAgencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Sucursal)this.cmbAgencia.SelectedItem).cod_agencia.ToString()=="-1")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
        
    }
}
