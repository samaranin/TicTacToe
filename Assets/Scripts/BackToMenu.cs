using UnityEngine;

namespace TicTacToe
{
	public class BackToMenu : MonoBehaviour {

		void FixedUpdate () {
			if(Input.GetKey(KeyCode.Escape)) //If escape key is pressed...
			{
				GameLogic.Reset(); //reset game
				Application.LoadLevel("Menu"); //Load the menu
			}
		}
	}
}
