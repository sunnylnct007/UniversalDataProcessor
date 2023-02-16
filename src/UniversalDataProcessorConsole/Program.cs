// See https://aka.ms/new-console-template for more information

using CommandLine;
using CsvHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Collections;
using UniversalDataProcessorModel;
using UniversalDataProcessorService;
using UniversalDataProcessorService.Cache;
using UniversalDataProcessorService.DataProcessor;
using UniversalDataProcessorService.Extract;

class Program
{
    static void Main(string[] args)
    {

        Parser.Default.ParseArguments<ProcessorOptions>(args)
            .WithParsed(RunDataLoad)
            .WithNotParsed(HandleParseError);
    }

    static void RunDataLoad(ProcessorOptions opts)
    {
        Task.WaitAll(GetDataLoadResult(opts));
    }

    static async Task GetDataLoadResult(ProcessorOptions opts)
    {
        var servicecollection = new ServiceCollection().AddLogging();
        servicecollection.RegisterDependency();
        try
        {
            var serviceProvider = BootStrapper.ServiceProvider;
            Log.Logger.Information(opts.ToString());

            var cachefacade = serviceProvider.GetService<ICacheFacade>();
            Log.Logger.Information("Started initializing cache");
            cachefacade.InitializeCache();
            Log.Logger.Information("Completed initializing cache");


            var extractfacade = serviceProvider.GetService<IExtractFactory>();
            extractfacade.GenerateExtract(opts.InputTransactionFile);
            var config = serviceProvider.GetService<IConfiguration>();
            

        }
        catch (Exception e)
        {
            Log.Error(e.Message);
        }

        finally
        {
            Log.Information("Shut down complete");
            Log.CloseAndFlush();

        }
    }

    static void HandleParseError(IEnumerable errs)
    {
        Console.WriteLine("Command Line parameters provided were not valid!");
    }

}
