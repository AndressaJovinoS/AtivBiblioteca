using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivBiblioteca
{
	public class ControllerEmprestimo
	{
		public static void EmprestimoLivro(List<Emprestimo> listaE)
		{
			long idCliente, numeroTombo;
			DateTime dataEmprestimo;
			DateTime dataDevolucao;
			int statusDevolucao;
		
			idCliente = LeIdCliente();
			numeroTombo = LeNumeroTombo(listaE);
			dataEmprestimo = LeDataEmprestimo();
			dataDevolucao = LeDataDevolucao();
			statusDevolucao = LeStatusDevolucao();

			Emprestimo livrosEmp = new Emprestimo()
			{
				IdCliente = idCliente,
				NumeroTombo = numeroTombo,
				DataEmprestimo = dataEmprestimo,
				DataDevolucao = dataDevolucao,
				StatusDevolucao = statusDevolucao

			};
			listaE.Add(livrosEmp);
			EscreverArquivoE(listaE);
		}

		private static long LeIdCliente()
		{
			long idCliente;

			Console.WriteLine("Informe os dados para o Emprestimo do Livro! ");
			Console.Write("Id Cliente: ");
			idCliente = long.Parse(Console.ReadLine());

			return idCliente;
		}

		public static long LeNumeroTombo(List<Emprestimo> listaEmp)
		{
			long numeroTombo;
			do
			{
				Console.Write("Numero Tombo: ");
				numeroTombo = long.Parse(Console.ReadLine());

				if (VerificaNumeroTomboBool(listaEmp, numeroTombo))
					Console.WriteLine("Exemplar indisponivel! ");

			} while (VerificaNumeroTomboBool(listaEmp, numeroTombo));

			return numeroTombo;
		}

		public static Emprestimo VerificaNumeroTombo(List<Emprestimo> lista, long numeroTombo) //devolve exemplar
		{
			foreach (Emprestimo i in lista)
			{
				if (i.NumeroTombo.Equals(numeroTombo) && (i.StatusDevolucao.Equals(1)))
					return i;
			}
			return null;
		}
		public static bool VerificaNumeroTomboBool(List<Emprestimo> lista, long numeroTombo) //verifica se o exemplar está disponivel
		{
			foreach (Emprestimo i in lista)
			{
				if (i.NumeroTombo.Equals(numeroTombo) && (i.StatusDevolucao.Equals(1)))
					return true;
			}
			return false;
		}

		private static DateTime LeDataEmprestimo()
		{
			DateTime dataEmprestimo;
			dataEmprestimo = DateTime.Now;

			return dataEmprestimo;
		}

		private static DateTime LeDataDevolucao()
		{
			Console.Write("Data para devolucao: ");
			DateTime dataDevolucao = DateTime.Parse(Console.ReadLine());

			return dataDevolucao;
		}

		private static int LeStatusDevolucao()
		{
			int statusDevolucao;

			Console.Write("Status Devolucao (1) Emprestado / (2) Devolvido: ");
			statusDevolucao = int.Parse(Console.ReadLine());

			return statusDevolucao;
		}

		public static void EscreverArquivoE(List<Emprestimo> emprestimos)
		{
			using (StreamWriter streamWriter = File.CreateText("C:\\AtivBlilbioteca1\\EMPRESTIMO.csv"))
			{
				streamWriter.WriteLine("IdCliente;NumeroTombo;DataEmprestimo;DataDevolucao;StatusDevolucao");
				foreach (var horizontal in emprestimos)
				{
					streamWriter.WriteLine(horizontal.ToString());
				}
				streamWriter.Close();
			}
		}
	}
}
