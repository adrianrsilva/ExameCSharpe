using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCinema2022.Models
{
    public class FileUploadModels
    {
        public IFormFile files { get; set; }
    }
}
