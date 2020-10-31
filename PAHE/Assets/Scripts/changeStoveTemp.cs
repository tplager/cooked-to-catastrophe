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
    [SerializeField]
    private int burnerTR;       // Top Right Burner temp

    [SerializeField]
    private int burnerBR;       // Bottom Right Burner temp

    [SerializeField]
    private int burnerBL;       // Bottom Left Burner temp

    [SerializeField]
    private int burnerTL;       // Top Left Burner temp

    #region Getters/Setters
    /// <summary>
    /// Getter/Setter for Top Right burner
    /// </summary>
    /// <returns></returns>
    public int BurnerTR
    {
        get { return burnerTR; }
        set { burnerTR = value; }
    }

    /// <summary>
    /// Getter/Setter for Bottome Right burner
    /// </summary>
    /// <returns></returns>
    public int BurnerBR
    {
        get { return burnerBR; }
        set { burnerBR = value; }
    }

    /// <summary>
    /// Getter/Setter for Bottom Left burner
    /// </summary>
    /// <returns></returns>
    public int BurnerBL
    {
        get { return burnerBL; }
        set { burnerBL = value; }
    }

    /// <summary>
    /// Getter/Setter for Top Left burner
    /// </summary>
    /// <returns></returns>
    public int BurnerTL
    {
        get { return burnerTL; }
        set { burnerTL = value; }
    }
    #endregion


    /// <summary>
    /// Author: John Vance
    /// Purpose: Sets the burners to default values.
    /// Restrictions: None.
    /// </summary>
    void Start()
    {
        burnerTR = 0;
        burnerBR = 0;
        burnerBL = 0;
        burnerTL = 0;

    }

    void Update()
    {


    }
}

