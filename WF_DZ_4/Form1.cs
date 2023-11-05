using System.Linq.Expressions;
using System.Windows.Forms;

namespace WF_DZ_4
{
    public partial class Form1 : Form
    {
        private decimal totalIncome;
        private Product[] gasolines;
        private Product[] products;
        private Cart cart;
        public Form1()
        {
            InitializeComponent();
            gasolines = new Product[]
            {
                new Product{ Name="A-92",Price=46},
                new Product{ Name="A-95",Price=48},
                new Product{ Name="A-100",Price=52},
            };
            products = new Product[]
            {
                new Product{ Name="Хот-Дог",Price=25},
                new Product{ Name="Гамбургер",Price=40},
                new Product{ Name="Картопля фрі",Price=30},
                new Product{ Name="Кока-Кола",Price=15},
            };
            cart = new Cart();

            comboBox1.DataSource = gasolines;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Price";

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndex = 0;
            comboBox1_SelectedIndexChanged(comboBox1, EventArgs.Empty);

            textBox1.Text = products[0].Price.ToString();
            numericUpDown3.Value = 0;

            textBox2.Text = products[1].Price.ToString();
            numericUpDown4.Value = 0;

            textBox3.Text = products[2].Price.ToString();
            numericUpDown5.Value = 0;

            textBox4.Text = products[3].Price.ToString();
            numericUpDown6.Value = 0;

            numericUpDown1.ValueChanged += CalculateTotal;
            numericUpDown2.ValueChanged += CalculateTotal;
            numericUpDown3.ValueChanged += CalculateTotal;
            numericUpDown4.ValueChanged += CalculateTotal;

            checkBox1.CheckedChanged += CalculateTotal;
            checkBox2.CheckedChanged += CalculateTotal;
            checkBox3.CheckedChanged += CalculateTotal;
            checkBox4.CheckedChanged += CalculateTotal;

            numericUpDown1.ValueChanged += CalculateTotal1;
            numericUpDown2.ValueChanged += CalculateTotal1;

            radioButton1.CheckedChanged += (s, e) => CalculateTotal1(s, e);
            radioButton2.CheckedChanged += (s, e) => CalculateTotal1(s, e);

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                textBox5.Text = gasolines[comboBox1.SelectedIndex].Price.ToString();
                CalculateTotal(null, null);
            }
        }
        private void CalculateTotal(object sender, EventArgs e)
        {
            decimal total = 0;

            if (checkBox1.Checked)
            {
                total += Convert.ToDecimal(textBox1.Text) * numericUpDown3.Value;
            }

            if (checkBox2.Checked)
            {
                total += Convert.ToDecimal(textBox2.Text) * numericUpDown4.Value;
            }

            if (checkBox3.Checked)
            {
                total += Convert.ToDecimal(textBox3.Text) * numericUpDown5.Value;
            }

            if (checkBox4.Checked)
            {
                total += Convert.ToDecimal(textBox4.Text) * numericUpDown6.Value;
            }

            textBox6.Text = total.ToString();
        }
        private void CalculateTotal1(object sender, EventArgs e)
        {
            decimal price = Convert.ToDecimal(textBox5.Text);

            decimal total = 0;

            if (radioButton1.Checked)
            {
                numericUpDown2.ReadOnly = true;
                total = price * (decimal)numericUpDown1.Value;
                textBox7.Text = total.ToString();
            }
            else if (radioButton2.Checked)
            {
                numericUpDown1.ReadOnly = true;
                total = (decimal)numericUpDown2.Value / price;
                numericUpDown1.Value = (int)total;
                textBox7.Text = numericUpDown2.Value.ToString();
            }            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox6.Text, out decimal value6) && decimal.TryParse(textBox7.Text, out decimal value7))
            {
                decimal sum = value6 + value7;
                textBox8.Text = sum.ToString();
            }
        }

    }
}