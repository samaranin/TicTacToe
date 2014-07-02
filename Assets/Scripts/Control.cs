using UnityEngine;

namespace TicTacToe{
 public class Control : MonoBehaviour {

	void OnMouseDown()
	{
		if (gameObject.tag == "Button") 
		{
			GameObject figure;
			int player = GameLogic.GetPlayer();

			if (player == 1)
				figure = (GameObject)Instantiate(Resources.Load("Prefabs/Zero", typeof(GameObject)));
			else 
				figure = (GameObject)Instantiate(Resources.Load("Prefabs/Cross", typeof(GameObject)));

			switch (gameObject.name)
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

			figure.transform.position = gameObject.transform.position;
			Destroy(gameObject);

			if (GameLogic.FindWinner() == 1)
			{ 
				if (player == 1) Debug.Log("Winner: X");
				if (player == -1) Debug.Log("Winner: 0");
			}
			else if ( GameLogic.FindWinner() == -1) Debug.Log("Both lose!");
					else GameLogic.ChangePlayer();
		}
	}
 }
}
