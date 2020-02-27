using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{    
    public partial class UsuarioPerfilDireito
    {
        public int       IdMaster                   { get; set; }
        public int       IdUsuarioPerfilDireito     { get; set; }
        public int       IdUsuarioPerfil            { get; set; }
        public int       IdUsuarioPath              { get; set; }
        public bool?     AcaoVisualizar             { get; set; }
        public bool?     AcaoEditar                 { get; set; }
        public bool?     AcaoIncluir                { get; set; }
        public bool?     AcaoExcluir                { get; set; }
        public bool?     AcaoImportar               { get; set; }
        public bool?     AcaoImprimir               { get; set; }
        public int       IdUsuarioInclusao          { get; set; }
        public DateTime  DtUsuarioInclusao          { get; set; }
        public int?      IdUsuarioAlteracao         { get; set; }
        public DateTime? DtUsuarioAlteracao         { get; set; }
                                                    
        [NotMapped]                                 
        public string    DescricaoAcesso            { get; set; }
                                                    
        public UsuarioPerfilDireito()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

