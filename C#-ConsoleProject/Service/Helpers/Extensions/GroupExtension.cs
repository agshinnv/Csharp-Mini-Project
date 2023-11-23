using Domain.Models;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public static class GroupExtension
    {
        public static bool ExistingName(this string name)
        {
            return AppDbContext<Group>.Datas.Exists(m=>m.Name.ToLower().Trim() == name.ToLower().Trim());
        }
    }
}
