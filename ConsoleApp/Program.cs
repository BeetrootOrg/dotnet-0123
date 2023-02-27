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

Cat cat1 = new()
{
    Color = "Black",
    Name = "Tom",
    IsLazy = true,
    Age = 5
};

Cat cat2 = new()
{
    Color = "Black",
    Name = "Tom",
    IsLazy = false,
    Age = 5
};

Dog dog1 = new()
{
    Color = "Black",
    Name = "Tom",
    Age = 5
};

Console.WriteLine(cat1.Equals(cat2));
Console.WriteLine(cat1 == cat2);
Console.WriteLine(cat1.GetHashCode());
Console.WriteLine(cat2.GetHashCode());

Console.WriteLine(cat1.Equals(dog1));
Console.WriteLine(dog1.Equals(cat1));