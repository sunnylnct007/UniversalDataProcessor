﻿namespace UniversalDataProcessorService.FileHandler
{
    public interface IFileGenerator<T>
    {
        MemoryStream GenerateCsvFile(IList<T> lst);
    }
}
