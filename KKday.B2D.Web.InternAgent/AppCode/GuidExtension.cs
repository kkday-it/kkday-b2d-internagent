using System;
namespace InternAgent.AppCode
{
    public static class GuidExtension
    {
        public static string Shrink(this Guid target)
        {
            string base64 = Convert.ToBase64String(target.ToByteArray()); 
            string encoded = base64.Replace("/", "_").Replace("+", "-"); 
            return encoded.Substring(0, 22);
        }
    }
}
