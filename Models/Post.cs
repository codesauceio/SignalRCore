namespace CoreWebTest.Models
{
    public class Post 
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Text { get; set; }

        public Post(){}

        public Post(int id, string userName, string text) {
            Id = id;
            UserName = userName;
            Text = text;
        }

    }
}
