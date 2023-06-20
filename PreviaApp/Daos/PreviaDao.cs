using Microsoft.Practices.EnterpriseLibrary.Data;
using PreviaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PreviaApp.Daos
{
    public static class PreviaDao
    {
        public static string EMPNMB { get; private set; }

        public static DataSet GetProducto(string codigoProducto, string codigoCLiente, int sucursal)
        {

            string strSQl = @"      select 
                                                SISFACT.FP_BUSCAR_PRECIO(:p_cliente, :p_producto,:p_sucursal) precio,
                                                artdsccorta,
                                                artid,
                                               ( select deta101 from m_tabdes where codta01 =144 and codde01 = artlineanegocio)    lineaNegocio                                                                                             
                                                from stkarticulo  where artid=lpad(:p_producto,7,'0')";
            int id = 0;
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);


            db.AddInParameter(command, "p_cliente", System.Data.DbType.String, codigoCLiente);
            db.AddInParameter(command, "p_producto", System.Data.DbType.String, codigoProducto);
            db.AddInParameter(command, "p_sucursal", System.Data.DbType.Int32, sucursal);




            var ds = db.ExecuteDataSet(command);
            return ds;
        }

        internal static void AsignarSemana(int usrId, int semana)
        {
            string strSQl = @"insert into ROADNET.PH_HISTORICOSEMANA(id,usrid,semana,fecha_aud) 
                values  (roadnet.SQ_PH_HISTORICOSEMANA.nextval,:p_usrid,:p_semana,sysdate )";
            int id = 0;
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);

            db.AddInParameter(command, "p_usrid", System.Data.DbType.Int64, usrId);
            db.AddInParameter(command, "p_semana", System.Data.DbType.Int32, semana);


            var ds = db.ExecuteNonQuery(command);
        
        }

        public static int GetSemanaAnio(DateTime fecha)
        {
            string strSQl = @"     select fn_retornaSemanaConfigurada(:p_fecha) semana from dual";
            int id = 0;
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);

            db.AddInParameter(command, "p_fecha", System.Data.DbType.DateTime, fecha);


            var ds = db.ExecuteDataSet(command);
           return int.Parse(ds.Tables[0].Rows[0][0].ToString());
                


        }


        internal static bool Funcion_Usuario(string v, int usuario)
        {
            string strSQL = @"SELECT  * FROM CS_FUNCION_USUARIO 
                            WHERE FUNCION =:P_funcion
                            and usrid = :p_usrid";


            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("COOX");
            command = db.GetSqlStringCommand(strSQL);
            db.AddInParameter(command, "P_funcion", System.Data.DbType.String, v);
            db.AddInParameter(command, "p_usrid", System.Data.DbType.Int32, usuario);
            var ds = db.ExecuteDataSet(command);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }




        }


        internal static void InsertarRegistro(Previa registro)
        {

          
            




            string strSql = @"                                    INSERT INTO ROADNET.PH_VENTAS_ASESORES
                                  (
                                   EMPID
                                  ,EMPRESA
                                  ,CODI_CLI
                                  ,RAZON_SOCIAL
                                  ,COD_AGENCIA
                                  ,AGENCIA
                                  --,TIPO_CLIENTE
                                  ,VENDED_CLI
                                  --,VENDEDOR
                                  --,GERENTE_SUCURSAL
                                  --,GERENTE_REGIONAL
                                  ,CODI_PRO
                                  ,PRECIO
                                  ,DESC_PRODUCTO
                                  ,LINEA_NEGOCIO
                                  ,VOL_MES1
                                  ,TOTAL_MES1
                                  ,VOL_MES2
                                  ,TOTAL_MES2
                                  ,VOL_MES3
                                  ,TOTAL_MES3
                                  --,CORTE
                                  ,VOL_PREVIA1
                                  ,FACT_PREVIA1
                                  ,VOL_PREVIA2
                                  ,FACT_PREVIA2
                                  ,VOL_PREVIA3
                                  ,FACT_PREVIA3
                                  ,VOL_PREVIA4
                                  ,FACT_PREVIA4
                                  ,ID
                                  ,USRID
                                  ,corte
                                  )
                                VALUES
                                  (
                                   :P_EMPID
                                  ,(select empnmb from cs_empresa where grpecid =1 and empid=:P_EMPID)
                                  ,lpad(:P_CODI_CLI,7,'0')
                                  ,:P_RAZON_SOCIAL
                                  ,lpad(:P_COD_AGENCIA,5,'0')
                                  ,:P_AGENCIA
                                  --,:P_TIPO_CLIENTE
                                  ,lpad(:P_VENDED_CLI,4,'0')
                                  --,:P_VENDEDOR
                                  --,:P_GERENTE_SUCURSAL
                                  --,:P_GERENTE_REGIONAL
                                  ,:P_CODI_PRO
                                  ,:P_PRECIO
                                  ,:P_DESC_PRODUCTO
                                  ,:P_LineEA_NEGOCIO
                                  ,:P_VOL_MES1
                                  ,:P_TOTAL_MES1
                                  ,:P_VOL_MES2
                                  ,:P_TOTAL_MES2
                                  ,:P_VOL_MES3
                                  ,:P_TOTAL_MES3
                                  --,:P_CORTE
                                  ,:P_VOL_PREVIA1
                                  ,:P_FACT_PREVIA1
                                  ,:P_VOL_PREVIA2
                                  ,:P_FACT_PREVIA2
                                  ,:P_VOL_PREVIA3
                                  ,:P_FACT_PREVIA3
                                  ,:P_VOL_PREVIA4
                                  ,:P_FACT_PREVIA4
                                  ,SQ_PREVIA.NEXTVAL
                                  ,:P_USRID
                                  ,to_char(:p_corte,'MM-YYYY')
                                  )";


            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSql);

           db.AddInParameter(command, "p_EMPID", System.Data.DbType.Int32, Parametros.ParametrosIniciales.Empresa);
          // db.AddInParameter(command, "p_EMPRESA", System.Data.DbType.Int32, Parametros.ParametrosIniciales);
            db.AddInParameter(command, "p_CODI_CLI", System.Data.DbType.String, registro.CODI_CLI);
            db.AddInParameter(command, "p_RAZON_SOCIAL", System.Data.DbType.String, registro.RAZON_SOCIAL);
            db.AddInParameter(command, "p_COD_AGENCIA", System.Data.DbType.String, registro.cod_agencia);
            db.AddInParameter(command, "p_AGENCIA", System.Data.DbType.String, registro.AGENCIA);
            //db.AddInParameter(command, "p_TIPO_CLIENTE", System.Data.DbType.Int32, registro.TIPO_CLIENTE);
            db.AddInParameter(command, "p_VENDED_CLI", System.Data.DbType.String, Parametros.ParametrosIniciales.CodigoAsesor);
            //db.AddInParameter(command, "p_VENDEDOR", System.Data.DbType.Int32, registro.);
           // db.AddInParameter(command, "p_GERENTE_SUCURSAL", System.Data.DbType.Int32, registro.g);
            //db.AddInParameter(command, "p_GERENTE_REGIONAL", System.Data.DbType.Int32, registro.GERENTE_REGIONAL);
            db.AddInParameter(command, "p_CODI_PRO", System.Data.DbType.String, registro.CODI_PRO);
            db.AddInParameter(command, "p_PRECIO", System.Data.DbType.Int32, registro.PRECIO_MES);
            db.AddInParameter(command, "p_DESC_PRODUCTO", System.Data.DbType.String, registro.DESC_PRODUCTO);
            db.AddInParameter(command, "P_LineEA_NEGOCIO", System.Data.DbType.String, registro.LINEA_NEGOCIO);
            db.AddInParameter(command, "p_VOL_MES1", System.Data.DbType.Double, registro.VOL_MES1);
            db.AddInParameter(command, "p_TOTAL_MES1", System.Data.DbType.Double, registro.TOTAL_MES1);
            db.AddInParameter(command, "p_VOL_MES2", System.Data.DbType.Double, registro.VOL_MES2);
            db.AddInParameter(command, "p_TOTAL_MES2", System.Data.DbType.Double, registro.TOTAL_MES2);
            db.AddInParameter(command, "p_VOL_MES3", System.Data.DbType.Double, registro.VOL_MES3);
            db.AddInParameter(command, "p_TOTAL_MES3", System.Data.DbType.Double, registro.TOTAL_MES3);
            //db.AddInParameter(command, "p_CORTE", System.Data.DbType.Int32, registro.c);
            db.AddInParameter(command, "p_VOL_PREVIA1", System.Data.DbType.Double, registro.VOL_PREVIA1);
            db.AddInParameter(command, "p_FACT_PREVIA1", System.Data.DbType.Double, registro.FACT_PREVIA1);
            db.AddInParameter(command, "p_VOL_PREVIA2", System.Data.DbType.Double, registro.VOL_PREVIA2);
            db.AddInParameter(command, "p_FACT_PREVIA2", System.Data.DbType.Double, registro.FACT_PREVIA2);
            db.AddInParameter(command, "p_VOL_PREVIA3", System.Data.DbType.Double, registro.VOL_PREVIA3);
            db.AddInParameter(command, "p_FACT_PREVIA3", System.Data.DbType.Double, registro.FACT_PREVIA3);
            db.AddInParameter(command, "p_VOL_PREVIA4", System.Data.DbType.Double, registro.VOL_PREVIA4);
            db.AddInParameter(command, "p_FACT_PREVIA4", System.Data.DbType.Double, registro.FACT_PREVIA4);
            //db.AddInParameter(command, " ,SQ_PREVIA.NEXTVAL", System.Data.DbType.Int32, , SQ_PREVIA.NEXTVAL);
            db.AddInParameter(command, "p_USRID", System.Data.DbType.Int32,Parametros.ParametrosIniciales.UsrId);
            db.AddInParameter(command, "p_corte", System.Data.DbType.DateTime, Parametros.ParametrosIniciales.Periodo);



            db.ExecuteNonQuery(command);



        }

        internal static string ValidaProducto(string artid)
        {
            string strSql = @"select 
                            artid, 1||substr(artid,2) flete
                            from roadnet.PB_PRODUCTOS_LIQUIDOS
                            where artid= :p_artid
                            ";


            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSql);

            db.AddInParameter(command, "p_artid", System.Data.DbType.String, artid);
          


            var ds = db.ExecuteDataSet(command);
            string retorno="-1";
            if (ds.Tables[0].Rows.Count>0)
            {

                retorno = (ds.Tables[0].Rows[0]["flete"].ToString());

            }
            else
            {
                retorno = "-1";
            }

            return retorno;
        }

        public static int VallidaExisteRegistro(Previa registro)
        {
            string strSql = @"select count(*) cantidad from  ROADNET.PH_VENTAS_ASESORES
                            where codi_cli = LPAD(:p_codi_cli,7,'0')
                            and vended_cli = lpad(:p_vended_cli,4,'0')
                            and codi_pro=LPAD(:p_codi_pro,7,'0')
                            and corte = to_char(:p_corte,'MM-YYYY')";




            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSql);

            db.AddInParameter(command, "p_codi_cli", System.Data.DbType.String, registro.CODI_CLI);
            //db.AddInParameter(command, "p_cod_agencia", System.Data.DbType.String, registro.cod_agencia);
            db.AddInParameter(command, "p_vended_cli", System.Data.DbType.String, Parametros.ParametrosIniciales.CodigoAsesor);
            db.AddInParameter(command, "p_codi_pro", System.Data.DbType.String, registro.CODI_PRO);
            db.AddInParameter(command, "p_corte", System.Data.DbType.Date, Parametros.ParametrosIniciales.Periodo);


            var ds = db.ExecuteDataSet(command);
            var retorno =int.Parse( ds.Tables[0].Rows[0]["cantidad"].ToString());

            return retorno;

        }

        public static void ActualizarvaloresPrevias()
        {
            string strSql = "roadnet.SP_ACTUALIZAR_PLANTILLA_PREVIA";


            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetStoredProcCommand(strSql);

            db.AddInParameter(command, "p_VENDED_CLI", System.Data.DbType.String, Parametros.ParametrosIniciales.CodigoAsesor);
            db.AddInParameter(command, "p_corte", System.Data.DbType.DateTime, Parametros.ParametrosIniciales.Periodo);

            db.ExecuteNonQuery(command);



        }

        internal static DataSet GetSucursales(int empid)
        {

            string strSQl = @"select scrid,scrnmb from cs_sucursal where empid=:p_empid and grpecid=1";

            int id = 0;
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);

            db.AddInParameter(command, "p_empid", System.Data.DbType.String, empid);

            
            var ds = db.ExecuteDataSet(command);
            return ds;
        }

        public static DataSet GetCliente(string codigoCliente,string conexion)
        {
            string strSQl = @"   select razon__cli,client_cli from m_df01 where client_cli =lpad(:p_client_cli,7,'0')";
            int id = 0;
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase(conexion);
            command = db.GetSqlStringCommand(strSQl);

            db.AddInParameter(command, "p_client_cli", System.Data.DbType.String, codigoCliente);


            var ds = db.ExecuteDataSet(command);
            return ds;

        }


        public static List<Previa> getVentasXasesor(int vendedor, DateTime periodo, int empresa)
        {

            List<Previa> lista = new List<Previa>();



            string strSQl = @"  SELECT a.* FROM ROADNET.PH_VENTAS_ASESORES a
                                                where vended_cli = :p_vended_cli
                                                and  corte = to_char(:p_corte,'MM-YYYY')
                                                and empid=:p_empid
                                order by razon_social asc,total_mes1 desc ";
            int id = 0;
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);

            db.AddInParameter(command, "p_vended_cli", System.Data.DbType.Int32, vendedor);

            db.AddInParameter(command, "p_corte", System.Data.DbType.DateTime, periodo);

            db.AddInParameter(command, "p_empid", System.Data.DbType.Int64, empresa);





            var ds = db.ExecuteDataSet(command);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                try
                {
                    lista.Add(new Previa
                    {
                        CODI_CLI = fila["CODI_CLI"].ToString(),
                        CODI_PRO = fila["CODI_PRO"].ToString(),
                        DESC_PRODUCTO = fila["DESC_PRODUCTO"].ToString(),
                        FACT_PREVIA1 = double.Parse(fila["FACT_PREVIA1"].ToString()),
                        FACT_PREVIA2 = double.Parse(fila["FACT_PREVIA2"].ToString()),
                        FACT_PREVIA3 = double.Parse(fila["FACT_PREVIA3"].ToString()),
                        FACT_PREVIA4 = double.Parse(fila["FACT_PREVIA4"].ToString()),
                         AGENCIA= fila["AGENCIA"].ToString(),
                        ID = int.Parse(fila["ID"].ToString()),
                        LINEA_NEGOCIO = fila["LINEA_NEGOCIO"].ToString(),
                        PRECIO_MES = double.Parse(fila["PRECIO"].ToString()),
                       // PROM_FACT = double.Parse(fila["PROM_FACT"].ToString()),
                        //PROM_VOL = double.Parse(fila["PROM_VOL"].ToString()),
                        RAZON_SOCIAL = (fila["RAZON_SOCIAL"].ToString()),
                        TOTAL_MES1 = double.Parse(fila["TOTAL_MES1"].ToString()),
                        TOTAL_MES2 = double.Parse(fila["TOTAL_MES2"].ToString()),
                        TOTAL_MES3 = double.Parse(fila["TOTAL_MES3"].ToString()),
                        VENDED_CLI = (fila["VENDED_CLI"].ToString()),
                        VOL_MES1 = double.Parse(fila["VOL_MES1"].ToString()),
                        VOL_MES2 = double.Parse(fila["VOL_MES2"].ToString()),
                        VOL_MES3 = double.Parse(fila["VOL_MES3"].ToString()),
                        VOL_PREVIA1 = double.Parse(fila["VOL_PREVIA1"].ToString()),
                        VOL_PREVIA2 = double.Parse(fila["VOL_PREVIA2"].ToString()),
                        VOL_PREVIA3 = double.Parse(fila["VOL_PREVIA3"].ToString()),
                        VOL_PREVIA4 = double.Parse(fila["VOL_PREVIA4"].ToString()),
                         cod_agencia= fila["cod_agencia"].ToString()



                    });
                }
                catch (Exception ex)
                {

                    throw;
                }
           
            }

            return lista;


        }


        public static List<Previa> GetPreviaCompleta()
        {

            List<Previa> lista = new List<Previa>();



            string strSQl = @"  SELECT* from VW_PREVIA 
                                where empid =:p_empid ";
            int id = 0;
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
           

            command = db.GetSqlStringCommand(strSQl);

            db.AddInParameter(command, "p_empid", System.Data.DbType.Int64, Parametros.ParametrosIniciales.Empresa);




            var ds = db.ExecuteDataSet(command);

            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                try
                {
                    lista.Add(new Previa
                    {
                        CODI_CLI = fila["CODI_CLI"].ToString(),
                        CODI_PRO = fila["CODI_PRO"].ToString(),
                        DESC_PRODUCTO = fila["DESC_PRODUCTO"].ToString(),
                        FACT_PREVIA1 = double.Parse(fila["FACT_PREVIA1"].ToString()),
                        FACT_PREVIA2 = double.Parse(fila["FACT_PREVIA2"].ToString()),
                        FACT_PREVIA3 = double.Parse(fila["FACT_PREVIA3"].ToString()),
                        FACT_PREVIA4 = double.Parse(fila["FACT_PREVIA4"].ToString()),
                        AGENCIA = fila["AGENCIA"].ToString(),
                        //ID = int.Parse(fila["ID"].ToString()),
                        LINEA_NEGOCIO = fila["LINEA_NEGOCIO"].ToString(),
                        PRECIO_MES = double.Parse(fila["PRECIO"].ToString()),
                        // PROM_FACT = double.Parse(fila["PROM_FACT"].ToString()),
                        //PROM_VOL = double.Parse(fila["PROM_VOL"].ToString()),
                        RAZON_SOCIAL = (fila["RAZON_SOCIAL"].ToString()),
                        TOTAL_MES1 = double.Parse(fila["TOTAL_MES1"].ToString()),
                        TOTAL_MES2 = double.Parse(fila["TOTAL_MES2"].ToString()),
                        TOTAL_MES3 = double.Parse(fila["TOTAL_MES3"].ToString()),
                        VENDED_CLI = (fila["VENDED_CLI"].ToString()),
                        VOL_MES1 = double.Parse(fila["VOL_MES1"].ToString()),
                        VOL_MES2 = double.Parse(fila["VOL_MES2"].ToString()),
                        VOL_MES3 = double.Parse(fila["VOL_MES3"].ToString()),
                        VOL_PREVIA1 = double.Parse(fila["VOL_PREVIA1"].ToString()),
                        VOL_PREVIA2 = double.Parse(fila["VOL_PREVIA2"].ToString()),
                        VOL_PREVIA3 = double.Parse(fila["VOL_PREVIA3"].ToString()),
                        VOL_PREVIA4 = double.Parse(fila["VOL_PREVIA4"].ToString()),
                        cod_agencia = fila["cod_agencia"].ToString(),
                        GERENTE_SUC_MAIL = fila["GERENTE_SUC_MAIL"].ToString(),
                        GERENTE_SUC = fila["GERENTE_SUC"].ToString(),
                        GERENTE_REP_MAIL = fila["GERENTE_REP_MAIL"].ToString(),
                        GERENTE_REP = fila["GERENTE_REP"].ToString(),
                        GERENTE_REG_MAIL = fila["GERENTE_REG_MAIL"].ToString(),
                        GERENTE_REG = fila["GERENTE_REG"].ToString(),
                        NOMBRE_VENDEDOR = fila["NOMBRE_VENDEDOR"].ToString(),
                        EMPNMB = fila["EMPNMB"].ToString()







                    });
                }
                catch (Exception ex)
                {

                    throw;
                }

            }

            return lista;

        }

        internal static void ActualizarRegistro(Previa item,int periodo)
        {

            string strSQl = @"    update ROADNET.PH_VENTAS_ASESORES 
                                                set vol_previa1 = decode(:p_periodo,1,:p_vol_previa1,vol_previa1),
                                                    vol_previa2 = decode(:p_periodo,2,:p_vol_previa2,vol_previa2),
                                                    vol_previa3 = decode(:p_periodo,3,:p_vol_previa3,vol_previa3),
                                                    vol_previa4 = decode(:p_periodo,4,:p_vol_previa4,vol_previa4),
                                                    fact_previa1=decode(:p_periodo,1,:p_fact_previa1,fact_previa1),
                                                    fact_previa2=decode(:p_periodo,2,:p_fact_previa2,fact_previa2),
                                                    fact_previa3=decode(:p_periodo,3,:p_fact_previa3,fact_previa3),
                                                    fact_previa4=decode(:p_periodo,4,:p_fact_previa4,fact_previa4),
                                                    Precio = :P_Precio,
                                                    USRID= :P_USRID
                                                 where id=:p_id";
            int id = 0;
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQl);

            db.AddInParameter(command, "p_periodo", System.Data.DbType.Int32, periodo);

            db.AddInParameter(command, "p_vol_previa1", System.Data.DbType.Int32, item.VOL_PREVIA1);
            db.AddInParameter(command, "p_vol_previa2", System.Data.DbType.Int32, item.VOL_PREVIA2);
            db.AddInParameter(command, "p_vol_previa3", System.Data.DbType.Int32, item.VOL_PREVIA3);
            db.AddInParameter(command, "p_vol_previa4", System.Data.DbType.Int32, item.VOL_PREVIA4);

            db.AddInParameter(command, "p_fact_previa1", System.Data.DbType.Int32, item.FACT_PREVIA1);
            db.AddInParameter(command, "p_fact_previa2", System.Data.DbType.Int32, item.FACT_PREVIA2);
            db.AddInParameter(command, "p_fact_previa3", System.Data.DbType.Int32, item.FACT_PREVIA3);
            db.AddInParameter(command, "p_fact_previa4", System.Data.DbType.Int32, item.FACT_PREVIA4);

            db.AddInParameter(command, "P_Precio", System.Data.DbType.Int32, item.PRECIO_MES);


            db.AddInParameter(command, "P_USRID", System.Data.DbType.Int32, Parametros.ParametrosIniciales.UsrId);

            db.AddInParameter(command, "p_id", System.Data.DbType.Int32, item.ID);

            db.ExecuteNonQuery(command);

        }

        public static List<Vendedor> GetVendedoresAsociados(int usrid, int empId) {


            //var strSQL = "OXIGENOS_USR.PKG_PREVIA_MENSUAL.SPSP_GET_VENDEDOR";
            try
            {

            
            var strSQL = "ROADNET.USUARIOSPREVIA";
            List<Vendedor> vendedores = new List<Vendedor>();


            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetStoredProcCommand(strSQL);

            db.AddInParameter(command, "P_USRID", System.Data.DbType.Int32, usrid);
            db.AddInParameter(command, "P_EMPID", System.Data.DbType.Int32, empId);


            var ds = db.ExecuteDataSet(command);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                vendedores.Add(new Vendedor
                {
                    Nombre = item["NOMBRE"].ToString(),
                     UsrId = usrid,
                      VendedorId = item["COD_VEND"].ToString(),

                });

            }
            


        return vendedores;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }

        }


        public static DataSet GetPrevia()
        {


            var strSQL = "select * from VW_PREVIA";
            List<Vendedor> vendedores = new List<Vendedor>();


            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetStoredProcCommand(strSQL);
            


            var ds = db.ExecuteDataSet(command);

        



            return ds;



        }


        public static DataSet GetEmpresas()
        {

            try
            {
            var strSQL = "select empid,empalias,empnmb from cs_empresa where grpecid=1 order by empnmb asc";
          
            DbCommand command;
            Database db = DatabaseFactory.CreateDatabase("ConexionOracle");
            command = db.GetSqlStringCommand(strSQL);



            var ds = db.ExecuteDataSet(command);





            return ds;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return null;
            }

        }

    }


}
