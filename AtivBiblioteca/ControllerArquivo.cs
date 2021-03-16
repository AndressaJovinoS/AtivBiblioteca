using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivBiblioteca
{
    public class ControllerArquivo
    {
        public static List<Cliente> ConvertParaListaCliente()
        {
            List<Cliente> listaCliente = new List<Cliente>();
            string diretorio = @"C:\AtivBlilbioteca1\CLIENTE.csv";

            if (File.Exists("diretorio"))
            {
                string horizontal = "";
                string[] novalinha;
                StreamReader reader = null;

                reader = new StreamReader("CLIENTE.csv", Encoding.UTF8, true);

                while (true)
                {
                    horizontal = reader.ReadLine();
                    if (horizontal == null) 
                        break;
                    novalinha = horizontal.Split(';');
                    listaCliente.Add(new Cliente
                    {
                        IdCliente = int.Parse(novalinha[0]),
                        Cpf = novalinha[1],
                        Nome = novalinha[2],
                        DataNascimento = Convert.ToDateTime(novalinha[3]),
                        Telefone = novalinha[4],
                        Endereco = new Endereco
                        {
                            Logradouro = novalinha[5],
                            Bairro = novalinha[6],
                            Cidade = novalinha[7],
                            Estado = novalinha[8],
                            CEP = novalinha[9]
                        }
                    });
                }
                reader.Close();
            }
            else
                Console.WriteLine("Arquivo não encontrado! ");

            return listaCliente;
        }

        public static List<Livro> ConvertParaListaLivro()
        {
            string diretorio = @"C:\AtivBlilbioteca1\LIVRO.csv";
            List<Livro> listaLivro = new List<Livro>();
            if (File.Exists("diretorio"))
            {
                string horizontal = "";
                string[] novalinha;
                StreamReader reader = null;

                reader = new StreamReader("LIVRO.csv", Encoding.UTF8, true);

                while (true)
                {
                    horizontal = reader.ReadLine();
                    if (horizontal == null) 
                        break;
                    novalinha = horizontal.Split(';');
                    listaLivro.Add(new Livro
                    {
                        Numero = long.Parse(novalinha[0]),
                        ISBN = novalinha[1],
                        Titulo = novalinha[2],
                        Genero = novalinha[3],
                        DataPublicacao = Convert.ToDateTime(novalinha[4]),
                        Autor = novalinha[5],
                    });
                }
                reader.Close();
            }
            else
                Console.WriteLine("Arquivo não encontrado! ");

            return listaLivro;
        }

        public static List<Emprestimo> ConvertParaListaEmprestimo()
        {
            string diretorio = @"C:\AtivBlilbioteca1\EMPRESTIMO.csv";
            List<Emprestimo> listaEmprestimo = new List<Emprestimo>();
            if (File.Exists("diretorio"))
            {
                string horizontal = "";
                string[] novalinha;
                StreamReader reader = null;

                reader = new StreamReader("EMPRESTIMO.csv", Encoding.UTF8, true);

                while (true)
                {
                    horizontal = reader.ReadLine();
                    if (horizontal == null) 
                        break;
                    novalinha = horizontal.Split(';');
                    listaEmprestimo.Add(new Emprestimo
                    {
                        IdCliente = int.Parse(novalinha[0]),
                        NumeroTombo = long.Parse(novalinha[1]),
                        DataEmprestimo = Convert.ToDateTime(novalinha[2]),
                        DataDevolucao = Convert.ToDateTime(novalinha[3]),
                        StatusDevolucao = int.Parse(novalinha[4]),
                        
                    });
                }
                reader.Close();
            }
            else
                Console.WriteLine("Arquivo não encontrado! ");

            return listaEmprestimo;
        }
    }
}
