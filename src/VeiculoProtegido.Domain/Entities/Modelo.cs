using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeiculoProtegido.Domain.Entities
{


	public class ModeloAno
	{
		public Modelo[] modelos { get; set; }
		public Ano[] anos { get; set; }
	}

	public class Modelo
	{
		public string nome { get; set; }
		public int codigo { get; set; }
	}

	public class Ano
	{
		public string nome { get; set; }
		public string codigo { get; set; }
	}


}
