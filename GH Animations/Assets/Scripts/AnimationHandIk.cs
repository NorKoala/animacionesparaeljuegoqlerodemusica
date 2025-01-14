using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandIk : MonoBehaviour
{
    private Animator anim;
	Transform LHand;
	Transform RHand;
	
	public Transform LeftHandObj = null;
	public Transform rightHandObj = null;
	
	public Transform LeftFeetObj = null;
	public Transform rightFeetObj = null;
	
	public bool rotation = true;
	
	//private AimIKBehaviour3D aimIK;
	
	// Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
		/*LHand = anim.GetBoneTransform(HumanBodyBones.LeftHand);
		RHand = anim.GetBoneTransform(HumanBodyBones.RightHand);*/
    }

    void OnAnimatorIK(int layerIndex)
    {
		if (anim) {
			
        if (rightHandObj != null ) {
            anim.SetIKPositionWeight (AvatarIKGoal.RightHand,1);
            if(rotation)anim.SetIKRotationWeight (AvatarIKGoal.RightHand,1);
            anim.SetIKPosition (AvatarIKGoal.RightHand,rightHandObj.position);
            if(rotation)anim.SetIKRotation (AvatarIKGoal.RightHand,rightHandObj.rotation);
        }
        if (LeftHandObj != null) {
            anim.SetIKPositionWeight (AvatarIKGoal.LeftHand,1);
            if(rotation)anim.SetIKRotationWeight (AvatarIKGoal.LeftHand,1);
            anim.SetIKPosition (AvatarIKGoal.LeftHand,LeftHandObj.position);
            if(rotation)anim.SetIKRotation (AvatarIKGoal.LeftHand,LeftHandObj.rotation);
        }
		
        if (rightFeetObj != null ) {
            anim.SetIKPositionWeight (AvatarIKGoal.RightFoot,1);
            if(rotation)anim.SetIKRotationWeight (AvatarIKGoal.RightFoot,1);
            anim.SetIKPosition (AvatarIKGoal.RightFoot,rightFeetObj.position);
            if(rotation)anim.SetIKRotation (AvatarIKGoal.RightFoot,rightFeetObj.rotation);
        }
        if (LeftFeetObj != null) {
            anim.SetIKPositionWeight (AvatarIKGoal.LeftFoot,1);
            if(rotation)anim.SetIKRotationWeight (AvatarIKGoal.LeftFoot,1);
            anim.SetIKPosition (AvatarIKGoal.LeftFoot,LeftFeetObj.position);
            if(rotation)anim.SetIKRotation (AvatarIKGoal.LeftFoot,LeftFeetObj.rotation);
        }
    }
	}
}

