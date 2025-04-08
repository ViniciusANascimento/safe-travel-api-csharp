using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace API.Models
{
    public class Users
    {
        private string _nome;
        private string _email;
        private string _senha;
        public Users(string nome, string email, string senha)
        {
            Id = Guid.NewGuid().ToString();
            _nome = nome;
            _email = email;
            _senha = senha;
            DataCriacao = DateTime.UtcNow;
        }
        public string Id { get; set; }
        public string Nome {
            get => _nome;
            set => _nome.ToUpper();
        }
        public string Email
        {
            get => _email;
            set => _email.ToLower();
        }
        public string Senha
        {
            get => _senha;
            set => BCrypt.Net.BCrypt.HashPassword(_senha);
        }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;

        public EnumRole Role { get; set; } = EnumRole.User;
        
    }
}