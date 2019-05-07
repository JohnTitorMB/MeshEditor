using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
public class TweenInt16 : Tween
{
    Int16 startValue;
    Int16 baseValueVector;
    Int16 endValue;

    public Int16 EndValue
    {
        get
        {
            return endValue;
        }

        set
        {
            if (TargetMode == ETargetMode.Absolute)
                endValue = value;
            else
                endValue = (Int16)(baseValueVector + value);
        }
    }

    public TweenInt16(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, Int16 _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (Int16)propertyInfo.GetValue(componentTween, null);
            EndValue = _endvalue;
        }
    }

    public override void InitStartValue(EStartValue eStartValue)
    {
        switch (eStartValue)
        {
            case EStartValue.StartValue:
                startValue = baseValueVector;
                break;
            case EStartValue.CurrentValue:
                startValue = (Int16)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        Int16 value = (Int16)tweenedFunction(time, startValue, EndValue - startValue, duration);
        propertyInfo.SetValue(componentTween, value, null);
    }

    public override void InverseValue()
    {
        Int16 tmp = startValue;
        startValue = EndValue;
        EndValue = tmp;
    }

    public override void Stop(EStopType type)
    {
        if (type == EStopType.StartValue)
            propertyInfo.SetValue(componentTween, startValue, null);

        else if (type == EStopType.EndValue)
            propertyInfo.SetValue(componentTween, EndValue, null);
    }
}

public class TweenInt32 : Tween
{
    Int32 startValue;
    Int32 baseValueVector;
    Int32 endValue;

    public Int32 EndValue
    {
        get
        {
            return endValue;
        }

        set
        {
            if (TargetMode == ETargetMode.Absolute)
                endValue = value;
            else
                endValue = (Int32)(baseValueVector + value);
        }
    }

    public TweenInt32(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, Int32 _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (Int32)propertyInfo.GetValue(componentTween, null);
            EndValue = _endvalue;
        }
    }

    public override void InitStartValue(EStartValue eStartValue)
    {
        switch (eStartValue)
        {
            case EStartValue.StartValue:
                startValue = baseValueVector;
                break;
            case EStartValue.CurrentValue:
                startValue = (Int32)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        Int32 value = (Int32)tweenedFunction(time, startValue, EndValue - startValue, duration);
        propertyInfo.SetValue(componentTween, value, null);
    }

    public override void InverseValue()
    {
        Int32 tmp = startValue;
        startValue = EndValue;
        EndValue = tmp;
    }

    public override void Stop(EStopType type)
    {
        if (type == EStopType.StartValue)
            propertyInfo.SetValue(componentTween, startValue, null);

        else if (type == EStopType.EndValue)
            propertyInfo.SetValue(componentTween, EndValue, null);
    }
}

public class TweenInt64 : Tween
{
    Int64 startValue;
    Int64 baseValueVector;
    Int64 endValue;

    public Int64 EndValue
    {
        get
        {
            return endValue;
        }

        set
        {
            if (TargetMode == ETargetMode.Absolute)
                endValue = value;
            else
                endValue = (Int64)(baseValueVector + value);
        }
    }


    public TweenInt64(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, Int64 _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (Int64)propertyInfo.GetValue(componentTween, null);
            EndValue = _endvalue;
        }
    }

    public override void InitStartValue(EStartValue eStartValue)
    {
        switch (eStartValue)
        {
            case EStartValue.StartValue:
                startValue = baseValueVector;
                break;
            case EStartValue.CurrentValue:
                startValue = (Int64)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        Int64 value = (Int64)tweenedFunctionD(time, startValue, EndValue - startValue, duration);
        propertyInfo.SetValue(componentTween, value, null);
    }

    public override void InverseValue()
    {
        Int64 tmp = startValue;
        startValue = EndValue;
        EndValue = tmp;
    }

    public override void Stop(EStopType type)
    {
        if (type == EStopType.StartValue)
            propertyInfo.SetValue(componentTween, startValue, null);

        else if (type == EStopType.EndValue)
            propertyInfo.SetValue(componentTween, EndValue, null);
    }
}

public class TweenUInt16 : Tween
{
    UInt16 startValue;
    UInt16 baseValueVector;
    UInt16 endValue;

    public UInt16 EndValue
    {
        get
        {
            return endValue;
        }

        set
        {
            if (TargetMode == ETargetMode.Absolute)
                endValue = value;
            else
                endValue = (UInt16)(baseValueVector + value);
        }
    }

    public TweenUInt16(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, UInt16 _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (UInt16)propertyInfo.GetValue(componentTween, null);
            EndValue = _endvalue;
        }
    }

    public override void InitStartValue(EStartValue eStartValue)
    {
        switch (eStartValue)
        {
            case EStartValue.StartValue:
                startValue = baseValueVector;
                break;
            case EStartValue.CurrentValue:
                startValue = (UInt16)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        UInt16 value = (UInt16)tweenedFunction(time, startValue, EndValue - startValue, duration);
        propertyInfo.SetValue(componentTween, value, null);
    }

    public override void InverseValue()
    {
        UInt16 tmp = startValue;
        startValue = EndValue;
        EndValue = tmp;
    }

    public override void Stop(EStopType type)
    {
        if (type == EStopType.StartValue)
            propertyInfo.SetValue(componentTween, startValue, null);

        else if (type == EStopType.EndValue)
            propertyInfo.SetValue(componentTween, EndValue, null);
    }
}

