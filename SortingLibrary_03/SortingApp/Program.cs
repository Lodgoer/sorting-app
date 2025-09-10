using SortingLibrary_03;
using System;

class Program
{
    static void Main(string[]? args)
    {
        Console.Clear();
        Console.Title = "Sorting Application";
        DisplayWelcomeMessage();

        // Show sorting options with a cleaner menu
        ShowSortingOptions();

        // Get sorting algorithm choice from user
        int choice = GetUserChoice(1, 6);
        ISortable<int> selectedSort = GetSortingAlgorithm(choice);

        // Ask for numbers to sort with clear instructions
        int[] numbers = GetNumbersFromUser();

        // Get sorting order (ascending or descending)
        int order = GetSortingOrder();
        var result = order == 1 ? selectedSort.SortAscending(numbers) : selectedSort.SortDescending(numbers);

        // Display sorted numbers
        DisplaySortedNumbers(result);

        // Ask if the user wants to run the program again
        AskToRunAgain();
    }

    static void DisplayWelcomeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to the Sorting Application!");
        Console.ResetColor();
        Console.WriteLine("This app helps you sort your numbers using different algorithms.");
        Console.WriteLine("=============================================");
    }

    static void ShowSortingOptions()
    {
        Console.WriteLine("Select a sorting algorithm:");
        string[] sortingOptions =
        {
            "1. Bubble Sort",
            "2. Selection Sort",
            "3. Insertion Sort",
            "4. Quick Sort",
            "5. Merge Sort",
            "6. Radix Sort"
        };

        foreach (var option in sortingOptions)
        {
            Console.WriteLine(option);
        }
    }

    static ISortable<int> GetSortingAlgorithm(int choice)
    {
        return choice switch
        {
            1 => new BubbleSort<int>(),
            2 => new SelectionSort<int>(),
            3 => new InsertionSort<int>(),
            4 => new QuickSort<int>(),
            5 => new MergeSort<int>(),
            6 => new RadixSort<int>(),
            _ => new BubbleSort<int>(), // Default to BubbleSort if invalid
        };
    }

    static int GetUserChoice(int min, int max)
    {
        int choice;
        while (true)
        {
            Console.Write("\nPlease enter your choice (1-6): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
                break;
            else
                Console.WriteLine($"Invalid choice! Please enter a number between {min} and {max}.");
        }
        return choice;
    }

    static int[] GetNumbersFromUser()
    {
        int[] numbers;
        Console.WriteLine("\nEnter the numbers you want to sort (comma-separated):");
        while (true)
        {
            string input = Console.ReadLine();
            string[] inputArray = input.Split(',');

            try
            {
                numbers = Array.ConvertAll(inputArray, int.Parse);
                break;
            }
            catch
            {
                Console.WriteLine("Invalid input! Please enter a valid list of numbers separated by commas.");
            }
        }
        return numbers;
    }

    static int GetSortingOrder()
    {
        Console.WriteLine("\nSelect sorting order:");
        Console.WriteLine("1. Ascending");
        Console.WriteLine("2. Descending");

        return GetUserChoice(1, 2);
    }

    static void DisplaySortedNumbers(int[] numbers)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nHere are your sorted numbers:");
        Console.WriteLine(string.Join(", ", numbers));
        Console.ResetColor();
    }

    static void AskToRunAgain()
    {
        Console.WriteLine("\nWould you like to sort another list of numbers? (y/n)");
        string response = Console.ReadLine()?.ToLower();

        if (response == "y")
        {
            Main(null); // Restart the program
        }
        else
        {
            Console.WriteLine("\nThank you for using the Sorting Application!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}