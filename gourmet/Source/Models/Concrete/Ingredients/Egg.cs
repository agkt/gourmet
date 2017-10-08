using gourmet.Source.Models.Abstract;
using gourmet.Source.Models.Concrete.Emotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gourmet.Source.Models.Concrete.Ingredients
{
    public class Egg : IIngredient
    {
        public string Name => "Яйцо";

        public Dictionary<IEmotion, float> Emotions => new Dictionary<IEmotion, float>()
        {
            { new Happiness(), 5.0f },
            { new Arousal(), 1.82f },
            { new Confidence(), 1.63f },
            { new Kindness(), 1.36f }
        };
        public Egg()
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