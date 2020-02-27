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
    public class TabAuxiliarService : ITabAuxiliar
    {
        private readonly TabAuxiliarRepository _repositorio = new TabAuxiliarRepository();
        protected ItsLawContext                _contexto    = new ItsLawContext();

        public void Dispose()
        {
            _contexto.Dispose();
            _repositorio.Dispose();
        }

        public TabAuxiliar TabAuxiliarGetById(int id)
        {
            var saida = _repositorio.GetById(id);
            return saida;
        }

        public IEnumerable<TabAuxiliar> TabAuxiliarListagem()
        {
            //EGS 30.07.2018 - Incluindo nome dos usuarios de inclusao e manutencao e FUNCIONANDO !!
            var tabela = (from ifs      in _contexto.TabAuxiliar 
                          where ifs.Ativo.Equals(true)      //True
                          select new
                          {
                              IdTabAuxiliar           = ifs.IdTabAuxiliar,
                              Descricao               = ifs.Descricao,
                              Ativo                   = ifs.Ativo
                          }).ToList().Select(x => new TabAuxiliar()
                          {
                              IdTabAuxiliar           = x.IdTabAuxiliar,
                              Descricao               = x.Descricao,
                              Ativo                   = x.Ativo
                          }).ToList();

            return tabela;
        }

        //EGS 30.08.2018 ---- Traz sexo descricao
        public IEnumerable<TabAuxiliar> SexoListagem()
        {
            //EGS 30.07.2018 - Incluindo nome dos usuarios de inclusao e manutencao e FUNCIONANDO !!
            var tabela = (from ifs      in _contexto.TabAuxiliar 
                          where ifs.Filtro.Equals("SEXO")  
                             && ifs.Ativo.Equals(true)     //True
                          select new
                          {
                              IdTabAuxiliar           = ifs.IdTabAuxiliar,
                              Descricao               = ifs.Descricao

                          }).ToList().Select(x => new TabAuxiliar()
                          {
                              IdTabAuxiliar           = x.IdTabAuxiliar,
                              Descricao               = x.Descricao
                          }).ToList();

            return tabela;
        }

        //EGS 30.08.2018 ---- Traz Estados UF descricao
        public IEnumerable<TabAuxiliar> EstadoListagem()
        {
            //EGS 30.08.2018 - Listagem dos Estados Brasileiros...
            var tabela = (from ifs in _contexto.TabAuxiliar where ifs.Filtro.Equals("ESTADO") && ifs.Ativo.Equals(true)
                          select new
                          {
                              IdTabAuxiliar = ifs.IdTabAuxiliar,
                              Descricao = ifs.Descricao

                          }).ToList().Select(x => new TabAuxiliar()
                          {
                              IdTabAuxiliar = x.IdTabAuxiliar,
                              Descricao = x.Descricao
                          }).ToList();
            return tabela;
        }

        //EGS 30.08.2018 ---- Traz Estado Civil descricao
        public IEnumerable<TabAuxiliar> EstCivilListagem()
        {
            //EGS 30.07.2018 - Incluindo nome dos usuarios de inclusao e manutencao e FUNCIONANDO !!
            var tabela = (from ifs in _contexto.TabAuxiliar
                          where ifs.Filtro.Equals("ESTADOCIVIL") && ifs.Ativo.Equals(true)
                          select new
                          {
                              IdTabAuxiliar = ifs.IdTabAuxiliar,
                              Descricao = ifs.Descricao

                          }).ToList().Select(x => new TabAuxiliar()
                          {
                              IdTabAuxiliar = x.IdTabAuxiliar,
                              Descricao = x.Descricao
                          }).ToList();
            return tabela;

        }

        public IEnumerable<TabAuxiliar> TabAuxiliarPesquisar(Expression<Func<TabAuxiliar, bool>> filtro)
        {
            var saida = _repositorio.Find(filtro);
            return saida;
        }
    }
}
