
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
                name = counter++,
                _core = 106,
                _previous = 107,
                _next= 105,
                vector = 1
            });
            snakeCells.Add(new Cell
            {
                name = counter++,
                _core = 107,
                _previous = 108,
                _next= 106
            });
            snakeCells.Add(new Cell
            {
                name = counter++,
                _core = 108,
                _previous = 109,
                _next= 107
            });
            snakeCells.Add(new Cell
            {
                name = counter++,
                _core = 109,
                _next= 108
            });
        }

        public void createApple()
        {  

            Random random = new Random();
            int appleCords = random.Next(100, 200);
            int i = 0;

            foreach (Cell cell in snakeCells)
            {
                if (getX(cell._core) != getX(appleCords) & getY(cell._core) != getY(appleCords))
                {
                    i++;
                }
            }
            if (i == snakeCells.Count)
            {
                Apple apple = new Apple();
                apple._core = appleCords;
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
            if (cell._core - cell._previous == -1)
            {
                cell.vector = 1;
            }
            else if (cell._core - cell._previous == 1)
            {
                cell.vector = 3;
            }
            else if (cell._core - cell._previous == 10)
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
            if (getY(cell._core) - getY(cell._previous) == -1)
            {
                return 1;
            }
            else if (getY(cell._core) - getY(cell._previous) == 1)
            {
                return 3;
            }
            else if (getX(cell._core) - getX(cell._previous) == 10)
            {
                return 4;
            }
            else if (getX(cell._core) - getX(cell._previous) == -10)
            {
                return 2;
            }
            return 1;
        }
        public int getNextByVector(Cell cell, int vector)
        {
            if (vector == 1)
            {
                return cell._core - 1;
            }
            else if (vector == 3)
            {
                return cell._core + 1;                
            }
            else if (vector == 2)
            {
                return cell._core - 10;
            }
            else if (vector == 4)
            {
                return cell._core + 10;
            }
            return cell._next;
        }

        public char[,] Execute(char[,] field)
        {
            
            foreach(Apple apple in appleCells)
            {
                field[getX(apple._core)+1, getY(apple._core)+1] = 'A';
            }
            foreach (Cell cell in snakeCells)
            {

                if (cell.name == 0)
                {
                    field[getX(cell._next)+1, getY(cell._next)+1] = '*';
                }
                else
                {
                    field[getX(cell._previous)+1, getY(cell._previous)+1] = '.';
                }
                field[getX(cell._core)+1, getY(cell._core)+1] = 'W';
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


                int temp1 = cell._core;
                int temp2 = cell._next;
                int temp3 = cell._previous;
                cell._core = temp2;
                cell._previous = temp1;
                if (cell.name != 0)
                {
                    Cell nextCell = (Cell)snakeCells[i-1];
                    cell._next = nextCell._core;
                }
                else
                {
                    cell._next = getNextByVector(cell, vector);


                    
                    Apple apple = (Apple)appleCells[0];
                    if (getX(cell._core) == getX(apple._core) & getY(cell._core) == getY(apple._core))
                    {
                        Cell lastCell = (Cell)snakeCells[snakeCells.Count-1];
                        Cell newCell = new Cell
                        {
                            name = counter++,
                            _core = lastCell._core,
                            _next = lastCell._next,
                            _previous = lastCell._previous,
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
                        cell1._core += 100;
                        cell1._next += 100;
                        cell1._previous += 100;
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