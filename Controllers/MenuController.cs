using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MenuAPI.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using MenuAPI.Models;
using MySqlConnector;
using Microsoft.Extensions.Logging;

namespace MenuAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<MenuController> _logger;
        public MenuController(IConfiguration configuration, IWebHostEnvironment env, ILogger<MenuController> logger)
        {
            _configuration = configuration;
            _env = env;
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<Menu> Get()
        {
            string query = @"
                            select id, food_name,price
                            from
                            dbo.food
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MenuDBCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            //return new JsonResult(table);
            return table.AsEnumerable().Select(row => new Menu
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["food_name"].ToString(),
                Price = Convert.ToInt32(row["price"])
            }).ToArray();

        }

        //[HttpGet]
        //public IEnumerable<Menu> Get()
        //{
        //    string query = @"
        //                    select Id, Name,Description,Price
        //                    from
        //                    dbo.Menu
        //                    ";

        //    DataTable table = new DataTable();

        //    var connection = new MySqlConnection("MenuDBCon");
        //    connection.Open();
        //    var command = new MySqlCommand(query, connection);
        //    var reader = command.ExecuteReader();
        //    table.Load(reader);
        //    reader.Close();
        //    connection.Close();



        //    return table.AsEnumerable().Select(row => new Menu 
        //        {
        //            Id = Convert.ToInt32(row["Id"]),
        //            Name = row["Name"].ToString(),
        //            Description = row["Description"].ToString(),
        //            Price = Convert.ToInt32(row["Price"])
        //        }).ToArray();

        //}


        //[HttpPost]
        //public JsonResult Post(Menu emp)
        //{
        //    string query = @"
        //                   insert into dbo.Menu
        //                   (Name,Description,Price)
        //            values (@Name,@Description,@Price)
        //                    ";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("MenuDBCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@Name", emp.Name);
        //            myCommand.Parameters.AddWithValue("@Description", emp.Description);
        //            myCommand.Parameters.AddWithValue("@Price", emp.Price);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult("Added Successfully");
        //}


        //[HttpPut]
        //public JsonResult Put(Menu emp)
        //{
        //    string query = @"
        //                   update dbo.Name
        //                   set Name= @Name,
        //                    Description=@Description,
        //                    Price=@Price,
        //                    where Id=@Id
        //                    ";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("MenuDBCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@Name", emp.Name);
        //            myCommand.Parameters.AddWithValue("@Description", emp.Description);
        //            myCommand.Parameters.AddWithValue("@Price", emp.Price);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult("Updated Successfully");
        //}

        //[HttpDelete("{id}")]
        //public JsonResult Delete(int id)
        //{
        //    string query = @"
        //                   delete from dbo.Menu
        //                    where Id=@Id
        //                    ";

        //    DataTable table = new DataTable();
        //    string sqlDataSource = _configuration.GetConnectionString("MenuDBCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@Id", id);

        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult("Deleted Successfully");
        //}


       
    }
}
