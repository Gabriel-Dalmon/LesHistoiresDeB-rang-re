using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedScript : MonoBehaviour
{
    public ShellController shellController;
    int _groundsCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            _groundsCount++;
            if (_groundsCount == 1)
            {
                shellController.IsGrounded = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            _groundsCount--;
            if (_groundsCount == 0)
            {
                shellController.IsGrounded = false;
            }
        }
    }
}