using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: Trenton Plager
/// Purpose: A class to update the position of the kitchen camera
/// Restrictions: This class shouldn't really have much beyond the TogglePosition method
/// The only reason that method is there is so that the camera can be instructed to lerp
/// to a different position with 1 button click
/// </summary>
public class KitchenCameraPositioning : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private Vector3 leftCameraPosition;             // The desired poistion of the camera on the left side of the kitchen
    [SerializeField]
    private Vector3 rightCameraPosition;            // The desired position of the camera on the right side of the kitchen

    private Vector3 targetPosition;                 // The current target position of the camera. It should be either left or right camera position
    [SerializeField]
    private float lerpQuickener;                    // A float value to make the camera lerp faster
    #endregion

    #region Methods
    /// <summary>
    /// Author: Trenton Plager
    /// Purpose: Sets the default position of the camera to the left side of the kitchen
    /// Restrictions: None
    /// </summary>
    void Start()
    {
        targetPosition = leftCameraPosition;
    }

    /// <summary>
    /// Author: Trenton Plager
    /// Purpose: Lerps the camera's position from its current position to the target position
    /// According to delta time and modified by the quickening factor field
    /// Restrictions: None
    /// </summary>
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpQuickener * Time.deltaTime);
    }

    /// <summary>
    /// Author: Trenton Plager
    /// Purpose: Switches the target position of the camera to the opposite target position
    /// Restrictions: None
    /// </summary>
    public void TogglePosition()
    {
        if (targetPosition == leftCameraPosition)
        {
            targetPosition = rightCameraPosition;
        }
        else
        {
            targetPosition = leftCameraPosition;
        }
    }
    #endregion
}
