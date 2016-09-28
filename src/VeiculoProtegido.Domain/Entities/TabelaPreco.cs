using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using VeiculoProtegido.Domain.Validations.TabelaPreco;

namespace VeiculoProtegido.Domain.Entities
{
	public class TabelaPreco
	{
		#region Builders
		public TabelaPreco()
		{
			TabelaPrecoId = Guid.NewGuid();
			FaixasTabelaPreco = new List<FaixaTabelaPreco>();
		}
		#endregion

		#region Attrubutes
		public Guid TabelaPrecoId { get; set; }
		public string Descricao { get; set; }
		public byte TipoFipe { get; set; }
		public virtual ICollection<FaixaTabelaPreco> FaixasTabelaPreco { get; set; }
		public DateTime DataHoraCadastro { get; set; }
		public DateTime DataHoraUltimaAlteracao { get; set; }
		public ValidationResult ValidationResult { get; set; }
		#endregion

		#region Methods
		public bool IsValid()
		{
			ValidationResult = new TabelaPrecoThisConsistentValidation().Validate(this);
			return ValidationResult.IsValid;
		}
		#endregion
	}
}
