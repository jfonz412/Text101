using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	public Text text;
	private enum States {cell, mirror, sheets_0, lock_0, sheets_1, cell_mirror, lock_1, freedom};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if (myState == States.cell) {
			state_cell();
		} else if(myState == States.sheets_0) {
			state_sheets_0();
		} else if(myState == States.mirror) {
			state_mirror();
		} else if(myState == States.lock_0) {
			state_lock_0();
		} else if(myState == States.sheets_1) {
			state_sheets_1();
		} else if(myState == States.cell_mirror) {
			state_cell_mirror();
		} else if(myState == States.lock_1) {
			state_lock_1();
		} else if(myState == States.freedom) {
			state_freedom();
		}
	}
	
	void state_cell() {
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
	
	void state_sheets_0(){
		text.text = "Disgusting, you refuse to sleep with these filthy sheets any longer! \n\n"
					+ "Press R to Return";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
	
	void state_mirror() {
		text.text = "Courtesy of Big Paulie, this old mirror is the key to your freedom... \n\n"
					+ "Press R to Return, press T to Take the mirror ";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		} else if(Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}
	
	void state_lock_0() {
		text.text = "Old, but still functional. \n\n"
					+ "Press R to Return.";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_sheets_1() {
		text.text = "This is plan B if plan A doesn't work... \n\n"
					+"Press R to Return";
		if(Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	
	void state_cell_mirror() {
		text.text = "You grab the mirror. \n\n"
				+ "You have an hour before the sunlight moves past your window...now is your chance! "
				+ "Press S to view your Sheets, L to view the Lock on the cell door.";
				
		if(Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		} else if(Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
	}
	
	void state_lock_1() {
		text.text = "Using the sunlight from the window, you direct the light towards the old and rusted lock... "
			       + "...nothing really happens...I don't know what you were thinking.... "
			       + "Press F to go back to sleep you dummy.";
		if(Input.GetKeyDown(KeyCode.F)) {
			myState = States.freedom;
		}
	}
	
	void state_freedom() {
		text.text = "Game over man...";
	}
}
