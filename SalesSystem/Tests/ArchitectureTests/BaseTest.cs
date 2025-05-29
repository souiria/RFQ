namespace ArchitectureTests
{
    public abstract class BaseTest
    {
        protected static readonly Assembly MasterAccessAssembly;
        protected static readonly Assembly EmacsAccessAssembly;
        protected static readonly Assembly EngineAssembly;
        protected static readonly Assembly ManagerAssembly;
        protected static readonly Assembly ClientAssembly;

        static BaseTest()
        {
            MasterAccessAssembly = typeof(Program).Assembly;
            EmacsAccessAssembly = typeof(Emacs.Program).Assembly;
            EngineAssembly = typeof(IRepository<>).Assembly;
            ManagerAssembly = typeof(IRepository<>).Assembly;
            ClientAssembly = typeof(IRepository<>).Assembly;
        }
    }
}
