using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace ItsLaw.Business.Interfaces
{
    public interface IUsuario
    {
        void                 UsuarioAdd             (Usuario itens);
        void                 UsuarioUpdate          (Usuario itens);
        IEnumerable<Usuario> UsuarioListagem        (int pIDMaster);
        IEnumerable<Usuario> UsuarioPesquisar       (Expression<Func<Usuario, Boolean>> filtro);
        IEnumerable<Empresa> UsuarioEmpresaListagem (int pIDMaster);
        Usuario              UsuarioGetById         (Int32 id);
        string               UsuarioPesquisarSenha  (string pEmail);
    }
}
