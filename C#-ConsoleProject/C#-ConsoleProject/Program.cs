using C__ConsoleProject.Controllers;
using Service.Enums;
using Service.Helpers.Extensions;
using Spectre.Console;
AnsiConsole.Write(
    new FigletText("C# mini-project")
        .LeftJustified()
        .Color(Color.LightGoldenrod2_2));

AccountController accountController = new AccountController();
GroupController groupController = new GroupController();
StudentController studentController = new StudentController();

//while (true)
//{
//    Console.WriteLine("Choose one option : 1-Login or 2-Register");
//    string operationStr = Console.ReadLine();
//    bool isFormatOperation = int.TryParse(operationStr, out int operation);


//    switch (operation)
//    {
//        case (int)AccountOperationTypes.Register:
//            accountController.Register();
//            break;


//        case (int)AccountOperationTypes.Login:
//            accountController.Login();
//            goto Menu;

//        default:ConsoleColor.Red.WriteConsole("Invalid operation,please enter the correct operation");
//            break;
//    }

//}


Menu: ConsoleColor.Green.WriteConsole("Welcome our application");

while (true)
{
    GetMenues();
    Console.WriteLine("Choose one option : ");
    Operation: string opStr = Console.ReadLine();
    bool isFormatOperation = int.TryParse(opStr, out int operation);

    switch (operation)
    {
        case (int)OperationTypes.GroupCreate:
            groupController.Create();
            break;
        case (int)OperationTypes.GroupDelete:
            groupController.Delete();
            break;
        case (int)OperationTypes.GroupEdit:
            groupController.Edit();
            break;
        case (int)OperationTypes.GroupGetById:
            groupController.GetById();
            break;
        case (int)OperationTypes.GroupGetAll:
            groupController.GetAll();
            break;
        case (int)OperationTypes.GroupSearch:
            groupController.Search();
            break;
        case (int)OperationTypes.GroupSorting:
            groupController.Sort();
            break;
        case (int)OperationTypes.StudentCreate:
            studentController.Create();
            break;
        case (int)OperationTypes.StudentDelete:
            studentController.Delete();
            break;
        case (int)OperationTypes.StudentEdit:
            studentController.Edit();
            break;
        case (int)OperationTypes.StudentGetById:
            studentController.GetById();
            break;
        case (int)OperationTypes.StudentGetAll:
            studentController.GetAll();
            break;
        case (int)OperationTypes.StudentFilter:
            studentController.Sorting();
            break;
        case (int)OperationTypes.StudentSearch:
            studentController.Search();
            break;


        default:
            Console.WriteLine("Invalid operation,please enter the correct operation");
            goto Operation;
    }
}

static void GetMenues()
{
    
    Console.WriteLine("\nPlease select one option:\nGroup operations:\n1-Create,\n2-Delete,\n3-Edit,\n4-GetById,\n5-GetAll,\n6-Search,\n7-Sorting\n~~~~~~~~~~~~~~~~~~~~~~~~~~~\nStudent operations:\n8-Create,\n9-Delete,\n10-Edit,\n11-GetById,\n12-GetAll,\n13-Filter,\n14-Search");
}


