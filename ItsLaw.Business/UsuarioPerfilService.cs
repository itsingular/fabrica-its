using ItsLaw.DAO.Conexao;
using ItsLaw.DAO.SQL;
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
    public class UsuarioPerfilService : IUsuarioPerfil
    {
        private readonly UsuarioPerfilRepository        _repositorio              = new UsuarioPerfilRepository();
        private readonly UsuarioRepository              _UsuarioID                = new UsuarioRepository();
        private readonly UsuarioPathRepository          _PathRepositorio          = new UsuarioPathRepository();
        private readonly UsuarioPerfilDireitoRepository _PerfilDireitoRepositorio = new UsuarioPerfilDireitoRepository();
        protected ItsLawContext _contexto = new ItsLawContext();

        public void Dispose()
        {
            _contexto.Dispose();
            _repositorio.Dispose();
        }       

        public void UsuarioPerfilAdd(UsuarioPerfil itens)
        {
            _repositorio.Add(itens);
        }

        public void UsuarioPerfilUpdate(UsuarioPerfil itens)
        {
            _repositorio.Update(itens);
        }

        public IEnumerable<UsuarioPerfil> UsuarioPerfilPesquisar(Expression<Func<UsuarioPerfil, bool>> filtro)
        {
            var saida = _repositorio.Find(filtro);
            return saida;
        }




        public UsuarioPerfil UsuarioPerfilGetById(int id)
        {
            Usuario UsuarioInc = new Usuario();
            var saida = _repositorio.GetById(id);
            //---------------------------------------------------------- Pega Nome Usuario Inclusao e Manutencao
            UsuarioInc = _UsuarioID.GetById(saida.IdUsuarioInclusao);
            saida.UsuarioInclusaoNome = UsuarioInc.Nome;
            if (saida.IdUsuarioAlteracao != null)
            {
                Usuario UsuarioMan = new Usuario();
                UsuarioMan = _UsuarioID.GetById(Convert.ToInt32(saida.IdUsuarioAlteracao));
                saida.UsuarioAlteracaoNome = UsuarioMan.Nome;
            }
            //---------------------------------------------------------- Pega Nome Usuario Inclusao e Manutencao
            return saida;
        }




        public IEnumerable<UsuarioPerfil> UsuarioPerfilListagem(int pIDMaster)
        {
            //EGS 30.04.2018 - Incluindo nome dos usuarios de inclusao e manutencao
            var tabela = (from ifs      in _contexto.UsuarioPerfil 
                          join _UsuaInc in _contexto.Usuario       on ifs.IdUsuarioInclusao  equals _UsuaInc.IdUsuario 
                          join _UsuaAlt in _contexto.Usuario       on ifs.IdUsuarioAlteracao equals _UsuaAlt.IdUsuario into tm
                          from subUser  in tm.DefaultIfEmpty()
                          let UsuarioAlteracao = subUser.Nome
                          where ifs.Ativo.Equals(true) && ifs.IdMaster.Equals(pIDMaster)      //True e IDMaster
                          select new
                          {
                              IdMaster                = ifs.IdMaster,
                              IdUsuarioPerfil         = ifs.IdUsuarioPerfil,
                              Descricao               = ifs.Descricao,
                              IdUsuarioInclusao       = ifs.IdUsuarioInclusao,
                              UsuarioInclusaoNome     = _UsuaInc.Nome.Substring(0, 16),
                              DtUsuarioInclusao       = ifs.DtUsuarioInclusao,
                              IdUsuarioAlteracao      = ifs.IdUsuarioAlteracao,
                              UsuarioAlteracaoNome    = UsuarioAlteracao.Substring(0, 16),
                              DtUsuarioAlteracao     = ifs.DtUsuarioAlteracao,
                              Ativo                   = ifs.Ativo
                          }).ToList().Select(x => new UsuarioPerfil()
                          {
                              IdMaster                = x.IdMaster,
                              IdUsuarioPerfil         = x.IdUsuarioPerfil,
                              Descricao               = x.Descricao,
                              IdUsuarioInclusao       = x.IdUsuarioInclusao,
                              UsuarioInclusaoNome     = x.UsuarioInclusaoNome,
                              DtUsuarioInclusao       = x.DtUsuarioInclusao,
                              IdUsuarioAlteracao      = x.IdUsuarioAlteracao,
                              UsuarioAlteracaoNome    = x.UsuarioAlteracaoNome,
                              DtUsuarioAlteracao      = x.DtUsuarioAlteracao,
                              Ativo                   = x.Ativo,
                              AcessoDireitos =  (from acessos in _contexto.UsuarioPerfilDireito
                                                 join _telas  in _contexto.UsuarioPath on acessos.IdUsuarioPath equals _telas.IdUsuarioPath
                                                 where acessos.IdUsuarioPerfil.Equals(x.IdUsuarioPerfil)
                                                 select new
                                                {
                                                    IdMaster               = acessos.IdMaster,
                                                    idUsuarioPerfilDireito = acessos.IdUsuarioPerfilDireito,
                                                    IdUsuarioPerfil        = acessos.IdUsuarioPerfil ,
                                                    IdUsuarioPath          = acessos.IdUsuarioPath   ,
                                                    DescricaoAcesso        = _telas.Descricao,
                                                    AcaoVisualizar         = (acessos.AcaoVisualizar   == null ? false : acessos.AcaoVisualizar),
                                                    AcaoEditar             = (acessos.AcaoEditar       == null ? false : acessos.AcaoEditar    ),
                                                    AcaoIncluir            = (acessos.AcaoIncluir      == null ? false : acessos.AcaoIncluir   ),
                                                    AcaoExcluir            = (acessos.AcaoExcluir      == null ? false : acessos.AcaoExcluir   ),
                                                    AcaoImportar           = (acessos.AcaoImportar     == null ? false : acessos.AcaoImportar  ),
                                                    AcaoImprimir           = (acessos.AcaoImprimir     == null ? false : acessos.AcaoImprimir  ), 
                                                }).ToList().Select(y => new UsuarioPerfilDireito()
                                                            {
                                                             IdMaster               = y.IdMaster,
                                                             IdUsuarioPerfilDireito = y.idUsuarioPerfilDireito,
                                                             IdUsuarioPerfil        = y.IdUsuarioPerfil ,
                                                             IdUsuarioPath          = y.IdUsuarioPath   ,
                                                             DescricaoAcesso        = y.DescricaoAcesso ,
                                                             AcaoVisualizar         = y.AcaoVisualizar  ,
                                                             AcaoEditar             = y.AcaoEditar      ,
                                                             AcaoIncluir            = y.AcaoIncluir     ,
                                                             AcaoExcluir            = y.AcaoExcluir     ,
                                                             AcaoImportar           = y.AcaoImportar    ,
                                                             AcaoImprimir           = y.AcaoImprimir

                                                }).ToList()
                          }).ToList();

            return tabela;
        }





        public bool PerfilDireitoAutoriza(string path, string pAcao, int idPerfil)
        {
            bool bRetorno = false;

            if (idPerfil != 0)   //EGS 30.02.2018 - Se usuario não informado, não permite acesso
            {
                var caminho = path.Split('/');
                string Controler = Controler = caminho[1].ToString();
                if (caminho.Length >= 3) { Controler = caminho[1].ToString(); }


                //EGS Localiza a pagina cadastrada, se não existir, mostra como negado
                var LocIdPath = _PathRepositorio.Find(x => x.DsController == Controler).FirstOrDefault();
                if (LocIdPath != null)
                {
                    bRetorno = true;

                    //EGS Localiza a pagina cadastrada, se não existir, mostra como negado
                    var LocIdDireito = _PerfilDireitoRepositorio.Find(x => x.IdUsuarioPerfil == idPerfil && x.IdUsuarioPath == LocIdPath.IdUsuarioPath).FirstOrDefault();
                    if (LocIdDireito != null)
                    {
                        if ((pAcao == "Index"  ) && (LocIdDireito.AcaoVisualizar == true)) { bRetorno = true; }
                        if ((pAcao == "Abrir"  ) && (LocIdDireito.AcaoEditar     == true)) { bRetorno = true; }
                        if ((pAcao == "Incluir") && (LocIdDireito.AcaoIncluir    == true)) { bRetorno = true; }
                        if ((pAcao == "Excluir") && (LocIdDireito.AcaoExcluir    == true)) { bRetorno = true; } 
                    }
                }
            }
            return bRetorno;
        }


        public List<UsuarioPerfilDireito> RetornaDireitosDoUsuario(int id)
        {
            var DAO   = new UsuarioPerfilDireitoDAO();
            var saida = DAO.Select(id);
            return saida;
        }

        //EGS 30.08.2018 - Devolve todos os direitos em branco...
        public bool AddAcessoDireitoBranco(int pIDMaster, int pIDUsuarioInc)
        {
            //EGS Listando todos os acessos possiveis, mas devolvendo tudo negado, para gravado
            var resultado = (from r in _contexto.UsuarioPerfil orderby r.IdUsuarioPerfil descending select r).First();

            var tabAcessoBranco = _contexto.UsuarioPath.Where(s => s.Ativo.Equals(true));

            if (tabAcessoBranco == null)
            {
                return false;
            } else {

                int pIDUsuarioPerfil = resultado.IdUsuarioPerfil;  //EGS 30.08.2018 Pega o ULTIMO ID do Perfil adicionado
                foreach (var item in tabAcessoBranco)
                {
                    UsuarioPerfilDireito registro = new UsuarioPerfilDireito();
                    registro.IdMaster          = pIDMaster;
                    registro.IdUsuarioPerfil   = pIDUsuarioPerfil;
                    registro.IdUsuarioPath     = item.IdUsuarioPath;
                    registro.AcaoVisualizar    = false;
                    registro.AcaoEditar        = false;
                    registro.AcaoIncluir       = false;
                    registro.AcaoExcluir       = false;
                    registro.AcaoImportar      = false;
                    registro.AcaoImprimir      = false;
                    registro.IdUsuarioInclusao = pIDUsuarioInc;
                    registro.DtUsuarioInclusao = DateTime.Now;
                    _PerfilDireitoRepositorio.Add(registro);
                }
            }
            return true;
        }
    }
}
