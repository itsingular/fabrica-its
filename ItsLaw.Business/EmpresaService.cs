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
    public class EmpresaService : IEmpresa
    {
        private readonly EmpresaRepository  _repositorio = new EmpresaRepository();
        private readonly UsuarioRepository _UsuarioID   = new UsuarioRepository();
        protected ItsLawContext               _contexto = new ItsLawContext();

        public void Dispose()
        {
            _contexto.Dispose();
            _repositorio.Dispose();
        }

        public void EmpresaAdd(Empresa itens)
        {
            _repositorio.Add(itens);
        }

        public Empresa EmpresaGetById(int id)
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

        public IEnumerable<Empresa> EmpresaListagem(int pIDMaster)
        {
            //EGS 30.07.2018 - Incluindo nome dos usuarios de inclusao e manutencao e FUNCIONANDO !!
            var tabela = (from ifs      in _contexto.Empresa 
                            join _UsuaInc in _contexto.Usuario       on ifs.IdUsuarioInclusao  equals _UsuaInc.IdUsuario 
                            join _UsuaAlt in _contexto.Usuario       on ifs.IdUsuarioAlteracao equals _UsuaAlt.IdUsuario into tm
                            from subUser  in tm.DefaultIfEmpty()
                            let UsuarioAlteracao = subUser.Nome
                            where ifs.Ativo.Equals(true) && ifs.IdMaster.Equals(pIDMaster)      //True e IDMaster
                            select new
                            {
                                IdMaster                = ifs.IdMaster,
                                IdEmpresa               = ifs.IdEmpresa,
                                CpfCnpj                 = ifs.CpfCnpj,              
                                Fantasia                = ifs.Fantasia,          
                                Nome                    = ifs.Nome,              
                                Cep                     = ifs.Cep,               
                                Logradouro              = ifs.Logradouro,        
                                Numero                  = ifs.Numero,            
                                Complemento             = ifs.Complemento,       
                                Bairro                  = ifs.Bairro,            
                                Cidade                  = ifs.Cidade,
                                IDEstado                = ifs.IDEstado,                
                                WebSite                 = ifs.WebSite,           
                                EmailPrincipal          = ifs.EmailPrincipal,    
                                EmailContato            = ifs.EmailContato,      
                                Telefone                = ifs.Telefone,          
                                Celular                 = ifs.Celular,           
                                Contato                 = ifs.Contato,           
                                CNAE                    = ifs.CNAE,
                                Logotipo                = ifs.Logotipo,
                                InscricaoEstadual       = ifs.InscricaoEstadual, 
                                InscricaoMunicipal      = ifs.InscricaoMunicipal,
                                IdUsuarioInclusao       = ifs.IdUsuarioInclusao,
                                UsuarioInclusaoNome     = _UsuaInc.Nome.Substring(0, 16),
                                DtUsuarioInclusao       = ifs.DtUsuarioInclusao,
                                IdUsuarioAlteracao      = ifs.IdUsuarioAlteracao,
                                UsuarioAlteracaoNome    = UsuarioAlteracao.Substring(0, 16),
                                DtUsuarioAlteracao      = ifs.DtUsuarioAlteracao,
                                Ativo                   = ifs.Ativo
                            }).ToList().Select(x => new Empresa()
                            {
                                IdMaster                = x.IdMaster,
                                IdEmpresa               = x.IdEmpresa,
                                CpfCnpj                 = x.CpfCnpj,              
                                Fantasia                = x.Fantasia,          
                                Nome                    = x.Nome,              
                                Cep                     = x.Cep,               
                                Logradouro              = x.Logradouro,        
                                Numero                  = x.Numero,            
                                Complemento             = x.Complemento,       
                                Bairro                  = x.Bairro,            
                                Cidade                  = x.Cidade,            
                                IDEstado                = x.IDEstado,                
                                WebSite                 = x.WebSite,           
                                EmailPrincipal          = x.EmailPrincipal,    
                                EmailContato            = x.EmailContato,      
                                Telefone                = x.Telefone,          
                                Celular                 = x.Celular,           
                                Contato                 = x.Contato,           
                                CNAE                    = x.CNAE,              
                                Logotipo                = x.Logotipo,
                                InscricaoEstadual       = x.InscricaoEstadual, 
                                InscricaoMunicipal      = x.InscricaoMunicipal,
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

        public IEnumerable<Empresa> EmpresaPesquisar(Expression<Func<Empresa, bool>> filtro)
        {
            var saida = _repositorio.Find(filtro);
            return saida;
        }
        
        public void EmpresaUpdate(Empresa itens)
        {
            _repositorio.Update(itens);
        }


    }
}
