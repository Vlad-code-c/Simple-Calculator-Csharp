using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {

    private static String resultText = "0";
    private static String elem1 = "";
    private static char symb = ' ';
    

    public Form1()
    {
      this.KeyPreview = true;
      this.KeyDown += new KeyEventHandler(Form1_KeyDown);
      InitializeComponent();
    }



    private void button0_Click(object sender, EventArgs e)
    {
      addNumber(0);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      addNumber(1);
    }
        
    private void button2_Click(object sender, EventArgs e)
    {
      addNumber(2);
    }
    
    private void button3_Click(object sender, EventArgs e)
    {
      addNumber(3);
    }
          
    private void button4_Click(object sender, EventArgs e)
    {
      addNumber(4);
    }
    
    private void button5_Click(object sender, EventArgs e)
    {
      addNumber(5);
    }
        
    private void button6_Click(object sender, EventArgs e)
    {
      addNumber(6);
    }
    
    private void button7_Click(object sender, EventArgs e)
    {
      addNumber(7);
    }
    
    private void button8_Click(object sender, EventArgs e)
    {
      addNumber(8);
    }
    
    private void button9_Click(object sender, EventArgs e)
    {
      addNumber(9);
    }

    
    
    

    private void button_plus_minus_Click(object sender, EventArgs e)
    {
      plusMinus();
    }

    private void button_dot_Click(object sender, EventArgs e)
    {
      addDot();
    }

    private void button_C_Click(object sender, EventArgs e)
    {
      resultText = "0";
      updateResult();
    }

    private void button_backspace_Click(object sender, EventArgs e)
    {
      deleteLast();
    }
    


    private void button_percent_Click(object sender, EventArgs e)
    {
      performOperation('%');
    }

    private void button_plus_Click(object sender, EventArgs e)
    {
      performOperation('+');
    }

    private void button_minus_Click(object sender, EventArgs e)
    {
      performOperation('-');
    }

    private void button_multiply_Click(object sender, EventArgs e)
    {
      performOperation('x');
    }
    
    private void button_divide_Click(object sender, EventArgs e)
    {
      performOperation('/');
    }


    private void button_equal_Click(object sender, EventArgs e)
    {
      equalShowResult();
    }



    private void Form1_KeyDown(object sender, KeyEventArgs e)    
    {

      switch (e.KeyCode)
      {
        case Keys.D0 :
          button0_Click(null, null);
          break;
        
        case Keys.D1 :
          button1_Click(null, null);
          break;
        
        case Keys.D2 :
          button2_Click(null, null);
          break;
        
        case Keys.D3 :
          button3_Click(null, null);
          break;
        
        case Keys.D4 :
          button4_Click(null, null);
          break;
        
        case Keys.D5 :
          button5_Click(null, null);
          break;
        
        case Keys.D6 :
          button6_Click(null, null);
          break;
        
        case Keys.D7 :
          button7_Click(null, null);
          break;
        
        case Keys.D8 :
          button8_Click(null, null);
          break;
        
        case Keys.D9 :
          button9_Click(null, null);
          break;
        
        
        //Backspace
        case Keys.Back :
          button_backspace_Click(null, null);
          break;
        
        //  /
        case Keys.Divide :
          button_divide_Click(null, null);
          break;

        // *
        case Keys.Multiply :
          button_multiply_Click(null, null);
          break;

        // -
        case Keys.OemMinus :
          button_minus_Click(null, null);
          break;

        // +
        case Keys.Oemplus :
          button_plus_Click(null, null);
          break;
        
        // case Keys.Enter :
        //   button_equal_Click(null, null);
        //   break;

      }
    }




    private void equalShowResult()
    {
      performOperation(symb);
      resultText = elem1.Split(' ')[0];
      elem1 = "";
      symb = ' ';
      
      updateResult();
      updateSubResult();
    }


    private void performOperation(char symb_)
    {
      if (resultText.Equals("0"))
      {
        symb = symb_;
      } 
      else if (elem1 == "")
      {
        elem1 = resultText;
        symb = symb_;
        resultText = "0";
        
      }
      else
      {
        switch (symb_)
        {
          case '+' :
            elem1 = (float.Parse(elem1) + float.Parse(resultText)).ToString();
            break;
          
          case '-' :
            elem1 = (float.Parse(elem1) - float.Parse(resultText)).ToString();
            break;
          
          case 'x' :
            elem1 = (float.Parse(elem1) * float.Parse(resultText)).ToString();
            break;

          case '%':
            elem1 = (float.Parse(elem1) % float.Parse(resultText)).ToString();
            break;    
            
          case '/' :
            if (resultText.Equals("0"))
            {
              MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButtons.OK);
            }
            else
            {
              elem1 = (float.Parse(elem1) / float.Parse(resultText)).ToString();
            }
            break;
        }
        
        resultText = "0";
        symb = ' ';
      }

      updateResult();
      updateSubResult();
    }
    

    private void deleteLast()
    {
      if (resultText.Length >= 2)
      {
        resultText = resultText.Substring(0, resultText.Length - 1);
      } 

      else
      {
        resultText = "0";
      }

      updateResult();
    }

    private void addDot()
    {
      if (!resultText.Contains("."))
      { 
        resultText += ".";
      }
    }

    private void plusMinus()
    {
      resultText = (-1 * double.Parse(resultText)).ToString();
      updateResult();
    }

    
    private void addNumber(int num)
    {

      if (double.Parse(resultText) > 99_999_999)
      {
        MessageBox.Show("Valoarea maxima este 99_999_999!", "Eroare", MessageBoxButtons.OK);
      }
      else
      {

        resultText = double.Parse(resultText + num).ToString();
        
        updateResult();
      }
      
    }

    
    private void updateResult()
    {
      result.Text = resultText;
    }

    private void updateSubResult()
    {
      subResult.Text = elem1 + " " + symb.ToString();
    }
    
  }
}
