using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItsLaw.Entidades;


namespace ItsLaw.Infra
{
    public class ItsLawBancoFuncoes
    {

        //--------------------------------------------------------------------------------------------- Funcoes Extras ----------------------
        //--------------------------------------------------------------------------------------------- Funcoes Extras ----------------------
        public static bool VerificaEmailDuplicado(int pID, string email)
        {
            using (ItsLawContext dc = new ItsLawContext())
            {
                var existeEmail = (from u in dc.Usuario where u.Email == email && u.IdUsuario!=pID select u).FirstOrDefault();
                if (existeEmail != null)
                    return true;
                else
                    return false;
            }
        }
    }
}
