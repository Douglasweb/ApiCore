using System.Collections.Generic;
using System.Linq;
using Primeiro.Models;

namespace  Primeiro.Data
{
    public class SqlPrimaryRepo : IPrimeiroRepo
    {
        private readonly PrimeiroContext _context;

        public SqlPrimaryRepo(PrimeiroContext context)
        {
            _context = context;
        }
        public IEnumerable<Primary> GetAllPrimary()
        {
            return _context.Primarys.ToList();
        }

        public Primary GetPrimaryById(int id)
        {
            return  _context.Primarys.FirstOrDefault(p => p.Id == id);
        }
    }

}