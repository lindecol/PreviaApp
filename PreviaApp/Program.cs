using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PreviaApp
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length.Equals(0))
                //2558	JESTUPINAN
                InitPatametros("COLTCCS1", "COLTCCS1", "9415", "1", "21", "1");
            // ClsParametros.InitPatametros("00001", "OXIGENOS_USR", "OXIGENOS_USR", "1", "21", "COOXD");
            else
                try
                {
                    /*
                    MessageBox.Show(args+"||"+args[0] + ";" +
                                    args[1] + ";" +
                                    args[2] + ";" +
                                    args[3] + ";" +
                                    args[4] + ";" +
                                    args[5] + ";" +
                                    args[6] + ";" +
                                    args[7] + ";");
                       */


                    InitPatametros(args[0].Replace(",", ""), args[1].Replace(",", ""), args[2].Replace(",", ""), args[3].Replace(",", ""), args[4].Replace(",", ""), args[5].Replace(",", ""));
                }
                catch (Exception ex)
                {

                    MessageBox.Show("oCURRIO UN ERROR INICIANDO EL APLICATIVO : " + ex.Message);
                }
            Application.Run(new Form1());
        }


        public static void InitPatametros(string p_usuario, string p_pwd, string idusuario, string p_gupo, string p_empresa, string p_agencia)

        {
            var parametro = new Parametros();
            parametro.Agencia = p_agencia;
            parametro.Usuario = p_usuario;
            parametro.Password = p_pwd;
            parametro.Grupo = Convert.ToInt16(p_gupo);
            parametro.Empresa = Convert.ToInt16(p_empresa);
            parametro.NombreConexion = "COOXT";
            parametro.TituloAplicativo = "pagos";
            parametro.CodigoAsesor = 0107;
            parametro.UsrId = int.Parse(idusuario);

            Parametros.ParametrosIniciales = parametro;



        }
    }
}
