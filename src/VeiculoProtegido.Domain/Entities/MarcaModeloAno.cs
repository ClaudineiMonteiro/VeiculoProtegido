using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeiculoProtegido.Domain.Entities
{
	public class MarcaModeloAno
	{
		public AnoCombustivel[] anoCombustivels { get; set; }
	}

	public class AnoCombustivel
	{
		public string nome { get; set; }
		public string codigo { get; set; }
	}

}
