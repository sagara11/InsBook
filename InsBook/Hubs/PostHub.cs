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
            int session_userId = Convert.ToInt32(Context.QueryString["session_userId"]);
            var like = new PostController().LikePost(postId, status, session_userId);
            if (like)
            {
                Clients.All.LikePost(postId, status);
            }
        }
        public void CommentPost(Int64 postId, string content, Int64 parent_id)
        {
            int session_userId = Convert.ToInt32(Context.QueryString["session_userId"]);
            var comment = new PostController().CommentPost(postId, content, parent_id, session_userId);
            if (comment != null)
            {
                Clients.All.CommentPost(comment);
            }
        }
        public void ShowListLike(Int64 postId)
        {
            var listlike = new PostController().GetListLikePost(postId);
            if (listlike.Count > 0)
            {
                Clients.All.ShowListLike(listlike, postId);
            }
        }
        public void DeletePost(Int64 postId, Int32 userId)
        {
            var check = new PostController().DeletePost(postId, userId);
            if (check)
            {
                Clients.All.DeletePost(postId);
            }
        }
    }
}