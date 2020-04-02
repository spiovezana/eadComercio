﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TropicalBears.Model.DataBase.Model
{
    public class FormaPagamento
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }
    }
    public class FormaPagamentoMap : ClassMapping<FormaPagamento>
    {
        public FormaPagamentoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));

            Property(x => x.Descricao);
        }
    }
}
