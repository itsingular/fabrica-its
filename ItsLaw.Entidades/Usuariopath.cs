using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{    
    public partial class UsuarioPath
    {
        public int       IdUsuarioPath         { get; set; }
        public string    Descricao             { get; set; }
        public string    DsController          { get; set; }
        public bool      Ativo                 { get; set; }

        public UsuarioPath()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

