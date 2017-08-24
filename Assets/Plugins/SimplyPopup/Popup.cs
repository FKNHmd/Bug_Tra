using UnityEngine;
using System.Collections;
using UniRx;

public class Popup : MonoBehaviour
{
    public enum State
    {
        Open,
        Close,
        UnUsed
    }

    public State state { get; private set; }

    public TweenScale open, close;

	public GameObject popup_haikei;

	static int opennum = 0;

    void Start ()
    {
        open.Setup (gameObject);
        open.scaleEndAsObservable.Subscribe (_ => state = State.Open);
        close.Setup (gameObject);
        close.scaleEndAsObservable.Subscribe (_ => state = State.Close);
    }

    public void Hide(int i)
    {
        if (i == 1)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Open ()
    {
        open.Play ();
		opennum++;
		Debug.Log (opennum);
    }

    public void Close ()
    {
        close.Play ();
		opennum--;
		Debug.Log (opennum);

		if (opennum <= 0) {
			popup_haikei.SetActive (false);
		}
    }

    public void Toggle ()
    {
        switch (state) {
        case State.UnUsed:
        case State.Close:
            open.Play ();
            break;
        case State.Open:
            close.Play ();
            break;
        }
    }

	public void opennum_reset()
	{
		opennum = 0;
	}

	public int get_opennum()
	{
		return opennum;
	}
}
