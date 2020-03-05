Book Store application 

Project contains two parts:
1) ApiBookStore - web api works with database (code first), get all information about books from database. 
2) BookStore - website, gets info from ApiBookStore, uses HTTPClient
To run the project:
1) Set up ApiBookStore: 
 -in web.config change connection string for database (code first);
 -configure ApiBookStore in IIS or use IISExpress;
2) Set up BookStore:
 - in HomeController.cs change BaseUrl with your url for ApiBookStore
