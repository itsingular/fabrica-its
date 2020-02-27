using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ItsLaw.Business.Interfaces
{
    public interface IUsuarioPath
    {
        void Add(UsuarioPath itens);
        void Update(UsuarioPath itens);
        IEnumerable<UsuarioPath> Listagem();
        IEnumerable<UsuarioPath> Pesquisar(Expression<Func<UsuarioPath, Boolean>> filtro);
        UsuarioPath GetById(Int32 id);
    }
}
