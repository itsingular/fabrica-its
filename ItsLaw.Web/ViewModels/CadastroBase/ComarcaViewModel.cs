using ItsLaw.Entidades;
using ItsLaw.Funcoes.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;




namespace ItsLaw.Web.ViewModels
{

    public class ComarcaViewModel
    {
        public ComarcaViewModel()
        {

        }

        public ComarcaViewModel(Comarca Itens)
        {
            IdComarca             = Itens.IdComarca;
            IdMaster              = Itens.IdMaster;
            Descricao             = Itens.Descricao;
            Endereco              = Itens.Endereco;
            Cidade                = Itens.Cidade;
            Bairro                = Itens.Bairro;
            Estado                = Itens.Estado;
            Telefone              = Itens.Telefone;
            IdUsuarioInclusao     = Itens.IdUsuarioInclusao;
            DtUsuarioInclusao     = Itens.DtUsuarioInclusao;
            UsuarioInclusaoNome   = Itens.UsuarioInclusaoNome;
            IdUsuarioAlteracao    = Itens.IdUsuarioAlteracao;
            DtUsuarioAlteracao    = Itens.DtUsuarioAlteracao;
            UsuarioAlteracaoNome  = Itens.UsuarioAlteracaoNome;
            Ativo                 = Itens.Ativo;                                  
        }

        public Comarca ToDomain()
        {
            var Itens = new Comarca();

            Itens.IdComarca             = IdComarca;
            Itens.IdMaster              = IdMaster;
            Itens.Descricao             = Descricao;
            Itens.Endereco              = Endereco;
            Itens.Cidade                = Cidade;
            Itens.Bairro                = Bairro;
            Itens.Estado                = Estado;
            Itens.Telefone              = Telefone;
            Itens.IdUsuarioInclusao     = IdUsuarioInclusao;
            Itens.DtUsuarioInclusao     = DtUsuarioInclusao;
            Itens.UsuarioInclusaoNome   = UsuarioInclusaoNome;
            Itens.IdUsuarioAlteracao    = IdUsuarioAlteracao;
            Itens.DtUsuarioAlteracao    = DtUsuarioAlteracao;
            Itens.UsuarioAlteracaoNome  = UsuarioAlteracaoNome;
            Itens.Ativo                 = Ativo;
            return Itens;

        }


        public int IdMaster                      { get; set; }
        public int IdComarca                     { get; set; }
                                                 
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a Descrição da Comarca", AllowEmptyStrings = false)]
        public string Descricao                   { get; set; }
                                                 
        [Display(Name = "Endereco")]             
        public string Endereco                    { get; set; }
                                                 
        [Display(Name = "Cidade")]               
        public string Cidade                      { get; set; }
                                                 
        [Display(Name = "Bairro")]               
        public string Bairro                      { get; set; }
                                                 
        [Display(Name = "Estado")]               
        public string Estado                      { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone                    { get; set; }
                                                 
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