using System;
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
        int childIndex = 0;
        int siblingIndex = 0;
        foreach (Transform child in this.transform)
        {
            foreach (Transform sibling in this.transform)
            {
                if (child.gameObject == sibling.gameObject)
                {
                    ++siblingIndex;
                    continue;
                }

                //child.gameObject.GetComponent<SoftBodyCollider>().AddDistJoint(sibling);
                //print("Testing child: " + child.gameObject.name + " and sibling: " + sibling.gameObject.name);
                if( Math.Abs(childIndex - siblingIndex) == 1 )
                {
                    //print("PASSED (" + childIndex + ") and (" + siblingIndex + ")");
                    child.gameObject.GetComponent<SoftBodyCollider>().AddSpringJoint(sibling, childIndex, siblingIndex, this.transform.childCount);
                }
                ++siblingIndex;
            }
            ++childIndex;
            siblingIndex = 0;
        }

        //Debug.Break();
    }

    private void Update()
    {
        // Checks every part of the soft body to ensure no one is too close to another
        for (int i = 0;  i < this.transform.childCount;  ++i)
        {
            // Setup useful variable that will used through tests and adaptations
            var curChild = this.transform.GetChild(i);
            float minDist = .2f;
            Vector2 minVec = new Vector2((float)Math.Sqrt(minDist), (float)Math.Sqrt(minDist));
            Vector2 distVec = new Vector2(0, 0);

            // Performs the check for the part after (if there's any)
            if ((i + 1) < this.transform.childCount)
            {
                // Determines the vector between both parts
                distVec = this.transform.GetChild(i + 1).transform.position - curChild.transform.position;
                if (distVec.magnitude < minDist)
                {
                    print("(" + (i + 1) + ") is too close to (" + i + ")");
                    //Debug.Break();
                    // We know a part is too close, so let's move it away !
                    // First, we normalize our vector that separates the two
                    print("(" + i + ").pos : " + curChild.gameObject.transform.position + " || (" + (i+1) + ").pos : " + this.transform.GetChild(i+1).transform.position);
                    print("distVec : " + distVec);
                    Vector2 normalizedDistVec = new Vector2(distVec.x, distVec.y);
                    normalizedDistVec.Normalize();
                    print("normalizedDistVec : " + normalizedDistVec + "[" + normalizedDistVec.magnitude + "]");

                    // Then, we multiply our now normalized vector with out wanted distance
                    normalizedDistVec.x *= minDist;
                    normalizedDistVec.y *= minDist;
                    print("normalizedDIstVec after + : " + normalizedDistVec + "[" + normalizedDistVec.magnitude + "]");

                    // Finally, let's apply that to that pesky, way-too-close other part
                    // To make sure it's good, we teleport it to our current part, and then translate it
                    this.transform.GetChild(i+1).transform.position = curChild.transform.position;
                    print("(" + (i + 1) + ").pos (tp) -> " + this.transform.GetChild(i + 1).transform.position);
                    this.transform.GetChild(i + 1).transform.Translate(normalizedDistVec, Space.World);
                    print("(" + (i + 1) + ").pos (tr) -> " + this.transform.GetChild(i + 1).transform.position);
                }
            }

            // Performs the check for the part before (if there's any)
            if ((i - 1) >= 0)
            {
                // Determines the vector between both parts
                distVec = this.transform.GetChild(i - 1).transform.position - curChild.transform.position;
                if (distVec.magnitude < minDist)
                {
                    // We know a part is too close, so let's move it away !
                    // First, we normalize our vector that separates the two
                    Vector2 normalizedDistVec = new Vector2(distVec.x, distVec.y);
                    normalizedDistVec.Normalize();

                    // Then, we multiply our now normalized vector with out wanted distance
                    normalizedDistVec.x *= minDist;
                    normalizedDistVec.y *= minDist;

                    // Finally, let's apply that to that pesky, way-too-close other part
                    // To make sure it's good, we teleport it to our current part, and then translate it
                    this.transform.GetChild(i - 1).transform.position = curChild.transform.position;
                    this.transform.GetChild(i - 1).transform.Translate(normalizedDistVec, Space.World);
                }
            }
        }
    }
}
