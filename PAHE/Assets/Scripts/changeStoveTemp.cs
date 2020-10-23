using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: John Vance
/// Purpose: Allows for each stove burner to be set independently.
/// Restrictions: Won't fully work until the Kitchen Object Interactions section is finished.
/// </summary>
public class ChangeStoveTemp : MonoBehaviour
{
    public int burnerTR;        // Top Right Burner temp
    private int burnerBR;       // Bottom Right Burner temp
    private int burnerBL;       // Bottom Left Burner temp
    private int burnerTL;       // Top Left Burner temp

    #region Getters
    /// <summary>
    /// Getter for Top Right burner
    /// </summary>
    /// <returns></returns>
    public int getTR()
    {
        return burnerTR;

    }

    /// <summary>
    /// Getter for Bottome Right burner
    /// </summary>
    /// <returns></returns>
    public int getBR()
    {
        return burnerBR;

    }

    /// <summary>
    /// Getter for Bottom Left burner
    /// </summary>
    /// <returns></returns>
    public int getBL()
    {
        return burnerBL;

    }

    /// <summary>
    /// Getter for Top Left burner
    /// </summary>
    /// <returns></returns>
    public int getTL()
    {
        return burnerTL;

    }
    #endregion

    #region Setters
    /// <summary>
    /// Author: John Vance.
    /// Purpose: Setter for Top Right Burner.
    /// Restrictions: None.
    /// </summary>
    /// <param name="x">New Top Right Burner temperature</param>
    public void setTR(int x)
    {
        burnerTR = x;

    }

    /// <summary>
    /// Author: John Vance.
    /// Purpose: Setter for Bottom Right Burner.
    /// Restrictions: None.
    /// </summary>
    /// <param name="x">New Bottom Right Burner temperature</param>
    public void setBR(int x)
    {
        burnerBR = x;

    }

    /// <summary>
    /// Author: John Vance.
    /// Purpose: Setter for Bottom Left Burner.
    /// Restrictions: None.
    /// </summary>
    /// <param name="x">New Bottom Left Burner temperature</param>
    public void setBL(int x)
    {
        burnerBL = x;

    }

    /// <summary>
    /// Author: John Vance.
    /// Purpose: Setter for Top Left Burner.
    /// Restrictions: None.
    /// </summary>
    /// <param name="x">New Top Left Burner temperature</param>
    public void setTL(int x)
    {
        burnerTL = x;

    }
    #endregion


    void Start()
    {
        burnerTR = 0;
        burnerBR = 0;
        burnerBL = 0;
        burnerTL = 0;

    }

    void Update()
    {
        //If player touches stove dial
        
            // then UI window pops up

        //Get input values from player



        
    }
}
