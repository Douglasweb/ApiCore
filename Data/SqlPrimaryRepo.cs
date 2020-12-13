using System;
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

        public void CreatePrimary(Primary pr)
        {
            if(pr == null)
            {
                throw new ArgumentNullException(nameof(pr));
            }
            
            _context.Primarys.Add(pr);
        }

        public void DeletePrimary(Primary pr)
        {
            if(pr == null)
            {
                throw new ArgumentNullException(nameof(pr));
            }

            _context.Primarys.Remove(pr);
        }

        public IEnumerable<Primary> GetAllPrimary()
        {
            return _context.Primarys.ToList();
        }

        public Primary GetPrimaryById(int id)
        {
            return  _context.Primarys.FirstOrDefault(p => p.Id == id);
        }

        public bool Savechanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePrimary(Primary pr)
        {
            //Nothing
        }
    }

}