using System.Collections.Generic;
using System.Data.SQLite;
using NUnit.Framework;


namespace Assignment7Test
{
    [Category("Integration-test-inmemory")]
    [Category("BankMapper-test")]
    public class BankMapper_inmem_Tests
    {
        [SetUp]
        public void setup(){
            
        }
        /******************************************************************************* */
        //These in-memory test are kinda bloated due to the fact that the db ceases to exist when 
        //connection is closed.
        /*********************************************************************************** */
        [Test]
        public void DBinMem_AccountTblContains5diffBalances_Returns5(){
            using (var conn = new SQLiteConnection("Data Source=:memory:"))
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
               
                sqlstr = @"
                            INSERT INTO Account (balance) VALUES (1000);
                            INSERT INTO Account (balance) VALUES (2000);
                            INSERT INTO Account (balance) VALUES (3000);
                            INSERT INTO Account (balance) VALUES (4000);
                            INSERT INTO Account (balance) VALUES (5000);
                            ";
                sqlstr2 = @"
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Jan, 2001', '2 Jan, 2009', 1234, 0, 1, 0);
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Dec, 2002', '2 Jan, 2019', 2345, 0, 3, 0);
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Apr, 2005', '2 Jan, 2012', 3456, 0, 4, 0);
                            ";

                command = new SQLiteCommand(sqlstr,conn);
                    command.ExecuteNonQuery();

                command = new SQLiteCommand(sqlstr2, conn);
                    command.ExecuteNonQuery();


                sqlstr = "SELECT * FROM Account";
                command = new SQLiteCommand(sqlstr,conn);

                var reader = command.ExecuteReader();
                
                List<string> dbContents = new List<string>();

                while (reader.Read())
                {
                    dbContents.Add(reader["balance"].ToString());
                }

                Assert.That(dbContents, Has.Exactly(5).Items);
                Assert.That(dbContents, Has.Exactly(1).EqualTo("1000")
                            .And.Exactly(1).EqualTo("2000")
                            .And.Exactly(1).EqualTo("3000")
                            .And.Exactly(1).EqualTo("4000")
                            .And.Exactly(1).EqualTo("5000"));


                //Not stricly needed since inside a using-statement
                //Close kills the database when in-memory
                conn.Close();
            }
        }

        [Test]
        public void DBinMem_CreditCardTblContains3diffPins_Returns3(){
            using (var conn = new SQLiteConnection("Data Source=:memory:"))
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
               
                sqlstr = @"
                            INSERT INTO Account (balance) VALUES (1000);
                            INSERT INTO Account (balance) VALUES (2000);
                            INSERT INTO Account (balance) VALUES (3000);
                            INSERT INTO Account (balance) VALUES (4000);
                            INSERT INTO Account (balance) VALUES (5000);
                            ";
                sqlstr2 = @"
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Jan, 2001', '2 Jan, 2009', 1234, 0, 1, 0);
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Dec, 2002', '2 Jan, 2019', 2345, 0, 3, 0);
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Apr, 2005', '2 Jan, 2012', 3456, 0, 4, 0);
                            ";

                command = new SQLiteCommand(sqlstr,conn);
                    command.ExecuteNonQuery();

                command = new SQLiteCommand(sqlstr2, conn);
                    command.ExecuteNonQuery();


                sqlstr = "SELECT * FROM Creditcard";
                command = new SQLiteCommand(sqlstr,conn);

                var reader = command.ExecuteReader();
                
                List<string> dbContents = new List<string>();

                while (reader.Read())
                {
                    dbContents.Add(reader["pin"].ToString());
                }

                Assert.That(dbContents, Has.Exactly(3).Items);
                Assert.That(dbContents, Has.Exactly(1).EqualTo("1234")
                            .And.Exactly(1).EqualTo("2345")
                            .And.Exactly(1).EqualTo("3456"));

                //Not stricly needed since inside a using-statement
                //Close kills the database when in-memory
                conn.Close();
            }
        }

        [Test]
        public void DBinMem_AccountTblContains1AccountAfterInsert_Returns6(){
            using (var conn = new SQLiteConnection("Data Source=:memory:"))
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
               
                sqlstr = @"
                            INSERT INTO Account (balance) VALUES (1000);
                            INSERT INTO Account (balance) VALUES (2000);
                            INSERT INTO Account (balance) VALUES (3000);
                            INSERT INTO Account (balance) VALUES (4000);
                            INSERT INTO Account (balance) VALUES (5000);
                            ";
                sqlstr2 = @"
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Jan, 2001', '2 Jan, 2009', 1234, 0, 1, 0);
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Dec, 2002', '2 Jan, 2019', 2345, 0, 3, 0);
                            INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) VALUES ('1 Apr, 2005', '2 Jan, 2012', 3456, 0, 4, 0);
                            ";

                command = new SQLiteCommand(sqlstr,conn);
                    command.ExecuteNonQuery();

                command = new SQLiteCommand(sqlstr2, conn);
                    command.ExecuteNonQuery();


                sqlstr = "SELECT * FROM Account";
                command = new SQLiteCommand(sqlstr,conn);

                var reader = command.ExecuteReader();
                
                List<string> dbContents = new List<string>();

                while (reader.Read())
                {
                    dbContents.Add(reader["balance"].ToString());
                }

                //contents of DB before insert
                Assert.That(dbContents, Has.Exactly(5).Items);
                Assert.That(dbContents, Has.Exactly(1).EqualTo("1000")
                            .And.Exactly(1).EqualTo("2000")
                            .And.Exactly(1).EqualTo("3000")
                            .And.Exactly(1).EqualTo("4000")
                            .And.Exactly(1).EqualTo("5000"));

                
                var extraAccount=new Account();
                extraAccount.SetBalance(9000);

                //adding one additional account
                var sqlstrExtra = @"INSERT INTO Account (balance) VALUES (" + extraAccount.GetBalance() + ");";
                command = new SQLiteCommand(sqlstrExtra, conn);
                    command.ExecuteNonQuery();

                sqlstr = "SELECT * FROM Account";
                command = new SQLiteCommand(sqlstr,conn);

                reader = command.ExecuteReader();
                
                dbContents = new List<string>();

                while (reader.Read())
                {
                    dbContents.Add(reader["balance"].ToString());
                }

                //asserting contents after additional insert
                Assert.That(dbContents, Has.Exactly(6).Items);
                Assert.That(dbContents, Has.Exactly(1).Items.EqualTo("9000"));

                //Not stricly needed since inside a using-statement
                //Close kills the database when in-memory
                conn.Close();
            }
        }


    }
}