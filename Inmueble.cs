using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frmInmobiliaria
{
    internal class Inmueble
    {
        //propiedades
        public double Metros { get; set; }

        public double Costo { get; set; }

        public int Tipo { get; set; }

        //constructores
        public Inmueble()
        {
            Metros = Costo = Tipo = 0;
        }

        public Inmueble(double metros, double costo, int tipo)
        {
            this.Metros = metros;
            this.Costo = costo;
            this.Tipo = tipo;
        }

        //metodos
        public string ToStringTipo()
        {
            switch (Tipo)
            {
                case 1: return "Casa";
                case 2: return "Departamento";
                case 3: return "Lote";
                default: return "Otro";
            }
        }

        public string ToStringInmueble()
        {
            return
                $"Metros: {Metros}\n" +
                $"Costo: {Costo}\n" +
                $"Tipo de vivienda: {ToStringTipo()}\n";
        }

        public double Valuacion()
        {
            return Costo * Metros;
        }
    }
}