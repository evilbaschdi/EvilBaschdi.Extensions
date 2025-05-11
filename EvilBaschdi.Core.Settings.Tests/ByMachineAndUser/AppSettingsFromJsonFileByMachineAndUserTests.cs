using EvilBaschdi.Core.Settings.ByMachineAndUser;

namespace EvilBaschdi.Core.Settings.Tests.ByMachineAndUser;

public class AppSettingsFromJsonFileByMachineAndUserTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppSettingsFromJsonFileByMachineAndUser).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(AppSettingsFromJsonFileByMachineAndUser sut)
    {
        sut.Should().BeAssignableTo<IAppSettingsFromJsonFileByMachineAndUser>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppSettingsFromJsonFileByMachineAndUser).GetMethods().Where(method => !method.IsAbstract));
    }
}