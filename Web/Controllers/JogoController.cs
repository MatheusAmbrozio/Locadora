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
    public class JogoController : Controller
    {
        private readonly IJogoBusiness _business;
        private readonly IGeneroBusiness _businessGenero;

        public JogoController(IJogoBusiness business, IGeneroBusiness businessGenero)
        {
            _business = business;
            _businessGenero = businessGenero;
        }
        // GET: Jogo
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<JogoVM>>(_business.RecuperarDapper()));
        }

        // GET: Jogo/Details/5
        public ActionResult Details(Guid id)
        {
            return View(Mapper.Map<JogoVM>(_business.Recuperar(id)));
        }

        // GET: Jogo/Create
        public ActionResult Create()
        {
            ViewBag.GeneroCombo = Mapper.Map<IEnumerable<GeneroVM>>(_businessGenero.RecuperarDapper());
            return View();
        }

        // POST: Jogo/Create
        [HttpPost]
        public ActionResult Create(JogoVM jogoVM)
        {
            try
            {
                 
                _business.Salvar(Mapper.Map<Jogo>(jogoVM));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        // GET: Jogo/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(Mapper.Map<JogoVM>(_business.Recuperar(id)));
            
        }

        // POST: Jogo/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, JogoVM jogoVM)
        {
            try
            {
                _business.Alterar(Mapper.Map<Jogo>(jogoVM));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        // GET: Jogo/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(Mapper.Map<JogoVM>(_business.Recuperar(id)));
        }

        // POST: Jogo/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, JogoVM jogoVM)
        {
            try
            {
                _business.Deletar(Mapper.Map<Jogo>(jogoVM));
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "Não foi possivel deletar este jogo, verifique se ele não tem emprestimos em aberto.");
                ModelState.AddModelError("", e.Message);
                return View(Mapper.Map<JogoVM>(_business.Recuperar(id)));
            }
        }
    }
}
