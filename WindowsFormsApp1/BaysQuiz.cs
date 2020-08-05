using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace WindowsFormsApp1
{
    public partial class BaysQuiz : Form
    {
        public BaysQuiz()
        {
            InitializeComponent();

        }

        //Function to determine if word is palindrome
        public static bool checkPalin(string word)
        {
            int n = word.Length;
            word = word.ToLower();
            for (int i = 0; i < n; i++, n--)
            {
                if (word[i] != word[n - 1])
                {
                    return false;
                }
            }
            return true;
        }
        //Function to determine if sentence is palindrome
        public static bool checkPalinSent(string sentence)
        {   // remove capitalization, remove spaces and commas
            string s = sentence.ToLower();
            sentence = Regex.Replace(""," ", ",");
            int x = sentence.Length;
            for (int i = 0; i < x; i++, x--)
            {
                if (sentence[i] != sentence[x- 1])
                {
                    return false;
                }
            }
            return true;
        }
            // Function to count palindrome words  
            public static int countPalin(string str)
        {
            int count = 0;
            string[] words = str.Split(' ');
            

            foreach (var word in words)
            {
                if ((word != "") && (checkPalin(word)))
                {
                    count++;
                
                }
            }
            return count;
  
        }
        //Function to count palindrome sentences
        public static int countPalinSent(string str)
        {
            // split input by sentences
            int count = 0;
            string[] sentences = str.Split('!', '.', '?');
            
           
            foreach (string sentence in sentences)
            {
                if ((sentence != "") && (checkPalinSent(sentence)))
                {
                    count++;

                }
            }
            return count;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //code to clear results of rtb and txtb
            richTextBox1.Clear();
            richTextBox1.SelectionStart = 0;
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // pulls in input from textbox
            string[] words = textBox1.Text.Split(' ');
            foreach (string word in words)
            {
                int startindex = 0;
                while (startindex < richTextBox1.TextLength)
                {
                    int wordstartIndex = richTextBox1.Find(word, startindex, RichTextBoxFinds.None);
                    if (wordstartIndex != -1)
                    {
                        // Highlights words in textbox based on search term (can use letter or full words)
                        richTextBox1.SelectionStart = wordstartIndex;
                        richTextBox1.SelectionLength = word.Length;
                        richTextBox1.SelectionBackColor = Color.Yellow;

                    }
                    
                    else
                        break;
                    startindex = richTextBox1.Text.IndexOf(textBox1.Text, startindex) + 1;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text;
            var result = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .GroupBy(r => r, StringComparer.InvariantCultureIgnoreCase)
                    .Select(grp => new
                    {
                        Word = grp.Key,
                        Count = grp.Count()
                    });
            // split string into words by space and remove empty entries. This also will then count and group words.
            richTextBox1.Clear();
            foreach (var item in result)
            
                {
                    richTextBox1.AppendText((Environment.NewLine+"Word: "+ item.Word +"\t"+ "Count " + item.Count).ToString());

                } 
        }

        private void button1_Click(object sender, EventArgs e)
            //code to output palindrome word checker
        {
            string inputpalindrome = richTextBox1.Text;
            richTextBox1.Clear();
            richTextBox1.AppendText("There are " + countPalin(inputpalindrome).ToString() + " palindrome words in the above input.");
        }

        private void button5_Click(object sender, EventArgs e)
        //code to output palindrome sentence checker
        {
            string inputpalindrome = richTextBox1.Text;
            richTextBox1.Clear();
            richTextBox1.AppendText("There are " + countPalinSent(inputpalindrome).ToString() + " palindrome sentences in the above input.");
        }
    }
}
        
    

    
        
    
