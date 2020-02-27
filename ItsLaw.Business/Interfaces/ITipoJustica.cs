using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ItsLaw.Business
{
    public interface ITipoJustica
    {
        TipoJustica              TipoJusticaGetById  (Int32 id);
        IEnumerable<TipoJustica> TipoJusticaPesquisar(Expression<Func<TipoJustica, Boolean>> filtro);
        IEnumerable<TipoJustica> TipoJusticaListagem (int pIDMaster);
        void                     TipoJusticaAdd      (TipoJustica itens);
        void                     TipoJusticaUpdate   (TipoJustica itens);
    }
}
