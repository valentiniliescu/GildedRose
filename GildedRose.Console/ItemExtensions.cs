using System;

namespace GildedRose.Console
{
    public static class ItemExtensions
    {
        private const int QualityUpperBound = 50;
        private const int QualityLowerBound = 0;
        private const int ConjuredQualityChangeRate = 2;
        private const int NonConjuredQualityChangeRate = 1;
        private const string ConjuredPrefix = "Conjured";

        public static bool IsExpired(this GildedRose.Item item)
        {
            return item.SellIn < 0;
        }

        public static void DecreaseSellIn(this GildedRose.Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        public static void IncreaseQualityIfPossible(this GildedRose.Item item)
        {
            var qualityChangeRate = item.GetQualityChangeRate();

            if (item.Quality + qualityChangeRate <= QualityUpperBound)
            {
                item.Quality = item.Quality + qualityChangeRate;
            }
        }

        public static void DecreaseQualityIfPossible(this GildedRose.Item item)
        {
            var qualityChangeRate = item.GetQualityChangeRate();

            if (item.Quality - qualityChangeRate >= QualityLowerBound)
            {
                item.Quality = item.Quality - qualityChangeRate;
            }
        }

        private static int GetQualityChangeRate(this GildedRose.Item item)
        {
            return item.IsConjured()
                ? ConjuredQualityChangeRate
                : NonConjuredQualityChangeRate;
        }

        private static bool IsConjured(this GildedRose.Item item)
        {
            return item.Name.StartsWith(ConjuredPrefix, StringComparison.InvariantCultureIgnoreCase);
        }

        public static string GetName(this GildedRose.Item item)
        {
            return item.IsConjured()
                ? item.Name.Substring(ConjuredPrefix.Length + 1)
                : item.Name;
        }
    }
}