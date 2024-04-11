using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
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
        // Adds a new joint first
        this.gameObject.AddComponent<DistanceJoint2D>();

        // Gets the reference to that one unique new Distance Joint 2D
        DistanceJoint2D newDistJoint = this.gameObject.GetComponents<DistanceJoint2D>().Last();

        // Calibrates the new joint we added two lines ago
        newDistJoint.enableCollision = false;
        newDistJoint.autoConfigureConnectedAnchor = false;
        newDistJoint.autoConfigureDistance = false;
        newDistJoint.maxDistanceOnly = true;

        newDistJoint.distance = .5f;

        newDistJoint.breakAction = JointBreakAction2D.Destroy;
        newDistJoint.breakForce = float.PositiveInfinity;

        newDistJoint.anchor = new Vector2(0, 0);
        newDistJoint.connectedAnchor = new Vector2(0, 0);

        newDistJoint.connectedBody = ARGneighbor.gameObject.GetComponent<Rigidbody2D>();
    }

    // Adds a Spring Joint to the SoftBodyCollider
    public void AddSpringJoint(Transform ARGneighbor, int ARGselfIndex, int ARGneighborIndex, int ARGfamilySize)
    {
        // Adds a new joint first
        this.gameObject.AddComponent<SpringJoint2D>();

        // Gets the reference to that one unique new Distance Joint 2D
        SpringJoint2D newSpringJoint = this.gameObject.GetComponents<SpringJoint2D>().Last();

        // Calibrates the new joint we added two lines ago
        newSpringJoint.enableCollision = false;
        newSpringJoint.autoConfigureConnectedAnchor = false;
        newSpringJoint.autoConfigureDistance = false;
        newSpringJoint.distance = .2f;

        newSpringJoint.breakAction = JointBreakAction2D.Destroy;
        newSpringJoint.breakForce = float.PositiveInfinity;

        newSpringJoint.anchor = new Vector2(0, 0);
        newSpringJoint.connectedAnchor = new Vector2(0, 0);

        newSpringJoint.dampingRatio = 0;
        newSpringJoint.frequency = (ARGfamilySize - Math.Abs(ARGselfIndex - ARGneighborIndex));

        newSpringJoint.connectedBody = ARGneighbor.gameObject.GetComponent<Rigidbody2D>();
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
