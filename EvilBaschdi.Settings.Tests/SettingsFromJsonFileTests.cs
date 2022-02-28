﻿using AutoFixture.Idioms;
using EvilBaschdi.Testing;
using FluentAssertions;
using Xunit;

namespace EvilBaschdi.Settings.Tests;

public class SettingsFromJsonFileTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(SettingsFromJsonFile).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_ReturnsInterfaceName(SettingsFromJsonFile sut)
    {
        sut.Should().BeAssignableTo<ISettingsFromJsonFile>();
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(SettingsFromJsonFile).GetMethods().Where(method => !method.IsAbstract));
    }
}