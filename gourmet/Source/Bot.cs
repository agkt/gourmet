using gourmet.Source.Models;
using gourmet.Source.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace gourmet.Source
{
    public class Bot : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public Dictionary<IIngredient, int> Ingredients { get; private set; } = new Dictionary<IIngredient, int>();
        public Dictionary<IEmotion, float> Emotions { get; private set; } = new Dictionary<IEmotion, float>();
        private OppositeFinder finder = new OppositeFinder();
        public Bot()
        {
            Status = "Ready";
        }
        public void CalculateEmotions()
        {
            Emotions.Clear();
            foreach(var ingredient in Ingredients)
            {
                foreach(var emotion in ingredient.Key.Emotions)
                {
                    if (Emotions.ContainsKey(emotion.Key))
                    {

                        //float coef = 5f - Emotions[emotion.Key];
                        //coef /= 5;

                        float coeff = emotion.Value / ingredient.Value;
                        // float coeff = coef * emotion.Value;
                        Emotions[emotion.Key] += coeff;
                        //Emotions[emotion.Key] /= ingredient.Value;
                    }
                    else
                    {
                        Emotions.Add(emotion.Key, ingredient.Value * emotion.Value);
                        //Emotions[emotion.Key] /= ingredient.Value;
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < Ingredients.Count; i++)
            {
                var ingredient1 = Ingredients.ElementAt(i);
                int ingX = (int)Enum.Parse(typeof(IngredientList), Ingredients.ElementAt(i).Key.GetType().Name);
                for (int j = 0; j < Ingredients.Count; j++)
                {
                    if (i == j) continue;

                    var ingredient2 = Ingredients.ElementAt(j);
                    int ingY = (int)Enum.Parse(typeof(IngredientList), Ingredients.ElementAt(j).Key.GetType().Name);
                    int coeff = finder.Matrix[ingX, ingY];
                    Console.WriteLine("COEFF => " + coeff);
                    if (coeff == 1)
                        for(int x = 0; x < Emotions.Count; x++)
                        {
                            var emotion = Emotions.ElementAt(x).Key;
                            if(emotion.IsPositive == true)
                            {
                                Console.WriteLine($"{ingredient1.Key.Name} is compatible with {ingredient2.Key.Name}");
                                Emotions[emotion] /= 0.7f;
                            }
                            else if(emotion.IsPositive == false)
                            {
                                Console.WriteLine($"{ingredient1.Key.Name} is NOT compatible with {ingredient2.Key.Name}");
                                Emotions[emotion] *= 0.7f;
                            }
                        }
                    else if(coeff == -1)
                        for (int x = 0; x < Emotions.Count; x++)
                        {
                            var emotion = Emotions.ElementAt(x).Key;
                            if (emotion.IsPositive == true)
                            {
                                Emotions[emotion] *= 0.7f;
                            }
                            else if (emotion.IsPositive == false)
                            {
                                Emotions[emotion] /= 0.7f;
                            }
                        }
                }
            }
            //var emotions = Emotions.OrderByDescending(i => i.Value).Take(4);

            float max = Emotions.Max(i => i.Value);
            bool? isPositive = true;
            foreach(var emotion in Emotions.OrderBy(s => s.Value))
            {
                isPositive = emotion.Key.IsPositive;
            }

            foreach (var emotion in Emotions)
            {
                float emo;
            
                emo = emotion.Value / max * 10;
                if (emo.Equals(10f))
                    emo /= (float)(new Random().NextDouble() +1);
                string text = emo.ToString();
                if(text.Length > 6)
                    text = text.Substring(0, 6);
                sb.AppendLine(emotion.Key.Name+ " => " + text);
            }
            Status = sb.ToString();
        }

        public void Add(IIngredient ingredient)
        {
            if(Ingredients.ContainsKey(ingredient))
            {
                Ingredients[ingredient]++;
            }
            else
            {
                Ingredients.Add(ingredient, 1);
            }
        }

        public void Clear()
        {
            Emotions.Clear();
            Ingredients.Clear();
            Status = "Ready";
        }
        public void Delete(string text)
        {
            foreach (var item in Ingredients)
            {
                if (text.Contains(item.Key.Name))
                {
                    Ingredients.Remove(item.Key);
                    break;
                }
            }
        }

    }
}
