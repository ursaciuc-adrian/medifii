using System;
using System.Collections.Generic;
using System.Text;

namespace Medifii.SearchService.Dto
{
    public class DbProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public float Price { get; set; }
    }
}
