using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.User;

namespace API.DTO.User
{
  public class GetUserDTO
  {
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public EnumStatus Status { get; set; }
  }
}