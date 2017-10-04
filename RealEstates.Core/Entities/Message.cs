using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstates.Core.Entities
{
	public class Message : EntityBase<int>
	{
		public int UserId { get; set; }
		public int SenderId { get; set; }
		public string MessageContent { get; set; }

		[ForeignKey("UserId")]
		public User User { get; set; }

		[ForeignKey("SenderId")]
		public User Sender { get; set; }
	}
}