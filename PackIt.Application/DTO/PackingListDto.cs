namespace PackIt.Application.DTO;

public class PackingListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public LocalizationDto Localization { get; set; }
    public PackingItemDto PackingItem { get; set; }
}
