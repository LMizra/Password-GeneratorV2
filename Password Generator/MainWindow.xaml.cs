using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Password_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int currentPasswordLength = 0;
        Random character = new Random();
        Random randomGeneratedPassword = new Random();

        private void passwordGenerator(int passwordLength)
        {
            string allCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnpoqrstuvwxyz!£$%^&*@?|,.:;{}";
            string randomPassword = "";

            for (int i = 0; i < passwordLength; i++)
            {
                int randomNum = character.Next(0, allCharacters.Length);
                randomPassword += allCharacters[randomNum]; // goes through the random characters and adds to the randomPassword empty string
            }
            passwordLabel.Content = randomPassword;
        }

        public MainWindow()
        {
            InitializeComponent();
            passwordLengthSlider.Minimum =  5;
            passwordLengthSlider.Maximum =  20;
            passwordGenerator(5);
        }

        private void copyPasswordButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText((string)passwordLabel.Content);
            MessageBox.Show("Password Successfully Copied");
        }

        private void passwordLengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PasswordLengthLabel.Content = "Password Length: " + passwordLengthSlider.Value.ToString("F0"); 
            //The ToString("F0") method call formats a numerical value as a string with zero decimal places.
            currentPasswordLength = (int)passwordLengthSlider.Value;
            passwordGenerator(currentPasswordLength);
            
            
        }

        private void generateRandomPasswordButton_Click(object sender, RoutedEventArgs e)
        {
           passwordLengthSlider.Value = randomGeneratedPassword.Next(5, 20);
           PasswordLengthLabel.Content = "Password Length: " + passwordLengthSlider.Value.ToString();
           passwordGenerator(currentPasswordLength);



        }
    }
}
