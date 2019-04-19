namespace Assignment7Test
{
    //The assignment text have both the Deposit and Withdraw inthere twice, thse will only be implented once
    public interface IAccount
    {
         void SetId(int id);
         int GetId();
         void SetBalance(double amount);
         double GetBalance();
         void Deposit(double amount);
         void WithDraw(double amount);
    }
}