using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoAsync.Windows.WPF
{
    public class CalculoDeNumerais
    {

        /// <summary>
        /// CALCULO DE FATORIAL SINCRONO
        /// </summary>
        /// <param name="valorUsuario">VALOR QUE USUARIO DIGITOU</param>
        /// <returns>LISTA DE NUMEROS FATORIAIS</returns>
        internal static string RetornaNumerosContador(int valorUsuario)
        {
            var retorno = new BigInteger(1);
            for (int i = 1; i < valorUsuario; i++)
            {
                retorno *= i;
            }

            return Convert.ToString(retorno);
        }




        /// <summary>
        /// CALCULO DE FATORIAL ASSINCRONO
        /// </summary>
        /// <param name="valorCliente">VALOR QUE USUARIO DIGITOU</param>
        /// <returns>LISTA DE NUMEROS FATORIAIS</returns>
        internal static async Task<String> RetornaNumerosContadorAsync(int valorCliente)
        {
            return await Task.Run(() =>
            {
                var retorno = new BigInteger(1);
                for (int i = 1; i < valorCliente; i++)
                {
                    retorno *= i;
                }

                return Convert.ToString(retorno);
            });
        }


        /// <summary>
        /// CALCULO DE FATORIAL ASSINCRONO COM A OPÇÃO DE CANCELAMENTO
        /// </summary>
        /// <param name="valorCliente">VALOR QUE USUARIO DIGITOU</param>
        /// <param name="cancellationToken">VERIFICA SE O CLIENTE CLICOU NO BOTÃO DE CANCELAR</param>
        /// <returns>LISTA DE NUMEROS FATORIAIS</returns>
        internal static async Task<String> RetornaNumerosContadorAsyncCancel(int valorCliente, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var retorno = new BigInteger(1);
                for (int i = 1; i < valorCliente; i++)
                {
                    //AQUI JA SUPORTA CANCELAMENTO
                    //VERIFICAMOS O SUPORTE AO EXCEPTION PARA O CANCELLATIONTOKEN
                    cancellationToken.ThrowIfCancellationRequested();

                    retorno *= i;
                }

                return Convert.ToString(retorno);
            });
        }





        /// <summary>
        /// CALCULO DE FATORIAL ASSINCRONO COM SUPORTE A CANCELAMENTO E BARRA DE PROGRESSO
        /// </summary>
        /// <param name="valorCliente">VALOR QUE USUARIO DIGITOU</param>
        /// <param name="cancellationToken">VERIFICA SE O CLIENTE CLICOU NO BOTÃO DE CANCELAR</param>
        /// <param name="progresso">USAMOS A INTERFACE DE PROGRESS PARA ENVIAR O REPORT DE ATUALIZAÇÃO</param>
        /// <returns>LISTA DE NUMEROS FATORIAIS</returns>
        internal static async Task<string> RetornaNumerosContadorAsyncCancelProgress(int valorCliente, CancellationToken cancellationToken, IProgress<int> progresso)
        {
            return await Task.Run(() =>
            {
                var retorno = new BigInteger(1);
                for (int i = 1; i < valorCliente; i++)
                {
                    //CASO O CLIENTE SOLICITE O CANCELAMENTO EU 
                    //APRESENTO UMA EXCEPTION
                    cancellationToken.ThrowIfCancellationRequested();

                    retorno *= i;

                    //TAMBEM DEVO NOTIFICAR O CLIENTE CASO TENHA ALGUM PROGRESSO
                    //A CADA 10 NOTIFICO A APLICAÇÃO QUE EXISTE UMA ATUALIZAÇÃO
                    if(i % 10 == 0)
                    {
                        progresso.Report(i);
                    }
                }

                return Convert.ToString(retorno);
            });
        }
    }
}
