


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class UsuarioPerfilConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UsuarioPerfil>
    {
        public UsuarioPerfilConfiguration()
            : this("dbo")
        {
        }

        public UsuarioPerfilConfiguration(string schema)
        {
            ToTable("USUARIOPERFIL", schema);
            HasKey(x => x.IdUsuarioPerfil);

            Property(x => x.IdUsuarioPerfil          ).HasColumnName(@"idUsuarioPerfil"      ).HasColumnType("int"      ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired();
            Property(x => x.Descricao                ).HasColumnName(@"Descricao"            ).HasColumnType("varchar"  ).IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.IdUsuarioInclusao        ).HasColumnName(@"IdUsuarioInclusao"    ).HasColumnType("int"      ).IsOptional();
            Property(x => x.DtUsuarioInclusao        ).HasColumnName(@"DtUsuarioInclusao"    ).HasColumnType("datetime" ).IsOptional();
            Property(x => x.IdUsuarioAlteracao       ).HasColumnName(@"IdUsuarioAlteracao"   ).HasColumnType("int"      ).IsOptional();
            Property(x => x.DtUsuarioAlteracao       ).HasColumnName(@"DtUsuarioAlteracao"   ).HasColumnType("datetime" ).IsOptional();
            Property(x => x.Ativo                    ).HasColumnName(@"Ativo"                ).HasColumnType("bit"      ).IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

