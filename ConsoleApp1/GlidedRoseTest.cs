using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace ConsoleApp1
{

    public class GlidedRoseTest
    {
        [TestCase(10, 9)]
        [TestCase(5, 4)]
        public void ShouldDecreaseSellInByOneEveryday(int sellin, int expected_sellin)
        {
            var application = new Application();
            var item = new Item { name = "Standard", sellin = sellin };
            application.Update(item);
            item.sellin.Should().Be(expected_sellin);
        }

        [TestCase(10, 11)]
        [TestCase(5, 6)]
        public void ShouldIncreaseAgedBrieQualityByOne(int quality, int expected_quality)
        {
            var application = new Application();
            var item = new Item { name = "Aged Brie", quality = quality };
            application.Update(item);
            item.quality.Should().Be(expected_quality);
        }

        [TestCase(50, 50)]
        [TestCase(49, 50)]
        public void ShouldNotIncreaseAgedBrieQualityWhenExceeding50(int quality, int expected_quality)
        {
            var application = new Application();
            var item = new Item { name = "Aged Brie", quality = quality };
            application.Update(item);
            item.quality.Should().Be(expected_quality);
        }

        [Test]
        public void ShouldNotStandardQualityBeNagative()
        {
            var application = new Application();
            var item = new Item { name = "Standard", quality = 0 };
            application.Update(item);
            item.quality.Should().Be(0);
        }

        [TestCase(10, 9)]
        [TestCase(34, 33)]
        public void ShouldDecreaseStandardItemQualityByOneEveryday(int quality, int expected_quality)
        {
            var application = new Application();
            var item = new Item { name = "Standard", quality = quality };
            application.Update(item);
            item.quality.Should().Be(expected_quality);
        }
    }

    public class Item
    {
        public string name { get; set; }
        public int sellin { get; set; }
        public int quality { get; set; }
    }

    public class Application
    {
        public void Update(Item item)
        {
            item.sellin = item.sellin - 1;
            if (item.name == "Standard")
            {
                if (item.quality > 0)
                {
                    item.quality--;
                }
            }
            else
            {
                if (item.quality < 50)
                {
                    item.quality = item.quality + 1;
                }
            }
        }
    }
}