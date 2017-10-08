using gourmet.Source.Models.Abstract;
using gourmet.Source.Models.Concrete.Emotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gourmet.Source.Models.Concrete.Ingredients
{
    public class Flour : IIngredient
    {
        public string Name => "Мука";

        public Dictionary<IEmotion, float> Emotions => new Dictionary<IEmotion, float>()
        {
            { new Happiness(), 3.40f },
            { new Wonder(), 2.42f },
            { new Tiredness(), 2.23f },
            { new Distraction(), 1.95f }
        };
        public Flour()
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