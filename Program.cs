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
void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine("Selected option: " + selectedOption);
}
void PrintAllToDo()
{
    if (mainList.Count == 0)
    {
        Console.WriteLine("No TODOs have been added yet.");
    }
    else
    {
        Console.WriteLine("Here is what you have on your main List: ");
        for (var i = 0; i < mainList.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + mainList[i]);
        }
    }
}
void AddToDo()
{
    bool isValidDescription = false;
    while (!isValidDescription)
    {
        Console.WriteLine("Enter the TODO description:");
        string enteredDescription = Console.ReadLine();

        if (enteredDescription == "") // first let's check program for exceptions (and throw that exception)
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
    bool isIndexValid = false;
    while (!isIndexValid)
    { 
    Console.WriteLine("Select the index of the TODO you want to remove:");
        PrintAllToDo();
    string enteredIndex = Console.ReadLine();
         if (enteredIndex == "")
        {
            Console.WriteLine("Selected index cannot be empty.");
            continue;
        }
        // check if user provided number in input
    if (int.TryParse(enteredIndex, out int index) && index >= 1 && index <= mainList.Count)
    {
            var indexOfTodo = index - 1;
     var todoToBeRemoved = mainList[indexOfTodo];
            mainList.RemoveAt(indexOfTodo);
            isIndexValid = true;
            Console.WriteLine("TODO successfully removed: " + todoToBeRemoved);
        }
       else
    {
        Console.WriteLine("The given index is not valid.");
    }
}
}
