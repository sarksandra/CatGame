﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.Dto
{
        public enum CatType
        {
            Orange, Black, Gray, White, Brown, Pink
        }
        public enum CatFoodType
        {
            Cake, Brownie, Muffin, Cookie, Candy, Chocolate, Waffle, IceCreame, Jelly, Pancake, Lollipop
        }
        public class CatDto
        {
            public Guid Id { get; set; }
            public string CatName { get; set; }
            public string CatFood { get; set; }
            public int CatFoodXP { get; set; }
            public int CatFoodXPNextLevel { get; set; }
            public int CatLevel { get; set; }
            public CatType CatType { get; set; }
            public CatFoodType CatFoodType { get; set; }
            public List<IFormFile> Files {get ; set ;}
           
            public IEnumerable<FileToDatabaseDto> Image {get; set;} = new List<FileToDatabaseDto>();
        }
        

    
         
        
}
