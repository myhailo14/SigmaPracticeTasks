using Task2.GiftParts;

namespace Task2.GiftBuilders
{
    
    interface IBuildGift
    {
        public void SetGiftBuilder(GiftBuilder chosenBuilder);
        public Gift GetGift();
        public void SetUpGift(Toys toys, Sweets sweets, Wishes wishes);
        public void SetUpGift(string toy, string sweet, string wish);
    }
    class BuildGift : IBuildGift
    {
        private GiftBuilder _giftBuilder;

        public void SetGiftBuilder(GiftBuilder chosenBuilder)
        {
            _giftBuilder = chosenBuilder;
        }

        public Gift GetGift()
        {
            return _giftBuilder.GetGift();
        }

        public void SetUpGift(Toys toys, Sweets sweets, Wishes wishes)
        {
            _giftBuilder.CreateNewGift();
            _giftBuilder.IncludeToy(toys);
            _giftBuilder.IncludeSweet(sweets);
            _giftBuilder.IncludeWish(wishes);
        }

        public void SetUpGift(string toy, string sweet, string wish)
        {
            _giftBuilder.CreateNewGift();
            _giftBuilder.IncludeGivenToy(toy);
            _giftBuilder.IncludeGivenSweet(sweet);
            _giftBuilder.IncludeGivenWish(wish);
        }
    }
}