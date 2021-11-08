using Task2.GiftParts;

namespace Task2.GiftBuilders
{
    abstract class GiftBuilder
    {
        protected Gift Gift { get; private set; }

        public void CreateNewGift()
        {
            Gift = new Gift();
        }

        public Gift GetGift()
        {
            return Gift;
        }


        public abstract void IncludeToy(Toys toysList);
        public abstract void IncludeSweet(Sweets sweetsList);
        public abstract void IncludeWish(Wishes wishesList);

        public abstract void IncludeGivenToy(string toy);
        public abstract void IncludeGivenSweet(string sweet);
        public abstract void IncludeGivenWish(string wish);
    }
}