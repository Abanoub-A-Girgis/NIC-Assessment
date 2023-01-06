# NIC Assessment 2023

Project Details:
You are required to implement a full stack application using .Net Framework, HTML, CSS, and 
JavaScript.
Such app should retrieve and display individual’s information such as FIRST_NAME, NATIONALITY, 
…etc. using United Nations Security Council Consolidated List XML data source (Link below) 

## APP Pages:
Login Page: 
• A login page with a username and password fields to log in the users to the APP.
Home Page: 
• The main screen where the user will be redirected to after a successful login displaying an 
option to retrieve the individual’s information using the above-mentioned data source (link 
below).
• Data grid which displays the retrieved information to the current user with a view, edit and 
delete actions for the displayed records. 
Users Page: 
• Displays application users with their respective roles
## Database:
Preferred Database provider: 
• MSSQL using Entity Framework ORM
## General:
• Use the below URL to get a list of Individuals and Entities information from the United 
Nations Security Council main website:
https://scsanctions.un.org/resources/xml/en/consolidated.xml
P.S: Filter only the individual’s node, no need to fetch Entities list. 
P.S: INDIVIDUALS node contains many SUB-INDIVIDUAL nodes. Loop through them to fetch 
their information.
• App should have a navigation bar to navigate between app pages.
• Use the available fields elements in the individual’s node to create the database columns.
• Responsive UI is preferred.
• Clean code is important (SOLID Principles is preferred).
## Bonus (any of these points would count as an extra point):
• Using React JS for frontend is a plus.
• Using ASP.net Identity to manage users and roles is a plus.
• Using Entity Framework Code first approach is a plus.
