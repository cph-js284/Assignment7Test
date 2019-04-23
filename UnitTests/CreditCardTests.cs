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

    }
}