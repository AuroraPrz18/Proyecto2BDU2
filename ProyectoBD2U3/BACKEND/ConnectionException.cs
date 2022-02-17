using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBD2U3.BACKEND
{
    public class ConnectionException : Exception
    {
        public ConnectionException() : base("Ha ocurrido un error al conectar con la BD. Intente más tarde o avise al encargado del sistema si sigue presentando problemas.")
        {

        }
    }
}