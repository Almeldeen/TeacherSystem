using BLL.Helper;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AuthServices
{
   public interface IAuthService
    {
        Task<ResponseBody<AuthModel>> RegisterAsync(RegisterModel model);
        Task<ResponseBody<AuthModel>> GetTokenAsync(TokenRequestModel model);
    }
}
