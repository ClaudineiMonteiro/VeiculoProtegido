using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Infra.Data.EntityConfig
{
	public class TabelaPrecoConfig : EntityTypeConfiguration<TabelaPreco>
	{
		public TabelaPrecoConfig()
		{
			HasKey(k => k.TabelaPrecoId);
			Property(p => p.Descricao)
				.IsRequired()
				.HasColumnAnnotation("idx_TabelaPreco_Descricao", new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
			Property(p => p.TipoFipe)
				.IsRequired();
			Property(p => p.DataHoraCadastro)
				.IsRequired();
			//Property(p => p.DataHoraUltimaAlteracao)
			//	.IsOptional();
			Ignore(i => i.ValidationResult);
			ToTable("TabelaPrecos");
		}
	}
}
