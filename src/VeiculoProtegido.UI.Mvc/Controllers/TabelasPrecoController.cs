using Microsoft.Ajax.Utilities;
using System;
using System.Net;
using System.Web.Mvc;
using VeiculoProtegido.Application.Interfaces;
using VeiculoProtegido.Application.ViewModels;

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
