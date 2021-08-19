
using System;
[AttributeUsage(AttributeTargets.Class, Inherited = true)]
public class PureModeAttribute : Attribute
{
    private EPureModeType pureMode;
    public EPureModeType Type => pureMode;
    public PureModeAttribute(EPureModeType mode)
    {
        pureMode = mode;
    }
}
