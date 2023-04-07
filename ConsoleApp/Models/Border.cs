using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleApp.Enums;
using ConsoleApp.Exceptions;
using ConsoleApp.Models.Objects;

namespace ConsoleApp.Models
{
    internal class Border
    {
        private List<BorderObject> _borders = new List<BorderObject>();
        public int Width { get; }
        public int Height { get; }
        public Border(int width, int height)
        {
            if (width < 5 || height < 5)
            {
                throw new InvalidBorderSizeException("Minimum width/height of field can be less than 5.");
            }
            if (width > 50 || height > 50)
            {
                throw new InvalidBorderSizeException("Maximum width/height of field can be more than 50.");
            }

            Width = width;
            Height = height;

            for (int i = 0; i < width + 1; i++)
            {
                BorderObject o = new BorderObject(i, height);
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
        public bool TouchCheck(Objects.IGameObject gameObject)
        {
            foreach (Objects.IGameObject item in _borders)
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