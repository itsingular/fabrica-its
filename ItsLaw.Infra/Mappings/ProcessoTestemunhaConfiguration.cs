


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class ProcessoTestemunhaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ProcessoTestemunha>
    {
        public ProcessoTestemunhaConfiguration()
            : this("dbo")
        {
        }

        public ProcessoTestemunhaConfiguration(string schema)
        {
            ToTable("PROCESSO_TESTEMUNHA", schema);
            HasKey(x => new { x.IdMaster, x.IdProcesso, x.IdTestemunha });

            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdProcesso               ).HasColumnName(@"IDPROCESSO"           ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdTestemunha             ).HasColumnName(@"IDTESTEMUNHA"         ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdUsuarioInclusao        ).HasColumnName(@"IDUSUARIOINCLUSAO"    ).HasColumnType("int"     ).IsRequired();
            Property(x => x.DtUsuarioInclusao        ).HasColumnName(@"DTUSUARIOINCLUSAO"    ).HasColumnType("datetime").IsRequired();

            InitializePartial();
        }
        partial void InitializePartial();
    }

}

