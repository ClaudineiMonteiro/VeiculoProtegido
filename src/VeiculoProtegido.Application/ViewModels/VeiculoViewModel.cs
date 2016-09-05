using System.ComponentModel.DataAnnotations;

namespace VeiculoProtegido.Application.ViewModels
{
	public class VeiculoViewModel
	{
		[Key]
		public string key { get; set; }
		public string name { get; set; }
		public string id { get; set; }
		public string fipe_name { get; set; }
	}
}
