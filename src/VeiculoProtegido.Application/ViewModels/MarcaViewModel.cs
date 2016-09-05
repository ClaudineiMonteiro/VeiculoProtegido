using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeiculoProtegido.Application.ViewModels
{
	public class MarcaViewModel
	{
		public MarcaViewModel()
		{
			Modelos = new List<ModeloViewModel>();
		}

		[Key]
		public string key { get; set; }
		public int id { get; set; }
		public string fipe_name { get; set; }
		public string name { get; set; }

		public ICollection<ModeloViewModel> Modelos { get; set; }
	}
}
