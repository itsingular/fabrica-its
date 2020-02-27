using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace ItsLaw.Business.Interfaces
{
    public interface IEmpresa
    {
        Empresa              EmpresaGetById      (Int32 id);
        IEnumerable<Empresa> EmpresaPesquisar    (Expression<Func<Empresa, Boolean>> filtro);
        IEnumerable<Empresa> EmpresaListagem     (int pIDMaster);
        void                 EmpresaAdd          (Empresa itens);
        void                 EmpresaUpdate       (Empresa itens);
    }
}
