using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

/// <summary>
/// MySQL database access class
/// </summary>
public class MySqlDBHelper {
    /// <summary>
    /// Database connection string member, where you can configure the connection string
    /// </summary>       
    private string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

    /// <summary>
    /// Connection object declaration
    /// </summary>
    private MySqlConnection objConn = null;

    /// <summary>
    /// Transaction object declaration
    /// </summary>
    private MySqlTransaction objTrans = null;

    /// <summary>
    /// Data access class constructor (initialization construct)
    /// </summary>
    public MySqlDBHelper() {
        objConn = new MySqlConnection(connString);
    }

    /// <summary>
    /// Open a connection
    /// </summary>
    private void OpenDB() {
        try {
            if (objConn != null && objConn.State != ConnectionState.Open) {
                objConn.Open();
            }
        }
        catch (MySqlException exp) {
            throw exp;
        }
    }

    /// <summary>
    /// Close the connection
    /// </summary>
    public void CloseDB() {
        try {
            if (objConn != null && objConn.State != ConnectionState.Closed) {
                objConn.Close();
            }
        }
        catch (MySqlException exp) {
            throw exp;
        }
    }

    /// <summary>
    /// Start a transaction
    /// </summary>
    private void BeginSqlTranscation() {
        OpenDB();
        objTrans = objConn.BeginTransaction();
    }

    /// <summary>
    /// Commit a transaction
    /// </summary>
    private void CommitSqlTranscation() {
        objTrans.Commit();
        CloseDB();
        objTrans = null;
    }

    /// <summary>
    /// Transaction rollback
    /// </summary>
    private void RollBackSqlTranscation() {
        objTrans.Rollback();
        CloseDB();
        objTrans = null;
    }

    /// <summary>
    /// Create command object (without parameters)
    /// </summary>
    /// <param name="cmdText">command text</param>
    /// <param name="cmdType">command type</param>
    /// <returns>command object</returns>
    private MySqlCommand CreateSqlCommand(string cmdText, CommandType cmdType) {
        MySqlCommand objCmd = new MySqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandType = cmdType;
        objCmd.CommandText = cmdText;
        if (objTrans != null) {
            objCmd.Transaction = objTrans;
        }
        return objCmd;
    }

    /// <summary>
    /// Create a command object with one parameter
    /// </summary>
    /// <param name="cmdText">command text</param>
    /// <param name="cmdType">command type</param>
    /// <param name="para">Single object</param>
    /// <returns>command object</returns>
    private MySqlCommand CreateSqlCommand(string cmdText, MySqlParameter para, CommandType cmdType) {
        MySqlCommand objCmd = new MySqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandType = cmdType;
        objCmd.CommandText = cmdText;
        if (objTrans != null) {
            objCmd.Transaction = objTrans;
        }
        if (para != null) {
            objCmd.Parameters.Add(para);
        }
        return objCmd;
    }

    /// <summary>
    /// Create command object (with multiple parameters)
    /// </summary>
    /// <param name="cmdText">command text</param>
    /// <param name="cmdType">command type</param>
    /// <param name="paras">Array of parameter objects</param>
    /// <returns>command object</returns>
    private MySqlCommand CreateSqlCommand(string cmdText, MySqlParameter[] paras, CommandType cmdType) {
        MySqlCommand objCmd = new MySqlCommand();
        objCmd.Connection = objConn;
        objCmd.CommandType = cmdType;
        objCmd.CommandText = cmdText;
        if (objTrans != null) {
            objCmd.Transaction = objTrans;
        }
        if (paras != null) {
            objCmd.Parameters.AddRange(paras);
        }
        return objCmd;
    }

