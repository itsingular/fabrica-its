


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class UsuarioPerfilDireitoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UsuarioPerfilDireito>
    {
        public UsuarioPerfilDireitoConfiguration()
            : this("dbo")
        {
        }

        public UsuarioPerfilDireitoConfiguration(string schema)
        {
            ToTable("USUARIOPERFILDIREITO", schema);
            HasKey(x => x.IdUsuarioPerfilDireito);

            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"              ).HasColumnType("int"     ).IsRequired();
            Property(x => x.IdUsuarioPerfilDireito   ).HasColumnName(@"IDUSUARIOPERFILDIREITO").HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdUsuarioPerfil          ).HasColumnName(@"IDUSUARIOPERFIL"       ).HasColumnType("int"     ).IsOptional();
            Property(x => x.IdUsuarioPath            ).HasColumnName(@"IDUSUARIOPATH"         ).HasColumnType("int"     ).IsOptional();
            Property(x => x.AcaoVisualizar           ).HasColumnName(@"ACAOVISUALIZAR"        ).HasColumnType("bit"     ).IsOptional();
            Property(x => x.AcaoEditar               ).HasColumnName(@"ACAOEDITAR"            ).HasColumnType("bit"     ).IsOptional();
            Property(x => x.AcaoIncluir              ).HasColumnName(@"ACAOINCLUIR"           ).HasColumnType("bit"     ).IsOptional();
            Property(x => x.AcaoExcluir              ).HasColumnName(@"ACAOEXCLUIR"           ).HasColumnType("bit"     ).IsOptional();
            Property(x => x.AcaoImportar             ).HasColumnName(@"ACAOIMPORTAR"          ).HasColumnType("bit"     ).IsOptional();
            Property(x => x.AcaoImprimir             ).HasColumnName(@"ACAOIMPRIMIR"          ).HasColumnType("bit"     ).IsOptional();
            Property(x => x.IdUsuarioInclusao        ).HasColumnName(@"IdUsuarioInclusao"     ).HasColumnType("int"      ).IsOptional();
            Property(x => x.DtUsuarioInclusao        ).HasColumnName(@"DtUsuarioInclusao"     ).HasColumnType("datetime" ).IsOptional();
            Property(x => x.IdUsuarioAlteracao       ).HasColumnName(@"IdUsuarioAlteracao"    ).HasColumnType("int"      ).IsOptional();
            Property(x => x.DtUsuarioAlteracao       ).HasColumnName(@"DtUsuarioAlteracao"    ).HasColumnType("datetime" ).IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

