


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class ReclamanteConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Reclamante>
    {
        public ReclamanteConfiguration()
            : this("dbo")
        {
        }

        public ReclamanteConfiguration(string schema)
        {
            ToTable("RECLAMANTE", schema);
            HasKey(x => x.IdReclamante);

            Property(x => x.IdReclamante             ).HasColumnName(@"IDRECLAMANTE"         ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired();
            Property(x => x.CpfCnpj                  ).HasColumnName(@"CPFCNPJ"              ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(x => x.Nome                     ).HasColumnName(@"NOME"                 ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(150);
            Property(x => x.Cep                      ).HasColumnName(@"CEP"                  ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(9);
            Property(x => x.Logradouro               ).HasColumnName(@"LOGRADOURO"           ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Numero                   ).HasColumnName(@"NUMERO"               ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(x => x.Complemento              ).HasColumnName(@"COMPLEMENTO"          ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength( 50);
            Property(x => x.Bairro                   ).HasColumnName(@"BAIRRO"               ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Cidade                   ).HasColumnName(@"CIDADE"               ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.IDEstado                 ).HasColumnName(@"IDESTADO"             ).HasColumnType("int"     ).IsOptional();
            Property(x => x.IDSexo                   ).HasColumnName(@"IDSEXO"               ).HasColumnType("int"     ).IsOptional();
            Property(x => x.IDEstadoCivil            ).HasColumnName(@"IDESTADOCIVIL"        ).HasColumnType("int"     ).IsOptional();
            Property(x => x.Email                    ).HasColumnName(@"EMAIL"                ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(150);
            Property(x => x.Telefone                 ).HasColumnName(@"TELEFONE"             ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(x => x.Celular                  ).HasColumnName(@"CELULAR"              ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(20);
            Property(x => x.DataNascimento           ).HasColumnName(@"DATANASCIMENTO"       ).HasColumnType("date"    ).IsOptional();
            Property(x => x.Profissao                ).HasColumnName(@"PROFISSAO"            ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
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

