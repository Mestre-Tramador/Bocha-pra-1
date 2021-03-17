using UnityEngine;
using UnityEngine.UI;
using MestreTramador.Constants;
using MestreTramador.Util;

/// <summary>
/// The Behaviour and Controller of the Bocce Ball.
/// </summary>
public sealed class BocceBall : MonoBehaviour
{        
    /// <summary>
    /// The reference Distance between the <see cref="BocceBall"/> and the <see cref="PlayerBall"/>.
    /// </summary>
    public float PlayerDistance { get; private set; }

    /// <summary>
    /// The reference Distance between the <see cref="BocceBall"/> and the <see cref="RivalBall"/>.
    /// </summary>
    public float RivalDistance { get; private set; }

    /// <summary>
    /// On Start, initialize and clear all Distances.
    /// </summary>
    void Start() => ClearDistances();

    /// <summary>
    /// Get if the <see cref="PlayerBall"/> is nearest the <see cref="BocceBall"/>.
    /// </summary>
    /// <returns><c>TRUE</c> if is, then the Player is victorious.</returns>
    public bool IsPlayerVictorious() => (PlayerDistance < RivalDistance);

    /// <summary>
    /// Get if the <see cref="RivalBall"/>  is nearest the <see cref="BocceBall"/>.
    /// </summary>
    /// <returns><c>TRUE</c> if is, then the Rival is victorious.</returns>
    public bool IsRivalVictorious() => (RivalDistance < PlayerDistance);

    /// <summary>
    /// Measure the Distance between the <see cref="BocceBall"/> and the given <paramref name="ball"/>.
    /// If the <paramref name="ball"/> corresponds to a <see cref="PlayerBall"/> or <see cref="RivalBall"/>,
    /// then the Distance is stored.
    /// </summary>
    /// <param name="ball">The Ball object, as its Components other than <see cref="Transform"/> does not matter.</param>
    public void MeasureBallDistance(GameObject ball)
    {
        float distance = Vector3.Distance(transform.position, ball.transform.position);

        switch(ball.name)
        {
            case GameObjects.BallPlayer:
                PlayerDistance = distance;
            break;

            case GameObjects.BallRival:
                RivalDistance = distance;
            break;

            default: return;
        }

        if(PlayerDistance > 0 && RivalDistance > 0)
        {
            CongratulateVictorious();
        }       
    }

    /// <summary>
    /// Clear all the Distances of the below list:
    /// <list type="bullet">
    /// <item><see cref="PlayerDistance"/>;</item>
    /// <item><see cref="RivalDistance"/>.</item>
    /// </list>
    /// </summary>
    private void ClearDistances()
    {
        PlayerDistance = 0.0f;
        RivalDistance = 0.0f;
    }

    /// <summary>
    /// When a Victorious is set, it must be congratulated! This function calls:
    /// <list type="bullet">
    /// <item><see cref="PlaceVictoriousText"/>;</item>
    /// <item><see cref="SetAndPlayVictoriousMusic"/>.</item>
    /// </list>
    /// </summary>
    private void CongratulateVictorious()
    {
        PlaceVictoriousText();
        SetAndPlayVictoriousMusic();
    }

    /// <summary>
    /// Gets all the <see cref="Text"/> components of the screen and place on each
    /// a assigned text and color according to <see cref="Texts"/> and <see cref="Colors"/>.
    /// </summary>
    private void PlaceVictoriousText()
    {
        GameObject textParent = GameObject.Find(GameObjects.CanvasEndTextChild);

        foreach(Transform textChild in textParent.transform)
        {
            Text text = textChild.gameObject.GetComponent<Text>();

            string textData = "";
            Color colorData = Colors.DefaultText;

            switch(textChild.gameObject.name)
            {
                case GameObjects.EndTextChildFinal:
                    textData  = (IsPlayerVictorious() ? Texts.PlayerVictoryText   : Texts.RivalVictoryText);
                    colorData = (IsPlayerVictorious() ? Colors.PlayerWinTextColor : Colors.RivalWinTextColor);
                break;

                case GameObjects.EndTextChildPlayerDistance:
                    textData = Texts.PlayerDistanceTextLabel;
                break;

                case GameObjects.EndTextChildPlayerDistanceValue:
                    textData  = PlayerDistance.ToString("0.00");
                    colorData = Colors.PlayerColor;
                break;

                case GameObjects.EndTextChildRivalDistance:
                    textData = Texts.RivalDistanceTextLabel;
                break;

                case GameObjects.EndTextChildRivalDistanceValue:
                    textData  = RivalDistance.ToString("0.00");
                    colorData = Colors.RivalColor;
                break;
            }

            text.text  = textData;
            text.color = colorData;
        }
    }

    /// <summary>
    /// Get the <see cref="AudioControl"/> component of the Camp field and, dinamically set
    /// its <see cref="AudioClip"/> by the Victorious.
    /// </summary>
    private void SetAndPlayVictoriousMusic()
    {
        AudioControl audio = GameObject.Find(GameObjects.CampParent).GetComponent<AudioControl>();

        audio.SetClip(IsPlayerVictorious() ? Path.MusicPlayerVictory : Path.MusicRivalVictory);

        audio.PlayClip();
    }
}
