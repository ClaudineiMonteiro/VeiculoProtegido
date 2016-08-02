using System;
using DomainValidation.Interfaces.Specification;
using VeiculoProtegido.Domain.Entities;
using VeiculoProtegido.Domain.Interfaces.Repository;

namespace VeiculoProtegido.Domain.Specifications.Empresas
{
	public class EmpresaMustHaveEmailUniqueSpecification : ISpecification<Empresa>
	{
		#region Atributos
		private readonly IEmpresaRepository _empresaRepository;
		#endregion

		#region Construtores
		public EmpresaMustHaveEmailUniqueSpecification(IEmpresaRepository empresaRepository)
		{
			_empresaRepository = empresaRepository;
		}
		#endregion

		#region Métodos
		public bool IsSatisfiedBy(Empresa empresa)
		{
			return _empresaRepository.GetByEmail(empresa.Email) == null;
		}
		#endregion
	}
}
