


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class ComarcaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Comarca>
    {
        public ComarcaConfiguration()
            : this("dbo")
        {
        }

        public ComarcaConfiguration(string schema)
        {
            ToTable("COMARCA", schema);
            HasKey(x => x.IdComarca);

            Property(x => x.IdComarca                ).HasColumnName(@"IDCOMARCA"            ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired();
            Property(x => x.Descricao                ).HasColumnName(@"DESCRICAO"            ).HasColumnType("varchar" ).IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Endereco                 ).HasColumnName(@"ENDERECO"             ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(150);
            Property(x => x.Bairro                   ).HasColumnName(@"BAIRRO"               ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Cidade                   ).HasColumnName(@"CIDADE"               ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Estado                   ).HasColumnName(@"ESTADO"               ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(2);
            Property(x => x.Telefone                 ).HasColumnName(@"TELEFONE"             ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(20);
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

