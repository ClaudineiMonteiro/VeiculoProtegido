using System.Data.Entity.ModelConfiguration;
using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Infra.Data.EntityConfig
{
	public class FaixaTabelaPrecoConfig : EntityTypeConfiguration<FaixaTabelaPreco>
	{
		public FaixaTabelaPrecoConfig()
		{
			HasKey(k => k.FaixatabelaPrecoId);
			Property(p => p.PlanoId)
				.IsRequired();
			Property(p => p.ValorDe)
				.IsRequired();
			Property(p => p.ValorAte)
				.IsRequired();
			Property(p => p.ValorMensal)
				.IsRequired();
			Property(p => p.ValorParticipacaoEvento)
				.IsRequired();
			Property(p => p.ValorAdesao)
				.IsRequired();
			ToTable("FaixaTabelaPreco");
		}
	}
}
