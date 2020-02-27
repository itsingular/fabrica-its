using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Infra.Repository;
using ItsLaw.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace ItsLaw.Business
{
    public class UsuarioPathService : IUsuarioPath
    {
        private readonly UsuarioPathRepository _repositorio = new UsuarioPathRepository();
        protected ItsLawContext _contexto = new ItsLawContext();

        public void Dispose()
        {
            _contexto.Dispose();
            _repositorio.Dispose();
        }
        
        public void Add(UsuarioPath itens)
        {
            _repositorio.Add(itens);
        }

        public UsuarioPath GetById(int id)
        {
            var saida = _repositorio.GetById(id);
            return saida;
        }

        public IEnumerable<UsuarioPath> Listagem()
        {
            var tabela = (from ifs in _contexto.UsuarioPath where ifs.Ativo.Equals(true) select ifs).ToList();
            return tabela;
        }

        public IEnumerable<UsuarioPath> Pesquisar(Expression<Func<UsuarioPath, bool>> filtro)
        {
            var saida = _repositorio.Find(filtro);
            return saida;
        }

        public void Update(UsuarioPath itens)
        {
            _repositorio.Update(itens);
        }
    }
}
