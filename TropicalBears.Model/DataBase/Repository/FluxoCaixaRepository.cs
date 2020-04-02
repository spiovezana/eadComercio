using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TropicalBears.Model.DataBase.Model;

namespace TropicalBears.Model.DataBase.Repository
{
    public class FluxoCaixaRepository : RepositoryBase<FluxoCaixa>
    {
        public FluxoCaixaRepository(ISession session) : base(session)
        {
        }

    }
}
