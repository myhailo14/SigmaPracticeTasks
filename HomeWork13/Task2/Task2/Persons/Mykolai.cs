using System;
using Task2.GiftBuilders;
using Task2.GiftParts;

namespace Task2
{
    public interface IMykolai
    {
        (Toys, Sweets, Wishes) GetToysList();
        Gift CreateGift(Child child);
        Gift CreateGiftForGoodChild(Child child);
        Gift CreateGiftForAnyChild(Child child);
        void SetGiftPolicy(bool policy);
        bool GetGiftPolicy();
    }

    public interface IAgedGiftBuilder
    {
        Gift CreateAgedGift(Child child, int age);
        Gift CreateAgedGiftForGoodChild(Child child, int age);
        Gift CreateAgedGiftForAnyChild(Child child, int age);

    }

    public class AgedGiftAdapter : IAgedGiftBuilder
    {
        protected IMykolai _mykolai;

        public AgedGiftAdapter(IMykolai mykolai)
        {
            _mykolai = mykolai;
        }

        public Gift CreateAgedGift(Child child, int age)
        {
            return _mykolai.GetGiftPolicy() == true
                ? CreateAgedGiftForGoodChild(child, age)
                : CreateAgedGiftForAnyChild(child, age);
        }

        public Gift CreateAgedGiftForGoodChild(Child child, int age)
        {
            var gift = _mykolai.CreateGiftForGoodChild(child);
            if (child.IsGood == false)
            {
                gift.SetToy(_mykolai.GetToysList().Item1.BadChildToy);
                gift.SetSweet(_mykolai.GetToysList().Item2.BadChildSweet);
                gift.SetSweet(_mykolai.GetToysList().Item3.BadChildWish);
                return gift;
            }
            if (child.IsBoy == true)
            {
                gift.SetToy(_mykolai.GetToysList().Item1.GetRandomAgedBoyToy(age));
                return gift;
            }
            gift.SetToy(_mykolai.GetToysList().Item1.GetRandomAgedGirlToy(age));
            return gift;
        }

        public Gift CreateAgedGiftForAnyChild(Child child, int age)
        {
            var gift = _mykolai.CreateGiftForAnyChild(child);
            
            if (child.IsBoy == true)
            {
                gift.SetToy(_mykolai.GetToysList().Item1.GetRandomAgedBoyToy(age));
                return gift;
            }
            gift.SetToy(_mykolai.GetToysList().Item1.GetRandomAgedGirlToy(age));
            return gift;
        }
    }

    public class Mykolai : IMykolai
    {
        #region SingletonePatternPart
        private static readonly Lazy<Mykolai> Lazy = new Lazy<Mykolai>(() => new Mykolai());
        public static Mykolai Instance => Lazy.Value;
        private Mykolai() { }
        #endregion

        private readonly Toys _toys = new Toys();
        private readonly Sweets _sweets = new Sweets();
        private readonly Wishes _wishes = new Wishes();
        private int _currentBoyToyIndex = 0;
        private int _currentGirlToyIndex = 0;
        private int _currentSweetIndex = 0;
        private int _currentWishIndex = 0;
        private bool _considerBadActions = true;

        public (Toys, Sweets, Wishes) GetToysList()
        {
            return (_toys, _sweets, _wishes);
        }

        public Gift CreateGift(Child child)
        {
            return _considerBadActions == true ? CreateGiftForGoodChild(child) : CreateGiftForAnyChild(child);
        }

        public Gift CreateGiftForGoodChild(Child child)
        {
            var giftForChild = new BuildGift();

            if (child.IsGood == false)
            {
                giftForChild.SetGiftBuilder(new BadChildGiftBuilder());
                giftForChild.SetUpGift(_toys, _sweets, _wishes);
            }
            else
            {
                if (child.IsBoy)
                {
                    giftForChild.SetGiftBuilder(new BoyGiftBuilder());
                    giftForChild.SetUpGift(_toys, _sweets, _wishes);
                }
                else
                {
                    giftForChild.SetGiftBuilder(new GirlGiftBuilder());
                    giftForChild.SetUpGift(_toys, _sweets, _wishes);
                }
            }

            var gift = giftForChild.GetGift();
            
            return gift;
        }
        public Gift CreateGiftForAnyChild(Child child)
        {
            var giftForChild = new BuildGift();
            if (child.IsBoy)
            {
                giftForChild.SetGiftBuilder(new BoyGiftBuilder());
                giftForChild.SetUpGift(_toys.BoyToys[_currentBoyToyIndex++], _sweets.SweetList[_currentSweetIndex++], _wishes.WishesList[_currentWishIndex++]);
            }
            else
            {
                giftForChild.SetGiftBuilder(new GirlGiftBuilder());
                giftForChild.SetUpGift(_toys.GirlToys[_currentGirlToyIndex++], _sweets.SweetList[_currentSweetIndex++], _wishes.WishesList[_currentWishIndex++]);
            }
            CheckIndexes();
            var gift = giftForChild.GetGift();
            
            return gift;
        }
        
        public void SetGiftPolicy(bool policy)
        {
            _considerBadActions = policy;
        }

        public bool GetGiftPolicy()
        {
            return _considerBadActions;
        }

        public void ResetGiftPartsCounter()
        {
            _currentBoyToyIndex = 0;
            _currentGirlToyIndex = 0;
            _currentSweetIndex = 0;
            _currentWishIndex = 0;
        }

        private void CheckIndexes()
        {
            if (_currentBoyToyIndex >= _toys.BoyToys.Count)
            {
                _currentBoyToyIndex = 0;
            }

            if (_currentGirlToyIndex >= _toys.GirlToys.Count)
            {
                _currentGirlToyIndex = 0;
            }

            if (_currentSweetIndex >= _sweets.SweetList.Count)
            {
                _currentSweetIndex = 0;
            }

            if (_currentWishIndex >= _wishes.WishesList.Count)
            {
                _currentWishIndex = 0;
            }
        }

    }
}