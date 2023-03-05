using ConsolApp;

Cat cat = new Cat()
{
    Color = "Black",
    Name = "Tom",
    Age = 5, 
    IsLazy = true
};

Dog dog = new()
{
    Color = "Brown",
    Name = "Spike",
    Age = 3
};

void PrintAnimalInfo(Animal animal)
{
    animal.PrintInfo();
}
PrintAnimalInfo(cat);
PrintAnimalInfo(dog);

static void MakeNoise(Animal animal)
{
    animal.MakeNoise();
}
MakeNoise(cat);
MakeNoise(dog);

static void PrintAge(Animal animal)
{
    animal.PrintAge();
}
PrintAge(cat);
PrintAge(dog);

Cat cat1 = new()
{
    Color = "Black",
    Name = "Tom",
    Age = 5, 
    IsLazy = true
};

Cat cat2 = new Cat()
{
    Color = "Black",
    Name = "Tom",
    Age = 5, 
    IsLazy = true
};

Dog dog1 = new()
{
    Color = "Black",
    Name = "Tom",
    Age = 5, 
};

Console.WriteLine(cat1.Equals(cat2));//True
Console.WriteLine(cat1 == cat2);//False
Console.WriteLine(cat1.GetHashCode());
Console.WriteLine(cat2.GetHashCode());

Console.WriteLine(cat1.Equals(dog1));
Console.WriteLine(dog1.Equals(cat1));

Animal child = cat1.Multiply(cat2, "Child");

PrintAnimalInfo(child);