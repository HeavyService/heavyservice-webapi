namespace HeavyService.Application.Exeptions.Comments;

public class CommentNotFoundExeption : NotFoundExeption
{
    public CommentNotFoundExeption()
    {
        this.TitleMessage = "Comment not found!";
    }
}
