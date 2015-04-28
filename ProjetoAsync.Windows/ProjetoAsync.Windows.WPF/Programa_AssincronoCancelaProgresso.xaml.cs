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
    /// <summary>
    /// Interaction logic for Programa_AssincronoCancelaProgresso.xaml
    /// </summary>
    public partial class Programa_AssincronoCancelaProgresso : Window
    {

        //PARA HABILITAR O CANCELAMENTO TENHO QUE CRIA UMA VARIAVEL DO TIPO 
        //cancellationToken que é do tipo CancellationTokenSource
        //QUE FAZ PARTE DO SEGUINTE NAMESPACE
        //using System.Threading;
        private CancellationTokenSource _cancellationToken;

        public Programa_AssincronoCancelaProgresso()
        {
            InitializeComponent();
        }



        /// <summary>
        /// DEFINIMOS UM EVENTO CLIQUE PARA O BOTÃO RESULTADO
        /// </summary>
        private async void ButtonResultado_Click(object sender, RoutedEventArgs e)
        {
            //LIMPAMOS OS CAMPOS DA TELAS
            ButtonResultado.IsEnabled = false;
            ButtonCancelar.IsEnabled = true;
            ProgressBarResultado.Visibility = Visibility.Visible;
            ListBoxResultado.Items.Clear();
            LabelResultado.Content = String.Empty;


            //INICIO A CONTAGEM
            DateTime horarioInicio = DateTime.Now;

            //PEGAMOS O VALOR QUE O USUARIO DIGITOU
            Int32 valorCliente = Convert.ToInt32(TextBoxValor.Text);


            //PASSO A VARIAVEL DE CANCELAMENTO
            _cancellationToken = new CancellationTokenSource();


            try
            {
                //AGORA VAMOS PARA O VALOR DO PROGRESSO
                ProgressBarResultado.Maximum = valorCliente;



                //CRIAMOS UMA VARIAVEL PARA CAPTURAR OS VALORES DA BARRA DE POGRESSO 
                Progress<int> progresso = new Progress<int>();
                progresso.ProgressChanged += (s, valorAtual) => ProgressBarResultado.Value = valorAtual;


                //EXECUTAMOS O CALCULO PARA O RESULTADO DO FATORIAL SINCRONO
                String resultado = await CalculoDeNumerais.RetornaNumerosContadorAsyncCancelProgress(valorCliente, _cancellationToken.Token, progresso);



                //COM OS DADOS DE RETORNO NA CLASSE NO AGORA VAMOS USAR O LINQ PARA PEGAR OS DADOS QUE QUEREMOS
                //LINQ DE OBJETOS
                var numerosIndividuais = from b in resultado
                                         group b by b
                                             into dados
                                             orderby dados.Key
                                             select new { Numero = dados.Key, Quantidade = dados.Count() };


                //PREENCHO MINHA LISTA COM OS DADOS DA TELA
                foreach (var item in numerosIndividuais)
                {
                    ListBoxResultado.Items.Add(String.Format("O Número {0}: se repete {1:N0}", item.Numero, item.Quantidade));
                }



                //FINALIZAMOS O CONTADOR DE PEGANDO O HORARIO FINAL
                DateTime horarioFinal = DateTime.Now;


                //CALCULAMOS O INTERVALO ENTRE O PERIODO DE INICIO E O FINAL
                TimeSpan intervalo = horarioFinal - horarioInicio;



                //EXIBIMOS A MENSAGEM FINAL PARA O USUARIO
                //COM O CALCULO DE INTERVALO
                LabelResultado.Content = String.Format(" O TEMPO FINAL PARA O PROCESSO É DE {0:N3} - segundos", intervalo.TotalSeconds);

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
            ProgressBarResultado.Visibility = Visibility.Hidden;

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
