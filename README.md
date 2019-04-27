# Assignment7Test
This is the [7th. assignment](https://github.com/datsoftlyngby/soft2019spring-test/blob/master/Assignments/07%20Integration%20Testing%20Assignment.pdf) for PBA Test soft2019spring. 

# What it is

This is a C# project containing mock-/ unit-/ and integrations-tests of the 3 interfaces(classes) mentioned in the assignment text.
The project includes a dockerfile so it can be build and run entirely containerized.<br>
The project uses MOQ (mocking-object-framework) and Nunit (unit-test-framework)

# Make it go

1) clone the repo
2) build the container
```
sudo docker build -t somename .
```
3) run the container
```
sudo docker run --rm -it somename
```
Running the container also serves as answer to Ex3. (making a main and trying out a few of the methods in the BankMapper class)

# Testing

*I've tried to divided tests into meanfull categories (categories instead of suites)*
The easiest way to run these test is from inside the container itself (imo)
1) run the container again this time in detached mode
```
sudo docker run --rm -it -d --name mytestcon somename
```
2) run a shell inside the container
```
sudo docker exec -it mytestcon bash
```
*Each testclass inside the [test-folder](https://github.com/cph-js284/Assignment7Test/tree/master/Tests) has 1 or more category-attributes associated with. [Example](https://github.com/cph-js284/Assignment7Test/blob/master/Tests/BankMapper_Mock_Tests.cs) notice the [Category("blahblah")] attribute on the test class. This is to help filter which test to run*<br>
<br>
To run one or more specific test-categories (filter also accepts regex)
```
dotnet test --filter TestCategory=<CATEGORY-NAME>
```
To run all the test disregarding category
```
dotnet test
```

# Comments

*I have taken some freedom with the returnvalues of some of the method, most of the setter-methods I have changed to return a bool, to indicate whether a value actually got set or not. I.E. Account.setId(-1) will return false, to indicate invalid method call*<br>
<br>
*The pinCode in the CreditCard class should probably have been a string instead of int to include valid codes that start with 0 (0025)*<br>
<br>
*Method: addWrongPinCodeAttemps is left out on purpose, instead I combine the SetWrongPinCodeAttemps and GetWrongPinCodeAttemps*
<br><br>
*SQLite DB inmemory ceases to exist as soon as the connection is closed, thats why all database management is moved directly into the tests*<br>
<br>
*For obvious reason this project does not make use of DBunit, there is a NDBunit(.Net version in alpha since 2014). Doing research on alternatives it seemed like most just developed their own code to reset DB-state. Which is what I ended up doing.*<br>

