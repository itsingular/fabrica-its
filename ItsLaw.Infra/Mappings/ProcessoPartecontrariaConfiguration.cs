


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class ProcessoPartecontrariaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ProcessoPartecontraria>
    {
        public ProcessoPartecontrariaConfiguration()
            : this("dbo")
        {
        }

        public ProcessoPartecontrariaConfiguration(string schema)
        {
            ToTable("PROCESSO_PARTECONTRARIA", schema);
            HasKey(x => new { x.IdMaster, x.IdProcesso, x.IdParteContraria });

            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdProcesso               ).HasColumnName(@"IDPROCESSO"           ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdParteContraria         ).HasColumnName(@"IDPARTECONTRARIA"     ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdUsuarioInclusao        ).HasColumnName(@"IDUSUARIOINCLUSAO"    ).HasColumnType("int"     ).IsRequired();
            Property(x => x.DtUsuarioInclusao        ).HasColumnName(@"DTUSUARIOINCLUSAO"    ).HasColumnType("datetime").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

