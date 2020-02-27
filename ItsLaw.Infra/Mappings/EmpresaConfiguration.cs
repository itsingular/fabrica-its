


namespace ItsLaw.Infra.Mappings
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra;

    
    public partial class EmpresaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
            : this("dbo")
        {
        }

        public EmpresaConfiguration(string schema)
        {
            ToTable("EMPRESA", schema);
            HasKey(x => x.IdEmpresa);

            Property(x => x.IdEmpresa                ).HasColumnName(@"IDEMPRESA"            ).HasColumnType("int"     ).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdMaster                 ).HasColumnName(@"IDMASTER"             ).HasColumnType("int"     ).IsRequired();
            Property(x => x.CpfCnpj                  ).HasColumnName(@"CPFCNPJ"              ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength( 20);
            Property(x => x.Fantasia                 ).HasColumnName(@"FANTASIA"             ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength( 50);
            Property(x => x.Nome                     ).HasColumnName(@"NOME"                 ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(150);
            Property(x => x.Cep                      ).HasColumnName(@"CEP"                  ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(  9);
            Property(x => x.Logradouro               ).HasColumnName(@"LOGRADOURO"           ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(200);
            Property(x => x.Numero                   ).HasColumnName(@"NUMERO"               ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength( 20);
            Property(x => x.Complemento              ).HasColumnName(@"COMPLEMENTO"          ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength( 50);
            Property(x => x.Bairro                   ).HasColumnName(@"BAIRRO"               ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Cidade                   ).HasColumnName(@"CIDADE"               ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.IDEstado                 ).HasColumnName(@"IDESTADO"             ).HasColumnType("int"     ).IsOptional();
            Property(x => x.WebSite                  ).HasColumnName(@"WEBSITE"              ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(150);
            Property(x => x.EmailPrincipal           ).HasColumnName(@"EMAILPRINCIPAL"       ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength( 20);
            Property(x => x.EmailContato             ).HasColumnName(@"EMAILCONTATO"         ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(150);
            Property(x => x.Telefone                 ).HasColumnName(@"TELEFONE"             ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength( 20);
            Property(x => x.Celular                  ).HasColumnName(@"CELULAR"              ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength( 20);
            Property(x => x.Contato                  ).HasColumnName(@"CONTATO"              ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.CNAE                     ).HasColumnName(@"CNAE"                 ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength( 20);
            Property(x => x.InscricaoEstadual        ).HasColumnName(@"INSCRICAOESTADUAL"    ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.InscricaoMunicipal       ).HasColumnName(@"INSCRICAOMUNICIPAL"   ).HasColumnType("varchar" ).IsOptional().IsUnicode(false).HasMaxLength(100);
            Property(x => x.Logotipo                 ).HasColumnName(@"LOGOTIPO"             ).HasColumnType("varbinary(MAX)").IsOptional();
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

