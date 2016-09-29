using VeiculoProtegido.Infra.Data.Interfaces;

namespace VeiculoProtegido.Application
{
	public class ApplicationService
	{
		#region Attribuilts
		private readonly IUnitOfWork _uow;
		#endregion

		#region Builders
		public ApplicationService(IUnitOfWork uow)
		{
			_uow = uow;
		}
		#endregion

		#region Methods
		public void BeginTransaction()
		{
			_uow.BeginTransaction();
		}

		public void Commit()
		{
			_uow.Commit();
		}
		#endregion
	}
}
