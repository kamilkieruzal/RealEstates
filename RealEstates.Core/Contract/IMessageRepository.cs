using RealEstates.Core.Entities;
using System.Collections.Generic;

namespace RealEstates.Core.Contract
{
	public interface IMessageRepository
	{
		IList<Message> GetMessages();
		Message GetMessage(ulong messageId);
		void SaveOrUpdateMessage(Message message);
	}
}
