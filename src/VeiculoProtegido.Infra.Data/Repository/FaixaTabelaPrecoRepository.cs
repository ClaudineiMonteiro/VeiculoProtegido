using System;
using System.Linq;
using VeiculoProtegido.Domain.Entities;
using VeiculoProtegido.Domain.Interfaces.Repository;
using VeiculoProtegido.Infra.Data.Context;

namespace VeiculoProtegido.Infra.Data.Repository
{
	public class FaixaTabelaPrecoRepository : Repository<FaixaTabelaPreco>, IFaixaTabelaPrecoRepository
	{
		#region Builders
		public FaixaTabelaPrecoRepository(VeiculoProtegidoContext context) : base(context) {}
		#endregion

		public FaixaTabelaPreco GetByPlanoId(string planoId)
		{
			return Search(s => s.PlanoId.Equals(planoId)).FirstOrDefault();
		}

		public FaixaTabelaPreco GetByValueRange(decimal valor)
		{
			return Search(s => s.ValorDe >= valor && s.ValorAte <= valor).FirstOrDefault();
		}
	}
}
