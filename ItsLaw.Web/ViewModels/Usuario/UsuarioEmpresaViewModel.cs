using ItsLaw.Entidades;
using ItsLaw.Funcoes.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;




namespace ItsLaw.Web.ViewModels
{
    public class UsuarioEmpresaViewModel
    {
        public UsuarioEmpresaViewModel()
        {

        }

        public UsuarioEmpresaViewModel(Usuario Itens)
        {
            IdUsuario             = Itens.IdUsuario;
            IdMaster              = Itens.IdMaster;
            IdEmpresa             = Itens.IdEmpresa;
            FantasiaEmpresa       = Itens.FantasiaEmpresa;
            Email                 = Itens.Email;
            Nome                  = Itens.Nome;
            IdUsuarioAlteracao    = Itens.IdUsuarioAlteracao;
            UsuarioAlteracaoNome  = Itens.UsuarioAlteracaoNome;
            DtUsuarioAlteracao    = Itens.DtUsuarioAlteracao;
        }


        public Usuario ToDomain()
        {
            var Itens = new Usuario();

            Itens.IdUsuario             = IdUsuario;
            Itens.IdMaster              = IdMaster;
            Itens.IdEmpresa             = IdEmpresa;
            Itens.FantasiaEmpresa       = FantasiaEmpresa;
            Itens.Email                 = Email;
            Itens.Nome                  = Nome;
            Itens.IdUsuarioAlteracao    = IdUsuarioAlteracao;
            Itens.UsuarioAlteracaoNome  = UsuarioAlteracaoNome;
            Itens.DtUsuarioAlteracao    = DtUsuarioAlteracao;
            return Itens;
        }



        public int       IdMaster               { get; set; }
        public int       IdUsuario              { get; set; }
        public int       IdEmpresa              { get; set; }

        public string    Email                  { get; set; }

        public string    Nome                   { get; set; }
        public string    FantasiaEmpresa        { get; set; }
        public int?      IdUsuarioAlteracao     { get; set; }
        public string    UsuarioAlteracaoNome   { get; set; }
        public DateTime? DtUsuarioAlteracao     { get; set; }
    }



}