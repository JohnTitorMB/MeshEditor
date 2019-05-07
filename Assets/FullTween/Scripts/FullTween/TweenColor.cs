using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class TweenColor : Tween
{
    Color startValue;
    Color baseValueVector;
    Color endValue;

    public Color EndValue
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

    public TweenColor(Component _componentTween, PropertyInfo _propertyInfo, ETargetMode targetMode, Color _endvalue) : base(_componentTween, _propertyInfo)
    {
        TargetMode = targetMode;
        baseValueVector = (Color)propertyInfo.GetValue(componentTween, null);
        EndValue = _endvalue;
    }

    public override void InitStartValue(EStartValue eStartValue)
    {
        switch (eStartValue)
        {
            case EStartValue.StartValue:
                startValue = baseValueVector;
                break;
            case EStartValue.CurrentValue:
                startValue = (Color)propertyInfo.GetValue(componentTween, null);
                break;
        }
    }

    public override void Update(float time, float duration)
    {
        Color color = Color.black;
        color.r = tweenedFunction(time, startValue.r, EndValue.r - startValue.r, duration);
        color.g = tweenedFunction(time, startValue.g, EndValue.g - startValue.g, duration);
        color.b = tweenedFunction(time, startValue.b, EndValue.b - startValue.b, duration);
        color.a = tweenedFunction(time, startValue.a, EndValue.a - startValue.a, duration);
        propertyInfo.SetValue(componentTween, color, null);
    }

    public override void InverseValue()
    {
        Color tmp = startValue;
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