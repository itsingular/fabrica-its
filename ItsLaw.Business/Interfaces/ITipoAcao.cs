using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ItsLaw.Business
{
    public interface ITipoAcao
    {
        TipoAcao              TipoAcaoGetById  (Int32 id);
        IEnumerable<TipoAcao> TipoAcaoPesquisar(Expression<Func<TipoAcao, Boolean>> filtro);
        IEnumerable<TipoAcao> TipoAcaoListagem (int pIDMaster);
        void                  TipoAcaoAdd      (TipoAcao itens);
        void                  TipoAcaoUpdate   (TipoAcao itens);
    }
}
