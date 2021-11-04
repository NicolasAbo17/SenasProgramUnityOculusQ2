using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRHandCollider : MonoBehaviour
{
    private OVRSkeleton skeleton;

    // Start is called before the first frame update
    void Start()
    {
        skeleton = gameObject.GetComponent<OVRSkeleton>();
        if (skeleton)
        {
            foreach (OVRBone bone in skeleton.Bones)
            {
                bone.Transform.gameObject.AddComponent<SphereCollider>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
