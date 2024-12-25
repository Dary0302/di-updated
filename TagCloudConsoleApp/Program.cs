using Autofac;
using CommandLine;
using TagCloudConsoleApp;
using TagCloudConsoleApp.SettingsProvider;
using TagsCloudVisualization.Interfaces;
using TagsCloudVisualization.Models.Savers;
using TagsCloudVisualization.Models.Readers;
using TagsCloudVisualization.Models.Filters;
using TagsCloudVisualization.Models.Generators;
using TagsCloudVisualization.Models.CloudLayouters;
using TagsCloudVisualization.Models.Selectors;
using TagsCloudVisualization.Models.Visualizatiuons;
using TagsCloudVisualization.Settings;

var options = Parser.Default.ParseArguments<CommandLineOptions>(args).Value;
var client = new SettingsProvider(options);
var settings = client.GetSettings();
var builder = new ContainerBuilder();

RegisterServices(builder);
RegisterSettings(builder, settings);
RegisterFileReaders(builder);

var build = builder.Build();
var tagCloudImageGenerator = build.Resolve<TagCloudImageGenerator>();
tagCloudImageGenerator.GenerateCloud();

return;

void RegisterServices(ContainerBuilder containerBuilder)
{
    
    containerBuilder.RegisterType<FileReadersSelector>().AsSelf();
    containerBuilder.RegisterType<ArchimedeanSpiralPositionGenerator>().As<IPositionGenerator>().SingleInstance();
    containerBuilder.RegisterType<RectangleVisualizatiuon>().As<IRectangleDraftsman>().SingleInstance();
    containerBuilder.RegisterType<CircularCloudLayouter>().As<ICloudLayouter>().SingleInstance();
    containerBuilder.RegisterType<BitmapGenerator>().As<IBitmapGenerator>().SingleInstance();
    containerBuilder.RegisterType<BoringWordsTextFilter>().As<ITextFilter>().SingleInstance();
    containerBuilder.RegisterType<LowerCaseTextFilter>().As<ITextFilter>().SingleInstance();
    containerBuilder.RegisterType<TxtTextReader>().As<ITextReader>().SingleInstance();
    containerBuilder.RegisterType<ImageSaver>().As<IImageSaver>().SingleInstance();
    containerBuilder.RegisterType<TagCloudImageGenerator>().AsSelf();
}

void RegisterSettings(ContainerBuilder containerBuilder, SettingsManager settingsManager)
{
    
    containerBuilder.RegisterInstance(settingsManager.SaveSettings);
    containerBuilder.RegisterInstance(settingsManager.TextReaderSettings);
    containerBuilder.RegisterInstance(settingsManager.BitmapGeneratorSettings);
    containerBuilder.RegisterInstance(settingsManager.SpiralGeneratorSettings);
    containerBuilder.RegisterInstance(settingsManager.TextSettings);
    containerBuilder.RegisterInstance(settingsManager.BoringWordsSettings);
}

void RegisterFileReaders(ContainerBuilder containerBuilder)
{
    containerBuilder.RegisterType<TxtTextReader>().Keyed<ITextReader>(".txt");
    containerBuilder.RegisterType<DocTextReader>().Keyed<ITextReader>(".doc");
    containerBuilder.RegisterType<DocxTextReader>().Keyed<ITextReader>(".docx");
}