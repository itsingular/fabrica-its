using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ItsLaw.Business
{
    public interface IComarca
    {
        Comarca              ComarcaGetById  (Int32 id);
        IEnumerable<Comarca> ComarcaPesquisar(Expression<Func<Comarca, Boolean>> filtro);
        IEnumerable<Comarca> ComarcaListagem (int pIDMaster);
        void                 ComarcaAdd      (Comarca itens);
        void                 ComarcaUpdate   (Comarca itens);
    }
}
