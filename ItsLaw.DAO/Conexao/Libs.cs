using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ItsLaw.DAO.Conexao
{
    public enum EnumTipoPeriodo
    {
        Mensal = 1,
        Bimestral = 2,
        Trimestral = 3,
        Quadrimestral = 4,
        Semestral = 5,
        Anual = 6
    }


    public enum EnumStatusRelatorio
    {
        NaoValidado = 1,
        Validado
    }
    public enum EnumTipoObservacaoAtividade
    {
        ReuniaoDiretoriaUnidade = 1,
        VisitaUnidade
    }
    public enum EnumTipoEntrada
    {
        Texto,
        Numeros,
        Valor,
        Email,
        DataDiaMesAno,
        DataMesAno,
        CEP,
        RG,
        CPF,
        CNPJ
    }

    public enum EnumTipoMes
    {
        Completo,
        Reduzido
    }

    public enum EnumTipoColuna
    {
        String,
        Integer,
        Boolean,
        Date,
        ByteArray,
        Outro,
        Decimal,
        Double,
        Byte
    }

    public enum EnumOrdemStatusOS
    {
        Aberto = 0,
        AguardandoAprovacao = 1,
        EncerradoTecnicamente = 2,
        Reaberto = 3,
        Encerrado = 4,
        AnaliseProcesso = 5
    }

    public enum EnumOrdemStatusEquipamentos
    {
        Ativo = 1,
        Inativo = 2
    }

    public enum EnumTiposNotificacoes
    {
        PesquisasNaoRespondidas = 1,
        OSEncerradaTecnicamente = 2
    }

    public enum EnumSituacaoEquipamento
    {
        Operacional = 1,
        Restricao,
        Inoperante
    }

    public enum EnumIsAtivo
    {
        Ativo,
        Inativo,
        Todos
    }

    public enum EnumTipoLancamento
    {
        OS = 1,
        Chamado
    }

    public class Util
    {

        public static double TestaNaN(double Valor)
        {
            if (double.IsNaN(Valor))
            {
                return 0;
            }
            else
            {
                return Valor;
            }
        }


        //valida o tamanho maximo do arquivo a ser submetido
        public static long LimiteTamanhoArquivo()
        {
            return Convert.ToInt64(1024); // ConfigurationManager.AppSettings["LimiteTamanhoArquivo"]);
        }

        public static string getIsAtivoDescricao(bool isAtivo)
        {
            if (isAtivo)
            {
                return "Ativo";
            }

            return "Inativo";
        }

        public static string getIsEmergenciaDescricao(bool isEmergencia)
        {
            if (isEmergencia)
            {
                return "Emergência";
            }

            return "Normal";
        }

        public static Dictionary<string, string> getUF()
        {
            var dict = new Dictionary<string, string>();

            dict.Add("Acre", "AC");
            dict.Add("Alagoas", "AL");
            dict.Add("Amapá", "AP");
            dict.Add("Amazonas", "AM");
            dict.Add("Bahia", "BA");
            dict.Add("Ceará", "CE");
            dict.Add("Distrito Federal", "DF");
            dict.Add("Espírito Santo", "ES");
            dict.Add("Goiás", "GO");
            dict.Add("Maranhão", "MA");
            dict.Add("Mato Grosso", "MT");
            dict.Add("Mato Grosso do Sul", "MS");
            dict.Add("Minas Gerais", "MG");
            dict.Add("Pará", "PA");
            dict.Add("Paraíba", "PB");
            dict.Add("Paraná", "PR");
            dict.Add("Pernambuco", "PE");
            dict.Add("Piauí", "PI");
            dict.Add("Rio de Janeiro", "RJ");
            dict.Add("Rio Grande do Norte", "RN");
            dict.Add("Rio Grande do Sul", "RS");
            dict.Add("Rondônia", "RO");
            dict.Add("Roraima", "RR");
            dict.Add("Santa Catarina", "SC");
            dict.Add("São Paulo", "SP");
            dict.Add("Sergipe", "SE");
            dict.Add("Tocantins", "TO");

            return dict;
        }

        public static string FormatPath(string Caminho)
        {
            //HttpContext.Current.Server.MapPath 
            var appDir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var relativePath = System.IO.Path.Combine(appDir, Caminho);

            return relativePath;
        }

        public static string SubstituiSQL(string Texto, EnumTipoEntrada Entrada = EnumTipoEntrada.Texto)
        {
            try
            {
                //Retorna string vazia caso não haja texto
                if (Texto == null || string.IsNullOrEmpty(Texto))
                    return "";

                // Substitui os caracteres vindos do JQuery
                Texto = Texto.Replace(" & amp;", "&");
                Texto = Texto.Replace("&lt;", "<");
                Texto = Texto.Replace("&gt;", "<");
                Texto = Texto.Replace("&quot;", "\"");
                Texto = Texto.Replace("&#39;", "'");
                Texto = Texto.Replace("&#x2F;", "/");

                //Substitui os caracteres abaixo
                Texto = Texto.Replace("'", "''");
                //Texto = Texto.Replace("@@", "@")
                //Texto = Texto.Replace("</", "")
                Texto = Regex.Replace(Texto, "%3C", "", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
                Texto = Regex.Replace(Texto, "%3E", "", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
                Texto = Regex.Replace(Texto, " XSS", "", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
                Texto = Regex.Replace(Texto, "XSS ", "", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
                Texto = Texto.Trim();

                //Verifica injections de comandos SQL
                //Dim CopiaDoTexto As String = Texto.ToUpper
                ArrayList BlackListSQL = new ArrayList();

                BlackListSQL.Add("CREATE");
                BlackListSQL.Add("SELECT");
                BlackListSQL.Add("INSERT");
                BlackListSQL.Add("UPDATE");
                BlackListSQL.Add("ALTER\\ TABLE");
                BlackListSQL.Add("ALTER\\ COLUMN");
                BlackListSQL.Add("ALTER\\ JOB");
                BlackListSQL.Add("ALTER\\ TRIGGER");
                BlackListSQL.Add("ALTER\\ PROC");
                BlackListSQL.Add("ALTER\\ PROCEDURE");
                BlackListSQL.Add("ALTER\\ DATABASE");
                BlackListSQL.Add("ALTER\\ VIEW");
                BlackListSQL.Add("ALTER\\ LOGIN");
                BlackListSQL.Add("ALTER\\ USER");
                BlackListSQL.Add("ALTER\\ SERVER");
                BlackListSQL.Add("ALTER\\ GROUP");
                BlackListSQL.Add("ALTER\\ FUNCTION");
                BlackListSQL.Add("ALTER\\ APPLICATION");
                BlackListSQL.Add("ALTER\\ ASSEMBLY");
                BlackListSQL.Add("ALTER\\ AUTHORIZATION");
                BlackListSQL.Add("ALTER\\ CERTIFICATE");
                BlackListSQL.Add("ALTER\\ CREDENTIAL");
                BlackListSQL.Add("ALTER\\ ENDPOINT");
                BlackListSQL.Add("ALTER\\ FULLTEXT");
                BlackListSQL.Add("ALTER\\ INDEX");
                BlackListSQL.Add("ALTER\\ ASYMMETRIC");
                BlackListSQL.Add("ALTER\\ SYMMETRIC");
                BlackListSQL.Add("ALTER\\ MASTER");
                BlackListSQL.Add("ALTER\\ SERVICE");
                BlackListSQL.Add("ALTER\\ MESSAGE");
                BlackListSQL.Add("ALTER\\ PARTITION");
                BlackListSQL.Add("ALTER\\ QUEUE");
                BlackListSQL.Add("ALTER\\ REMOTE");
                BlackListSQL.Add("ALTER\\ ROLE");
                BlackListSQL.Add("ALTER\\ SCHEMA");
                BlackListSQL.Add("ALTER\\ ROUTE");
                BlackListSQL.Add("ALTER\\ XML");
                BlackListSQL.Add("DELETE");
                BlackListSQL.Add("TRUNCATE");
                BlackListSQL.Add("DROP");
                BlackListSQL.Add("SHUTDOWN");
                //BlackListSQL.Add("CHAR(")

                //Limpa espaços duplos
                //While CopiaDoTexto.IndexOf("  ") > -1
                //    CopiaDoTexto = CopiaDoTexto.Replace("  ", " ")
                //End While

                while ((Texto.IndexOf("--") >= 0))
                {
                    Texto = Texto.Replace("--", "-");
                }

                //Procura se existe os comandos SQL proibidos no Texto
                foreach (string ComandoSQL in BlackListSQL)
                {
                    Texto = Regex.Replace(Texto, ";?\\s*" + ComandoSQL + "\\W\\s*", "", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
                    //If _
                    //CopiaDoTexto.IndexOf(ComandoSQL + " ") = 0 OrElse _
                    //CopiaDoTexto.IndexOf(" " + ComandoSQL + " ") > -1 OrElse _
                    //CopiaDoTexto.IndexOf("; " + ComandoSQL + " ") > -1 OrElse _
                    //CopiaDoTexto.IndexOf(";" + ComandoSQL + " ") > -1 Then
                    //    Texto = Texto.ToUpper.Replace(ComandoSQL, "")
                    //End If
                }

                //Se a entrada for do tipo Texto, não há mais verificações a serem feitas
                if (Entrada == EnumTipoEntrada.Texto)
                    return Texto;

                //Verificação numérica
                if (Texto.Where(c => char.IsNumber(c)).Count() == 0)
                {
                    return "";
                }

                //Verificação de datas
                try
                {
                    DateTime dt = DateTime.Parse(Texto);
                }
                catch
                {
                    return "";
                }

                //Verificação de email
                if (Entrada == EnumTipoEntrada.Email)
                {
                    Regex ExpressaoRegular = new Regex("\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*");
                    if (!ExpressaoRegular.IsMatch(Texto))
                        return "";
                }

                //Validação de tamanho
                if (Entrada == EnumTipoEntrada.CEP || Entrada == EnumTipoEntrada.CNPJ || Entrada == EnumTipoEntrada.CPF)
                {
                    string CopiaDoTexto = Util.SomenteNumeros(Texto);

                    switch (Entrada)
                    {
                        case EnumTipoEntrada.CEP:
                            if (CopiaDoTexto.Length != 8)
                                return "";
                            break;
                        case EnumTipoEntrada.CNPJ:
                            if (CopiaDoTexto.Length != 14)
                                return "";
                            break;
                        case EnumTipoEntrada.CPF:
                            if (CopiaDoTexto.Length != 11)
                                return "";
                            break;
                    }
                }

                return Texto;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        private string BuscaGoogle(string Busca)
        {
            Busca = Busca.ToLower();

            if (Busca.IndexOf("google") < 0)
            {
                return "";
            }

            Busca = Busca.Substring(Busca.IndexOf("?q=") + Busca.IndexOf("&q=") + 2);
            Busca = Busca.Substring(0, Busca.IndexOf("&"));

            return Busca;
        }

        public static string GeraBannerErro(string Mensagem)
        {
            StringBuilder JS = new StringBuilder();

            JS.AppendLine("<div class='Erro'>");
            JS.AppendLine("<p>");
            JS.AppendLine(Mensagem);
            JS.AppendLine("</p>");
            JS.AppendLine("</div>");

            //JS.AppendLine("<script type=""text/javascript"">")
            //JS.AppendLine("$(""<div></div>"")") ' O comando '$(""<div></div>"")' cria uma div
            //JS.AppendLine(".addClass('Erro')") ' Aplica o estilo
            //JS.AppendLine(".attr({ id: 'divErro' })")
            //JS.AppendLine(".hide()") ' Esconde o elemento
            //JS.AppendLine(".html('" & Mensagem.Replace("'", "`") & "')") ' O comando .html atribui o valor innerHTML a esta div
            //JS.AppendLine(".appendTo('body')") ' O comando  'appendTo' adiciona a div no body do HTML via seletor 'body'
            //JS.AppendLine("</script>")

            return JS.ToString();
        }

        public static string PegaUrlLOG()
        {
            return "c:\\logs";
        }

        public static int CalculaPrimeiraLinhaPaginacao(int PaginaAtual, int LinhasPorPagina)
        {
            if (PaginaAtual <= 0)
                PaginaAtual = 1;
            return ((PaginaAtual * LinhasPorPagina) - LinhasPorPagina) + 1;
        }

        public static int CalculaUltimaLinhaPaginacao(int PaginaAtual, int LinhasPorPagina)
        {
            return (CalculaPrimeiraLinhaPaginacao(PaginaAtual, LinhasPorPagina) + LinhasPorPagina) - 1;
        }

        public static string RemoveTagsHtml(string Texto)
        {
            return Regex.Replace(Texto, "<(.|\\n)*?>", string.Empty);
        }

        public static string SomenteNumeros(string Texto)
        {
            if (((Texto == null)) || (Texto == null))
            {
                return string.Empty;
            }
            else
            {
                return Regex.Replace(Texto, "[^0-9]", string.Empty);
            }
        }

        public static string ConverteSQLData(System.DateTime Valor)
        {
            return Valor.ToString("yyyy-MM-dd HH:mm:ss");
        }



        public static string GenerateShaHash(string Data, string Key)
        {
            using (HMACSHA1 hmac = new HMACSHA1(Encoding.ASCII.GetBytes(Key)))
            {
                return ByteToString(hmac.ComputeHash(Encoding.ASCII.GetBytes(Data))).ToLower();
            }
        }

        private static string ByteToString(byte[] Data)
        {
            string sbinary = "";

            for (int i = 0; i <= Data.Length - 1; i++)
            {
                sbinary += Data[i].ToString("X2");
                //HEX Format
            }

            return (sbinary);
        }

        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }



        public static string RemoveAcentos(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return "";
            }
            else
            {
                byte[] bytes = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(texto);
                return System.Text.Encoding.UTF8.GetString(bytes);
            }
        }

        //Método que valida o CPF
        public static bool ValidaCPF(string vrCPF)
        {
            string valor = SomenteNumeros(vrCPF);

            if (valor.Length != 11)
                return false;

            bool igual = true;
            int x = 1;
            while (x < 11 && igual)
            {
                if (valor[x] != valor[0])
                {
                    igual = false;
                }
                x += 1;
            }

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];
            for (int i = 0; i <= 10; i++)
            {
                numeros[i] = int.Parse(valor[i].ToString());
            }

            int soma = 0;
            for (int i = 0; i <= 8; i++)
            {
                soma += (10 - i) * numeros[i];
            }

            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                {
                    return false;
                }
            }
            else if (numeros[9] != 11 - resultado)
            {
                return false;
            }

            soma = 0;
            for (int i = 0; i <= 9; i++)
            {
                soma += (11 - i) * numeros[i];
            }

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                {
                    return false;

                }
            }
            else if (numeros[10] != 11 - resultado)
            {
                return false;
            }

            return true;
        }

        //Método que valida o CNPJ 
        public static bool ValidaCNPJ(string vrCNPJ)
        {

            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");

            int[] digitos = null;
            int[] soma = null;
            int[] resultado = null;
            int nrDig = 0;
            string ftmt = null;
            bool[] CNPJOk = null;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig <= 13; nrDig++)
                {
                    digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11)
                    {
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));
                    }
                    if (nrDig <= 12)
                    {
                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                    }
                }

                for (nrDig = 0; nrDig <= 1; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                    {
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);

                    }
                    else
                    {
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));

                    }
                }


                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }

        }


        public static string MesAtual(int Mes, EnumTipoMes TipoMes)
        {
            string NomeMes = string.Empty;

            switch (TipoMes)
            {
                case EnumTipoMes.Completo:
                    switch (Mes)
                    {
                        case 1:
                            NomeMes = "Janeiro";
                            break;
                        case 2:
                            NomeMes = "Fevereiro";
                            break;
                        case 3:
                            NomeMes = "Março";
                            break;
                        case 4:
                            NomeMes = "Abril";
                            break;
                        case 5:
                            NomeMes = "Maio";
                            break;
                        case 6:
                            NomeMes = "Junho";
                            break;
                        case 7:
                            NomeMes = "Julho";
                            break;
                        case 8:
                            NomeMes = "Agosto";
                            break;
                        case 9:
                            NomeMes = "Setembro";
                            break;
                        case 10:
                            NomeMes = "Outubro";
                            break;
                        case 11:
                            NomeMes = "Novembro";
                            break;
                        case 12:
                            NomeMes = "Dezembro";
                            break;
                    }

                    break;
                case EnumTipoMes.Reduzido:
                    switch (Mes)
                    {
                        case 1:
                            NomeMes = "Jan";
                            break;
                        case 2:
                            NomeMes = "Fev";
                            break;
                        case 3:
                            NomeMes = "Mar";
                            break;
                        case 4:
                            NomeMes = "Abr";
                            break;
                        case 5:
                            NomeMes = "Mai";
                            break;
                        case 6:
                            NomeMes = "Jun";
                            break;
                        case 7:
                            NomeMes = "Jul";
                            break;
                        case 8:
                            NomeMes = "Ago";
                            break;
                        case 9:
                            NomeMes = "Set";
                            break;
                        case 10:
                            NomeMes = "Out";
                            break;
                        case 11:
                            NomeMes = "Nov";
                            break;
                        case 12:
                            NomeMes = "Dez";
                            break;
                    }

                    break;
            }


            return NomeMes;
        }



        public static dynamic VerifyNullDB(object Column, EnumTipoColuna Type)
        {

            if (!(Column == DBNull.Value))
            {
                switch (Type)
                {
                    case EnumTipoColuna.String:
                        return Column.ToString();
                    case EnumTipoColuna.Integer:
                        return Convert.ToInt32(Column);
                    case EnumTipoColuna.Boolean:
                        return Convert.ToBoolean(Column);
                    case EnumTipoColuna.Date:
                        return Convert.ToDateTime(Column);
                    case EnumTipoColuna.Decimal:
                        return Convert.ToDecimal(Column);
                    case EnumTipoColuna.Double:
                        return Convert.ToDouble(Column);
                    default:
                        return "";
                }
            }
            else
            {
                if (Type == EnumTipoColuna.Boolean)
                {
                    return Convert.ToInt32(Column) == 0 ? false : true;
                }
                else
                {
                    return Column.ToString();
                    //return Column;
                }
            }
        }

        public static bool ValidaEmail(string Email)
        {
            return (new Regex("\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*")).IsMatch(Email);
        }



        public static string Cripto(string Texto)
        {
            //return FormsAuthentication.HashPasswordForStoringInConfigFile(Texto, "SHA1");
            return "";   //REMOVER 30.10.2018
        }



        //Ler dados do Arquivo
        public static string LerDadosArquivo(string Caminho)
        {

            var retorno = string.Empty;

            using (StreamReader sr = new StreamReader(Caminho))
            {
                retorno = sr.ReadToEnd();
            }

            return retorno;
        }

        public static decimal converteStringMoedaToDecimal(String valor)
        {
            valor = valor.Replace(".", "");
            valor = valor.Replace(",", ".");

            return Convert.ToDecimal(valor);
        }

        public static int ZeroToMinValue(int value)
        {
            return value == 0 ? int.MinValue : value;
        }

        public static string ApenasData(DateTime data)
        {
            var stringData = DataHora(data);
            var newData = stringData.Split();
            return newData[0];
        }

        public static string DataHora(DateTime data)
        {
            if (data == DateTime.MinValue)
            {
                return "";
            }
            else
            {
                return data.ToString();
            }
        }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public class DisplayText : Attribute
    {

        public string Text { get; set; }

        public DisplayText(string Text)
        {
            this.Text = Text;
        }

    }

    /// <summary>
    /// Classe para obter dados do WebConfig
    /// </summary>
    public static class Configuracao
    {
        public static string UrlSistema()
        {
            return "http://localhost"; // ConfigurationManager.AppSettings["UrlPadraoSistema"];
        }

        //Tempo que o token para validação de senha é valido.
        public static string ValidadeTokenDia()
        {
            return "60"; // ConfigurationManager.AppSettings["ValidadeTokenDia"];
        }

        //Caminho do Template de Email
        public static string EmailTemplate()
        {
            return "email template"; // ConfigurationManager.AppSettings["EmailTemplate"];
        }

        public static string NomeProjeto()
        {
            return "Nome Projeto"; // ConfigurationManager.AppSettings["NomeProjeto"];
        }

        public static string DownTime()
        {
            return "60"; // ConfigurationManager.AppSettings["DiasDownTime"];
        }
    }

    public static class Senhas
    {
        public static string GerarSenha(int tamanhoMaximo, int caracteresEspeciais)
        {
            return ""; // Membership.GeneratePassword(tamanhoMaximo, caracteresEspeciais);
        }
    }
}
