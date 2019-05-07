using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EasingToolsfloat
{
    static public float Linear(float t, float b, float c, float d)
    {
        return b + c * t / d;
    }
    static public float EaseInQuad(float t, float b, float c, float d)
    {
        return c * (t /= d) * t + b;
    }
    static public float EaseOutQuad(float t, float b, float c, float d)
    {
        return -c * (t /= d) * (t - 2) + b;
    }
    static public float EaseInOutQuad(float t, float b, float c, float d)
    {
        if ((t /= d / 2) < 1) return c / 2 * t * t + b;
        return -c / 2 * ((--t) * (t - 2) - 1) + b;
    }
    static public float EaseInCubic(float t, float b, float c, float d)
    {
        return c * (t /= d) * t * t + b;
    }
    static public float EaseOutCubic(float t, float b, float c, float d)
    {
        return c * ((t = t / d - 1) * t * t + 1) + b;
    }
    static public  float EaseInOutCubic(float t, float b, float c, float d)
    {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t + b;
        return c / 2 * ((t -= 2) * t * t + 2) + b;
    }
    static public  float EaseInQuart(float t, float b, float c, float d)
    {
        return c * (t /= d) * t * t * t + b;
    }
    static public  float EaseOutQuart(float t, float b, float c, float d)
    {
        return -c * ((t = t / d - 1) * t * t * t - 1) + b;
    }
    static public  float EaseInOutQuart(float t, float b, float c, float d)
    {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t * t + b;
        return -c / 2 * ((t -= 2) * t * t * t - 2) + b;
    }
    static public  float EaseInQuint(float t, float b, float c, float d)
    {
        return c * (t /= d) * t * t * t * t + b;

    }
    static public  float EaseOutQuint(float t, float b, float c, float d)
    {
        return c * ((t = t / d - 1) * t * t * t * t + 1) + b;
    }
    static public  float EaseInOutQuint(float t, float b, float c, float d)
    {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t * t * t + b;
        return c / 2 * ((t -= 2) * t * t * t * t + 2) + b;
    }
    static public  float EaseInCircle(float t, float b, float c, float d)
    {
        return -c * (Mathf.Sqrt(1 - (t /= d) * t) - 1) + b;
    }
    static public  float EaseOutCircle(float t, float b, float c, float d)
    {
        return c * Mathf.Sqrt(1 - (t = t / d - 1) * t) + b;
    }
    static public  float EaseInOutCircle(float t, float b, float c, float d)
    {
        if ((t /= d / 2) < 1) return -c / 2 * (Mathf.Sqrt(1 - t * t) - 1) + b;
        return c / 2 * (Mathf.Sqrt(1 - (t -= 2) * t) + 1) + b;
    }
    static public  float EaseInBack(float t, float b, float c, float d)
    {
        float s = 1.70158f;
        return c * (t /= d) * t * ((s + 1) * t - s) + b;
    }
    static public  float EaseOutBack(float t, float b, float c, float d)
    {
        float s = 1.70158f;
        return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b;
    }
    static public  float EaseInOutBack(float t, float b, float c, float d)
    {
        float s = 1.70158f;
        if ((t /= d / 2) < 1) return c / 2 * (t * t * (((s *= (1.525f)) + 1) * t - s)) + b;
        return c / 2 * ((t -= 2) * t * (((s *= (1.525f)) + 1) * t + s) + 2) + b;

    }
    static public  float EaseInElastic(float t, float b, float c, float d)
    {
        float s = 1.70158f;
        float p = 0;
        float a = c;
        if (t == 0)
            return b;
        if ((t /= d) == 1)
            return b + c;

        p = d * 0.3f;

        if (a < Mathf.Abs(c))
        {
            a = c;
            s = p / 4;
        }
        else
        {
            if (a == 0)
                s = 0;
            else
                s = p / (2 * Mathf.PI) * Mathf.Asin(c / a);
        }
        return -(a * Mathf.Pow(2, 10 * (t -= 1)) * Mathf.Sin((t * d - s) * (2 * Mathf.PI) / p)) + b;

    }
    static public  float EaseOutElastic(float t, float b, float c, float d)
    {
        float s = 1.70158f;
        float p = 0;
        float a = c;
        if (t == 0)
            return b;
        if ((t /= d) == 1)
            return b + c;

        p = d * 0.3f;
        if (a < Mathf.Abs(c))
        {
            a = c;
            s = p / 4;
        }
        else
        {
            if (a == 0)
                s = 0;
            else
                s = p / (2 * Mathf.PI) * Mathf.Asin(c / a);
        }

        return a * Mathf.Pow(2, -10 * t) * Mathf.Sin((t * d - s) * (2 * Mathf.PI) / p) + c + b;

    }
    static public  float EaseInOutElastic(float t, float b, float c, float d)
    {
        float s = 1.70158f; float p = 0; float a = c;
        if (t == 0) return b; if ((t /= d / 2) == 2) return b + c; p = d * (0.3f * 1.5f);
        if (a < Mathf.Abs(c)) { a = c; s = p / 4; }
        else
        {
            if (a == 0)
                s = 0;
            else
                s = p / (2 * Mathf.PI) * Mathf.Asin(c / a);
        }
        if (t < 1) return -0.5f * (a * Mathf.Pow(2, 10 * (t -= 1)) * Mathf.Sin((t * d - s) * (2 * Mathf.PI) / p)) + b;
        return a * Mathf.Pow(2, -10 * (t -= 1)) * Mathf.Sin((t * d - s) * (2 * Mathf.PI) / p) * 0.5f + c + b;
    }
    static public  float EaseInBounce(float t, float b, float c, float d)
    {
        return c - EaseOutBounce(d - t, 0, c, d) + b;
    }
    static public  float EaseOutBounce(float t, float b, float c, float d)
    {
        if ((t /= d) < (1 / 2.75f))
        {
            return c * (7.5625f * t * t) + b;
        }
        else if (t < (2 / 2.75f))
        {
            return c * (7.5625f * (t -= (1.5f / 2.75f)) * t + 0.75f) + b;
        }
        else if (t < (2.5f / 2.75f))
        {
            return c * (7.5625f * (t -= (2.25f / 2.75f)) * t + .9375f) + b;
        }
        else
        {
            return c * (7.5625f * (t -= (2.625f / 2.75f)) * t + 0.984375f) + b;
        }
    }
    static public  float EaseInOutBounce(float t, float b, float c, float d)
    {
        if (t < d / 2) return EaseInBounce(t * 2, 0, c, d) * 0.5f + b;
        return EaseOutBounce(t * 2 - d, 0, c, d) * 0.5f + c * 0.5f + b;
    }
    static public  float EaseInSmoothstep(float t, float b, float c, float d)
    {
        float t2 = (t / d) / 2;
        float x = t2 * t2 * (3 - 2 * t2) * 2;
        return b + c * x;
    }
    static public  float EaseOutSmoothstep(float t, float b, float c, float d)
    {
        float t2 = (t / d + 1) / 2;
        float x = t2 * t2 * (3 - 2 * t2) * 2 - 1;
        return b + c * x;
    }
    static public  float EaseInOutSmoothstep(float t, float b, float c, float d)
    {
        float t2 = t / d;
        float x = t2 * t2 * (3 - 2 * t2);
        return b + c * x;
    }
}
