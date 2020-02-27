using ItsLaw.Entidades;
using ItsLaw.Funcoes.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;



namespace ItsLaw.Web.ViewModels
{
    public class UsuarioPerfilDireitoViewModel
    {
        public UsuarioPerfilDireitoViewModel()
        {

        }

        public UsuarioPerfilDireitoViewModel(UsuarioPerfilDireito Itens)
        {
            IdMaster               = Itens.IdMaster;
            IdUsuarioPerfilDireito = Itens.IdUsuarioPerfilDireito;
            IdUsuarioPerfil        = Itens.IdUsuarioPerfil;
            IdUsuarioPath          = Itens.IdUsuarioPath;
            DescricaoAcesso        = Itens.DescricaoAcesso;
            AcaoVisualizar         = Itens.AcaoVisualizar;
            AcaoEditar             = Itens.AcaoEditar;
            AcaoIncluir            = Itens.AcaoIncluir;
            AcaoExcluir            = Itens.AcaoExcluir;
            AcaoImportar           = Itens.AcaoImportar;
            AcaoImprimir           = Itens.AcaoImprimir;
            IdUsuarioInclusao      = Itens.IdUsuarioInclusao;
            DtUsuarioInclusao      = Itens.DtUsuarioInclusao;
            AcaoImprimir           = Itens.AcaoImprimir;
            IdUsuarioAlteracao     = Itens.IdUsuarioAlteracao;
            DtUsuarioAlteracao     = Itens.DtUsuarioAlteracao;

        }

        public UsuarioPerfilDireito ToDomain()
        {
            var Itens = new UsuarioPerfilDireito();

            Itens.IdMaster               = IdMaster;
            Itens.IdUsuarioPerfilDireito = IdUsuarioPerfilDireito;
            Itens.IdUsuarioPerfil        = IdUsuarioPerfil;
            Itens.IdUsuarioPath          = IdUsuarioPath;
            Itens.DescricaoAcesso        = DescricaoAcesso;
            Itens.AcaoVisualizar         = AcaoVisualizar;
            Itens.AcaoEditar             = AcaoEditar;
            Itens.AcaoIncluir            = AcaoIncluir;
            Itens.AcaoExcluir            = AcaoExcluir;
            Itens.AcaoImportar           = AcaoImportar;
            Itens.AcaoImprimir           = AcaoImprimir;
            Itens.IdUsuarioInclusao      = IdUsuarioInclusao;
            Itens.DtUsuarioInclusao      = DtUsuarioInclusao;
            Itens.AcaoImprimir           = AcaoImprimir;
            Itens.IdUsuarioAlteracao     = IdUsuarioAlteracao;
            Itens.DtUsuarioAlteracao     = DtUsuarioAlteracao;
            return Itens;
        }

        public int       IdMaster               { get; set; }
        public int       IdUsuarioPerfilDireito { get; set; }
        public int       IdUsuarioPerfil        { get; set; }
        public int       IdUsuarioPath          { get; set; }
        public string    DescricaoAcesso        { get; set; }
        public bool?     AcaoVisualizar         { get; set; }
        public bool?     AcaoEditar             { get; set; }
        public bool?     AcaoIncluir            { get; set; }
        public bool?     AcaoExcluir            { get; set; }
        public bool?     AcaoImportar           { get; set; }
        public bool?     AcaoImprimir           { get; set; }
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

    }
}