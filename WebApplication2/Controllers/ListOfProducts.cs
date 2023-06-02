using System.ComponentModel;
using Microsoft.VisualBasic.FileIO;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class ListOfProducts
{
    private List<Product> productList;

    public ListOfProducts()
    {
        productList = new List<Product>();
        ReadCSV();

    }

    public List<Product> ProductList()
    {
        return productList;
    }

    public void ReadCSV()
    {
        string csvFilePath = "Products.csv";

        using (TextFieldParser parser = new TextFieldParser(csvFilePath))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                Product product = new Product();
                product.Title = fields[0];
                product.Description = fields[1];
                product.Category = fields[2];
                product.Image = fields[3];
                product.Price = Double.Parse(fields[4]);
                product.Supplier = fields[5];
                productList.Add(product);
                

            }
        }
    }

    // public Product GetItemsOfCategory(ListOfProducts productList,string category="Transportation")
    // {
    //     foreach (var product in this.productList)
    //     {
    //         
    //     }
    //     
    // }
    public List<string> ListOfCategories()
    {
        List<string> CategoryList = new List<string>();
        foreach (Product product in productList)
        {
            if (!CategoryList.Contains(product.Category))
            {
                CategoryList.Add(product.Category);
            }
        }

        return CategoryList;
    }
}
