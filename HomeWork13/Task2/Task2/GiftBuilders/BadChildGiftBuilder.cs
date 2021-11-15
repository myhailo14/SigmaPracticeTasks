using Task2.GiftParts;

namespace Task2.GiftBuilders
{
    class BadChildGiftBuilder : GiftBuilder
    {
        public override void IncludeToy(Toys toysList)
        {
            Gift.SetToy(toysList.BadChildToy);
        }

        public override void IncludeSweet(Sweets sweetsList)
        {
            Gift.SetSweet(sweetsList.BadChildSweet);
        }

        public override void IncludeWish(Wishes wishesList)
        {
            Gift.SetWish(wishesList.BadChildWish);
        }

        public override void IncludeGivenToy(string toy)
        {
            Gift.SetToy(toy);
        }

        public override void IncludeGivenSweet(string sweet)
        {
            Gift.SetSweet(sweet);
        }

        public override void IncludeGivenWish(string wish)
        {
            Gift.SetWish(wish);
        }
    }
}