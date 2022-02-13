﻿#pragma warning disable CS0105 // Using directive appeared previously in this namespace
using System.Linq;
using AutoFixture.Idioms;
using EvilBaschdi.Settings.Internal;
using EvilBaschdi.Testing;
using FluentAssertions;
using Microsoft.Extensions.Configuration.Json;
using Xunit;

#pragma warning restore CS0105 // Using directive appeared previously in this namespace

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
        sut.Should().BeAssignableTo<JsonConfigurationProvider>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(WritableJsonConfigurationSource).GetMethods().Where(method => !method.IsAbstract));
    }
}