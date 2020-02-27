using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{    
    public partial class Processo
    {
        public int       IdMaster                               { get; set; }
        public int       IdProcesso                             { get; set; }
        public int       IdTipoAcao                             { get; set; }
        public int       IdTipoJustica                          { get; set; }
        public int       IdTipoAreaDireito                      { get; set; }
        public int       IdComarca                              { get; set; }
        public int       IdEmpresa                              { get; set; }
        public int       IdEscritorio                           { get; set; }
        public int       IdEstado                               { get; set; }
        public string    Codigo                                 { get; set; }
        public string    CodInterno                             { get; set; }
        public string    PastaFisica                            { get; set; }
        public int       IdStatusProcesso                       { get; set; }
        public int       IdUsuarioInclusao                      { get; set; }
        public DateTime  DtUsuarioInclusao                      { get; set; }
        public int?      IdUsuarioAlteracao                     { get; set; }
        public DateTime? DtUsuarioAlteracao                     { get; set; }
        public bool      Ativo                                  { get; set; }
                                                                
        [NotMapped]                                             
        public string    ComarcaDescricao                       { get; set; }                                                      
        [NotMapped]                                             
        public string    TipoAcaoDescricao                      { get; set; }  
        [NotMapped]                                             
        public string    TipoJusticaDescricao                   { get; set; }  
        [NotMapped]                                             
        public string    TipoAreaDireitoDescricao               { get; set; }  
        [NotMapped]                                             
        public string    EstadoDescricao                        { get; set; }  
        [NotMapped]                                             
        public string    EmpresaDescricao                       { get; set; }
        [NotMapped]                                             
        public string    EscritorioDescricao                    { get; set; }
        [NotMapped]                                             
        public string    StatusCodigo                           { get; set; }
        [NotMapped]                                             
        public ProcessoAdvogado   lstProcessoAdvogado           { get; set; }
        [NotMapped]                                             
        public ProcessoDocumentos lstProcessoDocumentos         { get; set; }
        [NotMapped]                                             
        public ProcessoHistorico  lstProcessoHistorico          { get; set; }
        [NotMapped]                                 
        public ProcessoPartecontraria lstProcessoParteContraria { get; set; }
        [NotMapped]                                             
        public ProcessoReclamante     lstProcessoReclamante     { get; set; }
        [NotMapped]                                 
        public ProcessoTestemunha     lstProcessoTestemunha     { get; set; }
        [NotMapped]                                 
        public string    UsuarioInclusaoNome                    { get; set; }  
        [NotMapped]                                             
        public string    UsuarioAlteracaoNome                   { get; set; }

        public Processo()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }












    public partial class ProcessoFiltro
    {
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

        public ProcessoFiltro()
        {
            InitializePartial();
        }
        partial void InitializePartial();
    }
}

