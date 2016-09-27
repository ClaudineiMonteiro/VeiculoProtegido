using System;

namespace VeiculoProtegido.Domain.Entities
{
	public class FaixaTabelaPreco
	{
		public FaixaTabelaPreco()
		{
			FaixatabelaPrecoId = Guid.NewGuid();
		}
		public Guid FaixatabelaPrecoId { get; set; }
		public int MyProperty { get; set; }
		public byte PlanoId { get; set; }
		public decimal ValorDe { get; set; }
		public decimal ValorAte { get; set; }
		public decimal ValorMensal { get; set; }
		public decimal ValorParticipacaoEvento { get; set; }
		public decimal ValorAdesao { get; set; }
		public Guid TabelaPrecoId { get; set; }
		public virtual TabelaPreco TabelaPreco { get; set; }
	}
}
