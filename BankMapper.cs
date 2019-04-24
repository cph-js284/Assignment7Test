using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;

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
                            VALUES ("+ cc.GetCreated().ToString() + "," + cc.GetLastUsed().ToString() + ","+ cc.GetPinCode() +", 0," + cc.GetAccount().GetId()+ ", 0);";
                var command = new SQLiteCommand(sqlstr,conn);
                    await command.ExecuteNonQueryAsync();
            }
            return cc;
        }

        public IAccount getAccount(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<IAccount> getAccounts()
        {
            throw new System.NotImplementedException();
        }

        public ICreditCard getCreditcard(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<ICreditCard> getCreditCards()
        {
            throw new System.NotImplementedException();
        }

        public void setDataSource(string connection)
        {
            _connectionString = connection;
        }

        public void updateAccount(IAccount account)
        {
            throw new System.NotImplementedException();
        }

        public ICreditCard updateCreditCard(ICreditCard cc)
        {
            throw new System.NotImplementedException();
        }
    }
}