using NUnit.Framework;
using System.Collections.Generic;

namespace Atmosphere.Tests
{
    [TestFixture]
    public class GasLayerTests
    {
        private List<GasLayer> gasLayers;

        [SetUp]
        public void Setup()
        {
            gasLayers = new List<GasLayer>();
        }

        [Test]
        public void OzoneLayer_ReactToOtherEffects_Succeeds()
        {
            // Arrange
            OzoneLayer ozoneLayer = new OzoneLayer();
            ozoneLayer.Thickness = 5.0;
            double expectedThickness = 5.0 * 0.95; // 5% reduction

            // Act
            ozoneLayer.ReactToOtherEffects();

            // Assert
            Assert.AreEqual(expectedThickness, ozoneLayer.Thickness);
        }

        [Test]
        public void OxygenLayer_ReactToThunderstorm_Succeeds()
        {
            // Arrange
            OxygenLayer oxygenLayer = new OxygenLayer();
            oxygenLayer.Thickness = 2.0;
            double expectedThickness = 2.0 + (2.0 * 0.5); // 50% increase

            // Act
            oxygenLayer.ReactToThunderstorm();

            // Assert
            Assert.AreEqual(expectedThickness, oxygenLayer.Thickness);
        }

        [Test]
        public void OxygenLayer_ReactToSunshine_Succeeds()
        {
            // Arrange
            OxygenLayer oxygenLayer = new OxygenLayer();
            oxygenLayer.Thickness = 3.0;
            double expectedThickness = 3.0 + (3.0 * 0.05); // 5% increase

            // Act
            oxygenLayer.ReactToSunshine();

            // Assert
            Assert.AreEqual(expectedThickness, oxygenLayer.Thickness);
        }

        [Test]
        public void OxygenLayer_ReactToOtherEffects_Succeeds()
        {
            // Arrange
            OxygenLayer oxygenLayer = new OxygenLayer();
            oxygenLayer.Thickness = 4.0;
            double expectedThickness = 4.0 + (4.0 * 0.1); // 10% increase

            // Act
            oxygenLayer.ReactToOtherEffects();

            // Assert
            Assert.AreEqual(expectedThickness, oxygenLayer.Thickness);
        }

        [Test]
        public void CarbonDioxideLayer_ReactToSunshine_Succeeds()
        {
            // Arrange
            CarbonDioxideLayer carbonDioxideLayer = new CarbonDioxideLayer();
            carbonDioxideLayer.Thickness = 5.0;
            double expectedThickness = 5.0 * 0.95; // 5% reduction

            // Act
            carbonDioxideLayer.ReactToSunshine();

            // Assert
            Assert.AreEqual(expectedThickness, carbonDioxideLayer.Thickness);
        }

        [Test]
        public void AscendLayers_Succeeds()
        {
            // Arrange
            GasLayer layer1 = new OxygenLayer();
            layer1.Thickness = 2.0;
            GasLayer layer2 = new OxygenLayer();
            layer2.Thickness = 3.0;
            GasLayer layer3 = new OzoneLayer();
            layer3.Thickness = 1.5;
            GasLayer layer4 = new OxygenLayer();
            layer4.Thickness = 4.0;

            gasLayers.Add(layer1);
            gasLayers.Add(layer2);
            gasLayers.Add(layer3);
            gasLayers.Add(layer4);

            // Act
            AtmosphereSimulator.AscendLayers(gasLayers);

            // Assert
            Assert.AreEqual(2, gasLayers.Count);
            Assert.AreEqual(5.0, gasLayers[0].Thickness);
            Assert.AreEqual(7.0, gasLayers[1].Thickness);
        }

        [Test]
        public void CheckForPerishedLayer_True_Succeeds()
        {
            // Arrange
            GasLayer layer1 = new OxygenLayer();
            layer1.Thickness = 0.4;
            GasLayer layer2 = new OzoneLayer();
            layer2.Thickness = 0.8;
            GasLayer layer3 = new CarbonDioxideLayer();
            layer3.Thickness = 1.2;

            gasLayers.Add(layer1);
            gasLayers.Add(layer2);
            gasLayers.Add(layer3);

            // Act
            bool result = AtmosphereSimulator.CheckForPerishedLayer(gasLayers);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckForPerishedLayer_False_Succeeds()
        {
            // Arrange
            GasLayer layer1 = new OxygenLayer();
            layer1.Thickness = 1.0;
            GasLayer layer2 = new OzoneLayer();
            layer2.Thickness = 0.8;
            GasLayer layer3 = new CarbonDioxideLayer();
            layer3.Thickness = 1.2;

            gasLayers.Add(layer1);
            gasLayers.Add(layer2);
            gasLayers.Add(layer3);

            // Act
            bool result = AtmosphereSimulator.CheckForPerishedLayer(gasLayers);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
