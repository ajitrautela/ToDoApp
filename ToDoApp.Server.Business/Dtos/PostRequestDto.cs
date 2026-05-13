namespace ToDoApp.Server.Business.Dtos
{
    public class PostRequestDto
    {
        public PostRequestDto(string itemName)
        {
            ItemName = itemName;
        }
        public string? ItemName { get; set; }
    }
}
