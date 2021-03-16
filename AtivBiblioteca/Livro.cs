using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivBiblioteca
{
	public class Livro
	{
		public long Numero { get; set; } //Sistemico
		public string ISBN { get; set; }
		public string Genero { get; set; }
		public DateTime DataPublicacao { get; set; }
		public string Autor { get; set; }
		public string Titulo { get; set; }

		public Livro() { }
	}
}
