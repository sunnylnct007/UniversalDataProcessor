namespace UniversalDataProcessorService.TableListBinder
{
    public interface IValueProvider
    {
        IEnumerable<IDictionary<string, object>> GetValues();

    }
}