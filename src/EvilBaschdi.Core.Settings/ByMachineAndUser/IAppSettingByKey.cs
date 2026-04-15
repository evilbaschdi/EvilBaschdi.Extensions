namespace EvilBaschdi.Core.Settings.ByMachineAndUser;

/// <inheritdoc cref="IValueFor{TIn,TOut}" />
/// <inheritdoc cref="IRunFor2{TIn,TOut}" />
public interface IAppSettingByKey : IValueFor<string, string>
{
    /// <summary>Value</summary>
    // ReSharper disable once UnusedMember.Global
    TOut ValueFor<TOut>(string key);

    /// <summary>
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    void RunFor<TIn>(string key, TIn value);
}