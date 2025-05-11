﻿namespace EvilBaschdi.Core.DependencyInjection.Tests;

public class ChainConfiguratorTests
{
    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Constructor_HasNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ChainConfigurator).GetConstructors());
    }

    [Theory, NSubstituteOmitAutoPropertiesTrueAutoData]
    public void Methods_HaveNullGuards(GuardClauseAssertion assertion)
    {
        assertion.Verify(typeof(ChainConfigurator).GetMethods().Where(method => !method.IsAbstract));
    }
}