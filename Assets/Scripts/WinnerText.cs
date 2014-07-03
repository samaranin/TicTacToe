using UnityEngine;
using System.Collections;

namespace TicTacToe
{
	public class WinnerText : MonoBehaviour {

		// Update is called once per frame
		void Update () {
			string winner = "";
			if (GameLogic.FindLine() == 1) //if we find line
			{ 
				if (GameLogic.GetPlayer() == 1) winner = "X"; //winner x
				if (GameLogic.GetPlayer() == -1) winner = "0"; //else winer 0
			}
			else if ( GameLogic.FindLine() == -1) winner = "Nobody"; //or no winners
			guiText.text = winner; //writing our winner
		}
	}
}