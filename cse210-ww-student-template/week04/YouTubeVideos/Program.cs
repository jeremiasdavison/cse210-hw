using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Learn C# Fast", "Jeremias Davison", 634);
        video1.AddComment(new Comment("Ana", "Great explanation, very clear!"));
        video1.AddComment(new Comment("Carlos", "Exactly what I needed, thanks."));
        video1.AddComment(new Comment("Marta", "Could you make one about OOP?"));

        Video video2 = new Video("Automation with n8n from Scratch", "Jeremias Davison", 912);
        video2.AddComment(new Comment("Pedro", "This looks very useful for my business."));
        video2.AddComment(new Comment("Lucia", "I didn't know this was possible, awesome."));
        video2.AddComment(new Comment("Sofia", "Good pace of explanation."));
        video2.AddComment(new Comment("Diego", "Does it work with Google Sheets too?"));

        Video video3 = new Video("Introduction to Abstraction in OOP", "Jeremias Davison", 480);
        video3.AddComment(new Comment("Valentina", "Now I understand the difference with encapsulation."));
        video3.AddComment(new Comment("Nicolas", "Very good example with the classes."));
        video3.AddComment(new Comment("Camila", "Thanks, this helped me with my assignment."));

        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}
