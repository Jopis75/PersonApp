using PersonClassLibrary;

WriteWelcomeScreen();

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
            continue;
        }

        var firstName = cmdArgs[0];
        var lastName = cmdArgs[1];
        if (!int.TryParse(cmdArgs[2], out var age))
        {
            WriteErrorMessage("Invalid age format!");
            continue;
        }
        if (!decimal.TryParse(cmdArgs[3], out var salary))
        {
            WriteErrorMessage("Invalid salary format!");
            continue;
        }

        var person = new Person(firstName, lastName, age, salary);

        persons.Add(person);
    }
    catch (ArgumentException ex)
    {
        WriteErrorMessage(ex.Message);
        continue;
    }
    catch (Exception ex)
    {
        WriteErrorMessage($"Unexpected error: {ex.Message}");
        continue;
    }
}

persons
    .OrderBy(p => p.FirstName)
    .ThenBy(p => p.Age)
    .ToList()
    .ForEach(p => Console.WriteLine(p.ToString()));



static void WriteWelcomeScreen()
{
    Console.WriteLine($" ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄ \r\n▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌\r\n▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░▌░▌     ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌\r\n▐░▌       ▐░▌▐░▌          ▐░▌       ▐░▌▐░▌          ▐░▌       ▐░▌▐░▌▐░▌    ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌▐░▌       ▐░▌\r\n▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░▌       ▐░▌▐░▌ ▐░▌   ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌\r\n▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░▌  ▐░▌  ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌\r\n▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀█░█▀▀  ▀▀▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌▐░▌   ▐░▌ ▐░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀ \r\n▐░▌          ▐░▌          ▐░▌     ▐░▌            ▐░▌▐░▌       ▐░▌▐░▌    ▐░▌▐░▌▐░▌       ▐░▌▐░▌          ▐░▌          \r\n▐░▌          ▐░█▄▄▄▄▄▄▄▄▄ ▐░▌      ▐░▌  ▄▄▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░▌     ▐░▐░▌▐░▌       ▐░▌▐░▌          ▐░▌          \r\n▐░▌          ▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌      ▐░░▌▐░▌       ▐░▌▐░▌          ▐░▌          \r\n ▀            ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀  ▀         ▀  ▀            ▀           \r\n                                                                                                                     ");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Welcome to the PersonApp!");
    Console.WriteLine();
    Console.WriteLine("Enter first name, last name, age and salary separated by spaces. Enter blank line to exit.");
    Console.WriteLine("Ex. John Doe 30 50000.0");
    Console.WriteLine();
}

static void WriteErrorMessage(string message)
{
    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(message);
    Console.ResetColor();
    Console.WriteLine();
}