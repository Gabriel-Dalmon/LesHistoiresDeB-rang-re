using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SoftBody : MonoBehaviour
{
    // Start is called before the first frame update

    /* /' =========== '
       | ~~~{ Fields } */
    /*   !!!! !!!!
     *     abandonned code since passing ANYTHING to the list while the list is of ANY TYPE ends in a "null object being passed to the list boohooo"
     *     fuckien bullshit.
     *   !!!! !!!!
     * private List<Transform> Lchildren;
     */


    /* /' =============== '
       | ~~~{ Properties } */

    /*   !!!! !!!!
     *     abandonned code since passing ANYTHING to the list while the list is of ANY TYPE ends in a "null object being passed to the list boohooo"
     *     fuckien bullshit.
     *   !!!! !!!!
     * public List<SoftBodyCollider> _LSoftBodyColldier { get; }
     */

    /* /' =========== '
       | ~~~{ Events } */


    /* /' ============ '
       | ~~~{ Methods } */


    /* /' =================== '
       | ~~~{ UNITY DEFAULTS } */
    void Start()
    {
        /*   !!!! !!!!
         *     abandonned code since passing ANYTHING to the list while the list is of ANY TYPE ends in a "null object being passed to the list boohooo"
         *     fuckien bullshit.
         *   !!!! !!!!
         * // Fills the list of childrens
         * foreach (Transform child in this.transform)
         * {
         *    //var comps = child.gameObject.GetComponents(typeof(Component));
         *    //int i = 0;
         *    //foreach (var comp in comps)
         *    //{
         *    //    print("Component number " + ++i + " : " + comp.GetType());
         *    //    if(comp.GetType() == typeof(SoftBodyCollider))
         *    //    {
         *    //        print("Pre Attempt " + ++i + " : " + comp.GetType());
         *    //        _LSoftBodyColldier.Append(comp as SoftBodyCollider);
         *    //    }
         *    //}
         *    print("Child data[Type: " + child.GetType() + ", UnityNull: " + child.IsUnityNull() + ", C#Null: " + child == null + "]");
         *    Lchildren.Add(child);
         * }
         */

        // Loads every part of the hitbox in the list
        foreach (Transform child in this.transform)
        {
            print("working on child " + child.gameObject.name + "...");
            foreach (Transform sibling in this.transform)
            {
                if (child.gameObject == sibling.gameObject)
                {
                    //print("link between " + child.gameObject.name + " and " +  sibling.gameObject.name + " SKIPPED !");
                    continue;
                }

                //print("linking " + child.gameObject.name + " and " + sibling.gameObject.name);
                //child.gameObject.GetComponent<SoftBodyCollider>().AddDistJoint(sibling);


                // Builds the Distance Joint
                child.gameObject.AddComponent<DistanceJoint2D>();

                child.gameObject.GetComponent<DistanceJoint2D>().enableCollision = false;
                child.gameObject.GetComponent<DistanceJoint2D>().autoConfigureConnectedAnchor = false;
                child.gameObject.GetComponent<DistanceJoint2D>().autoConfigureDistance = true;
                child.gameObject.GetComponent<DistanceJoint2D>().maxDistanceOnly = true;

                child.gameObject.GetComponent<DistanceJoint2D>().breakAction = JointBreakAction2D.Destroy;
                child.gameObject.GetComponent<DistanceJoint2D>().breakForce = float.PositiveInfinity;

                child.gameObject.GetComponent<DistanceJoint2D>().anchor = new Vector2(0, 0);
                child.gameObject.GetComponent<DistanceJoint2D>().connectedAnchor = new Vector2(0, 0);

                child.gameObject.GetComponent<DistanceJoint2D>().connectedBody = new Rigidbody2D();
                child.gameObject.GetComponent<DistanceJoint2D>().connectedBody = sibling.gameObject.GetComponent<Rigidbody2D>();
            }
        }
    }
}
