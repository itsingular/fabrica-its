using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;


namespace ItsLaw.Infra
{
    public class CriptoDescripto
    {
        //Pega uma string e gera MD5
        public string RetornarMD5(string Senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return RetonarHash(md5Hash, Senha);
            }
        }


        //Descriptografa -------------------------------------------------------------------------------------------------
        //MD5 não é reversível, ou seja, só é possível criar o hash(ou, como você disse, criptografar) e comparar com outro hash.
        //Se forem iguais, a senha digitada é considerada a mesma.


        //Compara os Hash
        public bool ComparaMD5(string senhabanco, string Senha_MD5)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var senha = RetornarMD5(senhabanco);
                if (Senha_MD5 ==  senhabanco)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Retorna o HSD
        private string RetonarHash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }


        private bool VerificarHash(MD5 md5Hash, string input, string hash)
        {
            StringComparer compara = StringComparer.OrdinalIgnoreCase;

            if (0 == compara.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /*  EGS IT Singular
         *  30.09.2018
         *  Retorno o ID Master da empresa contratante, pego no WEB.CONFIG
         */
        public int RetornaIDMaster()
        {
            int bIDMaster = 0;
            try
            {
                bIDMaster = (Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("glbIDEmpresaMaster")) - 1817453);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Problemas ao verificar a EMPRESA MASTER" + ex.Message);
            }
            return bIDMaster;
        }
    }




    //Nova TransFolha 15.12.2018 ---------------------------------------------------------------------------------
    //Nova TransFolha 15.12.2018 ---------------------------------------------------------------------------------
    //Nova TransFolha 15.12.2018 ---------------------------------------------------------------------------------
    public class clsCriptografiaFolha
    {
        #region | Métodos Públicos

        public string AdicionarCriptografia(string pStrValorSemCriptografia)
        {
            string lStrResultado = string.Empty;
            byte[] lArrByteMensagem = System.Text.Encoding.Default.GetBytes(pStrValorSemCriptografia);// Criar o Hash Code
            MD5CryptoServiceProvider lObjMD5Provider = new MD5CryptoServiceProvider();
            byte[] lArrByteHashCode = lObjMD5Provider.ComputeHash(lArrByteMensagem);

            for (int i = 0; i < lArrByteHashCode.Length; i++)
            {
                lStrResultado += (char)(lArrByteHashCode[i]);
            }

            return lStrResultado;
        }

        public string RemoverCriptografia(string pStrValorComCriptografia)
        {
            string lStrResultado = string.Empty;
            byte[] lArrByteMensagem = System.Text.Encoding.Default.GetBytes(pStrValorComCriptografia);// Criar o Hash Code
            MD5CryptoServiceProvider lObjMd5Provider = new MD5CryptoServiceProvider();
            byte[] lArrByteHashCode = lObjMd5Provider.ComputeHash(lArrByteMensagem);

            for (int i = 0; i < lArrByteHashCode.Length; i++)
            {
                lStrResultado += (char)(lArrByteHashCode[i]);
            }
            return lStrResultado;
        }
    }
    #endregion
}
