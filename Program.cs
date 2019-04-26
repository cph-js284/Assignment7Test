using System;
using System.Threading.Tasks;

namespace Assignment7Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //setting up a DB.
            string connectionStr = "Data Source=testDb.db";
            sql newsql = new sql(connectionStr);

            IBankMapper mapper = new BankMapper();

            Bank myBank = new Bank(mapper);
            myBank.SetSource(connectionStr);
            var newCustomerAccount = myBank.CreateNewAcc();

            newCustomerAccount.SetBalance(9000);
            await myBank.createAccount(newCustomerAccount);

            var AllAccounts = myBank.getAllAccounts();
            System.Console.WriteLine("Reading Accounts");
            foreach (var item in await AllAccounts) // streaming
            {
                System.Console.WriteLine($"ID: {item.GetId()} - Balance: {item.GetBalance()}");
            }

            var AllCreditCards = myBank.getAllCCs();
            System.Console.WriteLine("----------------------------------");
            System.Console.WriteLine("Reading Creditscards");
            foreach (var item in await AllCreditCards) //streaming
            {
                System.Console.WriteLine($"ID: {item.GetId()} - Created: {item.GetCreated()} - LastUsed: {item.GetLastUsed()} - AccountID: {item.GetAccount().GetId()} - PIN: {item.GetPinCode()} - Blocked: {item.IsBlocked()}");
            }
            //keep terminal open untill user termination
            System.Console.WriteLine("Press any key to close terminal");
            Console.ReadKey();
        }
    }
}
