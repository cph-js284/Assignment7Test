using System;
using System.Reflection;
using Assignment7Test;
using NUnit.Framework;

namespace Assignment7Test
{
    [Category("Unit-test")]
    [Category("CreditCard-test")]
    public class CreditCardTests
    {
        ICreditCard cc;
        [SetUp]
        public void setup(){
            cc = new CreditCard();
        }
        [TearDown]
        public void Teardown(){

        }

        [Test]
        public void setId_invalidValue_returnFalse(){
            var setIdBool = cc.SetId(-42);
            FieldInfo fi = typeof(CreditCard).GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsFalse(setIdBool);
            Assert.That(actual, Is.EqualTo(0));  // null for ints => 0  
        }

        [Test]
        public void setId_validValue_returnTrue(){
            var setIdBool = cc.SetId(42);
            FieldInfo fi = typeof(CreditCard).GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsTrue(setIdBool);
            Assert.That(actual, Is.EqualTo(42));  
        }

        [Test]
        public void getId_Emptyvalue_returnId0(){
            var actual = cc.GetId();
            Assert.That(actual, Is.EqualTo(0));  // null for ints => 0  
        }

        [Test]
        public void getId_nonvalue_returnId(){
            var setIdBool = cc.SetId(42);
            var actual = cc.GetId();

            FieldInfo fi = typeof(CreditCard).GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldval = fi.GetValue(cc);

            Assert.IsTrue(setIdBool);
            Assert.That(actual, Is.EqualTo(fieldval));  
        }

        [Test]
        public void setAccount_AccountIsUpdated(){
            cc.SetAccount(new Account());
            FieldInfo fi = typeof(CreditCard).GetField("_account", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);
            // does the variable contain an account object
            Assert.That(actual, Is.InstanceOf(typeof(Account))); 
        }

        [Test]
        public void setCreated_invalidValue_tooLongAgo_ReturnFalse(){
            var created = (DateTime.Now).AddYears(-101); //101 years ago
            var setCreatedBool = cc.SetCreated(created);

            Assert.IsFalse(setCreatedBool);
        }

        [Test]
        public void setCreated_invalidValue_Future_ReturnFalse(){
            var created = (DateTime.Now).AddYears(1); //1 year from now
            var setCreatedBool = cc.SetCreated(created);

            Assert.IsFalse(setCreatedBool);
        }

