namespace UniversalDataProcessorService.FileHandler
{
    public interface IFileReader<T>
    {
        IList<T> ReadFile(Stream stream);
    }
}
