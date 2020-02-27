


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class TipoOABConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TipoOAB>
    {
        public TipoOABConfiguration()
            : this("dbo")
        {
        }

        public TipoOABConfiguration(string schema)
        {
            ToTable("TIPOOAB", schema);
            HasKey(x => x.IdTipoOAB);

            Property(x => x.IdTipoOAB                ).HasColumnName(@"IDTIPOOAB"            ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired();
            Property(x => x.Descricao                ).HasColumnName(@"DESCRICAO"            ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.IdUsuarioInclusao        ).HasColumnName(@"IDUSUARIOINCLUSAO"    ).HasColumnType("int"     ).IsOptional();
            Property(x => x.DtUsuarioInclusao        ).HasColumnName(@"DTUSUARIOINCLUSAO"    ).HasColumnType("datetime").IsOptional();
            Property(x => x.IdUsuarioAlteracao       ).HasColumnName(@"IDUSUARIOALTERACAO"   ).HasColumnType("int"     ).IsOptional();
            Property(x => x.DtUsuarioAlteracao       ).HasColumnName(@"DTUSUARIOALTERACAO"   ).HasColumnType("datetime").IsOptional();
            Property(x => x.Ativo                    ).HasColumnName(@"ATIVO"                ).HasColumnType("bit"     ).IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

