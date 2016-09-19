using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebPinterest.Models;

namespace WebPinterest.DAL
{
    public class PinterestInitializer : DropCreateDatabaseAlways<PinterestContext>
    {
        protected override void Seed(PinterestContext context)
        {
            var users = new List<User>()
            {
                new User() { Nickname="anna", Location="Dublin", Email="anna@fesb.hr", UserPhoto="slika" },
                new User() { Nickname="John", Location="Amsterdam", Email="john@fesb.hr", UserPhoto="slika" }
            };
            
            

            var tags = new List<Tag>()
            {
                new Tag() { TagName = "Animals"},
                new Tag() { TagName = "DIY" },
                new Tag() { TagName = "Films" }
            };
            

            var comments = new List<Comment>()
            {
                new Comment() { Text = "kom", Vrijeme = DateTime.Now, User = users.ElementAt(0)},
                new Comment() { Text = "kome", Vrijeme = DateTime.Now,User = users.ElementAt(1)},
                new Comment() { Text = "komen", Vrijeme = DateTime.Now, User = users.ElementAt(0)},
                new Comment() { Text = "koment", Vrijeme = DateTime.Now, User = users.ElementAt(0)}
            };
            

            var pins = new List<Pin>()
            {
                new Pin() { Title="Bernese Mountain Dogs", Text = "They are absolutely adorable!", Picture="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRMnoLCElHpVXZAq4LsWPrUOklrI1fZpdKa6Mm-0lZVq65Q8jOFQg", Tags =new List <Tag> { tags.ElementAt(0)}, UserCreator = users.ElementAt(0),Comments= new List<Comment> { comments.ElementAt(0)}},
                new Pin() { Title="DIY", Text = "nesto", Picture="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcT4sIkACqM7ySMvyx1xaEUuHl0BGcujK6jGclYALgOGOj4WKA9xXg", Tags = new List <Tag> { tags.ElementAt(1)},  UserCreator = users.ElementAt(0), Comments= new List<Comment> { comments.ElementAt(1),comments.ElementAt(3)} },
                new Pin() { Title="Stranger Things", Text = "I love this show!", Picture="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcR4u3coCkTbMItIs_OCGL7TXFlXTD8zF_V4mBSaN44plDGXF5dmAw", Tags = new List <Tag> { tags.ElementAt(2)}, UserCreator = users.ElementAt(1),Comments= new List<Comment> { comments.ElementAt(2) } }
            };
            

            var likes = new List<Like>()
            {
                new Like() { Pin = pins.ElementAt(0), Value = true },
                new Like() { Pin = pins.ElementAt(0), Value = false },
                new Like() { Pin = pins.ElementAt(1), Value = true },
            };
            

            users.ForEach(user => context.Users.Add(user));
            tags.ForEach(tag => context.Tags.Add(tag));
            comments.ForEach(comment => context.Comments.Add(comment));
            pins.ForEach(pin => context.Pins.Add(pin));
            likes.ForEach(like => context.Likes.Add(like));

            context.SaveChanges();

            base.Seed(context);
        }
    }
}