using System;
using System.Collections.Generic;

namespace vnface_core.Models
{
    public partial class FaceLogTb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Date { get; set; }
        public string FaceImg { get; set; }
        public string RecognizeImg { get; set; }
    }
}
