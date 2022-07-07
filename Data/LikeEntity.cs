namespace Course_Project.Data;

public class LikeEntity
{
    public long Id { get; set; }

    public long  UserId { get; set; }

    public long  ItemId { get; set; }

    public bool Status { get; set; }

}
