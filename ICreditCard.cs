using System;

namespace Assignment7Test
{
    public interface ICreditCard
    {
         bool SetId(int id);
         int GetId();
         void SetAccount(IAccount accInterface);
         IAccount GetAccount();
         bool SetCreated(DateTime created);
         DateTime GetCreated();
         bool SetLastUsed(DateTime lastUsed);
         DateTime GetLastUsed();
         bool SetPinCode(int pin);
         int GetPinCode();
         bool SetWrongPinCodeAttemps(int attemps);
         int GetWrongPinCodeAttemps();
         void ResetWrongPinCodeAttemps();
         void SetBlocked(bool blocked);
         bool IsBlocked();
    }
}