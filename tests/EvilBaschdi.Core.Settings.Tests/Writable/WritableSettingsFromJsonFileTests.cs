using EvilBaschdi.Core.Settings.Writable;

namespace EvilBaschdi.Core.Settings.Tests.Writable;

public class WritableSettingsFromJsonFileTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WritableSettingsFromJsonFile).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(WritableSettingsFromJsonFile sut)
    {
        sut.Should().BeAssignableTo<ISettingsFromJsonFile>();
    }

    //[Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    //public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    //{
    //    assertion.Verify(typeof(WritableSettingsFromJsonFile).GetMethods().Where(method => !method.IsAbstract & !method.Name.Equals("GetChildKeys")));
    //}
}