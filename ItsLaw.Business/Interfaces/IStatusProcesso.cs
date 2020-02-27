using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ItsLaw.Business
{
    public interface IStatusProcesso
    {
        StatusProcesso              StatusProcessoGetById  (Int32 id);
        IEnumerable<StatusProcesso> StatusProcessoPesquisar(Expression<Func<StatusProcesso, Boolean>> filtro);
        IEnumerable<StatusProcesso> StatusProcessoListagem (int pIDMaster);
        void                        StatusProcessoAdd      (StatusProcesso itens);
        void                        StatusProcessoUpdate   (StatusProcesso itens);
		}
}
