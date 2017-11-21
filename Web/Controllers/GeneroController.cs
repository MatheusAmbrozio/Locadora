using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LocadoraS2IT.Business.IBusiness;
using LocadoraS2IT.Shared.Entities;
using LocadoraS2IT.Web.Models;

namespace LocadoraS2IT.Web.Controllers
{
    [Authorize]
    public class GeneroController : Controller
    {
        private readonly IGeneroBusiness _business;

        public GeneroController(IGeneroBusiness business)
        {
            _business = business;
        }
        
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<GeneroVM>>(_business.RecuperarDapper()));
        }

        // GET: Genero/Details/5
        public ActionResult Details(Guid id)
        {
            return View(Mapper.Map<GeneroVM>(_business.Recuperar(id)));
        }

        // GET: Genero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genero/Create
        [HttpPost]
        public ActionResult Create(GeneroVM generoVM)
        {
            try
            {
                _business.Salvar(Mapper.Map<Genero>(generoVM));
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Genero/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(Mapper.Map<GeneroVM>(_business.Recuperar(id)));
        }

        // POST: Genero/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, GeneroVM collection)
        {
            try
            {
                _business.Alterar(Mapper.Map<Genero>(collection));
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(collection);
            }
        }

        // GET: Genero/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(Mapper.Map<GeneroVM>(_business.Recuperar(id)));
        }

        // POST: Genero/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, GeneroVM collection)
        {
            try
            {
                _business.Deletar(Mapper.Map<Genero>(collection));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }
    }
}
