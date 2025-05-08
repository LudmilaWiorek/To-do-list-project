using System.Threading.Channels;

Console.WriteLine("Hello, C#!");
void MainMenu()
{
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
void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}
void PrintAllToDo()
{
    if (mainList.Count > 0)
    {
        Console.WriteLine("Here is what you have on your main List: ");
        for (var i = 0; i < mainList.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + mainList[i]);
        }
    }
    else if (mainList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
    }
}
void AddToDo()
{
    bool isValidDescription = false;
    while (!isValidDescription)
    {
        Console.WriteLine("Enter the TODO description:");
        string enteredDescription = Console.ReadLine();

        if (enteredDescription == "")
        {
            Console.WriteLine("The description cannot be empty.");
        }
        else if (mainList.Contains(enteredDescription))
        {
            Console.WriteLine("The description must be unique.");
        }
        else
        {
            isValidDescription = true;
            mainList.Add(enteredDescription);
            Console.WriteLine("TODO successfully added: " + enteredDescription);
        }
    }
}
void RemoveToDo()
{
    if (mainList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
        return;
    }
    Console.WriteLine("Select the index of the TODO you want to remove:");
    string enteredIndex = Console.ReadLine();

    // musimy sprawdzić czy user wprowdzil liczbe w inpucie
    int index;
    if (int.TryParse(enteredIndex, out index))
    {
        if (index > mainList.Count || index <= 0)
        {
            Console.WriteLine("The given index is not valid.");
            RemoveToDo();
        }
        else if (index <= mainList.Count)
        {
            Console.WriteLine("User input is correct, can proceed with removing from list");
            Console.WriteLine($"TODO removed: {index}. {mainList[index - 1]}");
            mainList.RemoveAt(index - 1);
        }
    }
    else if (enteredIndex == "")
    {
        Console.WriteLine("Selected index cannot be empty.");
        RemoveToDo();
    }
    else
    {
        Console.WriteLine("The given index is not valid.");
        RemoveToDo();
    }
}
