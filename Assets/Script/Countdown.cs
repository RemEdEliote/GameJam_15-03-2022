using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float time = 50f;
    public bool countDonwnOn = true;
    void Start()
    {
        StartCoroutine(Timer);
    }

    // Update is called once per frame
    void Update()
    {
        IEnumerator timer()
        {
            while (time>0)
            {
                time--;
                yield return WaitForSeconds (1f);
                GetComponent<TextMeshProUGUI>().text = "" + time;
            }
        }
    }
}
