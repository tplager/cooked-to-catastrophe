using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: John Vance
/// Purpose: Allows for each stove burner to be set independently.
/// Restrictions: Won't fully work until the Kitchen Object Interactions section is finished.
/// </summary>
public class changeStoveTemp : MonoBehaviour
{
    public int burnerTR = 0;
    private int burnerBR = 0;
    private int burnerBL = 0;
    private int burnerTL = 0;

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
    /// Setter for Top Right burner
    /// </summary>
    /// <param name="x"></param>
    public void setTR(int x)
    {
        burnerTR = x;

    }

    /// <summary>
    /// Setter for Bottom Right burner
    /// </summary>
    /// <param name="x"></param>
    public void setBR(int x)
    {
        burnerBR = x;

    }

    /// <summary>
    /// Setter for Bottom Left burner
    /// </summary>
    /// <param name="x"></param>
    public void setBL(int x)
    {
        burnerBL = x;

    }

    /// <summary>
    /// Setter for Top Left burner
    /// </summary>
    /// <param name="x"></param>
    public void setTL(int x)
    {
        burnerTL = x;

    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If player touches stove dial
            // then UI window pops up

        //Get input values from player



        
    }
}
