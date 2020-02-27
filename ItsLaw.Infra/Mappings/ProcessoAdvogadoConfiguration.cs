


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class ProcessoAdvogadoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ProcessoAdvogado>
    {
        public ProcessoAdvogadoConfiguration()
            : this("dbo")
        {
        }

        public ProcessoAdvogadoConfiguration(string schema)
        {
            ToTable("PROCESSO_ADVOGADO", schema);
            HasKey(x => new { x.IdMaster, x.IdProcesso, x.IdAdvogado });

            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdProcesso               ).HasColumnName(@"IDPROCESSO"           ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdAdvogado               ).HasColumnName(@"IDADVOGADO"           ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdUsuarioInclusao        ).HasColumnName(@"IDUSUARIOINCLUSAO"    ).HasColumnType("int"     ).IsRequired();
            Property(x => x.DtUsuarioInclusao        ).HasColumnName(@"DTUSUARIOINCLUSAO"    ).HasColumnType("datetime").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

