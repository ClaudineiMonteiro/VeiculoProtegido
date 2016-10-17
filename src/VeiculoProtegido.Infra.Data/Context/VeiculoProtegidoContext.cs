using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using VeiculoProtegido.Infra.Data.EntityConfig;

namespace VeiculoProtegido.Infra.Data.Context
{
	public class VeiculoProtegidoContext : DbContext
	{
		public VeiculoProtegidoContext()
			: base("VeiculoProtegidoConnection")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Properties()
				.Where(p => p.Name == string.Format("{0}Id", p.ReflectedType.Name))
				.Configure(p => p.IsKey());

			modelBuilder.Properties<string>()
				.Configure(p => p.HasColumnType("varchar"));

			modelBuilder.Properties<string>()
				.Configure(p => p.HasMaxLength(100));

			modelBuilder.Configurations.Add(new TabelaPrecoConfig());
			modelBuilder.Configurations.Add(new FaixaTabelaPrecoConfig());

			base.OnModelCreating(modelBuilder);
		}

		public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataHoraUltimaAlteracao") != null))
			{
				entry.Property("DataHoraUltimaAlteracao").CurrentValue = DateTime.Now;
			}

			foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataHoraCadastro") != null))
			{
				if (entry.State == EntityState.Added)
				{
					entry.Property("DataHoraCadastro").CurrentValue = DateTime.Now;
				}

				if (entry.State == EntityState.Modified)
				{
					entry.Property("DataHoraCadastro").IsModified = false;
				}
			}
			return base.SaveChanges();
		}
	}
}
