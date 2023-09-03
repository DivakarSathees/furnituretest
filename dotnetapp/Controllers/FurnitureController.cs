using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnetapp.Models;
using System.Data;
using Microsoft.Data.SqlClient;

public class FurnitureController : Controller
{

    private string connectionString = "User ID=sa;password=examlyMssql@123;server=dffafdafebcfacbdcbaeadbebabcdebdca-0;Database=FuritureDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";

    public ActionResult Index()
    {
        // List<Furniture> furnitures = new List<Furniture>();
    try
    {
        List<Furniture> furnitures = new List<Furniture>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "EXEC GetFurniture";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Furniture furniture = new Furniture();

                    furniture.id = Convert.ToInt32(reader["id"]);
                    furniture.Product = reader["Product"].ToString();
                    furniture.Description = reader["Description"].ToString();
                    furniture.Material = reader["Material"].ToString();
                    furniture.Dimensions = reader["Dimensions"].ToString();
                    // furniture.Price = reader["Price"].ToString();
                    furniture.Price = decimal.Parse(reader["Price"].ToString());

                    furnitures.Add(furniture);
                }

                reader.Close();
            }
        }
        return View(furnitures);

}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving the furniture item.");

}
        // return View(furnitures);

    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Furniture furniture)
    {
        try{
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Furniture (Product, Description, Material, Dimensions, Price) VALUES (@Product, @Description, @Material,@Dimensions, @Price)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // command.Parameters.AddWithValue("@id", Book.id);
                command.Parameters.AddWithValue("@Product", furniture.Product);
                command.Parameters.AddWithValue("@Description", furniture.Description);
                command.Parameters.AddWithValue("@Material", furniture.Material);
                command.Parameters.AddWithValue("@Dimensions", furniture.Dimensions);
                command.Parameters.AddWithValue("@Price", furniture.Price);


                connection.Open();

                command.ExecuteNonQuery();
            }
        }
        }
        catch(Exception ex)
{
    Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while creating the furniture item.");

}

        return RedirectToAction("Index");
    }



}