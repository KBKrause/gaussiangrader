using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// This lovely class was written by Dave from daveoncsharp.com. 
/// It provides a hashing method used to protect text stored in databases.
/// </summary>
public class Hasher
{
    /// <summary>
    /// This method hashes the given text with 
    /// the SHA1CryptoServiceProvider.
    /// </summary>
    /// <param name="text">Text to hash</param>
    /// <returns>Hashed Value</returns>
    public static string HashString(string text)
    {
        // Create an instance of the SHA1 provider
        SHA1 sha = new SHA1CryptoServiceProvider();

        // Compute the hash 
        byte[] hashedData = sha.ComputeHash(Encoding.Unicode.GetBytes(text));

        StringBuilder stringBuilder = new StringBuilder();

        foreach (byte b in hashedData)
        {
            // Convert each byte to Hex
            stringBuilder.Append(String.Format("{0,2:X2}", b));
        }

        // Return the hashed value
        return stringBuilder.ToString();
    }
}