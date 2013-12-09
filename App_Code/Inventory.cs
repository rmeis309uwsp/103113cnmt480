public class Items
{
    public int itemid { get; set; }
    public string name { get; set; }
    public string categoryname { get; set; }
    public string description { get; set; }
    public string imagepath { get; set; }
    public bool available { get; set; }
    public bool staffonly { get; set; }


    public Items(int id, string name, string category,string description, string image, bool available, bool staff)
    {
        this.itemid = id;
        this.name = name;
        this.categoryname = category;
        this.description = description;
        this.imagepath = image;
        this.available = available;
        this.staffonly = staff;
       
        
    }
  //  public Items(string name, string category, string description, string image/*, string available, string staff*/)
  //  {
       
   //     this.name = name;
    //    this.categoryname = category;
    //    this.description = description;
    //    this.imagepath = image;
    //    this.available = available;
    //    this.staffonly = staff;


   // }
}