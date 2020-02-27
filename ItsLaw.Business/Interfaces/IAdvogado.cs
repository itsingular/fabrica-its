using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace ItsLaw.Business.Interfaces
{
    public interface IAdvogado
    {
        Advogado              AdvogadoGetById      (Int32 id);
        IEnumerable<Advogado> AdvogadoPesquisar    (Expression<Func<Advogado, Boolean>> filtro);
        IEnumerable<Advogado> AdvogadoListagem     (int pIDMaster);
        void                  AdvogadoAdd          (Advogado itens);
        void                  AdvogadoUpdate       (Advogado itens);
    }
}
