using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsLaw.DAO.Conexao
{
    public class ConexaoSQL
    {
        private static SqlConnection _sqlconn;
        private SqlTransaction      _sqlTransaction;
        private SqlCommand          _sqlCommand;
        private string _stringConnection = string.Empty;

        public string stringConnection
        {
            get
            {
                return _stringConnection;
            }
            set
            {
                _stringConnection = value;
            }
        }

        public ConexaoSQL()
        {
            this.Command.Connection = this.Connection;
            this.stringConnection = getConnectionString();
        }

        private string getConnectionString()
        {
            String connString = "";

            try
            {
                    connString = "Data Source=192.168.56.1;Initial Catalog=ItsLaw;persist security info=True;user id=ItsLaw;password=Itsingular!@;MultipleActiveResultSets=True;Trusted_Connection=False";
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }


            return connString;
        }

        public enum enumDatabaseType
        {
            MSSQLSERVER,
            ORACLE,
            SQLCOMPACT,
            MSACCESS,
            WebService
        }

        private enumDatabaseType _databaseType;

        public enumDatabaseType DatabaseType
        {
            get
            {
                return _databaseType;
            }
            set
            {
                _databaseType = value;
            }
        }

        /// <summary>
        /// Executa a Query e retorna o número de linha afetadas.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int ExecuteQuery(string query)
        {
            int rows = 0;


            if (DatabaseType == enumDatabaseType.MSSQLSERVER)
            {
                try
                {
                    _sqlCommand = new SqlCommand();

                    _sqlCommand.Connection = new SqlConnection(stringConnection);
                    _sqlCommand.Connection.Open();
                    _sqlCommand.CommandTimeout = 300;
                    _sqlCommand.CommandType = CommandType.Text;
                    _sqlCommand.CommandText = query;
                    rows = _sqlCommand.ExecuteNonQuery();

                }
                catch (Exception exp)
                {

                    throw new Exception(exp.Message);
                }
                finally
                {
                    _sqlCommand.Connection.Close();
                    _sqlCommand.Connection.Dispose();
                    _sqlCommand.Connection = null;
                    _sqlCommand.Dispose();
                    _sqlCommand = null;
                }
            }


            return rows;
        }

        public DataTable ExecuteQuery(string query, DataTable dt)
        {
            if (DatabaseType == enumDatabaseType.MSSQLSERVER)
            {
                try
                {
                    _sqlCommand = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();

                    _sqlCommand.Connection = new SqlConnection(stringConnection);

                    _sqlCommand.Connection.Open();
                    _sqlCommand.CommandType = CommandType.Text;
                    _sqlCommand.CommandText = query;
                    _sqlCommand.CommandTimeout = 300;
                    // _sqlCommand.ExecuteNonQuery();


                    da.SelectCommand = _sqlCommand;
                    da.Fill(dt);
                    da.Dispose();
                    da = null;
                }
                catch (Exception exp)
                {

                    throw new Exception(exp.Message);
                }
                finally
                {
                    _sqlCommand.Connection.Close();
                    _sqlCommand.Connection.Dispose();
                    _sqlCommand.Connection = null;
                    _sqlCommand.Dispose();
                    _sqlCommand = null;
                }
            }


            return dt;
        }

        /// <summary>
        /// Executa Query retornando Identity
        /// </summary>
        /// <param name="query">query</param>
        /// <param name="ORACLE_sequence">nome da Sequence</param>
        /// <returns></returns>
        public string ExecuteQuery(string query, string ORACLE_sequence)
        {
            if (DatabaseType == enumDatabaseType.MSSQLSERVER)
            {
                try
                {
                    _sqlCommand = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter();

                    _sqlCommand.Connection = new SqlConnection(stringConnection);
                    _sqlCommand.Connection.Open();
                    _sqlCommand.CommandTimeout = 300;
                    _sqlCommand.CommandType = CommandType.Text;
                    _sqlCommand.CommandText = query;
                    _sqlCommand.ExecuteNonQuery();


                    _sqlCommand.CommandText = "SELECT @@IDENTITY";

                    ORACLE_sequence = _sqlCommand.ExecuteScalar().ToString();
                }
                catch (Exception exp)
                {

                    throw new Exception(exp.Message);
                }
                finally
                {
                    _sqlCommand.Connection.Close();
                    _sqlCommand.Connection.Dispose();
                    _sqlCommand.Connection = null;
                    _sqlCommand.Dispose();
                    _sqlCommand = null;
                }
            }


            return ORACLE_sequence;
        }

        /// <summary>
        /// Retorna a primeira coluna da primeira linha do resultado retornado pela query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string ExecuteScalar(string query)
        {
            string retorno = string.Empty;

            if (DatabaseType == enumDatabaseType.MSSQLSERVER)
            {
                try
                {
                    _sqlCommand = new SqlCommand();

                    _sqlCommand.Connection = new SqlConnection(stringConnection);

                    _sqlCommand.Connection.Open();
                    _sqlCommand.CommandType = CommandType.Text;
                    _sqlCommand.CommandText = query;
                    object Scalar = _sqlCommand.ExecuteScalar();
                    retorno = Scalar != null ? Scalar.ToString() : string.Empty;

                }
                catch (Exception exp)
                {

                    throw new Exception(exp.Message);
                }
                finally
                {
                    _sqlCommand.Connection.Close();
                    _sqlCommand.Connection.Dispose();
                    _sqlCommand.Connection = null;
                    _sqlCommand.Dispose();
                    _sqlCommand = null;
                }
            }


            return retorno;
        }

        public IDbConnection Connection
        {
            set
            {
                _connection = value;
            }
            get
            {
                try
                {
                    if (_connection == null)
                    {
                        _stringConnection = _stringConnection == string.Empty ? getConnectionString() : _stringConnection;

                        _connection = new SqlConnection(_stringConnection); // conexao q esta na tabela de unica

                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }

                return _connection;
            }
        }

        private IsolationLevel _isolationLevel;
        public IsolationLevel IsolationLevel
        {
            get
            {
                return _isolationLevel;
            }
            set
            {
                _isolationLevel = value;
            }
        }
        public SqlConnection sqlConnection
        {
            get
            {
                if (_sqlconn == null)
                {
                    try
                    {
                        _stringConnection = _stringConnection == string.Empty ? getConnectionString() : _stringConnection;
                        _sqlconn = new SqlConnection(_stringConnection);
                        _sqlconn.Open();
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(exception.Message);
                    }
                }

                return _sqlconn;
            }
            set
            {
                _sqlconn = value;
            }
        }
        private SqlTransaction sqlTransaction
        {
            set
            {
                _sqlTransaction = value;
            }
            get
            {
                if (_sqlTransaction == null)
                {
                    _sqlTransaction = this.sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted, "Script");
                }
                return _sqlTransaction;
            }
        }
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IDbCommand _command;
        private IDbDataAdapter _dataAdapter;
        private IDbDataParameter _dataParameter;

        public IDbTransaction Transaction
        {
            set
            {
                _transaction = value;
            }
            get
            {
                if (_transaction == null)
                {
                    if (Connection.State == ConnectionState.Closed)
                        Connection.Open();

                    if (DatabaseType != enumDatabaseType.ORACLE || DatabaseType != enumDatabaseType.SQLCOMPACT)
                    {

                        if (IsolationLevel == 0)
                            _transaction = Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        else if ((int)IsolationLevel == 4096)
                            _transaction = Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                        else if ((int)IsolationLevel == 256)
                            _transaction = Connection.BeginTransaction(IsolationLevel.ReadUncommitted);
                        else if ((int)IsolationLevel == 1048576)
                            _transaction = Connection.BeginTransaction(IsolationLevel.Serializable);
                    }
                    else
                    {
                        _transaction = Connection.BeginTransaction(IsolationLevel.ReadCommitted);
                    }
                }
                return _transaction;
            }
        }
        public IDbCommand Command
        {
            set
            {
                _command = value;
            }
            get
            {
                if (_command == null)
                {
                    _command = new SqlCommand();
                }
                return _command;
            }
        }

        public IDbDataAdapter DataAdapter
        {
            get
            {
                _dataAdapter = new SqlDataAdapter((SqlCommand)Command);
                return _dataAdapter;
            }
        }
        public IDbDataParameter DataParameter
        {
            get
            {
                _dataParameter = new SqlParameter();
                return _dataParameter;
            }
        }
        public void BeginTransaction()
        {
            Command.Transaction = Transaction;
        }

        public void CommitTransaction()
        {
            if (Command.Transaction != null)
            {
                Command.Transaction.Commit();
                Connection.Close();
                _connection.Dispose();
                _connection = null;
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void RollbackTransaction()
        {
            if (Command.Transaction != null)
            {
                Command.Transaction.Rollback();
                Connection.Close();
                _connection.Dispose();
                _connection = null;
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public DataTable ExecuteQueryIDb(string query, DataTable dt)
        {
            try
            {
                DataSet ds = new DataSet();
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                Command.CommandText = query;

                if (DatabaseType != enumDatabaseType.SQLCOMPACT)
                    Command.CommandTimeout = Connection.ConnectionTimeout;

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);

                dt = ds.Tables[0];

                ds.Dispose();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                if (Command.Transaction == null)
                {
                    Connection.Close();
                    _connection.Dispose();
                    _connection = null;
                    Command.Dispose();
                    Command = null;
                }
            }

            return dt;
        }

        /// <summary>
        /// Executa a Query e retorna o número de linha afetadas.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int ExecuteQueryIDb(string query)
        {
            int rows = 0;

            try
            {
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;

                if (DatabaseType != enumDatabaseType.ORACLE)
                    Command.CommandText = query;
                else
                    Command.CommandText = "BEGIN " + query + " END;";



                if (DatabaseType != enumDatabaseType.SQLCOMPACT)
                    Command.CommandTimeout = Connection.ConnectionTimeout;

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                rows = Command.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                if (Command.Transaction == null)
                {
                    Connection.Close();
                    _connection.Dispose();
                    _connection = null;
                    Command.Dispose();
                    Command = null;
                }
            }
            return rows;
        }

        /// <summary>
        /// Retorna a primeira coluna da primeira linha do resultado retornado pela query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public string ExecuteScalarIDb(string query)
        {
            string retorno = string.Empty;

            try
            {
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                Command.CommandText = query;

                if (DatabaseType != enumDatabaseType.SQLCOMPACT)
                    Command.CommandTimeout = Connection.ConnectionTimeout;

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                retorno = Command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException)
            {
                return "";
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                if (Command.Transaction == null)
                {
                    Connection.Close();
                    _connection.Dispose();
                    _connection = null;
                    Command.Dispose();
                    Command = null;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Executa Query e retorna DataTable.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable ExecuteQueryIDb(string query, DataTable dt, List<SqlParameter> parametro)
        {
            try
            {
                DataSet ds = new DataSet();
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                Command.CommandText = query;
                Command.Parameters.Clear();
                foreach (SqlParameter p in parametro)
                {
                    Command.Parameters.Add(SetarDBNull(p));
                }
                if (DatabaseType != enumDatabaseType.SQLCOMPACT)
                    Command.CommandTimeout = Connection.ConnectionTimeout;

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);

                dt = ds.Tables[0];

                ds.Dispose();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                if (Command.Transaction == null)
                {
                    Connection.Close();
                    _connection.Dispose();
                    _connection = null;
                    Command.Dispose();
                    Command = null;
                }
            }

            return dt;
        }

        /// <summary>
        /// Executa Query passando um list de parametros
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parametro"></param>
        public int ExecuteQueryIDb(string sql, List<IDbDataParameter> parametro)
        {
            try
            {
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                //comando.Transaction = this.Transaction;
                Command.Parameters.Clear();
                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();
                foreach (SqlParameter p in parametro)
                {
                    Command.Parameters.Add(p);
                }
                Command.CommandText = sql;
                return Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Command.Transaction == null)
                {
                    Connection.Close();
                    _connection.Dispose();
                    _connection = null;
                    Command.Dispose();
                    Command = null;
                }
            }

        }

        /// <summary>
        /// Executa Query retornando Identity
        /// </summary>
        /// <param name="query"></param>
        /// <param name="idendity">Se for Oracle passar o nome da sequence.</param>
        /// <returns></returns>
        public string ExecuteQueryIDb(string query, string identity, List<SqlParameter> parametro)
        {
            try
            {
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;
                Command.Parameters.Clear();
                foreach (SqlParameter p in parametro)
                {
                    Command.Parameters.Add(SetarDBNull(p));
                }
                if (DatabaseType != enumDatabaseType.ORACLE)
                    Command.CommandText = query;
                else
                    Command.CommandText = "BEGIN " + query + " END;";

                if (DatabaseType != enumDatabaseType.SQLCOMPACT)
                    Command.CommandTimeout = Connection.ConnectionTimeout;

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                Command.ExecuteNonQuery();

                if (DatabaseType != enumDatabaseType.ORACLE)
                {
                    Command.CommandText = "select @@identity";
                }
                else
                {
                    Command.CommandText = "SELECT " + identity + ".currval FROM DUAL";
                }

                identity = Command.ExecuteScalar().ToString();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                if (Command.Transaction == null)
                {
                    Connection.Close();
                    _connection.Dispose();
                    _connection = null;
                    Command.Dispose();
                    Command = null;
                }
            }

            return identity;
        }

        /// <summary>
        /// Executa Query retornando Identity
        /// </summary>
        /// <param name="query"></param>
        /// <param name="idendity">Se for Oracle passar o nome da sequence.</param>
        /// <returns></returns>
        public string ExecuteQueryIDb(string query, string identity)
        {
            try
            {
                Command.Connection = Connection;
                Command.CommandType = CommandType.Text;

                if (DatabaseType != enumDatabaseType.ORACLE)
                    Command.CommandText = query;
                else
                    Command.CommandText = "BEGIN " + query + " END;";

                if (DatabaseType != enumDatabaseType.SQLCOMPACT)
                    Command.CommandTimeout = Connection.ConnectionTimeout;

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                Command.ExecuteNonQuery();

                if (DatabaseType == enumDatabaseType.SQLCOMPACT)
                {
                    Command.CommandText = "select @@identity";
                }
                else if (DatabaseType != enumDatabaseType.ORACLE)
                {
                    Command.CommandText = "select @@identity";
                }
                else
                {
                    Command.CommandText = "SELECT " + identity + ".currval FROM DUAL";
                }

                identity = Command.ExecuteScalar().ToString();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                if (Command.Transaction == null)
                {
                    Connection.Close();
                    _connection.Dispose();
                    _connection = null;
                    Command.Dispose();
                    Command = null;
                }
            }

            return identity;
        }

        /// <summary>
        /// Executa Stored Procedures.
        /// </summary>
        /// <param name="procedure">Nome da Procedure</param>
        /// <param name="ParameterName">Nome do Parametro</param>
        /// <param name="Value">Valor</param>
        public void ExecuteProcedureIDb(string procedure, string[] ParameterName, string[] Value)
        {
            try
            {
                Command.Connection = Connection;
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = procedure;

                if (DatabaseType != enumDatabaseType.SQLCOMPACT)
                    Command.CommandTimeout = Connection.ConnectionTimeout;

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                for (int i = 0; i < ParameterName.Length; i++)
                {
                    IDbDataParameter idp = DataParameter;
                    idp.ParameterName = ParameterName[i];
                    idp.Value = Value[i];
                    Command.Parameters.Add(idp);
                }

                Command.ExecuteNonQuery();
                Command.Parameters.Clear();

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                if (Command.Transaction == null)
                {
                    Connection.Close();
                    _connection.Dispose();
                    _connection = null;
                    Command.Dispose();
                    Command = null;
                }
            }
        }
        /// <summary>
        /// Executa Stored Procedure Retorna DataTable.
        /// </summary>
        /// <param name="procedure">Nome da procedure</param>
        /// <param name="ParameterName">Nome do Parametro</param>
        /// <param name="Value">Valor</param>
        /// <param name="dt"></param>
        /// <returns>Um Data Table</returns>

        public DataSet ExecuteProcedureIDb(string procedure, string[] ParameterName, string[] Value, DataTable dt)
        {
            DataSet ds = new DataSet();
            try
            {
                Command.Parameters.Clear();


                Command.Connection = Connection;
                Command.CommandType = CommandType.StoredProcedure;
                Command.CommandText = procedure;

                if (DatabaseType != enumDatabaseType.SQLCOMPACT)
                    Command.CommandTimeout = Connection.ConnectionTimeout;

                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();

                for (int i = 0; i < ParameterName.Length; i++)
                {
                    IDbDataParameter idp = DataParameter;
                    idp.ParameterName = ParameterName[i];
                    idp.Value = Value[i];
                    Command.Parameters.Add(idp);
                }
                DataAdapter.SelectCommand = Command;
                DataAdapter.Fill(ds);
                // dt = ds.Tables[0];

                Command.Parameters.Clear();
                // ds.Dispose();
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
            finally
            {
                if (Command.Transaction == null)
                {
                    Connection.Close();
                    _connection.Dispose();
                    _connection = null;
                    Command.Dispose();
                    Command = null;
                }
            }
            return ds;
        }

        public DataSet ExecutaSelect(string SQL)
        {
            SqlConnection Conn = new SqlConnection(getConnectionString());
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(SQL, Conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                if (Conn != null)
                    Conn.Dispose();
            }
        }

        public int ExecutaQuery(string SQL)
        {
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = SQL.ToString();
            return ExecutaQuery(Cmd);
        }

        public int ExecutaQuery(SqlCommand Cmd)
        {
            SqlConnection Conn = new SqlConnection(getConnectionString());

            try
            {
                Cmd.Connection = Conn;
                Cmd.Connection.Open();
                Cmd.ExecuteNonQuery();

                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                if (Conn != null)
                    Conn.Dispose();
                if (Cmd != null)
                    Cmd.Dispose();
            }
        }

        public DataTable ExecutaSelect(string SQL, List<SqlParameter> parametros)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(getConnectionString()))
                {
                    using (SqlCommand Cmd = new SqlCommand(SQL, Conn))
                    {
                        Cmd.Parameters.Clear();
                        Cmd.CommandTimeout = 300; // 2 * 60; //2 minutos

                        foreach (SqlParameter parametro in parametros)
                        {
                            Cmd.Parameters.Add(SetarDBNull(parametro));
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = Cmd;

                            using (DataSet ds = new DataSet())
                            {
                                da.Fill(ds);
                                return ds.Tables[0];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //return null;  --EGS 30.07.2018 Original
                throw ex;
            }
        }

        public int ExecutaQuery(string SQL, List<SqlParameter> parametros)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(getConnectionString()))
                {
                    using (SqlCommand Cmd = new SqlCommand(SQL, Conn))
                    {
                        Cmd.Parameters.Clear();

                        foreach (SqlParameter parametro in parametros)
                        {
                            Cmd.Parameters.Add(SetarDBNull(parametro));
                        }

                        Cmd.CommandText = SQL.ToString();
                        Cmd.Connection = Conn;
                        Cmd.Connection.Open();
                        Cmd.ExecuteNonQuery();

                        return 1;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> ExecuteQueryGeneric<T>(string commandText, Func<IDataRecord, T> factoryMethod, List<SqlParameter> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = commandText;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            yield return factoryMethod(reader);
                        reader.Close();
                    }
                }
            }
        }

        public IEnumerable<T> ExecuteQueryGeneric<T>(string commandText, Func<IDataRecord, T> factoryMethod, CommandType tipoComando, List<SqlParameter> parameters = null)
        {
            using (SqlConnection conn = new SqlConnection(getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = tipoComando;
                    cmd.CommandText = commandText;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            yield return factoryMethod(reader);
                        reader.Close();
                    }
                }
            }
        }

        public int InsertWithIdentity(string SQL, List<SqlParameter> parametros)
        {
            if (!SQL.Contains("SELECT @@identity"))
                throw new ArgumentException("Insert não pode ser executado nesse metopo, pois não retornará um @@identity");
            try
            {
                using (SqlConnection Conn = new SqlConnection(getConnectionString()))
                {
                    using (SqlCommand Cmd = new SqlCommand(SQL, Conn))
                    {
                        Cmd.Parameters.Clear();

                        foreach (SqlParameter parametro in parametros)
                        {
                            Cmd.Parameters.Add(SetarDBNull(parametro));
                        }

                        Cmd.CommandText = SQL.ToString();
                        Cmd.Connection = Conn;
                        Cmd.Connection.Open();
                        return Convert.ToInt32(Cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private SqlParameter SetarDBNull(SqlParameter parameter)
        {

            if (parameter.Value != null)
            {

                if (parameter.DbType == DbType.Int32)
                {
                    var value = int.Parse(parameter.Value.ToString());

                    if (value == int.MinValue)
                    {
                        parameter.Value = DBNull.Value;
                    }
                }

                else if (parameter.DbType == DbType.DateTime)
                {
                    var value = DateTime.Parse(parameter.Value.ToString());

                    if (value == DateTime.MinValue)
                    {
                        parameter.Value = DBNull.Value;
                    }
                }

                else if (parameter.DbType == DbType.Boolean)
                {
                    var value = false;

                    if (!bool.TryParse(parameter.Value.ToString(), out value))
                    {
                        parameter.Value = false;
                    }
                }
                else if (parameter.DbType == DbType.String)
                {
                    if (string.IsNullOrEmpty(parameter.Value.ToString()))
                    {
                        parameter.Value = DBNull.Value;
                    }
                }
            }
            else
            {
                parameter.Value = DBNull.Value;
            }

            return parameter;
        }

        public int ObterValorSequencia(string sequencia)
        {
            int retorno = 0;
            string update = null;

            SqlCommand Cmd = new SqlCommand();
            //define a conexão
            SqlConnection con = new SqlConnection(getConnectionString());
            //define o objeto SqlTransaction
            SqlTransaction transaction = null;
            con.Open();
            //Inicia a Transação
            transaction = con.BeginTransaction();
            try
            {
                //relaciona os comandos e executa-os

                Cmd = new SqlCommand("select max(valor) + 1 Id from sequencia where nome = '" + sequencia + "'", con, transaction);
                retorno = Convert.ToInt32(Cmd.ExecuteScalar());
                update = "update sequencia set valor = " + retorno.ToString() + " where nome = '" + sequencia + "'";
                Cmd = new SqlCommand(update, con, transaction);
                Cmd.ExecuteNonQuery();

                //efetua o commit e confirma as alterações
                transaction.Commit();
                con.Close();

                return retorno;
            }
            catch (SqlException)
            {
                //se ocorreu uma exceção desfaz as alterações
                transaction.Rollback();
                con.Close();
                return 0;
            }
        }
    }
}
