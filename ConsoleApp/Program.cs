using ConsoleApp;

Cat cat = new()
{
    Color = "Black",
    Name = "Tom",
    IsLazy = true,
    Age = 5
};

Dog dog = new()
{
    Color = "Brown",
    Name = "Spike",
    Age = 3
};

static void PrintAnimalInfo(Animal animal)
{
    animal.PrintInfo();
}

static void MakeNoise(Animal animal)
{
    animal.MakeNoise();
}

static void PrintAge(Animal animal)
{
    animal.PrintAge();
}

PrintAnimalInfo(cat);
PrintAnimalInfo(dog);

MakeNoise(cat);
MakeNoise(dog);

PrintAge(cat);
PrintAge(dog);