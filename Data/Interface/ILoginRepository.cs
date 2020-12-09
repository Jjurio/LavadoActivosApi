using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Models;

namespace LavadoActivosApi.Data.Interface
{
    public interface ILoginRepository
    {
        public Task<List<Login>> Login(string vUser, string vpassword);

    }
}
