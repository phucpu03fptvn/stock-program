using StockProgram_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProgram_Application.Services.TokenService
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
