namespace Assignment7Test
{
    //The assignment text have both the Deposit and Withdraw inthere twice, thse will only be implented once
    public interface IAccount
    {
         bool SetId(int id);
         int GetId();
         bool SetBalance(double amount);
         double GetBalance();
         bool Deposit(double amount);
         bool WithDraw(double amount);
    }
}