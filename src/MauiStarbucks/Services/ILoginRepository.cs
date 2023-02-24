using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiStarbucks.Models;

namespace MauiStarbucks.Services
{
    public interface ILoginRepository
    {
        Task<UserInfo> Login(string userName, string password);
    }
}
