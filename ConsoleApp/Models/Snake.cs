using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleApp.Enums;
using ConsoleApp.Models.Objects;

namespace ConsoleApp.Models
{
    internal class Snake
    {
        private List<SnakeObject> _body;
        public Direction Direction { get; private set; }

        public SnakeObject Head => _body.First();
        public int Score;
        public int Length => _body.Count;
        public Snake(Border border)
        {
            int headY = border == null ? 0 : border.Height / 2;
            _body = new List<SnakeObject>
            {
                new SnakeObject(2, headY),
                new SnakeObject(1, headY),
                new SnakeObject(0, headY)
            };
            Direction = Direction.Right;
        }
        // Return value determines whether apple had been eaten or not.
        public bool Update(Direction direction, Apple apple = null)
        {
            ValidateDirection(direction);
            return MoveAndTryGrow(apple);
        }
        public void Render()
        {
            _body[0].Render(ConsoleColor.Yellow);
            foreach (SnakeObject snakePart in _body.Skip(1))
            {
                snakePart.Render();
            }
        }
        public bool IsHitted()
        {
            foreach (SnakeObject item in _body.Skip(1))
            {
                if (Head.X == item.X && Head.Y == item.Y)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckWrongAppleGeneration(Apple apple)
        {
            foreach (SnakeObject item in _body)
            {
                if (item.X == apple.X && item.Y == apple.Y)
                {
                    return true;
                }
            }
            return false;
        }

        private void ValidateDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (Direction == Direction.Down)
                    {
                        return;
                    }
                    Direction = direction;
                    break;
                case Direction.Right:
                    if (Direction == Direction.Left)
                    {
                        return;
                    }
                    Direction = direction;
                    break;
                case Direction.Down:
                    if (Direction == Direction.Up)
                    {
                        return;
                    }
                    Direction = direction;
                    break;
                case Direction.Left:
                    if (Direction == Direction.Right)
                    {
                        return;
                    }
                    Direction = direction;
                    break;
                default:
                    break;
            }
        }
        // Grow snake if it possible, if not the snake just moves.
        private bool MoveAndTryGrow(Apple apple)
        {
            if (apple == null)
            {
                return false;
            }

            SnakeObject newHead = Head.Move(Direction);

            List<SnakeObject> newBody = new()
            {
                newHead
            };

            if (newHead.X == apple.X && newHead.Y == apple.Y)
            {
                Score++;

                newBody.AddRange(_body);
                _body = newBody;

                return true;
            }
            newBody.AddRange(_body.SkipLast(1));
            _body = newBody;

            return false;
        }
    }
}