using Raylib_cs;
using System.Diagnostics;
using System.Numerics;

namespace GameOfLife
{
    static class Program
    {

        public static bool[,] UpdateGame(bool[,] GameState)
        {
            bool[,] updated = new bool[GameState.GetLength(0), GameState.GetLength(1)];

            //Loops trough the cells
            for (int i = 0; i < GameState.GetLength(0); i++)
                for (int j = 0; j < GameState.GetLength(1); j++)
                {
                    //Creates an array only with the neighbors of the cell
                    bool[,] NeighborsArray = new bool[3, 3];

                    for (int k = 0; k < NeighborsArray.GetLength(0); k++)
                    {
                        for (int l = 0; l < NeighborsArray.GetLength(1); l++)
                        {
                            //Console.Write(GameState[k+i,l+j]);
                            try { NeighborsArray[k, l] = GameState[k + i - 1, l + j - 1]; } //Try-catch for the cels that are in the edges
                            catch { NeighborsArray[k, l] = false; }
                            NeighborsArray[1, 1] = false; //Neded not not count the cell  as it's own neighbor
                        }
                    }


                    int NumberOfNeighbors = 0;

                    //Counts the neighbors of the cell
                    for (int k = 0; k < 3; k++)
                        for (int l = 0; l < 3; l++)
                            if (NeighborsArray[k, l])
                                NumberOfNeighbors++;

                    //Choses the state of the cell
                    switch (NumberOfNeighbors)
                    {
                        case 0:
                            updated[i, j] = false; break;
                        case 1:
                            updated[i, j] = false; break;
                        case 2:
                            updated[i, j] = GameState[i, j]; break;
                        case 3:
                            updated[i, j] = true; break;

                        case 9:
                            Console.WriteLine("Nine cells where conted"); updated[i, j] = false; break;
                        default:
                            updated[i, j] = false;
                            if (NumberOfNeighbors > 9)
                                Console.WriteLine("What?!: " + NumberOfNeighbors);
                            break;



                    }


                }

            return updated;
        }

        public static void Main()
        {


            bool Runing = false;

            Raylib.InitWindow(800, 480, "Game Of Life");

            bool[,] CellArray = new bool[80, 48];
            for (int i = 0; i < CellArray.GetLength(0); i++)
                for (int j = 0; j < CellArray.GetLength(1); j++)
                    CellArray[i, j] = false;


            // Main loop
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                Vector2 mousePos = Raylib.GetMousePosition();

                // Changes the mouse is on top of, when you click on it
                if (Raylib.IsMouseButtonPressed(0))
                    try { CellArray[(int)mousePos.X / 10, (int)mousePos.Y / 10] = !CellArray[(int)mousePos.X / 10, (int)mousePos.Y / 10]; }
                    catch { } //Try-catch if the mouse is outside the game window

                // Draws the cells
                for (int i = 0; i < CellArray.GetLength(0); i++)
                    for (int j = 0; j < CellArray.GetLength(1); j++)
                        if (CellArray[i, j])
                            Raylib.DrawRectangle(i * 10, j * 10, 10, 10, Color.WHITE);

                // Pauses/unpauses the game
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                {
                    Runing = !Runing;
                    Console.WriteLine(Runing);
                }


                // Updates the game
                if (Runing)
                {
                    Stopwatch sw = Stopwatch.StartNew();

                    CellArray = UpdateGame(CellArray);

                    while (sw.ElapsedMilliseconds < 100) { } // Makes sure at least 100 ms have passed before updating again

                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}