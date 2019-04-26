using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Assignment7Test
{
    [Category("Integrateion-test-Ondisk")]
    [Category("BankMapper-test")]
    public class BankMapper_ondisk_Tests
    {
        sql builder;
        BankMapper myBankTest;
        Account newAcc;
        CreditCard newCC;

        [SetUp]
        public void setup(){
            //create database and state here
            builder = new sql("Data Source=testDb_version2.db");

            myBankTest = new BankMapper();
            myBankTest.setDataSource("Data Source=testDb_version2.db");

            newAcc = new Account();
            newCC = new CreditCard();
        }
        [TearDown]
        public void TearDown(){
            //no need for teardown, dbfile gets overwritten on setup(before-each)
        }

        [Test]
        public void BankMapperDatasource_returnsConnectionsString(){
            string connectionString = "Data Source=testDb_version2.db";
            myBankTest.setDataSource(connectionString);
            FieldInfo fi = typeof(BankMapper).GetField("_connectionString", BindingFlags.Instance | BindingFlags.NonPublic);
            var actual = fi.GetValue(myBankTest);

            Assert.That(actual, Is.EqualTo(connectionString));
        }

        [Test]
        public async Task BankMapperCreateAccount_returnsStateAndAdditinalAccount(){

            var balance = 2300;
            newAcc.SetBalance(balance);
            await myBankTest.createAccount(newAcc);
            var ActualAccList= await myBankTest.getAccounts();

            Assert.That(ActualAccList, Has.Exactly(6).Items);
            Assert.That(ActualAccList[5].GetBalance(), Is.EqualTo(balance));
        }

        [Test]
        public async Task BankMapperCreateCC_returnsStateAndAdditinalCC(){

            //create Account for CC
            var balance = 2300;
            newAcc.SetBalance(balance);
            await myBankTest.createAccount(newAcc);

            //create CC
            newCC.SetCreated(DateTime.Now);
            newCC.SetLastUsed(DateTime.Now);
            newCC.SetPinCode(4321);
            newCC.SetAccount(newAcc);
            
            await myBankTest.createCreditCard(newCC);
            
            var ActualCCList= await myBankTest.getCreditCards();

            Assert.That(ActualCCList, Has.Exactly(4).Items);
            Assert.That(ActualCCList[3].GetPinCode(), Is.EqualTo(4321));
        }

    }
}