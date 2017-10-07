 using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CycleAnimations : MonoBehaviour
{
    public GameObject goStart;
    public GameObject goStop;
    public Dropdown dropdownAnimationList;
    public static GameObject goSTATICStart;
    public static GameObject goSTATICStop;
    public static Dropdown dropdownSTATICAnimationList;

    public Text textDisplayAnimationName;

    public List<string> listrAnimationList;
    public float fTimerBlend = 0.25f;
    private static bool bSTATICStartCycleAnimations = false;
    private static bool bSTATICPlayAnimation = false;
    private Animation manimation;

    void Awake()
    {
        if (goStart != null)
            goSTATICStart = goStart;
        if (goStop != null)
            goSTATICStop = goStop;
        if (dropdownAnimationList != null)
            dropdownSTATICAnimationList = dropdownAnimationList;

        if (dropdownAnimationList != null)
            goSTATICStop.gameObject.SetActive(false);

        listrAnimationList = new List<string>();
        manimation = GetComponent<Animation>();
        fTimerBlend = 0.25f;
        bSTATICStartCycleAnimations = false;

        AnimationsScanning();
    }

    void Start()
    {
        manimation.wrapMode = WrapMode.Once;
    }

    void Update()
    {
        if (bSTATICStartCycleAnimations || bSTATICPlayAnimation)
        {
            Debug.Log("Begin Animations");
            BeginChoreography();
        }
    }

    void BeginChoreography()
    {
        manimation.wrapMode = WrapMode.Once;
        if (bSTATICStartCycleAnimations)
        {
            foreach (string strAnimation in listrAnimationList)
            {
                if (strAnimation.Contains("Idle"))
                {
                    manimation[strAnimation].speed = 0.5f;
                }
                manimation.PlayQueued(strAnimation, QueueMode.CompleteOthers);
                Debug.Log(strAnimation);
            }
        }
        else if (bSTATICPlayAnimation)
        {
            manimation.wrapMode = WrapMode.Loop;
            manimation.Play(dropdownSTATICAnimationList.options[dropdownSTATICAnimationList.value].text, PlayMode.StopAll);
        }
    }

    void AnimationsScanning()
    {
        manimation.enabled = true;
        Debug.Log(manimation.GetClipCount());
        foreach (AnimationState animState in manimation)
        {
            Debug.Log(animState.name);
            listrAnimationList.Add(animState.name);
        }

        if (dropdownSTATICAnimationList != null)
        {
            dropdownSTATICAnimationList.AddOptions(listrAnimationList);
        }
    }

    void OnGUI()
    {
        if (Input.anyKeyDown && goSTATICStart == null)
            bSTATICStartCycleAnimations = true;

        foreach (AnimationState animState in manimation)
        {
            if (manimation.IsPlaying(animState.name))
            {
                if (textDisplayAnimationName == null)
                    GUI.Label(new Rect(40, 40, 300, 150), animState.name, GUIStyle.none);
                else
                    textDisplayAnimationName.text = animState.name.Replace(" - Queued Clone", "");
                bSTATICStartCycleAnimations = false;
                break;
            }
        }
    }

    public void PlaySelectedAnimation()
    {
        if ((dropdownSTATICAnimationList != null))
        {
            bSTATICPlayAnimation = true;
            bSTATICStartCycleAnimations = false;

            if (goSTATICStart != null)
                goSTATICStart.gameObject.SetActive(false);
            if (goSTATICStop != null)
                goSTATICStop.gameObject.SetActive(true);
        }
    }
    public void StartCycleAnimations()
    {
        bSTATICStartCycleAnimations = true;
        bSTATICPlayAnimation = false;

        if (goSTATICStart != null)
            goSTATICStart.gameObject.SetActive(false);
        if (goSTATICStop != null)
            goSTATICStop.gameObject.SetActive(true);
    }

    public void StopAnimations()
    {
        bSTATICStartCycleAnimations = false;
        bSTATICPlayAnimation = false;

        if (goSTATICStart != null)
            goSTATICStart.gameObject.SetActive(true);
        if (goSTATICStop != null)
            goSTATICStop.gameObject.SetActive(false);

        manimation.Stop();
    }
}
