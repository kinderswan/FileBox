using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Model.Models;

namespace FileBox.Web.Global.Auth
{
    interface IUserProvider
    {
        UserInfo User { get; set; }
    }
}
