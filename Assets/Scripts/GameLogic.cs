﻿using UnityEngine;

namespace TicTacToe 
{
  	public class GameLogic : MonoBehaviour 
  	{

		private static int[,] _field =  {
											{0,0,0},
											{0,0,0},
											{0,0,0}
										};

		private static int player = 1;

		public static int GetPlayer()
		{
			return player;
		}

		public static void Show()
		{
			string matrix = "";
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					matrix += _field[i,j].ToString() + " ";
			Debug.Log(matrix);
		}

		public static void SetPoint(int i, int j)
		{
			if (player != 0)
				_field [i, j] = player;
			else
				Debug.Log("Player is 0");
		}

		public static void ChangePlayer()
		{
			if (player != 0)
				player = -player;
		} 

		public static int FindWinner()
		{
			for (int i = 0; i < 3; i++)
			{
				if (_field[i,0] != 0)
					if ((_field[i,0] == _field[i,1]) && (_field[i,0] == _field[i,2])) return 1;

				if (_field[0,i] != 0)
					if ((_field[0,i] == _field[1,i]) && (_field[0,i] == _field[2,i])) return 1;

				if ((i == 1) && (_field[i,i] != 0) )
					if ((_field[i,i] == _field[i + 1,i + 1]) && (_field[i,i] == _field[i - 1,i - 1]) ||
					    (_field[i,i] == _field[i - 1,i + 1]) && (_field[i,i] == _field[i + 1,i - 1])  )
					    return 1;
			}

			bool marker = false;
			foreach (int x in _field)
			{
				if (x != 0) marker = true;
				else 
				{ 
					marker = false; 
					break;
				}
			}

			if (marker) return -1;
			else return 0;
		}
  	}
}