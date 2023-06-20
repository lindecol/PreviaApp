using PreviaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreviaApp
{
    public class Parametros
    {
        public static List<Vendedor> listaVendedores;
        public static Parametros ParametrosIniciales;
        private string _agencia;
        private string _usuario;
        private string _password;
        private int _empresa;
        private int _grupo;
        private int _Token;
        private string _Cliente;
        private string _SubDeposito;
        private string _TituloAplicativo;
        private string _NombreConexion;
        private string _Entidad;
        private string _Domicilio;
        private string _ruta;
        private DateTime _Fecha;

        public int CodigoAsesor { get; set; }
        public string   NombreAsesor{ get; set; }

        public int UsrId { get; set; }

  

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public string Ruta
        {
            get { return _ruta; }
            set { _ruta = value; }
        }

        public string Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }
        }

        public string Entidad
        {
            get { return _Entidad; }
            set { _Entidad = value; }
        }

        public string Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        public string NombreConexion
        {
            get { return _NombreConexion; }
            set { _NombreConexion = value; }
        }

        public string SubDeposito
        {
            get { return _SubDeposito; }
            set { _SubDeposito = value; }
        }

        public string Agencia
        {
            get { return _agencia; }
            set { _agencia = value; }
        }

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int Grupo
        {
            get { return _grupo; }
            set { _grupo = value; }
        }

        public int Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        public int Token
        {
            get { return _Token; }
            set { _Token = value; }
        }

        public string TituloAplicativo
        {
            get { return _TituloAplicativo; }
            set { _TituloAplicativo = value; }
        }

        public DateTime Periodo { get; internal set; }
    }
}
