using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace ItsLaw.Business.Interfaces
{
    public interface IEscritorio
    {
        Escritorio              EscritorioGetById  (Int32 id);
        IEnumerable<Escritorio> EscritorioPesquisar(Expression<Func<Escritorio, Boolean>> filtro);
        IEnumerable<Escritorio> EscritorioListagem (int pIDMaster);
        void                    EscritorioAdd      (Escritorio itens);
        void                    EscritorioUpdate   (Escritorio itens);
        byte[]                  EscritorioRetornaFigura(int iIDEscritorio);
    }
}
