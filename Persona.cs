using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmInmobiliaria
{
    internal abstract class Persona
    {
        //atributos
        protected int dni, sexo;

        protected string nombre;

        //propiedades
        public int DNI { get => dni; set => dni = value; }

        public string Nombre { get => nombre; set => nombre = value; }

        public int Sexo { get => sexo; set => sexo = value; }

        //constructores
        protected Persona()
        {
            DNI = 0;
            Nombre = "";
            Sexo = 0;
        }

        protected Persona(int dni, string nombre, int sexo)
        {
            DNI = dni;
            Nombre = nombre;
            Sexo = sexo;
        }

        //metodos
        public string ToStringSexo()
        {
            switch (Sexo)
            {
                case 1: return "Masculino";
                case 2: return "Femenino";
                default: return "Otro";
            }
        }

        public string ToStringPersona()
        {
            return
                $"DNI: {DNI}\n" +
                $"Nombre: {Nombre}\n" +
                $"Sexo: {ToStringSexo()}\n";
        }
    }
}