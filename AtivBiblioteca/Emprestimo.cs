using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivBiblioteca
{
	public class Emprestimo
	{
		public long IdCliente { get; set; }
		public long NumeroTombo { get; set; }
		public DateTime DataEmprestimo { get; set; }
		public DateTime DataDevolucao { get; set; }
		public int StatusDevolucao { get; set; } 

		public Emprestimo() { }
	}
}
