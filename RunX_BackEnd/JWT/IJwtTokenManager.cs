using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunX_BackEnd.JWT
{
    public interface IJwtTokenManager
    {
        string Authenticate(string email);
        string DeCode(string token);
        string forgotPasswordAuth(string email);
    }
}
