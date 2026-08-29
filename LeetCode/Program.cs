// See https://aka.ms/new-console-template for more information

using System;
using System.Reflection;
using System.Linq;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using CSnakes.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Eventing.Reader;
using System.IO.Pipelines;
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;

var builder = Host.CreateApplicationBuilder(args);
var home = Path.Join(Environment.CurrentDirectory, ".");

builder.Services
    .WithPython()
    .WithHome(home)
    .FromRedistributable(); 

var app = builder.Build();
var env = app.Services.GetRequiredService<IPythonEnvironment>();

// Get the Python module
var pySolutions = env.LeetCodeSolutions();
var pythonSetup = env.PythonSetup();

Console.WriteLine("\n<>--Zach's LeetCode Tester---<>");
Console.WriteLine("\nMade with love by Zach Lima.");
Console.WriteLine("08/27/26");
Console.WriteLine("Made with C#, Python, CSnakes, and a love for Punk Rock.");
Console.WriteLine("It's all for you, Miss Universe.");
Console.WriteLine("\n<>---------------------------<>\n");

LeetCodeSolutions attempt = new LeetCodeSolutions();
Type attemptType = attempt.GetType();

MethodInfo[] rawMethodList = attemptType.GetMethods( 
    BindingFlags.Public | 
    BindingFlags.Instance | 
    BindingFlags.DeclaredOnly);


string[] methodNameList = rawMethodList.Select(method => method.Name).ToArray();
string methodNameListAsString = string.Join(", ",methodNameList);

string pythonMethodNameListAsString = pythonSetup.GetPythonFunctions();


while (true)
{
    Console.WriteLine("Enter the name of the question you'd like to try,");
    Console.Write("enter @list for the list of methods, or @exit to leave: ");
    string question = Console.ReadLine();

    MethodInfo methodExists = attemptType.GetMethod(question, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
    if (question.StartsWith("py", StringComparison.CurrentCultureIgnoreCase) && 
    pythonMethodNameListAsString.Contains(question, StringComparison.CurrentCultureIgnoreCase))
    {
        //Get Proper function name
        string pattern = $@"\b[a-zA-Z0-9_]*{Regex.Escape(question)}[a-zA-Z0-9_]*\b";
        Match match = Regex.Match(pythonMethodNameListAsString, pattern, RegexOptions.IgnoreCase);
        if (match.Success)
        {
            string properFunctionName = match.Value; 
            //RUN METHOD WITH PYTHON
            Console.WriteLine("\nSweet, let's give it a shot.\n");
            Console.WriteLine("Now Running: " + properFunctionName +"..." +" With Python!");
            Console.WriteLine("<>--------------------------<>\n");
            var answer = pythonSetup.RunPythonFunction(properFunctionName);
            Console.WriteLine(answer);
            Console.WriteLine("\n<>---------------------------<>");
            Console.WriteLine("\nIf you'd like to try another,");
        }
        else
        {
            Console.WriteLine("\n[ERROR!] Function should exist but doesn't. Contact the developer.");
            break;
        }

    }
    else if (question == "@list")
    {
        Console.WriteLine("\nCheck it, here's the list of available methods: \n");
        Console.WriteLine("C#: "+methodNameListAsString + "\n" + "Python: "+pythonMethodNameListAsString + "\n");
        Console.WriteLine("When you're ready,");
    }
    else if (question == "@exit")
    {
        Console.WriteLine("\nSee you later! Thank you for using this :D");
        break;
    }
    else if (methodExists != null)
    {
        //TEST IT!
        Console.WriteLine("\nSweet, let's give it a shot.\n");
        Console.WriteLine("Now Running: " + methodExists.Name +"..."+" With C#!");
        object[] parameters = GetDefaultParameters(methodExists);
        object rawResult  = methodExists.Invoke(attempt, parameters);
        Console.WriteLine("<>---------------------------<>\n");
        PrintOutputBasedOnResultType(rawResult);
        Console.WriteLine("\n<>---------------------------<>");

        Console.WriteLine("\nIf you'd like to try another,");
    }
    else
    {

        Console.WriteLine("\n[ERROR!] Nope, sorry, that one doesn't exist yet. Try again.\n");
    }
}

object[] GetDefaultParameters(MethodInfo method)
{
    //if I ever want to make it so I can request specific params in the command line
    //ParameterInfo[] requiredParams = method.GetParameters();
    object[] parametersToPass;
    switch (method.Name)
    {
        default:
            parametersToPass = null;
            break;
        case "TwoSumBruteForce":
            parametersToPass = [new int[] { 4, 1, 6, 8 }, 7];
            break;
        case "TwoSum":
            parametersToPass = [new int[] { 4, 1, 6, 8 }, 7];
            break;
        case "AddTwoNumbers":
            ListNode l11 = new ListNode();
            ListNode l12 = new ListNode();
            ListNode l13 = new ListNode();
            ListNode l21 = new ListNode();
            ListNode l22 = new ListNode();
            ListNode l23 = new ListNode();

            l11.next = l12;
            l12.next = l13;

            l11.val = 2;
            l12.val = 4;
            l13.val = 3;

            l21.val = 5;
            l22.val = 6;
            l23.val = 4;

            l21.next = l22;
            l22.next = l23;

            parametersToPass = [l11,l21];
            break;
        case "AddTwoNumbersMod":
            ListNode l11b = new ListNode();
            ListNode l12b = new ListNode();
            ListNode l13b = new ListNode();
            ListNode l21b = new ListNode();
            ListNode l22b = new ListNode();
            ListNode l23b = new ListNode();

            l11b.next = l12b;
            l12b.next = l13b;

            l11b.val = 2;
            l12b.val = 4;
            l13b.val = 3;

            l21b.val = 5;
            l22b.val = 6;
            l23b.val = 4;

            l21b.next = l22b;
            l22b.next = l23b;

            parametersToPass = [l11b,l21b];
            parametersToPass = [l11b,l21b];
            break;
    }
    return parametersToPass;
}

void PrintOutputBasedOnResultType(object result)
{
    if (result is int[] resultArr)
    {
        Console.WriteLine($"(int[]) Output: [{string.Join(", ",resultArr)}]");
    }
    else if (result is null)
    {
        Console.WriteLine("The method returned NULL.");
    }
    else if (result is ListNode startNode)
    {
        List<int> listNodeArray = new List<int>();
        while (startNode !=null)
        {
            listNodeArray.Add(startNode.val);
            startNode = startNode.next;
        }

        string finalString = $"(ListNode) Output: [{string.Join(", ",listNodeArray)}]";
        Console.WriteLine(finalString);
    }
}

 public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) 
        {
            this.val = val;
            this.next = next;
        }
    }



