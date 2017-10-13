using System.Web.Mvc;

namespace RealEstates.Utils
{
	public static class TempDataCommunicates
	{
		public static void WarningInfo(this TempDataDictionary tempData, string message)
		{
			tempData[TempDataTypes.Warning] = message;
		}

		public static void SuccessInfo(this TempDataDictionary tempData, string message)
		{
			tempData[TempDataTypes.Success] = message;
		}
	}

	public static class TempDataTypes
	{
		public static string Success = "SuccessMessage";
		public static string Warning = "WarningMessage";
	}
}