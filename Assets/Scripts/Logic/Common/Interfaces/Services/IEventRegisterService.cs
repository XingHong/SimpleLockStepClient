using System;
public interface IEventRegisterService : IService
{
    void RegisterEvent(object obj);
    void UnRegisterEvent(object obj);

    void RegisterEvent<TEnum, TDelegate>(string prefix,
    Action<TEnum, TDelegate> callBack, object obj)
    where TDelegate : Delegate
    where TEnum : struct;
}
