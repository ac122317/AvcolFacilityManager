AvcolFacilityManager Web Application

---Explanation of the Software--- 
This software is a digital booking system of facilities at Avondale College. The main pages on the application are the Home page, Facilities, Bookings and Reviews.
Users can book facilities at Avondale College on the bookings page by selecting a Facility, Date, Start Time and End Time.
By using searching and sorting, users can navigate to specific facilities in the facilities page. One can search by names of facilities to find what they are looking for (e.g. searching gym can produce results of gyms at Avondale College).
Only a user with the admin role will have permission to Create, Delete, or Edit records on the facilities page.
All other users are restricted to viewing the facilities, details about each record, and general features on the page (like searching, pagination and filtering). 
Regular users can also create their own reviews on facilities that they have booked, as well as have the ability to edit and delete their reviews and any bookings they have.

---Prerequisites---
.NET SDK (Version 6.0 or later) - https://dotnet.microsoft.com/en-us/download
Visual Studio (2022 is advised) - https://visualstudio.microsoft.com/

---Cloning and Opening solution---
After downloading Visual Studio 2022, click on "Clone a repository" and paste my repository link in the box provided. My link: https://github.com/ac122317/AvcolFacilityManager.git
Click clone and wait for it to load, you should be directed to the project.
Navigate to the solution explorer (may be pinned to the right of the screen you can just click it) by clicking on "View' from the navigation pane at the top and then solution explorer 
(or you can use the keyboard shortcut "Ctrl+Alt+L" on windows).
Then finally in the solution explorer, double click "AvcolFacilityManager.sln" to open the project solution.

---Package Manager Console and running the application---
From there, click on the "View" tab again and locate "Other windows", hover over it and locate "Package Manager Console", then click it.
A tab at the bottom of the screen should appear. In the Package Manager Console click beside "PM>" and type the command "Update-Database" and press enter.
After this the project may install some necessary NuGet Packages required to run the application.
After updating the database, you are now ready to run the application. On the top of the screen you shall she a filled green arrow with "https" next to it on the right. 
Click this to run the application. After this, register an account and enjoy!

