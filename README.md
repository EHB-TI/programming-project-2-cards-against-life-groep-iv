# programming-project-2-cards-against-life-groep-iv

This is a cards game made with Unity. We will use a php server for authentication and a node.js server to host our own API communication with a running mysql database.

We have split our logic and branches in 3. The main is for the game, nodeJSAPI is for our API and php is for our php server.

## Collaborate
We had some initial merge problems that we could not work out so we changed over to the build Unity versioning control feature 'collaborate'.
This worked great for us. It synced everyone up with the same project but this also means that the code each indivdual has pushed to git (located under Assest/scripts) do not completely translate in what each person has made. The code each one wrote will be more clear in our demo vide.


## Testing the Game
To play our game you first have to setup the api's.

Php: Have a local appache server running of the 'php branch' folder. preferably using xampp.
Node.js: Have the node.js start running "npm start" located in the 'node.js branch'.

Now you will be able to test our game using the .exe which is located under the 'game' branch -> thestProject.exe

We have created a test user with the username: cardwizard and password: 12345678.

To test the card portion of the our game, go to: builds/TestProject.exe and execute it four times. One should be the host and the other 3 should join the host by clicking "client". 


## Credits
Ryan, Anton, Sara and Alvaro have worked on this project.

Ryan was responsible for the php server and the API.

Anton, Sara, Alvar worked on the game itself.


