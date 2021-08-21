using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace AppSecurity.Models 
{
    /// <summary>
    /// Encryption and Decryption Class
    /// </summary>
    public static class DataCryptor
    {
    /// <summary>
    /// 
    /// </summary>
        public static string CypherKey = "#CODERSTATION10122003#";

        //=========================================================================================================================================================================================

        /// <summary>
        /// Encryption
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static string Encode(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(CypherKey));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToEncrypt = UTF8.GetBytes(Message);
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            string Bes64Results = Convert.ToBase64String(Results);

            if (Bes64Results.EndsWith("=="))
               { Bes64Results = Bes64Results.Replace("==", "X2"); }
            else if (Bes64Results.EndsWith("="))
               { Bes64Results = Bes64Results.Replace("=", "X1"); }

            return Bes64Results;
        }


        //=========================================================================================================================================================================================

        /// <summary>
        /// Decryption
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>

        public static string Decode(string Message)
        { 
            if (Message.EndsWith("X2"))
             { Message = Message.Replace("X2", "=="); }
            else if (Message.EndsWith("X1"))
             { Message = Message.Replace("X1", "="); }

            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(CypherKey));

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
             
            byte[] DataToDecrypt = Convert.FromBase64String(Message);
            
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            catch (Exception) { Results = DataToDecrypt; }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return UTF8.GetString(Results);
        }

        //=========================================================================================================================================================================================
        /// <summary>
        /// String to Hex Conversion
        /// </summary>
        /// <param name="MyData"></param>
        /// <returns></returns>
        public static String String_ToHex(string MyData)
        { 
            Byte[] stringBytes = System.Text.Encoding.Unicode.GetBytes(MyData);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte bayt in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", bayt);
            }
            return sbBytes.ToString(); 
        }

        //=========================================================================================================================================================================================
        /// <summary>
        /// Hex To String Conversion
        /// </summary>
        /// <param name="MyData"></param>
        /// <returns></returns>
        public static String Hex_ToString(string MyData)
        {  int numberChars = MyData.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(MyData.Substring(i, 2), 16);
            }
            MyData = System.Text.Encoding.Unicode.GetString(bytes);
         return MyData.ToString();

          }
        //=========================================================================================================================================================================================
 


    }

}