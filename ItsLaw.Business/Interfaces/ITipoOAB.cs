using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ItsLaw.Business
{
    public interface ITipoOAB
    {
        TipoOAB              TipoOABGetById  (Int32 id);
        IEnumerable<TipoOAB> TipoOABPesquisar(Expression<Func<TipoOAB, Boolean>> filtro);
        IEnumerable<TipoOAB> TipoOABListagem (int pIDMaster);
        void                 TipoOABAdd      (TipoOAB itens);
        void                 TipoOABUpdate   (TipoOAB itens);
    }
}
