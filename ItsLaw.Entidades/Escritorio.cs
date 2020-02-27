using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{    
    public partial class Escritorio
    {
        public int       IdEscritorio               { get; set; }
        public int       IdMaster                   { get; set; }
        public string    CpfCnpj                    { get; set; }
        public string    Fantasia                   { get; set; }
        public string    Nome                       { get; set; }
        public string    Cep                        { get; set; }
        public string    Logradouro                 { get; set; }
        public string    Numero                     { get; set; }
        public string    Complemento                { get; set; }
        public string    Bairro                     { get; set; }
        public string    Cidade                     { get; set; }
        public int       IDEstado                   { get; set; }
        public string    WebSite                    { get; set; }
        public string    EmailPrincipal             { get; set; }
        public string    EmailContato               { get; set; }
        public string    Telefone                   { get; set; }
        public string    Celular                    { get; set; }
        public string    Contato                    { get; set; }
        public string    CNAE                       { get; set; }
        public string    InscricaoEstadual          { get; set; }
        public string    InscricaoMunicipal         { get; set; }
        public byte[]    Logotipo                   { get; set; }
        public int       IdUsuarioInclusao          { get; set; }
        public DateTime  DtUsuarioInclusao          { get; set; }
        public int?      IdUsuarioAlteracao         { get; set; }
        public DateTime? DtUsuarioAlteracao         { get; set; }
        public bool      Ativo                      { get; set; }
                                                    
        [NotMapped]                                 
        public string    UsuarioInclusaoNome        { get; set; }  
        [NotMapped]                                 
        public string    UsuarioAlteracaoNome       { get; set; }



        public Escritorio()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

