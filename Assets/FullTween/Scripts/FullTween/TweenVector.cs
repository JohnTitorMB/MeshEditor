using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Reflection;

public class TweenVector2 : Tween
{
    Vector2 startValue;
    Vector2 baseValueVector;
    Vector2 endValue;

    public Vector2 EndValue
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
                endValue = baseValueVector + value;
        }
    }

    public TweenVector2(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, Vector2 _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (Vector2)propertyInfo.GetValue(componentTween, null);
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
                startValue = (Vector2)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        Vector2 pos = Vector2.zero;
        pos.x = tweenedFunction(time, startValue.x, EndValue.x - startValue.x, duration);
        pos.y = tweenedFunction(time, startValue.y, EndValue.y - startValue.y, duration);
        propertyInfo.SetValue(componentTween, pos, null);
    }

    public override void InverseValue()
    {
        Vector2 tmp = startValue;
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

public class TweenVector2Int : Tween
{
    Vector2Int startValue;
    Vector2Int baseValueVector;
    Vector2Int endValue;

    public Vector2Int EndValue
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
                endValue = baseValueVector + value;
        }
    }


    public TweenVector2Int(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, Vector2Int _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (Vector2Int)propertyInfo.GetValue(componentTween, null);
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
                startValue = (Vector2Int)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        Vector2Int pos = Vector2Int.zero;
        pos.x = (Int32)tweenedFunction(time, startValue.x, EndValue.x - startValue.x, duration);
        pos.y = (Int32)tweenedFunction(time, startValue.y, EndValue.y - startValue.y, duration);
        propertyInfo.SetValue(componentTween, pos, null);
    }

    public override void InverseValue()
    {
        Vector2Int tmp = startValue;
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

public class TweenVector3 : Tween
{
    Vector3 startValue;
    Vector3 baseValueVector;
    Vector3 endValue;

    public Vector3 EndValue
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
                endValue = baseValueVector + value;
        }
    }


    public TweenVector3(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, Vector3 _endvalue) : base(_componentTween, _propertyInfo)
    {
        if(_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (Vector3)propertyInfo.GetValue(componentTween, null);
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
                startValue = (Vector3)propertyInfo.GetValue(componentTween, null);
            break;
        }
    }

    public override void Update(float time, float duration)
    {
        Vector3 pos = Vector3.zero;
        pos.x = tweenedFunction(time, startValue.x, EndValue.x - startValue.x, duration);
        pos.y = tweenedFunction(time, startValue.y, EndValue.y - startValue.y, duration);
        pos.z = tweenedFunction(time, startValue.z, EndValue.z - startValue.z, duration);
        propertyInfo.SetValue(componentTween, pos, null);
    }

    public override void InverseValue()
    {
        Vector3 tmp = startValue;
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

public class TweenVector3Int : Tween
{
    Vector3Int startValue;
    Vector3Int baseValueVector;
    Vector3Int endValue;

    public Vector3Int EndValue
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
                endValue = baseValueVector + value;
        }
    }

    public TweenVector3Int(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, Vector3Int _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (Vector3Int)propertyInfo.GetValue(componentTween, null);
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
                startValue = (Vector3Int)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        Vector3Int pos = Vector3Int.zero;
        pos.x = (Int32)tweenedFunction(time, startValue.x, EndValue.x - startValue.x, duration);
        pos.y = (Int32)tweenedFunction(time, startValue.y, EndValue.y - startValue.y, duration);
        pos.z = (Int32)tweenedFunction(time, startValue.z, EndValue.z - startValue.z, duration);
        propertyInfo.SetValue(componentTween, pos, null);
    }

    public override void InverseValue()
    {
        Vector3Int tmp = startValue;
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

public class TweenVector4 : Tween
{
    Vector4 startValue;
    Vector4 baseValueVector;
    Vector4 endValue;

    public Vector4 EndValue
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
                endValue = baseValueVector + value;
        }
    }

    public TweenVector4(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, Vector4 _endvalue) : base(_componentTween, _propertyInfo)
    {
        if (_componentTween)
        {
            TargetMode = targetMode;
            baseValueVector = (Vector3)propertyInfo.GetValue(componentTween, null);
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
                startValue = (Vector4)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        Vector4 pos = Vector4.zero;
        pos.x = tweenedFunction(time, startValue.x, EndValue.x - startValue.x, duration);
        pos.y = tweenedFunction(time, startValue.y, EndValue.y - startValue.y, duration);
        pos.z = tweenedFunction(time, startValue.z, EndValue.z - startValue.z, duration);
        pos.w = tweenedFunction(time, startValue.w, EndValue.w - startValue.w, duration);
        propertyInfo.SetValue(componentTween, pos, null);
    }

    public override void InverseValue()
    {
        Vector4 tmp = startValue;
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
