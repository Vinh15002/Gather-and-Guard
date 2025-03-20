using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ProgressBar : MonoBehaviour
{
    public Sprite iconTrain;
    public Sprite iconSetting;
    public Sprite iconContact;
    public Sprite iconBuild;
    private Slider slider;
    private Image icon;
    private bool isProgress = false;
    private float timeProgress = -1f;
    public static ProgressBar Instance;

    void Start()
    {
        Instance = this;
        slider = GetComponent<Slider>();
        icon = transform.Find("Icon").GetComponent<Image>();
    }

    public void ExecuteProgress(float time, int type){
        GetTimeProgress(time);
        SetIcon(type);
        if(isProgress && timeProgress>0){
            StartCoroutine(ExecuteMission());
        }
    }

    public void SetIcon(int type){
        if(type==0){
            icon.sprite = iconBuild;
        }
        else if(type==1){
            icon.sprite = iconTrain;
        }
        else if(type==2){
            icon.sprite = iconSetting;
        }
        else
        {
            icon.sprite = iconContact;
        }
    }

    public void GetTimeProgress(float time){
        if(!isProgress){
            isProgress = true;
            timeProgress = time;
        }
    }
    
    public IEnumerator ExecuteMission(){
        float time = 0;
        while (time < timeProgress)
        {
            yield return new WaitForSeconds(1);
            time++;
            slider.value = time/timeProgress;
            Debug.Log(time/timeProgress);
        }
        Debug.Log("Complete");
        isProgress = false;
        timeProgress = -1;
    }
}
