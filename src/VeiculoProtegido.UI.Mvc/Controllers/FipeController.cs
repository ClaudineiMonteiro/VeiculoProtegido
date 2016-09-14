using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using VeiculoProtegido.Application.Interfaces;
using VeiculoProtegido.Application.ViewModels;
using VeiculoProtegido.Domain.Entities;

namespace VeiculoProtegido.UI.Mvc.Controllers
{

	public class FipeController : Controller
	{
		private readonly IMarcaAppService _marcaAppService;
		private HttpClient client;
		public FipeController()
		{
			//_marcaAppService = marcaAppService;
			client = new HttpClient();
			client.BaseAddress = new Uri("https://fipe-parallelum.rhcloud.com");
			client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}
		// GET: Fipe
		public ActionResult Carro()
		{
			var type = "/api/v1/carros/marcas";
			var response = client.GetAsync(type).Result;
			if (response.IsSuccessStatusCode)
			{
				var marcaUri = response.Headers.Location;
				var marcaViewModel = response.Content.ReadAsAsync<IEnumerable<MarcaViewModel>>().Result;
				return View(marcaViewModel);
			}
			else
				return null;
		}

		public JsonResult RetornarModelos(string marcaId)
		{
			var modelo = string.Format("/api/v1/carros/marcas/{0}/modelos",
				marcaId);
			var response = client.GetAsync(modelo).Result;
			if (response.IsSuccessStatusCode)
			{
				var marcaUri = response.Headers.Location;
				var modelos = response.Content.ReadAsAsync<ModeloAno>().Result;
				return Json(modelos, JsonRequestBehavior.AllowGet);
			}
			else
				return null;

		}

		public JsonResult RetornarAnoPorModelo(string marcaId, string modeloId)
		{
			var marcaModelo = string.Format("/api/v1/carros/marcas/{0}/modelos/{1}/anos",
				marcaId,
				modeloId);
			var response = client.GetAsync(marcaModelo).Result;
			if (response.IsSuccessStatusCode)
			{
				var marcaUri = response.Headers.Location;
				var marcasModelos = response.Content.ReadAsAsync<ModeloAno>().Result;
				return Json(marcasModelos, JsonRequestBehavior.AllowGet);
			}
			else
				return null;
		}
	}
}