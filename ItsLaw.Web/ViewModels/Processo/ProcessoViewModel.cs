using ItsLaw.Entidades;
using ItsLaw.Funcoes.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;


namespace ItsLaw.Web.ViewModels
{

    public class ProcessoViewModel
    {
        public ProcessoViewModel()
        {

        }

        public ProcessoViewModel(Processo Itens)
        {
            // Read the file into the byte array.
            IdProcesso                  = Itens.IdProcesso;
            IdMaster                    = Itens.IdMaster;
            Codigo                      = Itens.Codigo;
            IdTipoAcao                  = Itens.IdTipoAcao;
            IdTipoJustica               = Itens.IdTipoJustica;
            IdTipoAreaDireito           = Itens.IdTipoAreaDireito;
            IdComarca                   = Itens.IdComarca;
            IdEmpresa                   = Itens.IdEmpresa;
            IdEscritorio                = Itens.IdEscritorio;
            IdEstado                    = Itens.IdEstado;
            Codigo                      = Itens.Codigo;
            CodInterno                  = Itens.CodInterno;                
            PastaFisica                 = Itens.PastaFisica;               
            IdStatusProcesso            = Itens.IdStatusProcesso;          
            ComarcaDescricao            = Itens.ComarcaDescricao;                                          
            TipoAcaoDescricao           = Itens.TipoAcaoDescricao;         
            TipoJusticaDescricao        = Itens.TipoJusticaDescricao;      
            TipoAreaDireitoDescricao    = Itens.TipoAreaDireitoDescricao;  
            EstadoDescricao             = Itens.EstadoDescricao;           
            EmpresaDescricao            = Itens.EmpresaDescricao;          
            EscritorioDescricao         = Itens.EscritorioDescricao;       
            StatusCodigo                = Itens.StatusCodigo;       
            lstProcessoAdvogado         = Itens.lstProcessoAdvogado;       
            lstProcessoDocumentos       = Itens.lstProcessoDocumentos;     
            lstProcessoHistorico        = Itens.lstProcessoHistorico;      
            lstProcessoParteContraria   = Itens.lstProcessoParteContraria; 
            lstProcessoReclamante       = Itens.lstProcessoReclamante;     
            lstProcessoTestemunha       = Itens.lstProcessoTestemunha;     
            IdUsuarioInclusao           = Itens.IdUsuarioInclusao;
            UsuarioInclusaoNome         = Itens.UsuarioInclusaoNome;
            DtUsuarioInclusao           = Itens.DtUsuarioInclusao;
            IdUsuarioAlteracao          = Itens.IdUsuarioAlteracao;
            UsuarioAlteracaoNome        = Itens.UsuarioAlteracaoNome;
            DtUsuarioAlteracao          = Itens.DtUsuarioAlteracao;
            Ativo                       = Itens.Ativo;       
        }

        public Processo ToDomain()
        {
            var Itens = new Processo();

            Itens.IdProcesso                = IdProcesso;
            Itens.IdMaster                  = IdMaster;
            Itens.Codigo                    = Codigo;
            Itens.IdTipoAcao                = IdTipoAcao;
            Itens.IdTipoJustica             = IdTipoJustica;
            Itens.IdTipoAreaDireito         = IdTipoAreaDireito;        
            Itens.IdComarca                 = IdComarca;                
            Itens.IdEmpresa                 = IdEmpresa;
            Itens.IdEscritorio              = IdEscritorio;             
            Itens.IdEstado                  = IdEstado;                 
            Itens.Codigo                    = Codigo;                   
            Itens.CodInterno                = CodInterno;               
            Itens.PastaFisica               = PastaFisica;              
            Itens.IdStatusProcesso          = IdStatusProcesso;         
            Itens.ComarcaDescricao          = ComarcaDescricao;                                        
            Itens.TipoAcaoDescricao         = TipoAcaoDescricao;        
            Itens.TipoJusticaDescricao      = TipoJusticaDescricao;     
            Itens.TipoAreaDireitoDescricao  = TipoAreaDireitoDescricao; 
            Itens.EstadoDescricao           = EstadoDescricao;          
            Itens.EmpresaDescricao          = EmpresaDescricao;         
            Itens.EscritorioDescricao       = EscritorioDescricao;
            Itens.StatusCodigo              = StatusCodigo;       
            Itens.lstProcessoAdvogado       = lstProcessoAdvogado;      
            Itens.lstProcessoDocumentos     = lstProcessoDocumentos;    
            Itens.lstProcessoHistorico      = lstProcessoHistorico;     
            Itens.lstProcessoParteContraria = lstProcessoParteContraria;
            Itens.lstProcessoReclamante     = lstProcessoReclamante;    
            Itens.lstProcessoTestemunha     = lstProcessoTestemunha;    
            Itens.IdUsuarioInclusao         = IdUsuarioInclusao;
            Itens.UsuarioInclusaoNome       = UsuarioInclusaoNome;
            Itens.DtUsuarioInclusao         = DtUsuarioInclusao;
            Itens.IdUsuarioAlteracao        = IdUsuarioAlteracao;
            Itens.UsuarioAlteracaoNome      = UsuarioAlteracaoNome;
            Itens.DtUsuarioAlteracao        = DtUsuarioAlteracao;
            Itens.Ativo                     = Ativo;
            return Itens;
        }


