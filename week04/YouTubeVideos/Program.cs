using System;
using System.Collections.Generic; 

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Video video1 = new Video("Video 1", "Author 1", 300);
        video1.AddComment(new Comment("John Doe", "Great video!"));
        video1.AddComment(new Comment("Jane Doe", "I loved it!"));
        video1.AddComment(new Comment("Bob Smith", "Excellent!"));

        Video video2 = new Video("Video 2", "Author 2", 240);
        video2.AddComment(new Comment("Alice Johnson", "Good job!"));
        video2.AddComment(new Comment("Mike Brown", "Well done!"));
        video2.AddComment(new Comment("Emily Davis", "Fantastic!"));

        Video video3 = new Video("Video 3", "Author 3", 180);
        video3.AddComment(new Comment("Sarah Taylor", "Nice video!"));
        video3.AddComment(new Comment("David Lee", "Good work!"));
        video3.AddComment(new Comment("Rebecca Hall", "Excellent video!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Comment Count: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"  {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

