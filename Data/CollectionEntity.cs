namespace Course_Project.Data;

public class CollectionEntity
{
    public long  Id { get; set; }
    public string Name { get; set; }

    public long TopicId { get; set; }
        
    public string  Description { get; set; }

    public long  UserId { get; set; }

    public string  Imgae_url { get; set; }
}
