# Bank Transactions

Project was part of the course 5022.22 "Web Applications: ASP.NET Core with C#".

The objective of the course is to learn how to develop interactive and database-driven web-sites with ASP.NET Core / C#.


# Mac instructions (works for both intel and apple chips):
https://www.twilio.com/blog/using-sql-server-on-macos-with-docker?fbclid=IwAR38OG0CV4CX5z8NQ9vV6s4E09_ztohOS8Rz65NlmW2C3-5el190GFakbn0

1.  Download "Docker for Mac":
    https://docs.docker.com/desktop/install/mac-install/

2.  Open terminal and execute the following command:
    ~ docker run -d --name sql_server -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=someThingComplicated1234' -p 1433:1433 mcr.microsoft.com/mssql/server:2022-latest

3.  Download Azure Data Studio for graphical DB UI:
    https://learn.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver15

4. Open terminal and cd to root of the project:
    ~ cd [...]/BankTransactions
    example: cd /Users/aritj/Documents/School/ASP.Net_core/BankTransactions
    ~ dotnet ef migrations add initial
    ~ dotnet ef database update
