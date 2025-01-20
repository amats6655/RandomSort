using System.Diagnostics;

namespace RandomSort;

public class ViewService
{
	public static void Print(Stopwatch watch, int[] array, int[] sortedArray, SortType sortType)
	{
		// Console.WriteLine($"Массив размером: {array.Length} элементов");
		
		// Console.Write("Оригинальный массив: ");
		foreach(var item in array)
			Console.Write($"{item} ");
		Console.WriteLine();
		
		// Console.Write("Отсортированный массив: ");
		foreach (var item in sortedArray)
			Console.Write($"{item} ");
		Console.WriteLine();
		
		// Console.WriteLine($"Тип сортировки: {sortType}");
		// Console.WriteLine($"Время сортировки: {watch.Elapsed}");
	}
}