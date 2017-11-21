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
    public class EmprestimoController : Controller
    {
        private readonly IAmigoBusiness _businessAmigo;
        private readonly IEmprestimoBusiness _business;
        private readonly IJogoBusiness _businessJogo;

        public EmprestimoController(IAmigoBusiness businessAmigo, IEmprestimoBusiness business, IJogoBusiness businessJogo)
        {
            _businessAmigo = businessAmigo;
            _business = business;
            _businessJogo = businessJogo;

        }
        // GET: Emprestimo
        public ActionResult Index()
        {
            return View(Mapper.Map<IEnumerable<EmprestimoVM>>(_business.RecuperarEmprestimos()));
        }

        // GET: Emprestimo/Create
        public ActionResult Create()
        {
            PreencherCombo();
            return View();
        }

        private void PreencherCombo()
        {
            ViewBag.ComboAmigo = Mapper.Map<IEnumerable<AmigoVM>>(_businessAmigo.RecuperarDapper());
            ViewBag.ComboJogos = Mapper.Map<IEnumerable<JogoVM>>(_businessJogo.RecuperarDisponiveis());
        }
        // POST: Emprestimo/Create
        [HttpPost]
        public ActionResult Create(EmprestimoVM emprestimoVM)
        {
            try
            {
                string validarId = "00000000-0000-0000-0000-000000000000";
                if (emprestimoVM.Amigo.Id.ToString().Equals(validarId) ||
                    emprestimoVM.Jogo.Id.ToString().Equals(validarId))
                    if (!ModelState.IsValid)
                    {
                        PreencherCombo();
                        return View(emprestimoVM);
                    }

                _business.Salvar(Mapper.Map<Emprestimo>(emprestimoVM));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                PreencherCombo();
                ModelState.AddModelError("", e.Message);
                return View(emprestimoVM);
            }
        }

        // GET: Emprestimo/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(Mapper.Map<EmprestimoVM>(_business.Recuperar(id)));
        }

        // POST: Emprestimo/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, EmprestimoVM emprestimoVM)
        {
            try
            {
                _business.Deletar(Mapper.Map<Emprestimo>(emprestimoVM));
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(emprestimoVM);
            }
        }
    }
}
