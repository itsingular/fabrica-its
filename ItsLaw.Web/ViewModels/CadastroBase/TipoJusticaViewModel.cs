using ItsLaw.Entidades;
using ItsLaw.Funcoes.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;




namespace ItsLaw.Web.ViewModels
{

    public class TipoJusticaViewModel
    {
        public TipoJusticaViewModel()
        {

        }

        public TipoJusticaViewModel(TipoJustica Itens)
        {
            IdTipoJustica         = Itens.IdTipoJustica;
            IdMaster              = Itens.IdMaster;
            Descricao             = Itens.Descricao;
            IdUsuarioInclusao     = Itens.IdUsuarioInclusao;
            DtUsuarioInclusao     = Itens.DtUsuarioInclusao;
            UsuarioInclusaoNome   = Itens.UsuarioInclusaoNome;
            IdUsuarioAlteracao    = Itens.IdUsuarioAlteracao;
            DtUsuarioAlteracao    = Itens.DtUsuarioAlteracao;
            UsuarioAlteracaoNome  = Itens.UsuarioAlteracaoNome;
            Ativo                 = Itens.Ativo;                                  
        }

        public TipoJustica ToDomain()
        {
            var Itens = new TipoJustica();

            Itens.IdTipoJustica         = IdTipoJustica;
            Itens.IdMaster              = IdMaster;
            Itens.Descricao             = Descricao;
            Itens.IdUsuarioInclusao     = IdUsuarioInclusao;
            Itens.DtUsuarioInclusao     = DtUsuarioInclusao;
            Itens.UsuarioInclusaoNome   = UsuarioInclusaoNome;
            Itens.IdUsuarioAlteracao    = IdUsuarioAlteracao;
            Itens.DtUsuarioAlteracao    = DtUsuarioAlteracao;
            Itens.UsuarioAlteracaoNome  = UsuarioAlteracaoNome;
            Itens.Ativo                 = Ativo;
            return Itens;

        }



        public int IdMaster                     { get; set; }
        public int    IdTipoJustica             { get; set; }

        [Display(Name = "Descrição do Tipo de Justiça")]
        [Required(ErrorMessage = "Informe a Descrição do Tipo de Justiça", AllowEmptyStrings = false)]
        public string Descricao                 { get; set; }

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