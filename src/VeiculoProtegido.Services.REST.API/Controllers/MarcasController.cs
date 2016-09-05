using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VeiculoProtegido.Application.Interfaces;

namespace VeiculoProtegido.Services.REST.API.Controllers
{
    public class MarcasController : ApiController
    {
		private readonly IMarcaAppService _marcaAppService;
		public MarcasController(IMarcaAppService marcaAppService)
		{
			_marcaAppService = marcaAppService;
		}

		public void Post([FromBody]string value)
		{

		}
    }
}
