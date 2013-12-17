public class Items
{
    public int itemid { get; set; }
   public string name { get; set; }
    public string categoryname { get; set; }
    public string description { get; set; }
 //   public string imagepath { get; set; }
 //   public bool available { get; set; }
 //   public bool staffonly { get; set; }


    public Items(int itemid, string name, string categoryname,string description /*string imagepath, bool available, bool staffonly*/)
    {
       this.itemid = itemid;
       this.name = name;
      this.categoryname = categoryname;
      this.description = description;
  //    this.imagepath = imagepath;
  //      this.available = available;
  //      this.staffonly = staffonly;
       
        
    }

    public Items(string name/*, string categoryname, string description, string available, string staff*/)
    {

        this.name = name;
        //this.categoryname = categoryname;
        //this.description = description;
        //    this.imagepath = image;
        //    this.available = available;
        //    this.staffonly = staff; 


    }  
}