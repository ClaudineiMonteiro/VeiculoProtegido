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

		public string nome { get; set; }
		public int codigo { get; set; }

		public ICollection<ModeloViewModel> Modelos { get; set; }
	}
}
