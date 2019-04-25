using System;
using System.Threading.Tasks;

namespace Assignment7Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string CS = "Data Source=testDb.db";
            sql newsql = new sql(CS);
            Account acc = new Account();
            acc.SetBalance(9000);
            BankMapper myBank = new BankMapper();
            myBank.setDataSource(CS);
            await myBank.createAccount(acc);
            var res = await myBank.getAccounts();
            System.Console.WriteLine("Reading Accounts");
            foreach (var item in res)
            {
                System.Console.WriteLine($"ID: {item.GetId()} - Balance: {item.GetBalance()}");
            }
            var CCs = myBank.getCreditCards();
            System.Console.WriteLine("----------------------------------");
            System.Console.WriteLine("Reading Creditscards");
            foreach (var item in await CCs) //in effect a creditcard stream
            {
                System.Console.WriteLine($"ID: {item.GetId()} - Created: {item.GetCreated()} - LastUsed: {item.GetLastUsed()} - AccountID: {item.GetAccount().GetId()} - PIN: {item.GetPinCode()} - Blocked: {item.IsBlocked()}");
            }
            //keep terminal open untill user termination
            System.Console.WriteLine("Press any key to close terminal");
            Console.ReadKey();
        }
    }
}
