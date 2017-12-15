using gourmet.Source;
using gourmet.Source.Helpers;
using gourmet.Source.Models.Abstract;
using gourmet.Source.Models.Concrete.Ingredients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gourmet
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            
            LblStatus.DataBindings.Add(new Binding("Text", bot, "Status"));
            BtnOnion.Click += Btn_Click;
            BtnAvocado.Click += Btn_Click;
            BtnBanana.Click += Btn_Click;
            BtnChilli.Click += Btn_Click;
            BtnEgg.Click += Btn_Click;
            BtnFlour.Click += Btn_Click;
            BtnMacaroni.Click += Btn_Click;
            BtnChocolate.Click += Btn_Click;
            BtnOrange.Click += Btn_Click;
            BtnRedMeat.Click += Btn_Click;
            BtnSalmon.Click += Btn_Click;
            BtnSausage.Click += Btn_Click;
            BtnTomato.Click += Btn_Click;
            BtnVegetableOil.Click += Btn_Click;
            BtnWalnuts.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var ingredient = Assembly.GetExecutingAssembly().CreateInstance("gourmet.Source.Models.Concrete.Ingredients."+btn.Tag) as IIngredient;
            bot.Add(ingredient);
            LBoxIngredients.Items.Clear();
            foreach (var item in bot.Ingredients)
            {
                LBoxIngredients.Items.Add(item.Key + " => " + item.Value);
            }
        }

        private Bot bot { get; set; } = new Bot();
        private void MainForm_Load(object sender, EventArgs e)
        {
            BtnOnion.BackgroundImage = IconFinder.GetIcon(new Onion());
            BtnAvocado.BackgroundImage = IconFinder.GetIcon(new Avocado());
            BtnBanana.BackgroundImage = IconFinder.GetIcon(new Banana());
            BtnChilli.BackgroundImage = IconFinder.GetIcon(new Chilli());
            BtnEgg.BackgroundImage = IconFinder.GetIcon(new Egg());
            BtnFlour.BackgroundImage = IconFinder.GetIcon(new Flour());
            BtnMacaroni.BackgroundImage = IconFinder.GetIcon(new Macaroni());
            BtnChocolate.BackgroundImage = IconFinder.GetIcon(new MilkChocolate());
            BtnOrange.BackgroundImage = IconFinder.GetIcon(new Orange());
            BtnRedMeat.BackgroundImage = IconFinder.GetIcon(new RedMeat());
            BtnSalmon.BackgroundImage = IconFinder.GetIcon(new Salmon());
            BtnSausage.BackgroundImage = IconFinder.GetIcon(new Sausage());
            BtnTomato.BackgroundImage = IconFinder.GetIcon(new Tomato());
            BtnVegetableOil.BackgroundImage = IconFinder.GetIcon(new VegetableOil());
            BtnWalnuts.BackgroundImage = IconFinder.GetIcon(new Walnuts());
        }

        private void BtnOnion_Click(object sender, EventArgs e)
        {
            bot.Add(new Onion());
            LBoxIngredients.Items.Clear();
            foreach(var item in bot.Ingredients)
            {
                LBoxIngredients.Items.Add(item.Key + " => " + item.Value);
            }
        }

        private void LBoxIngredients_MouseUp(object sender, MouseEventArgs e)
        {
            //if(e.Button == MouseButtons.Right)
            //{
            //    if(LBoxIngredients.SelectedItems.Count > 0)
            //    {
            //        CONTEXT.Show();
            //    }
            //}
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in LBoxIngredients.SelectedIndices)
            {
                bot.Delete(LBoxIngredients.Items[(int)item].ToString());
                LBoxIngredients.Items.RemoveAt((int)item);
            }
        }

        private void BtnFeed_Click(object sender, EventArgs e)
        {
            if(LBoxIngredients.Items.Count >= 3)
            bot.CalculateEmotions();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            LBoxIngredients.Items.Clear();
            bot.Clear();
        }
    }
}
