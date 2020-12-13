using System.Collections.Generic;
using Primeiro.Models;

namespace Primeiro.Data
{
   public interface IPrimeiroRepo
   {
       bool Savechanges();
       IEnumerable<Primary> GetAllPrimary();
       Primary GetPrimaryById(int id);
       void CreatePrimary(Primary pr);
       void UpdatePrimary(Primary pr);
       void DeletePrimary(Primary pr);
   }
}