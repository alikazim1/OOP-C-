// Program.cs
using Atmosphere;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the input filename:");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);
        int n = int.Parse(lines[0]);

        AtmosphereSimulator simulator = new AtmosphereSimulator();

        for (int i = 1; i <= n; i++)
        {
            string[] attributes = lines[i].Split(' ');
            string type = attributes[0];
            double thickness = double.Parse(attributes[1]);

            GasLayer layer;
            if (type == "Z")
                layer = new OzoneLayer();
            else if (type == "X")
                layer = new OxygenLayer();
            else if (type == "C")
                layer = new CarbonDioxideLayer();
            else
                throw new ArgumentException("Invalid layer type");

            layer.Thickness = thickness;
            simulator.AddLayer(layer);
        }

        string atmosphericVariables = lines[n + 1];
        simulator.Simulate(atmosphericVariables);

        Console.WriteLine("Simulation ended. Gas component perished.");
        Console.ReadLine();
    }
}
