using UnityEngine;

namespace TicTacToe
{
	public class Menu : MonoBehaviour { 
		
		public int window; 
		public GUIStyle guiStyle;
		
		void Start () { 
			window = 1; 
		} 
	
		void OnGUI () { 
			GUI.BeginGroup (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200)); 
			if(window == 1) 
			{ 
				if(GUI.Button (new Rect (10,30,180,30), "Play"))
				{
					window = 2;   
				} 
				if(GUI.Button (new Rect (10,110,180,30), "Exit")) 
				{ 
					window = 3; 
				} 
			} 
			
			if(window == 2) 
			{ 
				GUI.Label(new Rect(50, 10, 180, 30), "Choose Player");   
				if(GUI.Button (new Rect (10,40,180,30), "Computer")) 
				{ 
					Control.SetGameMode("Computer");
					Application.LoadLevel("MainScene"); 
				} 
				if(GUI.Button (new Rect (10,80,180,30), "Other player")) 
				{ 
					Control.SetGameMode("Human");
					Application.LoadLevel("MainScene"); 
				} 
				if(GUI.Button (new Rect (10,160,180,30), "Back")) 
				{ 
					window = 1; 
				} 
			} 
	
			
			if(window == 3) 
			{ 
				GUI.Label(new Rect(50, 10, 180, 30), "Do you want to leave us?");   
				if(GUI.Button (new Rect (10,40,180,30), "Yes")) 
				{ 
					Application.Quit(); 
				} 
				if(GUI.Button (new Rect (10,80,180,30), "No")) 
				{ 
					window = 1; 
				} 
			} 
			GUI.EndGroup (); 
		} 
	}
}