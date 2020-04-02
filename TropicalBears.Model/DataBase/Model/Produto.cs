﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TropicalBears.Model.DataBase.Model
{
    public class Produto
    {
        public virtual int Id { get; set; }
        public virtual Categoria Categoria { get; set; }
        //public virtual Subcategoria Subcategoria { get; set; }
        //public virtual Tipo Tipo { get; set; }

        //public virtual double Preco { get; set; }

        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int Status { get; set; }

        public virtual int Estoque { get; set; }
        //public virtual DateTime CreatedAt { get; set; }
        //public virtual DateTime UpdatedAt { get; set; }

        //comments
        public virtual IList<Comentario> Comentarios { get; set; }

        //images
        public virtual IList<Imagem> Imagens { get; set; }

       


        public virtual double MediaAvaliacao()
        {
            int coment = 0;
            if(Comentarios != null && Comentarios.Count > 0)
            {
                foreach (var item in Comentarios)
                {
                    if (item.Avaliacao == "Bom")
                    {
                        coment++;
                    }
                }

                double onepct = Convert.ToDouble(this.Comentarios.Count()) / 100;

                return 100 - ((Comentarios.Count() - coment) / onepct);

            }
            return 100;
        }

        public virtual double MediaAvaliacaoNegativa()
        {
            return 100 - this.MediaAvaliacao();
        }

    }
    public class ProdutoMap : ClassMapping<Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));

            ManyToOne(x => x.Categoria,m => {
                m.Cascade(Cascade.All);
                m.Column("categoria_id");
                m.Class(typeof(Categoria));
                m.Lazy(LazyRelation.NoLazy);
            });

            /* ManyToOne(x => x.Subcategoria, m => {
                 m.Cascade(Cascade.All);
                 m.Column("subcategoria_id");
                 m.Class(typeof(Subcategoria));
                 m.Lazy(LazyRelation.NoLazy);
             });

             ManyToOne(x => x.Tipo, m => {
                 m.Cascade(Cascade.All);
                 m.Column("tipo_id");
                 m.Class(typeof(Tipo));
                 m.Lazy(LazyRelation.NoLazy);
             }); */

            Property(x => x.Nome);
            Property(x => x.Descricao);
            Property(x => x.Status);
           
            Bag<Imagem>(x => x.Imagens, m =>
            {
                m.Cascade(Cascade.All);
                m.Key(k => k.Column("produto_id"));
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
            },
            r => r.OneToMany());

            Bag<Comentario>(x => x.Comentarios, m =>
            {
                m.Cascade(Cascade.None);
                m.Key(k => k.Column("produto_id"));
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
            },
            r => r.OneToMany());
            
        }

    }
}
