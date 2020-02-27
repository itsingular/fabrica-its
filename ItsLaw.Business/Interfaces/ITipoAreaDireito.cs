using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ItsLaw.Business
{
    public interface ITipoAreaDireito
    {
        TipoAreaDireito              TipoAreaDireitoGetById  (Int32 id);
        IEnumerable<TipoAreaDireito> TipoAreaDireitoPesquisar(Expression<Func<TipoAreaDireito, Boolean>> filtro);
        IEnumerable<TipoAreaDireito> TipoAreaDireitoListagem (int pIDMaster);
        void                         TipoAreaDireitoAdd      (TipoAreaDireito itens);
        void                         TipoAreaDireitoUpdate   (TipoAreaDireito itens);
    }
}
