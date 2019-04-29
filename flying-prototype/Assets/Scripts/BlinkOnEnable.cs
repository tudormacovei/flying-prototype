using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        Blink(2, 0.3f, 0.5f);
    }

    IEnumerator Blink(int blinks, float timeOn, float timeOff)
    {
        while (blinks > 0)
        {
            this.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(timeOn);
            this.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(timeOff);
            blinks--;
        }
    }
}
