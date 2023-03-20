using System;
using static System.Console;
namespace SnakeGame
{
    public class Program
    {
       private const int MapWidth = 40;
       private const int MapHeigth = 40;
       private const ConsoleColor BorderColor = ConsoleColor.Gray;

       static void Main()
       {
          SetWindowSize(MapWidth, MapHeigth);
          SetBufferSize(MapWidth, MapHeigth);
          CursorVisible = false;

          DrawBorder();

          ReadKey();
       }

       static void DrawBorder()
       {
            for(int i = 0; i < MapWidth; i++)
            {
                new Pixel (i, 0, BorderColor).Draw();
                new Pixel (i, MapHeigth - 1, BorderColor).Draw();
            }
       }
    }
}