namespace Course_Project.Data;

public class CommentEntity
{
    public long  Id { get; set; }

    public long UserId { get; set; }

    public long ItemId { get; set; }

    public string CommentText { get; set; }
}
