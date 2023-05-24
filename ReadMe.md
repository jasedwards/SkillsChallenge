## The purpose of this app is to test your skills in .net and angular.  Below you will find a set of tasks to be performed.  You may complete as many or as few as you woudl like.

### Before you begin please fork this repository and work in your own instance. (https://docs.github.com/en/search?query=forking)

## Tasks
1. Bug Fix:  We have a memory leak somewhere in our application.  The description from the user is as follows:
	> For my job I have to navigate between people and places.  As the day gets later my browser seems to slow down a lot.
	
	The performance team ran some tests and found that memory is going up from 5 MB on load to 2 GB after only a couple of hours.
2. Bug Fix:  Navigation issue.  The description from the user is as follows:
	> When I click on the Things nav item nothing happens

3. Enhancement:  The users would like to see the search results cached for at least 2 minutes.  Introduce code that could accomplish this.

4. Refactor:  Remove the X-Powered-By response header

5. Refactor:  The quality of this application can be improved.  In your role as a great developer, please refactor/improve this application as you seem fit.  I know we can create a product that is easier to read by other developers, improve the quality and provide more functionality for our clients.

### For the following you may write code to demonstrate or just describe how it could be done

1. Is DbContext used in a thread safe manner?

2. What would be the server side steps to add an ability to input a new Person record?

3. What are the security concerns with data UPSERT?  How would you resolve those concerns?


1. Is DbContext used in a thread safe manner?

   No, DbContext is not thread-safe.  We can use a separate DbContext instance for each thread.


2. What would be the server side steps to add an ability to input a new Person record?
       1.  Verify the new person details using server side validation 
           ex: name : validate for special chars, total chars length 
           ex: mobile no : check mobile no format
       2. if valid, then we have to insert record to the db, using store procedure
       3. connect application to db using connection string
       4. we will get this connection string in our codebehind file.
       5. And mention store procedure name and send all the values(parameters) to the store procedure.
       

       
3. What are the security concerns with data UPSERT? How would you resolve those concerns?
 
upsert will update the existing recrods and insert the non existing ones
     1. SQL Injection
     2. Data Loss in the Cloud
     3. Insider Threats
     4. Accidental Exposure

 overcome this by 
    1. Data Discovery and Classification
    2. Data Masking
    3. Identity Access Management
    4. Data Encryption
    5. Data Loss Prevention (DLP)
