using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment7Test
{
    public interface IBankMapper
    {
        void setDataSource(string connectionString);
        Task<ICreditCard> createCreditCard(ICreditCard cc);
        Task<ICreditCard> updateCreditCard(ICreditCard cc);
        Task<ICreditCard> getCreditcard(int id);
        Task<List<ICreditCard>> getCreditCards();        
        Task<IAccount> createAccount(IAccount account);
        void updateAccount(IAccount account);
        Task<IAccount> getAccount(int id);
        Task<List<IAccount>> getAccounts();

    }
}