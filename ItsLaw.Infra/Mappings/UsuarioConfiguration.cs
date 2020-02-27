


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class UsuarioConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
            : this("dbo")
        {
        }

        public UsuarioConfiguration(string schema)
        {
            ToTable("USUARIO", schema);
            HasKey(x => x.IdUsuario);

            Property(x => x.IdUsuario                ).HasColumnName(@"IdUsuario"            ).HasColumnType("int"           ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"           ).IsRequired();
            Property(x => x.IdUsuarioPerfil          ).HasColumnName(@"idUsuarioPerfil"      ).HasColumnType("int"           ).IsOptional();
            Property(x => x.IdEmpresa                ).HasColumnName(@"IdEmpresa"            ).HasColumnType("int"           ).IsOptional();
            Property(x => x.Email                    ).HasColumnName(@"Email"                ).HasColumnType("varchar"       ).IsOptional().IsUnicode(false).HasMaxLength(250);
            Property(x => x.Nome                     ).HasColumnName(@"Nome"                 ).HasColumnType("varchar"       ).IsOptional().IsUnicode(false).HasMaxLength(150);
            Property(x => x.Apelido                  ).HasColumnName(@"Apelido"              ).HasColumnType("varchar"       ).IsOptional().IsUnicode(false).HasMaxLength( 50);
            Property(x => x.SenhaCripto              ).HasColumnName(@"SenhaCripto"          ).HasColumnType("varchar"       ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Fotografia               ).HasColumnName(@"Fotografia"           ).HasColumnType("varbinary(MAX)").IsOptional();
            Property(x => x.IdUsuarioInclusao        ).HasColumnName(@"IdUsuarioInclusao"    ).HasColumnType("int"           ).IsOptional();
            Property(x => x.DtUsuarioInclusao        ).HasColumnName(@"DtUsuarioInclusao"    ).HasColumnType("datetime"      ).IsOptional();
            Property(x => x.IdUsuarioAlteracao       ).HasColumnName(@"IdUsuarioAlteracao"   ).HasColumnType("int"           ).IsOptional();
            Property(x => x.DtUsuarioAlteracao       ).HasColumnName(@"DtUsuarioAlteracao"   ).HasColumnType("datetime"      ).IsOptional();
            Property(x => x.DtSenhaAlteracao         ).HasColumnName(@"DtSenhaAlteracao"     ).HasColumnType("datetime"      ).IsOptional();
            Property(x => x.CodigoAtivacao           ).HasColumnName(@"Codigo_Ativacao"      ).HasColumnType("varchar"       ).IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.AtivoEmail               ).HasColumnName(@"Ativo_Email"          ).HasColumnType("bit"           ).IsOptional();
            Property(x => x.Ativo                    ).HasColumnName(@"Ativo"                ).HasColumnType("bit"           ).IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

