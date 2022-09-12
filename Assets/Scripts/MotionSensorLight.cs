using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSensorLight : MonoBehaviour
{
    Light lght;
    int countdownTime = 3;


    void Start()
    {
        lght = GetComponent<Light>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag.Equals("Player") && !lght.enabled);
        {
            //play sound
            lght.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag.Equals("Player") && lght.enabled);
            StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        float cnt = countdownTime;
        while(cnt > 0)
        {
            Debug.Log(cnt);
            yield return new WaitForSeconds(1f);

            cnt--;
        }
        Debug.Log("closed");
        lght.enabled = false;
    }
}
