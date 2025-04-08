using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Validation
{
    public static class UserDesconstruct
    {
        public static void Deconstruct(
            this Users user,
            out string id, out string nome, out string email, out DateTime dataAtualizacao
        )
        {
            id = user.Id;
            nome = user.Nome;
            email = user.Email;
            dataAtualizacao = user.DataAtualizacao;
        }
        
    }
}