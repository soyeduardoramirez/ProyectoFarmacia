using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VEFAC.Core.Models;

namespace VEFAC.Core.BL.Interfaces
{
    public interface ILogin
    {
        Task<List<LoginResponse>> LoginUser(LoginResponse loginResponse);
    }
}
