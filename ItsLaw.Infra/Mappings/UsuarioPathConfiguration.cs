


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class UsuarioPathConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UsuarioPath>
    {
        public UsuarioPathConfiguration()
            : this("dbo")
        {
        }

        public UsuarioPathConfiguration(string schema)
        {
            ToTable("USUARIOPATH", schema);
            HasKey(x => x.IdUsuarioPath);

            Property(x => x.IdUsuarioPath            ).HasColumnName(@"idUsuarioPath"        ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao                ).HasColumnName(@"Descricao"            ).HasColumnType("varchar" ).IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.DsController             ).HasColumnName(@"DsController"         ).HasColumnType("varchar" ).IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.Ativo                    ).HasColumnName(@"Ativo"                ).HasColumnType("bit"     ).IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

