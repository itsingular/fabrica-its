using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{    
    public partial class StatusProcesso
    {
        public int       IdStatusProcesso           { get; set; }
        public int       IdMaster                   { get; set; }
        public string    Codigo                     { get; set; }
        public string    Descricao                  { get; set; }
        public string    CorGrid                    { get; set; }
        public int       IdUsuarioInclusao          { get; set; }
        public DateTime  DtUsuarioInclusao          { get; set; }
        public int?      IdUsuarioAlteracao         { get; set; }
        public DateTime? DtUsuarioAlteracao         { get; set; }
        public bool      Ativo                      { get; set; }
                                                    
        [NotMapped]                                 
        public string    UsuarioInclusaoNome        { get; set; }  
        [NotMapped]                                 
        public string    UsuarioAlteracaoNome       { get; set; }
                                                    
        public StatusProcesso()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }


    public partial class Cores
    {
        public int CorID { get; set; }
        public string Cor   { get; set; }

        public List<Cores> ListaCores()
        {
            return new List<Cores>
            {
                new Cores { CorID = 1, Cor = "Azul"},
                new Cores { CorID = 2, Cor = "Vermelho"},
                new Cores { CorID = 3, Cor = "Amarelo"}
            };
        }

        public Cores()
        {
            InitializePartial();
        }
        partial void InitializePartial();
    }
}

