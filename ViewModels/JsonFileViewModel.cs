namespace OpenEditSaveJson.ViewModels
{
    public record JsonFileViewModel
    {
        public string Name { get; init; }
        public string FullName { get; init; }
        public string Directory { get; init; }
    }
}
