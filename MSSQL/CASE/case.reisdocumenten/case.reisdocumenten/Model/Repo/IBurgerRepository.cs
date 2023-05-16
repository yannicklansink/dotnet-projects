using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cases.reisdocumenten.Model.Repo
{
    public interface IBurgerRepository
    {

        Burger GetBurgerById(long id);
    }
}
