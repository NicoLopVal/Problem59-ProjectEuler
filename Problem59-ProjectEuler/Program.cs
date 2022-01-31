using System.Text;

string[] encryptedFile = File.ReadAllText(@"C:\Users\nikil\Documents\Developer\ProjectEuler\Problem59-ProjectEuler\p059_cipher.txt").Split(',');
char[] allowedChars = File.ReadAllText(@"C:\Users\nikil\Documents\Developer\ProjectEuler\Problem59-ProjectEuler\ValidChars.txt").ToCharArray();
char[] passwordChars = File.ReadAllText(@"C:\Users\nikil\Documents\Developer\ProjectEuler\Problem59-ProjectEuler\passwordChars.txt").ToCharArray();

for (int i = 0; i < passwordChars.Count(); i++)
{
    for (int j = 0; j < passwordChars.Count(); j++)
    {
        for (int k = 0; k < passwordChars.Count(); k++)
        {
            int counter = 0;
            string thisText = "";
            foreach(string encryptedChar in encryptedFile)
            {
                char encChar = Convert.ToChar(Convert.ToByte(int.Parse(encryptedChar)));
                char checkedChar = 'a';
                if(counter == 0)
                {
                    checkedChar = passwordChars[i];
                    counter++;
                }
                else if(counter == 1)
                {
                    checkedChar = passwordChars[j];
                    counter++;
                }
                else
                {
                    checkedChar = passwordChars[k];
                    counter = 0;
                }
                char newChar = Convert.ToChar((byte)(encChar ^ checkedChar));
                if (!allowedChars.Contains(newChar))
                {
                    break;
                }
                thisText += newChar;
            }
            if(thisText.Contains("the") || thisText.Contains("The"))
            {
                Console.WriteLine(passwordChars[i].ToString() + passwordChars[j].ToString() + passwordChars[k].ToString() + ": " + thisText);
                byte[] asciiBytes = Encoding.ASCII.GetBytes(thisText);
                int sum = 0;
                foreach(byte bte in asciiBytes)
                {
                    sum += Convert.ToInt32(bte);
                }
                Console.WriteLine("The answer is: " + sum);
            }
        }
    }
}