using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMatchLibrary
{
    public class Match : Attribute
    {
        Type _type;

        public Match()
        {

        }

        public Match(Type type)
        {
            _type = type;
        }

        public Type Type { get => _type; }
    }
}
