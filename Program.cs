using System;
using System.Threading.Tasks;

namespace Assignment7Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            sql newsql = new sql("Data Source=testDb.db");
            newsql.CreateDataBase();
            newsql.CreateTables();
            newsql.CreateState();
            Account a1 = new Account();
            a1.SetBalance(9000);
            BankMapper b1 = new BankMapper();
            b1.setDataSource("Data Source=testDb.db");
            await b1.createAccount(a1);
            newsql.read();
        }
    }
}
