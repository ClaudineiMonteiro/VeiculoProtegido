using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeiculoProtegido.Domain.Entities
{
	public class Endereco
	{
		public Endereco()
		{
			EnderecoId = new Guid();
		}
		public Guid EnderecoId { get; set; }
		public string Logradouro { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public string Bairro { get; set; }
		public string Localidade { get; set; }
		public string CEP { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string Unidade { get; set; }
		public string Ibge { get; set; }
		public string Gia { get; set; }

		#region Relacionamentos
		public Guid EmpresaId { get; set; }
		public virtual Empresa Empresa { get; set; }
		#endregion
	}
}
