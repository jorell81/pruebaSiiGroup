using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Core.Entidades
{
    public class Result<I> 
    {
        public string? status { get; set; }
        public string? message { get; set; }
        public I? data { get; set; }
    }
}
