Console.BackgroundColor = ConsoleColor.Blue;
Console.ForegroundColor = ConsoleColor.White;
Console.Clear();
Console.WriteLine("[[ Simple 2 values calculator " + ((char)0169).ToString() + " ]]\n");
Console.Write("Type the first value: ");
string value1 = onlyNumbers();
Console.Write("Type the second value: ");
string value2 = onlyNumbers();
Console.Write("Choose the operation type (+, -, * or /): ");
string operatorSign = onlyOperators();
Console.ForegroundColor = ConsoleColor.Green;
Console.Write("Result: ");
string totalCalculated = doCalculations(value1, value2, operatorSign);
resetConsole(false);

/*=====================================================================
Function that filters text input only for numbers and decimal places. =
It also allows the use of backspace to erase typos.                   =
Prints the entered number on the screen.                              =
Returns a string containing the number entered.                       =
=====================================================================*/
static string onlyNumbers()
{
    double value = 0;
    string number = "0";
    ConsoleKeyInfo cki;
    do
    {
        cki = Console.ReadKey(true);
        if (cki.Key != ConsoleKey.Backspace)
        {
            if ((cki.Key == ConsoleKey.OemPeriod || cki.Key == ConsoleKey.OemComma) && !number.Contains(".") && float.Parse(number) == 0)
            {
                number += ".";
                Console.Write(".");
            }
            else
            {
                bool control = double.TryParse(cki.KeyChar.ToString(), out value);
                if (control)
                {
                    number += cki.KeyChar;
                    Console.Write(cki.KeyChar);
                }
            }
        }
        else
        {
            if (cki.Key == ConsoleKey.Backspace && number.Length > 0)
            {
                number = number.Substring(0, (number.Length - 1));
                Console.Write("\b \b");
            }
        }
    }
    while (cki.Key != ConsoleKey.Enter);
    if (number.Length == 0)
    {
        number = "0";
    }
    if (float.Parse(number) <= 0)
    {
        Console.WriteLine("You must enter a number. End of program!");
        resetConsole(true);
    }
    Console.Write("\n");
    return number;
}

/*====================================================================
Function that filters text input only for allowed operation signals. =
Prints the chosen operator on the screen.                            =
Returns a string containing the chosen operator.                     =
====================================================================*/
static string onlyOperators()
{
    string operatorSelected = "";
    ConsoleKeyInfo cki;
    do
    {
        cki = Console.ReadKey(true);
        if (cki.Key == ConsoleKey.Add || cki.Key == ConsoleKey.OemPlus || cki.Key == ConsoleKey.Subtract || cki.Key == ConsoleKey.OemMinus || cki.Key == ConsoleKey.Multiply || cki.Key == ConsoleKey.Divide)
        {
            operatorSelected = cki.Key.ToString();
            switch (operatorSelected)
            {
                case "Add": operatorSelected = "+"; break;
                case "OemPlus": operatorSelected = "+"; break;
                case "Subtract": operatorSelected = "-"; break;
                case "OemMinus": operatorSelected = "-"; break;
                case "Multiply": operatorSelected = "*"; break;
                case "Divide": operatorSelected = "/"; break;
                default: Console.Write("ERROR!!!"); System.Environment.Exit(1); break;
            }
        }
    } while (operatorSelected == "");
    Console.WriteLine(operatorSelected);
    return operatorSelected;
}

/*=======================================================================================================
Function that resets the console to its default color and clears the screen after the program finishes. =
=======================================================================================================*/
static void resetConsole(bool error)
{
    if (error == true)
    {
        Console.WriteLine("Press any key to exit...");
    }
    Console.ReadKey();
    Console.ResetColor();
    Console.Clear();
    System.Environment.Exit(1);
}

/*=======================================================================================================================
Function that receives the values entered previously and the operation sign and performs the corresponding calculation. =
Returns the calculated value.                                                                                           =
=======================================================================================================================*/
static string doCalculations(string value1, string value2, string operatorSign)
{
    string totalCalculation = "";
    switch (operatorSign)
    {
        case "+": totalCalculation = (float.Parse(value1) + float.Parse(value2)).ToString(); break;
        case "-": totalCalculation = (float.Parse(value1) - float.Parse(value2)).ToString(); break;
        case "*": totalCalculation = (float.Parse(value1) * float.Parse(value2)).ToString(); break;
        case "/": totalCalculation = (float.Parse(value1) / float.Parse(value2)).ToString(); break;
        default: Console.WriteLine("ERROR!!!"); break;
    }
    Console.WriteLine(totalCalculation);
    return totalCalculation;
}



// ConsoleKeyInfo cki;
// // Prevent example from ending if CTL+C is pressed.
// Console.TreatControlCAsInput = true;
// do
// {
//     cki = Console.ReadKey();
//     //    if (cki.Key == ConsoleKey. 1) Console.Write(cki.Key.ToString());
//     // Console.Write(cki.Key.ToString());
//     // Console.WriteLine(Console.CursorLeft);
//     // if (cki.Key == ConsoleKey.D1)
//     // {
//     // }
//     // else
//     // {
//     //     Console.Write("\b");
//     // }


// } while (cki.Key != ConsoleKey.Enter);





// class Example
// {
//     public static void Main()
//     {
//         ConsoleKeyInfo cki;
//         // Prevent example from ending if CTL+C is pressed.
//         Console.TreatControlCAsInput = true;

//         Console.WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.");
//         Console.WriteLine("Press the Escape (Esc) key to quit: \n");
//         do
//         {
//             cki = Console.ReadKey();
//             Console.Write(" --- You pressed ");
//             if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
//             if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
//             if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
//             Console.WriteLine(cki.Key.ToString());
//         } while (cki.Key != ConsoleKey.Escape);
//     }
// }
// This example displays output similar to the following:
//       Press any combination of CTL, ALT, and SHIFT, and a console key.
//       Press the Escape (Esc) key to quit:
//
//       a --- You pressed A
//       k --- You pressed ALT+K
//       ► --- You pressed CTL+P
//         --- You pressed RightArrow
//       R --- You pressed SHIFT+R
//                --- You pressed CTL+I
//       j --- You pressed ALT+J
//       O --- You pressed SHIFT+O
//       § --- You pressed CTL+U







// Console.WriteLine("'{0}' --> {1}", 1, 2);


//    float resultado = float.Parse(value1) + float.Parse(value2);
//    Console.WriteLine(resultado.ToString());
