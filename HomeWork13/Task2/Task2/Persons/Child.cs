using Task2.GiftParts;

namespace Task2
{
    interface IChild
    {
        public void AskForGift(IMykolai m);
        public string ToString();
    }

    public class Child : IChild
    {
        public string Name { get; private set; }
        private bool _sex;
        private int _goodActions;
        private int _badActions;
        private Gift _gift = null;
        public bool IsGood => _goodActions - _badActions > 0;
        public bool IsBoy => _sex;
        public Gift Gift => _gift;
        public Child(string name, bool sex, int goodActions, int badActions)
        {
            Name = name;
            _sex = sex;
            _goodActions = goodActions;
            _badActions = badActions;
        }

        public void AskForGift(IMykolai m)
        {
            _gift = m.CreateGift(this);
        }

        public void AskForGift(IAgedGiftBuilder agb, int age)
        {
            _gift = agb.CreateAgedGift(this, age);
        }

        public override string ToString()
        {
            return $"{(IsGood ? "Good" : "Bad")} {(IsBoy ? "boy" : "girl")} {Name}\nGift: {(_gift == null ? " (no gift)" : $"{_gift}")}";
        }
    }
}