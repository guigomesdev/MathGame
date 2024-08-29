using System;
using static System.Formats.Asn1.AsnWriter;

var date = DateTime.UtcNow;

var games = new List<string>();

string name = GetName();

Menu(name);

string GetName()
{
    Console.WriteLine("Please, type your name");

    var name = Console.ReadLine();
    return name;
}



void Menu(string name)
{
    Console.WriteLine("--------------------------------------\n");
    Console.WriteLine($"Hello, {name.ToUpper()}. It's {date}. This is your Maths Game. That's great you're working on improving yourself\n");
    Console.WriteLine("--------------------------------------");

    var isGameOn = true;

    do
    {
        Console.Clear();
        Console.WriteLine($@"Select the game you wanna play:
A -> +
S -> -
M -> *
D -> /
V - View previous games
Q -> Quit the game");
        Console.WriteLine("---------------------------------");

        var gameSelected = Console.ReadLine();

        switch (gameSelected.Trim().ToLower())
        {
            case "v":
                GetGames();
                break;
            case "a":
                AdditionGame("Addition game");
                break;
            case "s":
                SubtractionGame("Substraction game");
                break;
            case "m":
                MultiplicationGame("Multiplication game");
                break;
            case "d":
                DivisionGame("Division game");
                break;
            case "q":
                Console.WriteLine("Goodbye");
                isGameOn = false;
                break;
            default:
                Console.WriteLine("Invalid Input");
                break;
        }
    } while (isGameOn);
}

void GetGames()
{
    Console.Clear();
    Console.WriteLine("Games History");
    Console.WriteLine("---------------------------------");
    foreach (var game in games)
    {
        Console.WriteLine(game);
    }
    Console.WriteLine("---------------------------------\n");
    Console.WriteLine("Press any key to return to Main Menu\n");
    Console.ReadLine();

}

void DivisionGame(string message)
{

    var score = 0;

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        var divisionNumbers = GetDivisionNumbers();
        var firstNumber = divisionNumbers[0];
        var secondNumber = divisionNumbers[1];

        Console.WriteLine($"{firstNumber} / {secondNumber}");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber / secondNumber)
        {
            Console.WriteLine("Correct Answer! Type any key to see the next question");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Wrong Answer. Type any key to see the next question");
            Console.ReadLine();
        };

        if (i == 4)
        {
            Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
            Console.ReadLine();
        }


    }

    AddToHistory(score, "Division");

}

void MultiplicationGame(string message)
{

    var random = new Random();
    var score = 0;

    int firstNumber;
    int secondNumber;

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} * {secondNumber}");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber * secondNumber)
        {
            Console.WriteLine("Correct Answer! Type any key to see the next question");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Wrong Answer. Type any key to see the next question");
            Console.ReadLine();
        };

        if (i == 4)
        {
            Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
            Console.ReadLine();
        }
    }

    AddToHistory(score, "Multiplication");
}

void AdditionGame(string message)
{

    var random = new Random();
    var score = 0;

    int firstNumber;
    int secondNumber;

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);
        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} + {secondNumber}");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber + secondNumber)
        {
            Console.WriteLine("Correct Answer! Type any key to see the next question");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Wrong Answer. Type any key to see the next question");
            Console.ReadLine();
        };

        if (i == 4)
        {
            Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
            Console.ReadLine();
        }
    }

    AddToHistory(score, "Addition");

}

void SubtractionGame(string message)
{

    var random = new Random();
    var score = 0;

    int firstNumber;
    int secondNumber;

    for (int i = 0; i < 5; i++)
    {
        Console.Clear();
        Console.WriteLine(message);

        firstNumber = random.Next(1, 9);
        secondNumber = random.Next(1, 9);

        Console.WriteLine($"{firstNumber} - {secondNumber}");
        var result = Console.ReadLine();

        if (int.Parse(result) == firstNumber - secondNumber)
        {
            Console.WriteLine("Correct Answer! Type any key to see the next question");
            score++;
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Wrong Answer. Type any key to see the next question");
            Console.ReadLine();
        };

        if (i == 4)
        {
            Console.WriteLine($"Game Over. Your final score is {score}. Press any key to go back to the main menu.");
            Console.ReadLine();
        }
    }

    AddToHistory(score, "Subtraction");
}

int[] GetDivisionNumbers()
{
    var random = new Random();
    var firstNumber = random.Next(1, 99);
    var secondNumber = random.Next(1, 99);

    var result = new int[2];

    while (firstNumber % secondNumber != 0)
    {
        firstNumber = random.Next(1, 99);
        secondNumber = random.Next(1, 99);
    }

    result[0] = firstNumber;
    result[1] = secondNumber;


    return result;
}

Console.ReadLine();

void AddToHistory(int gameScore, string gameType)
{
    games.Add($"{DateTime.Now} - {gameType}: {gameScore} pts");
}