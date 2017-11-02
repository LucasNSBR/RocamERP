using AutoMapper;
using RocamERP.Application.Interfaces.ClienteApplicationService;
using RocamERP.Domain.Models;
using RocamERP.Presentation.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RocamERP.Presentation.Web.Areas.Plataforma.Controllers
{
    public class ClientesController : Controller
    {
        IClienteApplicationService _clienteApplicationService;

        public ClientesController(IClienteApplicationService clienteApplicationService)
        {
            _clienteApplicationService = clienteApplicationService;
        }

        public ActionResult Index()
        {
            var clientes = _clienteApplicationService.Get();
            var clientesVM = new List<ClienteViewModel>();

            foreach (var cliente in clientes)
            {
                var obj = Mapper.Map(cliente, cliente.GetType(), typeof(ClienteViewModel));
                clientesVM.Add(obj as ClienteViewModel);
            }

            return View(clientesVM);
        }

        // GET: Plataforma/Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Plataforma/Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plataforma/Clientes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plataforma/Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Plataforma/Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plataforma/Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Plataforma/Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
