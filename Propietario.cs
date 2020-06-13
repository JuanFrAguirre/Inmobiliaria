using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmInmobiliaria
{
    internal class Propietario : Persona
    {
        //propiedades
        public long Numero { get; set; }

        internal Inmueble Inmueble { get; set; }

        //constructores
        public Propietario() : base()
        {
            Numero = 0;
            Inmueble = null;
        }

        public Propietario(long numero, Inmueble inmueble, int dni, string nombre, int sexo) : base(dni, nombre, sexo)
        {
            Numero = numero;
            Inmueble = inmueble;
        }

        //metodos
        public string ToStringPropietario()
        {
            return
                $"{base.ToStringPersona()}\n" +
                $"Numero: {Numero}\n" +
                $"\t---------\n" +
                $"Inmueble: \n" +
                $"{Inmueble.ToStringInmueble()}";
        }
    }
}