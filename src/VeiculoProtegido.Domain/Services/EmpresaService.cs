using System;
using System.Collections.Generic;
using VeiculoProtegido.Domain.Entities;
using VeiculoProtegido.Domain.Interfaces.Repository;
using VeiculoProtegido.Domain.Interfaces.Service;
using VeiculoProtegido.Domain.Validations.Empresas;

namespace VeiculoProtegido.Domain.Services
{
	public class EmpresaService : IEmpresaService
	{
		#region Atributos
		private readonly IEmpresaRepository _empresaRepository;
		private readonly IEnderecoRepository _enderecoRepository;
		#endregion

		#region Construtores
		public EmpresaService(IEmpresaRepository empresaRepository, IEnderecoRepository enderecoRepository)
		{
			_empresaRepository = empresaRepository;
			_enderecoRepository = enderecoRepository;
		}
		#endregion


		public Empresa Add(Empresa empresa)
		{
			if (!empresa.IsValid())
			{
				return empresa;
			}
			empresa.ValidationResult = new EmpresaAbleToRegisterValidation(_empresaRepository).Validate(empresa);
			if (!empresa.ValidationResult.IsValid)
			{
				return empresa;
			}
			empresa.ValidationResult.Message = "Empresa cadastrada com sucesso!!!";
			return _empresaRepository.Add(empresa);
		}


		public void Dispose()
		{
			_empresaRepository.Dispose();
			GC.SuppressFinalize(this);
		}

		public IEnumerable<Empresa> GetAll()
		{
			return _empresaRepository.GetAll();
		}

		public Empresa GetByDocument(string document)
		{
			return _empresaRepository.GetByDocument(document);
		}

		public Empresa GetByEmail(string email)
		{
			return _empresaRepository.GetByEmail(email);
		}

		public Empresa GetById(Guid id)
		{
			return _empresaRepository.GetById(id);
		}

		public Empresa Update(Empresa empresa)
		{
			return _empresaRepository.Update(empresa);
		}

		public Endereco GetEnderecoById(Guid id)
		{
			return _enderecoRepository.GetById(id);
		}

		public void Remove(Guid id)
		{
			_empresaRepository.Remove(id);
		}

		public Endereco AddEndereco(Endereco endereco)
		{
			return _enderecoRepository.Add(endereco);
		}

		public void RemovEndereco(Guid id)
		{
			_enderecoRepository.Remove(id);
		}

		public Endereco UpdateEndereco(Endereco endereco)
		{
			return _enderecoRepository.Update(endereco);
		}
	}
}
