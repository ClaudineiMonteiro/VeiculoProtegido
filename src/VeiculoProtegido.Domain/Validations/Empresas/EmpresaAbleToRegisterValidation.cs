using DomainValidation.Validation;
using VeiculoProtegido.Domain.Entities;
using VeiculoProtegido.Domain.Interfaces.Repository;
using VeiculoProtegido.Domain.Specifications.Empresas;

namespace VeiculoProtegido.Domain.Validations.Empresas
{
	public class EmpresaAbleToRegisterValidation : Validator<Empresa>
	{
		public EmpresaAbleToRegisterValidation(IEmpresaRepository empresaRepository)
		{
			var emailDuplicate = new EmpresaMustHaveEmailUniqueSpecification(empresaRepository);
			base.Add("EmailDuplicate", new Rule<Empresa>(emailDuplicate, "E-mail já cadastrado!"));
		}
	}
}
