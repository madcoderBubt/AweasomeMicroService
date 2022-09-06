using Infrastructure.Extensions;

namespace LibraryService.Models;

public class BookTypeRef
{
    public BookTypeEnum TypeId { get; set; }
    public string TypeName { get; set; }
    public BookTypeRef(BookTypeEnum typeId)
    {
        TypeId = typeId;
        TypeName = TypeId.GetDescription();
    }
}
public enum BookTypeEnum
{
    General,
    ComputerScience,
    ScienceFiction,
    SceinceStudy,
    EngineeringStudy,
    ElectricalElectronicsStudy,
    BusinessStudy,
    EnglishStudy,
    ScienceTechnology,
    LifeStyle,
    SelfGrowth,
    HistoryCulture,
    LawStudy
}
