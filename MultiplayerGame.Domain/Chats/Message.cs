using CSharpFunctionalExtensions;

namespace MultiplayerGame.Domain.Chats
{
    public class Message : Entity<Guid>
    {
        public string From { get; private set; }

        public string Text { get; private set; }

        public DateTimeOffset SentDateTime { get; private set; }

        private Message(Guid id, string from, string text, DateTimeOffset sentDateTime)
        {
            Id = id;
            From = from;
            Text = text;
            SentDateTime = sentDateTime;
        }

        #region EF
        /// <summary>
        /// For Entity Framework
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Message()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            
        }
        #endregion

        public static Message Create(string from, string text, DateTimeOffset sentDateTime)
        {
            return new Message(Guid.NewGuid(), from, text, sentDateTime);
        }
    }
}
