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
    public class StatusProcessoService : IStatusProcesso
    {
        private readonly StatusProcessoRepository _repositorio = new StatusProcessoRepository();
        private readonly UsuarioRepository  _UsuarioID   = new UsuarioRepository();
        protected                ItsLawContext _contexto = new ItsLawContext();


        public void StatusProcessoAdd(StatusProcesso itens)
        {
            _repositorio.Add(itens);
        }

        public StatusProcesso StatusProcessoGetById(int id)
        {
            var saida = _repositorio.GetById(id);
            return saida;
            }


        public IEnumerable<StatusProcesso> StatusProcessoListagem(int pIDMaster)
        {
            //EGS 30.07.2018 - Incluindo nome dos usuarios de inclusao e manutencao FUNCIONANDO
            var tabela = (from ifs      in _contexto.StatusProcesso 
                          join _UsuaInc in _contexto.Usuario       on ifs.IdUsuarioInclusao  equals _UsuaInc.IdUsuario 
                          join _UsuaAlt in _contexto.Usuario       on ifs.IdUsuarioAlteracao equals _UsuaAlt.IdUsuario into tm
                          from subUser  in tm.DefaultIfEmpty()
                          let UsuarioAlteracao = subUser.Nome
                          where ifs.Ativo.Equals(true) && ifs.IdMaster.Equals(pIDMaster)      //True e IDMaster
                          select new
                          {
                              IdMaster                = ifs.IdMaster,
                              IdStatusProcesso        = ifs.IdStatusProcesso,
                              Codigo                  = ifs.Codigo,
                              Descricao               = ifs.Descricao,
                              CorGrid                 = ifs.CorGrid,
                              IdUsuarioInclusao       = ifs.IdUsuarioInclusao,
                              UsuarioInclusaoNome     = _UsuaInc.Nome.Substring(0, 16),
                              DtUsuarioInclusao       = ifs.DtUsuarioInclusao,
                              IdUsuarioAlteracao      = ifs.IdUsuarioAlteracao,
                              UsuarioAlteracaoNome    = UsuarioAlteracao.Substring(0, 16),
                              DtUsuarioAlteracao      = ifs.DtUsuarioAlteracao,
                              Ativo                   = ifs.Ativo
                          }).ToList().Select(x => new StatusProcesso()
                          {
                              IdMaster                = x.IdMaster,
                              IdStatusProcesso        = x.IdStatusProcesso,
                              Codigo                  = x.Codigo,
                              Descricao               = x.Descricao,
                              CorGrid                 = x.CorGrid,
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


        public IEnumerable<StatusProcesso> StatusProcessoPesquisar(Expression<Func<StatusProcesso, bool>> filtro)
        {
            var saida = _repositorio.Find(filtro);
            return saida;
        }


        public void StatusProcessoUpdate(StatusProcesso itens)
        {
            _repositorio.Update(itens);
        }

    }
}
