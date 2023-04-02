
namespace ConsoleApp
{
    class Snake : Cell
    {
        public List<object> snakeCells = new List<object>();

        public List<object> appleCells = new List<object>();
        int counterBuff = 0;
        public void CreateSnake()
        {
            snakeCells.Add(new Cell
            {
                Name = Counter++,
                Core = 106,
                Previous = 107,
                Next= 105,
                vector = 1
            });
            snakeCells.Add(new Cell
            {
                Name = Counter++,
                Core = 107,
                Previous = 108,
                Next= 106
            });
            snakeCells.Add(new Cell
            {
                Name = Counter++,
                Core = 108,
                Previous = 109,
                Next= 107
            });
            snakeCells.Add(new Cell
            {
                Name = Counter++,
                Core = 109,
                Next= 108
            });
        }

        public void createApple()
        {  

            Random random = new Random();
            int appleCords = random.Next(100, 200);
            int i = 0;

            foreach (Cell cell in snakeCells)
            {
                if (getX(cell.Core) != getX(appleCords) & getY(cell.Core) != getY(appleCords))
                {
                    i++;
                }
            }
            if (i == snakeCells.Count)
            {
                Apple apple = new Apple();
                apple.Core = appleCords;
                appleCells.Add(apple);
                
            }
            else
            {
                createApple();
            }
        }
        public int getY(int cell)
        {
            return (int)Math.Floor(Convert.ToDouble((cell/10)%10));
        }
        public int getX(int cell)
        {
            return (int)Math.Floor(Convert.ToDouble(cell % 10));
        }
        public void setVector(Cell cell)
        {
            if (cell.Core - cell.Previous == -1)
            {
                cell.vector = 1;
            }
            else if (cell.Core - cell.Previous == 1)
            {
                cell.vector = 3;
            }
            else if (cell.Core - cell.Previous == 10)
            {
                cell.vector = 4;
            }
            else
            {
                cell.vector = 2;
            }
        }
        public int getVector(Cell cell)
        {
            if (getY(cell.Core) - getY(cell.Previous) == -1)
            {
                return 1;
            }
            else if (getY(cell.Core) - getY(cell.Previous) == 1)
            {
                return 3;
            }
            else if (getX(cell.Core) - getX(cell.Previous) == 10)
            {
                return 4;
            }
            else if (getX(cell.Core) - getX(cell.Previous) == -10)
            {
                return 2;
            }
            return 1;
        }
        public int getNextByVector(Cell cell, int vector)
        {
            if (vector == 1)
            {
                return cell.Core - 1;
            }
            else if (vector == 3)
            {
                return cell.Core + 1;                
            }
            else if (vector == 2)
            {
                return cell.Core - 10;
            }
            else if (vector == 4)
            {
                return cell.Core + 10;
            }
            return cell.Next;
        }

        public char[,] Execute(char[,] field)
        {
            
            foreach(Apple apple in appleCells)
            {
                field[getX(apple.Core)+1, getY(apple.Core)+1] = 'A';
            }
            foreach (Cell cell in snakeCells)
            {

                if (cell.Name == 0)
                {
                    field[getX(cell.Next)+1, getY(cell.Next)+1] = '*';
                }
                else
                {
                    field[getX(cell.Previous)+1, getY(cell.Previous)+1] = '.';
                }
                field[getX(cell.Core)+1, getY(cell.Core)+1] = 'W';
            }


            return field;
        }
        public void Step(int vector)
        {
            counterBuff++;

            List<object> cellsToAdd = new List<object>();

            for (int i = 0; i < snakeCells.Count; i++)
            {
                Cell cell = (Cell)snakeCells[i];


                int temp1 = cell.Core;
                int temp2 = cell.Next;
                int temp3 = cell.Previous;
                cell.Core = temp2;
                cell.Previous = temp1;
                if (cell.Name != 0)
                {
                    Cell nextCell = (Cell)snakeCells[i-1];
                    cell.Next = nextCell.Core;
                }
                else
                {
                    cell.Next = getNextByVector(cell, vector);


                    
                    Apple apple = (Apple)appleCells[0];
                    if (getX(cell.Core) == getX(apple.Core) & getY(cell.Core) == getY(apple.Core))
                    {
                        Cell lastCell = (Cell)snakeCells[snakeCells.Count-1];
                        Cell newCell = new Cell
                        {
                            Name = Counter++,
                            Core = lastCell.Core,
                            Next = lastCell.Next,
                            Previous = lastCell.Previous,
                        };
                        cellsToAdd.Add(newCell);
                        appleCells.Clear();
                        createApple();
                    }
                }

            if (counterBuff > 8)
                {
                    foreach (Cell cell1 in snakeCells)
                    {
                        cell1.Core += 100;
                        cell1.Next += 100;
                        cell1.Previous += 100;
                    }
                    counterBuff = 0;
                }
            }
            if (cellsToAdd.Count > 0)
            {
                snakeCells.Add(cellsToAdd[0]);
                cellsToAdd.Clear();
            }
        }
    }
}