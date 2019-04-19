using System;

namespace Assignment7Test
{
    public interface ICreditCard
    {
         void SetId(int id);
         int GetId();
         void SetAccount(IAccount accInterface);
         IAccount GetAccount();
         void SetCreated(DateTime created);
         DateTime GetCreated();
         void SetLastUsed(DateTime lastUsed);
         DateTime GetLastUsed();
         void SetPinCode(int pin);
         int GetPinCode();
         void SetWrongPinCodeAttemps(int attemps);
         int GetWrongPinCodeAttemps();
         void ResetWrongPinCodeAttemps();
         void SetBlocked(bool blocked);
         bool IsBlocked();
    }
}