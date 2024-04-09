using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftBody : MonoBehaviour
{
    // Start is called before the first frame update

    /* /' =========== '
       | ~~~{ Fields } */
    private static List<SoftBody> __Lmember = new List<SoftBody>();
    private List<DistanceJoint2D> _LdistJoint = new List<DistanceJoint2D>();
    private List<SpringJoint2D> _LspringJoint = new List<SpringJoint2D>();
    private List<HingeJoint2D> _LhingeJoint = new List<HingeJoint2D>();


    /* /' =============== '
       | ~~~{ Properties } */
    public List<SoftBody> __LMember { get; }


    /* /' =========== '
       | ~~~{ Events } */


    /* /' ============ '
       | ~~~{ Methods } */


    /* /' =================== '
    // | ~~~{ UNITY DEFAULTS } */
    void Start()
    {
        __Lmember.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
