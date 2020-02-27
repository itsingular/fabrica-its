using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{    
    public partial class Comarca
    {
        public int       IdComarca                  { get; set; }
        public int       IdMaster                   { get; set; }
        public string    Descricao                  { get; set; }
        public string    Endereco                   { get; set; }
        public string    Bairro                     { get; set; }
        public string    Cidade                     { get; set; }
        public string    Estado                     { get; set; }
        public string    Telefone                   { get; set; }
        public int       IdUsuarioInclusao          { get; set; }
        public DateTime  DtUsuarioInclusao          { get; set; }
        public int?      IdUsuarioAlteracao         { get; set; }
        public DateTime? DtUsuarioAlteracao         { get; set; }
        public bool      Ativo                      { get; set; }
                                                    
        [NotMapped]                                 
        public string    UsuarioInclusaoNome        { get; set; }  
        [NotMapped]                                 
        public string    UsuarioAlteracaoNome       { get; set; }

        public Comarca()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

