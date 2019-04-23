using System.Collections.Generic;

namespace Assignment7Test
{
    public class BankMapper : IBankMapper
    {
        public IAccount createAccount(IAccount account)
        {
            throw new System.NotImplementedException();
        }

        public ICreditCard createCreditCard(ICreditCard cc)
        {
            throw new System.NotImplementedException();
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

        public void setDataSource(string connectionString)
        {
            throw new System.NotImplementedException();
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