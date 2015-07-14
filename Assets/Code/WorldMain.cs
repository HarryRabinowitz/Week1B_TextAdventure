using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//Multiple ways to get in: Fight the bouncer, steal the key to the back entrance in the alley
//Do some street performing, get money. Go back to bouncer, realize it's not enough, but realize it IS enough to buy a costume.
//Go to costume store, but a Marvel (not DC) costume, go back, get in free.


public class WorldMain : MonoBehaviour {

	bool hasStudentID = false; //Put this before UPDATE
	string currentRoom = "Intro"; //remembers our current location in the world
	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	//if I declare a variable inside Update(),
		//then I can ONLY use this variable inside Update() !!
		//also, a "buffer" is a staging area to prepare data
		string textBuffer = "You are currently in: "  + currentRoom;

		if (currentRoom == "Intro" ) {
			textBuffer += "\nYou are lined up for the red carpet premiere of Marvel's newest super hero movie, Avengers 7. The word is that it's going" +
				"to be way better than Avengers 6.";
			textBuffer += "\nPress [S] to begin.";

			if ( Input.GetKeyDown (KeyCode.S) ) {
				currentRoom = "Lobby";
			}
		}
	//Lobby code
		 else if ( currentRoom == "Lobby" ) {
				//all your LOBBY code will go here later!
				//typing "/n" in a string means "line break"
			textBuffer += "\nYou see the security guard.";
				//the line of code below is the SAME as the line of code above
			//textBuffer = textBuffer + "/nYou see the Parsons security guard.";

			textBuffer += "\npress [W] to go to elevators";
			textBuffer += "\npress [S] to go outside";
			textBuffer += "\npress [E] to look around";
	//Key codes for Lobby inputs
			if ( Input.GetKeyDown (KeyCode.W) ) { //if player pushes W...
				currentRoom = "Elevators";
			} else if ( Input.GetKeyDown (KeyCode.S) ) {
				currentRoom = "Outside";
			} else if ( Input.GetKeyDown (KeyCode.E) ) {
				currentRoom = "Investigating Lobby";
			}


	//Investigating Lobby code
		} else if ( currentRoom == "Investigating Lobby" ) {
				textBuffer += "\nYou look around the lobby and find your ID card on the floor. You should really keep better track of it.";
					hasStudentID = true;
			textBuffer += "\npress [W] to go to Lobby.";

			if ( Input.GetKeyDown (KeyCode.W) ) {
				currentRoom = "Lobby";
			}
		
		

	//Elevator code
		} else if ( currentRoom == "Elevators" ) {
			textBuffer += "\nYou enter the elevator. Nothing happens";
			if ( hasStudentID == false ) {
				textBuffer += "\nYou cannot access any floors without an ID card.";
				textBuffer += "\npress [A] to go to Lobby";
			} else {
				textBuffer += "\nYou swipe your ID card. The floor buttons on the elevator panel light up.";
				textBuffer += "\nPress [E] to go to the 8th floor";
			}
	//Key codes for Elevator inputs
			if ( Input.GetKeyDown (KeyCode.A) ) { //if player pushes W...
				currentRoom = "Lobby";
			}
			if ( Input.GetKeyDown (KeyCode.E) ) {
				currentRoom = "8th Floor";
			}

	//Outside code
		} else if ( currentRoom == "Outside" ) {
			textBuffer += "\nYou go outside. It is a nice day. A dog approaches you";
				//all your OUTSIDE code will go here later!
		

	//8th Floor code
		} else if ( currentRoom == "8th Floor" ) {
			textBuffer += "\nYou are on the 8th floor. Congratulations.";

		}








		GetComponent<Text>().text = textBuffer;
	}
}
