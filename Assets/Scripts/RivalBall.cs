using UnityEngine;
using MestreTramador.Constants;
using MestreTramador.Util;

/// <summary>
/// The Rival's <see cref="Ball"/>.
/// </summary>
public sealed class RivalBall : Ball
{
    /// <summary>
    /// On the <c>overrided</c> Start, the Ball's X Axis is repositioned between <b><c>(-6.5, 0.0)</c></b>,
    /// then the parent <see cref="Ball.Start"/> is executed.
    /// </summary>
    protected override void Start()
    {
        RepositionBall(-6.5f, 0.0f);

        base.Start();
    }

    /// <summary>
    /// The Movement of the Player is maintained by the values as below:
    /// <list type="bullet">
    /// <item><see cref="Ball.Speed"/>: <see cref="Numbers.BallSpeed"/>;</item>
    /// <item><see cref="Ball.XAxis"/>: <see cref="Random.Range(float, float)"/> for <b><c>(-1.0, 1.0)</c></b>;</item>
    /// <item><see cref="Ball.ZAxis"/>: <see cref="Random.Range(float, float)"/> for <b><c>(0.1, 1.0)</c></b>.</item>
    /// </list>
    /// </summary>
    protected override void KeepMoving()
    {
        if(!TimeOut)
        {
            SetMovementValues(Numbers.BallSpeed, Random.Range(-1.0f, 1.0f), Random.Range(0.1f, 1.0f));
        }

        GetComponent<Rigidbody>().AddForce(Helper.CalculateVelocityForce(XAxis, 0.0f, ZAxis, Speed));
    }      
}
