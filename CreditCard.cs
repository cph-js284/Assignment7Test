using System;

namespace Assignment7Test
{
    public class CreditCard : ICreditCard
    {
        int _id;
        DateTime _created,_lastUsed; 
        int _pinCode;
        int _pinCodeAttemps;
        bool _blocked;
        IAccount _account;


        public IAccount GetAccount()
        {
            return _account;
        }

        public DateTime GetCreated()
        {
            return _created;
        }

        public int GetId()
        {
            return _id;
        }

        public DateTime GetLastUsed()
        {
            return _lastUsed;
        }

        public int GetPinCode()
        {
            return _pinCode;
        }

        public int GetWrongPinCodeAttemps()
        {
            return _pinCodeAttemps;
        }

        public bool IsBlocked()
        {
            return _blocked;
        }

        public void ResetWrongPinCodeAttemps()
        {
            _pinCodeAttemps = 0;
        }

        //perhaps check for invalid account object? 
        public void SetAccount(IAccount accInterface)
        {
            _account = accInterface;
        }

        public void SetBlocked(bool blocked)
        {
            _blocked = blocked;
        }

        public bool SetCreated(DateTime created)
        {
            var diff =DateTime.Now.Subtract(created);
            //more than 100 years ago or in the future (counting ticks would make it more precise)
            if(diff.Days > 36500 || diff.Days< 0){
                return false;
            }else
            {
                _created = created;
                return true;
            }
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
            var diff =DateTime.Now.Subtract(lastUsed);
            //more than 100 years ago or in the future (counting ticks would make it more precise)
            if(diff.Days > 36500 || diff.Days< 0){
                return false;
            }else
            {
                _lastUsed = lastUsed;
                return true;
            }
            
        }

        public bool SetPinCode(int pin)
        {
            if(pin>999 && pin < 9999){
                _pinCode = pin;
                return true;
            }else{
                return false;
            }
        }
        //Bank allows 3 times wrong input, 4th. wrong input triggers universal meltdown
        public bool SetWrongPinCodeAttemps(int attemps)
        {
            if(attemps<4 && attemps>0){
                _pinCodeAttemps=attemps;
                return true;
            }else
            {
                return false;
            }
        }
    }
}