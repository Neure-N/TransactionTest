using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

var entities = new List<Entity>();

app.MapGet("insert", (string data) =>
{
    var parsedEntity = JsonConvert.DeserializeObject<EntityParsing>(data);

    entities.Add(parsedEntity);

    return "Data added.";
});

app.MapGet("get", (string id) =>
{
    var entity = entities.FirstOrDefault(n => n.Id == Guid.Parse(id));

    return JsonConvert.SerializeObject(entity);
});

app.Run();

public class Entity
{
    public Guid Id { get; set; }
    public DateTime OperationDate { get; set; }
    public decimal Amount { get; set; }
    public Entity()
    {
        Id = Guid.NewGuid();
        OperationDate = DateTime.Now;
    }
}

public class EntityParsing : Entity
{
    [JsonProperty(PropertyName = "OperationDate")]
    public string? OperationDateString { get; set; }
}
