using System.Collections.Generic;
using System.Linq;
using RealEstates.Core.Entities;
using RealEstates.Core.Contract;

namespace RealEstates.Infrastructure.Repositories
{
	public class MessageRepository : IMessageRepository
	{
		private RealEstatesContext realEstatesContext;
		
		public MessageRepository(RealEstatesContext realEstatesContext)
		{
			this.realEstatesContext = realEstatesContext;
		}

		public Message GetMessage(ulong messageId)
		{
			return realEstatesContext.Messages.Find(messageId);
		}

		public IList<Message> GetMessages()
		{
			return realEstatesContext.Messages.ToList();
		}

		public void SaveOrUpdateMessage(Message message)
		{
			var oldMessage = realEstatesContext.Messages.Find(message.Id);
			if (oldMessage == null)
				realEstatesContext.Entry(oldMessage).CurrentValues.SetValues(message);
			else
				realEstatesContext.Messages.Add(message);
			realEstatesContext.SaveChanges();
		}
	}
}
