using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace VeiculoProtegido.Infra.Data.Context
{
	public class VeiculoProtegidoContext : DbContext
	{
		public VeiculoProtegidoContext()
			: base("DefaultConnection")
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

			base.OnModelCreating(modelBuilder);
		}

		public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataHoraUltimaAlteracao") != null && entry.Entity.GetType().GetProperty("DataHoraUltimaAlteracaoDataHoraCadastro") != null))
			{
				if (entry.State == EntityState.Added)
				{
					entry.Property("DataHoraUltimaAlteracao").CurrentValue = DateTime.Now;
				}

				if (entry.State == EntityState.Modified)
				{
					entry.Property("DataHoraUltimaAlteracao").IsModified = false;
				}
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
