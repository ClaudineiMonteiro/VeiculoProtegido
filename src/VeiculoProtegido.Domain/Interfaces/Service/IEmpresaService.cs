using System;
using System.Collections.Generic;
using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.Domain.Interfaces.Service
{
	public interface IEmpresaService : IDisposable
	{
		Empresa Add(Empresa empresa);
		Empresa GetById(Guid id);
		Empresa GetByDocument(string document);
		Empresa GetByEmail(string email);
		IEnumerable<Empresa> GetAll();
		Empresa Update(Empresa empresa);
		void Remove(Guid id);
		Endereco AddEndereco(Endereco endereco);
		Endereco UpdateEndereco(Endereco endereco);
		Endereco GetEnderecoById(Guid id);
		void RemovEndereco(Guid id);
	}
}
