using Task2.GiftParts;

namespace Task2.GiftBuilders
{
    class GirlGiftBuilder : GiftBuilder
    {
        public override void IncludeToy(Toys toysList)
        {
            Gift.SetToy(toysList.GetRandomGirlToy());
        }

        public override void IncludeSweet(Sweets sweetsList)
        {
            Gift.SetSweet(sweetsList.GetRandomSweet());
        }

        public override void IncludeWish(Wishes wishesList)
        {
            Gift.SetWish(wishesList.GetRandomWish());
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