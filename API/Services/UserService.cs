using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.User;
using API.Models;
using API.Repository;

namespace API.Services
{
    public class UserService
    {
        public UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public Users CreateUser(CreateUserDTO user)
        {
            var novoUsuario = new Users(
                nome: user.Nome.ToUpperInvariant(),
                email: user.Email.Trim().ToLowerInvariant(),
                senha: BCrypt.Net.BCrypt.HashPassword(user.Senha)
            );
            _userRepository.CreateUser(novoUsuario);
            return novoUsuario;

        }

        public Users GetUsers(string id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}