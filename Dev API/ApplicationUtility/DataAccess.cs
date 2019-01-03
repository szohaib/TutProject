using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using  System.Configuration;

namespace ApplicationUtility
{
    public abstract class DataAccess : IDisposable
    {
        private string _result;
        private string _connectionString;
        private SqlConnection _sqlConnection;

        public DataAccess(string connectionString)
        {
           string connection= ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            this._connectionString = connection;
            this._sqlConnection = new SqlConnection(connection);
        }

        public virtual void Dispose()
        {
            try
            {
                if (this._sqlConnection.State != ConnectionState.Closed)
                {
                    this._sqlConnection.Close();
                }
            }
            finally
            {
                this._sqlConnection.Dispose();
                this._sqlConnection = null;
                GC.Collect();
            }
        }


        private SqlCommand BuildIntCommand(string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = this.BuildSqlCommand(storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("@ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        private SqlCommand BuildSqlCommand(string procedureName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(procedureName, this._sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        private SqlCommand BuildSqlCommand(string procedureName, IDataParameter[] parameters, string[] outputParameters)
        {
            SqlCommand command = this.BuildSqlCommand(procedureName, parameters);
            foreach (string parameter in outputParameters)
            {
                command.Parameters.Add(new SqlParameter(parameter, SqlDbType.Variant, 50, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            }
            return command;
        }

        protected SqlDataReader RunProcedure(string query)
        {
            this._sqlConnection.Open();
            SqlCommand command = new SqlCommand(query, this._sqlConnection);
            command.CommandType = CommandType.Text;
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        protected SqlDataReader RunProcedure(string procedureName, IDataParameter[] parameters)
        {
            this._sqlConnection.Open();
            return this.BuildSqlCommand(procedureName, parameters).ExecuteReader(CommandBehavior.CloseConnection);
        }

        protected string GetOneResult(string query)
        {
            _result = string.Empty;
            this._sqlConnection.Open();
            try
            {
                SqlCommand command = new SqlCommand(query, this._sqlConnection);
                command.CommandType = CommandType.Text;
                _result = command.ExecuteScalar().ToString();
            }
            finally
            {
                this._sqlConnection.Close();
            }
            return _result;
        }

        protected string GetOneResult(string procedureName, IDataParameter[] parameters)
        {
            _result = string.Empty;
            this._sqlConnection.Open();
            try
            {
                SqlCommand command = this.BuildSqlCommand(procedureName, parameters);
                _result = command.ExecuteScalar().ToString();
                command.Dispose();
            }
            finally
            {
                this._sqlConnection.Close();
            }
            return _result;
        }

        protected void RunProcedure(string procedureName, IDataParameter[] parameters, out int affectedRow)
        {
            this._sqlConnection.Open();
            try
            {
                SqlCommand command = this.BuildIntCommand(procedureName, parameters);
                affectedRow = command.ExecuteNonQuery();
            }
            finally
            {
                this._sqlConnection.Close();
            }
        }

        protected DataSet RunProcedure(string procedureName, IDataParameter[] parameters, string tableName)
        {
            DataSet dataSet = new DataSet();
            this._sqlConnection.Open();
            try
            {
                new SqlDataAdapter(this.BuildSqlCommand(procedureName, parameters)).Fill(dataSet, tableName);
            }
            finally
            {
                this._sqlConnection.Close();
            }
            return dataSet;
        }

        protected DataSet RunProcedure(string procedureName, IDataParameter[] parameters, bool isTables)
        {
            DataSet dataSet = new DataSet();
            this._sqlConnection.Open();
            try
            {
                new SqlDataAdapter(this.BuildSqlCommand(procedureName, parameters)).Fill(dataSet);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._sqlConnection.Close();
            }
            return dataSet;
        }

        protected DataSet RunProcedure(string procedureName, bool isTables)
        {
            DataSet dataSet = new DataSet();
            this._sqlConnection.Open();
            try
            {
                SqlCommand selectCommand = new SqlCommand(procedureName, this._sqlConnection);
                selectCommand.CommandType = CommandType.Text;
                new SqlDataAdapter(selectCommand).Fill(dataSet);
            }
            finally
            {
                this._sqlConnection.Close();
            }
            return dataSet;
        }

        protected DataSet RunProcedure(string query, string tableName)
        {
            DataSet dataSet = new DataSet();
            this._sqlConnection.Open();
            try
            {
                SqlCommand selectCommand = new SqlCommand(query, this._sqlConnection);
                selectCommand.CommandType = CommandType.Text;
                new SqlDataAdapter(selectCommand).Fill(dataSet, tableName);
            }
            finally
            {
                this._sqlConnection.Close();
            }
            return dataSet;
        }

        protected DataSet RunProcedure(string procedureName, string outputParameter, IDataParameter[] parameters,string tableName, out int affectedRow)
        {
            DataSet dataSet = new DataSet();
            this._sqlConnection.Open();
            try
            {
                SqlCommand command = this.BuildSqlCommand(procedureName, parameters);
                new SqlDataAdapter(command).Fill(dataSet, tableName);
                affectedRow = (int)command.Parameters[outputParameter].Value;
            }
            finally
            {
                this._sqlConnection.Close();
            }
            return dataSet;
        }

        protected object RunProcedure(string procedureName, string outputParameter, IDataParameter[] parameters)
        {
            this._sqlConnection.Open();
            try
            {
                SqlCommand command = this.BuildIntCommand(procedureName, parameters);
                command.ExecuteNonQuery();
                return command.Parameters[outputParameter].Value;
            }
            catch { return null; }
            finally
            {
                this._sqlConnection.Close();
            }
        }

        protected System.Collections.ArrayList RunProcedure(string procedureName, string[] outputParameters, IDataParameter[] parameters)
        {
            this._sqlConnection.Open();
            try
            {
                System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
                SqlCommand command = this.BuildSqlCommand(procedureName, parameters, outputParameters);
                command.ExecuteNonQuery();
                foreach (string parameter in outputParameters)
                {
                    arrayList.Add(command.Parameters[parameter].Value);
                }
                return arrayList;
            }
            finally
            {
                this._sqlConnection.Close();
            }
        }

        protected void ManuplateTable(string query)
        {
            this._sqlConnection.Open();
            try
            {
                SqlCommand command = new SqlCommand(query, this._sqlConnection);
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                command.Dispose();
            }
            finally
            {
                this._sqlConnection.Close();
            }
        }

        protected void ManuplateTable(string procedureName, IDataParameter[] parameters)
        {
            this._sqlConnection.Open();
            try
            {
                SqlCommand command = this.BuildSqlCommand(procedureName, parameters);
                command.ExecuteNonQuery();
                command.Dispose();
            }
            finally
            {
                this._sqlConnection.Close();
            }
        }
    }
}
