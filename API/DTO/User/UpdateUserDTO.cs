using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace API.DTO.User
{
    public class UpdateUserDTO 
    {
        [Required(ErrorMessage = "O id é obrigatório")]
        public int Id { get; set; }

       
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; }

        
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [MaxLength(10, ErrorMessage = "A senha deve ter no máximo 10 caracteres")]
        public string Senha { get; set; } 
    }
}