namespace RandomSort;

public class SortService
{
    public static int[] Sort(SortType type, int[] array)
    {
        return type switch
        {
            SortType.BubbleSort    => BubbleSort(array),
            SortType.QuickSort     => QuickSort(array),
            SortType.InsertionSort => InsertionSort(array),
            _ => throw new NotImplementedException()
        };
    }
    
    private static int[] QuickSort(int[] input)
    {
        if (input == null || input.Length <= 1)
        {
            return input ?? Array.Empty<int>();
        }

        int pivot = input[input.Length / 2];
        var left = new List<int>();
        var middle = new List<int>();
        var right = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] < pivot)
            {
                left.Add(input[i]);
            }
            else if (input[i] == pivot)
            {
                middle.Add(input[i]);
            }
            else
            {
                right.Add(input[i]);
            }
        }

        var leftSorted = QuickSort(left.ToArray());
        var rightSorted = QuickSort(right.ToArray());

        var result = new int[leftSorted.Length + middle.Count + rightSorted.Length];
        leftSorted.CopyTo(result, 0);
        middle.ToArray().CopyTo(result, leftSorted.Length);
        rightSorted.CopyTo(result, leftSorted.Length + middle.Count);

        return result;
    }

    private static int[] BubbleSort(int[] input)
    {
        var copy = (int[])input.Clone();

        for (int write = 0; write < copy.Length; write++)
        {
            for (int sort = 0; sort < copy.Length - 1; sort++)
            {
                if (copy[sort] > copy[sort + 1])
                {
                    int temp = copy[sort + 1];
                    copy[sort + 1] = copy[sort];
                    copy[sort] = temp;
                }
            }
        }
        return copy;
    }
    
    private static int[] InsertionSort(int[] input)
    {
        var copy = (int[])input.Clone();

        for (int i = 1; i < copy.Length; i++)
        {
            int key = copy[i];
            int j = i - 1;

            while (j >= 0 && copy[j] > key)
            {
                copy[j + 1] = copy[j];
                j--;
            }

            copy[j + 1] = key;
        }

        return copy;
    }
}