namespace Library.API.DTOs.AuthorDtos
{
    // shared DTO for POST and GET actions
    public class AuthorDto : AuthorDtoBase
    {
        // null ID means author doesn't exist yet
        public int? Id { get; set; }
    }
}
