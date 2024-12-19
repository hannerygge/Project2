public record BaseServices(
    IConfiguration Configuration,
    INavigationService Navigator,
    IDialogService Dialogs,
    ILoggerFactory LoggerFactory
);