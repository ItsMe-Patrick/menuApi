using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MenuAPI.Models
{

    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

    }
}
