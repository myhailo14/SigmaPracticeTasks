namespace StoreApp.StorageClasses;

public class StorageNorms
{
    public int ProductMax { get; private set; } = 500;
    public int MeatMax { get; private set; } = 100;
    public int DairyMax { get; private set; } = 100;

    public int ProductCurrent { get; private set; } = 0;
    public int MeatCurrent { get; private set; } = 0;
    public int DairyCurrent { get; private set; } = 0;

    public bool WillFitProduct()
    {
        return ProductCurrent + 1 <= ProductMax;
    }
    public bool WillFitMeat()
    {
        return MeatCurrent + 1 <= MeatMax;
    }

    public bool WillFitDairy()
    {
        return DairyCurrent + 1 <= DairyMax;
    }

}