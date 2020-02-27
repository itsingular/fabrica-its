using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ItsLaw.Business.Interfaces
{
    public interface IUsuarioPerfil
    {
        void                       UsuarioPerfilAdd        (UsuarioPerfil itens);
        void                       UsuarioPerfilUpdate     (UsuarioPerfil itens);
        IEnumerable<UsuarioPerfil> UsuarioPerfilListagem   (int pIDMaster);
        IEnumerable<UsuarioPerfil> UsuarioPerfilPesquisar  (Expression<Func<UsuarioPerfil, Boolean>> filtro);
        UsuarioPerfil              UsuarioPerfilGetById    (Int32 id);
        List<UsuarioPerfilDireito> RetornaDireitosDoUsuario(int id);
        bool                       PerfilDireitoAutoriza   (string path, string pAcao, int id);
        bool                       AddAcessoDireitoBranco  (int pIDMaster, int pIDUsuarioInc);

    }
}
