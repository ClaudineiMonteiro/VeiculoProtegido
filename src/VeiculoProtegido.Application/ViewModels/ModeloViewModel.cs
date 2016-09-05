using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeiculoProtegido.Application.ViewModels
{
	public class ModeloViewModel
	{
		public ModeloViewModel()
		{
			Veiculos = new List<VeiculoViewModel>();
		}
		public string fipe_codigo { get; set; }
		public string name { get; set; }
		public string key { get; set; }
		public string veiculo { get; set; }
		public string id { get; set; }

		public ICollection<VeiculoViewModel> Veiculos { get; set; }
	}
}
