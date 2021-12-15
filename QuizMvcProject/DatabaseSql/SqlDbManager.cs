using MySql.Data.MySqlClient;
using QuizTemplateMvcDotnet6.DatabaseSql;
using System.Data;

namespace Quick_Quiz
{
    public static  class SqlDbManager
    {
        public const string dbOldPddAll = "newschema2";
        public const string dbPddEntityNew = "pddentitynew";

        public static SqlBuilderQuery sqlBuilderOldPdd { get; private set; } = new SqlBuilderQuery(dbOldPddAll);
        public static SqlBuilderQuery sqlBuilderEntity { get; private set; }  = new SqlBuilderQuery(dbPddEntityNew);

        //private static MySqlConnection dbConnection;
        private static MySqlConnection dbConnection; // = new MySqlConnection(mysqlstr);

        //SQL QUERIES:   
        public static string[] sqlQueries = new string[]
        {
            //EXAMPLE: SELECT * FROM YOUR_DB.YOUR_TABLE;
            "SELECT * FROM allusersdb.allusers", //0 all
            "SELECT * FROM allusersdb.allusers LIMIT", //1 limit to ..
            "SELECT * FROM " + dbOldPddAll + ".allquestions", //2 all
            "SELECT idQuestion, textQuestion, allAnswers FROM " + dbOldPddAll + ".allquestions LIMIT", //3 limit to ..
            "SELECT idQuestion, textQuestion, allAnswers, amountAnswers, pictureUrl FROM " + dbOldPddAll + ".allquestions ORDER BY RAND() LIMIT" //4 limit to ..
        };
        
        //calls ready sql queries:
        public static DataTable GetAllData()
        {
            return GetDataFromQuery(sqlQueries[2]);
        }
        public static DataTable GetAllDataLimit(string argString)
        {
            return GetDataFromQuery(sqlQueries[4] + " " + argString);
        }

        public static void WakeSqlDb()
        {
            ConnectToServer();
            //GetDataFromDb();
        }
        private static void ConnectToServer()
        {
            dbConnection = new MySqlConnection(sqlBuilderOldPdd.GetConnectionString());  //mysqlstr
            TurnConnect(true);
        }
        private static void TurnConnect(bool newState)
        {
            if (newState)
                dbConnection.Open();
            else
                dbConnection.Close();
        }
        
        public static DataTable GetDataFromQuery(string argQuery)
        {
            DataTable toReturn = new DataTable();
            MySqlCommand allGetCommand = new MySqlCommand(argQuery, dbConnection);
            MySqlDataReader sqlReader = allGetCommand.ExecuteReader();
            toReturn.Load(sqlReader);

            return toReturn;
        }
    }
}
