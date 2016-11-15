using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class PinningTests
    {
        private static readonly Func<Console.GildedRose.Item, Console.GildedRose.Item, bool> ItemEqualityComparison = 
            (item1, item2) => 
                item1.Name == item2.Name 
                && item1.SellIn == item2.SellIn 
                && item1.Quality == item2.Quality;

        [TestMethod]
        public void InitialInventory()
        {
            var gildedRose = new Console.GildedRose();

            var expectation = new[] {
                new Console.GildedRose.Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Console.GildedRose.Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Console.GildedRose.Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Console.GildedRose.Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Console.GildedRose.Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Console.GildedRose.Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };

            gildedRose.Inventory.Should().Equal(expectation, ItemEqualityComparison);
        }
    }
}
