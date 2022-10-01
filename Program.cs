// See https://aka.ms/new-console-template for more information
using CommandLineTool;
using microsoft.cli;

Console.WriteLine("Hello, World!");
Cli cli = new(typeof(MyCli))
{
    Introduction = "my intro",
    PromptText = "CLI"
};
//optional: set list of keys to exit from the command loop
cli.SetCancellationKeys(new() { "exit" });
cli.Start();
