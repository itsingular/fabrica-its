using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ItsLaw.Business;
using ItsLaw.Business.Interfaces;



namespace ItsLaw.Funcoes
{
    public sealed class UsuarioSession
    {
        private static volatile UsuarioSession instance;
        private static object sync = new Object();

        private UsuarioSession() { }

        public static UsuarioSession Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new UsuarioSession();
                        }
                    }
                }
                return instance;
            }

        }
        /// <summary>
        /// Propriedade para o ID do usuario na sessão
        /// </summary>
        public int    SessionMasterID     { get; set; }   //EGS 30.09.2018 - ID da empresa MASTER
        public int    SessionUserID       { get; set; }
        public int    SessionPerfilID     { get; set; }
        public string SessionUserLogin    { get; set; }
        public string SessionCompanyName  { get; set; }
        public string SessionUserName     { get; set; }
    }
}
 