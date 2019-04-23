namespace Assignment7Test
{
    public class Account : IAccount
    {
        private double _balance;
        private int _id;
        public bool Deposit(double amount)
        {
            if (amount>0)
            {
                _balance += amount;
                return true;
            }else
            {
                return false;
            }
        }

        public double GetBalance()
        {
            return _balance;
        }

        public int GetId()
        {
            return _id;
        }

        public bool SetBalance(double amount)
        {
            if(amount>0){
                _balance = amount;
                return true;
            }else
            {
                return false;
            }
            
        }

        public bool SetId(int id)
        {
            if(id>0){
                _id=id;
                return true;
            }else
            {
                return false;
            }
        }

        public bool WithDraw(double amount)
        {
            if(amount>0){
                if(amount>_balance){
                    return false;
                }else{
                    _balance = _balance - amount;
                    return true;
                }
            }else
            {
                return false;
            }
        }
    }
}