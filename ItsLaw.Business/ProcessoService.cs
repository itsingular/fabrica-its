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
    public class ProcessoService : IProcesso
    {
        private readonly ProcessoRepository _repositorio = new ProcessoRepository();
        private readonly IUsuario           _Usuario     = new UsuarioService();
        private readonly UsuarioRepository  _UsuarioID   = new UsuarioRepository();
        protected                ItsLawContext _contexto = new ItsLawContext();


        public void ProcessoAdd(Processo itens)
        {
            _repositorio.Add(itens);
        }

        public Processo ProcessoGetById(int id)
        {
            var saida = _repositorio.GetById(id);
            return saida;
        }


        public IEnumerable<Processo> ProcessoListagem(ProcessoFiltro ItemFiltro)
        {
            if (ItemFiltro.FiltroIdMaster == 0) { ItemFiltro.FiltroIdMaster = 1; }
            DateTime sDtUlProcesso = (DateTime.Now).AddMonths(-6);
            //EGS 30.07.2018 - Incluindo nome dos usuarios de inclusao e manutencao FUNCIONANDO
            var tabela = (from ifs      in _contexto.Processo 
                          join _TipAcao in _contexto.TipoAcao             on ifs.IdTipoAcao         equals _TipAcao.IdTipoAcao
                          join _TipJust in _contexto.TipoJustica          on ifs.IdTipoJustica      equals _TipJust.IdTipoJustica
                          join _TipArea in _contexto.TipoAreaDireito      on ifs.IdTipoAreaDireito  equals _TipArea.IdTipoAreaDireito
                          join _Comarca in _contexto.Comarca              on ifs.IdComarca          equals _Comarca.IdComarca
                          join _Estado  in _contexto.TabAuxiliar          on ifs.IdEstado           equals _Estado.IdTabAuxiliar
                          join _Empresa in _contexto.Empresa              on ifs.IdEmpresa          equals _Empresa.IdEmpresa
                          join _Escrito in _contexto.Escritorio           on ifs.IdEscritorio       equals _Escrito.IdEscritorio
                          join _Status  in _contexto.StatusProcesso       on ifs.IdStatusProcesso   equals _Status.IdStatusProcesso
                          join _UsuaInc in _contexto.Usuario              on ifs.IdUsuarioInclusao  equals _UsuaInc.IdUsuario 
                          join _UsuaAlt in _contexto.Usuario              on ifs.IdUsuarioAlteracao equals _UsuaAlt.IdUsuario into tm
                          from subUser  in tm.DefaultIfEmpty() let UsuarioAlteracao = subUser.Nome
                          where ifs.Ativo.Equals(true) && ifs.IdMaster.Equals(ItemFiltro.FiltroIdMaster)      //True e IDMaster
                           && (((ItemFiltro.FiltroIdTipoAcao        == 0) || (ifs.IdTipoAcao.Equals        (ItemFiltro.FiltroIdTipoAcao       )))
                           &&  ((ItemFiltro.FiltroIdTipoAreaDireito == 0) || (ifs.IdTipoAreaDireito.Equals (ItemFiltro.FiltroIdTipoAreaDireito)))
                           &&  ((ItemFiltro.FiltroIdTipoJustica     == 0) || (ifs.IdTipoJustica.Equals     (ItemFiltro.FiltroIdTipoJustica    )))
                           &&  ((ItemFiltro.FiltroIdComarca         == 0) || (ifs.IdComarca.Equals         (ItemFiltro.FiltroIdComarca        )))
                           &&  ((ItemFiltro.FiltroIdEmpresa         == 0) || (ifs.IdEmpresa.Equals         (ItemFiltro.FiltroIdEmpresa        )))
                           &&  ((ItemFiltro.FiltroIdEscritorio      == 0) || (ifs.IdEscritorio.Equals      (ItemFiltro.FiltroIdEscritorio     )))
                           &&  ((ItemFiltro.FiltroIdEstado          == 0) || (ifs.IdEstado.Equals          (ItemFiltro.FiltroIdEstado         )))
                           &&  ((ItemFiltro.FiltroIdStatusProcesso  == 0) || (ifs.IdStatusProcesso.Equals  (ItemFiltro.FiltroIdStatusProcesso ))))

                          //&& (ifs.DtUsuarioInclusao >= sDtUlProcesso)
                          orderby ifs.IdProcesso descending
                          select new
                          {
                              IdMaster                     = ifs.IdMaster,
                              IdProcesso                   = ifs.IdProcesso,
                              Codigo                       = ifs.Codigo,
                              CodInterno                   = ifs.CodInterno,
                              PastaFisica                  = ifs.PastaFisica,
                              TipoAcaoDescricao            = _TipAcao.Descricao.Substring(0,15),
                              TipoJusticaDescricao         = _TipJust.Descricao.Substring(0,15),
                              TipoAreaDireitoDescricao     = _TipArea.Descricao.Substring(0,15),
                              ComarcaDescricao             = _Comarca.Descricao.Substring(0,15),
                              EstadoDescricao              = _Estado.Codigo,
                              EmpresaDescricao             = _Empresa.Fantasia,
                              EscritorioDescricao          = _Escrito.Fantasia,
                              StatusCodigo                 = _Status.Codigo,
                              IdUsuarioInclusao            = ifs.IdUsuarioInclusao,
                              UsuarioInclusaoNome          = _UsuaInc.Nome.Substring(0, 16),
                              DtUsuarioInclusao            = ifs.DtUsuarioInclusao,
                              IdUsuarioAlteracao           = ifs.IdUsuarioAlteracao,
                              UsuarioAlteracaoNome         = UsuarioAlteracao.Substring(0, 16),
                              DtUsuarioAlteracao           = ifs.DtUsuarioAlteracao,
                              Ativo                        = ifs.Ativo
                          }).ToList().Select(x => new Processo()
                          {
                              IdMaster                     = x.IdMaster,
                              IdProcesso                   = x.IdProcesso,
                              Codigo                       = x.Codigo,
                              CodInterno                   = x.CodInterno,
                              PastaFisica                  = x.PastaFisica,
                              TipoAcaoDescricao            = x.TipoAcaoDescricao,
                              TipoJusticaDescricao         = x.TipoJusticaDescricao,
                              TipoAreaDireitoDescricao     = x.TipoAreaDireitoDescricao,
                              ComarcaDescricao             = x.ComarcaDescricao,
                              EstadoDescricao              = x.EstadoDescricao,
                              EmpresaDescricao             = x.EmpresaDescricao,
                              EscritorioDescricao          = x.EscritorioDescricao,
                              StatusCodigo                 = x.StatusCodigo,
                              IdUsuarioInclusao            = x.IdUsuarioInclusao,
                              UsuarioInclusaoNome          = x.UsuarioInclusaoNome,
                              DtUsuarioInclusao            = x.DtUsuarioInclusao,
                              IdUsuarioAlteracao           = x.IdUsuarioAlteracao,
                              UsuarioAlteracaoNome         = x.UsuarioAlteracaoNome,
                              DtUsuarioAlteracao           = x.DtUsuarioAlteracao,
                              Ativo                        = x.Ativo
                          }).ToList();

            return tabela;
        }


        public IEnumerable<Processo> ProcessoPesquisar(Expression<Func<Processo, bool>> filtro)
        {
            var saida = _repositorio.Find(filtro);
            return saida;
        }


        public void ProcessoUpdate(Processo itens)
        {
            _repositorio.Update(itens);
        }



        //EGS 30.11.2018 - Dados do DashBoard, qtde de processos, estas coisas
        public DashBoard ProcessoDashBoard(int pIDUsuario)
        {
            DashBoard iDashBoard = new DashBoard();

            Usuario tabUsuario = _Usuario.UsuarioGetById(pIDUsuario);
            if (tabUsuario != null)
            {
                DateTime sDtUlProcesso       = (DateTime.Now).AddMonths(-6);
                iDashBoard.IdMaster          = tabUsuario.IdMaster;
                iDashBoard.IdUsuarioLogado   = tabUsuario.IdUsuario;
                iDashBoard.UsuarioLogadoNome = tabUsuario.Nome;
                iDashBoard.QtdeProcessos     = _contexto.Processo.Count();
                iDashBoard.QtdeProcAberto    = (from p in _contexto.Processo where (p.IdMaster.Equals(tabUsuario.IdMaster)) && (p.Ativo.Equals(true)) && (p.IdStatusProcesso.Equals(1)) select p).Count();
                iDashBoard.QtdeProcPendente  = (from p in _contexto.Processo where (p.IdMaster.Equals(tabUsuario.IdMaster)) && (p.Ativo.Equals(true)) && (p.IdStatusProcesso.Equals(2)) select p).Count();
            }
            return iDashBoard;
        }

    }
}
