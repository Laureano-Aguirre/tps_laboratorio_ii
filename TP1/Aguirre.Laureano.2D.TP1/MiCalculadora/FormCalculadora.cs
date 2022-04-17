using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            btnConvertirADecimal.Enabled = true;
            btnConvnertirABinario.Enabled = true;
        }

        private void btnConvnertirABinario_Click(object sender, EventArgs e)
        {
            string resultado;
            if(txtNumero1.Text !="" && txtNumero1.Text!= "" && lblResultado.Text!="0" && lblResultado.Text!="Valor Invalido")
            {
                resultado = Operando.DecimalBinario(lblResultado.Text);
                lblResultado.Text = resultado;
                btnConvnertirABinario.Enabled = false;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultado;
            if (txtNumero1.Text != "" && txtNumero1.Text != "" && lblResultado.Text != "0" && lblResultado.Text != "Valor Invalido")
            {
                resultado = Operando.BinarioDecimal(lblResultado.Text);
                lblResultado.Text = resultado;
                btnConvertirADecimal.Enabled = false;
            }
        }
        private void Limpiar()
        {
            cmbOperador.SelectedItem = "";
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "0";
        }

        public static double Operar(string numero1, string numero2, string operador)
        {
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            if(numero2=="0" && operador=="/")
            {
                MessageBox.Show("El segundo operador es igual a 0, y no se puede dividir por 0", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return Calculadora.Operar(num1 , num2 , Convert.ToChar(operador));
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = txtNumero1.Text;
            string num2 = txtNumero2.Text;
            string operador = cmbOperador.Text;
            double validar;
            double resultado;

            if(double.TryParse(num1, out validar) && double.TryParse(num2, out validar))
            {
                if(operador==string.Empty)
                {
                    operador = "+";
                }
                resultado = FormCalculadora.Operar(num1, num2, operador);
                lblResultado.Text = resultado.ToString();
                lstOperaciones.Items.Add(num1+operador+num2+"="+resultado.ToString());
            }
            else
            {
                MessageBox.Show("No se llenaron los campos correctamente.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
