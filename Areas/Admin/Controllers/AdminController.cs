using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileBox.Web.Controllers;
using FileBox.Web.Global.Auth;

namespace FileBox.Web.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
    }
}