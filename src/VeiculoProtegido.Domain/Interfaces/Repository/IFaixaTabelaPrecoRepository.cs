using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Domain.Interfaces.Repository
{
	public interface IFaixaTabelaPrecoRepository : IRepository<FaixaTabelaPreco>
	{
		FaixaTabelaPreco GetByPlano(byte planoId);
		FaixaTabelaPreco GetByValueRange(decimal valor);
	}
}
