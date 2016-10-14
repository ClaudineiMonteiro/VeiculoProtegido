using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Domain.Interfaces.Repository
{
	public interface ITabelaPrecoRepository : IRepository<TabelaPreco>
	{
		TabelaPreco GetByDescricao(string descricao);
		TabelaPreco GetByTipoFIPE(string tipoFIPE);
	}
}
