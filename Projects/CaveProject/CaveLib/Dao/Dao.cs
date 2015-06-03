using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Data;
//using System.Data.SqlClient;

//using System.Data.SQLite;

namespace CaveLib.Dao
{
    class Dao
    {
        //private SQLiteConnection sql_con;
        //private SQLiteCommand sql_cmd;
        //private SQLiteDataAdapter DB;
        //private DataSet DS = new DataSet();
        //private DataTable DT = new DataTable();

        public Dao()
        {

        }

        //private void SetConnection()
        //{
        //    sql_con = new SQLiteConnection
        //        ("Data Source=DemoT.db;Version=3;New=False;Compress=True;");
        //}

        //private void ExecuteQuery(string txtQuery)
        //{
        //    SetConnection();
        //    sql_con.Open();
        //    sql_cmd = sql_con.CreateCommand();
        //    sql_cmd.CommandText = txtQuery;
        //    sql_cmd.ExecuteNonQuery();
        //    sql_con.Close();
        //}

        //private void LoadData()
        //{
        //    SetConnection();
        //    sql_con.Open();
        //    sql_cmd = sql_con.CreateCommand();
        //    string CommandText = "select id, desc from mains";
        //    DB = new SQLiteDataAdapter(CommandText, sql_con);
        //    DS.Reset();
        //    DB.Fill(DS);
        //    DT = DS.Tables[0];
        //    //Grid.DataSource = DT;
        //    sql_con.Close();
        //}

        //private void Add()
        //{
        //    string txtSQLQuery;
        //    //txtSQLQuery = "insert into  mains (desc) values ('" + txtDesc.Text + "')";
        //    //ExecuteQuery(txtSQLQuery);
        //}
    }
}
