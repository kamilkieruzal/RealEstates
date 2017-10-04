using System.Text;

namespace RealEstates.Core.Utils
{
	public static class MD5Helper
	{
		public static string CalculateMD5Hash(string input)
		{
			var md5 = System.Security.Cryptography.MD5.Create();
			var inputBytes = Encoding.ASCII.GetBytes(input);
			var hash = md5.ComputeHash(inputBytes);
			var result = new StringBuilder();

			for (int i = 0; i < hash.Length; i++)
				result.Append(hash[i].ToString());

			return result.ToString();
		}
	}
}