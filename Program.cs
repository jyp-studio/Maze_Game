using System;

//using wasd to move the mouse in a maze.
namespace Mice
{
    class Program
    {
        static void Main(string[] args)
        {
            //initial maze via using random numbers
            int m = 1;
            int n = 1;
            int[,] maze = new int[50, 50];
            Random m_random = new Random();
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    if (i == 0 || j == 0 || i == 49 || j == 49)
                    {
                        maze[i, j] = 1;
                    }
                    else
                    {
                        maze[i, j] = m_random.Next() % 2;
                    } 
                }
            }
            maze[1, 1] = 2; maze[48, 48] = 3;

            //initial BOMB
            int counter = 3;
            for (int i = 5; i < 50; i += 5)
            {
                for (int j = 5; j < 50; j+= 5)
                {
                    maze[i, j] = 4;
                }
            }

            //bomb function
            void Bomb(int m, int n)
            {
                if (counter > 0)
                {
                    for (int i = (m - 2); i < 5; i++)
                    {
                        for (int j = (n - 2); j < 5; j++)
                        {
                                maze[i, j] = 0;
                        }
                    }
                    maze[m, n] = 2;
                    counter--; 
                }
                else
                {
                    Console.WriteLine("You dont have bomb!");
                }
            }

            //special skills function
            void Bomb_counter(int m, int n)
            {
                if (maze[m, n] == 4)
                {
                    counter++;
                }
            }

            //print function
            void PrintMaze()
            {
                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        switch (maze[i, j])
                        {
                            case 1:
                                Console.Write("■");
                                break;
                            case 2:
                                Console.Write("Ｍ");
                                break;
                            case 3:
                                Console.Write("☆");
                                break;
                            case 4:
                                Console.Write("⊙");
                                break;
                            default:
                                Console.Write("　");
                                break;
                        }
                        if (j == 49)
                        {
                            Console.Write("\n");
                        }
                    }
                }
                Console.WriteLine(counter + " bombs left.");
            }

            //print the maze
            PrintMaze();
            
            //control the mouse
            Console.WriteLine("Where do you want to move?");
            Console.WriteLine("Use 'w' 'a' 's' 'd' to move and use \"'\" to Boom surroundings!");
            Console.WriteLine("Remember that you can only use bomb for three times!\nunless you pick up bombs on the ground.");
            do
            {
                string offset = Console.ReadLine();
                switch (offset)
                {
                    case "w":
                        if (maze[m -1, n] != 1)
                        {
                            Bomb_counter(m - 1, n);
                            maze[m - 1, n] = 2;
                            maze[m, n] = 0;
                            m--;
                        }
                        break;
                    case "a":
                        if (maze[m, n - 1] != 1)
                        {
                            Bomb_counter(m, n - 1);
                            maze[m, n - 1] = 2;
                            maze[m, n] = 0;
                            n--;
                        }
                        break;
                    case "s":
                        if (maze[m + 1, n] != 1)
                        {
                            Bomb_counter(m + 1, n);
                            maze[m + 1, n] = 2;
                            maze[m, n] = 0;
                            m++;
                        }
                        break;
                    case "d":
                        if (maze[m, n + 1] != 1)
                        {
                            Bomb_counter(m, n + 1);
                            maze[m, n + 1] = 2;
                            maze[m, n] = 0;
                            n++;
                        }
                        break;
                    case "'":
                        try
                        {
                            Bomb(m, n);
                        }
                        catch
                        {
                            Console.WriteLine("Out of array! Help me fix this bug.");
                        }
                        break;
                    default:
                        Console.WriteLine("This is not a correct movemont!");
                        break;
                }
                PrintMaze();
            } while (m != 48 | n != 48);
            Console.WriteLine("Congratulations!");
        }
    }
}
