using Microsoft.Ajax.Utilities;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using VeiculoProtegido.Application.Interfaces;
using VeiculoProtegido.Application.ViewModels;
using VeiculoProtegido.Infra.CrossCutting.Global;
using System.Collections.Generic;

namespace VeiculoProtegido.UI.Mvc.Controllers
{


	public class TabelasPrecoController : Controller
	{
		private readonly ITabelaPrecoAppService _tabelaPrecoAppService;

		public TabelasPrecoController(ITabelaPrecoAppService tabelaPrecoAppService)
		{
			_tabelaPrecoAppService = tabelaPrecoAppService;
		}

		// GET: TabelasPreco
		public ActionResult Index()
		{
			return View(_tabelaPrecoAppService.GetAll());
		}

		// GET: TabelasPreco/Details/5
		public ActionResult Details(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			TabelaPrecoViewModel tabelaPrecoViewModel = _tabelaPrecoAppService.GetById(id.Value);
			if (tabelaPrecoViewModel == null)
			{
				return HttpNotFound();
			}
			return View(tabelaPrecoViewModel);
		}

		// GET: TabelasPreco/Create
		public ActionResult Create()
		{
			List<TipoFIPE> tipoFIPEList = new List<TipoFIPE>();
			foreach (var item in ManipulateEnumerable.EnumToList<TipoFipe>().OrderBy(c => (sbyte)c))
			{
				var tipoFIPE = new TipoFIPE();
				tipoFIPE.Id = (int)item;
				tipoFIPE.Descricao = ManipulateEnumerable.BuscarDescricaoEnumerador((TipoFipe)item);
				tipoFIPEList.Add(tipoFIPE);
			}

			ViewBag.TipoFIPEList = tipoFIPEList;
			return View();
		}

		// POST: TabelasPreco/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(TabelaPrecoFaixaTabelaPrecoViewModel tabelaPrecoFaixaTabelaPrecoViewModel)
		{
		if (ModelState.IsValid)
		{
				tabelaPrecoFaixaTabelaPrecoViewModel = _tabelaPrecoAppService.Add(tabelaPrecoFaixaTabelaPrecoViewModel);
				if (!tabelaPrecoFaixaTabelaPrecoViewModel.ValidationResult.IsValid)
				{
					foreach (var erro in tabelaPrecoFaixaTabelaPrecoViewModel.ValidationResult.Erros)
					{
						ModelState.AddModelError(string.Empty, erro.Message);
					}
					return View(tabelaPrecoFaixaTabelaPrecoViewModel);
				}

				if (!tabelaPrecoFaixaTabelaPrecoViewModel.ValidationResult.Message.IsNullOrWhiteSpace())
				{
					ViewBag.Sucesso = tabelaPrecoFaixaTabelaPrecoViewModel.ValidationResult.Message;
					return View(tabelaPrecoFaixaTabelaPrecoViewModel);
				}
				return RedirectToAction("Index");
			}
			return View(tabelaPrecoFaixaTabelaPrecoViewModel);
		}

		// GET: TabelasPreco/Edit/5
		public ActionResult Edit(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			TabelaPrecoViewModel tabelaPrecoViewModel = _tabelaPrecoAppService.GetById(id.Value);
			if (tabelaPrecoViewModel == null)
			{
				return HttpNotFound();
			}
			ViewBag.TabelaPrecoId = id;
			return View(tabelaPrecoViewModel);
		}

		// POST: TabelasPreco/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Route("editar/{id:guid}")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(TabelaPrecoViewModel tabelaPrecoViewModel)
		{
			if (ModelState.IsValid)
			{
				_tabelaPrecoAppService.Update(tabelaPrecoViewModel);
				return RedirectToAction("Index");
			}
			return View(tabelaPrecoViewModel);
		}

		// GET: TabelasPreco/Delete/5
		public ActionResult Delete(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			TabelaPrecoViewModel tabelaPrecoViewModel = _tabelaPrecoAppService.GetById(id.Value);
			if (tabelaPrecoViewModel == null)
			{
				return HttpNotFound();
			}
			return View(tabelaPrecoViewModel);
		}

		// POST: TabelasPreco/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(Guid id)
		{
			_tabelaPrecoAppService.Remove(id);
			return RedirectToAction("Index");
		}

		public ActionResult ListFaixaTabelaPreco(Guid id)
		{
			ViewBag.TabelaPrecoId = id;
			return PartialView("_FaixaTabelaPrecoList", _tabelaPrecoAppService.GetById(id).FaixasTabelaPreco);
		}

		public ActionResult AddFaixaTabelaPreco(Guid id)
		{
			ViewBag.TabelaPrecoId = id;
			return PartialView("_FaixatabelaPrecoAdd");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult AddFaixaTabelaPreco(FaixaTabelaPrecoViewModel faixaTabelaPrecoViewModel)
		{
			if (ModelState.IsValid)
			{
				_tabelaPrecoAppService.AddFaixaTabelaPreco(faixaTabelaPrecoViewModel);
				string url = Url.Action("ListFaixaTabelaPreco", "TabelaPreco", new { id = faixaTabelaPrecoViewModel.TabelaPrecoId });
				return Json(new { success = true, url = url });
			}
			return PartialView("_FaixatabelaPrecoAdd");
		}

		public ActionResult UpdateFaixaTabelaPreco(Guid id)
		{
			return PartialView("_FaixaTabelaPrecoUpdate", _tabelaPrecoAppService.GetByIdFaixaTabelaPreco(id));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult UpdateFaixaTabelaPreco(FaixaTabelaPrecoViewModel faixaTabelaPrecoViewModel)
		{
			if (ModelState.IsValid)
			{
				_tabelaPrecoAppService.UpdateFaixaTabelaPreco(faixaTabelaPrecoViewModel);
				string url = Url.Action("ListFaixaTabelaPreco", "TabelaPreco", new { id = faixaTabelaPrecoViewModel.TabelaPrecoId });
				return Json(new { success = true, url = url });
			}
			return PartialView("_FaixaTabelaPrecoUpdate", faixaTabelaPrecoViewModel);
		}

		public ActionResult DeleteFaixaTabelaPreco(Guid id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var faixaTabelaPrecoViewModel = _tabelaPrecoAppService.GetByIdFaixaTabelaPreco(id);
			if (faixaTabelaPrecoViewModel == null)
			{
				return HttpNotFound();
			}
			return PartialView("_FaixaTabelaPrecoDelete", faixaTabelaPrecoViewModel);
		}

		public ActionResult DeletarFaixaTAbelaPreco(Guid id)
		{
			var tabelaPrecoId = _tabelaPrecoAppService.GetByIdFaixaTabelaPreco(id).TabelaPrecoId;
			_tabelaPrecoAppService.RemoveFaixaTabelaPreco(id);

			string url = Url.Action("_FaixaTabelaPrecoList", "TabelasPreco", new { id = tabelaPrecoId });
			return Json(new { success = true, url = url });
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_tabelaPrecoAppService.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
