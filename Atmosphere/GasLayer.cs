using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atmosphere
{
    // GasLayer.cs
    public abstract class GasLayer
    {
        protected double thickness;

        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public abstract void ReactToThunderstorm();
        public abstract void ReactToSunshine();
        public abstract void ReactToOtherEffects();
    }

    // OzoneLayer.cs
    public class OzoneLayer : GasLayer
    {
        public override void ReactToThunderstorm()
        {
            // No reaction to thunderstorm for ozone layer
        }

        public override void ReactToSunshine()
        {
            // No reaction to sunshine for ozone layer
        }

        public override void ReactToOtherEffects()
        {
            thickness -= (thickness * 0.05); // 5% turns to oxygen
        }
    }

    // OxygenLayer.cs
    public class OxygenLayer : GasLayer
    {
        public override void ReactToThunderstorm()
        {
            thickness += (thickness * 0.5); // 50% turns to ozone
        }

        public override void ReactToSunshine()
        {
            thickness += (thickness * 0.05); // 5% turns to ozone
        }

        public override void ReactToOtherEffects()
        {
            thickness += (thickness * 0.1); // 10% turns to carbon dioxide
        }
    }

    // CarbonDioxideLayer.cs
    public class CarbonDioxideLayer : GasLayer
    {
        public override void ReactToThunderstorm()
        {
            // No reaction to thunderstorm for carbon dioxide layer
        }

        public override void ReactToSunshine()
        {
            thickness -= (thickness * 0.05); // 5% turns to oxygen
        }

        public override void ReactToOtherEffects()
        {
            // No reaction to other effects for carbon dioxide layer
        }
    }

    // AtmosphereSimulator.cs
    public class AtmosphereSimulator
    {
        private List<GasLayer> layers;

        public AtmosphereSimulator()
        {
            layers = new List<GasLayer>();
        }

        public void AddLayer(GasLayer layer)
        {
            layers.Add(layer);
        }

        public void Simulate(string atmosphericVariables)
        {
            int rounds = 0;

            while (!CheckForPerishedLayer())
            {
                Console.WriteLine($"Simulation Round: {++rounds}");
                PrintLayers();

                foreach (char variable in atmosphericVariables)
                {
                    foreach (GasLayer layer in layers)
                    {
                        switch (variable)
                        {
                            case 'T': // Thunderstorm
                                layer.ReactToThunderstorm();
                                break;
                            case 'S': // Sunshine
                                layer.ReactToSunshine();
                                break;
                            case 'O': // Other Effects
                                layer.ReactToOtherEffects();
                                break;
                        }
                    }

                    // Ascend or create new layers based on reactions
                    AscendLayers();
                }
            }
        }

        private bool CheckForPerishedLayer()
        {
            foreach (GasLayer layer in layers)
            {
                if (layer.Thickness <= 0.5)
                {
                    layers.Remove(layer);
                    return true;
                }
            }

            return false;
        }

        private void AscendLayers()
        {
            for (int i = layers.Count - 2; i >= 0; i--)
            {
                if (layers[i].GetType() == layers[i + 1].GetType())
                {
                    layers[i].Thickness += layers[i + 1].Thickness;
                    layers.RemoveAt(i + 1);
                }
                else
                {
                    break;
                }
            }
        }

        private void PrintLayers()
        {
            foreach (GasLayer layer in layers)
            {
                Console.WriteLine($"Type: {layer.GetType().Name}, Thickness: {layer.Thickness}");
            }
            Console.WriteLine();
        }

        internal static bool CheckForPerishedLayer(List<GasLayer> gasLayers)
        {
            throw new NotImplementedException();
        }

        internal static void AscendLayers(List<GasLayer> gasLayers)
        {
            throw new NotImplementedException();
        }
    }
}