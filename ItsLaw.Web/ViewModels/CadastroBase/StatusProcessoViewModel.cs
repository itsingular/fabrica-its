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

    public class StatusProcessoViewModel
    {
        public StatusProcessoViewModel()
        {

        }

        public StatusProcessoViewModel(StatusProcesso Itens)
        {
            // Read the file into the byte array.
            IdStatusProcesso      = Itens.IdStatusProcesso;
            IdMaster              = Itens.IdMaster;
            Codigo                = Itens.Codigo;
            Descricao             = Itens.Descricao;
            CorGrid               = Itens.CorGrid;
            IdUsuarioInclusao     = Itens.IdUsuarioInclusao;
            UsuarioInclusaoNome   = Itens.UsuarioInclusaoNome;
            DtUsuarioInclusao     = Itens.DtUsuarioInclusao;
            IdUsuarioAlteracao    = Itens.IdUsuarioAlteracao;
            UsuarioAlteracaoNome  = Itens.UsuarioAlteracaoNome;
            DtUsuarioAlteracao    = Itens.DtUsuarioAlteracao;
            Ativo                 = Itens.Ativo;                                  
        }

        public StatusProcesso ToDomain()
        {
            var Itens = new StatusProcesso();

            Itens.IdStatusProcesso      = IdStatusProcesso;
            Itens.IdMaster              = IdMaster;
            Itens.Codigo                = Codigo;
            Itens.Descricao             = Descricao;
            Itens.CorGrid               = CorGrid;
            Itens.IdUsuarioInclusao     = IdUsuarioInclusao;
            Itens.UsuarioInclusaoNome   = UsuarioInclusaoNome;
            Itens.DtUsuarioInclusao     = DtUsuarioInclusao;
            Itens.IdUsuarioAlteracao    = IdUsuarioAlteracao;
            Itens.UsuarioAlteracaoNome  = UsuarioAlteracaoNome;
            Itens.DtUsuarioAlteracao    = DtUsuarioAlteracao;
            Itens.Ativo                 = Ativo;
            return Itens;

        }



        public int IdMaster                      { get; set; }
        public int IdStatusProcesso              { get; set; }
                                                
        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "Informe o Codigo do Status", AllowEmptyStrings = false)]
        public string Codigo                     { get; set; }
                                                
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a Descrição do Status", AllowEmptyStrings = false)]
        public string Descricao                  { get; set; }
                                                
        [Display(Name = "Cor no Grid")]         
        public string CorGrid                    { get; set; }
                                                
        public int IdUsuarioInclusao             { get; set; }
        [Display(Name = "Usuario Inclusão")]    
        public string UsuarioInclusaoNome        { get; set; }
        [Display(Name = "Data Inclusão")]       
        public DateTime DtUsuarioInclusao        { get; set; }
        public int? IdUsuarioAlteracao           { get; set; }
        [Display(Name = "Usuario Alteração")]   
        public string UsuarioAlteracaoNome       { get; set; }
        [Display(Name = "Data Alteração")]      
        public DateTime? DtUsuarioAlteracao      { get; set; }
        [Display(Name = "Ativo")]               
        public bool Ativo                        { get; set; }
    }



}