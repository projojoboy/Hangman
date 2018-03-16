using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalgController : MonoBehaviour {

    [SerializeField] GameObject[] galg;

    private void Start()
    {
        for(int i = 0; i < galg.Length; i++)
        {
            galg[i].SetActive(false);
        }
    }

    public void Levels(int level)
    {
        galg[level].SetActive(true);
    }
}
