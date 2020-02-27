using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace ItsLaw.Business.Interfaces
{
    public interface ITestemunha
    {
        Testemunha              TestemunhaGetById   (Int32 id);
        IEnumerable<Testemunha> TestemunhaPesquisar (Expression<Func<Testemunha, Boolean>> filtro);
        IEnumerable<Testemunha> TestemunhaListagem  (int pIDMaster);
        void                    TestemunhaAdd       (Testemunha itens);
        void                    TestemunhaUpdate    (Testemunha itens);
    }
}
