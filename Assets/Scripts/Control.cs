using UnityEngine;
using System;

namespace TicTacToe{
 public class Control : MonoBehaviour {

	private static int gameMode = -1;

        
    private void GameWithHuman()
	{
			if (gameObject.tag == "Button") 
			{ 
				int player = GameLogic.GetPlayer(); //get our player

				GameObject[] figure = new GameObject[2]; //array of game objects to load figures
				
				if (player == 1) //if x
				{
					figure[0] = (GameObject)Instantiate(Resources.Load("Prefabs/Cube1", typeof(GameObject))); //loading cross
					figure[1] = (GameObject)Instantiate(Resources.Load("Prefabs/Cube2", typeof(GameObject)));
					figure[0].transform.position = figure[1].transform.position = gameObject.transform.position; //and place it on field
				}
				else
				{
					figure[0] = (GameObject)Instantiate(Resources.Load("Prefabs/Zero", typeof(GameObject))); //loading circle
                    figure[0].transform.position = gameObject.transform.position;
                }
                
                switch (gameObject.name) //placing player move on field
				{
					case "1": GameLogic.SetPoint(0,0); break; 
					case "2": GameLogic.SetPoint(0,1); break;
					case "3": GameLogic.SetPoint(0,2); break;
					case "4": GameLogic.SetPoint(1,0); break;
					case "5": GameLogic.SetPoint(1,1); break;
					case "6": GameLogic.SetPoint(1,2); break;
					case "7": GameLogic.SetPoint(2,0); break;
					case "8": GameLogic.SetPoint(2,1); break;
					case "9": GameLogic.SetPoint(2,2); break;
				}

				GameLogic.Show();
				
				DestroyObject(gameObject); //destroy button
				if (GameLogic.FindLine() == 0) //if no winner
					GameLogic.ChangePlayer(); //continue game and changing player
				else
				{
					Application.LoadLevel("winner"); //else - show winner
                }
            }
	}



	public static void SetGameMode(string mode)
	{
			if (mode == "Human") gameMode = 1;
			else gameMode = 0;
    }


	void OnMouseDown()
	{
			GameWithHuman();
			if (gameMode == 0)//game with computer
			{
				int player = GameLogic.GetPlayer(); //get our player
				string name = AI.FindMove().ToString();

				if (GameObject.Find(name) != null)
				{
					GameObject[] figure = new GameObject[2]; //array of game objects to load figures
					if (player == 1) //if x
					{
						figure[0] = (GameObject)Instantiate(Resources.Load("Prefabs/Cube1", typeof(GameObject))); //loading cross
						figure[1] = (GameObject)Instantiate(Resources.Load("Prefabs/Cube2", typeof(GameObject)));
						figure[0].transform.position = figure[1].transform.position = GameObject.Find(name).transform.position; //and place it on field
					}
					else
					{
						figure[0] = (GameObject)Instantiate(Resources.Load("Prefabs/Zero", typeof(GameObject))); //loading circle
						figure[0].transform.position = GameObject.Find(name).transform.position;
               	 }
               	 
                	switch (name) //placing player move on field
					{
						case "1": GameLogic.SetPoint(0,0); break; 
						case "2": GameLogic.SetPoint(0,1); break;
						case "3": GameLogic.SetPoint(0,2); break;
						case "4": GameLogic.SetPoint(1,0); break;
						case "5": GameLogic.SetPoint(1,1); break;
						case "6": GameLogic.SetPoint(1,2); break;
						case "7": GameLogic.SetPoint(2,0); break;
						case "8": GameLogic.SetPoint(2,1); break;
						case "9": GameLogic.SetPoint(2,2); break;
					}
						
					Debug.Log(name);
					Destroy(GameObject.Find(name));
					if (GameLogic.FindLine() == 0) //if no winner
                   	 GameLogic.ChangePlayer(); //continue game and changing player
                	else
					{
						Application.LoadLevel("winner"); //else - show winner
					}
            	}
				else
				{	
					name = (int.Parse(name) - (DateTime.Now.Millisecond % 10)).ToString();
					if (int.Parse(name) < 1)
						name = (int.Parse(name) + (DateTime.Now.Millisecond % 10)).ToString();
					else if (int.Parse(name) > 9)
						name = (int.Parse(name) - (DateTime.Now.Millisecond % 10)).ToString();
				}
        	}
    }
 }
}