public class TweenUInt32 : Tween
{
    UInt32 startValue;
    UInt32 baseValueVector;
    UInt32 endValue;

    public UInt32 EndValue
    {
        get
        {
            return endValue;
        }

        set
        {
            if (TargetMode == ETargetMode.Absolute)
                endValue = value;
            else
                endValue = (UInt32)(baseValueVector + value);
        }
    }

    public TweenUInt32(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, UInt32 _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (UInt32)propertyInfo.GetValue(componentTween, null);
            EndValue = _endvalue;
        }
    }

    public override void InitStartValue(EStartValue eStartValue)
    {
        switch (eStartValue)
        {
            case EStartValue.StartValue:
                startValue = baseValueVector;
                break;
            case EStartValue.CurrentValue:
                startValue = (UInt32)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        UInt32 value = (UInt32)tweenedFunction(time, startValue, EndValue - startValue, duration);
        propertyInfo.SetValue(componentTween, value, null);
    }

    public override void InverseValue()
    {
        UInt32 tmp = startValue;
        startValue = EndValue;
        EndValue = tmp;
    }

    public override void Stop(EStopType type)
    {
        if (type == EStopType.StartValue)
            propertyInfo.SetValue(componentTween, startValue, null);

        else if (type == EStopType.EndValue)
            propertyInfo.SetValue(componentTween, EndValue, null);
    }
}

public class TweenUInt64 : Tween
{
    UInt64 startValue;
    UInt64 baseValueVector;
    UInt64 endValue;

    public UInt64 EndValue
    {
        get
        {
            return endValue;
        }

        set
        {
            if (TargetMode == ETargetMode.Absolute)
                endValue = value;
            else
                endValue = (UInt64)(baseValueVector + value);
        }
    }

    public TweenUInt64(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, UInt64 _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (UInt64)propertyInfo.GetValue(componentTween, null);
            EndValue = _endvalue;
        }
    }

    public override void InitStartValue(EStartValue eStartValue)
    {
        switch (eStartValue)
        {
            case EStartValue.StartValue:
                startValue = baseValueVector;
                break;
            case EStartValue.CurrentValue:
                startValue = (UInt64)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        UInt64 value = (UInt64)tweenedFunctionD(time, startValue, EndValue - startValue, duration);
        propertyInfo.SetValue(componentTween, value, null);
    }

    public override void InverseValue()
    {
        UInt64 tmp = startValue;
        startValue = EndValue;
        EndValue = tmp;
    }

    public override void Stop(EStopType type)
    {
        if (type == EStopType.StartValue)
            propertyInfo.SetValue(componentTween, startValue, null);

        else if (type == EStopType.EndValue)
            propertyInfo.SetValue(componentTween, EndValue, null);
    }
}

public class TweenSingle : Tween
{
    Single startValue;
    Single baseValueVector;
    Single endValue;

    public Single EndValue
    {
        get
        {
            return endValue;
        }

        set
        {
            if (TargetMode == ETargetMode.Absolute)
                endValue = value;
            else
                endValue = (Single)(baseValueVector + value);
        }
    }

    public TweenSingle(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, Single _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (Single)propertyInfo.GetValue(componentTween, null);
            EndValue = _endvalue;
        }
    }

    public override void InitStartValue(EStartValue eStartValue)
    {
        switch (eStartValue)
        {
            case EStartValue.StartValue:
                startValue = baseValueVector;
                break;
            case EStartValue.CurrentValue:
                startValue = (Single)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        Single value = tweenedFunction(time, startValue, EndValue - startValue, duration);
        propertyInfo.SetValue(componentTween, value, null);
    }

    public override void InverseValue()
    {
        Single tmp = startValue;
        startValue = EndValue;
        EndValue = tmp;
    }

    public override void Stop(EStopType type)
    {
        if (type == EStopType.StartValue)
            propertyInfo.SetValue(componentTween, startValue, null);

        else if (type == EStopType.EndValue)
            propertyInfo.SetValue(componentTween, EndValue, null);
    }
}

public class TweenDouble : Tween
{
    Double startValue;
    Double baseValueVector;
    Double endValue;

    public Double EndValue
    {
        get
        {
            return endValue;
        }

        set
        {
            if (TargetMode == ETargetMode.Absolute)
                endValue = value;
            else
                endValue = (Double)(baseValueVector + value);
        }
    }

    public TweenDouble(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, Double _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (Double)propertyInfo.GetValue(componentTween, null);
            EndValue = _endvalue;
        }
    }

    public override void InitStartValue(EStartValue eStartValue)
    {
        switch (eStartValue)
        {
            case EStartValue.StartValue:
                startValue = baseValueVector;
                break;
            case EStartValue.CurrentValue:
                startValue = (UInt64)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        Double value = tweenedFunctionD(time, startValue, EndValue - startValue, duration);
        propertyInfo.SetValue(componentTween, value, null);
    }

    public override void InverseValue()
    {
        Double tmp = startValue;
        startValue = EndValue;
        EndValue = tmp;
    }

    public override void Stop(EStopType type)
    {
        if (type == EStopType.StartValue)
            propertyInfo.SetValue(componentTween, startValue, null);

        else if (type == EStopType.EndValue)
            propertyInfo.SetValue(componentTween, EndValue, null);
    }
}
