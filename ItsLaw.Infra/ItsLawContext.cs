namespace ItsLaw.Infra
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra.Mappings;


    
    public partial class ItsLawContext : System.Data.Entity.DbContext
    {
        public System.Data.Entity.DbSet<Advogado> Advogado                              { get; set; }
        public System.Data.Entity.DbSet<Empresa> Empresa                                { get; set; }
        public System.Data.Entity.DbSet<Escritorio> Escritorio                          { get; set; }
        public System.Data.Entity.DbSet<Testemunha> Testemunha                          { get; set; }
        public System.Data.Entity.DbSet<Usuario> Usuario                                { get; set; }
        public System.Data.Entity.DbSet<UsuarioPath> UsuarioPath                        { get; set; }
        public System.Data.Entity.DbSet<UsuarioPerfil> UsuarioPerfil                    { get; set; }
        public System.Data.Entity.DbSet<UsuarioPerfilDireito> UsuarioPerfilDireito      { get; set; }
        public System.Data.Entity.DbSet<StatusProcesso> StatusProcesso                  { get; set; }
        public System.Data.Entity.DbSet<Comarca> Comarca                                { get; set; }
        public System.Data.Entity.DbSet<TabAuxiliar> TabAuxiliar                        { get; set; }
        public System.Data.Entity.DbSet<TipoAcao> TipoAcao                              { get; set; }
        public System.Data.Entity.DbSet<TipoJustica> TipoJustica                        { get; set; }
        public System.Data.Entity.DbSet<TipoAreaDireito> TipoAreaDireito                { get; set; }
        public System.Data.Entity.DbSet<TipoOAB> TipoOAB                                { get; set; }
        public System.Data.Entity.DbSet<ParteContraria> ParteContraria                  { get; set; }
        public System.Data.Entity.DbSet<Reclamante> Reclamante                          { get; set; }                                                                                        
        public System.Data.Entity.DbSet<Processo> Processo                              { get; set; }
        public System.Data.Entity.DbSet<ProcessoAdvogado> ProcessoAdvogado              { get; set; }
        public System.Data.Entity.DbSet<ProcessoDocumentos> ProcessoDocumentos          { get; set; }
        public System.Data.Entity.DbSet<ProcessoHistorico> ProcessoHistorico            { get; set; }
        public System.Data.Entity.DbSet<ProcessoPartecontraria> ProcessoPartecontraria  { get; set; }
        public System.Data.Entity.DbSet<ProcessoReclamante> ProcessoReclamante          { get; set; }
        public System.Data.Entity.DbSet<ProcessoTestemunha> ProcessoTestemunha          { get; set; }

        static ItsLawContext()
        {
            System.Data.Entity.Database.SetInitializer<ItsLawContext>(null);
        }

        public ItsLawContext()
            : base("Name=ItsLawConnection")
        {
            InitializePartial();
        }

        public ItsLawContext(string connectionString)
            : base(connectionString)
        {
            InitializePartial();
        }

        public ItsLawContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
            InitializePartial();
        }

        public ItsLawContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            InitializePartial();
        }

        public ItsLawContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
            InitializePartial();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AdvogadoConfiguration               ());
            modelBuilder.Configurations.Add(new EmpresaConfiguration                ());
            modelBuilder.Configurations.Add(new EscritorioConfiguration             ());
            modelBuilder.Configurations.Add(new TestemunhaConfiguration             ());
            modelBuilder.Configurations.Add(new UsuarioConfiguration                ());
            modelBuilder.Configurations.Add(new UsuarioPathConfiguration            ());
            modelBuilder.Configurations.Add(new UsuarioPerfilConfiguration          ());
            modelBuilder.Configurations.Add(new UsuarioPerfilDireitoConfiguration   ());
            modelBuilder.Configurations.Add(new StatusProcessoConfiguration         ());
            modelBuilder.Configurations.Add(new ComarcaConfiguration                ());
            modelBuilder.Configurations.Add(new TipoAcaoConfiguration               ());
            modelBuilder.Configurations.Add(new TabAuxiliarConfiguration            ());
            modelBuilder.Configurations.Add(new TipoJusticaConfiguration            ());
            modelBuilder.Configurations.Add(new TipoAreaDireitoConfiguration        ());
            modelBuilder.Configurations.Add(new TipoOABConfiguration                ());
            modelBuilder.Configurations.Add(new ParteContrariaConfiguration         ());
            modelBuilder.Configurations.Add(new ReclamanteConfiguration             ());
            modelBuilder.Configurations.Add(new ProcessoConfiguration               ());
            modelBuilder.Configurations.Add(new ProcessoAdvogadoConfiguration       ());
            modelBuilder.Configurations.Add(new ProcessoDocumentosConfiguration     ());
            modelBuilder.Configurations.Add(new ProcessoHistoricoConfiguration      ());
            modelBuilder.Configurations.Add(new ProcessoPartecontrariaConfiguration ());
            modelBuilder.Configurations.Add(new ProcessoReclamanteConfiguration     ());
            modelBuilder.Configurations.Add(new ProcessoTestemunhaConfiguration     ());

            OnModelCreatingPartial(modelBuilder);
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AdvogadoConfiguration               (schema));
            modelBuilder.Configurations.Add(new EmpresaConfiguration                (schema));
            modelBuilder.Configurations.Add(new EscritorioConfiguration             (schema));
            modelBuilder.Configurations.Add(new TestemunhaConfiguration             (schema));
            modelBuilder.Configurations.Add(new UsuarioConfiguration                (schema));
            modelBuilder.Configurations.Add(new UsuarioPathConfiguration            (schema));
            modelBuilder.Configurations.Add(new UsuarioPerfilConfiguration          (schema));
            modelBuilder.Configurations.Add(new UsuarioPerfilDireitoConfiguration   (schema));
            modelBuilder.Configurations.Add(new StatusProcessoConfiguration         (schema));
            modelBuilder.Configurations.Add(new ComarcaConfiguration                (schema));
            modelBuilder.Configurations.Add(new TipoAcaoConfiguration               (schema));
            modelBuilder.Configurations.Add(new TabAuxiliarConfiguration            (schema));
            modelBuilder.Configurations.Add(new TipoJusticaConfiguration            (schema));
            modelBuilder.Configurations.Add(new TipoAreaDireitoConfiguration        (schema));
            modelBuilder.Configurations.Add(new TipoOABConfiguration                (schema));
            modelBuilder.Configurations.Add(new ParteContrariaConfiguration         (schema));
            modelBuilder.Configurations.Add(new ReclamanteConfiguration             (schema));
            modelBuilder.Configurations.Add(new ProcessoConfiguration               (schema));
            modelBuilder.Configurations.Add(new ProcessoAdvogadoConfiguration       (schema));
            modelBuilder.Configurations.Add(new ProcessoDocumentosConfiguration     (schema));
            modelBuilder.Configurations.Add(new ProcessoHistoricoConfiguration      (schema));
            modelBuilder.Configurations.Add(new ProcessoPartecontrariaConfiguration (schema));
            modelBuilder.Configurations.Add(new ProcessoReclamanteConfiguration     (schema));
            modelBuilder.Configurations.Add(new ProcessoTestemunhaConfiguration     (schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(System.Data.Entity.DbModelBuilder modelBuilder);
    }
}

