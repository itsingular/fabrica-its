


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class ProcessoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Processo>
    {
        public ProcessoConfiguration()
            : this("dbo")
        {
        }

        public ProcessoConfiguration(string schema)
        {
            ToTable("PROCESSO", schema);
            HasKey(x => x.IdProcesso);

            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired();
            Property(x => x.IdProcesso               ).HasColumnName(@"IDPROCESSO"           ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdTipoAcao               ).HasColumnName(@"IDTIPOACAO"           ).HasColumnType("int"     ).IsRequired();
            Property(x => x.IdTipoJustica            ).HasColumnName(@"IDTIPOJUSTICA"        ).HasColumnType("int"     ).IsRequired();
            Property(x => x.IdTipoAreaDireito        ).HasColumnName(@"IDTIPOAREADIREITO"    ).HasColumnType("int"     ).IsRequired();
            Property(x => x.IdComarca                ).HasColumnName(@"IDCOMARCA"            ).HasColumnType("int"     ).IsRequired();
            Property(x => x.IdEmpresa                ).HasColumnName(@"IDEMPRESA"            ).HasColumnType("int"     ).IsRequired();
            Property(x => x.IdEscritorio             ).HasColumnName(@"IDESCRITORIO"         ).HasColumnType("int"     ).IsRequired();
            Property(x => x.IdEstado                 ).HasColumnName(@"IDESTADO"             ).HasColumnType("int"     ).IsRequired();
            Property(x => x.Codigo                   ).HasColumnName(@"CODIGO"               ).HasColumnType("varchar" ).IsRequired().IsUnicode(false).HasMaxLength(50);
            Property(x => x.CodInterno               ).HasColumnName(@"CODINTERNO"           ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(50);
            Property(x => x.PastaFisica              ).HasColumnName(@"PASTAFISICA"          ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(500);
            Property(x => x.IdStatusProcesso         ).HasColumnName(@"IDSTATUSPROCESSO"     ).HasColumnType("int"     ).IsRequired();
            Property(x => x.IdUsuarioInclusao        ).HasColumnName(@"IDUSUARIOINCLUSAO"    ).HasColumnType("int"     ).IsRequired();
            Property(x => x.DtUsuarioInclusao        ).HasColumnName(@"DTUSUARIOINCLUSAO"    ).HasColumnType("datetime").IsRequired();
            Property(x => x.IdUsuarioAlteracao       ).HasColumnName(@"IDUSUARIOALTERACAO"   ).HasColumnType("int"     ).IsOptional();
            Property(x => x.DtUsuarioAlteracao       ).HasColumnName(@"DTUSUARIOALTERACAO"   ).HasColumnType("datetime").IsOptional();
            Property(x => x.Ativo                    ).HasColumnName(@"ATIVO"                ).HasColumnType("bit"     ).IsRequired();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

