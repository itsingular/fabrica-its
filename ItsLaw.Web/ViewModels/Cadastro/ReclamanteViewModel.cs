using ItsLaw.Entidades;
using ItsLaw.Funcoes.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;




namespace ItsLaw.Web.ViewModels
{
    public class ReclamanteViewModel
    {
        public ReclamanteViewModel()
        {

        }

        public ReclamanteViewModel(Reclamante Itens)
        {
            IdReclamante          = Itens.IdReclamante;
            IdMaster              = Itens.IdMaster;
            CpfCnpj               = Itens.CpfCnpj;
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
            Profissao             = Itens.Profissao;
            IdUsuarioInclusao     = Itens.IdUsuarioInclusao;
            UsuarioInclusaoNome   = Itens.UsuarioInclusaoNome;
            DtUsuarioInclusao     = Itens.DtUsuarioInclusao;
            IdUsuarioAlteracao    = Itens.IdUsuarioAlteracao;
            UsuarioAlteracaoNome  = Itens.UsuarioAlteracaoNome;
            DtUsuarioAlteracao    = Itens.DtUsuarioAlteracao;
            Ativo                 = Itens.Ativo;                                  
        }

        public Reclamante ToDomain()
        {
            var Itens = new Reclamante();

            Itens.IdReclamante          = IdReclamante;
            Itens.IdMaster              = IdMaster;
            Itens.CpfCnpj               = CpfCnpj;
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
            Itens.Profissao             = Profissao;
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

        [Display(Name = "IdReclamante")]
        public int IdReclamante                  { get; set; }

        [Required(ErrorMessage = "Informe o CPF ou CNPJ da Parte Contrária", AllowEmptyStrings = false)]
        [CpfCnpj(ErrorMessage = "O valor é inválido para CPF ou CNPJ")]
        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj                    { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o Nome do Reclamante", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Rua")]
        public string Logradouro { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public int IDEstado { get; set; }

        [Display(Name = "E-Mail")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [Display(Name = "Sexo")]
        public int IDSexo { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public System.DateTime? DataNascimento { get; set; }

        [Display(Name = "Est.Civil")]
        public int IDEstadoCivil               { get; set; }

        [Display(Name = "Profissão")]
        public string Profissao                { get; set; }

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