        [Test]
        public void setCreated_validValue_betweenNow_99yearsAgo_ReturnTrue(){
            var created = (DateTime.Now).AddYears(-50); // 50 years ago
            var setCreatedBool = cc.SetCreated(created);

            Assert.IsTrue(setCreatedBool);
            FieldInfo fi = typeof(CreditCard).GetField("_created", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsTrue(setCreatedBool);
            Assert.That(actual, Is.EqualTo(created));
        }

        [Test]
        public void getCreated_returnCreatedDate(){
            var setCreatedBool = cc.SetCreated(DateTime.Now.AddDays(-1));
            var createdVal = cc.GetCreated();
            FieldInfo fi = typeof(CreditCard).GetField("_created", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsTrue(setCreatedBool);
            Assert.That(actual, Is.EqualTo(createdVal));
        }


        [Test]
        public void setLastUsed_invalidValue_tooLongAgo_ReturnFalse(){
            var used = (DateTime.Now).AddYears(-101); //101 years ago
            var setUsedBool = cc.SetLastUsed(used);

            Assert.IsFalse(setUsedBool);
        }

        [Test]
        public void setLastUsed_invalidValue_Future_ReturnFalse(){
            var Used = (DateTime.Now).AddYears(1); //1 year from now
            var setUsedBool = cc.SetLastUsed(Used);

            Assert.IsFalse(setUsedBool);
        }

        [Test]
        public void setLastUsed_validValue_betweenNow_99yearsAgo_ReturnTrue(){
            var Used = (DateTime.Now).AddYears(-50); // 50 years ago
            var setUsedBool = cc.SetLastUsed(Used);

            Assert.IsTrue(setUsedBool);
            FieldInfo fi = typeof(CreditCard).GetField("_lastUsed", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsTrue(setUsedBool);
            Assert.That(actual, Is.EqualTo(Used));
        }

        [Test]
        public void getLastUsed_returnLastUsedDate(){
            var setlastUsedBool = cc.SetLastUsed(DateTime.Now.AddDays(-1));
            var LastUsedVal = cc.GetLastUsed();
            FieldInfo fi = typeof(CreditCard).GetField("_lastUsed", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsTrue(setlastUsedBool);
            Assert.That(actual, Is.EqualTo(LastUsedVal));
        }

        [Test]
        public void setPinCode_invalidCode_MoreThan4Digits_returnFalse(){
            int code = 12345;
            var setpinBool = cc.SetPinCode(code);

            FieldInfo fi = typeof(CreditCard).GetField("_pinCode", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsFalse(setpinBool);
            Assert.That(actual, Is.EqualTo(0));
        }
        [Test]
        public void setPinCode_invalidCode_LessThan4Digits_returnFalse(){
            int code = 123;
            var setpinBool = cc.SetPinCode(code);

            FieldInfo fi = typeof(CreditCard).GetField("_pinCode", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsFalse(setpinBool);
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void setPinCode_invalidCode_returnFalse(){
            int code = -123;
            var setpinBool = cc.SetPinCode(code);

            FieldInfo fi = typeof(CreditCard).GetField("_pinCode", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsFalse(setpinBool);
            Assert.That(actual, Is.EqualTo(0));
        }
        [Test]
        public void setPinCode_ValidCode_returnTrue(){
            int code = 4123;
            var setpinBool = cc.SetPinCode(code);

            FieldInfo fi = typeof(CreditCard).GetField("_pinCode", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsTrue(setpinBool);
            Assert.That(actual, Is.EqualTo(code));
        }

        [Test]
        public void getPin_emptyValue_returns0(){
            var actual = cc.GetPinCode();
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void getPin_ValidValue_returnsPin(){
            var setPnBool= cc.SetPinCode(5678);
            var expected = cc.GetPinCode();

            FieldInfo fi = typeof(CreditCard).GetField("_pinCode", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsTrue(setPnBool);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void setWrgPinCodeAttemps_invalidValue_TooHigh_returnsFalse(){
            int attemps = 5;
            var setwrgAttmpsBool = cc.SetWrongPinCodeAttemps(attemps);

            FieldInfo fi = typeof(CreditCard).GetField("_pinCodeAttemps", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsFalse(setwrgAttmpsBool);
            Assert.That(actual, Is.EqualTo(0));

        }

        [Test]
        public void setWrgPinCodeAttemps_invalidValue_Negative_returnsFalse(){
            int attemps = -5;
            var setwrgAttmpsBool = cc.SetWrongPinCodeAttemps(attemps);

            FieldInfo fi = typeof(CreditCard).GetField("_pinCodeAttemps", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsFalse(setwrgAttmpsBool);
            Assert.That(actual, Is.EqualTo(0));

        }

        [Test]
        public void setWrgPinCodeAttemps_ValidValue_returnsTrue(){
            int attemps = 2;
            var setwrgAttmpsBool = cc.SetWrongPinCodeAttemps(attemps);

            FieldInfo fi = typeof(CreditCard).GetField("_pinCodeAttemps", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsTrue(setwrgAttmpsBool);
            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void getwrgPinAttemps_empty_returns0(){
            var actual = cc.GetWrongPinCodeAttemps();
            Assert.That(actual, Is.EqualTo(0));
        }
        [Test]
        public void getwrgPinAttemps_returnsAttemps(){
            var setwrgBool = cc.SetWrongPinCodeAttemps(2);
            var expected = cc.GetWrongPinCodeAttemps();
            
            FieldInfo fi = typeof(CreditCard).GetField("_pinCodeAttemps", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsTrue(setwrgBool);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void resetwrgPinCodeAttemps_setsValueTo0(){
            var setwrgBool = cc.SetWrongPinCodeAttemps(2);
            cc.ResetWrongPinCodeAttemps();

            FieldInfo fi = typeof(CreditCard).GetField("_pinCodeAttemps", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.IsTrue(setwrgBool);
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void setBlocked_UpdatesBlockedValue(){
            var expected = true;
            cc.SetBlocked(expected);
            FieldInfo fi = typeof(CreditCard).GetField("_blocked", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void isBlocked_empty_returnsFalse(){
            var actual = cc.IsBlocked(); // unfortunate that un-initiaized == false
            Assert.IsFalse(actual);
        }
        [Test]
        public void isBlocked_returnsBlockedValue(){
            cc.SetBlocked(true);
            var expected = cc.IsBlocked(); 

            FieldInfo fi = typeof(CreditCard).GetField("_blocked", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(cc);

            Assert.That(actual, Is.EqualTo(expected));
        }


    }
}