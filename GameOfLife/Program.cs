using Raylib_cs;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {
            Raylib.InitWindow(800, 480, "Game Of Life");

            bool[,] CellArray = new bool[80, 48];


            for (int i = 0; i < CellArray.GetLength(0); i++)
                for (int j = 0; j < CellArray.GetLength(1); j++)
                    CellArray[i, j] = false;

            /*for (int i = 0; i < CellArray.GetLength(0); i++)
            for (int j = 0; j < CellArray.GetLength(1); j++)
                Console.Write(CellArray[i, j]); */


            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                Vector2 mousePos = Raylib.GetMousePosition();


                if (Raylib.IsMouseButtonPressed(0))
                    try { CellArray[(int)mousePos.X / 10, (int)mousePos.Y / 10] = !CellArray[(int)mousePos.X / 10, (int)mousePos.Y / 10]; }
                    catch { }

                

                /*for(int i = 0;i < 800; i+=10)
                    Raylib.DrawLine(i,0,i,480,Color.BLACK);

                for(int i=0;i<480;i+=10)
                    Raylib.DrawLine(0,i,800,i,Color.BLACK);*/

                for (int i = 0; i < CellArray.GetLength(0); i++)
                    for (int j = 0; j < CellArray.GetLength(1); j++)
                        if (CellArray[i,j])
                            Raylib.DrawRectangle(i*10,j*10,10,10,Color.WHITE);


                //Raylib.DrawRectangle(Raylib.GetMouseX()/10, Raylib.GetMouseY()/10, 10, 10, Color.BLUE);



                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}