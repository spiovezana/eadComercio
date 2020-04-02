using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TropicalBears.Model.DataBase.Model
{
    public class FluxoCaixa
    {
        public virtual int Id { get; set; }
        public virtual double ContasReceber { get; set; }
        public virtual double Emprestimos { get; set; }
        public virtual double DinheiroSocios { get; set; }
        public virtual double ContasPagar { get; set; }
        public virtual double DespesasGerais { get; set; }
        public virtual double PagamentoEmprestimos { get; set; }
        public virtual double ComprasVista { get; set; }

        public class FluxoCaixaMap : ClassMapping<FluxoCaixa>
        {
            public FluxoCaixaMap()
            {
                Id(x => x.Id, m => m.Generator(Generators.Identity));
                Property(x => x.ContasReceber);
                Property(x => x.Emprestimos);
                Property(x => x.DinheiroSocios);
                Property(x => x.ContasPagar);
                Property(x => x.DespesasGerais);
                Property(x => x.PagamentoEmprestimos);
                Property(x => x.ComprasVista);
            }
        }
    }
}
