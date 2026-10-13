using PersonClassLibrary;

// Write a welcome message.
WriteWelcomeInfo();

// Read the bonus to be used for each person entered.
var bonus = ReadBonusPercentage();

// Write a info message for how to add a person.
WriteAddPersonInfo();

var persons = new List<Person>();

var exit = false;

while (!exit)
{
    try
    {
        var line = Console.ReadLine();

        if (string.IsNullOrEmpty(line))
        {
            exit = true;
            break;
        }

        var cmdArgs = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        if (cmdArgs.Length != 4)
        {
            WriteErrorMessage("Input must contain exactly 4 arguments!");
            Console.WriteLine();
            continue;
        }

        var firstName = cmdArgs[0];
        var lastName = cmdArgs[1];
        if (!int.TryParse(cmdArgs[2], out var age))
        {
            WriteErrorMessage("Invalid age format!");
            Console.WriteLine();
            continue;
        }
        if (!decimal.TryParse(cmdArgs[3], out var salary))
        {
            WriteErrorMessage("Invalid salary format!");
            Console.WriteLine();
            continue;
        }

        var person = new Person(firstName, lastName, age, salary);

        persons.Add(person);
    }
    catch (ArgumentException ex)
    {
        WriteErrorMessage(ex.Message);
        Console.WriteLine();
        continue;
    }
    catch (Exception ex)
    {
        WriteErrorMessage($"An unexpected error has occured: {ex.Message}");
        Console.WriteLine();
        continue;
    }
}

persons
    .OrderBy(p => p.FirstName)
    .ThenBy(p => p.Age)
    .ToList()
    .ForEach(p =>
    {
        p.IncreaseSalary(bonus);
        WriteInfoMessage(p.ToString());
        Console.WriteLine();
    });

static decimal ReadBonusPercentage()
{
    var bonusInput = string.Empty;
    var bonus = 0.00m;

    do
    {
        Console.Write("Please enter the bonus percentage: ");
        bonusInput = Console.ReadLine();
    }
    while (decimal.TryParse(bonusInput, out bonus) == false || !(bonus >= 0.00m && bonus <= 100.00m));

    return bonus;
}

static void WriteWelcomeInfo()
{
    Console.WriteLine($" ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄ \r\n▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌\r\n▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░▌░▌     ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌\r\n▐░▌       ▐░▌▐░▌          ▐░▌       ▐░▌▐░▌          ▐░▌       ▐░▌▐░▌▐░▌    ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌\r\n▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░▌       ▐░▌▐░▌ ▐░▌   ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌\r\n▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌  ▐░▌  ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌\r\n▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀█░█▀▀  ▀▀▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌▐░▌   ▐░▌ ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ \r\n▐░▌          ▐░▌          ▐░▌     ▐░▌            ▐░▌▐░▌       ▐░▌▐░▌    ▐░▌▐░▌▐░▌       ▐░▌▐░▌          ▐░▌          \r\n▐░▌          ▐░█▄▄▄▄▄▄▄▄▄ ▐░▌      ▐░▌  ▄▄▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░▌     ▐░▐░▌▐░▌       ▐░▌▐░▌          ▐░▌          \r\n▐░▌          ▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌      ▐░░▌▐░▌       ▐░▌▐░▌          ▐░▌          \r\n ▀            ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀  ▀         ▀  ▀            ▀           \r\n                                                                                                                     ");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Welcome to the PersonApp!");
    Console.WriteLine();
}

static void WriteAddPersonInfo()
{
    Console.WriteLine("Enter first name, last name, age and salary separated by spaces. Enter blank line to exit.");
    Console.WriteLine("Ex. John Doe 30 50000.0");
    Console.WriteLine();
}

static void WriteInfoMessage(string message)
{
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(message);
    Console.ResetColor();
}

static void WriteErrorMessage(string message)
{
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(message);
    Console.ResetColor();
}