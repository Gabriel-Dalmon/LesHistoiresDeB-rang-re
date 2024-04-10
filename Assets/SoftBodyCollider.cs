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
    private List<DistanceJoint2D> _LdistJoint;
    private List<SpringJoint2D> _LspringJoint;
    private List<HingeJoint2D> _LhingeJoint;


    /* /' =============== '
       | ~~~{ Properties } */


    /* /' =========== '
       | ~~~{ Events } */


    /* /' ============ '
       | ~~~{ Methods } */
    // Adds a Distance Joint to the SoftBodyCollider
    public void AddDistJoint(SoftBodyCollider ARGneighbor)
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
        _LdistJoint.Append<DistanceJoint2D>(distJoint);
    }

    // Adds a Spring Joint to the SoftBodyCollider
    public void AddSpringJoint(SoftBodyCollider ARGneighbor)
    {
        // Builds the Spring Joint
        SpringJoint2D springJoint = new SpringJoint2D();

        springJoint.enableCollision = false;
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.autoConfigureDistance = true;

        springJoint.breakAction = JointBreakAction2D.Destroy;
        springJoint.breakForce = float.PositiveInfinity;

        springJoint.anchor = new Vector2(0, 0);
        springJoint.connectedAnchor = new Vector2(0, 0);

        springJoint.connectedBody = ARGneighbor.gameObject.GetComponent<Rigidbody2D>();

        // Adds the Joint to the SoftBodyCollider
        _LspringJoint.Append<SpringJoint2D>(springJoint);
    }

    // Adds a Hinge Joint to the SoftBodyCollider
    public void AddHingeJoint(SoftBodyCollider ARGneighbor)
    {
        // Builds the Hinge Joint
        HingeJoint2D hingeJoint = new HingeJoint2D();

        hingeJoint.enableCollision = false;
        hingeJoint.autoConfigureConnectedAnchor = false;
        hingeJoint.useMotor = false;
        hingeJoint.useLimits = true;
        
        hingeJoint.breakAction = JointBreakAction2D.Destroy;
        hingeJoint.breakForce = float.PositiveInfinity;
        hingeJoint.breakTorque = float.PositiveInfinity;

        hingeJoint.anchor = new Vector2(0, 0);
        hingeJoint.connectedAnchor = new Vector2(0, 0);

        JointAngleLimits2D angleLimits = new JointAngleLimits2D();
        angleLimits.min = -53;
        angleLimits.max = 53;
        hingeJoint.limits = angleLimits;

        // Adds the Joint to the SoftBodyCollider
        _LhingeJoint.Append<HingeJoint2D>(hingeJoint);
    }

    /* /' =================== '
       | ~~~{ UNITY DEFAULTS } */
}
