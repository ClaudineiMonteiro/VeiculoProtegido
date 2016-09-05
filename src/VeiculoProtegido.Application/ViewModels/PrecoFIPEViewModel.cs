using System.ComponentModel.DataAnnotations;

namespace VeiculoProtegido.Application.ViewModels
{
	public class PrecoFIPEViewModel
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
		[Key]
		public string key { get; set; }
	}
}
