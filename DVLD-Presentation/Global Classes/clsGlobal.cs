using DVLD_Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Global_Classes
{
    internal class clsGlobal
    {

        public static clsUser CurrentUser;
        public static string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
        public static string UsernameValue = "Username",  PasswordValue = "Password";

        /*
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            try
            {
                //this will get the current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                // Define the path to the text file where you want to save the data
                string filePath = currentDirectory + "\\Credentialdata.txt";

                //incase the username is empty, delete the file
                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;

                }

                // concatonate username and passwrod withe seperator.
                string dataToSave = Username + "#//#" + Password;

                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file
                    writer.WriteLine(dataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath = currentDirectory + "\\Credentialdata.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }
        */
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                // If either Username or Password is empty, remove the saved credential.
                RemoveCredentials();
                return false;
            }

            try
            {
                // Encrypt the password
                string encryptedPassword = clsCryptography.EncryptPassword(Password);
                

                // Save to Registry as a Base64 string
                Registry.SetValue(keyPath, UsernameValue, Username, RegistryValueKind.String);
                Registry.SetValue(keyPath, PasswordValue, encryptedPassword, RegistryValueKind.String);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
            
            return true;

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.

            try
            {
                // Read the value from the Registry
                Username = Registry.GetValue(keyPath, UsernameValue, null) as string;
                string encryptedPasswordBase64 = Registry.GetValue(keyPath, PasswordValue, null) as string;


                if (!string.IsNullOrEmpty(Username) || !string.IsNullOrEmpty(encryptedPasswordBase64))
                {
                    string decryptedPassword = clsCryptography.DecryptPassword(encryptedPasswordBase64);
                    if (decryptedPassword != null)
                    {
                        Password = decryptedPassword;
                        return true;
                    }
                }

                Username = "";
                Password = "";
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        private static void RemoveCredentials()
        {

            try
            {
                Registry.SetValue(keyPath, UsernameValue, string.Empty, RegistryValueKind.String);
                Registry.SetValue(keyPath, PasswordValue, string.Empty, RegistryValueKind.String);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

    }
}
