namespace EvilBaschdi.Core.Logging.Tests;

/// <summary>
///     Do not delete this class.
///     NCrunch needs at least one test method in witch <see cref="Assert" />.Equal() is used.
/// </summary>
// ReSharper disable once TestFileNameWarning
public class DoNotDeleteDummyTests
{
    [Fact]
    public void Value_ToEnableUnitTests_Asserts1Equals1()
    {
        // Arrange
        // Act
        // Assert
        // Use FluentAssertions equivalent
#pragma warning disable MFA001
#pragma warning disable FAA0002 // Replace Xunit assertion with Fluent Assertions equivalent
        Assert.Equal(1, 1);
#pragma warning restore FAA0002 // Replace Xunit assertion with Fluent Assertions equivalent
#pragma warning restore MFA001
        // Use FluentAssertions equivalent
    }
}