using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{
    public partial class ProcessoHistorico
    {
        public int       IdMaster                   { get; set; }
        public int       IdProcesso                 { get; set; }
        public int       IdHistorico                { get; set; }
        public int       IdEvento                   { get; set; }
        public DateTime  DtEvento                   { get; set; }
        public string    Descricao                  { get; set; }

        public ProcessoHistorico()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

