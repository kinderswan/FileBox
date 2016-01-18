using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Model.Models;
using FileBox.Web.ViewModels;

namespace FileBox.Web.Global.Auth
{
    interface IUserProvider
    {
        UserInfoAdminModel User { get; set; }
    }
}
