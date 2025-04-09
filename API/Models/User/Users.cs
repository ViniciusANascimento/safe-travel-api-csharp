using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace API.Models.User
{
    public class Users
    {

        //Constructor para criação de novo usuario
        public Users(string nome, string email, string senha)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Email = email;
            Senha = senha;
            DataCriacao = DateTime.UtcNow;
            DataAtualizacao = DateTime.UtcNow;
            Role = EnumRole.User;
            Status = EnumStatus.Ativo;
        }

        public Users() { }
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public EnumRole Role { get; set; }
        
        public EnumStatus Status { get; set; }
  }
}