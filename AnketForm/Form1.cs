using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace AnketForm
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string email = textBoxEmail.Text;
            string ageText = textBoxAge.Text;
            string country = textBoxCountry.Text;
            int age;
            if (string.IsNullOrWhiteSpace(ageText) 
                ||
                !int.TryParse(ageText, out age))
            {
                age = -1;
            }

           
            if (string.IsNullOrWhiteSpace(name) 
                ||
                string.IsNullOrWhiteSpace(surname) 
                ||
                string.IsNullOrWhiteSpace(email)
                || 
                string.IsNullOrWhiteSpace(country))
            {
                MessageBox.Show("Some gaps are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            Forums forumobj = new Forums(name, surname, email, age, country);


            string json = JsonConvert.SerializeObject(forumobj);

            
            string filePath = name + ".json";

            
            File.WriteAllText(filePath, json);
            MessageBox.Show("File Add Succsesfully", "File", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            textBoxName.Clear();
            textBoxSurname.Clear();
            textBoxEmail.Clear();
            textBoxAge.Clear();
            textBoxCountry.Clear();

        }
    }
    public class Forums
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }

        public Forums(string name, string surname, string email, int age, string country)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Age = age;
            Country = country;
        }
    }
}
