using C__ConsoleProject.Controllers;
using Service.Enums;
using Service.Helpers.Extensions;
using Spectre.Console;
AnsiConsole.Write(
    new FigletText("Welcome our Application")
        .LeftJustified()
        .Color(Color.LightGoldenrod2_2));

AccountController AccountController = new AccountController();
GroupController groupController = new GroupController();

while (true)
{
    Console.WriteLine("Choose one option : 1-Login or 2-Register");
    string operationStr = Console.ReadLine();
    bool isFormatOperation = int.TryParse(operationStr, out int operation);   
        
    
    switch (operation)
    {
        case (int)AccountOperationTypes.Register:
            AccountController.Register();
            break;


        case (int)AccountOperationTypes.Login:
           AccountController.Login();
            break;

        default:
            break;
    }

   
}





static void GetMenues()
{
    ConsoleColor.Magenta.WriteConsole("Please select one option: Group operations: <1> Create, <2> Delete, <3> Edit, <4> GetById, <5> GetAll, <6> Search, <7> Sorting | Student operations : 8-Create, 9-Delete, 10-Edit, 11-GetById, 12-GetAll,13-Filter, 14-Search");
}

