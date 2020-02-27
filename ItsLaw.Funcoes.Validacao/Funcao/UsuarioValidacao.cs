using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItsLaw.Business;
using ItsLaw.Business.Interfaces;


namespace ItsLaw.Funcoes
{
    public class UsuarioValidacao
    {

        private readonly IUsuario _usuario = new UsuarioService();
        private readonly IEmpresa _Empresa = new EmpresaService();

        /* EGS IT Singular - 30.10.2018 - Limpa os dados do usuario
        */
        public void LimpaDadosUsuario()
        {
            //EGS 30.03.2018 - Grava o usuario logado, para usar em todos os cadastros
            UsuarioSession.Instance.SessionMasterID    = 0;     //ID da empresa Master
            UsuarioSession.Instance.SessionUserID      = 0;
            UsuarioSession.Instance.SessionPerfilID    = 0;
            UsuarioSession.Instance.SessionUserLogin   = "";
            UsuarioSession.Instance.SessionUserName    = "";
            UsuarioSession.Instance.SessionCompanyName = "";
        }


        /* EGS IT Singular - 30.10.2018 - Retorna os dados do usuario e empresa para mostrar nas telas
        */
        public void DadosUsuarioGlobal(int pIDUsuario)
        {
            var dados = _usuario.UsuarioGetById(pIDUsuario);
            UsuarioSession.Instance.SessionUserID      = dados.IdUsuario;
            UsuarioSession.Instance.SessionPerfilID    = dados.IdUsuarioPerfil;
            UsuarioSession.Instance.SessionUserName    = dados.Nome;
            UsuarioSession.Instance.SessionCompanyName = _Empresa.EmpresaGetById(dados.IdEmpresa).Fantasia + " (" + (UsuarioSession.Instance.SessionMasterID + 1187).ToString() + ")";
        }
    }
}
