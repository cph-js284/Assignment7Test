using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Assignment7Test
{
    public class BankMapper : IBankMapper
    {
        string _connectionString;

        public async Task<IAccount> createAccount(IAccount account)
        {
            using(var conn = new SQLiteConnection(_connectionString)){
                conn.Open();
                var sqlstr="INSERT INTO Account(balance) VALUES (" + account.GetBalance() +");";
                var command = new SQLiteCommand(sqlstr,conn);
                    await command.ExecuteNonQueryAsync();
            }
            return account;
        }

        public async Task<ICreditCard> createCreditCard(ICreditCard cc)
        {
            using(var conn = new SQLiteConnection(_connectionString)){
                conn.Open();
                //newly created CCs with 0 wrongpinattemps and not blocked
                var sqlstr=@"INSERT INTO Creditcard (created, lastused, pin, wrongpincodeattemps, account, blocked) 
                            VALUES ('"+ cc.GetCreated().ToLongDateString() + "','" + cc.GetLastUsed().ToLongDateString() + "',"+ cc.GetPinCode() +", 0," + cc.GetAccount().GetId()+ ", 0);";
                System.Console.WriteLine(sqlstr);
                var command = new SQLiteCommand(sqlstr,conn);
                    await command.ExecuteNonQueryAsync();
            }
            return cc;
        }

        public async Task<IAccount> getAccount(int id)
        {
            IAccount account = new Account();
            using(var conn = new SQLiteConnection(_connectionString)){
                conn.Open();
                var sqlstr="SELECT * FROM Account where id = " + id;
                var command = new SQLiteCommand(sqlstr,conn);
                    var reader = await command.ExecuteReaderAsync();
                    account.SetBalance(Convert.ToDouble(reader["balance"]));
            }
            return account;
        }

        public async Task<List<IAccount>> getAccounts()
        {
            List<IAccount> allAccounts = new List<IAccount>();
            using(var conn = new SQLiteConnection(_connectionString)){
                conn.Open();
                var sqlstr="SELECT * FROM Account;";
                var command = new SQLiteCommand(sqlstr,conn);
                    var reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        Account atmp = new Account();
                        atmp.SetId(Convert.ToInt32(reader["id"]));
                        atmp.SetBalance(Convert.ToDouble(reader["balance"]));
                        allAccounts.Add(atmp);
                    }
            }
            return allAccounts;
        }

        public async Task<ICreditCard> getCreditcard(int id)
        {
            ICreditCard cc = new CreditCard();
            using(var conn = new SQLiteConnection(_connectionString)){
                conn.Open();
                var sqlstr="SELECT * FROM Creditcard where id = " + id;
                var command = new SQLiteCommand(sqlstr,conn);
                var reader = await command.ExecuteReaderAsync();
                cc.SetId(Convert.ToInt32(reader["id"]));
                Account acc = new Account();
                acc.SetId(Convert.ToInt32(reader["account"])); //lazy loading - only fetching id from db untill account data is actually used
                cc.SetAccount(acc);
                cc.SetBlocked(Convert.ToBoolean(reader["blocked"]));
                cc.SetCreated(Convert.ToDateTime(reader["created"]));
                cc.SetLastUsed(Convert.ToDateTime(reader["lastused"]));
                cc.SetWrongPinCodeAttemps(Convert.ToInt32(reader["wrongpincodeattemps"]));
                }
            return cc;
        }

        public async Task<List<ICreditCard>> getCreditCards()
        {
            List<ICreditCard> CCs = new List<ICreditCard>();
            using(var conn = new SQLiteConnection(_connectionString)){
                conn.Open();
                var sqlstr="SELECT * FROM Creditcard";
                var command = new SQLiteCommand(sqlstr,conn);
                var reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    CreditCard cc = new CreditCard();
                    cc.SetId(Convert.ToInt32(reader["id"]));
                    Account acc = new Account();
                    acc.SetId(Convert.ToInt32(reader["account"])); //lazy loading - only fetching id from db untill account data is actually used
                    cc.SetAccount(acc);
                    cc.SetBlocked(Convert.ToBoolean(reader["blocked"]));
                    cc.SetCreated(Convert.ToDateTime(reader["created"]));
                    cc.SetLastUsed(Convert.ToDateTime(reader["lastused"]));
                    cc.SetWrongPinCodeAttemps(Convert.ToInt32(reader["wrongpincodeattemps"]));
                    cc.SetPinCode(Convert.ToInt32(reader["pin"]));
                    CCs.Add(cc);
                }
            }
            return CCs;
        }

        public void setDataSource(string connection)
        {
            _connectionString = connection;
        }

        public async void updateAccount(IAccount account)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                var sqlstr = @"UPDATE Account set balance = " + account.GetBalance() + 
                              "where id = " + account.GetId() + ";";
                var command = new SQLiteCommand(sqlstr,conn);
                    await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<ICreditCard> updateCreditCard(ICreditCard cc)
        {
            using (var conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                var sqlstr= @"UPDATE Creditcard set created = " + cc.GetCreated() +
                            "lastused = " + cc.GetLastUsed() +
                            "pin = " + cc.GetPinCode() +
                            "wrongpincodeattemps = " + cc.GetWrongPinCodeAttemps() +
                            "account = " + cc.GetAccount().GetId() +
                            "blocked = " + cc.IsBlocked() +
                            "WHERE id = " + cc.GetId() + ";";
                var command = new SQLiteCommand(sqlstr,conn);
                    await command.ExecuteNonQueryAsync();
            }
            return cc;
        }
    }
}