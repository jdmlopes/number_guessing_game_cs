char playAgain = 'y';

while (playAgain == 'y')
{
    
    Random rng = new();
    
    Console.WriteLine(@"Welcome to the Number Guessing Game!
    I'm thinking of a number between 1 and 100.
    You have 5 chances to guess the correct number.
    
    
    Please select the difficulty level:
    1. Easy (10 chances)
    2. Medium (5 chances)
    3. Hard (3 chances)
    ");
    int numberToGuess = rng.Next(1, 101);
    int difficulty = 0;
    while (true)
    {
        Console.Write("Enter your choice: ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out difficulty) && difficulty is 1 or 2 or 3)
            break;
        Console.WriteLine("Invalid input, try again");
    }
    int guesses = difficulty switch
    {
        1 => 10,
        2 => 5,
        3 => 3,
        _ => 10
    };
    
    Console.WriteLine("\nLet's start the game!\n");
    int guess = -1;
    while (guess != numberToGuess && guesses > 0)
    {
        Console.WriteLine($"You have {guesses} chances left.");
        while (true)
        {
            Console.Write("Enter your guess: ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out guess) && guess is >= 1 and <= 100)
                break;
            Console.WriteLine("Invalid input, try again");
        }
        if (guess < numberToGuess)
            Console.WriteLine("\nToo low, try a higher number\n");
        if (guess > numberToGuess)
            Console.WriteLine("\nToo high, try a lower number\n");
        guesses--;
    }
    
    if (guess == numberToGuess)
        Console.WriteLine($"You won, you guessed the number {numberToGuess} right!!!\n");
    else
        Console.WriteLine($"You lost, the right number was {numberToGuess}!!!\n");
    
    while (true)
    {
        Console.Write("Do you want to play again?(y/n) ");
        playAgain = Console.ReadKey().KeyChar;
        if (playAgain is 'y' or 'n')
            break;
        Console.WriteLine("Invalid input, try again");
    }
}







