using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        
        public Operando()
        {
            numero = 0;
        }

        public Operando(string strNumero)
        {
            this.numero = double.Parse(strNumero);
        }

        public Operando(double numero) : this(numero.ToString())
        {
        } 
        
        public static double operator + (Operando num1, Operando num2)
        {
            return num1.numero + num2.numero;
        }

        public static double operator - (Operando num1, Operando num2)
        {
            return num1.numero - num2.numero;
        }

        public static double operator * (Operando num1, Operando num2)
        {
            return num1.numero * num2.numero;
        }

        public static double operator / (Operando num1, Operando num2)
        {
            double resultado;

            if(num2.numero == 0)
            {
                return resultado = double.MinValue;
            }
            return resultado= num1.numero / num2.numero;
        }

        private double ValidarOperando(string strNumero)
        {
            double numero;

            if(!double.TryParse(strNumero, out numero))
            {
                numero = 0;
            }
            return numero;
        }

        
        private static bool EsBinario(string binario)
        {
            bool resultado = true;

            foreach(char c in binario)
            {
                if(c != '0' && c != '1')
                {
                    resultado = false;
                    break;
                }
            }
            return resultado;
        }

        public static string BinarioDecimal(string binario)
        {
            string resultado = "Valor invalido";
            int numero;

            if(Operando.EsBinario(binario))
            {
                numero = Convert.ToInt32(binario, 2);
                if(numero > 0)
                {
                    resultado = numero.ToString();
                }
            }
            return resultado;
        }
        
        public static string DecimalBinario(string numero)
        {
            int num;
            string resultado = "Valor invalido";

            if (int.TryParse(numero, out num))
            {
                if (num > 0)
                {
                    resultado = Convert.ToString(num, 2);
                }
            }
            return resultado;
        }
        public string DecimalBinario(double numero)
        {
            return DecimalBinario(numero.ToString());
        }       
        private string Numero
        {
            set
            {
                this.numero = this.ValidarOperando(value);
            }
        }
    }
}
