using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public float length;
    public UnityAction action;
    public UnityAction endaction;

    public Effects(float length, UnityAction action, UnityAction endaction)
    {
        this.length = length;
        this.action = action;
        this.action = endaction;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
