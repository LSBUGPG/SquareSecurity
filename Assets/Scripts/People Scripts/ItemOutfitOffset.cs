using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOutfitOffset : MonoBehaviour {

    //public float OffsetX;
    //public float OffsetY;
    //public float OffsetZ;
    public Vector3 Offset;


	// Use this for initialization
	void Start () {

        var itemTransform = transform.position;
        itemTransform.x += Offset.x;
        itemTransform.y += Offset.y;
        itemTransform.z += Offset.z;
        transform.position = itemTransform;


        //var t = transform.position;
        //var e = transform.position;
        //var a = transform.position;
        //t.y += OffsetY;
        //e.z += OffsetZ;
        //a.x += OffsetX;
        //transform.localPosition = t;
        //transform.localPosition = e;
        //transform.localPosition = a;
    }
	
}
