﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webkd.Models;

namespace Webkd.Controllers
{
    public class UsuarioRolController : Controller
    {
        // GET: UsuarioRol
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.usuariorol.ToList());
            }

        }

        public static string nombreusuario(int idusuario)
        {
            using (var db = new inventario2021Entities())
            {
                return db.usuario.Find(idusuario).nombre;
            }
        }

        public ActionResult ListarUsuarios()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.usuario.ToList());
            }
        }

        public static string Descripcionrol(int idroles)
        {
            using (var db = new inventario2021Entities())
            {
                return db.roles.Find(idroles).descripcion;
            }
        }

        public ActionResult ListarRoles()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.roles.ToList());
            }
        }






        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(usuariorol usuariorol)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.usuariorol.Add(usuariorol);
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
                return View(db.usuariorol.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventario2021Entities())
            {
                usuariorol usuariorolEdit = db.usuariorol.Where(a => a.id == id).FirstOrDefault();
                return View(usuariorolEdit);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(usuariorol usuariorolEdit)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var oldusuariorol = db.usuariorol.Find(usuariorolEdit.id);
                    oldusuariorol.idUsuario = usuariorolEdit.idUsuario;
                    oldusuariorol.idRol = usuariorolEdit.idRol;
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

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                   usuariorol usuariorol = db.usuariorol.Find(id);
                    db.usuariorol.Remove(usuariorol);
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
    }
    
}