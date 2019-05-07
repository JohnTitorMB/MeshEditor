using System;
using System.Reflection;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

#region Enum

public enum EMode
{
    Normal = 1,
    PingPong = 2,
    Loop = 3,
}

public enum EActiveOnStart
{
    No,
    Yes,
    PingPong,
    Loop,
}

public enum EFunction
{
    Linear,
    EaseInQuad,
    EaseOutQuad,
    EaseInOutQuad,
    EaseInCubic,
    EaseOutCubic,
    EaseInOutCubic,
    EaseInQuart,
    EaseOutQuart,
    EaseInOutQuart,
    EaseInQuint,
    EaseOutQuint,
    EaseInOutQuint,
    EaseInCircle,
    EaseOutCircle,
    EaseInOutCircle,
    EaseInBack,
    EaseOutBack,
    EaseInOutBack,
    EaseInElastic,
    EaseOutElastic,
    EaseInOutElastic,
    EaseInBounce,
    EaseOutBounce,
    EaseInOutBounce,
    EaseInSmoothstep,
    EaseOutSmoothstep,
    EaseInOutSmoothstep,
}

public enum ETargetMode
{
    Absolute,
    Relative
}

public enum EStopType
{
    CurrentValue,
    StartValue,
    EndValue,
}

public enum EStartValue
{
    StartValue,
    CurrentValue,
}

#endregion

public class FullTween : MonoBehaviour
{
    #region Members

    [System.Serializable]
    private struct EndValueField
    {
        public Int16 Int16EndValue;
        public Int32 Int32EndValue;
        public Int64 Int64EndValue;
        public UInt16 UInt16EndValue;
        public UInt32 UInt32EndValue;
        public UInt64 UInt64EndValue;
        public Single SingleEndValue;
        public Double DoubleEndValue;

        public Vector2 Vector2EndValue;
        public Vector2Int Vector2IntEndValue;

        public Vector3 Vector3EndValue;
        public Vector3Int Vector3IntEndValue;

        public Vector4 Vector4EndValue;
        public Color ColorEndValue;
        public Color32 Color32EndValue;
    }

    [SerializeField]
    EActiveOnStart activeOnStart = EActiveOnStart.Yes;

    [SerializeField]
    EFunction function = EFunction.Linear;

    [SerializeField]
    Tween tween;

    [SerializeField]
    EndValueField endValueField = new EndValueField();

    [SerializeField]
    ETargetMode targetMode = ETargetMode.Absolute;

    [SerializeField]
    float duration = 2.5f;

    [SerializeField]
    bool activePhysic = false;

    private bool pause = false;
    private bool reverse = false;

    private float time = 0;
    private float progress = 0;
    private Estate state = Estate.Start;
    private Component componentTween;
    private PropertyInfo propertyInfoTween;

    public int ComponentSelected;
    public int ValueSelected;

    public Action OntweenStart;
    public Action OntweenEnd;
    public int ComponentTweenID;
    public int propertyInfoTweenID;
    public bool isInitialise = true;

    #endregion

    #region Properties

    public enum Estate
    {
        Start,
        Progress,
        End,
    }

    public EMode Mode
    {
        get;
        set;
    }

    public EFunction Function
    {
        get
        {
            return function;
        }

        set
        {
            function = value;
            if (tween != null)
                tween.EFunctionProperty = function;
        }
    }

    public float Duration
    {
        get
        {
            return duration;
        }

        set
        {
            duration = value;
        }
    }

    public float Progress
    {
        get
        {
            return progress;
        }
    }

    public Estate State
    {
        get
        {
            return state;
        }
    }

    public ETargetMode TargetMode
    {
        get
        {
            return targetMode;
        }

        set
        {
            targetMode = value;
            if (tween != null)
                tween.TargetMode = targetMode;
        }
    }
    
    #endregion

    #region Functions

    void Awake()
    {
        if (isInitialise == false)
            return;
        InitTween();

        Mode = (EMode)activeOnStart;

        if (activeOnStart != EActiveOnStart.No)
            StartFullTween(EStartValue.StartValue);               
    }

