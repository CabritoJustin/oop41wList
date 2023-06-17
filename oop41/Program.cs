using System;
using System.Collections.Generic;

// Justin Rafael Cabrito
// Unit Converter 
class UnitConverter
{
    static void Main()
    {
        Console.WriteLine("Unit Converter");
        Console.WriteLine();

        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to my unit converter");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Please select the conversion type:");
            Console.WriteLine("1. Length Converter");
            Console.WriteLine("2. Volume Converter");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice (1-3): ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 3.");
                continue;
            }

            if (choice == 3)
            {
                exitProgram = true;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Thank you for using this unit converter!!");
                Console.ResetColor();
                continue;
            }

            switch (choice)
            {
                case 1:
                    ConvertLength();
                    break;
                case 2:
                    ConvertVolume();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 3.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void ConvertLength()
    {
        Console.WriteLine("Length Converter");
        Console.WriteLine("----------------");

        List<UnitConversion> conversions = new List<UnitConversion>
        {
            new UnitConversion("Meters", "Feet", meters => meters * 3.28084),
            new UnitConversion("Feet", "Meters", feet => feet / 3.28084),
            new UnitConversion("Kilometers", "Miles", kilometers => kilometers * 0.621371),
            new UnitConversion("Miles", "Kilometers", miles => miles / 0.621371),
            new UnitConversion("Inches", "Centimeters", inches => inches * 2.54),
            new UnitConversion("Centimeters", "Inches", centimeters => centimeters / 2.54),
            new UnitConversion("Yards", "Meters", yards => yards * 0.9144),
            new UnitConversion("Meters", "Yards", meters => meters / 0.9144)
        };

        bool exitConverter = false;

        while (!exitConverter)
        {
            Console.WriteLine("Select the conversion type:");
            for (int i = 0; i < conversions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {conversions[i].FromUnit} to {conversions[i].ToUnit}");
            }
            Console.WriteLine($"{conversions.Count + 1}. Back to Main Menu");

            Console.Write("Enter your choice (1-{0}): ", conversions.Count + 1);
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine($"Invalid choice. Please enter a number from 1 to {conversions.Count + 1}.");
                continue;
            }

            if (choice == conversions.Count + 1)
            {
                exitConverter = true;
                Console.WriteLine("Returning to the main menu.");
                continue;
            }

            if (choice < 1 || choice > conversions.Count)
            {
                Console.WriteLine($"Invalid choice. Please enter a number from 1 to {conversions.Count + 1}.");
                continue;
            }

            double length;
            Console.Write("Enter the length value: ");
            if (!double.TryParse(Console.ReadLine(), out length))
            {
                Console.WriteLine("Invalid length value. Please enter a valid number.");
                continue;
            }

            UnitConversion selectedConversion = conversions[choice - 1];
            double convertedValue = selectedConversion.ConversionFunc(length);

            Console.WriteLine($"{length} {selectedConversion.FromUnit} is equal to {convertedValue} {selectedConversion.ToUnit}.");
            Console.WriteLine();
        }
    }

    static void ConvertVolume()
    {
        Console.WriteLine("Volume Converter");
        Console.WriteLine("----------------");

        List<UnitConversion> conversions = new List<UnitConversion>
        {
            new UnitConversion("Liters", "Gallons", liters => liters * 0.264172),
            new UnitConversion("Gallons", "Liters", gallons => gallons / 0.264172),
            new UnitConversion("Cubic Meters", "Cubic Feet", cubicMeters => cubicMeters * 35.3147),
            new UnitConversion("Cubic Feet", "Cubic Meters", cubicFeet => cubicFeet / 35.3147)
        };

        bool exitConverter = false;

        while (!exitConverter)
        {
            Console.WriteLine("Select the conversion type:");
            for (int i = 0; i < conversions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {conversions[i].FromUnit} to {conversions[i].ToUnit}");
            }
            Console.WriteLine($"{conversions.Count + 1}. Back to Main Menu");

            Console.Write("Enter your choice (1-{0}): ", conversions.Count + 1);
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine($"Invalid choice. Please enter a number from 1 to {conversions.Count + 1}.");
                continue;
            }

            if (choice == conversions.Count + 1)
            {
                exitConverter = true;
                Console.WriteLine("Returning to the main menu.");
                continue;
            }

            if (choice < 1 || choice > conversions.Count)
            {
                Console.WriteLine($"Invalid choice. Please enter a number from 1 to {conversions.Count + 1}.");
                continue;
            }

            double volume;
            Console.Write("Enter the volume value: ");
            if (!double.TryParse(Console.ReadLine(), out volume))
            {
                Console.WriteLine("Invalid volume value. Please enter a valid number.");
                continue;
            }

            UnitConversion selectedConversion = conversions[choice - 1];
            double convertedValue = selectedConversion.ConversionFunc(volume);

            Console.WriteLine($"{volume} {selectedConversion.FromUnit} is equal to {convertedValue} {selectedConversion.ToUnit}.");
            Console.WriteLine();
        }
    }
}

// Class to represent a unit conversion
class UnitConversion
{
    public string FromUnit { get; }
    public string ToUnit { get; }
    public Func<double, double> ConversionFunc { get; }

    public UnitConversion(string fromUnit, string toUnit, Func<double, double> conversionFunc)
    {
        FromUnit = fromUnit;
        ToUnit = toUnit;
        ConversionFunc = conversionFunc;
    }
}