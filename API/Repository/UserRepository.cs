using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.Models.User;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class UserRepository
    {
        private readonly DBContext _context;

        public UserRepository(DBContext context)
        {
            _context = context;
        }

        public void CreateUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            Console.WriteLine($"Usuario {user.Id} criado com sucesso");
        }

        public Users GetUserById(string id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<Users>> GetUsers(int limit,int offset)
        {
            return await _context.Users.Skip(offset).Take(limit).ToListAsync();
            //return nextPage;
        }

        public Users UpdateUser(Users user)
        {
            var userUpdated = _context.Users.Update(user);
            
            if (userUpdated.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
            {
                _context.SaveChanges();
                Console.WriteLine($"Usuario {user.Id} foi alterado com sucesso");
            }
            else
            {
                Console.WriteLine("Não foi possivel alterar o usuario");
            }
            return user;

            
        }
  }
}