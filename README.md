# NIC Assessment 2023

Project Details:
You are required to implement a full stack application using .Net Framework, HTML, CSS, and 
JavaScript.<br>
Such app should retrieve and display individual’s information such as FIRST_NAME, NATIONALITY, 
…etc. using United Nations Security Council Consolidated List XML data source (Link below) 

## APP Pages:
Login Page: <br>
• A login page with a username and password fields to log in the users to the APP.<br>
Home Page: <br>
• The main screen where the user will be redirected to after a successful login displaying an 
option to retrieve the individual’s information using the above-mentioned data source (link 
below).<br>
• Data grid which displays the retrieved information to the current user with a view, edit and 
delete actions for the displayed records. <br>
Users Page: <br>
• Displays application users with their respective roles
## Database:
Preferred Database provider: <br>
• MSSQL using Entity Framework ORM
## General:
• Use the below URL to get a list of Individuals and Entities information from the United 
Nations Security Council main website:<br>
https://scsanctions.un.org/resources/xml/en/consolidated.xml<br>
P.S: Filter only the individual’s node, no need to fetch Entities list. <br>
P.S: INDIVIDUALS node contains many SUB-INDIVIDUAL nodes. Loop through them to fetch 
their information.<br>
• App should have a navigation bar to navigate between app pages.<br>
• Use the available fields elements in the individual’s node to create the database columns.<br>
• Responsive UI is preferred.<br>
• Clean code is important (SOLID Principles is preferred).<br>
## Bonus (any of these points would count as an extra point):
• Using React JS for frontend is a plus.<br>
• Using ASP.net Identity to manage users and roles is a plus.<br>
• Using Entity Framework Code first approach is a plus.<br>
