using System;
using VeiculoProtegido.Infra.Data.Context;
using VeiculoProtegido.Infra.Data.Interfaces;

namespace VeiculoProtegido.Infra.Data.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		#region Attributes
		private readonly VeiculoProtegidoContext _context;
		private bool _disposed;
		#endregion

		#region Builders
		public UnitOfWork(VeiculoProtegidoContext context)
		{
			_context = context;
		}
		#endregion

		#region Methods
		public void BeginTransaction()
		{
			_disposed = false;
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
