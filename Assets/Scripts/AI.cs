using UnityEngine;
using System;

namespace TicTacToe
{
	public class AI : GameLogic {

		private static int CheckEnemyLine(int player)
		{
			for (int i = 0; i < 3; i++)
			{
				//cheking for enemy's line and plase there our figure
				if (_field[i,0] != 0)
				{
					if ( (_field[i,0] == _field[i,1]) && (_field[i,0] == -player) && (_field[i,2] == 0))
					{
						switch (i)
						{ 
							case 0: return 3;
							case 1: return 6;
							case 2: return 9;
							default: break;
						}
					}
					
					if ( (_field[i,0] == _field[i,2]) && (_field[i,0] == -player) && (_field[i,1] == 0) )
					{
						switch (i)
						{ 
							case 0: return 2;
							case 1: return 5;
							case 2: return 8;
							default: break;
                        }
					}
					
					if ( (_field[i,1] == _field[i,2]) && (_field[i,1] == -player) && (_field[i,0] == 0) )
					{
						switch (i)
						{ 
							case 0: return 1;
							case 1: return 4;
							case 2: return 7;
							default: break;
                        }
					}
				}
				
				//cheking for enemy's column and plase there our figure
				if (_field[0,i] != 0)
				{
					if ( (_field[0,i] == _field[1,i]) && (_field[0,i] == -player) && (_field[2,i] == 0) )
					{
						switch (i)
						{ 
							case 0: return 7;
							case 1: return 8;
							case 2: return 9;
							default: break;
                        }
					}
					
					if ( (_field[0,i] == _field[2,i]) && (_field[0,i] == -player) && (_field[1,i] == 0) )
					{
						switch (i)
						{ 
							case 0: return 4;
							case 1: return 5;
							case 2: return 6;
							default: break;
                        }
					}
					
					if ( (_field[1,i] == _field[2,i]) && (_field[1,i] == -player) && (_field[0,i] == 0) )
					{
						switch (i)
						{ 
							case 0: return 1;
							case 1: return 2;
							case 2: return 3;
							default: break;
                        }
					}
				}

				//cheking for enemy's diagonal and plase there our figure
				if ((i == 1) && (_field[i,i] != 0) )
				{
					if ((_field[i,i] == _field[i + 1,i + 1]) && (_field[i,i] == -player) && (_field[i - 1,i - 1] == 0) ) return 1;
					if ((_field[i,i] == _field[i - 1,i - 1]) && (_field[i,i] == -player) && (_field[i + 1,i + 1] == 0) ) return 9;
					if ((_field[i,i] == _field[i - 1,i + 1]) && (_field[i,i] == -player) && (_field[i + 1,i - 1] == 0) ) return 7;
					if ((_field[i,i] == _field[i + 1,i - 1]) && (_field[i,i] == -player) && (_field[i - 1,i + 1] == 0) ) return 3;
				}
				
			}

			return -1; // if no enemy lines
		}

		private static int AnotherMoves(int player)
		{
			if ((_field[1,0] == _field[0,1]) && (_field[1,0] == _field[0,2]) && (_field[1,0] == -player) &&
			    (_field[1,1] == _field[1,2]) && (_field[1,1] == player)) return 1;
			if (_field[1,1] == 0) return 5; //try to take center
			else 
			{
				if (_field[1,1] == player) //else try to take center vertical or horizontal
				{
					if (_field[0,1] == 0) return 2;
					else if (_field[1,0] == 0) return 4;
					else if (_field[1,2] == 0) return 6;
					else if (_field[2,1] == 0) return 8;
               	 	else
                	{
						if (_field[0,0] == 0) return 1;
						if (_field[0,1] == 0) return 2;
						if (_field[1,1] == 0) return 5;
                       	if (_field[0,2] == 0) return 3;
						if (_field[1,0] == 0) return 4;
						if (_field[1,2] == 0) return 6;
						if (_field[2,2] == 0) return 9;
                       	if (_field[2,0] == 0) return 7;
						if (_field[2,1] == 0) return 8;
						else return -1;
                    }
            	}
				else 
				{
					if (_field[0,1] == 0) return 2;
					if (_field[0,2] == 0) return 3;
					if (_field[0,0] == 0) return 1;
                    if (_field[1,0] == 0) return 4;
					if (_field[1,1] == 0) return 5;
					if (_field[1,2] == 0) return 6;
					if (_field[2,0] == 0) return 7;
                    if (_field[2,2] == 0) return 9;
					if (_field[2,1] == 0) return 8;
					else return -1;
                }
            }
		}

		public static int FindMove()
		{
			int player = GameLogic.GetPlayer();

			bool marker = false;
			foreach (int x in _field)
			{
				if (x != 0) marker = true; //if every cell is not empty
				else 
				{ 
					marker = false; 
					break;
				}
			}

			if (!marker) //if exist empty cell
			{
				int enemy = -player;
				if (CheckEnemyLine(enemy) != -1) return CheckEnemyLine(enemy); //looking for enemy lines
				if (CheckEnemyLine(player) != -1) return CheckEnemyLine(player); //looking for our lines
				if (AnotherMoves(player) != -1) return AnotherMoves(player); //another option
				else return -1;
			}

			return -1;
		}

	}
}