    /// <summary>
    /// Execute SQL command without parameters and return the number of affected rows
    /// </summary>
    /// <param name="cmdText">Non query SQL commands without parameters (insert, delete and update SQL commands)</param>
    /// <returns>Number of rows affected</returns>
    public int ExecuteSqlNonQuery(string cmdText) {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(cmdText, CommandType.Text);
        try {
            return objCmd.ExecuteNonQuery();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute the SQL command with one parameter and return the number of affected rows
    /// </summary>
    /// <param name="cmdText">Query SQL commands with a parameter (insert, delete, update SQL commands)</param>
    /// <param name="paras">Array of parameter objects</param>
    /// <returns>Number of rows affected</returns>
    public int ExecuteSqlNonQuery(string cmdText, MySqlParameter para)//over load
    {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(cmdText, para, CommandType.Text);
        try {
            return objCmd.ExecuteNonQuery();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }
    /// <summary>
    ///Execute SQL command with multiple parameters and return the number of affected rows
    /// </summary>
    /// <param name="cmdText">Non query SQL commands with parameters (insert, delete and update SQL commands)</param>
    /// <param name="paras">Array of parameter objects</param>
    /// <returns>Number of rows affected</returns>
    public int ExecuteSqlNonQuery(string cmdText, MySqlParameter[] paras)
    {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(cmdText, paras, CommandType.Text);
        try {
            return objCmd.ExecuteNonQuery();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute the stored procedure without parameters and return the number of affected rows
    /// </summary>
    /// <param name="procName">Non query stored procedure without parameters</param>
    /// <returns>Number of rows affected</returns>
    public int ExecuteProcedureNonQuery(string procName) {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(procName, CommandType.StoredProcedure);
        try {
            return objCmd.ExecuteNonQuery();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute a stored procedure with one parameter and return the number of affected rows
    /// </summary>
    /// <param name="procName">Non query stored procedure with one parameter</param>
    /// <param name="para">Parameter object</param>
    /// <returns>Number of rows affected</returns>
    public int ExecuteProcedureNonQuery(string procName, MySqlParameter para) {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(procName, para, CommandType.StoredProcedure);
        try {
            return objCmd.ExecuteNonQuery();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute the stored procedure with multiple parameters and return the number of affected rows
    /// </summary>
    /// <param name="procName">Non query stored procedure with multiple parameters</param>
    /// <param name="paras">Array of parameter objects</param>
    /// <returns>Number of rows affected</returns>
    public int ExecuteProcedureNonQuery(string procName, MySqlParameter[] paras) {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(procName, paras, CommandType.StoredProcedure);
        try {
            return objCmd.ExecuteNonQuery();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute SQL query command without parameters and return DataReader object
    /// </summary>
    /// <param name="cmdText">SQL query command without parameters</param>
    /// <returns>Datareader object</returns>
    public MySqlDataReader ExecuteSqlDataReader(string cmdText) {
        OpenDB();
        MySqlCommand objCmd = CreateSqlCommand(cmdText, CommandType.Text);
        try {
            return objCmd.ExecuteReader();
        }
        catch (MySqlException exp) {
            throw exp;
        }
    }

    /// <summary>
    /// Execute the SQL query command with one parameter and return the DataReader object
    /// </summary>
    /// <param name="cmdText">SQL query command with one parameter</param>
    /// <param name="para">Parameter object</param>
    /// <returns>Datareader object</returns>
    public MySqlDataReader ExecuteSqlDataReader(string cmdText, MySqlParameter para) {
        OpenDB();
        MySqlCommand objCmd = CreateSqlCommand(cmdText, para, CommandType.Text);
        try {
            return objCmd.ExecuteReader();
        }
        catch (MySqlException exp) {
            throw exp;
        }
    }

    /// <summary>
    /// Execute SQL query command with multiple parameters and return DataReader object
    /// </summary>
    /// <param name="cmdText">SQL query command with multiple parameters</param>
    /// <param name="paras">Array of parameter objects</param>
    /// <returns>Datareader object</returns>
    public MySqlDataReader ExecuteSqlDataReader(string cmdText, MySqlParameter[] paras) {
        OpenDB();
        MySqlCommand objCmd = CreateSqlCommand(cmdText, paras, CommandType.Text);
        try {
            return objCmd.ExecuteReader();
        }
        catch (MySqlException exp) {
            throw exp;
        }
    }

    /// <summary>
    /// Execute the query stored procedure without parameters and return the DataReader object
    /// </summary>
    /// <param name="procName">Querying stored procedures without parameters</param>        
    /// <returns>Datareader object</returns>
    public MySqlDataReader ExecuteProcedureDataReader(string procName) {
        OpenDB();
        MySqlCommand objCmd = CreateSqlCommand(procName, CommandType.StoredProcedure);
        try {
            return objCmd.ExecuteReader();
        }
        catch (MySqlException exp) {
            throw exp;
        }
    }

    /// <summary>
    /// Execute a query stored procedure with one parameter and return the DataReader object
    /// </summary>
    /// <param name="cmdText">Query stored procedure with one parameter</param>
    /// <param name="para">Parameter object</param>
    /// <returns>Datareader object</returns>
    public MySqlDataReader ExecuteProcedureDataReader(string procName, MySqlParameter para) {
        OpenDB();
        MySqlCommand cmd = CreateSqlCommand(procName, para, CommandType.StoredProcedure);
        try {
            return cmd.ExecuteReader();
        }
        catch (MySqlException exp) {
            throw exp;
        }
    }

    /// <summary>
    /// Execute the query stored procedure with multiple parameters and return the DataReader object
    /// </summary>
    /// <param name="cmdText">Querying stored procedures with multiple parameters</param>
    /// <param name="paras">Array of parameter objects</param>
    /// <returns>Datareader object</returns>
    public MySqlDataReader ExecuteProcedureDataReader(string procName, MySqlParameter[] paras) {
        OpenDB();
        MySqlCommand cmd = CreateSqlCommand(procName, paras, CommandType.StoredProcedure);
        try {
            return cmd.ExecuteReader();
        }
        catch (MySqlException exp) {
            throw exp;
        }
    }

    /// <summary>
    /// Execute the general summary SQL query command without parameters 
    /// (that is, the first row and first column in the query result set) to return the Object object
    /// </summary>
    /// <param name="cmdText">General summary query SQL command 
    /// (that is, the first row and first column in the query result set)</param>
    /// <returns>Summary results, object</returns>
    public object ExecuteSqlScalar(string cmdText) {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(cmdText, CommandType.Text);
        try {
            return objCmd.ExecuteScalar();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute the SQL command with one parameter summary query 
    /// (that is, the first row and first column in the query result set) to return the Object object
    /// </summary>
    /// <param name="cmdText">Summary query SQL command with one parameter
    /// (i.e. the first row and the first column in the query result set)</param>
    /// <param name="para">Parameter object</param>
    /// <returns>Summary results, object</returns>        
    public object ExecuteSqlScalar(string cmdText, MySqlParameter para) {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(cmdText, para, CommandType.Text);
        try {
            return objCmd.ExecuteScalar();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute the query SQL command with multiple parameters
    /// (that is, the first row and first column in the query result set) to return the Object object
    /// </summary>
    /// <param name="cmdText">Summary query SQL command with multiple parameters
    /// (that is, the first row and first column in the query result set)</param>
    /// <param name="paras">Array of parameter objects</param>
    /// <returns>Summary results, object</returns>        
    public object ExecuteSqlScalar(string cmdText, MySqlParameter[] paras) {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(cmdText, paras, CommandType.Text);
        try {
            return objCmd.ExecuteScalar();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute the query stored procedure without parameters 
    /// (that is, the first row and first column in the query result set) and return the Object object
    /// </summary>
    /// <param name="cmdText">stored procedure</param>       
    /// <returns>Summary results, object</returns>        
    public object ExecuteProcScalar(string procName) {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(procName, CommandType.StoredProcedure);
        try {
            return objCmd.ExecuteScalar();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute a summary query stored procedure with one parameter 
    /// (that is, the first row and first column in the query result set) and return the Object object
    /// </summary>
    /// <param name="cmdText">stored procedure</param>
    /// <param name="para">Parameter object</param>
    /// <returns>Summary results, object</returns>        
    public object ExecuteProcScalar(string procName, MySqlParameter para) {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(procName, para, CommandType.StoredProcedure);
        try {
            return objCmd.ExecuteScalar();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute a summary query stored procedure with multiple parameters 
    /// (that is, the first row and first column in the query result set) and return the Object object
    /// </summary>
    /// <param name="cmdText">stored procedure</param>
    /// <param name="paras">Array of parameter objects</param>
    /// <returns>Summary results, object</returns>        
    public object ExecuteProcScalar(string procName, MySqlParameter[] paras) {
        BeginSqlTranscation();
        MySqlCommand objCmd = CreateSqlCommand(procName, paras, CommandType.StoredProcedure);
        try {
            return objCmd.ExecuteScalar();
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute the normal SQL query command without parameters and return the result set DataTable
    /// </summary>
    /// <param name="cmdText">Normal query SQL command</param>
    /// <returns>DataTable</returns>
    public DataTable ExecuteSqlDataTable(string cmdText) {
        BeginSqlTranscation();
        MySqlDataAdapter objDa = new MySqlDataAdapter();
        objDa.SelectCommand = CreateSqlCommand(cmdText, CommandType.Text);
        DataTable dt = new DataTable();
        try {
            objDa.Fill(dt);
            return dt;
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute the query SQL command with one parameter and return the result set DataTable
    /// </summary>
    /// <param name="cmdText">Query SQL command with one parameter</param>
    /// <param name="para">Parameter object</param>
    /// <returns>DataTable</returns>
    public DataTable ExecuteSqlDataTable(string cmdText, MySqlParameter para) {
        BeginSqlTranscation();
        MySqlDataAdapter objDa = new MySqlDataAdapter();
        objDa.SelectCommand = CreateSqlCommand(cmdText, para, CommandType.Text);
        DataTable dt = new DataTable();
        try {
            objDa.Fill(dt);
            return dt;
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute SQL command with multiple parameters to return the result set DataTable
    /// </summary>
    /// <param name="cmdText">Query SQL command with multiple parameters</param>
    /// <param name="paras">Array of parameter objects</param>
    /// <returns>DataTable</returns>
    public DataTable ExecuteSqlDataTable(string cmdText, MySqlParameter[] paras) {
        BeginSqlTranscation();
        MySqlDataAdapter objDa = new MySqlDataAdapter();
        objDa.SelectCommand = CreateSqlCommand(cmdText, paras, CommandType.Text);
        DataTable dt = new DataTable();
        try {
            objDa.Fill(dt);
            return dt;
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute the query stored procedure without parameters and return the result set DataTable
    /// </summary>
    /// <param name="cmdText">stored procedure</param>        
    /// <returns>DataTable</returns>
    public DataTable ExecuteProcedureDataTable(string procName) {
        BeginSqlTranscation();
        MySqlDataAdapter objDa = new MySqlDataAdapter();
        objDa.SelectCommand = CreateSqlCommand(procName, CommandType.StoredProcedure);
        DataTable dt = new DataTable();
        try {
            objDa.Fill(dt);
            return dt;
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute a query stored procedure with one parameter and return the result set DataTable
    /// </summary>
    /// <param name="cmdText">stored procedure</param>
    /// <param name="para">Parameter object</param>
    /// <returns>DataTable</returns>
    public DataTable ExecuteProcedureDataTable(string procName, MySqlParameter para) {
        BeginSqlTranscation();
        MySqlDataAdapter objDa = new MySqlDataAdapter();
        objDa.SelectCommand = CreateSqlCommand(procName, para, CommandType.StoredProcedure);
        DataTable dt = new DataTable();
        try {
            objDa.Fill(dt);
            return dt;
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Execute the query stored procedure with multiple parameters and return the result set DataTable
    /// </summary>
    /// <param name="cmdText">stored procedure</param>
    /// <param name="paras">Array of parameter objects</param>
    /// <returns>DataTable</returns>
    public DataTable ExecuteProcedureDataTable(string procName, MySqlParameter[] paras) {
        BeginSqlTranscation();
        MySqlDataAdapter objDa = new MySqlDataAdapter();
        objDa.SelectCommand = CreateSqlCommand(procName, paras, CommandType.StoredProcedure);
        DataTable dt = new DataTable();
        try {
            objDa.Fill(dt);
            return dt;
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Batch insert data
    /// </summary>
    /// <param name="dt">Data table object</param>
    /// <param name="InsertCmdText">SQL insert command with multiple parameters</param>
    /// <param name="paras">Array of parameter objects bound to data column names</param>
    public void BatchInsert(DataTable dt, string InsertCmdText, MySqlParameter[] paras) {
        BeginSqlTranscation();
        MySqlDataAdapter objDa = new MySqlDataAdapter();
        objDa.InsertCommand = CreateSqlCommand(InsertCmdText, paras, CommandType.Text);
        try {
            objDa.Update(dt);
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Batch update data
    /// </summary>
    /// <param name="dt">Data table object</param>
    /// <param name="UpdateCmdText">SQL update command with multiple parameters</param>
    /// <param name="paras">Array of parameter objects bound to data column names</param>
    public void BatchUpdate(DataTable dt, string UpdateCmdText, MySqlParameter[] paras) {
        BeginSqlTranscation();
        MySqlDataAdapter objDa = new MySqlDataAdapter();
        objDa.UpdateCommand = CreateSqlCommand(UpdateCmdText, paras, CommandType.Text);
        try {
            objDa.Update(dt);
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }

    /// <summary>
    /// Batch delete data
    /// </summary>
    /// <param name="dt">Data table object</param>
    /// <param name="DeleteCmdText">SQL delete command with multiple parameters</param>
    /// <param name="paras">Array of parameter objects bound to data column names</param>
    public void BatchDelete(DataTable dt, string DeleteCmdText, MySqlParameter[] paras) {
        BeginSqlTranscation();
        MySqlDataAdapter objDa = new MySqlDataAdapter();
        objDa.DeleteCommand = CreateSqlCommand(DeleteCmdText, paras, CommandType.Text);
        try {
            objDa.Update(dt);
        }
        catch (MySqlException exp) {
            RollBackSqlTranscation();
            throw exp;
        }
        finally {
            if (objTrans != null) {
                CommitSqlTranscation();
            }
            else {
                CloseDB();
            }
        }
    }
}