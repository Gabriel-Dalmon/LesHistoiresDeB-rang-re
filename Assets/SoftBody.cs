using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoftBody : MonoBehaviour
{
    // Start is called before the first frame update

    /* /' =========== '
       | ~~~{ Fields } */
    private List<SoftBodyCollider> _LSoftBodyCollider;


    /* /' =============== '
       | ~~~{ Properties } */
    public List<SoftBodyCollider> _LSoftBodyColldier { get; }


    /* /' =========== '
       | ~~~{ Events } */


    /* /' ============ '
       | ~~~{ Methods } */


    /* /' =================== '
       | ~~~{ UNITY DEFAULTS } */
    void Start()
    {
        // Fills the list of childrens
        foreach (Transform child in this.transform)
        {
            var comps = child.gameObject.GetComponents(typeof(Component));
            int i = 0;
            foreach (var comp in comps)
            {
                print("Component number " + ++i + " : " + comp.GetType());
                if(comp.GetType() == typeof())
                {
                    print("Pre Attempt " + ++i + " : " + comp.GetType());
                    _LSoftBodyColldier.Append(comp as SoftBodyCollider);
                }
            }
            //_LSoftBodyCollider.Add(child.gameObject.GetComponent(typeof(SoftBodyCollider)) as SoftBodyCollider);
            //_LSoftBodyCollider.Append(child.gameObject.GetComponent(typeof(SoftBodyCollider)) as SoftBodyCollider);
        }

        // Loads every part of the hitbox in the list
        foreach (SoftBodyCollider child in _LSoftBodyCollider)
        {
            foreach (SoftBodyCollider sibling in _LSoftBodyCollider)
            {
                if (child.gameObject == sibling.gameObject)
                    continue;

                child.AddDistJoint(sibling);
            }
        }
    }
}
