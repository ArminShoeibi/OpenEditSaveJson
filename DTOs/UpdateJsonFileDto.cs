using OpenEditSaveJson.ViewModels;

namespace OpenEditSaveJson.DTOs
{
    public record UpdateJsonFileDto : JsonFileViewModel
    {
        public string Content { get; init; }
    }
}
