using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ItsLaw.Entidades
{    
    public partial class Usuario
    {

        public int    IdMaster               { get; set; }
        public int    IdUsuario              { get; set; }
        public int    IdUsuarioPerfil        { get; set; }
        public int    IdEmpresa              { get; set; }
        [NotMapped]
        public string FantasiaEmpresa        { get; set; }
        [NotMapped]
        public string PerfilNome             { get; set; }
        public string Email                  { get; set; }
        public string Nome                   { get; set; }
        public string Apelido                { get; set; }
        public string SenhaCripto            { get; set; }
        public byte[] Fotografia             { get; set; }
        public int IdUsuarioInclusao         { get; set; }
        [NotMapped]
        public string UsuarioInclusaoNome    { get; set; }
        public DateTime DtUsuarioInclusao    { get; set; }
        public int? IdUsuarioAlteracao       { get; set; }
        [NotMapped]
        public string UsuarioAlteracaoNome   { get; set; }
        public DateTime? DtUsuarioAlteracao  { get; set; }
        public DateTime? DtSenhaAlteracao    { get; set; }
        public string CodigoAtivacao         { get; set; }
        public bool? AtivoEmail              { get; set; }
        public bool Ativo                    { get; set; }

        public Usuario()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

