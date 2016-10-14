using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Domain.Interfaces.Repository
{
	public interface IFaixaTabelaPrecoRepository : IRepository<FaixaTabelaPreco>
	{
		FaixaTabelaPreco GetByPlanoId(string planoId);
		FaixaTabelaPreco GetByValueRange(decimal valor);
	}
}
