using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivBiblioteca
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Cliente> listaCliente = new List<Cliente>();
			List<Livro> listaLivro = new List<Livro>();
			List<Emprestimo> listaEmprestimo = new List<Emprestimo>();
			listaCliente = ControllerArquivo.ConvertParaListaCliente();
			listaLivro = ControllerArquivo.ConvertParaListaLivro();
			listaEmprestimo = ControllerArquivo.ConvertParaListaEmprestimo();

			int op;
			do
			{
				Console.Clear();
				Console.WriteLine("    \n      >>> Bliblioteca Sureal <<<\n");
				Console.WriteLine("+-----------------------------------+");
				Console.Write("|           >>> MENU <<<              |\n"
					+ "|1 - Cadastro de Cliente              |\n"
					+ "|2 - Cadastro de Livro                |\n"
					+ "|3 - Emprestimo de Livro              |\n"
					+ "|4 - Develoção de Livro               |\n"
					+ "|5 - Relatório Emprestimo / Devolução |\n"
					+ "|6 - Sair                             |\n");
				Console.WriteLine("+-----------------------------------+");
				Console.Write("\nInforme a opcao desejada: ");

				if (int.TryParse(Console.ReadLine(), out op))

					switch (op)
					{
						case 1:
							ControllerCliente.Cadastrar(listaCliente);
							ControllerCliente.EscreverArquivoC(listaCliente);
							break;
						case 2:
							ControllerLirvo.CadastrarL(listaLivro);
							ControllerLirvo.EscreverArquivoL(listaLivro);
							break;
						case 3:
							ControllerEmprestimo.EmprestimoLivro(listaEmprestimo);
							ControllerEmprestimo.EscreverArquivoE(listaEmprestimo);
							break;
						case 4:
							Devolucao.DevolucaoLivro(listaEmprestimo);
							break;
						case 5:
							//ImprimirRelatorio();
							break;
						case 6:
							break;
						default:
							Console.WriteLine("Opção Invalida! Pressione enter para continuar.");
							Console.ReadKey();
							break;
					}
			} while (op != 6);
		}
	}
}
