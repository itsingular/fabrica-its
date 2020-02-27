using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{
    public partial class ProcessoTestemunha
    {
        public int       IdMaster                   { get; set; }
        public int       IdProcesso                 { get; set; }
        public int       IdTestemunha               { get; set; }
        public int       IdUsuarioInclusao          { get; set; }
        public DateTime  DtUsuarioInclusao          { get; set; }

        public ProcessoTestemunha()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

