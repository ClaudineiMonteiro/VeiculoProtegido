using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using VeiculoProtegido.Domain.Entities;
using VeiculoProtegido.Domain.Interfaces.Repository;
using VeiculoProtegido.Infra.Data.Context;

namespace VeiculoProtegido.Infra.Data.Repository
{
	public class TabelaPrecoRepository : Repository<TabelaPreco>, ITabelaPrecoRepository
	{
		#region Builders
		public TabelaPrecoRepository(VeiculoProtegidoContext context) : base(context) {}
		#endregion

		#region Methods
		public TabelaPreco GetByDescricao(string descricao)
		{
			return Search(s => s.Descricao.Contains(descricao)).FirstOrDefault();
		}

		public TabelaPreco GetByTipoFIPE(byte tipoFIPE)
		{
			return Search(s => s.TipoFipe.Equals(tipoFIPE)).FirstOrDefault();
		}

		public override IEnumerable<TabelaPreco> GetAll()
		{
			var cn = Db.Database.Connection;
			var sql = @"
SELECT *
  FROM TabelaPreco
";
			return cn.Query<TabelaPreco>(sql);
		}

		public override TabelaPreco GetById(Guid id)
		{
			var cn = Db.Database.Connection;
			var sql = @"
SELECT *
  FROM TabelaPreco A
       LEFT JOIN FaixaTabelaPreco B
         ON B.TabelaPrecoId = A.TabelaPrecoId
 WHERE A.TabelaPrecoId = @sId";
			var tabelaPreco = new List<TabelaPreco>();
			cn.Query<TabelaPreco, FaixaTabelaPreco, TabelaPreco>(
				sql,
				(t, f) =>
				{
					tabelaPreco.Add(t);
					if (f != null)
						tabelaPreco[0].FaixasTabelaPreco.Add(f);
					return tabelaPreco.FirstOrDefault();
				},
				new {sid = id}, splitOn:"TabelaPrecoId, FaixaTabelaPrecoId"
				);
			return tabelaPreco.FirstOrDefault();
		}
		#endregion
	}
}
