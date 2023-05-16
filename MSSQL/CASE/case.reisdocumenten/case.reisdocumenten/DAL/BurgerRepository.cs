using cases.reisdocumenten.Model;
using cases.reisdocumenten.Model.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.DAL
{
    public class BurgerRepository : IBurgerRepository
    {

        private readonly ReisdocumentenDbContext _context;

        public BurgerRepository(ReisdocumentenDbContext context)
        {
            _context = context;
        }

        public Burger GetBurgerById(long burgerid)
        {
            return _context.Burgers.FirstOrDefault(b => b.Id == burgerid);
        }
    }
}
