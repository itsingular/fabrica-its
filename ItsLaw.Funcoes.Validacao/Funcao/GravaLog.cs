using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Globalization;
using System.Runtime.Serialization;
using System.Configuration;



namespace ItsLaw.Funcoes
{
    public class GravaLog
    {
        public void _GravaLog(string pMensagem)
        {
            string glbNomeArquivoLOG  = "ItsLaw.Error";

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
    }
}