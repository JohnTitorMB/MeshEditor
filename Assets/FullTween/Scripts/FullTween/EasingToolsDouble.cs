using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public static class EasingToolsdouble
{
    static public double Linear(double t, double b, double c, double d)
    {
        return b + c * t / d;
    }
    static public double EaseInQuad(double t, double b, double c, double d)
    {
        return c * (t /= d) * t + b;
    }
    static public double EaseOutQuad(double t, double b, double c, double d)
    {
        return -c * (t /= d) * (t - 2) + b;
    }
    static public double EaseInOutQuad(double t, double b, double c, double d)
    {
        if ((t /= d / 2) < 1) return c / 2 * t * t + b;
        return -c / 2 * ((--t) * (t - 2) - 1) + b;
    }
    static public double EaseInCubic(double t, double b, double c, double d)
    {
        return c * (t /= d) * t * t + b;
    }
    static public double EaseOutCubic(double t, double b, double c, double d)
    {
        return c * ((t = t / d - 1) * t * t + 1) + b;
    }
    static public double EaseInOutCubic(double t, double b, double c, double d)
    {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t + b;
        return c / 2 * ((t -= 2) * t * t + 2) + b;
    }
    static public double EaseInQuart(double t, double b, double c, double d)
    {
        return c * (t /= d) * t * t * t + b;
    }
    static public double EaseOutQuart(double t, double b, double c, double d)
    {
        return -c * ((t = t / d - 1) * t * t * t - 1) + b;
    }
    static public double EaseInOutQuart(double t, double b, double c, double d)
    {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t * t + b;
        return -c / 2 * ((t -= 2) * t * t * t - 2) + b;
    }
    static public double EaseInQuint(double t, double b, double c, double d)
    {
        return c * (t /= d) * t * t * t * t + b;

    }
    static public double EaseOutQuint(double t, double b, double c, double d)
    {
        return c * ((t = t / d - 1) * t * t * t * t + 1) + b;
    }
    static public double EaseInOutQuint(double t, double b, double c, double d)
    {
        if ((t /= d / 2) < 1) return c / 2 * t * t * t * t * t + b;
        return c / 2 * ((t -= 2) * t * t * t * t + 2) + b;
    }
    static public double EaseInCircle(double t, double b, double c, double d)
    {
        return -c * (Math.Sqrt(1 - (t /= d) * t) - 1) + b;
    }
    static public double EaseOutCircle(double t, double b, double c, double d)
    {
        return c * Math.Sqrt(1 - (t = t / d - 1) * t) + b;
    }
    static public double EaseInOutCircle(double t, double b, double c, double d)
    {
        if ((t /= d / 2) < 1) return -c / 2 * (Math.Sqrt(1 - t * t) - 1) + b;
        return c / 2 * (Math.Sqrt(1 - (t -= 2) * t) + 1) + b;
    }
    static public double EaseInBack(double t, double b, double c, double d)
    {
        double s = 1.70158f;
        return c * (t /= d) * t * ((s + 1) * t - s) + b;
    }
    static public double EaseOutBack(double t, double b, double c, double d)
    {
        double s = 1.70158f;
        return c * ((t = t / d - 1) * t * ((s + 1) * t + s) + 1) + b;
    }
    static public double EaseInOutBack(double t, double b, double c, double d)
    {
        double s = 1.70158f;
        if ((t /= d / 2) < 1) return c / 2 * (t * t * (((s *= (1.525f)) + 1) * t - s)) + b;
        return c / 2 * ((t -= 2) * t * (((s *= (1.525f)) + 1) * t + s) + 2) + b;

    }
    static public double EaseInElastic(double t, double b, double c, double d)
    {
        double s = 1.70158f;
        double p = 0;
        double a = c;
        if (t == 0)
            return b;
        if ((t /= d) == 1)
            return b + c;

        p = d * 0.3f;

        if (a < Math.Abs(c))
        {
            a = c;
            s = p / 4;
        }
        else
        {
            if (a == 0)
                s = 0;
            else
                s = p / (2 * Math.PI) * Math.Asin(c / a);
        }
        return -(a * Math.Pow(2, 10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b;

    }
    static public double EaseOutElastic(double t, double b, double c, double d)
    {
        double s = 1.70158f;
        double p = 0;
        double a = c;
        if (t == 0)
            return b;
        if ((t /= d) == 1)
            return b + c;

        p = d * 0.3f;
        if (a < Math.Abs(c))
        {
            a = c;
            s = p / 4;
        }
        else
        {
            if (a == 0)
                s = 0;
            else
                s = p / (2 * Math.PI) * Math.Asin(c / a);
        }

        return a * Math.Pow(2, -10 * t) * Math.Sin((t * d - s) * (2 * Math.PI) / p) + c + b;

    }
    static public double EaseInOutElastic(double t, double b, double c, double d)
    {
        double s = 1.70158f; double p = 0; double a = c;
        if (t == 0) return b; if ((t /= d / 2) == 2) return b + c; p = d * (0.3f * 1.5f);
        if (a < Math.Abs(c)) { a = c; s = p / 4; }
        else
        {
            if (a == 0)
                s = 0;
            else
                s = p / (2 * Math.PI) * Math.Asin(c / a);
        }
        if (t < 1) return -0.5f * (a * Math.Pow(2, 10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p)) + b;
        return a * Math.Pow(2, -10 * (t -= 1)) * Math.Sin((t * d - s) * (2 * Math.PI) / p) * 0.5f + c + b;
    }
    static public double EaseInBounce(double t, double b, double c, double d)
    {
        return c - EaseOutBounce(d - t, 0, c, d) + b;
    }
    static public double EaseOutBounce(double t, double b, double c, double d)
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
    static public double EaseInOutBounce(double t, double b, double c, double d)
    {
        if (t < d / 2) return EaseInBounce(t * 2, 0, c, d) * 0.5f + b;
        return EaseOutBounce(t * 2 - d, 0, c, d) * 0.5f + c * 0.5f + b;
    }
    static public double EaseInSmoothstep(double t, double b, double c, double d)
    {
        double t2 = (t / d) / 2;
        double x = t2 * t2 * (3 - 2 * t2) * 2;
        return b + c * x;
    }
    static public double EaseOutSmoothstep(double t, double b, double c, double d)
    {
        double t2 = (t / d + 1) / 2;
        double x = t2 * t2 * (3 - 2 * t2) * 2 - 1;
        return b + c * x;
    }
    static public double EaseInOutSmoothstep(double t, double b, double c, double d)
    {
        double t2 = t / d;
        double x = t2 * t2 * (3 - 2 * t2);
        return b + c * x;
    }
}
