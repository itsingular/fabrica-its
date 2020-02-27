using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace ItsLaw.Business.Interfaces
{
    public interface ITabAuxiliar
    {
        TabAuxiliar              TabAuxiliarGetById      (Int32 id);
        IEnumerable<TabAuxiliar> TabAuxiliarListagem     ();
        IEnumerable<TabAuxiliar> SexoListagem();
        IEnumerable<TabAuxiliar> EstadoListagem();
        IEnumerable<TabAuxiliar> EstCivilListagem();
    }
}