        public int       IdMaster                               { get; set; }
        public int       IdProcesso                             { get; set; }

        public int       IdTipoAcao                             { get; set; }
        [Required(ErrorMessage = "Informe o Tipo Ação do Processo", AllowEmptyStrings = false)]

        public int       IdTipoJustica                          { get; set; }
        [Required(ErrorMessage = "Informe o Tipo Justiça do Processo", AllowEmptyStrings = false)]

        public int       IdTipoAreaDireito                      { get; set; }
        [Required(ErrorMessage = "Informe a Área Direito do Processo", AllowEmptyStrings = false)]

        public int       IdComarca                              { get; set; }
        [Required(ErrorMessage = "Informe a Comarca do Processo", AllowEmptyStrings = false)]

        public int       IdEmpresa                              { get; set; }
        [Required(ErrorMessage = "Informe a Empresa do Processo", AllowEmptyStrings = false)]

        public int       IdEscritorio                           { get; set; }
        [Required(ErrorMessage = "Informe o Escritorio do Processo", AllowEmptyStrings = false)]

        public int       IdEstado                               { get; set; }
        [Required(ErrorMessage = "Informe a UF do Processo", AllowEmptyStrings = false)]

        public string Codigo { get; set; }
        [Display(Name = "Código do Processo")]
        [Required(ErrorMessage = "Informe o Código do Processo", AllowEmptyStrings = false)]

        public string    CodInterno                             { get; set; }
        [Display(Name = "Código interno")]

        public string    PastaFisica                            { get; set; }
        [Display(Name = "Pasta Física")]

        public int       IdStatusProcesso                       { get; set; }
        public string    ComarcaDescricao                       { get; set; }                                                      
        public string    TipoAcaoDescricao                      { get; set; }  
        public string    TipoJusticaDescricao                   { get; set; }  
        public string    TipoAreaDireitoDescricao               { get; set; }  
        public string    EstadoDescricao                        { get; set; }  
        public string    EmpresaDescricao                       { get; set; }
        public string    EscritorioDescricao                    { get; set; }
        public string    StatusCodigo                           { get; set; }
        public ProcessoAdvogado       lstProcessoAdvogado       { get; set; }
        public ProcessoDocumentos     lstProcessoDocumentos     { get; set; }
        public ProcessoHistorico      lstProcessoHistorico      { get; set; }
        public ProcessoPartecontraria lstProcessoParteContraria { get; set; }
        public ProcessoReclamante     lstProcessoReclamante     { get; set; }
        public ProcessoTestemunha     lstProcessoTestemunha     { get; set; }

        public int IdUsuarioInclusao                            { get; set; }
        [Display(Name = "Usuario Inclusão")]                    
        public string UsuarioInclusaoNome                       { get; set; }
        [Display(Name = "Data Inclusão")]                       
        public DateTime DtUsuarioInclusao                       { get; set; }
        public int? IdUsuarioAlteracao                          { get; set; }
        [Display(Name = "Usuario Alteração")]                   
        public string UsuarioAlteracaoNome                      { get; set; }
        [Display(Name = "Data Alteração")]                      
        public DateTime? DtUsuarioAlteracao                     { get; set; }
        [Display(Name = "Ativo")]                               
        public bool Ativo                                       { get; set; }

    }










    public class ProcessoFiltroViewModel
    {
        public ProcessoFiltroViewModel()
        {

        }

