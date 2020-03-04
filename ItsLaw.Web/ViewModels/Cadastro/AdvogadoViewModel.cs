using ItsLaw.Entidades;
using ItsLaw.Funcoes;
using ItsLaw.Funcoes.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;




namespace ItsLaw.Web.ViewModels
{

    public class AdvogadoViewModel
    {
        public AdvogadoViewModel()
        {

        }

        public AdvogadoViewModel(Advogado Itens)
        {
            IdAdvogado            = Itens.IdAdvogado;
            IdMaster              = Itens.IdMaster;
            CpfCnpj               = Itens.CpfCnpj;
            Fantasia              = Itens.Fantasia;
            Nome                  = Itens.Nome;
            Cep                   = Itens.Cep;
            Logradouro            = Itens.Logradouro;
            Numero                = Itens.Numero;
            Complemento           = Itens.Complemento;
            Bairro                = Itens.Bairro;
            Cidade                = Itens.Cidade;
            IDEstado              = Itens.IDEstado;
            Email                 = Itens.Email;
            Telefone              = Itens.Telefone;
            Celular               = Itens.Celular;
            IDSexo                = Itens.IDSexo;
            DataNascimento        = Itens.DataNascimento;
            IDEstadoCivil         = Itens.IDEstadoCivil;
            OAB_Numero            = Itens.OAB_Numero;
            OAB_DtExpedido        = Itens.OAB_DtExpedido;
            OAB_IDTipoInscricao   = Itens.OAB_IDTipoInscricao;
            IdUsuarioInclusao     = Itens.IdUsuarioInclusao;
            UsuarioInclusaoNome   = Itens.UsuarioInclusaoNome;
            DtUsuarioInclusao     = Itens.DtUsuarioInclusao;
            IdUsuarioAlteracao    = Itens.IdUsuarioAlteracao;
            UsuarioAlteracaoNome  = Itens.UsuarioAlteracaoNome;
            DtUsuarioAlteracao    = Itens.DtUsuarioAlteracao;
            Ativo                 = Itens.Ativo;                                  
        }

        public Advogado ToDomain()
        {
            var Itens = new Advogado();

            Itens.IdAdvogado            = IdAdvogado;
            Itens.IdMaster              = IdMaster;
            Itens.CpfCnpj               = CpfCnpj;
            Itens.Fantasia              = Fantasia;
            Itens.Nome                  = Nome;
            Itens.Cep                   = Cep;
            Itens.Logradouro            = Logradouro;
            Itens.Numero                = Numero;
            Itens.Complemento           = Complemento;
            Itens.Bairro                = Bairro;
            Itens.Cidade                = Cidade;
            Itens.IDEstado              = IDEstado;
            Itens.Email                 = Email;
            Itens.Telefone              = Telefone;
            Itens.Celular               = Celular;
            Itens.IDSexo                = IDSexo;
            Itens.DataNascimento        = DataNascimento;
            Itens.IDEstadoCivil         = IDEstadoCivil;
            Itens.OAB_Numero            = OAB_Numero;
            Itens.OAB_DtExpedido        = OAB_DtExpedido;
            Itens.OAB_IDTipoInscricao   = OAB_IDTipoInscricao;
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
        public int IdAdvogado                    { get; set; }

        [Required(ErrorMessage = "Informe o CPF ou CNPJ do Advogado", AllowEmptyStrings = false)]
        [CpfCnpj(ErrorMessage = "O valor é inválido para CPF ou CNPJ ")]
        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj                    { get; set; }

        [Display(Name = "Fantasia")]
        [Required(ErrorMessage = "Informe a Fantasia", AllowEmptyStrings = false)]
        public string Fantasia                   { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o Nome do Advogado", AllowEmptyStrings = false)]
        public string Nome                       { get; set; }

        [Display(Name = "CEP")]
        public string Cep                        { get; set; }

        [Display(Name = "Rua")]
        public string Logradouro                 { get; set; }

        [Display(Name = "Número")]
        public string Numero                     { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento                { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro                     { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade                     { get; set; }

        [Display(Name = "Estado")]
        public int IDEstado                      { get; set; }

        [Display(Name = "E-Mail")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Informe um email válido.")]
        public string Email                      { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone                   { get; set; }


        [Required(ErrorMessage = "Informe o celular do Advogado", AllowEmptyStrings = false)]
        [CpfCnpj(ErrorMessage = "O valor é inválido o celular")]
        [Display(Name = "Celular")]
        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$", ErrorMessage = "Informe um celular válido.")]
        public string Celular                    { get; set; }

        [Display(Name = "Sexo")]
        public int IDSexo                        { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public System.DateTime? DataNascimento   { get; set; }

        [Display(Name = "Est.Civil")]
        public int IDEstadoCivil                 { get; set; }

        [Display(Name = "OAB Número")]
        public string OAB_Numero                 { get; set; }

        [Display      (Name = "OAB Dt.Exped")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? OAB_DtExpedido          { get; set; }

        [Display(Name = "OAB Inscrição")]
        public int  OAB_IDTipoInscricao          { get; set; }
                                                 
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