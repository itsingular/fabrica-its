using ItsLaw.Entidades.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ItsLaw.Infra.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected ItsLawContext Db = new ItsLawContext();


        public void Add(TEntity obj)
        {
            try
            {
                Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
                Db.Set<TEntity>().Add(obj);
                Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Insert não pode ser executado por falta de preenchimento de campos: " + ex.Message);
            }
        }
        public TEntity GetById(int id)
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            try
            {
                Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
                Db.Entry(obj).State = EntityState.Modified;
                Db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Alteração não pode ser executado pelo seguinte erro: " + ex.Message + " " + ex.InnerException + " " + ex.Data.ToString() );
            }
        }

        public void Remove(TEntity obj)
        {
            Db.Database.Log = (s) => System.Diagnostics.Debug.Write(s);
            Db.Entry(obj).State = EntityState.Deleted;
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, Boolean>> filtro)
        {
            return Db.Set<TEntity>().AsNoTracking().Where(filtro).ToList();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}

