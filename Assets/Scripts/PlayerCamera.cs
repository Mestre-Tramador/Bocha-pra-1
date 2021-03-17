using UnityEngine;

/// <summary>
/// The Player Camera Management.
/// </summary>
public sealed class PlayerCamera : MonoBehaviour
{
    /// <summary>
    /// The exact object wich holds the Player information.
    /// </summary>
    private GameObject Player { get; set; }

    /// <summary>
    /// The Offset of the <see cref="Player"/> position.
    /// </summary>
    private Vector3 Offset { get; set; }

    /// <summary>
    /// Set the Offset's <see cref="Vector3"/> value based on the positioning of the Player.
    /// </summary>
    /// <param name="player">The Player's object for reference.</param>
    public void SetOffsetToPlayer(GameObject player)
    {
        Player = player;

        transform.position = new Vector3(Player.transform.position.x, transform.position.y, transform.position.z);

        Offset = transform.position - Player.transform.position;
    }

    /// <summary>
    /// On Fixed Update, the camera position is moved to the Player's Offset.
    /// </summary>
    private void FixedUpdate() => MoveToPlayer();

    /// <summary>
    /// Recalculate the position using the <see cref="Player"/>'s position and the already setted <see cref="Offset"/>.
    /// </summary>
    private void MoveToPlayer() => transform.position = Player.transform.position + Offset;
}
