using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webkd.Models;
using System.Web.Routing;

namespace Webkd.Controllers
{
    public class proveedoresController : Controller
    {
        [Authorize]
        // GET: proveedores
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.proveedor.ToList());
            }
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.proveedor.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return RedirectToAction("Index");


            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var findprover = db.proveedor.Find(id);
                return View(findprover);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var findprover = db.proveedor.Find(id);
                    db.proveedor.Remove(findprover);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor findprover = db.proveedor.Where(a => a.id == id).FirstOrDefault();
                    return View(findprover);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(proveedor editprover)
        {
            try
            {

                using (var db = new inventario2021Entities())
                {
                    proveedor prover = db.proveedor.Find(editprover.id);

                    prover.nombre = editprover.nombre;
                    prover.direccion = editprover.direccion;
                    prover.telefono = editprover.telefono;
                    prover.nombre_contacto = editprover.nombre_contacto;
                   

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }

        }

        public ActionResult PaginadorIndex(int pagina = 1)
        {
            try
            {
                var cantidadRegistros = 5;

                using (var db = new inventario2021Entities())
                {
                    var proveedor = db.proveedor.OrderBy(x => x.id).Skip((pagina - 1) * cantidadRegistros).Take(cantidadRegistros).ToList();

                    var totalRegistros = db.proveedor.Count();
                    var model = new proveedorIndex();
                    model.proveedors =  proveedor;
                    model.ActualPage = pagina;
                    model.Total = totalRegistros;
                    model.RecordsPage = cantidadRegistros;
                    model.valueQueryString = new RouteValueDictionary();

                    return View(model);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }


    }
}