using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmInmobiliaria
{
    public partial class frmInmobiliaria : Form
    {
        //contadores
        private int contCasas, contDeptos, contLotes, cantTotal, mujeresConDepto;

        private double acuCasas, acuDeptos, acuLotes, acuTotal, porcCasas;

        private Propietario mayor, loteMenor;

        public frmInmobiliaria()
        {
            InitializeComponent();
            acuCasas = acuDeptos = acuLotes = acuTotal = porcCasas = contCasas = contDeptos = contLotes = cantTotal = mujeresConDepto = 0;
            mayor = loteMenor = null;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //////////////////////  ---carga de datos (propietario + inmueble)---
            //inmueble
            Inmueble inmueble1 = new Inmueble();
            inmueble1.Metros = double.Parse(txtMetros.Text);
            inmueble1.Costo = double.Parse(txtCosto.Text);
            inmueble1.Tipo = cboTipo.SelectedIndex + 1;

            // propietario
            int sexo = 1;
            if (rdoFem.Checked) sexo = 2;
            if (rdoOtro.Checked) sexo = 3;

            Propietario prop1 = new Propietario();
            prop1.DNI = int.Parse(txtDNI.Text);
            prop1.Nombre = txtNombre.Text;
            prop1.Sexo = sexo;
            prop1.Numero = long.Parse(txtNum.Text);
            prop1.Inmueble = inmueble1;

            MessageBox.Show(prop1.ToStringPropietario());

            //////////////////////  ---datos inmuebles---
            //calculos
            switch (prop1.Inmueble.Tipo)
            {
                case 1: contCasas++; acuCasas += prop1.Inmueble.Valuacion(); break;
                case 2: contDeptos++; acuDeptos += prop1.Inmueble.Valuacion(); break;
                case 3: contLotes++; acuLotes += prop1.Inmueble.Valuacion(); break;
            }

            //cantidades
            txtCantCasas.Text = contCasas.ToString();
            txtCantDeptos.Text = contDeptos.ToString();
            txtCantLotes.Text = contLotes.ToString();

            //valuaciones promedio
            if (contCasas == 0) txtValCasas.Text = "-";
            else txtValCasas.Text = Math.Round((acuCasas / contCasas), 2).ToString();
            if (contDeptos == 0) txtValDeptos.Text = "-";
            else txtValDeptos.Text = Math.Round((acuDeptos / contDeptos), 2).ToString();
            if (contLotes == 0) txtValLotes.Text = "-";
            else txtValLotes.Text = Math.Round((acuLotes / contLotes), 2).ToString();

            //////////////////////  ---otros datos---
            //calculos
            //valuacion promedio total
            cantTotal = contCasas + contDeptos + contLotes;
            acuTotal = acuCasas + acuDeptos + acuLotes;
            //porcentaje casas
            porcCasas = (contCasas * 100) / cantTotal;
            //mujeres con depto
            if (prop1.Inmueble.Tipo == 2 && prop1.Sexo == 2) mujeresConDepto++;

            //asignaciones
            txtValPromTotal.Text = Math.Round((acuTotal / cantTotal), 2).ToString();
            txtPorcCasas.Text = Math.Round(porcCasas, 2).ToString();
            txtMujeresConDeptos.Text = mujeresConDepto.ToString();

            //////////////////////  ---propietarios---
            //calculos mayor y menor
            if (mayor == null) mayor = prop1;
            else if (prop1.Inmueble.Valuacion() > mayor.Inmueble.Valuacion()) mayor = prop1;

            if (loteMenor == null && prop1.Inmueble.Tipo == 3) loteMenor = prop1;
            else if (prop1.Inmueble.Tipo == 3 && prop1.Inmueble.Metros < loteMenor.Inmueble.Metros) loteMenor = prop1;

            //asignaciones
            lblMayor.Text = mayor.ToStringPropietario();
            lblMayor.TextAlign = ContentAlignment.TopLeft;
            if (loteMenor != null)
            {
                lblLoteMenor.Text = loteMenor.ToStringPropietario();
                lblLoteMenor.TextAlign = ContentAlignment.TopLeft;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}