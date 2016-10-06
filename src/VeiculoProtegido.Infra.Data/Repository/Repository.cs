using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using VeiculoProtegido.Domain.Interfaces.Repository;
using VeiculoProtegido.Infra.Data.Context;

namespace VeiculoProtegido.Infra.Data.Repository
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		#region Attributes
		protected VeiculoProtegidoContext Db;
		protected DbSet<TEntity> DbSet;
		#endregion

		#region Builders
		public Repository(VeiculoProtegidoContext context)
		{
			Db = context;
			DbSet = Db.Set<TEntity>();
		}
		#endregion

		#region Methods
		public virtual TEntity Add(TEntity obj)
		{
			var objReturn = DbSet.Add(obj);
			return objReturn;
		}

		public virtual void Dispose()
		{
			Db.Dispose();
			GC.SuppressFinalize(this);
		}

		public virtual IEnumerable<TEntity> GetAll()
		{
			return DbSet.ToList();
		}

		public virtual TEntity GetById(Guid id)
		{
			return DbSet.Find(id);
		}

		public virtual void Remove(Guid id)
		{
			DbSet.Remove(DbSet.Find(id));
		}

		public int SaveChanges()
		{
			return Db.SaveChanges();
		}

		public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
		{
			return DbSet.Where(predicate);
		}

		public TEntity Update(TEntity obj)
		{
			var entry = Db.Entry(obj);
			DbSet.Attach(obj);
			entry.State = EntityState.Modified;
			return obj;
		}
		#endregion
	}
}
