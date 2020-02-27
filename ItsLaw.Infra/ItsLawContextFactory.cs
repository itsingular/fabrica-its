


namespace ItsLaw.Infra
{
    using ItsLaw.Entidades;
    using ItsLaw.Infra.Mappings;

    public class ItsLawContextFactory : System.Data.Entity.Infrastructure.IDbContextFactory<ItsLawContext>
    {
        public ItsLawContext Create()
        {
            return new ItsLawContext();
        }
    }
}

