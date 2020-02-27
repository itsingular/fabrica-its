using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.IO;
using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Infra.Repository;
using ItsLaw.Infra;




namespace ItsLaw.Business
{
    public class ComarcaService : IComarca
    {
        private readonly ComarcaRepository  _repositorio = new ComarcaRepository();
        private readonly UsuarioRepository  _UsuarioID   = new UsuarioRepository();
        protected                ItsLawContext _contexto = new ItsLawContext();


        public void ComarcaAdd(Comarca itens)
        {
            _repositorio.Add(itens);
        }

        public Comarca ComarcaGetById(int id)
        {
            var saida = _repositorio.GetById(id);
            //-------------- Dados da Inclusao ----------------------------------------------- 31.12.2018
            Usuario UsuarioInc = new Usuario();
            UsuarioInc = _UsuarioID.GetById(saida.IdUsuarioInclusao);
            saida.UsuarioInclusaoNome = UsuarioInc.Nome;
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

        public IEnumerable<Comarca> ComarcaListagem(int pIDMaster)
        {
            //EGS 30.07.2018 - Incluindo nome dos usuarios de inclusao e manutencao FUNCIONANDO
            var tabela = (from ifs      in _contexto.Comarca 
                          join _UsuaInc in _contexto.Usuario       on ifs.IdUsuarioInclusao  equals _UsuaInc.IdUsuario 
                          join _UsuaAlt in _contexto.Usuario       on ifs.IdUsuarioAlteracao equals _UsuaAlt.IdUsuario into tm
                          from subUser  in tm.DefaultIfEmpty()
                          let UsuarioAlteracao = subUser.Nome
                          where ifs.Ativo.Equals(true) && ifs.IdMaster.Equals(pIDMaster)      //True e IDMaster
                          select new
                          {
                              IdMaster                = ifs.IdMaster,
                              IdComarca               = ifs.IdComarca,
                              Descricao               = ifs.Descricao,
                              Endereco                = ifs.Endereco,
                              Bairro                  = ifs.Bairro,
                              Cidade                  = ifs.Cidade,
                              Estado                  = ifs.Estado,
                              Telefone                = ifs.Telefone,
                              IdUsuarioInclusao       = ifs.IdUsuarioInclusao,
                              UsuarioInclusaoNome     = _UsuaInc.Nome.Substring(0, 16),
                              DtUsuarioInclusao       = ifs.DtUsuarioInclusao,
                              IdUsuarioAlteracao      = ifs.IdUsuarioAlteracao,
                              UsuarioAlteracaoNome    = UsuarioAlteracao.Substring(0, 16),
                              DtUsuarioAlteracao      = ifs.DtUsuarioAlteracao,
                              Ativo                   = ifs.Ativo
                          }).ToList().Select(x => new Comarca()
                          {
                              IdMaster                = x.IdMaster,
                              IdComarca               = x.IdComarca,
                              Descricao               = x.Descricao,
                              Endereco                = x.Endereco,
                              Bairro                  = x.Bairro,
                              Cidade                  = x.Cidade,
                              Estado                  = x.Estado,
                              Telefone                = x.Telefone,
                              IdUsuarioInclusao       = x.IdUsuarioInclusao,
                              UsuarioInclusaoNome     = x.UsuarioInclusaoNome,
                              DtUsuarioInclusao       = x.DtUsuarioInclusao,
                              IdUsuarioAlteracao      = x.IdUsuarioAlteracao,
                              UsuarioAlteracaoNome    = x.UsuarioAlteracaoNome,
                              DtUsuarioAlteracao      = x.DtUsuarioAlteracao,
                              Ativo                   = x.Ativo
                          }).ToList();

            return tabela;
        }

        public IEnumerable<Comarca> ComarcaPesquisar(Expression<Func<Comarca, bool>> filtro)
        {
            var saida = _repositorio.Find(filtro);
            return saida;
        }

        public void ComarcaUpdate(Comarca itens)
        {
            _repositorio.Update(itens);
        }


    }
}
