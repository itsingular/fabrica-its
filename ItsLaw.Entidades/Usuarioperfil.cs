using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{    
    public partial class UsuarioPerfil
    {
        public int       IdUsuarioPerfil            { get; set; }
        public int       IdMaster                   { get; set; }
        public string    Descricao                  { get; set; }
        public int       IdUsuarioInclusao          { get; set; }
        public DateTime  DtUsuarioInclusao          { get; set; }
        public int?      IdUsuarioAlteracao         { get; set; }
        public DateTime? DtUsuarioAlteracao         { get; set; }
        [NotMapped]                                 
        public string    UsuarioInclusaoNome        { get; set; }  
        [NotMapped]                                 
        public string    UsuarioAlteracaoNome       { get; set; }
        public bool      Ativo                      { get; set; }

        public IEnumerable<UsuarioPerfilDireito> AcessoDireitos { get; set; }

        public UsuarioPerfil()
        {
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

