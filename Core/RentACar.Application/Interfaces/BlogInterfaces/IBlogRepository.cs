﻿using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        public List<Blog> GetLast3BlogsWithAuthors();

        public List<Blog> GetAllBlogsWithAuthors();

        public List<Blog> GetBlogByAuthorId(int id);
    }
}
