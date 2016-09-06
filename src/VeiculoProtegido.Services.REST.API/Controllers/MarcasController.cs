using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VeiculoProtegido.Application.Interfaces;
using VeiculoProtegido.Application.ViewModels;

namespace VeiculoProtegido.Services.REST.API.Controllers
{
	public class MarcasController : ApiController
	{
		private readonly IMarcaAppService _marcaAppService;
		private HttpClient client;
		public MarcasController(IMarcaAppService marcaAppService)
		{
			_marcaAppService = marcaAppService;
			client = new HttpClient();
			client.BaseAddress = new Uri("https://fipe-parallelum.rhcloud.com/api/v1");
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}

		public IEnumerable<MarcaViewModel> GetType(string type)
		{
			var response = client.GetAsync($"{type}/marcas").Result;
			if (response.IsSuccessStatusCode)
			{
				var marcaUri = response.Headers.Location;
				var marcaViewModel = response.Content.ReadAsAsync<IEnumerable<MarcaViewModel>>().Result;
				return marcaViewModel;
			}
			else
				return null;
		}
	}
}
