using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItsLaw.Entidades;


namespace ItsLaw.Funcoes
{
    public class ItsLawFuncoes
    {

        //--------------------------------------------------------------------------------------------- Funcoes Extras ----------------------
        //--------------------------------------------------------------------------------------------- Funcoes Extras ----------------------
        public static string _ServidorWebAPI_Caminho()
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get("glbWebAPI_Servidor");
        }
    }
}
