using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Domain.Interfaces.Repository
{
	public interface IEmpresaRepository : IRepository<Empresa>
	{
		Empresa GetByDocument(string document);
		Empresa GetByEmail(string email);
	}
}
