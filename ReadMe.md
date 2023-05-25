## The purpose of this app is to test your skills in .net and angular.  Below you will find a set of tasks to be performed.  You may complete as many or as few as you woudl like.

### Before you begin please fork this repository and work in your own instance. (https://docs.github.com/en/search?query=forking)

## Tasks
1. Bug Fix:  We have a memory leak somewhere in our application.  The description from the user is as follows:
	> For my job I have to navigate between people and places.  As the day gets later my browser seems to slow down a lot.
	
	The performance team ran some tests and found that memory is going up from 5 MB on load to 2 GB after only a couple of hours.
2. Bug Fix:  Navigation issue.  The description from the user is as follows:
	> When I click on the Things nav item nothing happens

3. Enhancement:  The users would like to see the search results cached for at least 2 minutes.  Introduce code that could accomplish this.

4. Refactor:  Remove the X-Powered-By response header.
 application.js file can be changed

5. Refactor:  The quality of this application can be improved.  In your role as a great developer, please refactor/improve this application as you seem fit.  I know we can create a product that is easier to read by other developers, improve the quality and provide more functionality for our clients.

### For the following you may write code to demonstrate or just describe how it could be done

1. Is DbContext used in a thread safe manner?
  Yes DbContext is used in thread safe manner . As it uses async and await.

2. What would be the server side steps to add an ability to input a new Person record?
   1.Create a [HttpPost] async method in PeopleController with parameter [FormBody] data
   2.Do the check if the dbcontext.people has a person exist
   3.If the person dosn't exist add to the dbcontext.people collection
   4.save the dbcontext changes.
   5.return the new updated collection

3. What are the security concerns with data UPSERT?  How would you resolve those concerns?
  -deadlock because of incompatible locks-
   -raise key violation errors that shouldn't have happened
   -insert duplicate key values if that column isn't properly constrained.
   -That last one is the worst, IMHO, because it's the one that potentially corrupts data

 Solution:use transaction, and protect table access with appropriate locking
