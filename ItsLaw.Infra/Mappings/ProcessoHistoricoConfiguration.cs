


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class ProcessoHistoricoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ProcessoHistorico>
    {
        public ProcessoHistoricoConfiguration()
            : this("dbo")
        {
        }

        public ProcessoHistoricoConfiguration(string schema)
        {
            ToTable("PROCESSO_HISTORICO", schema);
            HasKey(x => new { x.IdMaster, x.IdProcesso, x.IdHistorico });

            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdProcesso               ).HasColumnName(@"IDPROCESSO"           ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdHistorico              ).HasColumnName(@"IDHISTORICO"          ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdEvento                 ).HasColumnName(@"IDEVENTO"             ).HasColumnType("int"     ).IsRequired();
            Property(x => x.DtEvento                 ).HasColumnName(@"DTEVENTO"             ).HasColumnType("datetime").IsRequired();
            Property(x => x.Descricao                ).HasColumnName(@"DESCRICAO"            ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(500);

            InitializePartial();
        }
        partial void InitializePartial();
    }

}

