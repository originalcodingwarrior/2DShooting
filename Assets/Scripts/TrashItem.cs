using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : Trash 
{
    public AudioClip popopoSound;
    protected AudioSource audioSource;

    //쓰봉 터지면 나오는 쓰레기들 클래스

    // Start is called before the first frame update
    protected override void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(popopoSound);

        base.Start();
        angerImpact = 1;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
