using System.Diagnostics;

class BinarySearch
{
    private const int ARRAY_SIZE = 11;
    private const int MAX_ELEMENT = 100;
    
    private static List<int> list = new(ARRAY_SIZE);
    private static int key;

    static void Main()
    {
        Random rand = new Random();
        for (int i = 0; i < ARRAY_SIZE; i++)
        {
            int value = rand.Next(1, MAX_ELEMENT);
            list.Add(value);
        }
        key = list[rand.Next(0, list.Count - 1)];
        list.Sort();
        
        Console.Write("Random array: ");
        for (int i = 0; i < ARRAY_SIZE; i++)
        {
            Console.Write(list[i] + ", ");
        }
        Console.WriteLine($"\nKey {key}");
        
        Console.WriteLine("Occurances: " + countOccurences());
        Console.WriteLine("Index (Custom): " + search());
        Console.WriteLine("Index (Native): " + searchNative());

    }

    public static int search()
    {
        int left = 0;
        int right = list.Count - 1;
        int compareOperations = 0;
        while (left <= right)
        {
            int middle = (left + right) / 2;
            if (list[middle] == key)
            {
                compareOperations++;
                Console.WriteLine($"Number of compare operations: {compareOperations}");
                return middle;
            } else if (list[middle] < key)
            {
                compareOperations++;
                left = middle - 1;
            }
            else
            {
                compareOperations++;
                right = middle - 1;
            }
            Console.WriteLine($"Number of compare operations: {compareOperations}");
        }
        return -1;
    }

    public static int countOccurences()
    {
        int left = 0;
        int right = list.Count - 1;
        while (left <= right)
        {
            int middle = (left + right) / 2;
            if (list[middle] == key)
            {
                int count = 1;
                int i = middle - 1;
                while (i >= 0 && list[i] == key)
                {
                    count++;
                    i--;
                }

                i = middle + 1;
                while (i < list.Count && list[i] == key)
                {
                    count++;
                    i++;
                }

                return count;
            } else if (list[middle] < key)
            {
                left = middle + 1;
            } 
            else right = middle - 1;
        }

        return 0;
    }
    
    public static int searchNative()
    {
        return list.BinarySearch(key);
    }
}