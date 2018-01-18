﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsV2
{
    class Program
    {
        static void Main(string[] args)
        {

            var ran = new Random();
            var grid_x = 11;
            var grid_y = 11;
            var gridObject = new string[grid_x, grid_y];
            int direction = ran.Next(0, 1);
            gridObject = DrawShip(direction,5,gridObject,ran);


            for (var x = 1; x < grid_x; x++)
            {
                for (var y = 1; y < grid_y; y++)
                {
                    if (gridObject[x, y] == "V" || gridObject[x, y] == "H")
                    {

                        gridObject[x, y] = "~";

                    }

                }
            }


            Display(grid_x, grid_y, gridObject);
            Console.ReadLine();
        }

        static void Display(int gridX, int gridY, string[,] gridObject)
        {
            Console.Clear();
            Console.WriteLine("   A  B  C  D  E  F  G  H  I  J");
            for (int x = 1; x < gridX; x++)
            {
                if (x < 10)
                {
                    Console.Write(" " + x);
                }
                else if (x >= 10)
                {
                    Console.Write(x);
                }
                for (int y = 1; y < gridY; y++)
                {
                    //Console.Write(y);
                    if (gridObject[x, y] == "~")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (gridObject[x, y] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("|" + gridObject[x, y] + "|");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine("");

            }


        }

    static string[,] DrawShip(int direction, int shipLength, string[,] grid, Random ranN)
        {
            var noShips = false;
            while (noShips == false)
            {
                if (direction == 1) //vertical
                {
                    var shipsY = ranN.Next(0, 9 - shipLength);
                    var shipsX = ranN.Next(0, 9);

                    noShips = CheckForShips(1, shipsX, shipsY, grid, shipLength);
                    if (noShips)
                    {
                        for (var i = 0; i < shipLength; i++)
                        {
                            grid[shipsX, shipsY++] = "V";
                        }
                    }
                    else
                    {
                        DrawShip(direction, shipLength, grid, ranN);
                    }

                }
                else //Horizontal
                {
                    var shipsX = ranN.Next(0, 9 - shipLength);
                    var shipsY = ranN.Next(0, 9);

                    noShips = CheckForShips(0, shipsX, shipsY, grid, shipLength);

                    if (noShips)
                    {
                        for (var i = 0; i < shipLength; i++)
                        {
                            grid[shipsX++, shipsY] = "H";
                        }
                    }
                    else
                    {
                        CheckForShips(0, shipsX, shipsY, grid, shipLength);
                    }
                }
                return grid;
            }
            return grid;
        }

        static bool CheckForShips(int direction, int positionX, int positionY, string[,] grid, int shipLength)
        {
            if (direction == 1) //vertical
            {
                for (var i = positionY; i < positionX + shipLength; i++)

                {
                    if (grid[i, positionY] != "V")
                    {
                        return false;
                    }
                }
            }
            else //Horizontal
            {
                for (var i = positionX; i < shipLength + positionY; i++)
                {
                    if (grid[positionX, i] != "H")
                    {
                        return false;
                    }

                }
            }

            return true;
        }
    }
}