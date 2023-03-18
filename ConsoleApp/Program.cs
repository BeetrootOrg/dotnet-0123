
//============18/03/2023=============
// Homework 19-Методи розширення
// GroupBy(enumerable, func) extension to a collection that will return a dictionary 
// of grouped items by func. E.g. GroupBy([{a: 1, b: 2}, {a: 1, b: 3}, 
// {a: 2, b: 2}, item => item.a] => {1: [{a: 1, b: 2}, {a: 1, b: 3}], 2: [{a: 2, b: 2}]}

List<SomeClass> list = new() { new(){ Name="Vasya",Age=10 }, new(){Name="Petya", Age=10},new(){Name="Kolya", Age=15},
new(){Name="Ivan", Age=15}, new(){Name="Ann", Age=5},
new(){Name="Andrey", Age=20}   };
var result=list.GroupBy(x=>x.Age).ToList();
Console.WriteLine($"{string.Join("\n", result)}");

public static class IEnumerableExtension
{
    //static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        List<(TKey, TSource)> list=new(source.Count());
        List<TKey> listkey=new(source.Count());
        
        foreach (TSource item  in source){
            TKey key=keySelector.Invoke(item);
            list.Add(new (){Item1=key,Item2=item});    
            if (!listkey.Contains(key)) listkey.Add(key);
        }
        foreach(TKey key in list){
            Group<TKey, TSource> group   
        }

    }
}

public class SomeClass{
    public string Name{get;set;}
    public int Age{get;set;}   
}