﻿using EvilBaschdi.Settings.Internal;
using Microsoft.Extensions.Configuration.Json;

namespace EvilBaschdi.Settings.Tests.Internal;

public class WritableJsonConfigurationSourceTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WritableJsonConfigurationSource).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(WritableJsonConfigurationSource sut)
    {
        sut.Should().BeAssignableTo<JsonConfigurationSource>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WritableJsonConfigurationSource).GetMethods().Where(method => !method.IsAbstract));
    }
}