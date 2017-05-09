using PlusSize.Models.BindingModels.Comments;
using PlusSize.Models.EntityModels;
using PlusSize.Services.Interfaces;
using System;

namespace PlusSize.Services
{
    public class CommentsService : Service, ICommentsService
    {
        public void Add(int id, AddCommentBm bm)
        {
            Comment model = new Comment
            {
                DataAdded = DateTime.Now,
                Author = bm.Author,
                Content = bm.Content,
                Product = this.Context.Products.Find(id)
            };
            this.Context.Comments.Add(model);
            this.Context.SaveChanges();
        }
    }
}
