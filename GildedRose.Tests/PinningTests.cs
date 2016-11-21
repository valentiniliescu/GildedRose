using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApprovalTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class PinningTests
    {
        [TestMethod]
        public void VerifyInventoryAfterEachDayFor50Days()
        {
            var gildedRose = new Console.GildedRose();

            var log = new StringBuilder();
            for (var day = 0; day < 50; day++)
            {
                log
                    .AppendLine()
                    .AppendLine($"Inventory after day {day}")
                    .Append(gildedRose.Inventory.SerializeToString())
                    .AppendLine();

                gildedRose.UpdateQuality();
            }

            Approvals.Verify(log);
        }
    }

    public static class ItemsExtensions
    {
        public static string SerializeToString(this IEnumerable<Console.GildedRose.Item> items)
        {
            return items != null
                ? string.Join(Environment.NewLine, items.Select(item => $"Name: {item.Name} Sell in: {item.SellIn} Quality: {item.Quality}"))
                : string.Empty;
        }
    }
}
