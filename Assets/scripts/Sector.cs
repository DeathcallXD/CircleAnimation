using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public float value = 1f;
    //public float progress = 0f;
    public Color[] sectorColors;
    public Image sectorPrefab;
    public bool flag = true;
    float prevTime;
    float newTime;
    float duration = 2f;
    int count = 0;
    float zRot = 0f;
    System.DateTime startTime;

    private void Start()
    {
        startTime = System.DateTime.UtcNow;
    }

    void Update()
    {
        System.TimeSpan timeDel = System.DateTime.UtcNow - startTime;
        newTime = timeDel.Seconds;
        if (flag)
        {
            if (timeDel.Seconds > 0 && newTime % duration == 0 && newTime - prevTime >= 1f)
            {
                MakeSectors(count); count++; prevTime = newTime;
                if (count >= value)
                {
                    flag = false;
                }
            }
            if (timeDel.Seconds > 0 && newTime % duration == 1 && newTime - prevTime >= 1f)
            {
                MakeSectors(count); count++; prevTime = newTime;
                if (count >= value)
                {
                    flag = false;
                }
            }
        }

    }

    void MakeSectors(int i)
    {
        Image newSector = Instantiate(sectorPrefab) as Image;
        newSector.transform.SetParent(transform, false);
        newSector.color = sectorColors[i % 2];
        newSector.fillAmount = (1 / value);
        newSector.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRot));
        zRot -= newSector.fillAmount * 360f;
    }

}
