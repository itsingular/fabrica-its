using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace ItsLaw.Business.Interfaces
{
    public interface IParteContraria
    {
        ParteContraria              ParteContrariaGetById  (Int32 id);
        IEnumerable<ParteContraria> ParteContrariaPesquisar(Expression<Func<ParteContraria, Boolean>> filtro);
        IEnumerable<ParteContraria> ParteContrariaListagem (int pIDMaster);
        void                        ParteContrariaAdd      (ParteContraria itens);
        void                        ParteContrariaUpdate   (ParteContraria itens);
    }
}
