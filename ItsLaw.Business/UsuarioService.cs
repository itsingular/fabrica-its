using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Infra.Repository;
using ItsLaw.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Net.Mail;


namespace ItsLaw.Business
{
    public class UsuarioService : IUsuario
    {
        private readonly UsuarioRepository       _Usuario     = new UsuarioRepository();
        private readonly UsuarioRepository       _UsuarioID   = new UsuarioRepository();
        private readonly EmpresaRepository       _EmpresaID   = new EmpresaRepository();
        private readonly UsuarioPerfilRepository _PerfilID    = new UsuarioPerfilRepository();
        protected ItsLawContext _contexto = new ItsLawContext();

        public void Dispose()
        {
            _contexto.Dispose();
            _EmpresaID.Dispose();
            _Usuario.Dispose();
        }
        
        public void UsuarioAdd(Usuario itens)
        {
            _Usuario.Add(itens);
        }

        public void UsuarioUpdate(Usuario itens)
        {
            _Usuario.Update(itens);
        }

        public Usuario UsuarioGetById(int id)
        {
            var saida = _Usuario.GetById(id);
            //-------------- Dados da Inclusao ----------------------------------------------- 31.12.2018
            Usuario UsuarioInc = new Usuario();
            Empresa UsuarioEmp = new Empresa();
            UsuarioPerfil UsuarioPerf = new UsuarioPerfil();
            UsuarioInc  = _UsuarioID.GetById(saida.IdUsuarioInclusao);
            UsuarioEmp  = _EmpresaID.GetById(saida.IdEmpresa);
            UsuarioPerf = _PerfilID.GetById(saida.IdUsuarioPerfil);
            saida.UsuarioInclusaoNome = UsuarioInc.Nome;
            saida.UsuarioInclusaoNome = UsuarioInc.Nome;
            saida.FantasiaEmpresa     = UsuarioEmp.Fantasia;
            saida.PerfilNome          = UsuarioPerf.Descricao;
            //-------------- Dados da Alteracao ----------------------------------------------
            if (saida.IdUsuarioAlteracao != null)
            {
                Usuario UsuarioMan = new Usuario();
                UsuarioMan = _UsuarioID.GetById(Convert.ToInt32(saida.IdUsuarioAlteracao));
                saida.UsuarioAlteracaoNome = UsuarioMan.Nome;
            }
            //-------------------------------------------------------------------------------------------
            return saida;
        }

        public IEnumerable<Usuario> UsuarioListagem(int pIDMaster)
        {
            //EGS 30.04.2018 - Incluindo nome dos usuarios de inclusao e manutencao
            var tabela = (from ifs      in _contexto.Usuario 
                          join _Empresa in _contexto.Empresa       on ifs.IdEmpresa            equals _Empresa.IdEmpresa
                          join _Perfil  in _contexto.UsuarioPerfil on ifs.IdUsuarioPerfil      equals _Perfil.IdUsuarioPerfil 
                          join _UsuaInc in _contexto.Usuario       on ifs.IdUsuarioInclusao    equals _UsuaInc.IdUsuario 
                          join _UsuaAlt in _contexto.Usuario       on ifs.IdUsuarioAlteracao   equals _UsuaAlt.IdUsuario into tm
                          from subUser  in tm.DefaultIfEmpty()
                          let UsuarioAlteracao = subUser.Nome
                          where ifs.Ativo.Equals(true) && ifs.IdMaster.Equals(pIDMaster)      //True e IDMaster
                          select new
                          {
                              IdMaster                = ifs.IdMaster,
                              IdUsuario               = ifs.IdUsuario,
                              IdUsuarioPerfil         = ifs.IdUsuarioPerfil,
                              PerfilNome              = _Perfil.Descricao,
                              Email                   = ifs.Email,
                              Nome                    = ifs.Nome,
                              Apelido                 = ifs.Apelido,
                              IdEmpresa               = ifs.IdEmpresa,
                              SenhaCripto             = ifs.SenhaCripto,
                              FantasiaEmpresa         = _Empresa.Fantasia,
                              Fotografia              = ifs.Fotografia,
                              IdUsuarioInclusao       = ifs.IdUsuarioInclusao,
                              UsuarioInclusaoNome     = _UsuaInc.Nome.Substring(0, 16),
                              DtUsuarioInclusao       = ifs.DtUsuarioInclusao,
                              IdUsuarioAlteracao      = ifs.IdUsuarioAlteracao,
                              UsuarioAlteracaoNome    = UsuarioAlteracao.Substring(0, 16),
                              DtUsuarioAlteracao      = ifs.DtUsuarioAlteracao,
                              DtSenhaAlteracao        = ifs.DtSenhaAlteracao,
                              CodigoAtivacao          = ifs.CodigoAtivacao,
                              AtivoEmail              = ifs.AtivoEmail,
                              Ativo                   = ifs.Ativo
                          }).ToList().Select(x => new Usuario()
                          {
                              IdMaster                = x.IdMaster,
                              IdUsuario               = x.IdUsuario,
                              IdUsuarioPerfil         = x.IdUsuarioPerfil,
                              PerfilNome              = x.PerfilNome,
                              Email                   = x.Email,
                              Nome                    = x.Nome,
                              Apelido                 = x.Apelido,
                              IdEmpresa               = x.IdEmpresa,
                              SenhaCripto             = x.SenhaCripto,
                              FantasiaEmpresa         = x.FantasiaEmpresa,
                              Fotografia              = x.Fotografia,
                              IdUsuarioInclusao       = x.IdUsuarioInclusao,
                              UsuarioInclusaoNome     = x.UsuarioInclusaoNome,
                              DtUsuarioInclusao       = x.DtUsuarioInclusao,
                              IdUsuarioAlteracao      = x.IdUsuarioAlteracao,
                              UsuarioAlteracaoNome    = x.UsuarioAlteracaoNome,
                              DtUsuarioAlteracao      = x.DtUsuarioAlteracao,
                              DtSenhaAlteracao        = x.DtSenhaAlteracao,
                              CodigoAtivacao          = x.CodigoAtivacao,
                              AtivoEmail              = x.AtivoEmail,
                              Ativo                   = x.Ativo
                          }).ToList();
            return tabela;
        }



        public IEnumerable<Empresa> UsuarioEmpresaListagem(int pIDMaster)
        {
            //EGS 30.09.2018 - Lista as Empresas para aquele usuario
            var tabela = (from ifs in _contexto.Empresa where ifs.Ativo.Equals(true) && ifs.IdMaster.Equals(pIDMaster) select ifs).ToList();
            return tabela;
        }



        public IEnumerable<Usuario> UsuarioPesquisar(Expression<Func<Usuario, bool>> filtro)
        {
            var saida = _Usuario.Find(filtro);
            return saida;
        }



        public string UsuarioPesquisarSenha(string pEmail)
        {
            string SenhaRetorno = "";
            var _usuarioSenha = _Usuario.Find(x => x.Email == pEmail.ToLower()).FirstOrDefault();
            if (_usuarioSenha != null)
            {
                return _usuarioSenha.SenhaCripto;
            }
            return SenhaRetorno;
        }

    }
}
