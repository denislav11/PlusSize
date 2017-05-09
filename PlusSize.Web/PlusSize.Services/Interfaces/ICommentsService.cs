using PlusSize.Models.BindingModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusSize.Services.Interfaces
{
    public interface ICommentsService
    {
        void Add(int id, AddCommentBm bm);
    }
}
