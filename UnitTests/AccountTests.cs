using System.Reflection;
using Assignment7Test;
using NUnit.Framework;

namespace Tests
{
    [Category("Unit-test")]
    [Category("Account-test")]
    public class AccountTests
    {
        IAccount account;
        [SetUp]
        public void Setup()
        {
            account = new Account();
        }

        [Test]
        public void setId_AccountGetsUpdated_returnsTrue()
        {
            int id = 1;
            var returnval=account.SetId(id);
            //peeking
            FieldInfo fi = typeof(Account).GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(account);
            Assert.That(actual, Is.EqualTo(1));
            Assert.IsTrue(returnval);

        }

        [Test]
        public void setId_NoValueSet_returnsFalse()
        {
            int id = -1;
            var returnval=account.SetId(id);
            //peeking
            FieldInfo fi = typeof(Account).GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(account);
            Assert.That(0, Is.EqualTo(0)); //ints aren't null, but 0
            Assert.IsFalse(returnval);

        }

        [Test]
        public void getId_EmptyId_ReturnsvalueofId(){
            var actual = account.GetId();

            FieldInfo fi = typeof(Account).GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            var expected = fi.GetValue(account);
            Assert.That(actual, Is.EqualTo(expected)); //ints aren't null, but 0

        }

        [Test]
        public void getId_PreSetId_ReturnsvalueofId(){
            int id = 42;
            
            account.SetId(id);
            var actual = account.GetId();

            FieldInfo fi = typeof(Account).GetField("_id", BindingFlags.Instance | BindingFlags.NonPublic);
            var expected = fi.GetValue(account);
            Assert.That(actual, Is.EqualTo(expected)); //ints aren't null, but 0
        }

        [Test]
        public void setBalance_balanceValueUpdated_ReturnTrue(){
            double balance=42.5;
            var returnVal=account.SetBalance(balance);

            FieldInfo fi = typeof(Account).GetField("_balance", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(account);

            Assert.That(balance, Is.EqualTo(actual));
            Assert.IsTrue(returnVal);
        }

        [Test]
        public void setBalance_invalidvalue_ReturnFalse(){
            double balance=-42.5;
            var returnVal=account.SetBalance(balance);

            FieldInfo fi = typeof(Account).GetField("_balance", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(account);

            Assert.That(0, Is.EqualTo(actual));
            Assert.IsFalse(returnVal);
        }

        [Test]
        public void getBalance_Emptybalance_returnsBalanceValue(){
            var expected = account.GetBalance();
            FieldInfo fi = typeof(Account).GetField("_balance", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(account);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void getBalance_NonEmptybalance_returnsBalanceValue(){
            var returnval = account.SetBalance(42);
            var expected = account.GetBalance();
            FieldInfo fi = typeof(Account).GetField("_balance", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(account);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.IsTrue(returnval);
        }

        [Test]
        public void deposit_invalidValue_returnsFalse(){
            var setBalanceBool = account.SetBalance(42.0); // starter balance
            var depositBool = account.Deposit(-41.9);
            FieldInfo fi = typeof(Account).GetField("_balance", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(account);

            Assert.IsTrue(setBalanceBool);
            Assert.IsFalse(depositBool);
            Assert.That(actual, Is.EqualTo(42.0));
        }

        public void deposit_validValue_returnsTrue(){
            var setBalanceBool = account.SetBalance(42.0); // starter balance
            var depositBool = account.Deposit(41.9);
            FieldInfo fi = typeof(Account).GetField("_balance", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(account);

            Assert.IsTrue(setBalanceBool);
            Assert.IsTrue(depositBool);
            Assert.That(actual, Is.EqualTo(83.9));
        }

        [Test]
        public void withDraw_invalidAmount_returnsFalse(){
            var setBalanceBool = account.SetBalance(42.0); // starter balance
            var withdrawBool = account.WithDraw(-41.9);
            FieldInfo fi = typeof(Account).GetField("_balance", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(account);

            Assert.IsTrue(setBalanceBool);
            Assert.IsFalse(withdrawBool);
            Assert.That(actual, Is.EqualTo(42.0));
        }

        [Test]
        public void withDraw_validAmount_returnsTrue(){
            var setBalanceBool = account.SetBalance(42.0); // starter balance
            var withdrawBool = account.WithDraw(22.0);
            FieldInfo fi = typeof(Account).GetField("_balance", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(account);

            Assert.IsTrue(setBalanceBool);
            Assert.IsTrue(withdrawBool);
            Assert.That(actual, Is.EqualTo(20.0));
        }

        [Test]
        public void withDraw_validAmount_higherThanBalance_returnsFalse(){
            var setBalanceBool = account.SetBalance(42.0); // starter balance
            var withdrawBool = account.WithDraw(42.1);
            FieldInfo fi = typeof(Account).GetField("_balance", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(account);

            Assert.IsTrue(setBalanceBool);
            Assert.IsFalse(withdrawBool);
            Assert.That(actual, Is.EqualTo(42.0));
        }
















    }
}