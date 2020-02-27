


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class ProcessoDocumentosConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ProcessoDocumentos>
    {
        public ProcessoDocumentosConfiguration()
            : this("dbo")
        {
        }

        public ProcessoDocumentosConfiguration(string schema)
        {
            ToTable("PROCESSO_DOCUMENTOS", schema);
            HasKey(x => new { x.IdMaster, x.IdProcesso, x.IdDocumento });

            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdProcesso               ).HasColumnName(@"IDPROCESSO"           ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdDocumento              ).HasColumnName(@"IDDOCUMENTO"          ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdTipoDocumento          ).HasColumnName(@"IDTIPODOCUMENTO"      ).HasColumnType("int"     ).IsRequired();
            Property(x => x.Documento                ).HasColumnName(@"DOCUMENTO"            ).HasColumnType("varbinary(max)").IsOptional();
            Property(x => x.IdUsuarioInclusao        ).HasColumnName(@"IDUSUARIOINCLUSAO"    ).HasColumnType("int"     ).IsRequired();
            Property(x => x.DtUsuarioInclusao        ).HasColumnName(@"DTUSUARIOINCLUSAO"    ).HasColumnType("datetime").IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

