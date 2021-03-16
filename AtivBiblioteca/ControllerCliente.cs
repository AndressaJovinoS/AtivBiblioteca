using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtivBiblioteca
{
	public class ControllerCliente
	{
		public static void Cadastrar(List<Cliente> lista)
		{
			long idCliente = lista.Count() + 1;
			string cpf, nome, telefone;
			DateTime dataNascimento;
			Endereco endereco = new Endereco();

			cpf = Cpf(lista);
			nome = Nome();
			dataNascimento = DataNascimento();
			telefone = Telefone();
			endereco = Endereco();


			Cliente novoCliente = new Cliente()
			{
				IdCliente = idCliente,
				Cpf = cpf,
				Nome = nome,
				DataNascimento = dataNascimento,
				Telefone = telefone,
				Endereco = endereco,
			};
			lista.Add(novoCliente);
			EscreverArquivoC(lista);
		}

		public static string Cpf(List<Cliente> lista)
		{
			string cpf;
			do
			{
				Console.Clear();
				Console.WriteLine("informe os dados do Cliente! ");
				Console.Write("CPF: ");
				cpf = Console.ReadLine();

				if (VerificaCpf(lista, cpf))
					Console.WriteLine("CPF já cadastrado");

			} while (VerificaCpf(lista, cpf)); // verifica cpf cadastrado

			return cpf;
		}

		public static bool VerificaCpf(List<Cliente> lista, string cpf)
		{
			foreach (Cliente i in lista)
			{
				if (i.Cpf.Equals(cpf))
					return true;
			}
			return false;
		}

		private static string Nome()
		{
			string nome;

			Console.Write("Nome: ");
			nome = Console.ReadLine();

			return nome;
		}

		private static DateTime DataNascimento()
		{
			Console.Write("Data de Nascimento: ");
			DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

			return dataNascimento;
		}

		private static string Telefone()
		{
			string telefone;

			Console.Write("Telefone: ");
			telefone = Console.ReadLine();

			return telefone;
		}

		private static Endereco Endereco()
		{
			string logradouro, bairro, cidade, estado;
			int cep;
			Endereco endereco = new Endereco();

			Console.Write("Logradouro: ");
			logradouro = Console.ReadLine();
			Console.Write("Bairro: ");
			bairro = Console.ReadLine();
			Console.Write("Cidade: ");
			cidade = Console.ReadLine();
			Console.Write("Estado: ");
			estado = Console.ReadLine();
			Console.Write("CEP: ");
			cep = int.Parse(Console.ReadLine());

			return endereco;
		}

		public static void EscreverArquivoC(List<Cliente> clientes)
		{
			using (StreamWriter streamWriter = File.CreateText("C:\\AtivBlilbioteca1\\CLIENTE.csv"))
			{
				streamWriter.WriteLine("IdCliente;Cpf;Nome;DataNascimento;Telefone;Logradouro;Bairro;Cidade;Estado;Cep");
				foreach (var horizontal in clientes)
				{
					streamWriter.WriteLine(horizontal.ToString());
				}
				streamWriter.Close();
			}
		}
	}
}