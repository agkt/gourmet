using gourmet.Source.Models.Abstract;
using gourmet.Source.Models.Concrete.Emotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gourmet.Source.Models.Concrete.Ingredients
{
    public class Salmon : IIngredient
    {
        public string Name => "Лосось";

        public Dictionary<IEmotion, float> Emotions => new Dictionary<IEmotion, float>()
        {
            { new Concentration(), 3.73f },
            { new Serenity(), 2.69f },
            { new Interest(), 1.96f },
            { new Pleasure(), 1.62f }
        };
        public Salmon()
        {
        }

        public override bool Equals(object obj)
        {
            return Name == ((IIngredient)obj).Name;
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