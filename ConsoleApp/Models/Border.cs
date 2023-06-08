using System.Collections.Generic;

using ConsoleApp.Exceptions;
using ConsoleApp.Models.Objects;

namespace ConsoleApp.Models
{
    internal class Border
    {
        private readonly List<BorderObject> _borders = new();
        public int Width { get; }
        public int Height { get; }
        public Border(int width, int height)
        {
            if (width < 5 || height < 5)
            {
                throw new InvalidBorderSizeException("Minimum width/height of field can be less than 5.");
            }
            if (width > 20 || height > 20)
            {
                throw new InvalidBorderSizeException("Maximum width/height of field can be more than 20.");
            }

            Width = width;
            Height = height;

            for (int i = 0; i < width + 1; i++)
            {
                BorderObject o = new(i, height);
                _borders.Add(o);
            }
            for (int i = 0; i < height; i++)
            {
                _borders.Add(new BorderObject(width, i));
            }
        }
        public void Render()
        {
            foreach (BorderObject borderObject in _borders)
            {
                borderObject.Render();
            }
        }
        public bool TouchCheck(IGameObject gameObject)
        {
            foreach (IGameObject item in _borders)
            {
                if (item.X == gameObject.X && item.Y == gameObject.Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}