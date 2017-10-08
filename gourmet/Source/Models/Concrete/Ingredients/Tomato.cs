using gourmet.Source.Models.Abstract;
using gourmet.Source.Models.Concrete.Emotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gourmet.Source.Models.Concrete.Ingredients
{
    public class Tomato : IIngredient
    {
        public string Name => "Помидор";

        public Dictionary<IEmotion, float> Emotions => new Dictionary<IEmotion, float>()
        {
            { new Happiness(), 4.0f },
            { new Kindness(), 4.0f },
            { new Serenity(), 3.0f },
            { new Confidence(), 2.0f }
        };
        public Tomato()
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