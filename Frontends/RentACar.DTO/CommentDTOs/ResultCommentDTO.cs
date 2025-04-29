﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DTO.CommentDTOs
{
    public class ResultCommentDTO
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogID { get; set; } 
    }
}
