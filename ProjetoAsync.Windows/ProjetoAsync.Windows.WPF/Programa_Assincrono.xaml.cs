using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetoAsync.Windows.WPF
{
    public  partial class Programa_Assincrono : Window
    {
        public Programa_Assincrono()
        {
            InitializeComponent();
        }


        /// <summary>
        /// DEFINIMOS UM EVENTO CLIQUE PARA O BOTÃO RESULTADO
        /// </summary>
        private async void ButtonResultado_Click(object sender, RoutedEventArgs e)
        {
            //LIMPAMOS OS CAMPOS DA TELAS
            LabelResultado.Content = String.Empty;
            ListBoxResultado.Items.Clear();
            ButtonResultado.IsEnabled = false;


            //INICIAMOS A CONTAGEM
            DateTime horarioInicio = DateTime.Now;


            #region CALCULO PARA OS DADOS DO CLIENTE


            //PEGAMOS O VALOR QUE USUARIO DIGITOU
            Int32 valorCliente =  Convert.ToInt32(TextBoxValor.Text);



            //EXECUTAMOS O CALCULO PARA O RESULTADO DO FATORIAL SINCRONO
            String resultado = await CalculoDeNumerais.RetornaNumerosContadorAsync(valorCliente);



            //COM OS DADOS DE RETORNO NA CLASSE NO AGORA VAMOS USAR O LINQ PARA PEGAR OS DADOS QUE QUEREMOS
            //LINQ DE OBJETOS
            var numerosIndividuais = from d in resultado
                                    group d by d
                                    into dados
                                    orderby dados.Key
                                    select new {Numero = dados.Key, Quantidade = dados.Count()};


            //PREENCHO MINHA LISTA COM OS DADOS DA TELA
            foreach (var i in numerosIndividuais)
            {
                ListBoxResultado.Items.Add(String.Format("O Número {0}: se repete {1:N0}", i.Numero, i.Quantidade));
            }

            #endregion


            //FINALIZAMOS O CONTADOR DE PEGANDO O HORARIO FINAL
            DateTime horarioFinal = DateTime.Now;

            //CALCULAMOS O INTERVALO ENTRE O PERIODO DE INICIO E O FINAL
            TimeSpan intervalo = horarioFinal - horarioInicio;


            //EXIBIMOS A MENSAGEM FINAL PARA O USUARIO
            //COM O CALCULO DE INTERVALO
            LabelResultado.Content = String.Format("O TEMPO FINAL PARA O PROCESSO É DE {0:N3} - segundos", intervalo.TotalSeconds);


            //HABILITAMOS O BOTÃO DE RESULTADO PARA O USUARIO
            ButtonResultado.IsEnabled = true;
        }
    }
}
