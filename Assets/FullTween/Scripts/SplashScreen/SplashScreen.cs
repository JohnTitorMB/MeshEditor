using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour {

    [SerializeField]
    FullTween logo2D,logo3D,logoFullTween;

    // Use this for initialization
    void Start () {
        logoFullTween.OntweenEnd += delegate () { logo2D.StartFullTween(EStartValue.StartValue);  };
        logo2D.OntweenEnd += delegate () { logo3D.StartFullTween(EStartValue.StartValue); };
        StartCoroutine(CorotineTransition());
    }

    IEnumerator CorotineTransition()
    {
        yield return new WaitForSeconds(5);
        logoFullTween.StartFullTween(EStartValue.StartValue);
    }
}
