using gourmet.Properties;
using gourmet.Source.Models.Abstract;
using gourmet.Source.Models.Concrete.Ingredients;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gourmet.Source.Helpers
{
    public class IconFinder
    {
        public IconFinder()
        {
            
        }
        public static Bitmap GetIcon(IIngredient ingredient)
        {
            if (ingredient is Avocado) return Resources.avocado;
            else if (ingredient is Banana) return Resources.banana;
            else if (ingredient is Chilli) return Resources.chilli;
            else if (ingredient is Egg) return Resources.egg;
            else if (ingredient is Flour) return Resources.flour;
            else if (ingredient is Macaroni) return Resources.macaroni;
            else if (ingredient is MilkChocolate) return Resources.chocolate;
            else if (ingredient is Onion) return Resources.onion;
            else if (ingredient is Orange) return Resources.orange;
            else if (ingredient is Sausage) return Resources.sausage;
            else if (ingredient is Tomato) return Resources.tomato;
            else if (ingredient is VegetableOil) return Resources.vegetableoil;
            else if (ingredient is Walnuts) return Resources.walnuts;
            else if (ingredient is RedMeat) return Resources.redmeat;
            else if (ingredient is Salmon) return Resources.salmon;
            else return Resources.blank;
        }
    }
}
