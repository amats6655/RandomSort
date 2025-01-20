namespace RandomSort;

public class GenerateNumbersService
{
	public static int[] GenerateNumbers()
	{
		var arrSize = Random.Shared.Next(20, 100);
		var resultArray = new int[arrSize];
		for (var i = 0; i < arrSize; i++)
		{
			resultArray[i] = Random.Shared.Next(-100, 100);
		}
		Console.WriteLine(arrSize);
		return resultArray;
	}
}