        public ProcessoFiltroViewModel(ProcessoFiltro Itens)
        {
            // Read the file into the byte array.
            FiltroIdProcesso            = Itens.FiltroIdProcesso;
            FiltroIdMaster              = Itens.FiltroIdMaster;
            FiltroCodigo                = Itens.FiltroCodigo;
            FiltroIdTipoAcao            = Itens.FiltroIdTipoAcao;
            FiltroIdTipoJustica         = Itens.FiltroIdTipoJustica;
            FiltroIdTipoAreaDireito     = Itens.FiltroIdTipoAreaDireito;
            FiltroIdComarca             = Itens.FiltroIdComarca;
            FiltroIdEmpresa             = Itens.FiltroIdEmpresa;
            FiltroIdEscritorio          = Itens.FiltroIdEscritorio;
            FiltroIdEstado              = Itens.FiltroIdEstado;
            FiltroCodigo                = Itens.FiltroCodigo;
            FiltroCodInterno            = Itens.FiltroCodInterno;
            FiltroPastaFisica           = Itens.FiltroPastaFisica;
            FiltroIdStatusProcesso      = Itens.FiltroIdStatusProcesso;
            FiltroIdUsuarioInclusao     = Itens.FiltroIdUsuarioInclusao;
            FiltroDtUsuarioInclusao     = Itens.FiltroDtUsuarioInclusao;
            FiltroIdUsuarioAlteracao    = Itens.FiltroIdUsuarioAlteracao;
            FiltroDtUsuarioAlteracao    = Itens.FiltroDtUsuarioAlteracao;
            FiltroAtivo                 = Itens.FiltroAtivo;       
            ListaProcessos              = Itens.ListaProcessos;
        }

        public ProcessoFiltro ToDomain()
        {
            var Itens = new ProcessoFiltro();

            Itens.FiltroIdProcesso          = FiltroIdProcesso;
            Itens.FiltroIdMaster            = FiltroIdMaster;
            Itens.FiltroCodigo              = FiltroCodigo;
            Itens.FiltroIdTipoAcao          = FiltroIdTipoAcao;
            Itens.FiltroIdTipoJustica       = FiltroIdTipoJustica;
            Itens.FiltroIdTipoAreaDireito   = FiltroIdTipoAreaDireito;        
            Itens.FiltroIdComarca           = FiltroIdComarca;                
            Itens.FiltroIdEmpresa           = FiltroIdEmpresa;
            Itens.FiltroIdEscritorio        = FiltroIdEscritorio;             
            Itens.FiltroIdEstado            = FiltroIdEstado;                 
            Itens.FiltroCodigo              = FiltroCodigo;                   
            Itens.FiltroCodInterno          = FiltroCodInterno;               
            Itens.FiltroPastaFisica         = FiltroPastaFisica;              
            Itens.FiltroIdStatusProcesso    = FiltroIdStatusProcesso;         
            Itens.FiltroIdUsuarioInclusao   = FiltroIdUsuarioInclusao;
            Itens.FiltroDtUsuarioInclusao   = FiltroDtUsuarioInclusao;
            Itens.FiltroIdUsuarioAlteracao  = FiltroIdUsuarioAlteracao;
            Itens.FiltroDtUsuarioAlteracao  = FiltroDtUsuarioAlteracao;
            Itens.FiltroAtivo               = FiltroAtivo;
            Itens.ListaProcessos            = ListaProcessos;
            return Itens;
        }


        public int       FiltroIdMaster                         { get; set; }
        public int       FiltroIdProcesso                       { get; set; }
        public int       FiltroIdTipoAcao                       { get; set; }
        public int       FiltroIdTipoJustica                    { get; set; }
        public int       FiltroIdTipoAreaDireito                { get; set; }
        public int       FiltroIdComarca                        { get; set; }
        public int       FiltroIdEmpresa                        { get; set; }
        public int       FiltroIdEscritorio                     { get; set; }
        public int       FiltroIdEstado                         { get; set; }
        public string    FiltroCodigo                           { get; set; }
        public string    FiltroCodInterno                       { get; set; }
        public string    FiltroPastaFisica                      { get; set; }
        public int       FiltroIdStatusProcesso                 { get; set; }
        public int       FiltroIdUsuarioInclusao                { get; set; }
        public DateTime  FiltroDtUsuarioInclusao                { get; set; }
        public int?      FiltroIdUsuarioAlteracao               { get; set; }
        public DateTime? FiltroDtUsuarioAlteracao               { get; set; }
        public bool      FiltroAtivo                            { get; set; }
        public List<Processo>  ListaProcessos                   { get; set; }
    }


}