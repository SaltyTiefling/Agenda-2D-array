using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda_2D_array
{
    public partial class Form1 : Form
    {
            string[,] weekAgenda = new string[23, 7];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 23; i++)
            {
                Label newLable = new Label();
                if (i < 10) newLable.Text = "0";
                newLable.Text += $"{i}:00";
                newLable.Width = 40;
                newLable.Height = 20;
                newLable.Location = new Point(10, 10 + newLable.Height * (i + 1));

                Controls.Add(newLable);

                for (int j = 0; j < 7; j++)
                {
                    TextBox newTextBox = new TextBox();
                    newTextBox.Width = 100;
                    newTextBox.Height = 20;
                    newTextBox.Location = new Point(50 + newTextBox.Width * j, 10 + newTextBox.Height * (i + 1));
                    newTextBox.Name = $"TbxField{i}-{j}";

                    newTextBox.Leave += new EventHandler(newTextBox_Leave);
                    Controls.Add(newTextBox);
                }

            }

        }

        private void newTextBox_Leave(object sender, EventArgs e)
        {
            var coords = (sender as TextBox).Name.Replace("TbxField", "").Split('-');
            int hour = int.Parse(coords[0]);
            int weekday = int.Parse(coords[1]);

            weekAgenda[hour, weekday] = (sender as TextBox).Text;
        }
    }
}
