using System;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class Pages_Inventory_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string selectedValue = ddlImage.SelectedValue;
        ShowImages();
        ddlImage.SelectedValue = selectedValue;
    }

    private void ShowImages()
    {
        //Get all filepaths
        string[] images = Directory.GetFiles(Server.MapPath("~/Images/Inventory/"));

        //Get all filenames and add them to an arraylist
        ArrayList imageList = new ArrayList();

        foreach (string image in images)
        {
            string imageName = image.Substring(image.LastIndexOf(@"\") + 1);
            imageList.Add(imageName);
        }

        //Set the arrayList as the dropdownview's datasource and refresh
        ddlImage.DataSource = imageList;
        ddlImage.DataBind();
    }
    private void ClearTextFields()
    {
       
        txtName.Text = "";
        txtCategory.Text = "";
        txtDescription.Text = "";
   //     txtAvailable.Text = "";
    //    txtStaff.Text = "";
    }



    protected void btnUploadImage_Click(object sender, EventArgs e)
    {
        try
        {
            string filename = Path.GetFileName(FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/Images/Inventory/") + filename);
            lblResult.Text = "Image " + filename + " succesfully uploaded!";
            Page_Load(sender, e);
        }
        catch (Exception)
        {
            lblResult.Text = "Upload failed!";
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
      
    

        
        try
        {
     
            string name = txtName.Text;
            string category = txtCategory.Text;
            string description = txtDescription.Text;
            string image = "../Images/Inventory/" + ddlImage.SelectedValue;
           // string available = txtAvailable.Text;
            //int available = Convert.ToInt32(txtAvailable.Text);
           // string staff = txtStaff.Text;
   
  

           // Items items = new Items(name, category, description, image/*, available, staff*/);
            //ConnectionClass.AddInventory(items);  
            lblResult.Text = "Upload succesful!";
            ClearTextFields();
        }
        catch (Exception)
        {
            lblResult.Text = "Upload failed!";
        }
    }
}

