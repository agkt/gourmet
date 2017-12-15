using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gourmet.Source.Models.Abstract
{
    public interface IIngredient
    {
        string Name { get; }
        Dictionary<IEmotion, float> Emotions { get; }
    }
}
