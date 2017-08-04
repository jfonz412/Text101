using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	public bool lockpick = false;
	public Text text;
	private enum States {
							cell, mirror, sheets_0, lock_0, sheets_1, cell_mirror, lock_1, corridor_0, stairs_0,
							door, other_cell, corridor_1, office, closet_door, inside_closet, janitor, guard
						};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		//print (myState);
		
		if (myState == States.cell) 			{cell();} 
		else if(myState == States.sheets_0) 	{sheets_0();}
		else if(myState == States.mirror)   	{mirror();}	
		else if(myState == States.lock_0)   	{lock_0();}
		else if(myState == States.sheets_1) 	{sheets_1();}	
		else if(myState == States.cell_mirror)  {cell_mirror();}
		else if(myState == States.lock_1)       {lock_1();}
		else if(myState == States.corridor_0) 	{corridor_0();}	
		else if(myState == States.stairs_0) 	{stairs_0();}
		else if(myState == States.door)   		{door();}	
		else if(myState == States.other_cell)   {other_cell();}
		else if(myState == States.corridor_1) 	{corridor_1();}	
		else if(myState == States.office) 		{office();}	
		else if(myState == States.closet_door)  {closet_door();}	
		else if(myState == States.inside_closet){inside_closet();}
		else if(myState == States.janitor) 		{janitor();}	
		else if(myState == States.guard)  		{guard();}
	}
	#region state handlers
	void cell() {
		text.text = "Sunlight hits your face through the cold steel bars of your tiny cell window, as "
				+ "it always does at around 8am during summer months. If there's one positive thing about your "
				+ "sentance, it'd be your well adjusted sleep schedule. That's about it though, and frankly "
				+ "that's just not enough to keep you here any longer. Your preperations are complete, the "
				+ "day has come. It's time to make your escape. \n"
				+ "You remove a loose brick behind your mattress to reveal a small mirror. "
				+ "It's all you have besides the sheets on your bed. \n\n"
				+ "Press S to view your Sheets, L to view the Lock on the cell door, and M to view the "
				+ "Mirror.";
		if(Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		} else if(Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		} else if(Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		}
		
	}
	
	void sheets_0(){
		text.text = "Disgusting, you refuse to sleep with these filthy sheets any longer! \n\n"
					+ "Press R to Return";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void mirror() {
		text.text = "Courtesy of Big Paulie, this old mirror is the key to your freedom... \n\n"
					+ "Press R to Return, press T to Take the mirror ";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		} else if(Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}
	
	void lock_0() {
		text.text = "Old, but still functional. \n\n"
					+ "Press R to Return.";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void sheets_1() {
		text.text = "This is plan B if plan A doesn't work... \n\n"
					+"Press R to Return";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	
	void cell_mirror() {
		text.text = "You grab the mirror. \n\n"
					+ "Press S to view your Sheets, L to view the Lock on the cell door.";
				
		if(Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		} else if(Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
	}
	
	void lock_1() {
		text.text = "You use the mirror to peer down the corridor. There are no guards coming. "
			       + "With all the strength you have left you slam your body against the old rusy door. "
			       + "The old lock gives way, you find yourself on the floor of the corridor outside your cell. \n\n"
			       + "Press C to start walking down the corridor.";
		if(Input.GetKeyDown(KeyCode.C)) {
			myState = States.corridor_0;
		}
	}
	
	void corridor_0() {
		text.text = "You're in the corridor now. To your left is a stairway up, to your right is another cell, "
					+"straight ahead is a door to the second corridor. \n\n"
					+"Press S to go up the Stairs, press D to check out the door, "
					+"press C to go to the other Cell";
		if(Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_0;
		} else if(Input.GetKeyDown(KeyCode.C)) {
			myState = States.other_cell;
		} else if(Input.GetKeyDown(KeyCode.D)) {
			myState = States.door;
		}
	}
	
	void stairs_0(){
		if(lockpick == false)
		{
			text.text = "At the top of the stairs is the door to the warden's office. You hear muffled laughter coming "
						+"from the other side. The door is locked. \n\n"
						+"Press R to Return";
			if(Input.GetKeyDown(KeyCode.R)) {
				myState = States.corridor_0;
			}	
		} else {
			text.text = "At the top of the stairs is the door to the warden's office. You hear muffled laughter coming "
						+"from the other side. The door is locked. \n\n"
						+"Press R to Return, or P to pick the lock";
			if(Input.GetKeyDown(KeyCode.R)) {
				myState = States.corridor_0;
			} else if (Input.GetKeyDown(KeyCode.P)) {
				myState = States.office;
			}
		}			
	}
	
	void other_cell(){
		lockpick = true;
		text.text = "The cell is home to a very old man. He looks suprised to see you on the other side. "
					+"He immediatly hops to his feet and for a moment appears 20 years old again as he rummages "
					+"through his belongings. He pulls out a single lock pick, and with a smile and a nod gives it to you. \n\n"
					+"Press R to Return";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		}		
	}
	
	void door(){
		if(lockpick == false)
		{
			text.text = "The heavy metal door to the next corridor. It'll be impossible to break this one down "
						+"with brute force alone. \n\n"
						+"Press R to Return";
			if(Input.GetKeyDown(KeyCode.R)) {
				myState = States.corridor_0;
			}
		} else {
			text.text = "You use your lockpick to pick the lock of the heavy metal door. It swings open loudly. \n\n"
						+"Press C to continue on";
			if(Input.GetKeyDown(KeyCode.C)) {
				myState = States.corridor_1;
			}
		}	
	}
	
	void office() {
		text.text = "You begin to pick the lock. It's only about 30 seconds before the laughter inside stops and the door pops open "
					+"on it's own. The warden and several guards are inside. Not sure why you thought that this was a good idea... \n\n"
					+"Press P to Play again";
		if(Input.GetKeyDown(KeyCode.P)) {
			myState = States.cell;
		}
	}
	
	void corridor_1() {
		text.text = "To your dismay, the next hallway is a dead end. The only thing down this hallway is a closet. \n\n "
					+"Press C to check out the closet.";
		if(Input.GetKeyDown(KeyCode.C)) {
			myState = States.closet_door;
		}
	}
	
	void closet_door(){
		text.text = "The door is locked but flimsy. Either way you'll be able to get in \n\n "
					+"Press B to Break into the closet, press R to Return";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_1;
		} else if(Input.GetKeyDown(KeyCode.B)) {
			myState = States.inside_closet;
		}
	}
	
	void inside_closet(){
		text.text = "The closet smells terrible, but you quickly forget the smell when you spot not only the janitor's uniform, "
					+"but a guard's uniform as well. Which one will you pick to make your escape? \n\n"
					+"Press G to pick the Guard uniform, press J to wear the janitor's uniform.";
		if(Input.GetKeyDown(KeyCode.G)) {
			myState = States.guard;
		} else if(Input.GetKeyDown(KeyCode.J)) {
			myState = States.janitor;
		}
	}
	
	void guard(){
		text.text = "As you leave the closet wearing the guard's uniform you found, you spot two guards heading down the corridor. "
					+"There's no way you won't be spotted. One of the guards confronts you. \n\n"
					+"\"Hey, we didn't hire any new guards.... who the @!#$ are you???\" \n\n"
					+"You've been found out, game over... \n\n"
					+"Press P to Play again.";	
		if(Input.GetKeyDown(KeyCode.P)) {
			myState = States.cell;
		}									
	}
	
	void janitor(){
		text.text = "As you leave the closet wearing the guard's uniform you found, you spot two guards heading down the corridor. "
					+"There's no way you won't be spotted. One of the guards approaches you. \n\n"
					+"\"Hey, you must be the new janitor. Someone spilled something in the lobby, why don't you get on that?\" \n\n"
					+"The guards kindly lead you out of the secured area and into the lobby, making pleasant small talk along the way. \n\n"
					+"You are completly free to leave, after you mop up that mess of course. \n\n"
					+"Press P to Play again.";
		if(Input.GetKeyDown(KeyCode.P)) {
			myState = States.cell;
		}		
	}
	#endregion
}
