# Assignment7Test
This is the 7th. assignment for PBA Test spring2019soft

*All the setter and getters I would normally implement using the shorthand: public fieldName {get; set;}*

*I have taken some freedom with the returnvalues of some of the method, most of the setter-methods I have changed to return a bool, to indicate whether a value actually got set or not. I.E. Account.setId(-1) will return false, to indicate invalid method call*

*I've trid to divided tests into meanfull categories (categories instead of suites)*
To run one or more specific test-categories (filter also accepts regex)
```
dotnet test --filter TestCategory=<CATEGORY-NAME>
```
To run all the test disregarding category
```
dotnet test
```

*The pinCode in the CreditCard class should probably have been a string instead of int to include valid codes that start with 0 (0025)*

*Method: addWrongPinCodeAttemps is left out on purpose, instead I combine the SetWrongPinCodeAttemps and GetWrongPinCodeAttemps*

*SQLite DB inmemory ceases to exist as soon as the connection is closed, thats why all database management is moved directly into the tests*

