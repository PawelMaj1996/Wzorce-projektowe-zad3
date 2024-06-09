using System;

public interface IPizzaBuilder
{
    void SetDough();
    void AddMeat();
    void AddCheese();
    void AddVegetables();
    void AddSpices();
    Pizza GetPizza();
}

public class PizzaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void SetDough()
    {
        _pizza.Dough = "standard dough";
    }

    public void AddMeat()
    {
        _pizza.Meat = "pepperoni";
    }

    public void AddCheese()
    {
        _pizza.Cheese = "mozzarella";
    }

    public void AddVegetables()
    {
        _pizza.Vegetables = "bell peppers";
    }

    public void AddSpices()
    {
        _pizza.Spices = "oregano";
    }

    public Pizza GetPizza()
    {
        return _pizza;
    }
}

public class Pizza
{
    public string Dough { get; set; }
    public string Meat { get; set; }
    public string Cheese { get; set; }
    public string Vegetables { get; set; }
    public string Spices { get; set; }

    public override string ToString()
    {
        return $"Pizza with {Dough}, {Meat}, {Cheese}, {Vegetables}, {Spices}";
    }
}

public class Director
{
    private IPizzaBuilder _builder;

    public void SetBuilder(IPizzaBuilder builder)
    {
        _builder = builder;
    }

    public void BuildPizza()
    {
        _builder.SetDough();
        _builder.AddMeat();
        _builder.AddCheese();
        _builder.AddVegetables();
        _builder.AddSpices();
    }
}

public class Client
{
    public static void Main(string[] args)
    {
        PizzaBuilder builder = new PizzaBuilder();
        Director director = new Director();
        director.SetBuilder(builder);
        director.BuildPizza();
        Pizza pizza = builder.GetPizza();
        Console.WriteLine(pizza.ToString());
    }
}
