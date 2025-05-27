namespace ArchitectureTests
{
    public abstract class BaseTest
    {
        protected static readonly Assembly MasterAccessAssembly = typeof(Program).Assembly;
        protected static readonly Assembly EmacsAccessAssembly = typeof(Emacs.Program).Assembly;
        protected static readonly Assembly EngineAssembly = typeof(IRepository<>).Assembly;
        protected static readonly Assembly ManagerAssembly = typeof(IRepository<>).Assembly;
        protected static readonly Assembly ClientAssembly = typeof(IRepository<>).Assembly;
    }
}
