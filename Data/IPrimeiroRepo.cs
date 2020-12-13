using System.Collections.Generic;
using Primeiro.Models;

namespace Primeiro.Data
{
   public interface IPrimeiroRepo
   {
       IEnumerable<Primary> GetAllPrimary();
       Primary GetPrimaryById(int id);
   }
}