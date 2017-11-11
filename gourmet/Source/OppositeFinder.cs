using gourmet.Source.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gourmet.Source
{
    public class OppositeFinder
    {
        public OppositeFinder()
        {
            //Dictionary<IIngredient> onionPositives
            Matrix = new int[(int)(IngredientList.Walnuts + 1), (int)(IngredientList.Walnuts + 1)]
            {
                { 0, 0, 1, -1, -1, -1, -1, 1, 0, -1, -1, -1, 0, 0, 0},
                { 0, 0, 1, -1, -1, -1, -1, 1, 0, -1, -1, -1, 0, 0, 0},
                { 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1},
                { -1, -1, 1, 0, -1, -1, -1, 1, -1, -1, -1, -1, -1, -1, -1},
                { -1, -1, 1, -1, 0, 0, -1, 1, -1, -1, -1, -1, -1, 1, 0},
                { -1, -1, 1, -1, 0, 0, -1, 1, -1, -1, -1, -1, -1, 1, 0},
                { -1, -1, 1, -1, -1, -1, 0, 1, -1, -1, -1, -1, -1, -1, -1},
                { 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1},
                { 0, 0, 1, -1, -1, -1, -1, 1, 0, -1, -1, -1, 0, 1, 1},
                { -1, -1, 1, -1, -1, -1, -1, 1, -1, 0, 0, 0, -1, -1, -1},
                { -1, -1, 1, -1, -1, -1, -1, 1, -1, 0, 0, 0, -1, -1, -1},
                { -1, -1, 1, -1, -1, -1, -1, 1, -1, 0, 0, 0, -1, -1, -1},
                { 0, 0, 1, -1, -1, -1, -1, 1, 0, -1, -1, -1, 0, 1, 1},
                { 0, 0, 1, -1, 1, 1, -1, 1, 1, -1, -1, -1, 1, 0, 1},
                { 0, 0, 1, -1, 0, 0, -1, 1, 1, -1, -1, -1, 1, 1, 0}
            };
        }

        public int[,] Matrix { get; set; }
    }
}
