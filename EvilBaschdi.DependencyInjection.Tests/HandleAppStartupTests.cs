namespace EvilBaschdi.DependencyInjection.Tests;

public class HandleAppStartupTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(HandleAppStartup<string>).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(HandleAppStartup<string> sut)
    {
        sut.Should().BeAssignableTo<IHandleAppStartup<string>>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1031:Do not use blocking task operations in test method", Justification = "<Pending>")]
    public void ValueFor_HasNullGuards_Result(
        HandleAppStartup<string> sut)
    {
        // Arrange

        // Act
        // ReSharper disable once AssignNullToNotNullAttribute
        var action = Record.ExceptionAsync(() => sut.ValueFor(null));

        // Assert
        action.Result.Should().BeOfType<ArgumentNullException>();
    }
}