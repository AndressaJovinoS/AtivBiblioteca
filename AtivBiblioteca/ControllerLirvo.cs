using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivBiblioteca
{
	public class ControllerLirvo
	{
		public static void CadastrarL(List<Livro> listaL)
		{
			long numero = listaL.Count() + 1; 
			string isbn, genero, autor, titulo;
			DateTime dataPublicacao;
			
			isbn = Isbn(listaL);
			genero = Genero();
			autor = Autor();
			titulo = Titulo();
			dataPublicacao = DataPublicacao();


			Livro livro = new Livro()
			{
				Numero = numero,
				ISBN = isbn,
				Genero = genero,
				Autor = autor,
				Titulo = titulo,
				DataPublicacao = dataPublicacao
			};
			listaL.Add(livro);
			listaL = listaL.OrderBy(x => x.Titulo).ToList();
			EscreverArquivoL(listaL);

		}

		public static string Isbn(List<Livro> lista)
		{
			string isbn;
			do
			{
				Console.Clear();
				Console.WriteLine("Informe os dados do Livro");
				Console.Write("ISBN: ");
				isbn = Console.ReadLine();

				if (VerificaIsbn(lista, isbn))
					Console.WriteLine("Livro já cadastrado");

			} while (VerificaIsbn(lista, isbn));

			return isbn;
		}

		public static bool VerificaIsbn(List<Livro> lista, string isbn)
		{
			foreach (Livro i in lista)
			{
				if (i.ISBN.Equals(isbn))
					return true;
			}
			return false;
		}

		private static string Genero()
		{
			string titulo;

			Console.Write("Título: ");
			titulo = Console.ReadLine();

			return titulo;
		}

		private static string Autor()
		{
			string autor;

			Console.Write("Autor: ");
			autor = Console.ReadLine();

			return autor;
		}

		private static string Titulo()
		{
			string titulo;

			Console.Write("Título: ");
			titulo = Console.ReadLine();

			return titulo;
		}

		private static DateTime DataPublicacao()
		{
			Console.Write("Data de Publicação: ");
			DateTime dataPublicacao = DateTime.Parse(Console.ReadLine());

			return dataPublicacao;
		}

		public static void EscreverArquivoL(List<Livro> listaL)
		{
			using (StreamWriter streamWriter = File.CreateText("C:\\AtivBlilbioteca1\\LIVRO.csv"))
			{
				streamWriter.WriteLine("Numero;ISBN;Genero;Autor;Titulo;DataPublicacao");
				foreach (var horizontal in listaL)
				{
					streamWriter.WriteLine(horizontal.ToString());
				}
				streamWriter.Close();
			}
		}
	}
}
