namespace base_converter
{
    public partial class Form1 : Form
    {
        //Variables declaration
        private int inputBase;      // stores base of the input number
        private int outputBase;     // stores base of the requested number

        private string tempString;  // stores intermediate (base 10) number when converting from base different than 10
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            //App tries to parse input from textboxes as bases for given and requested number
            try
            {
                inputBase = int.Parse(baseFromTextBox.Text);
                outputBase = int.Parse(baseToTextBox.Text);
            } 
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            //Checks if given bases are legitimate
            if (outputBase == 1)
            {
                MessageBox.Show("1 is not a correct base");
                return;
            }
            else if (inputBase > 36 || outputBase > 36)
            {
                MessageBox.Show("Base can not exceed 36");
                return;
            }
            else
            {
                //Tries to convert the input number
                try
                {
                    if (inputBase == 10)
                    {
                        outputTextBox.Text = ConvertToBase(numTextBox.Text, outputBase);    // if the input number is in (10), app converts it straight to (outputBase)
                    }
                    else if (outputBase == 10)
                    {
                        outputTextBox.Text = ConvertToDecimal(numTextBox.Text, inputBase);  // if requested base is (10), app converts input number to (10)
                    }
                    else
                    {
                        tempString = ConvertToDecimal(numTextBox.Text, inputBase);          // if both requested and input base are different than (10), it has to be converted to (10) at first
                        outputTextBox.Text = ConvertToBase(tempString, outputBase);         // then it can be converted to (outputBase)
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private string ConvertToDecimal(string inputString, int inputBase) // Converts any base to decimal
        {
            //Variables declaration
            string outputString = "";   
            string wholePart = "";      // stores the whole part of input
            string fractionalPart = ""; // stores the fractional part of input
            double tempFloat = 0;       // used for intermediate calculations
            char baseChar = '0';        // used in converting from higher than (10)

            (wholePart, fractionalPart) = DivideIntoParts(inputString); // this method divides string into two parts by the decimal separator

            //App calculates the whole part of the requested number
            for (int i = 0; i < wholePart.Length; i++)
            {
                if (char.ToUpper(wholePart[i]) >= 'A')
                {
                    baseChar = '7'; // since 'A' has a ASCII value of 65, we need to subtract 55 from it, to get the correct decimal value, '7' has a ASCII value of 55
                }
                else
                {
                    baseChar = '0'; // same as before, but for digits lower than 10 it's simply '0';
                }
                tempFloat += (char.ToUpper(wholePart[i]) - baseChar) * Math.Pow(inputBase, wholePart.Length - i - 1);   // this intermediate number is calculated by subtracting casting a character into ascii value,
                                                                                                                        // then subtracting the correct ascii value from it and finally multiplying it by the correct
                                                                                                                        // power of 10, which in itself is calculated from digit's position
            }
            outputString = tempFloat.ToString();

            //Then it calculates the fractional part
            if (fractionalPart != "")               // if ther is any
            {
                tempFloat = 0;
                for (int i = 2; i < fractionalPart.Length; i++)
                {
                    if (char.ToUpper(fractionalPart[i]) >= 'A')
                    {
                        baseChar = '7';
                    }
                    else
                    {
                        baseChar = '0';
                    }
                    tempFloat += (char.ToUpper(fractionalPart[i]) - baseChar) * Math.Pow(inputBase, 1 - i);     // the only difference between whole and fractional parts lies in calculating the exponent
                                                                                                                // which has to be negative for the fractional part
                }
                outputString += tempFloat.ToString().Substring(1);  //the temporary number is added to the output string without the first 0
            }

            return outputString;
        }

        private string ConvertToBase(string inputString, int outputBase) // converts decimal to any base
        {
            //Variables declaration
            string outputString = "";
            string wholePart = "";      // stores the whole part of input
            string fractionalPart = ""; // stores the fractional part of input
            int quotient;               // used in calculating current digit
            int remainder;              // -------------||------------------
            float tempFloat;            // used in calculating fractional digits
            string tempString = "";     // stores fractional part of output
            char remainderOver9 = 'A';  // used in calculating digits higher than 9

            (wholePart, fractionalPart) = DivideIntoParts(inputString); // this method divides string into two parts by the decimal separator

            quotient = int.Parse(wholePart);

            if (quotient == 0)
            {
                outputString = "0"; // adds 0 in front of a fraction
            }

            while (quotient != 0)
            {
                remainderOver9 = 'A';
                quotient = Math.DivRem(quotient, outputBase, out remainder); // this method returns a quotient of division and also it's remainder in an output parameter
                if (remainder > 9)
                {
                    remainderOver9 += (char)(remainder - 10);       // if a digit is higher than 9, its value is converted to a letter by adding its ASCII value to the ASCII value of 'A'
                    outputString = remainderOver9 + outputString;   // then the digit is added to the front of the output string
                }
                else
                {
                    outputString = remainder.ToString() + outputString; // if remainder is lower than 9 it is simply added as is to the front of the output string
                }
            }

            if (fractionalPart != "") 
            { 
                tempFloat = float.Parse(fractionalPart);
                while (tempFloat != 0.0 && tempString.Length < 12) // fractional parts are limited to 12 characters
                {
                    remainderOver9 = 'A';
                    tempFloat *= outputBase;                                                // fractional digits are calculated by multiplying the input fractional part by the requested base
                    if (tempFloat >= 10)
                    {
                        remainderOver9 += (char)Math.Floor(tempFloat - 10);                 // the whole part of this calculation is added as the next fractional digit
                                                                                            // for digits > 9 its a letter calculated by adding its ASCII value to 'A'
                        tempString = tempString + remainderOver9;
                        tempFloat = float.Parse("0" + tempFloat.ToString().Substring(2));   // the whole part of this temporary number gets deleted
                                                                                            // then the process continues until the fractional part is zeroed
                    }
                    else
                    {
                        tempString = tempString + tempFloat.ToString()[0];
                        tempFloat = float.Parse("0" + tempFloat.ToString().Substring(1));
                    }
                    
                }
                outputString += ",";
                outputString += tempString;
            }

            return outputString;
        }

        private (string, string) DivideIntoParts(string inputString)    // returns a tuple of two strings originally separated by a comma in the input string
        {
            int decimalSeparatorPosition;
            string substring1 = "";
            string substring2 = "";

            if (inputString.IndexOf(",") != inputString.LastIndexOf(","))   // checks if there are more than one commas
            {
                MessageBox.Show("Input contains more than one separator");
                return (substring1, substring2);
            }
            else
            {
                decimalSeparatorPosition = inputString.IndexOf(",");        // if not, checks the index of the comma

                if (decimalSeparatorPosition == -1)                         // and if there is no commas, returns the entire input as a first string of the tuple
                {
                    substring1 = inputString;
                    substring2 = "";

                }
                else
                {
                    substring1 = inputString.Substring(0, decimalSeparatorPosition);            // this method returns a part of a string from [firstArgument] to [secondArgument]
                    substring2 = "0," + inputString.Substring(decimalSeparatorPosition + 1);    // or a part of the string from [argument] to the end
                }

                return (substring1, substring2);
            }
        }
    }
}
