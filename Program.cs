using System.Threading.Channels;

Console.WriteLine("Hello, C#!");
void MainMenu()
{
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs!");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    var userChoice = Console.ReadLine();
    userChoice = userChoice.ToUpper();

    switch (userChoice)
    {
        case "S":
            PrintSelectedOption("See all TODOs");
            PrintAllToDo();
            MainMenu();
            break;
        case "A":
            PrintSelectedOption("Add a TODO");
            AddToDo();
            MainMenu();
            break;
        case "R":
            PrintSelectedOption("Remove a TODO");
            RemoveToDo();
            MainMenu();
            break;
        case "E":
            PrintSelectedOption("Exit");
            break;
        default:
            Console.WriteLine("Invalid choice. Please input s, a, r or e");
            MainMenu();
            break;
    }
}
var mainList = new List<string> { };
MainMenu();

void PrintAllToDo()
{
    if (mainList.Count == 0)
    {
        ShowNoToDoMessage();
        return;
    }

    Console.WriteLine("Here is what you have on your main List: ");
    for (var i = 0; i < mainList.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + mainList[i]);
    }
}
void AddToDo() // high-level method
{
    //bool isValidDescription = false;
    string enteredDescription;
    do
    {
        {
            Console.WriteLine("Enter the TODO description:");
            enteredDescription = Console.ReadLine();
        }
    } while (!IsDescriptionValid(enteredDescription));
    mainList.Add(enteredDescription);
    // A WIADOMOSC O DODANIU TODO?
}
void RemoveToDo()
{
    if (mainList.Count == 0)
    {
        ShowNoToDoMessage();
        return;
    }
    int index;
    do
    {
        {
            Console.WriteLine("Select the index of the TODO you want to remove:");
            PrintAllToDo();
        } 
    } while (!TryReadIndex(out index));
        RemoveToDoAtIndex(index - 1);
}

// helper methods, less important, go in the end of file; more important methods go at the top
bool IsDescriptionValid(string enteredDescription) // low-lvl method
{
    if (enteredDescription == "") // first let's check program for exceptions (and throw that exception)
    {
        Console.WriteLine("The description cannot be empty.");
        return false;
    }
    if (mainList.Contains(enteredDescription))
    {
        Console.WriteLine("The description must be unique.");
        return false;
    }
    return true;
}
bool TryReadIndex(out int index)
{
    string enteredIndex = Console.ReadLine();
    if (enteredIndex == "")
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty.");
        return false;
    }
    // check if user provided number in input
    if (int.TryParse(enteredIndex, out index) &&
        index >= 1 &&
        index <= mainList.Count)
    {
        return true;
    }

    Console.WriteLine("The given index is not valid.");
    return false;
}
void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}
void ShowNoToDoMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}
void RemoveToDoAtIndex(int index)
{
    var todoToBeRemoved = mainList[index];
    mainList.RemoveAt(index);
    Console.WriteLine("TODO successfully removed: " + todoToBeRemoved);
}