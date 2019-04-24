using System.Data.SQLite;

namespace Assignment7Test
{
    public class sql
    {
        string _connStr;
        public sql(string _conn)
        {
            _connStr=_conn;
        }

        public void CreateDataBase(){
            SQLiteConnection.CreateFile("testDb.db");
        }
        public void CreateTables(){
            using (var conn = new SQLiteConnection(_connStr))
            {
                conn.Open();
                var sqlstr= @"CREATE TABLE Account(
                    id INTEGER PRIMARY KEY,
                    balance INTEGER
                );"; 
                //split into seperate commands to avoid bleeding eyes 
                // slite does not support datetime/boolean types - reference official docs 
                var sqlstr2=@"CREATE TABLE Creditcard(
                    id INTEGER PRIMARY KEY,
                    created TEXT,
                    lastused TEXT,
                    pin INTEGER,
                    wrongpincodeattemps INT,
                    account INTEGER,
                    blocked INTEGER
                );";              

                var command = new SQLiteCommand(sqlstr,conn);
                    command.ExecuteNonQuery();
                
                command = new SQLiteCommand(sqlstr2, conn);
                    command.ExecuteNonQuery();

            }
        }

        public void CreateState(){
            using (var conn = new SQLiteConnection(_connStr))
            {
                conn.Open();
                var sqlstr = @"
                            INSERT INTO Account (balance) VALUES (1000);
                            INSERT INTO Account (balance) VALUES (2000);
                            INSERT INTO Account (balance) VALUES (3000);
                            INSERT INTO Account (balance) VALUES (4000);
                            INSERT INTO Account (balance) VALUES (5000);
                            ";
                var sqlstr2 = @"
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Jan, 2001', '2 Jan, 2009', 1234, 0, 1, 0);
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Dec, 2002', '2 Jan, 2019', 2345, 0, 3, 0);
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Apr, 2005', '2 Jan, 2012', 3456, 0, 4, 0);
                            ";

                var command = new SQLiteCommand(sqlstr,conn);
                    command.ExecuteNonQuery();

                command = new SQLiteCommand(sqlstr2, conn);
                    command.ExecuteNonQuery();

            }
        }

        /*DEBUG READER FR SANITY */
        public void read(){
            using (var conn = new SQLiteConnection(_connStr))
            {
                conn.Open();
                var sqlstr = "SELECT * FROM Account";
                var command = new SQLiteCommand(sqlstr,conn);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    System.Console.WriteLine("data - " + reader["balance"].ToString());
                }
            }
        }
    }
}