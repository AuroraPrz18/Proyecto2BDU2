using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBD2U3.BACKEND
{
    public class NoControllerException : Exception
    {
        public NoControllerException() : base("Ha ocurrido un error a la hora de intentar realizar la acción, intente más tarde y si sigue experimentando problemas contacte al encargado del sistema.")
        {

        }
        public NoControllerException(string message) : base(message)
        {

        }

    }
}