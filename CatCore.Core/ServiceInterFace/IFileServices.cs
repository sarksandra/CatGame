using Cat.Core.Dto;
using CatGame.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Core.ServiceInterFace
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(CatDto dto, CatDM domino);
    }
}
