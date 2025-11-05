namespace ArchitectureTests.Layers
{
    public class LayerTests : BaseTest
    {
        #region MasterAccess

        [Fact]
        public void Access_Should_NotHaveDependencyOnEngine()
        {
            TestResult result = Types.InAssembly(MasterAccessAssembly)
                .Should()
                .NotHaveDependencyOn("Engine")
                .GetResult();

        result.IsSuccessful.ShouldBeTrue();
        }

        [Fact]
        public void Access_Should_NotHaveDependencyOnManager()
        {

        }

        [Fact]
        public void Access_Should_NotHaveDependencyOnClient()
        {

        }

        #endregion
/*
        [Fact]
        public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
        {
            TestResult result = Types.InAssembly(ApplicationAssembly)
                .Should()
                .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
                .GetResult();

            result.IsSuccessful.ShouldBeTrue();
        }

        [Fact]
        public void ApplicationLayer_ShouldNotHaveDependencyOn_PresentationLayer()
        {
            TestResult result = Types.InAssembly(ApplicationAssembly)
                .Should()
                .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
                .GetResult();

            result.IsSuccessful.ShouldBeTrue();
        }

        [Fact]
        public void InfrastructureLayer_ShouldNotHaveDependencyOn_PresentationLayer()
        {
            TestResult result = Types.InAssembly(InfrastructureAssembly)
                .Should()
                .NotHaveDependencyOn(PresentationAssembly.GetName().Name)
                .GetResult();

            result.IsSuccessful.ShouldBeTrue();
        }
*/
    }
}
