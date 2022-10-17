# Bank Transactions

Project was part of the course 5022.22 "Web Applications: ASP.NET Core with C#".

The objective of the course is to learn how to develop interactive and database-driven web-sites with ASP.NET Core / C#.

Please choose correct DB string for your operating system in "Program.cs".


# Mac instructions (works for both intel and apple chips):

* https://www.twilio.com/blog/using-sql-server-on-macos-with-docker?fbclid=IwAR38OG0CV4CX5z8NQ9vV6s4E09_ztohOS8Rz65NlmW2C3-5el190GFakbn0

1.  Download "Docker for Mac":
    
    * https://docs.docker.com/desktop/install/mac-install/

2.  Open terminal and execute the following command:
    ~ docker run -d --name sql_server -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=someThingComplicated1234' -p 1433:1433 mcr.microsoft.com/mssql/server:2022-latest

3. Clone repository and open using your IDE of choice:
    
    ~ git clone https://github.com/Aritj/BankTransactions.git

4. Open terminal and cd to root of the project:
    
    ~ cd [...]/BankTransactions
    
    example: cd /Users/aritj/Documents/School/ASP.Net_core/BankTransactions
    
    ~ dotnet ef migrations add initial
    
    ~ dotnet ef database update

5.  Run the application!

# Optional graphical SQL server administration

Download Azure Data Studio for graphical DB UI:

    * https://learn.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver15
    
        * Server: localhost
        
        * Username: sa
        
        * Password: someThingComplicated1234

# Nice to know! Mac uses port 5000/tcp for AirPort/upnp:

(base) aritj@Aris-MacBook-Pro ~ % nmap -p 5000 localhost                    

PORT     STATE SERVICE
5000/tcp open  upnp

Nmap done: 1 IP address (1 host up) scanned in 0.05 seconds
