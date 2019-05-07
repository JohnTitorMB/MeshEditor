using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullTweenTest : MonoBehaviour {

    FullTween fulltween;

	void Start ()
    {
        fulltween = GetComponent<FullTween>();
        fulltween.OntweenStart += Print;
        fulltween.OntweenEnd += PrintEnd;
        fulltween.StartFullTween(EStartValue.StartValue);
        fulltween.Function = EFunction.EaseInOutSmoothstep;
        fulltween.Mode = EMode.Normal;
    }
	
	void Print ()
    {
        Debug.Log("Start Fulltween");
	}

    void PrintEnd()
    {
        Debug.Log("End Fulltween");
    }
}
