using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsBook.Areas.Client.Controllers;
using Microsoft.AspNet.SignalR;

namespace InsBook.Hubs
{
    public class PostHub : Hub
    {
        public void LikePost(Int64 postId, bool status)
        {
            var like = new PostController().LikePost(postId, status);
            if (like)
            {
                Clients.All.LikePost(postId, status);
            }
        }
        public void CommentPost(Int64 postId, string content, Int64 parent_id)
        {
            var comment = new PostController().CommentPost(postId, content, parent_id);
            if (comment != null)
            {
                Clients.All.CommentPost(comment);
            }
        }
    }
}