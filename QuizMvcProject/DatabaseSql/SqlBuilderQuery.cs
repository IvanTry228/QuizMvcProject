namespace QuizTemplateMvcDotnet6.DatabaseSql
{
    public class SqlBuilderQuery
    {
        public string bodySql { get; private set; } = "server=localhost;" + //server=127.0.0.1
                                                        "port=3306;" +
                                                        "user=root;" +
                                                        "password=mysqlroot1111;" +
                                                        "database=";

        public string currentDbName { get; private set; } = "newschema2";

        public string GetConnectionString()
        {
            return bodySql + currentDbName;
        }

        public SqlBuilderQuery(string _dbName)
        {
            currentDbName = _dbName;
        }
    }
}
