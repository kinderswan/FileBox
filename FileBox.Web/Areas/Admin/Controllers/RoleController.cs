using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FileBox.Model.Models;
using FileBox.Service;
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
            var viewRoles = Mapper.Map<IEnumerable<UserRole>, IEnumerable<UserRoleViewModel>>(roles);
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
            return View(Mapper.Map<UserRole, UserRoleViewModel>(role));
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
            var editRole = Mapper.Map<UserRole, UserRoleFormModel>(role);
            return View(editRole);
        }

        [HttpPost]
        public ActionResult Edit(UserRoleFormModel rModel)
        {
            if (ModelState.IsValid)
            {
                var editRole = Mapper.Map<UserRoleFormModel, UserRole>(rModel);

                RoleService.UpdateRole(editRole);
                RoleService.SaveUserRole();
                return RedirectToAction("Index");
            }
            return View(rModel);
        }

    }
}