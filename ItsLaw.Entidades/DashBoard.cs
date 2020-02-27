using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{
    public partial class DashBoard
    {
        public int       IdProcesso                 { get; set; }
        public int       IdMaster                   { get; set; }
        public int       IdUsuarioLogado            { get; set; }
        public int       QtdeProcessos              { get; set; }
        public int       QtdeProcAberto             { get; set; }
        public int       QtdeProcPendente           { get; set; }

        [NotMapped]                                 
        public string    UsuarioLogadoNome          { get; set; }

        public DashBoard()
        {
            InitializePartial();
        }

        partial void InitializePartial();

    }
}
