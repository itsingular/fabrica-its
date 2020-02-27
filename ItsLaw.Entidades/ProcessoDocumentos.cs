using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{
    public partial class ProcessoDocumentos
    {
        public int       IdMaster                   { get; set; }
        public int       IdProcesso                 { get; set; }
        public int       IdDocumento                { get; set; }
        public int       IdTipoDocumento            { get; set; }
        public byte[]    Documento                  { get; set; }
        public int       IdUsuarioInclusao          { get; set; }
        public DateTime  DtUsuarioInclusao          { get; set; }

        public ProcessoDocumentos()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

