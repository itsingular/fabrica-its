using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Infra.Repository;
using ItsLaw.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;




namespace ItsLaw.Business
{
    public class ReclamanteService : IReclamante
    {
        private readonly ReclamanteRepository _repositorio = new ReclamanteRepository();
        private readonly UsuarioRepository        _UsuarioID   = new UsuarioRepository();
        protected ItsLawContext                   _contexto    = new ItsLawContext();

        public void Dispose()
        {
            _contexto.Dispose();
            _repositorio.Dispose();
        }

        public void ReclamanteAdd(Reclamante itens)
        {
            _repositorio.Add(itens);
        }

        public Reclamante ReclamanteGetById(int id)
        {
            var saida = _repositorio.GetById(id);
            return saida;
        }

        public IEnumerable<Reclamante> ReclamanteListagem(int pIDMaster)
        {
            //EGS 30.07.2018 - Incluindo nome dos usuarios de inclusao e manutencao e FUNCIONANDO !!
            var tabela = (from ifs      in _contexto.Reclamante 
                          join _UsuaInc in _contexto.Usuario       on ifs.IdUsuarioInclusao  equals _UsuaInc.IdUsuario 
                          join _UsuaAlt in _contexto.Usuario       on ifs.IdUsuarioAlteracao equals _UsuaAlt.IdUsuario into tm
                          from subUser  in tm.DefaultIfEmpty()
                          let UsuarioAlteracao = subUser.Nome
                          where ifs.Ativo.Equals(true) && ifs.IdMaster.Equals(pIDMaster)      //True e IDMaster
                          select new
                          {
                              IdMaster                = ifs.IdMaster,
                              IdReclamante            = ifs.IdReclamante,
                              CpfCnpj                 = ifs.CpfCnpj,
                              Nome                    = ifs.Nome,
                              Cep                     = ifs.Cep,
                              Logradouro              = ifs.Logradouro,
                              Numero                  = ifs.Numero,
                              Complemento             = ifs.Complemento,
                              Bairro                  = ifs.Bairro,
                              Cidade                  = ifs.Cidade,
                              IDEstado                = ifs.IDEstado,
                              Email                   = ifs.Email,
                              Telefone                = ifs.Telefone,
                              Celular                 = ifs.Celular,
                              IDSexo                  = ifs.IDSexo,
                              DataNascimento          = ifs.DataNascimento,
                              IDEstadoCivil           = ifs.IDEstadoCivil,
                              Profissao               = ifs.Profissao,
                              IdUsuarioInclusao       = ifs.IdUsuarioInclusao,
                              UsuarioInclusaoNome     = _UsuaInc.Nome.Substring(0, 16),
                              DtUsuarioInclusao       = ifs.DtUsuarioInclusao,
                              IdUsuarioAlteracao      = ifs.IdUsuarioAlteracao,
                              UsuarioAlteracaoNome    = UsuarioAlteracao.Substring(0, 16),
                              DtUsuarioAlteracao      = ifs.DtUsuarioAlteracao,
                              Ativo                   = ifs.Ativo
                          }).ToList().Select(x => new Reclamante()
                          {
                              IdMaster                = x.IdMaster,
                              IdReclamante            = x.IdReclamante,
                              CpfCnpj                 = x.CpfCnpj,
                              Nome                    = x.Nome,
                              Cep                     = x.Cep,
                              Logradouro              = x.Logradouro,
                              Numero                  = x.Numero,
                              Complemento             = x.Complemento,
                              Bairro                  = x.Bairro,
                              Cidade                  = x.Cidade,
                              IDEstado                = x.IDEstado,
                              Email                   = x.Email,
                              Telefone                = x.Telefone,
                              Celular                 = x.Celular,
                              IDSexo                  = x.IDSexo,
                              DataNascimento          = x.DataNascimento,
                              IDEstadoCivil           = x.IDEstadoCivil,
                              Profissao               = x.Profissao,
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

        public IEnumerable<Reclamante> ReclamantePesquisar(Expression<Func<Reclamante, bool>> filtro)
        {
            var saida = _repositorio.Find(filtro);
            return saida;
        }
        
        public void ReclamanteUpdate(Reclamante itens)
        {
            _repositorio.Update(itens);
        }
    }
}
