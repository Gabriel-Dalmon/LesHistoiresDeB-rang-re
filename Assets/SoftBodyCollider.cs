using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoftBodyCollider : MonoBehaviour
{
    // Start is called before the first frame update

    /* /' =========== '
       | ~~~{ Fields } */
    Dictionary<int, DistanceJoint2D> _DDistJoint2D;
    Dictionary<int, SpringJoint2D> _DSpringJoint2D;
    Dictionary<int, HingeJoint2D> _HingeJoint2D;


    /* /' =============== '
       | ~~~{ Properties } */


    /* /' =========== '
       | ~~~{ Events } */


    /* /' ============ '
       | ~~~{ Methods } */
    // Adds a Distance Joint to the SoftBodyCollider
    public void AddDistJoint(Transform ARGneighbor)
    {
        // Builds the Distance Joint
        DistanceJoint2D distJoint = new DistanceJoint2D();

        distJoint.enableCollision = false;
        distJoint.autoConfigureConnectedAnchor = false;
        distJoint.autoConfigureDistance = true;
        distJoint.maxDistanceOnly = true;

        distJoint.breakAction = JointBreakAction2D.Destroy;
        distJoint.breakForce = float.PositiveInfinity;

        distJoint.anchor = new Vector2(0, 0);
        distJoint.connectedAnchor = new Vector2(0, 0);

        distJoint.connectedBody = ARGneighbor.gameObject.GetComponent<Rigidbody2D>();

        // Adds (Apply) the Joint to the SoftBodyCollider
        this.gameObject.AddComponent<DistanceJoint2D>(distJoint);
    }

    // Adds a Spring Joint to the SoftBodyCollider
    public void AddSpringJoint(Transform ARGneighbor)
    {
        // Builds the Spring Joint
        this.gameObject.AddComponent<SpringJoint2D>();

        this.gameObject.GetComponent<SpringJoint2D>().enableCollision = false;
        this.gameObject.GetComponent<SpringJoint2D>().autoConfigureConnectedAnchor = false;
        this.gameObject.GetComponent<SpringJoint2D>().autoConfigureDistance = true;

        this.gameObject.GetComponent<SpringJoint2D>().breakAction = JointBreakAction2D.Destroy;
        this.gameObject.GetComponent<SpringJoint2D>().breakForce = float.PositiveInfinity;

        this.gameObject.GetComponent<SpringJoint2D>().anchor = new Vector2(0, 0);
        this.gameObject.GetComponent<SpringJoint2D>().connectedAnchor = new Vector2(0, 0);

        this.gameObject.GetComponent<SpringJoint2D>().connectedBody = ARGneighbor.gameObject.GetComponent<Rigidbody2D>();
    }

    // Adds a Hinge Joint to the SoftBodyCollider
    public void AddHingeJoint(Transform ARGneighbor)
    {
        // Builds the Hinge Joint
        this.gameObject.AddComponent<HingeJoint2D>();

        this.gameObject.GetComponent<HingeJoint2D>().enableCollision = false;
        this.gameObject.GetComponent<HingeJoint2D>().autoConfigureConnectedAnchor = false;
        this.gameObject.GetComponent<HingeJoint2D>().useMotor = false;
        this.gameObject.GetComponent<HingeJoint2D>().useLimits = true;
        
        this.gameObject.GetComponent<HingeJoint2D>().breakAction = JointBreakAction2D.Destroy;
        this.gameObject.GetComponent<HingeJoint2D>().breakForce = float.PositiveInfinity;
        this.gameObject.GetComponent<HingeJoint2D>().breakTorque = float.PositiveInfinity;

        this.gameObject.GetComponent<HingeJoint2D>().anchor = new Vector2(0, 0);
        this.gameObject.GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);

        JointAngleLimits2D angleLimits = new JointAngleLimits2D();
        angleLimits.min = -53;
        angleLimits.max = 53;
        this.gameObject.GetComponent<HingeJoint2D>().limits = angleLimits;
    }

    /* /' =================== '
       | ~~~{ UNITY DEFAULTS } */
}
