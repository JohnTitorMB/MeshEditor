using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

    [SerializeField]
    FullTween transitionFullTween;

    [SerializeField]
    int nextScene = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine(CorotineTransition());
    }

    IEnumerator CorotineTransition()
    {
        yield return new WaitForSeconds(10);
        transform.position = new Vector3(0, -22.5f, 0);

        transitionFullTween.StartFullTween(EStartValue.CurrentValue);
        transitionFullTween.OntweenEnd += TransitionActive;
    }

    void TransitionActive()
    {
        SceneManager.LoadScene(nextScene);
    }
}
