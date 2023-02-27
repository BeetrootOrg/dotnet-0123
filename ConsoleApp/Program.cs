using ConsoleApp;

Cat cat = new()
{
    Color = "Black",
    Name = "Tom"
};

Dog dog = new()
{
    Color = "Brown",
    Name = "Spike"
};

static void PrintAnimalInfo(Animal animal)
{
    animal.PrintInfo();
}

static void MakeNoise(Animal animal)
{
    animal.MakeNoise();
}

PrintAnimalInfo(cat);
PrintAnimalInfo(dog);

MakeNoise(cat);
MakeNoise(dog);