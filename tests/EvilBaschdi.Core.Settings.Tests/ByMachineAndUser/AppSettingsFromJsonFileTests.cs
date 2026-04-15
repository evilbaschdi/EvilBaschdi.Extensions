using EvilBaschdi.Core.Settings.ByMachineAndUser;

namespace EvilBaschdi.Core.Settings.Tests.ByMachineAndUser;

public class AppSettingsFromJsonFileTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppSettingsFromJsonFile).GetConstructors());
    }

    //[Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    //public void Constructor_ReturnsInterfaceName(AppSettingsFromJsonFile sut)
    //{
    //    sut.Should().BeAssignableTo<IAppSettingsFromJsonFile>();
    //    sut.Should().BeAssignableTo<WritableSettingsFromJsonFile>();
    //}

    //[Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    //public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    //{
    //    assertion.Verify(typeof(AppSettingsFromJsonFile).GetMethods().Where(method => !method.IsAbstract));
    //}
}