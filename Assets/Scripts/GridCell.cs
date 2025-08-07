using UnityEngine;

public class GridCell : MonoBehaviour
{
    public TeamColour TeamColour;
    public Material GreenColour;
    public Material BlueColour;
    public Material RedColour;
    public Material YellowColour;

    public Renderer TeamColourRenderer;

    public void SetTileColour(TeamColour colour)
    {
        if (TeamColour == colour) return;

        TeamColour = colour;

        // Get the material of our new team colour
        var mat = GreenColour;
        switch (colour)
        {
            case TeamColour.Green:
                mat = GreenColour;
                break;
            case TeamColour.Blue:
                mat = BlueColour;
                break;
            case TeamColour.Red:
                mat = RedColour;
                break;
            case TeamColour.Yellow:
                mat = YellowColour;
                break;
        }

        TeamColourRenderer.material = mat;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    var ball = other.GetComponent<Ball>();
    //    if (ball != null)
    //    {
    //        if (ball.TeamColour != this.TeamColour)
    //            SetTileColour(ball.TeamColour);
    //    }
    //}
}
