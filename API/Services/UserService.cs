using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.User;
using API.Models.User;
using API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API.Services
{
    public class UserService
    {
        public UserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(UserRepository userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
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

        //Retorna um usuario
        public GetUserDTO GetUsers(string id)
        {
            var usuarioEncontrado = GetUserRepository(id);
            var dto = _mapper.Map<GetUserDTO>(usuarioEncontrado);

            return dto;
        }

        //Retorna uma lista de usuarios
        public async Task<List<GetUserDTO>> GetUsers(int limit, int offset)
        {
            if (limit == 0 || limit > 10)
            {
                limit = 10;
            }
            var listaUsuario = await _userRepository.GetUsers(limit, offset);
            var listaDTO = _mapper.Map<List<GetUserDTO>>(listaUsuario);

            return listaDTO;
        }

        //Atualiza um usuario
        public GetUserDTO UpdateUser(string id, UpdateUserDTO user)
        {
            var usuarioEncontrado = GetUserRepository(id);

            usuarioEncontrado.Nome = !string.IsNullOrEmpty(user.Nome) ? user.Nome.ToUpperInvariant() : usuarioEncontrado.Nome;
            usuarioEncontrado.Email = !string.IsNullOrEmpty(user.Email) ? user.Email.Trim().ToLowerInvariant() : usuarioEncontrado.Email;
            usuarioEncontrado.Senha = !string.IsNullOrEmpty(user.Senha) ? BCrypt.Net.BCrypt.HashPassword(user.Senha) : usuarioEncontrado.Senha;
            usuarioEncontrado.DataAtualizacao = DateTime.UtcNow;

            //Alterar depois para que verifique se o usuario logado é admin para alterar o role
            if (usuarioEncontrado.Role == EnumRole.Admin)
                usuarioEncontrado.Role = !string.IsNullOrEmpty(user.Role) ? Enum.Parse<EnumRole>(user.Role) : usuarioEncontrado.Role;

            _userRepository.UpdateUser(usuarioEncontrado);
            return _mapper.Map<GetUserDTO>(usuarioEncontrado);
        }

        //Desativa um usuario
        public void DeleteUser(string id)
        {
            //Alterar depois para que verifique se o usuario logado é admin para desativar o usuario
            var usuarioEncontrado = GetUserRepository(id);
            usuarioEncontrado.Status = EnumStatus.Inativo;
            _userRepository.UpdateUser(usuarioEncontrado);
        }

        private Users GetUserRepository(string id)
        {
            //var idString = id.ToString();
            Users usuarioEncontrado = _userRepository.GetUserById(id);
            if (usuarioEncontrado == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            return usuarioEncontrado;
        }
  }
}