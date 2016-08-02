using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace VeiculoProtegido.Domain.Entities
{
	public class Empresa
	{
		#region Construtores
		public Empresa()
		{
			EmpresaId = new Guid();
			Enderecos = new List<Endereco>();
		}
		#endregion

		#region Propriedades
		public Guid EmpresaId { get; set; }
		public string RazãoSocial { get; set; }
		public string NomeFantasia { get; set; }
		public sbyte TipoDocumento { get; set; }
		public string Documento { get; set; }
		public DateTime DataFundacao { get; set; }
		public DateTime DataCadastro { get; set; }
		public bool Ativo { get; set; }
		public virtual ICollection<Endereco> Enderecos { get; set; }
		public ValidationResult ValidationResult { get; set; }
		#endregion

		#region Métodos
		public bool IsValid()
		{
			return true;
		}
		#endregion

	}
}
