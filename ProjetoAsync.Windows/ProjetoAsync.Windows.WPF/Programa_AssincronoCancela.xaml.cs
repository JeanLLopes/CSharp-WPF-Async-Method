using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class Programa_AssincronoCancela : Window
    {

        //PARA HABILITAR O CANCELAMENTO TENHO QUE CRIA UMA VARIAVEL DO TIPO 
        //cancellationToken que é do tipo CancellationTokenSource
        //QUE FAZ PARTE DO SEGUINTE NAMESPACE
        //using System.Threading;
        private CancellationTokenSource _cancellationToken;



        public Programa_AssincronoCancela()
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
            ButtonCancelar.IsEnabled = true;


            //INICIAMOS O CONTADOR
            DateTime horarioInicio = DateTime.Now;



            //PEGAMOS O VALOR QUE O USUARIO DIGITOU
            Int32 valorCliente = Convert.ToInt32(TextBoxValor.Text);


            //INICIALIZAMOS A VARIAVEL DO TIPO CANCELATIONTOKEN
            _cancellationToken = new CancellationTokenSource();

            try
            {

                //EXECUTAMOS O CALCULO PARA O RESULTADO DO FATORIAL SINCRONO
                String resultado = await CalculoDeNumerais.RetornaNumerosContadorAsyncCancel(valorCliente, _cancellationToken.Token);



                //COM OS DADOS DE RETORNO NA CLASSE NO AGORA VAMOS USAR O LINQ PARA PEGAR OS DADOS QUE QUEREMOS
                //LINQ DE OBJETOS
                var numerosIndividuais = from d in resultado
                                         group d by d
                                             into dados
                                             orderby dados.Key
                                             select new { Numero = dados.Key, Quantidade = dados.Count() };



                //PREENCHO MINHA LISTA COM OS DADOS DA TELA
                foreach (var i in numerosIndividuais)
                {
                    ListBoxResultado.Items.Add(String.Format("O Número {0}: se repete {1:N0}", i.Numero, i.Quantidade));
                }




                //FINALIZAMOS O CONTADOR DE PEGANDO O HORARIO FINAL
                DateTime horarioFinal = DateTime.Now;


                //CALCULAMOS O INTERVALO ENTRE O PERIODO DE INICIO E O FINAL
                TimeSpan intervalo = horarioFinal - horarioInicio;


                //EXIBIMOS A MENSAGEM FINAL PARA O USUARIO
                //COM O CALCULO DE INTERVALO
                LabelResultado.Content = String.Format("O TEMPO FINAL PARA O PROCESSO É DE {0:N3} - segundos", intervalo.TotalSeconds);
            }


            //CASO O CLIENTE CLIQUE NO BOTÃO DE CANCELAR SERÁ EXECUTADO UMA OperationCanceledException
            //COM ESSE OperationCanceledException CAPTURAMOS O FINAL DO CLIQUE DE CANCELAR
            //E EXIBIMOS UMA MENSAGEM PARA O CLIENTE 
            catch (OperationCanceledException)
            {
                LabelResultado.Content = String.Format("O USUARIO CANCELOU A OPERAÇÃO...");

            }



            //HABILITAMOS O BOTÃO DE RESULTADO PARA O USUARIO
            ButtonResultado.IsEnabled = true;
            ButtonCancelar.IsEnabled = false;
            TextBoxValor.Text = String.Empty;

        }



        /// <summary>
        /// CAPTURAMOS O EVENTO CLIQUE DO BOTÃO DE CANCELAMENTO
        /// </summary>
        private void ButtonCancelar_Click(object sender, RoutedEventArgs e)
        {
            _cancellationToken.Cancel();
        }
    }
}
