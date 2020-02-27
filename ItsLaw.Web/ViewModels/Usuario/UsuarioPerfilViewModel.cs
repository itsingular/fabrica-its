using ItsLaw.Entidades;
using ItsLaw.Funcoes.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace ItsLaw.Web.ViewModels
{
    public class UsuarioPerfilViewModel
    {
        public UsuarioPerfilViewModel()
        {

        }

        public UsuarioPerfilViewModel(UsuarioPerfil Itens)
        {
            IdUsuarioPerfil       = Itens.IdUsuarioPerfil;
            IdMaster              = Itens.IdMaster;
            Descricao             = Itens.Descricao;
            IdUsuarioInclusao     = Itens.IdUsuarioInclusao;
            UsuarioInclusaoNome   = Itens.UsuarioInclusaoNome;
            DtUsuarioInclusao     = Itens.DtUsuarioInclusao;
            IdUsuarioAlteracao    = Itens.IdUsuarioAlteracao;
            UsuarioAlteracaoNome  = Itens.UsuarioAlteracaoNome;
            DtUsuarioAlteracao    = Itens.DtUsuarioAlteracao;
            Ativo                 = Itens.Ativo;
            AcessoDireitos        = Itens.AcessoDireitos;
        }

        public UsuarioPerfil ToDomain()
        {
            var Itens = new UsuarioPerfil();

            Itens.IdUsuarioPerfil       = IdUsuarioPerfil;
            Itens.IdMaster              = IdMaster;
            Itens.Descricao             = Descricao;
            Itens.IdUsuarioInclusao     = IdUsuarioInclusao;
            Itens.UsuarioInclusaoNome   = UsuarioInclusaoNome;
            Itens.DtUsuarioInclusao     = DtUsuarioInclusao;
            Itens.IdUsuarioAlteracao    = IdUsuarioAlteracao;
            Itens.UsuarioAlteracaoNome  = UsuarioAlteracaoNome;
            Itens.DtUsuarioAlteracao    = DtUsuarioAlteracao;
            Itens.Ativo                 = Ativo;
            Itens.AcessoDireitos        = AcessoDireitos;

            return Itens;
        }

        public int        IdMaster                  { get; set; }
        public int        IdUsuarioPerfil           { get; set; }
        public string     Descricao                 { get; set; }
        public string     NomeCampoPerfilDireito    { get; set; }
        public IEnumerable<UsuarioPerfilDireito> AcessoDireitos { get; set; }

        public int        IdUsuarioInclusao         { get; set; }
        [Display(Name = "Usuario Inclusão")]    
        public string     UsuarioInclusaoNome       { get; set; }
        [Display(Name = "Data Inclusão")]       
        public DateTime   DtUsuarioInclusao         { get; set; }
        public int?       IdUsuarioAlteracao        { get; set; }
        [Display(Name = "Usuario Alteração")]   
        public string     UsuarioAlteracaoNome      { get; set; }
        [Display(Name = "Data Alteração")]      
        public DateTime?  DtUsuarioAlteracao        { get; set; }
        [Display(Name = "Ativo")]               
        public bool       Ativo                     { get; set; }

    }
}