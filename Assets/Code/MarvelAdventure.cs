using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//General code flow: Intro, Intro VIP, VIP line, guard interactions, around the building, watching the people, waiting, costume stuff, premiere


public class MarvelAdventure : MonoBehaviour {
	
	bool hasGuardKeys = false; //Put this before UPDATE
	bool hasCostumeKnowledge = false;
	bool hasWarMachineCostume = false;
	bool hasScarletWitchCostume = false;
	bool hasTheFalconCostume = false;
	bool hasBatmanCostume = false;

	string currentRoom = "Intro"; //remembers our current location in the world
	// Use this for initialization
	
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//if I declare a variable inside Update(),
		//then I can ONLY use this variable inside Update() !!
		//also, a "buffer" is a staging area to prepare data
		string textBuffer = "You are currently: "  + currentRoom;

	//Intro code
		if (currentRoom == "Intro" ) {
			textBuffer += "\nYou are lined up for the red carpet premiere of Marvel's Avengers: Timespace Reckoning 2. Word on the street is" +
				"that it's going to be way better than the flop that was Timespace Reckoning 1. There's a bit of a problem, though. You're not " +
				"exactly supposed to be there... You weren't invited or anything. But you're trying to get in anyway, in the one line there, the VIP line.";
		//Text for inputs
			textBuffer += "\nPress [1] to begin.";
		//Code for inputs
			if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
				currentRoom = "On the VIP Line";
			}
		}

	//On the VIP line code
		else if ( currentRoom == "On the VIP Line" ) {
			textBuffer += "\nAt the front of the line, you approach the guard checking people in. He has an iPad in hand. You say your name. He does not " +
				"find you on the list. You plead for a moment before the guard squares up to you. 'No fans allowed', he states.";
			textBuffer += "\nNo way you're quiting now. It took you hours to get here, and you already made all your friends jeleous when you told " +
				"them you were going to the premiere.";
			textBuffer += "\nFind a way to enter the premiere.";
		//Text for inputs
			textBuffer += "\nPress [1] to talk with the guard";
			textBuffer += "\nPress [2] to look around the building";
			textBuffer += "\nPress [3] to observe the people getting in";
			textBuffer += "\nPress [4] to wait";
		//Code for inputs
			if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
				currentRoom = "Talking with the guard";
			} else if ( Input.GetKeyDown (KeyCode.Alpha2) ) {
				currentRoom = "Looking around the building";
			} else if ( Input.GetKeyDown (KeyCode.Alpha3) ) {
				currentRoom = "Observing the people";
			} else if ( Input.GetKeyDown (KeyCode.Alpha4) ) {
				currentRoom = "Waiting";
			}

	//By the VIP line code
		} else if ( currentRoom == "By the VIP line" ) {
			textBuffer += "\nFind a way to enter the premiere.";
		//Text for inputs
			textBuffer += "\nPress [1] to talk with the guard";
			textBuffer += "\nPress [2] to look around the building";
			textBuffer += "\nPress [3] to observe the people getting in";
			textBuffer += "\nPress [4] to wait";
			if ( hasCostumeKnowledge == true ) {
				textBuffer += "\nPress [5] to go to the costume shop";
			}
			if ( hasScarletWitchCostume == true ) {
				textBuffer += "\nPress [6] to get in line wearing Scarlet Witch costume";
			}
			if ( hasWarMachineCostume == true ) {
				textBuffer += "\nPress [6] to get in line wearing War Machine costume";
			}
			if ( hasTheFalconCostume == true ) {
				textBuffer += "\nPress [6] to get in line wearing The Falcon costume";
			}
			if ( hasBatmanCostume == true ) {
				textBuffer += "\nPress [7] to get in line wearing Batman costume";
			}
		//Code for inputs
			if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
				currentRoom = "Talking with the guard";
			} else if ( Input.GetKeyDown (KeyCode.Alpha2) ) {
				currentRoom = "Looking around the building";
			} else if ( Input.GetKeyDown (KeyCode.Alpha3) ) {
				currentRoom = "Observing the people";
			} else if ( Input.GetKeyDown (KeyCode.Alpha4) ) {
				currentRoom = "Waiting";
			} else if ( Input.GetKeyDown (KeyCode.Alpha5) && hasCostumeKnowledge == true) {
				currentRoom = "In the costume shop";
			} else if ( Input.GetKeyDown (KeyCode.Alpha6) && ( hasScarletWitchCostume == true ||
			           hasWarMachineCostume == true || hasTheFalconCostume == true) ) {
				currentRoom = "In line wearing Marvel costume";
			} else if ( Input.GetKeyDown (KeyCode.Alpha7) && hasBatmanCostume == true ) {
				currentRoom = "In line wearing DC costume";
			}
		
	//Talking with the guard code
		} else if ( currentRoom == "Talking with the guard" ) {
			textBuffer += "\nThe guard has nothing more to say to you. He mostly just looks agitated that you're still here.";
		//Text for inputs
			textBuffer += "\nPress [1] to stop talking with the guard";
			textBuffer += "\nPress [2] to investigate guard";
		//Code for inputs
			if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
				currentRoom = "By the VIP line";
			} else if ( Input.GetKeyDown (KeyCode.Alpha2) ) {
				currentRoom = "Investigating guard";
			}

	//Investigating guard code
		} else if ( currentRoom == "Investigating guard" ) {
			textBuffer += "\nYou notice a set of keys on the guard's belt. 'Move it, I said no fans.' the guard says.";
		//Text for inputs
			textBuffer += "\nPress [1] to grab the keys";
			textBuffer += "\nPress [2] to back off";
		//Code for inputs
			if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
				currentRoom = "Grabbing the keys";
			} else if ( Input.GetKeyDown (KeyCode.Alpha2) ) {
				currentRoom = "By the VIP line";
			}

	//Grabbing the keys code
		} else if ( currentRoom == "Grabbing the keys" ) {
		    textBuffer += "\nYou pretend to fall into the guard. In the ensuing pushy-shovesy between the two of you, you snatch the keys. " +
		        "The guard doesn't seem to notice.";
			textBuffer += "\nYou've obtained the guard's keys!";
					hasGuardKeys = true;
		//Text for inputs
		    textBuffer += "\nPress [1] to walk away from the guard.";
		//Code for inputs
		    if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
				currentRoom = "By the VIP line";
		}

	//Looking around the building code
		} else if ( currentRoom == "Looking around the building" ) {
			textBuffer += "\nYou patrol the perimeter of the building. In an alley on the side of the building you notice an unmarked door " +
				"with no knob, simply a slot for a key.";
		//Text for inputs
			if ( hasGuardKeys == false ) {
				textBuffer += "\nPress [1] to go back to the VIP line";
			} else {
				textBuffer += "\nPress [2] to try the guard keys.";
			}
		//Code for inputs
			if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
				currentRoom = "By the VIP line";
			} else if ( Input.GetKeyDown (KeyCode.Alpha2) && hasGuardKeys == true) {
				currentRoom = "Inside the premiere";
			}

	//Observing the people code
		} else if ( currentRoom == "Observing the people" ) {
			textBuffer += "\nYou stand a ways away from the line and watch invited guests file in. Most wear formal attire: suits, dresses, " +
				"tuxedos, avant-garde designer outfits. However, one person approaches the guard wearing a full replica Quicksilver costume. " +
					"The guard waves them through, without checking the list. Perhaps you could get in the same way?";
			hasCostumeKnowledge = true;
		//Text for inputs
			textBuffer += "\nPress [1] to go back to the VIP line";
		//Code for inputs
			if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
				currentRoom = "By the VIP line";
			}

	//Waiting code
		} else if ( currentRoom == "Waiting" ) {
			textBuffer += "\nYou wait by the premiere. Nothing changes. You should probably get moving...";
		//Text for inputs
			textBuffer += "\nPress [1] to go back to the VIP line";
		//Code for inputs
			if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
					currentRoom = "By the VIP line";
				}

	//Costume shop
		} else if ( currentRoom == "In the costume shop" ) {
			textBuffer += "\nYou walk to a nearby costume shop. They have plenty of superhero costumes for sale. Hopefully one of them " +
				"will let you in the premiere, like with that Quicksilver fellow. Better hurry back after buying one, though. The premiere is " +
				"about to start!";
		//Text for inputs
			textBuffer += "\nPress [1] to buy Scarlet Witch costume";
			textBuffer += "\nPress [2] to buy Batman costume";
			textBuffer += "\nPress [3] to buy War Machine costume";
			textBuffer += "\nPress [4] to buy The Falcon costume";
		//Code for inputs
			if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
				currentRoom = "By the VIP line";
				hasScarletWitchCostume = true;
				hasCostumeKnowledge = false;
			} else if ( Input.GetKeyDown (KeyCode.Alpha2) ) {
				currentRoom = "By the VIP line";
				hasBatmanCostume = true;
				hasCostumeKnowledge = false;
			} else if ( Input.GetKeyDown (KeyCode.Alpha3) ) {
				currentRoom = "By the VIP line";
				hasWarMachineCostume = true;
				hasCostumeKnowledge = false;
			} else if ( Input.GetKeyDown (KeyCode.Alpha4) ) {
				currentRoom = "By the VIP line";
				hasTheFalconCostume = true;
				hasCostumeKnowledge = false;
			}

	//In line wearing Marvel costume
		} else if ( currentRoom == "In line wearing Marvel costume" ) {
			textBuffer += "\nYou approach the guard in your costume, hoping for the best. 'Nice costume!' he says. The guard waves you through.";
		//Text for inputs
			textBuffer += "\nPress [1] to enter the premiere";
		//Code for inputs
			if ( Input.GetKeyDown (KeyCode.Alpha1) ) {
				currentRoom = "Inside the premiere";
			}
	//In line wearing DC costume
		} else if ( currentRoom == "In line wearing DC costume" ) {
			textBuffer += "\nYou approach the guard in your costume, hoping for the best. 'Batman isn't in the avengers, kid. That's DC comics. Get lost.";
			textBuffer += "\nGAME OVER. Restart/Refresh to try again.";
			
	//Inside the premiere
		} else if ( currentRoom == "Inside the premiere" ) {
			textBuffer += "\nYou made it inside the premiere. Go grab some free popcorn and enjoy yourself! You earned it!";
			textBuffer += "\nGame Complete.";
	

		}
		GetComponent<Text>().text = textBuffer;
	}
}


