using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreviaApp.Entidades
{
    public class Previa

    {
        public int ID { get; set; }
        public string VENDED_CLI { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string CODI_CLI { get; set; }
        public string LINEA_NEGOCIO { get; set; }
        public string CODI_PRO { get; set; }
        public string DESC_PRODUCTO { get; set; }
        public double PRECIO_MES { get; set; }
        public double VOL_MES1 { get; set; }
        public double VOL_MES2 { get; set; }
        public double VOL_MES3 { get; set; }
        public double TOTAL_MES1 { get; set; }
        public double TOTAL_MES2 { get; set; }
        public double TOTAL_MES3 { get; set; }
        public double PROM_VOL
        {
            get { return (VOL_MES1 + VOL_MES2 + VOL_MES3) / 3; }
        }
                
        public double PROM_FACT
        {
            get { return (TOTAL_MES1 + TOTAL_MES2 + TOTAL_MES3) / 3; }
        }

        public double VOL_PREVIA1 { get; set; }
        public double FACT_PREVIA1 { get; set; }
        public double VOL_PREVIA2 { get; set; }
        public double FACT_PREVIA2 { get; set; }
        public double VOL_PREVIA3 { get; set; }
        public double FACT_PREVIA3 { get; set; }
        public double VOL_PREVIA4 { get; set; }
        public double FACT_PREVIA4 { get; set; }
        public int estadoEdicion { get; set; }
        public string AGENCIA { get; set; }
        public string cod_agencia{ get; set; }
        public string GERENTE_SUC_MAIL { get;  set; }
        public string GERENTE_SUC { get; internal set; }
        public string GERENTE_REP_MAIL { get;  set; }
        public string GERENTE_REP { get;  set; }
        public string GERENTE_REG_MAIL { get;  set; }
        public string GERENTE_REG { get;  set; }
        public string NOMBRE_VENDEDOR { get; internal set; }
        public string EMPNMB { get; internal set; }
    }
}
