using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileBox.Model.Models;
using FileBox.Service;
using FileBox.Service.Interfaces;
using FileBox.Web.Mappings;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Areas.Admin.Controllers
{
    public class RoleController : AdminController
    {

        public RoleController() { }

        public RoleController(IUserRoleService rService)
        {
            RoleService = rService;
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            var roles = RoleService.GetRoleInfos();
            var viewRoles = roles.Select(r => r.ToUserRoleMapModel());
            return View(viewRoles);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToNotFoundPage;
            }
            var role = RoleService.GetRoleInfo((int)id);
            if (role == null)
            {
                return RedirectToNotFoundPage;
            }
            var detailRole = role.ToUserRoleMapModel();
            return View(detailRole);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToNotFoundPage;
            }
            var role = RoleService.GetRoleInfo((int)id);
            if (role == null)
            {
                return RedirectToNotFoundPage;
            }
            var editRole = role.ToUserRoleMapModel();
            return View(editRole);
        }

        [HttpPost]
        public ActionResult Edit(UserRoleMapModel rModel)
        {
            if (ModelState.IsValid)
            {
                //var editRole = Mapper.Map<UserRoleMapModel, UserRole>(rModel);
                var editRole = rModel.ToUserRole();

                RoleService.UpdateRole(editRole);
                RoleService.SaveUserRole();
                return RedirectToAction("Index");
            }
            return View(rModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserRoleMapModel rModel)
        {
            if (ModelState.IsValid)
            {
                var role = rModel.ToUserRole();
                RoleService.CreateRole(role);
                RoleService.SaveUserRole();
                return RedirectToAction("Index");
            }
            return View(rModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToNotFoundPage;
            }
            var role = RoleService.GetRoleInfo((int)id);
            if (role == null)
            {
                return RedirectToNotFoundPage;
            }
            var deleteRole = role.ToUserRoleMapModel();
            return View(deleteRole);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleService.DeleteUserRole(id);
            RoleService.SaveUserRole();
            return RedirectToAction("Index");
        }

    }
}