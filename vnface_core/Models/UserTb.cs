using System;
using System.Collections.Generic;

namespace vnface_core.Models
{
    public partial class UserTb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string FaceImage { get; set; }
        public string Role { get; set; }
    }
}
