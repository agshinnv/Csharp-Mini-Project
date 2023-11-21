using Service.Helpers.Extensions;
using Spectre.Console;
AnsiConsole.Write(
    new FigletText("Welcome our Application")
        .LeftJustified()
        .Color(Color.LightGoldenrod2_2));


static void GetMenues()
{
    ConsoleColor.Magenta.WriteConsole("Please select one option: Group operations: <1> Create, <2> Delete, <3> Edit, <4> GetById, <5> GetAll, <6> Search, <7> Sorting | Student operations : 8-Create, 9-Delete, 10-Edit, 11-GetById, 12-GetAll,13-Filter, 14-Search");
}

