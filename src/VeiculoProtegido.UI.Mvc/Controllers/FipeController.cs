﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using VeiculoProtegido.Application.Interfaces;
using VeiculoProtegido.Application.ViewModels;

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
	}
}