    // Init Attribute FUllTween and save startValue
    void InitTween()
    {
        Component[] components = GetComponents<Component>();
        componentTween = components[ComponentTweenID];

        Type componentType = componentTween.GetType();

        PropertyInfo[] propertiesInfo = componentType.GetProperties();

        propertyInfoTween = propertiesInfo[propertyInfoTweenID];
        Type T = propertyInfoTween.PropertyType;

        if (T == typeof(Vector2))
            tween = new TweenVector2(componentTween, propertyInfoTween, TargetMode, endValueField.Vector2EndValue);
        else if (T == typeof(Vector2Int))
            tween = new TweenVector2Int(componentTween, propertyInfoTween, TargetMode, endValueField.Vector2IntEndValue);
        else if(T == typeof(Vector3))
            tween = new TweenVector3(componentTween, propertyInfoTween, TargetMode, endValueField.Vector3EndValue);
        else if(T == typeof(Vector3Int))
            tween = new TweenVector3Int(componentTween, propertyInfoTween, TargetMode, endValueField.Vector3IntEndValue);
        else if(T == typeof(Vector4))
            tween = new TweenVector4(componentTween, propertyInfoTween, TargetMode, endValueField.Vector4EndValue);
        else if(T == typeof(Color))
            tween = new TweenColor(componentTween, propertyInfoTween, TargetMode, endValueField.ColorEndValue);
        else if (T == typeof(Int16))
            tween = new TweenInt16(componentTween, propertyInfoTween, TargetMode, endValueField.Int16EndValue);
        else if (T == typeof(Int32))
            tween = new TweenInt32(componentTween, propertyInfoTween, TargetMode, endValueField.Int32EndValue);
        else if (T == typeof(Int64))
            tween = new TweenInt64(componentTween, propertyInfoTween, TargetMode, endValueField.Int64EndValue);
        else if (T == typeof(UInt16))
            tween = new TweenUInt16(componentTween, propertyInfoTween, TargetMode, endValueField.UInt16EndValue);
        else if (T == typeof(UInt32))
            tween = new TweenUInt32(componentTween, propertyInfoTween, TargetMode, endValueField.UInt32EndValue);
        else if (T == typeof(UInt64))
            tween = new TweenUInt64(componentTween, propertyInfoTween, TargetMode, endValueField.UInt64EndValue);
        else if (T == typeof(Single))
            tween = new TweenSingle(componentTween, propertyInfoTween, TargetMode, endValueField.SingleEndValue);
        else if (T == typeof(Double))
            tween = new TweenDouble(componentTween, propertyInfoTween, TargetMode, endValueField.DoubleEndValue);

        if (tween != null)
            tween.EFunctionProperty = function;
    }

    // Get EndValue in absolute. To read value, cast in fulltween property type.
    public object GetEndValue()
    {
        if (tween != null)
        {

            if (tween.GetType() == typeof(TweenVector2))
                return (object)((TweenVector2)tween).EndValue;

            if (tween.GetType() == typeof(TweenVector2Int))
                return (object)((TweenVector2Int)tween).EndValue;

            if (tween.GetType() == typeof(TweenVector3))
                return (object)((TweenVector3)tween).EndValue;

            if (tween.GetType() == typeof(TweenVector3Int))
                return (object)((TweenVector3Int)tween).EndValue;

            if (tween.GetType() == typeof(TweenVector4))
                return (object)((TweenVector4)tween).EndValue;

            if (tween.GetType() == typeof(TweenColor))
                return (object)((TweenColor)tween).EndValue;

            if (tween.GetType() == typeof(TweenInt16))
                return (object)((TweenInt16)tween).EndValue;

            if (tween.GetType() == typeof(TweenInt32))
                return (object)((TweenInt32)tween).EndValue;

            if (tween.GetType() == typeof(TweenInt64))
                return (object)((TweenInt64)tween).EndValue;

            if (tween.GetType() == typeof(TweenUInt16))
                return (object)((TweenUInt16)tween).EndValue;

            if (tween.GetType() == typeof(TweenUInt32))
                return (object)((TweenUInt32)tween).EndValue;

            if (tween.GetType() == typeof(TweenUInt64))
                return (object)((TweenUInt64)tween).EndValue;

            if (tween.GetType() == typeof(TweenSingle))
                return (object)((TweenSingle)tween).EndValue;

            if (tween.GetType() == typeof(TweenDouble))
                return (object)((TweenDouble)tween).EndValue;

        }

        return null;
    }

