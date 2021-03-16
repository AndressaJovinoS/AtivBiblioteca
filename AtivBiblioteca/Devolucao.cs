using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivBiblioteca
{
	class Devolucao
	{
		public static void DevolucaoLivro(List<Emprestimo> listaE)
		{
			long numeroTombo;

			Emprestimo emprestimo = null;
			double valorMulta = 0;

			Console.WriteLine("Informe os dados para Devolução! ");
			Console.Write("Numero do Tombo: ");
			numeroTombo = long.Parse(Console.ReadLine());
			emprestimo = ControllerEmprestimo.VerificaNumeroTombo(listaE, numeroTombo);
			if (emprestimo != null)
			{
				emprestimo.StatusDevolucao = 2;
				//EscreverArquivoE(listaE);

				DateTime dataAtual = DateTime.Now;
				
				if (dataAtual > emprestimo.DataDevolucao)
				{
					valorMulta = Multa(emprestimo.DataDevolucao, dataAtual);
					Console.WriteLine("O valor da multa: " + valorMulta);
				}	
			}
		}

		public static double Multa(DateTime dataDevolucao, DateTime dataAtual)
		{
			const double multaDiaria = 0.10;
			int dias;
			double valorFinal = 0;
			TimeSpan data = dataDevolucao - dataAtual;
			dias = data.Days;

			if (dias < 0)
			{
				Console.WriteLine("Devolução efetuada! ");
				dias = dias * -1;
				valorFinal = dias * multaDiaria;
			}
			return valorFinal;
		}
	}
}
