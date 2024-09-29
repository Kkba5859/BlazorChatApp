namespace BlazorChatApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public DateTime SentAt { get; set; }
        public int SenderId { get; set; }
        public ChatUser? Sender { get; set; }
    }
}
