using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ItsLaw.Business
{
    public interface IProcesso
    {
        Processo              ProcessoGetById  (Int32 id);
        IEnumerable<Processo> ProcessoPesquisar(Expression<Func<Processo, Boolean>> filtro);
        IEnumerable<Processo> ProcessoListagem (ProcessoFiltro ItemFiltro);
        DashBoard             ProcessoDashBoard(int pIDUsuario);
        void                  ProcessoAdd      (Processo itens);
        void                  ProcessoUpdate   (Processo itens);
		}
}
