﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeiculoProtegido.Domain.Entities
{
	public class PrecoFIPE
	{
		public string id { get; set; }
		public string ano_modelo { get; set; }
		public string marca { get; set; }
		public string name { get; set; }
		public string veiculo { get; set; }
		public string preco { get; set; }
		public string combustivel { get; set; }
		public string referencia { get; set; }
		public string fipe_codigo { get; set; }
		public string key { get; set; }
	}
}
