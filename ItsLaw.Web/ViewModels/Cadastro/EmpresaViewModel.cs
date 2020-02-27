using ItsLaw.Entidades;
using ItsLaw.Funcoes.Validacao;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;




namespace ItsLaw.Web.ViewModels
{

    public class EmpresaViewModel
    {
        public EmpresaViewModel()
        {

        }

        public EmpresaViewModel(Empresa Itens)
        {
            IdEmpresa             = Itens.IdEmpresa;           
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
            WebSite               = Itens.WebSite;             
            EmailPrincipal        = Itens.EmailPrincipal;      
            EmailContato          = Itens.EmailContato;        
            Telefone              = Itens.Telefone;            
            Celular               = Itens.Celular;             
            Contato               = Itens.Contato;             
            CNAE                  = Itens.CNAE;                
            InscricaoEstadual     = Itens.InscricaoEstadual;
            InscricaoMunicipal    = Itens.InscricaoMunicipal;  
            Logotipo              = Itens.Logotipo;
            IdUsuarioInclusao     = Itens.IdUsuarioInclusao;
            UsuarioInclusaoNome   = Itens.UsuarioInclusaoNome;
            DtUsuarioInclusao     = Itens.DtUsuarioInclusao;
            IdUsuarioAlteracao    = Itens.IdUsuarioAlteracao;
            UsuarioAlteracaoNome  = Itens.UsuarioAlteracaoNome;
            DtUsuarioAlteracao    = Itens.DtUsuarioAlteracao;
            Ativo                 = Itens.Ativo;                                  
        }

        public Empresa ToDomain()
        {
            var Itens = new Empresa();

            Itens.IdEmpresa             = IdEmpresa;
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
            Itens.WebSite               = WebSite;             
            Itens.EmailPrincipal        = EmailPrincipal;      
            Itens.EmailContato          = EmailContato;        
            Itens.Telefone              = Telefone;            
            Itens.Celular               = Celular;             
            Itens.Contato               = Contato;             
            Itens.CNAE                  = CNAE;                
            Itens.InscricaoEstadual     = InscricaoEstadual;
            Itens.InscricaoMunicipal    = InscricaoMunicipal;  
            Itens.Logotipo              = Logotipo;
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
        public int IdEmpresa                     { get; set; }

        [Required(ErrorMessage = "Informe o CPF ou CNPJ da Empresa", AllowEmptyStrings = false)]
        [CpfCnpj(ErrorMessage = "O valor é inválido para CPF ou CNPJ")]
        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [Display(Name = "Fantasia")]
        [Required(ErrorMessage = "Informe a Fantasia", AllowEmptyStrings = false)]
        public string Fantasia                   { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe o Nome da Empresa", AllowEmptyStrings = false)]
        public string Nome                       { get; set; }

        [Display(Name = "CEP")]
        public string Cep                        { get; set; }

        [Display(Name = "Endereço")]
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

        [Display(Name = "Website da Empresa")]
        public string WebSite                    { get; set; }

        [Display(Name = "E-Mail da Empresa")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Informe um email válido.")]
        public string EmailPrincipal             { get; set; }

        [Display(Name = "E-Mail do Contato")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Informe um email válido.")]
        public string EmailContato               { get; set; }
                                                 
        [Display(Name = "Telefone")]
        public string Telefone                   { get; set; }
                                                 
        [Display(Name = "Celular")]
        public string Celular                    { get; set; }
                                                 
        [Display(Name = "Contato")]              
        public string Contato                    { get; set; }
                                                 
        [Display(Name = "Codigo CNAE")]          
        public string CNAE                       { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual          { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string InscricaoMunicipal         { get; set; }

        [Display(Name = "Logotipo")]
        public byte[] Logotipo                   { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Logotipo_Empresa")]
        public HttpPostedFileBase ImageUpload    { get; set; }
                                                 
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