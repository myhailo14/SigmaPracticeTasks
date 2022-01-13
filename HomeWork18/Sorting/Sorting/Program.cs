// This is test program to demonstrate sorting algorithms
// Demo sort of numbers without and with predicates
// Demo sort of custom objects without and with predicates
using System.Text;
using System.Text.Json;
using Sorting;

void PrintArrayInConsole<T>(T[] array)
{
    var result = new StringBuilder();
    foreach (var item in array)
    {
        result.Append($"{item}");
    }
    Console.WriteLine(result);
}

// numbers work
int[] numbers1 = { 4, 1, 6, 2, 7, 2 };
int[] numbers2 = { 4, 1, 6, 2, 7, 2 };
int[] numbers3 = { 4, 1, 6, 2, 7, 2 };

Console.WriteLine("Initial numbers array:");
PrintArrayInConsole(numbers1);

// Sorting.Sorting.QuickSortRecursive(numbers1, IntMethods.CustomComparator, 0, numbers1.Length - 1, true, null);
// Sorting.Sorting.QuickSortIterative(numbers2, IntMethods.CustomComparator, 0, numbers2.Length - 1, true, null);
// Sorting.Sorting.HeapSort          (numbers3, IntMethods.CustomComparator, 0, numbers3.Length - 1, true, null);

Sorting.Sorting.QuickSortRecursive(numbers1, IntMethods.CustomComparator, 0, numbers1.Length - 1, true, IntMethods.CustomPredicate);
Sorting.Sorting.QuickSortIterative(numbers2, IntMethods.CustomComparator, 0, numbers2.Length - 1, true, IntMethods.CustomPredicate);
Sorting.Sorting.HeapSort          (numbers3, IntMethods.CustomComparator, 0, numbers3.Length - 1, true, IntMethods.CustomPredicate);

Console.WriteLine("Sorting numbers by 3 methods ");
PrintArrayInConsole(numbers1);
PrintArrayInConsole(numbers2);
PrintArrayInConsole(numbers3);

// cities work
string jsonData =
    File.ReadAllText(@"C:\Users\mykha\Desktop\Sigma_School\homework\HomeWork18\Sorting\Sorting\cities.json");
City[]? cities1 = JsonSerializer.Deserialize<City[]>(jsonData);
City[]? cities2 = JsonSerializer.Deserialize<City[]>(jsonData);
City[]? cities3 = JsonSerializer.Deserialize<City[]>(jsonData);



Console.WriteLine("Initial cities array:");
PrintArrayInConsole(cities1);

Sorting.Sorting.QuickSortRecursive(cities1, City.AreaComparator, 0, cities1.Length - 1, true, null);
Sorting.Sorting.QuickSortRecursive(cities2, City.AreaComparator, 0, cities2.Length - 1, true, null);
Sorting.Sorting.QuickSortRecursive(cities3, City.AreaComparator, 0, cities3.Length - 1, true, null);

Console.WriteLine("Sorting cities by 3 methods ");

PrintArrayInConsole(cities1);
PrintArrayInConsole(cities2);
PrintArrayInConsole(cities3);