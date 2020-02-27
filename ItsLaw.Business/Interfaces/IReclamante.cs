using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace ItsLaw.Business.Interfaces
{
    public interface IReclamante
    {
        Reclamante              ReclamanteGetById  (Int32 id);
        IEnumerable<Reclamante> ReclamantePesquisar(Expression<Func<Reclamante, Boolean>> filtro);
        IEnumerable<Reclamante> ReclamanteListagem (int pIDMaster);
        void                    ReclamanteAdd      (Reclamante itens);
        void                    ReclamanteUpdate   (Reclamante itens);
    }
}
