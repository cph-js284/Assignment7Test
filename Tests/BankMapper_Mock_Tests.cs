using System.Collections.Generic;
using System.Data.SQLite;
using NUnit.Framework;
using Moq;
using System.Threading.Tasks;

namespace Assignment7Test
{
    [Category("Mock-test")]
    [Category("BankMapper-test")]
    public class BankMapper_Mock_Tests
    {
        Mock<IBankMapper> mockBankMapper;
        IAccount newAcc;
        List<IAccount> listOfAcc;
        ICreditCard newCC;
        List<ICreditCard> listOfCCs;
        Bank myBank;
        
        [SetUp]
        public void setup(){
            mockBankMapper = new Mock<IBankMapper>();
            newAcc = new Account();
            newCC = new CreditCard();
            listOfAcc = new List<IAccount>();
            listOfCCs = new List<ICreditCard>();
            myBank = null;
        }

        [Test]
        public async Task BankMapper_getAccounts_returnsListOfAccount(){
            //adding 2 random account to list for mock object to return
            listOfAcc.Add(newAcc);
            listOfAcc.Add(newAcc);

            mockBankMapper.Setup(x => x.getAccounts()).Returns(Task.FromResult(listOfAcc));
            myBank = new Bank(mockBankMapper.Object);

            var Actual = await myBank.getAllAccounts();

            Assert.That(2, Is.EqualTo(Actual.Count));
        }

        [Test]
        public async Task BankMapper_CreateAccount_returnsAccount(){
            //create acc for mock to return
            int id = 56;
            newAcc.SetId(id);
            newAcc.SetBalance(5672);

            mockBankMapper.Setup(x => x.createAccount(newAcc)).Returns(Task.FromResult(newAcc));
            myBank = new Bank(mockBankMapper.Object);

            var Actual = await myBank.createAccount(newAcc);

            Assert.That(Actual, Is.EqualTo(newAcc));
            Assert.That(Actual.GetBalance(), Is.EqualTo(5672));

        }

        [Test]
        public async Task BankMapper_getCreditCards_returnsListOfCreditcards(){
            //adding 3 random creditcards to list for mock object to return
            listOfCCs.Add(newCC);
            listOfCCs.Add(newCC);
            listOfCCs.Add(newCC);

            mockBankMapper.Setup(x => x.getCreditCards()).Returns(Task.FromResult(listOfCCs));
            myBank = new Bank(mockBankMapper.Object);

            var Actual = await myBank.getAllCCs();

            Assert.That(3, Is.EqualTo(Actual.Count));
        }


    }
}