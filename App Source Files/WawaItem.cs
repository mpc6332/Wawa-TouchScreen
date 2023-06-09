namespace Lab_WawaApp;

public class WawaItem
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Calories { get; set; }
    public int QTY { get; set; }

    public override string ToString()
    {
        return $"{Name}\n" +
               $"       Calories:   {Calories * QTY}\n" +
               $"       QTY:         {QTY}\n" +
               $"       Price:        ${Price * QTY}";
    }
}