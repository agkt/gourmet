using gourmet.Source.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gourmet.Source.Models.Concrete.Emotions
{
    public class Annoyance : IEmotion
    {
        public string Name => "Раздражение";
        public bool? IsPositive => false;

        public override bool Equals(object obj)
        {
            return Name == ((IEmotion)obj).Name;
        }
        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
