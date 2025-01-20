namespace RandomSort;

public class RandomService
{
	public static int[] GenerateNumbers()
	{
		var arrSize = Random.Shared.Next(20, 100);
		var resultArray = new int[arrSize];
		for (var i = 0; i < arrSize; i++)
		{
			resultArray[i] = Random.Shared.Next(-100, 100);
		}
		return resultArray;
	}

	public static SortType GenerateSortType()
	{
		Array values = Enum.GetValues(typeof(SortType));
		var sortType = (SortType)values.GetValue(Random.Shared.Next(values.Length));
		return sortType;
	}
}