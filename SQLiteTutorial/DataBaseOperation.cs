using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace SQLiteTutorial
{
    class DataBaseOperation
    {
        /// <summary>
        /// 連結資料庫
        /// </summary>
        /// <param name="dbConnectionString">資料庫位置及名稱</param>
        /// <param name="Query">欲下的指令</param>
        /// <param name="sqliteCon">sqlite connection物件</param>
        /// <param name="sqliteCmd">sqlite connection物件</param>
        public static void ConnectToDataBase(string dbConnectionString, string Query, ref SQLiteConnection sqliteCon, ref SQLiteCommand sqliteCmd)
        {
            sqliteCon = new SQLiteConnection(dbConnectionString);
            //--- Open connection to database
            sqliteCon.Open();
            sqliteCmd = new SQLiteCommand(Query, sqliteCon);
            sqliteCmd.ExecuteNonQuery();
            //sqliteCon.Close();
        }

    }
}
