using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AesCryptHelper
{
    /// <summary>
    /// 字串加密(非對稱式)
    /// </summary>
    /// <param name="SourceStr">加密前字串</param>
    /// <param name="CryptoKey">加密金鑰</param>
    /// <returns>加密後字串</returns>
    public static string aesEncryptBase64(string SourceStr, string CryptoKey)
    {
        string encrypt = "";
        try
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
            byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
            aes.Key = key;
            aes.IV = iv;

            byte[] dataByteArray = Encoding.UTF8.GetBytes(SourceStr);
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(dataByteArray, 0, dataByteArray.Length);
                cs.FlushFinalBlock();
                encrypt = Convert.ToBase64String(ms.ToArray());
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return encrypt;
    }

    /// <summary>
    /// 字串解密(非對稱式)
    /// </summary>
    /// <param name="SourceStr">解密前字串</param>
    /// <param name="CryptoKey">解密金鑰</param>
    /// <returns>解密後字串</returns>
    public static string aesDecryptBase64(string SourceStr, string CryptoKey)
    {
        string decrypt = "";
        try
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();

            byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
            byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
            aes.Key = key;
            aes.IV = iv;

            byte[] dataByteArray = Convert.FromBase64String(SourceStr);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    decrypt = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return decrypt;
    }

    /// <summary>
    /// 字串加密(非對稱式)
    /// </summary>
    /// <param name="SourceStr">加密前字串</param>
    /// <param name="CryptoKey">加密金鑰</param>
    /// <returns>加密後字串</returns>
    public static string aesEncryptBase64WithReplace(string SourceStr, string CryptoKey)
    {
        string encrypt = "";
        try
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
            byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
            aes.Key = key;
            aes.IV = iv;

            byte[] dataByteArray = Encoding.UTF8.GetBytes(SourceStr);
            using (MemoryStream ms = new MemoryStream())
            using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(dataByteArray, 0, dataByteArray.Length);
                cs.FlushFinalBlock();
                encrypt = Convert.ToBase64String(ms.ToArray()).TrimEnd('=').Replace('+', '-').Replace('/', '_');
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return encrypt;
    }

    /// <summary>
    /// 字串解密(非對稱式)
    /// </summary>
    /// <param name="SourceStr">解密前字串</param>
    /// <param name="CryptoKey">解密金鑰</param>
    /// <returns>解密後字串</returns>
    public static string aesDecryptBase64WithReplace(string SourceStr, string CryptoKey)
    {
        string decrypt = "";
        try
        {
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();

            string newSourceStr = SourceStr
    .Replace('_', '/').Replace('-', '+');
            switch (SourceStr.Length % 4)
            {
                case 2: newSourceStr += "=="; break;
                case 3: newSourceStr += "="; break;
            }

            byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
            byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(CryptoKey));
            aes.Key = key;
            aes.IV = iv;

            byte[] dataByteArray = Convert.FromBase64String(newSourceStr);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    decrypt = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return decrypt;
    }
}