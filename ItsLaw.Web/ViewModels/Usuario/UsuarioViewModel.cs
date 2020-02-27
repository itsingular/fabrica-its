using ItsLaw.Entidades;
using ItsLaw.Funcoes.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;




namespace ItsLaw.Web.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {

        }

        public UsuarioViewModel(Usuario Itens)
        {
            IdUsuario             = Itens.IdUsuario;
            IdMaster              = Itens.IdMaster;
            IdUsuarioPerfil       = Itens.IdUsuarioPerfil;
            IdEmpresa             = Itens.IdEmpresa;
            FantasiaEmpresa       = Itens.FantasiaEmpresa;
            Email                 = Itens.Email;
            Nome                  = Itens.Nome;
            Apelido               = Itens.Apelido;
            SenhaCripto           = Itens.SenhaCripto;
            Fotografia            = Itens.Fotografia;
            IdUsuarioInclusao     = Itens.IdUsuarioInclusao;
            UsuarioInclusaoNome   = Itens.UsuarioInclusaoNome;
            DtUsuarioInclusao     = Itens.DtUsuarioInclusao;
            IdUsuarioAlteracao    = Itens.IdUsuarioAlteracao;
            UsuarioAlteracaoNome  = Itens.UsuarioAlteracaoNome;
            DtUsuarioAlteracao    = Itens.DtUsuarioAlteracao;
            DtSenhaAlteracao      = Itens.DtSenhaAlteracao;
            CodigoAtivacao        = Itens.CodigoAtivacao;  //EGS 30.11.2018 - Lembrar usuario para confirmar inclusao no sistema, por link no email
            AtivoEmail            = Itens.AtivoEmail;      //EGS 30.11.2018 - Apos incluir, vai email para usuario confirmar inclusao no sistema, por link no email
            Ativo                 = Itens.Ativo;                                  
        }


        public Usuario ToDomain()
        {
            var Itens = new Usuario();

            Itens.IdUsuario             = IdUsuario;
            Itens.IdMaster              = IdMaster;
            Itens.IdUsuarioPerfil       = IdUsuarioPerfil;
            Itens.IdEmpresa             = IdEmpresa;
            Itens.FantasiaEmpresa       = FantasiaEmpresa;
            Itens.Email                 = Email;
            Itens.Nome                  = Nome;
            Itens.Apelido               = Apelido;
            Itens.SenhaCripto           = SenhaCripto;
            Itens.Fotografia            = Fotografia;
            Itens.IdUsuarioInclusao     = IdUsuarioInclusao;
            Itens.UsuarioInclusaoNome   = UsuarioInclusaoNome;
            Itens.DtUsuarioInclusao     = DtUsuarioInclusao;
            Itens.IdUsuarioAlteracao    = IdUsuarioAlteracao;
            Itens.UsuarioAlteracaoNome  = UsuarioAlteracaoNome;
            Itens.DtUsuarioAlteracao    = DtUsuarioAlteracao;
            Itens.DtSenhaAlteracao      = DtSenhaAlteracao;
            Itens.CodigoAtivacao        = CodigoAtivacao;
            Itens.AtivoEmail            = AtivoEmail;
            Itens.Ativo                 = Ativo;
            return Itens;
        }



        public int    IdMaster                  { get; set; }
        public int    IdUsuario                 { get; set; }
        public int    IdUsuarioPerfil           { get; set; }
        public int    IdEmpresa                 { get; set; }
        public string FantasiaEmpresa           { get; set; }
        public string PerfilNome                { get; set; }

        [Required(ErrorMessage = "Informe o email do usuário", AllowEmptyStrings = false)]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Informe um email válido.")]
        public string Email                     { get; set; }

        [Required(ErrorMessage = "Informe o nome do usuário", AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome                      { get; set; }

        [Required(ErrorMessage = "Informe o Apelido do usuário", AllowEmptyStrings = false)]
        public string Apelido                   { get; set; }

        [Required(ErrorMessage = "Informe a Senha do usuário", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string SenhaCripto               { get; set; }

        [Display(Name = "Fotografia do Usuário")]
        public byte[] Fotografia                { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Foto_Usuario")]
        public HttpPostedFileBase ImageUpload   { get; set; }

        [Display(Name = "Dt.Últ.Alt.Senha")]
        public DateTime? DtSenhaAlteracao       { get; set; }

        //EGS 30.11.2018 - Codigo de ativacao por link no email
        [Display(Name = "Codigo de Ativacao por Link de Email")]
        public string CodigoAtivacao            { get; set; }

        //EGS 30.11.2018 - Apos incluir, vai email para usuario confirmar inclusao no sistema, por link no email
        [Display(Name = "Ativo por Link de Email")]
        public bool? AtivoEmail                  { get; set; }

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