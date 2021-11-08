namespace Task2.GiftParts
{
    class Gift
    {
        private string _toy;
        private string _sweet;
        private string _wish;

        public void SetToy(string toy)
        {
            _toy = toy;
        }
        public void SetSweet(string sweet)
        {
            _sweet = sweet;
        }
        public void SetWish(string wish)
        {
            _wish = wish;
        }

        public override string ToString()
        {
            return $"\n Toy - {_toy}\n Sweet - {_sweet}\n Wish - {_wish}\n";
        }
    }
}