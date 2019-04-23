using System;

namespace Assignment7Test
{
    public class CreditCard : ICreditCard
    {
        int _id;
        DateTime _created,_lastUsed; 
        int _pincode;
        int pinCodeAttemps;
        bool _blocked;
        IAccount _account;


        public IAccount GetAccount()
        {
            throw new NotImplementedException();
        }

        public DateTime GetCreated()
        {
            throw new NotImplementedException();
        }

        public int GetId()
        {
            return _id;
        }

        public DateTime GetLastUsed()
        {
            throw new NotImplementedException();
        }

        public int GetPinCode()
        {
            throw new NotImplementedException();
        }

        public int GetWrongPinCodeAttemps()
        {
            throw new NotImplementedException();
        }

        public bool IsBlocked()
        {
            throw new NotImplementedException();
        }

        public bool ResetWrongPinCodeAttemps()
        {
            throw new NotImplementedException();
        }

        //perhaps check for invalid account object? 
        public void SetAccount(IAccount accInterface)
        {
            _account = accInterface;
        }

        public void SetBlocked(bool blocked)
        {
            throw new NotImplementedException();
        }

        public bool SetCreated(DateTime created)
        {
            throw new NotImplementedException();
        }

        public bool SetId(int id)
        {
            if(id>0){
                _id = id;
                return true;
            }else
            {
                return false;
            }
        }

        public bool SetLastUsed(DateTime lastUsed)
        {
            throw new NotImplementedException();
        }

        public bool SetPinCode(int pin)
        {
            throw new NotImplementedException();
        }

        public bool SetWrongPinCodeAttemps(int attemps)
        {
            throw new NotImplementedException();
        }
    }
}