using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMatchLibrary.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
