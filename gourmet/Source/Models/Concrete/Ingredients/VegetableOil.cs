using gourmet.Source.Models.Abstract;
using gourmet.Source.Models.Concrete.Emotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gourmet.Source.Models.Concrete.Ingredients
{
    public class VegetableOil : IIngredient
    {
        public string Name => "Растительное масло";

        public Dictionary<IEmotion, float> Emotions => new Dictionary<IEmotion, float>()
        {
            { new Serenity(), 2.84f },
            { new Interest(), 2.49f},
            { new Disgust(), 2.35f },
            { new Wonder(), 2.32f }
        };
        public VegetableOil()
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