using UnityEngine;

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
				
				Destroy(gameObject); //destroy button
				if (GameLogic.FindLine() == 0) //if no winner
					GameLogic.ChangePlayer(); //continue game and changing player
				else Application.LoadLevel("winner"); //else - show winner
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
	}
	
	void OnDestroy()
	{
			if (gameMode == 0)//game with computer
			{
				int player = GameLogic.GetPlayer(); //get our player
				GameObject gameObj = null;
				string name = "";

				while (gameObj == null)
				{
					name = AI.FindMove().ToString();
					gameObj = GameObject.Find(name);
				}

				GameObject[] figure = new GameObject[2]; //array of game objects to load figures

				if (player == 1) //if x
				{
					figure[0] = (GameObject)Instantiate(Resources.Load("Prefabs/Cube1", typeof(GameObject))); //loading cross
					figure[1] = (GameObject)Instantiate(Resources.Load("Prefabs/Cube2", typeof(GameObject)));
					figure[0].transform.position = figure[1].transform.position = gameObj.transform.position; //and place it on field
				}
				else
				{
					figure[0] = (GameObject)Instantiate(Resources.Load("Prefabs/Zero", typeof(GameObject))); //loading circle
                    figure[0].transform.position = gameObj.transform.position;
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
				if (GameLogic.FindLine() == 0) //if no winner
                    GameLogic.ChangePlayer(); //continue game and changing player
                else Application.LoadLevel("winner"); //else - show winner
            }
        }
    }
}
