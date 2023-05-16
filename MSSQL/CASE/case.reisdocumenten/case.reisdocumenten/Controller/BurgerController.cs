using cases.reisdocumenten.DAL;
using cases.reisdocumenten.Model;
using cases.reisdocumenten.Model.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Controller
{
    public class BurgerController
    {

        private DbContextOptions<ReisdocumentenDbContext> _options;

        public BurgerController(DbContextOptions<ReisdocumentenDbContext> options)
        {
            _options = options;
        }

        public Burger GetBurgerById(int burgerId)
        {
            using (var context = new ReisdocumentenDbContext(_options))
            {
                IBurgerRepository repo = new BurgerRepository(context);

                var burger = repo.GetBurgerById(burgerId);

                return burger;
            }
        }


    }
}
