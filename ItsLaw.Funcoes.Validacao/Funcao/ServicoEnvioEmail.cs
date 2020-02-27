using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;



namespace ItsLaw.Funcoes
{

    public class ServicoEnvioEmail
    {
        //EGS 30.11.2018 - Pega email e senha para envio do email no web-config
        private GravaLog _LogGrava = new GravaLog();
        private string glbEmailAutomatico_Smtp     = System.Configuration.ConfigurationManager.AppSettings.Get("glbEmailAutomatico_Smtp"    );
        private string glbEmailAutomatico_Fantasia = System.Configuration.ConfigurationManager.AppSettings.Get("glbEmailAutomatico_Fantasia");
        private string glbEmailAutomatico_Conta    = System.Configuration.ConfigurationManager.AppSettings.Get("glbEmailAutomatico_Conta"   );
        private string glbEmailAutomatico_Senha    = System.Configuration.ConfigurationManager.AppSettings.Get("glbEmailAutomatico_Senha"   );
        private string glbWebAPI_Servidor          = ItsLawFuncoes._ServidorWebAPI_Caminho();

        /* ======================================================================================================
        *     ROTINA DE ENVIO DE EMAIL - INCLUIR USUARIO
        *     NOV-2018 - EDINALDO
        ========================================================================================================= */
        public bool EnvioEmail_IncluirUsuario (Usuario item)
        {
            bool bRetorno = false;
            if (item == null) { return bRetorno; }

            string sUsuarioEmail   = item.Email.ToLower().Trim();
            string sUsuCopiaEmail  = "edinaldo.silva@onwork.com.br, gdomingues@itsingular.com.br";
            string sUsuarioNome    = item.Nome.ToUpper().Trim();
            string sUsuApelido     = item.Apelido.ToUpper().Trim();
            string sUsuarioAssunto = "ItsLaw - Usuario [" + sUsuApelido + "] Criado";
            string sUsuarioCorpo   = "It´s Law - Email Automatico:<br/><br/>" +
                                     "Prezado(a) " + sUsuApelido + " seja bem vindo(a) ao sistema<br><strong>Its´Law Gestão de Contencioso</strong>.<br/><br/>" +
                                     "Para <strong>confirmar seu cadastro</strong> clique no link abaixo: <br/><br/>" +
                                     "Link:<br>" + glbWebAPI_Servidor + "/api/UsuarioValidaCadastroAPI?pGuid=" + item.CodigoAtivacao.ToString() + " <br/><br/>" +
                                     "   <br>" +
                                     "   <br>" +
                                     "Atenciosamente,<br>" +
                                     "<br>" +
                                     "---------------------------------------<br>" +
                                     "Equipe It's Law - Gestão de Contencioso";
            //==================================================================================================
            //==================================================================================================
            bRetorno = ServicoEfetivoEnvioEmail(sUsuarioEmail, sUsuCopiaEmail, sUsuApelido, sUsuarioNome, sUsuarioAssunto, sUsuarioCorpo);
            //==================================================================================================
            //==================================================================================================
            return bRetorno;
        }




        /* ======================================================================================================
        *     ROTINA DE ENVIO DE EMAIL - RECUPERACAO DE SENHA DE USUARIO
        *     NOV-2018 - EDINALDO
        ========================================================================================================= */
        public bool EnvioEmail_UsuarioRecuperarSenha (Usuario item)
        {
            bool bRetorno = false;
            if (item == null) { return bRetorno; }
            if (item.CodigoAtivacao.ToString() == "") { return bRetorno; }

            string sUsuarioEmail   = item.Email.ToLower().Trim();
            string sUsuCopiaEmail  = "edinaldo.silva@onwork.com.br, gdomingues@itsingular.com.br"; //item.Email.ToLower().Trim();
            string sUsuarioNome    = item.Nome.ToUpper().Trim();
            string sUsuApelido     = item.Apelido.ToUpper().Trim();
            string sUsuarioAssunto = "ItsLaw - Usuario [" + sUsuApelido + "] Solicitou Recuperação de Senha";
            string sUsuarioCorpo   = "It´s Law - Email Automatico:<br/><br/>" +
                                     "Prezado(a) " + sUsuApelido + " foi solicitado a recuperação de sua senha.<br/><br/>" +
                                     "Para <strong>gerar nova senha criptografada</strong> clique no link abaixo: <br/><br/>" +
                                     "Link:<br>" + glbWebAPI_Servidor + "/api/UsuarioRecuperarSenhaAPI?pGuid=" + item.CodigoAtivacao.ToString() + " <br/><br/>" +
                                     "   <br>" +
                                     "   <br>" +
                                     "<strong>Atenção:</strong>   <br>" +
                                     "Caso você não tenha solicitado essa recuperação de senha, entre em contato com o administrador do sistema. <br><br><br>" +
                                     "Atenciosamente,<br>" +
                                     "<br>" +
                                     "---------------------------------------<br>" +
                                     "Equipe It's Law - Gestão de Contencioso";
            //==================================================================================================
            //==================================================================================================
            bRetorno = ServicoEfetivoEnvioEmail(sUsuarioEmail, sUsuCopiaEmail, sUsuApelido, sUsuarioNome, sUsuarioAssunto, sUsuarioCorpo);
            //==================================================================================================
            //==================================================================================================
            return bRetorno;
        }











        /* ======================================================================================================
        *     ROTINA DE ENVIO DE EMAIL - INCLUIR USUARIO
        *     NOV-2018 - EDINALDO
        ========================================================================================================= */
        private bool ServicoEfetivoEnvioEmail(string pEmail, string pCopia, string pApelido, string pNome, string pEmailAssunto, string pEmailCorpo)
        {
            bool bRetorno = false;
            if (pEmail == null) { return bRetorno; }

            string sUsuarioEmail   = pEmail;
            string sUsuCopiaEmail  = pCopia;
            string sUsuarioNome    = pNome;
            string sUsuApelido     = pApelido;
            string sUsuarioAssunto = pEmailAssunto;
            string sUsuarioCorpo   = pEmailCorpo;
            //http://www.macoratti.net/15/10/mvc_cnfrec1.htm

            //Create Mail Message Object with content that you want to send with mail.
            System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage();
            MyMailMessage.From       = new MailAddress(glbEmailAutomatico_Conta, glbEmailAutomatico_Fantasia); 
            MyMailMessage.Subject    = sUsuarioAssunto; 
            MyMailMessage.Body       = sUsuarioCorpo;
            MyMailMessage.IsBodyHtml = true;
            MyMailMessage.To.Add(new MailAddress(sUsuarioEmail, sUsuarioNome));
            MyMailMessage.Bcc.Add(sUsuCopiaEmail);

            //Proper Authentication Details need to be passed when sending email from gmail
            System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(glbEmailAutomatico_Conta, glbEmailAutomatico_Senha);

            //Smtp Mail server of Gmail is "smpt.gmail.com" and it uses port no. 587 //For different server like yahoo this details changes and you can
            System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient(glbEmailAutomatico_Smtp, 587);

            //Enable SSL
            mailClient.EnableSsl             = false;
            mailClient.UseDefaultCredentials = true;
            mailClient.Credentials           = mailAuthentication;

            try
            {
                mailClient.Send(MyMailMessage);
                bRetorno = true;
            }
            catch (System.Exception erro)
            {
                _LogGrava._GravaLog("EnvioEmail (" + sUsuApelido + ") Error: " + erro.Message + " " + erro.InnerException);
                bRetorno = false;
            }
            finally
            {
                mailClient = null;
            }
            //==================================================================================================
            //==================================================================================================
            return bRetorno;
        }

    }
}