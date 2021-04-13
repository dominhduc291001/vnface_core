using System;
using System.Collections.Generic;

namespace vnface_core.Models
{
    public partial class FaceTb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string FaceImage { get; set; }
        public string Feature { get; set; }
    }
}
