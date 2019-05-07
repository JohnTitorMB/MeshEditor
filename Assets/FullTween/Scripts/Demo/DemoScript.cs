using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoScript : MonoBehaviour
{
    [SerializeField]
    FullTween[] fulltweens;

    [SerializeField]
    FullTween[] fulltweenEvent;

    [SerializeField]
    Text pauseText;
    enum State
    {
        RESUME,
        PAUSE,
    }

    State state = State.RESUME;
    // Use this for initialization
    void Start ()
    {
        fulltweenEvent[0].OntweenEnd += delegate () { fulltweenEvent[1].StartFullTween(EStartValue.StartValue); };
        fulltweenEvent[1].OntweenEnd += delegate () { fulltweenEvent[2].StartFullTween(EStartValue.StartValue); };
    }

    public void Pause()
    {
        if(state == State.RESUME)
        {
            foreach (FullTween fulltween in fulltweens)
                fulltween.Pause();

            state = State.PAUSE;
            pauseText.text = "Resume";

        }
        else
        {
            foreach (FullTween fulltween in fulltweens)
                fulltween.Resume();

            state = State.RESUME;
            pauseText.text = "Pause";

        }
    }
    public void Reverse()
    {
        foreach (FullTween fulltween in fulltweens)
            fulltween.Reverse();
    }

    public void StartFullTween()
    {
            fulltweenEvent[0].StartFullTween(EStartValue.StartValue);
    }
}
