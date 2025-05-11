using EvilBaschdi.Core.Settings.ByMachineAndUser;

namespace EvilBaschdi.Core.Settings.Tests.ByMachineAndUser;

public class AppSettingByKeyTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppSettingByKey).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(AppSettingByKey sut)
    {
        sut.Should().BeAssignableTo<IAppSettingByKey>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(AppSettingByKey).GetMethods().Where(method => !method.IsAbstract));
    }
}