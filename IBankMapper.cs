using System.Collections.Generic;

namespace Assignment7Test
{
    public interface IBankMapper
    {
        void setDataSource(string connectionString);
        ICreditCard createCreditCard(ICreditCard cc);
        ICreditCard updateCreditCard(ICreditCard cc);
        ICreditCard getCreditcard(int id);
        List<ICreditCard> getCreditCards();        
        IAccount createAccount(IAccount account);
        void updateAccount(IAccount account);
        IAccount getAccount(int id);
        List<IAccount> getAccounts();

    }
}