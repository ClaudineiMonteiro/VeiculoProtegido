using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VeiculoProtegido.Application.Interfaces;
using VeiculoProtegido.Application.ViewModels;
using VeiculoProtegido.UI.Mvc.Models;

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
        public ActionResult Create([Bind(Include = "TabelaPrecoId,Descricao,TipoFipe,DataHoraCadastro,DataHoraUltimaAlteracao")] TabelaPrecoViewModel tabelaPrecoViewModel)
        {
            if (ModelState.IsValid)
            {
                tabelaPrecoViewModel.TabelaPrecoId = Guid.NewGuid();
                db.TabelaPrecoViewModels.Add(tabelaPrecoViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabelaPrecoViewModel);
        }

        // GET: TabelasPreco/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaPrecoViewModel tabelaPrecoViewModel = db.TabelaPrecoViewModels.Find(id);
            if (tabelaPrecoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(tabelaPrecoViewModel);
        }

        // POST: TabelasPreco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TabelaPrecoId,Descricao,TipoFipe,DataHoraCadastro,DataHoraUltimaAlteracao")] TabelaPrecoViewModel tabelaPrecoViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabelaPrecoViewModel).State = EntityState.Modified;
                db.SaveChanges();
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
            TabelaPrecoViewModel tabelaPrecoViewModel = db.TabelaPrecoViewModels.Find(id);
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
            TabelaPrecoViewModel tabelaPrecoViewModel = db.TabelaPrecoViewModels.Find(id);
            db.TabelaPrecoViewModels.Remove(tabelaPrecoViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
