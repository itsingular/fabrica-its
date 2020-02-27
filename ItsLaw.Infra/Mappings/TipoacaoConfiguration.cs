


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class TipoAcaoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TipoAcao>
    {
        public TipoAcaoConfiguration()
            : this("dbo")
        {
        }

        public TipoAcaoConfiguration(string schema)
        {
            ToTable("TIPOACAO", schema);
            HasKey(x => x.IdTipoAcao);

            Property(x => x.IdTipoAcao               ).HasColumnName(@"IDTIPOACAO"           ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired();
            Property(x => x.Descricao                ).HasColumnName(@"DESCRICAO"            ).HasColumnType("varchar" ).IsRequired().IsUnicode(false).HasMaxLength(50);
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

