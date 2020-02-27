


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class StatusProcessoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<StatusProcesso>
    {
        public StatusProcessoConfiguration()
            : this("dbo")
        {
        }

        public StatusProcessoConfiguration(string schema)
        {
            ToTable("STATUSPROCESSO", schema);
            HasKey(x => x.IdStatusProcesso);

            Property(x => x.IdStatusProcesso         ).HasColumnName(@"IDSTATUSPROCESSO"     ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired();
            Property(x => x.Codigo                   ).HasColumnName(@"CODIGO"               ).HasColumnType("varchar" ).IsRequired().IsUnicode(false).HasMaxLength(15);
            Property(x => x.Descricao                ).HasColumnName(@"DESCRICAO"            ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.CorGrid                  ).HasColumnName(@"CORGRID"              ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(20);
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