    // Set End Value in relative if properties TargetMode is relative and absolute if properties TargetMode is absolute. Exemple : SetEndValue(new Vector3(0,0,10)) or SetEndValue(10);
    public void SetEndValue(object value)
    {
        if (tween == null)
            return;

        if (tween.GetType() == typeof(TweenVector2))
            ((TweenVector2)tween).EndValue = (Vector2)value;

        if (tween.GetType() == typeof(TweenVector2Int))
            ((TweenVector2Int)tween).EndValue = (Vector2Int)value;

        if (tween.GetType() == typeof(TweenVector3))
            ((TweenVector3)tween).EndValue = (Vector3)value;

        if (tween.GetType() == typeof(TweenVector3Int))
            ((TweenVector3Int)tween).EndValue = (Vector3Int)value;

        if (tween.GetType() == typeof(TweenVector4))
            ((TweenVector4)tween).EndValue = (Vector4)value;

        if (tween.GetType() == typeof(TweenColor))
            ((TweenColor)tween).EndValue = (Color)value;

        if (tween.GetType() == typeof(TweenInt16))
            ((TweenInt16)tween).EndValue = (Int16)value;

        if (tween.GetType() == typeof(TweenInt32))
            ((TweenInt32)tween).EndValue = (Int32)value;

        if (tween.GetType() == typeof(TweenInt64))
            ((TweenInt64)tween).EndValue = (Int64)value;

        if (tween.GetType() == typeof(TweenUInt16))
            ((TweenUInt16)tween).EndValue = (UInt16)value;

        if (tween.GetType() == typeof(TweenUInt32))
            ((TweenUInt32)tween).EndValue = (UInt32)value;

        if (tween.GetType() == typeof(TweenUInt64))
            ((TweenUInt64)tween).EndValue = (UInt64)value;

        if (tween.GetType() == typeof(TweenSingle))
            ((TweenSingle)tween).EndValue = (Single)value;

        if (tween.GetType() == typeof(TweenDouble))
            ((TweenDouble)tween).EndValue = (Double)value;
    }

    // Start Fulltween
    public void StartFullTween(EStartValue value)
    {
        if (tween == null)
            return;
        time = 0;
        progress = 0;

        reverse = false;
        tween.InitStartValue(value);
      
        state = Estate.Progress;

        if (OntweenStart != null)
            OntweenStart();
    }

    void Update()
    {
        if (tween == null)
            return;

        if (!activePhysic)
        {
            UpdateFulltween(Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (tween == null)
            return;

        if (activePhysic)
        {
            UpdateFulltween(Time.fixedDeltaTime);
        }
    }

    void UpdateFulltween(float _time)
    {
        if (tween != null)
            tween.EFunctionProperty = function;

        if (state == Estate.Progress && !pause)
        {
            if (!reverse)
                time = (time + _time < Duration) ? time + _time : Duration;
            else
                time = (time - _time > 0) ? time - _time : 0.0f;

            progress = time / Duration;
            tween.Update(time, Duration);
            if (progress >= 1.0f || progress <= 0.0f)
            {
                state = Estate.End;
                if (OntweenEnd != null)
                    OntweenEnd();
            }

            UpdateStartingMode();
        }
    }

    void UpdateStartingMode()
    {
        switch (Mode)
        {
            case EMode.PingPong:
                PingPong();
                break;

            case EMode.Loop:
                Loop();
                break;
        }
    }
    void PingPong()
    {
        if (reverse)
        {
            if (progress <= 0.0f)
            {
                reverse = !reverse;
            }
        }
        else if (!reverse)
        {
            if (progress >= 1.0f)
            {
                reverse = !reverse;
            }
        }

        state = Estate.Progress;
    }

    void Loop()
    {
        if (reverse)
        {
            if (progress <= 0.0f)
            {
                time = Duration;
                state = Estate.Progress;
            }
        }
        else if (!reverse)
        {
            if (progress >= 1.0f)
            {

                    time = 0.0f;
                state = Estate.Progress;

            }
        }
    }

    // Reverse Fulltween
    public void Reverse()
    {
        reverse = !reverse;
    }

    // Pause Fulltween
    public void Pause()
    {
        pause = true;
    }

    // Resume Fulltween if Fulltween is in Pause
    public void Resume()
    {
        pause = false;
    }

    // Stop Fulltween in current value, stárt value or end value
    public void Stop(EStopType type)
    {
        if (tween == null)
            return;

        state = Estate.Start;
        progress = 0.0f;
        tween.Stop(type);
    }

    #endregion
}
