using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment7Test
{
    /******************************************************************* 
    * This is a class that makes use of the BankMapper 
    * This class has been reduced on purpose to maintain focus on the 
    * test part of the hand-in (this class is mainly just to make the main go)
    *********************************************************************/
    public class Bank
    {
        IBankMapper mapper;
        public Bank(IBankMapper _mapper)
        {
            mapper=_mapper;
        }

        public void SetSource(string source){
            mapper.setDataSource(source);
        }

        public async Task<List<IAccount>> getAllAccounts(){
            return await mapper.getAccounts();
        }
            
        public async Task<IAccount> createAccount(IAccount acc){
            return await mapper.createAccount(acc);
        }

        public Account CreateNewAcc(){
            return new Account();
        }

        public async Task<List<ICreditCard>> getAllCCs(){
            return await mapper.getCreditCards();
        }


    }
}