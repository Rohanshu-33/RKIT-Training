using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB_CRUD.DTO
{
    // DTO class is used to transfer data between client and your application(to POCO Model)
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}