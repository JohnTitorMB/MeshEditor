using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;

abstract public class Tween
{
    Type[] floatType = { typeof(Int16), typeof(Int16[]),
                         typeof(Int32), typeof(Int32[]),
                         typeof(UInt16), typeof(UInt16[]),
                         typeof(UInt32), typeof(UInt32[]),
                         typeof(float),typeof(float[]),
                         typeof(Vector2),typeof(Vector2[]),
                         typeof(Vector2Int),typeof(Vector2Int[]),
                         typeof(Vector3), typeof(Vector3[]),
                         typeof(Vector3Int), typeof(Vector3Int[]),
                         typeof(Vector4), typeof(Vector4[]),
                         typeof(Matrix4x4), typeof(Matrix4x4[]),
                         typeof(Color), typeof(Color[]),
                         typeof(Color32), typeof(Color32[])
                       };

    protected enum TypeValue
    {
        FLOAT,
        DOUBLE,
    };

    protected Component componentTween;
    protected PropertyInfo propertyInfo;
    private EFunction eFunction;
    protected TypeValue typeValue;
    public Tween(Component _componentTween, PropertyInfo _propertyInfo)
    {
        componentTween = _componentTween;
        propertyInfo = _propertyInfo;
        if (_componentTween)
        {
            Type T = propertyInfo.PropertyType;
        if (Array.IndexOf(floatType, T) != -1)
            typeValue = TypeValue.FLOAT;
        else
            typeValue = TypeValue.DOUBLE;
        }
    }

    public delegate float TweenFunc(float t, float b, float c, float d);
    protected TweenFunc tweenedFunction;

    public delegate double TweenFuncD(double t, double b, double c, double d);
    protected TweenFuncD tweenedFunctionD;

    public EFunction EFunctionProperty
    {
        get
        {
            
            return eFunction;
        }

        set
        {        
            eFunction = value;
            SetFunction(eFunction);
        }
    }

    public ETargetMode TargetMode
    {
        get; set;
       
    }

    private void SetFunction(EFunction function)
    {
        tweenedFunction = null;
        tweenedFunctionD = null;

        switch (function)
        {
            case EFunction.Linear:
                
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.Linear;
                else
                    tweenedFunctionD += EasingToolsdouble.Linear;
                break;
            case EFunction.EaseInQuad:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInQuad;
                else
                    tweenedFunctionD += EasingToolsdouble.EaseInQuad;
                break;
            case EFunction.EaseOutQuad:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseOutQuad;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseOutQuad;
                break;
            case EFunction.EaseInOutQuad:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInOutQuad;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInOutQuad;
                break;
            case EFunction.EaseInCubic:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInCubic;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInCubic;
                break;
            case EFunction.EaseOutCubic:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseOutCubic;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseOutCubic;
                break;
            case EFunction.EaseInOutCubic:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInOutCubic;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInOutCubic;
                break;
            case EFunction.EaseInQuart:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInQuart;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInQuart;
                break;
            case EFunction.EaseOutQuart:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseOutQuart;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseOutQuart;
                break;
            case EFunction.EaseInOutQuart:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInOutQuart;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInOutQuart;
                break;
            case EFunction.EaseInQuint:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInQuint;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInQuint;
                break;
            case EFunction.EaseOutQuint:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseOutQuint;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseOutQuint;
                break;
            case EFunction.EaseInOutQuint:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInOutQuint;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInOutQuint;
                break;
            case EFunction.EaseInCircle:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInCircle;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInCircle;
                break;
            case EFunction.EaseOutCircle:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseOutCircle;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseOutCircle;
                break;
            case EFunction.EaseInOutCircle:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInOutCircle;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInOutCircle;
                break;
            case EFunction.EaseInBack:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInBack;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInBack;
                break;
            case EFunction.EaseOutBack:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseOutBack;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseOutBack;
                break;
            case EFunction.EaseInOutBack:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInOutBack;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInOutBack;
                break;
            case EFunction.EaseInElastic:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInElastic;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInElastic;
                break;
            case EFunction.EaseOutElastic:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseOutElastic;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseOutElastic;
                break;
            case EFunction.EaseInOutElastic:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInOutElastic;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInOutElastic;
                break;
            case EFunction.EaseInBounce:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInBounce;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInBounce;
                break;
            case EFunction.EaseOutBounce:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseOutBounce;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseOutBounce;
                break;
            case EFunction.EaseInOutBounce:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInOutBounce;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInOutBounce;
                break;
            case EFunction.EaseInSmoothstep:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInSmoothstep;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInSmoothstep;
                break;
            case EFunction.EaseOutSmoothstep:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseOutSmoothstep;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseOutSmoothstep;
                break;
            case EFunction.EaseInOutSmoothstep:
                if (typeValue == TypeValue.FLOAT)
                    tweenedFunction += EasingToolsfloat.EaseInOutSmoothstep;
                 else
                    tweenedFunctionD += EasingToolsdouble.EaseInOutSmoothstep;
                break;
        }
        eFunction = function;
    }
    public virtual void InitStartValue(EStartValue eStartValue) { }
    public virtual void Update(float time, float duration) { }
    public virtual void InverseValue() { }
    public virtual void Stop(EStopType type) { }
}
