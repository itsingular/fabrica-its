using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{    
    public partial class TabAuxiliar
    {
        public int       IdTabAuxiliar         { get; set; }
        public string    Filtro                { get; set; }
        public string    Codigo                { get; set; }
        public string    Descricao             { get; set; }
        public bool      Ativo                 { get; set; }

        public TabAuxiliar()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

