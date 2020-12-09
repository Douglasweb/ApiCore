using System.Collections.Generic;
using Primeiro.Models;

namespace Primeiro.Data
{
   public interface IPrimeiroRepo
   {
       IEnumerable<Primary> GetAppPrimary();
       Primary GetPrimaryById(int id);
   }
}