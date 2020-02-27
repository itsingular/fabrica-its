using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Globalization;
using System.Runtime.Serialization;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;



namespace ItsLaw.WebAPI.Mobile
{
    public class GravaLogAPI
    {
        public void _GravaLog(string pMensagem)
        {
            string glbNomeArquivoLOG  = "ItsLaw.WebAPI.Mobile";

            DateTime dataAgora = DateTime.Now;
            string Nomefolder  = @"C:\\TEMP\\";
            string NomeArquivo =  "C:\\TEMP\\" + glbNomeArquivoLOG + "_" + dataAgora.ToString("yyyy-MM-dd") + ".log";

            if (!Directory.Exists(Nomefolder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(Nomefolder);
            }


            //EGS 30.01.2019 - Remover quebra de linha
            var tab = '\u0009';
            pMensagem = pMensagem.Replace("  "   , " ");
            pMensagem = pMensagem.Replace("=\r\n", "" );
            pMensagem = pMensagem.Replace(";\r\n", "" );
            pMensagem = pMensagem.Replace("\r\n" , "" );
            pMensagem = pMensagem.Replace("\t"   , " ");
            pMensagem = pMensagem.Replace(tab.ToString(), "");


            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@NomeArquivo, true))
            {
                writer.WriteLine(dataAgora.ToString() + " - " + pMensagem);

                //Fechando o arquivo
                writer.Close();

                //Limpando a referencia dele da memória
                writer.Dispose();
            }
        }




         /* ===========================================================================================
         *  Edinaldo IT Singular / Thiago Aoki Kenko TransFolha
         *  Jan/2019 
         *  Métodos para gravar em arquivo texto assincrono
         ===========================================================================================*/
        public async Task _GravaLogAsync(string pMensagem)
        {
            string glbNomeArquivoLOG = "TransFolha.API";

            DateTime dataAgora = DateTime.Now;
            string Nomefolder  = @"C:\\TEMP\\";
            string NomeArquivo =  "C:\\TEMP\\" + glbNomeArquivoLOG + "_" + dataAgora.ToString("yyyy-MM-dd") + ".log";

            if (!Directory.Exists(Nomefolder))
            {
                //Criamos um com o nome folder
                Directory.CreateDirectory(Nomefolder);
            }

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@NomeArquivo, true))
            {
                try
                {
                    await writer.WriteLineAsync(dataAgora.ToString() + " - " + pMensagem);
                }
                finally
                {
                }
            }
        }

        /* ===========================================================================================
         *  Edinaldo IT Singular
         *  Jan/2019 
         *  Mostra alerta na tela
         ===========================================================================================*/
        public void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>alert('" + msg + "')</script>";
            //Page.Controls.Add(lbl);
        }
    }
}