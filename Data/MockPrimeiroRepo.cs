using System.Collections.Generic;
using Primeiro.Models;

namespace Primeiro.Data
{
    public class MockPrimeiroRepo : IPrimeiroRepo
    {
        public IEnumerable<Primary> GetAppPrimary()
        {
            var primarys = new List<Primary>
            {
                new Primary { Id=1, Howto="Teste", Line="Testar", Platform="Douglas"    },
                new Primary { Id=2, Howto="Teste2", Line="Testar2", Platform="Douglas2" },
                new Primary { Id=3, Howto="Teste3", Line="Testar3", Platform="Douglas3" }
            };

            return primarys;
        }

        public Primary GetPrimaryById(int id)
        {
            return new Primary { Id = id, Howto = "Teste", Line = "Testar", Platform = "Douglas" };
        }
    }
}