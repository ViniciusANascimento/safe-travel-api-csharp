using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.User;
using API.Models;
using API.Repository;
using AutoMapper;

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

        public GetUserDTO GetUsers(string id)
        {
            var usuarioEncontrado = _userRepository.GetUserById(id);
            var dto = _mapper.Map<GetUserDTO>(usuarioEncontrado);

            return dto;
        }

        public async Task<List<GetUserDTO>> GetUsers(int limit, int offset)
        {
            if (limit == 0 || limit == null || limit > 10)
            {
                limit = 10;
            }
            var listaUsuario = await _userRepository.GetUsers(limit, offset);
            var listaDTO = _mapper.Map<List<GetUserDTO>>(listaUsuario);

            return listaDTO;
        }
    }
}