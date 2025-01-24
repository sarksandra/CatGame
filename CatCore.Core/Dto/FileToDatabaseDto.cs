﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace   Cat.Core.Dto
{
    public class FileToDatabaseDto
    {
        public Guid ID { get; set; }
        public Guid ImageID { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? HunterID { get; set; }
        public Guid? RoomID { get; set; }
    }
}
