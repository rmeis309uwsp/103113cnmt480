public class Coffee
{
    public int id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public double price { get; set; }
    public string roast { get; set; }
    public string country { get; set; }
    public string image { get; set; }
    public string review { get; set; }

    public Coffee(int id, string name, string type, double price, string roast, string country, string image, string review)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.price = price;
        this.roast = roast;
        this.country = country;
        this.image = image;
        this.review = review;
    }
    public Coffee(string name, string type, double price, string roast, string country, string image, string review)
    {
        this.name = name;
        this.type = type;
        this.price = price;
        this.roast = roast;
        this.country = country;
        this.image = image;
        this.review = review;
    }
}