namespace GildedRose.Console
{
    public static class ItemExtensions
    {
        private const int QualityUpperBound = 50;
        private const int QualityLowerBound = 0;

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
            if (item.Quality < QualityUpperBound)
            {
                item.Quality = item.Quality + 1;
            }
        }

        public static void DecreaseQualityIfPossible(this GildedRose.Item item)
        {
            if (item.Quality > QualityLowerBound)
            {
                item.Quality = item.Quality - 1;
            }
        }
    }
}