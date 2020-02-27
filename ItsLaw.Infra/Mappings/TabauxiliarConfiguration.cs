


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class TabAuxiliarConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TabAuxiliar>
    {
        public TabAuxiliarConfiguration()
            : this("dbo")
        {
        }

        public TabAuxiliarConfiguration(string schema)
        {
            ToTable("TABAUXILIAR", schema);
            HasKey(x => x.IdTabAuxiliar);

            Property(x => x.IdTabAuxiliar            ).HasColumnName(@"IDTABAUXILIAR"        ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Filtro                   ).HasColumnName(@"FILTRO"               ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(x => x.Codigo                   ).HasColumnName(@"CODIGO"               ).HasColumnType("varchar" ).IsRequired().IsUnicode(false).HasMaxLength(10);
            Property(x => x.Descricao                ).HasColumnName(@"DESCRICAO"            ).HasColumnType("varchar" ).IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Ativo                    ).HasColumnName(@"ATIVO"                ).HasColumnType("bit"     ).IsRequired();

            InitializePartial();
        }
        partial void InitializePartial();
    }

}

