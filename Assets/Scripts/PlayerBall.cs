using UnityEngine;
using UnityEngine.SceneManagement;
using MestreTramador.Constants;
using MestreTramador.Util;

/// <summary>
/// The Player's <see cref="Ball"/>.
/// </summary>
public sealed class PlayerBall : Ball
{
    /// <summary>
    /// The Camera wich follows the Player's Ball.
    /// </summary>
    private PlayerCamera Camera { get; set; }

    /// <summary>
    /// On the <c>overrided</c> Fixed Update, the parent <see cref="Ball.FixedUpdate"/> is runned,
    /// but it also check for the Restart condition if <see cref="Ball.TimeOut"/> is <c>TRUE</c>.
    /// </summary>
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if(TimeOut)
        {
            ListenForBocceRestart();
        }
    }

    /// <summary>
    /// On the <c>overrided</c> Start, the Ball's X Axis is repositioned between <b><c>(0.0, 4.5)</c></b> and also
    /// the <see cref="Camera"/>'s position is fixed, then the parent <see cref="Ball.Start"/> is executed.
    /// </summary>
    protected override void Start()
    {
        RepositionBall(0.0f, 4.5f);

        FixCamera();

        base.Start();
    }

    /// <summary>
    /// The Movement of the Player is maintained by the values as below:
    /// <list type="bullet">
    /// <item><see cref="Ball.Speed"/>: <see cref="Numbers.BallSpeed"/>;</item>
    /// <item><see cref="Ball.XAxis"/>: <see cref="Input.GetAxis(string)"/> for <b><c>"Horizontal"</c></b>;</item>
    /// <item><see cref="Ball.ZAxis"/>: <see cref="Input.GetAxis(string)"/> for <b><c>"Vertical"</c></b>.</item>
    /// </list>
    /// </summary>
    protected override void KeepMoving()
    {
        if(!TimeOut)
        {
            SetMovementValues(Numbers.BallSpeed, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        GetComponent<Rigidbody>().AddForce(Helper.CalculateVelocityForce(XAxis, 0.0f, ZAxis, Speed));
    }

    /// <summary>
    /// Get the <see cref="PlayerCamera"/> Component to use the <see cref="PlayerCamera.SetOffsetToPlayer(GameObject)"/> function.
    /// </summary>
    private void FixCamera()
    {
        Camera = GameObject.Find(GameObjects.CameraPlayer).GetComponent<PlayerCamera>();

        Camera.SetOffsetToPlayer(gameObject);
    }

    /// <summary>
    /// If the <see cref="KeyCode.Escape"/> is pressed after <see cref="Ball.TimeOut"/>, then the current <see cref="Scene"/> is reloaded.
    /// </summary>
    private void ListenForBocceRestart()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(Scenes.MainScene);
        }
    }       
}
