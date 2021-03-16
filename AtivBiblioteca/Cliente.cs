using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivBiblioteca
{
	public class Cliente
	{
		public long IdCliente { get; set; }
		public string Cpf { get; set; }
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Telefone { get; set; }
		public Endereco Endereco { get; set; }

		public Cliente() { }

		public override string ToString()
		{
			return $"{IdCliente};{Cpf};{Nome};{DataNascimento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)};{Telefone};{Endereco.Logradouro};{Endereco.Bairro};{Endereco.Cidade};{Endereco.Estado};{Endereco.CEP}";
		}
	}
}
