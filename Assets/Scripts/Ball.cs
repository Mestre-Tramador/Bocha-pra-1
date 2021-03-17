using System.Collections;
using UnityEngine;
using MestreTramador.Constants;

/// <summary>
/// The Behaviour of a throwable Ball.
/// </summary>
public abstract class Ball : MonoBehaviour
{
    /// <summary>
    /// The Ball's speed on its trajectory.
    /// </summary>
    public float Speed { get; set; }

    /// <summary>
    /// A key to determine if the throwing had ended.
    /// </summary>
    protected bool TimeOut { get; private set; }
    
    /// <summary>
    /// The <b>X</b> Axis for the Ball movement.
    /// </summary>
    protected float XAxis { get; private set; }

    /// <summary>
    /// The <b>Z</b> Axis for the Ball movement.
    /// </summary>
    protected float ZAxis { get; private set; }

    /// <summary>
    /// The Ball's Initial Position, for comparison.
    /// </summary>
    protected Vector3 InitialPosition { get; private set; }

    /// <summary>
    /// Based on the <see cref="InitialPosition"/>, determines if the Ball has moved along the camp.
    /// </summary>
    /// <returns><c>TRUE</c> if the Ball has moved at least one unity.</returns>
    public bool BallHasMoved() => !((InitialPosition.x == transform.position.x) && (InitialPosition.z == transform.position.z));

    /// <summary>
    /// Controls the Forces and Axis to keep the Ball moving.
    /// </summary>
    protected abstract void KeepMoving();

    /// <summary>
    /// On Fixed Update, keep the Ball Moving, and if <see cref="TimeOut"/>, then the <see cref="StopMovement"/> routine is started.
    /// </summary>
    protected virtual void FixedUpdate()
    {
        KeepMoving();

        if(TimeOut)
        {
            StartCoroutine(StopMovement());
        }
    }

    /// <summary>
    /// On Start, saves the Initial Position and set values for Movement variables, also starts the <see cref="ThrowBall"/> routine.
    /// </summary>
    protected virtual void Start()
    {
        SaveInitialPosition();
        SetMovementValues();

        StartCoroutine(ThrowBall());
    }

    /// <summary>
    /// Reposition the ball along the given range for the <b>X</b> Axis.
    /// </summary>
    /// <param name="min">The minimum value for the <b>X</b> Axis range.</param>
    /// <param name="max">The maximum value for the <b>X</b> Axis range.</param>
    protected void RepositionBall(float min, float max) => transform.position = new Vector3(Random.Range(min, max), transform.position.y, transform.position.z);

    /// <summary>
    /// Set the given values for the Movement variables, as listed:
    /// <list type="bullet">
    /// <item><see cref="Speed"/>;</item>
    /// <item><see cref="XAxis"/>;</item>
    /// <item><see cref="ZAxis"/>.</item>
    /// </list>
    /// </summary>
    /// <param name="speed"><c><i>[optional]</i></c> The new speed.</param>
    /// <param name="xAxis"><c><i>[optional]</i></c> The new <b>X</b> axis.</param>
    /// <param name="zAxis"><c><i>[optional]</i></c> The new <b>Z</b> axis.</param>
    protected void SetMovementValues(float speed = 0.0f, float xAxis = 0.0f, float zAxis = 0.0f)
    {
        Speed = speed;
        XAxis = xAxis;
        ZAxis = zAxis;
    }

    /// <summary>
    /// Wait for the throwing of <b>three seconds</b>, then shut down any controls and/or forces on the Ball.
    /// </summary>
    /// <returns>A <see cref="IEnumerator"/> for the Routine.</returns>
    private IEnumerator ThrowBall()
    {
        yield return new WaitForSeconds(3.0f);

        EndPlayTime();

        SetMovementValues();

        /// <summary>Set the <see cref="TimeOut"/> to <c>TRUE</c>.</summary>
        void EndPlayTime() => TimeOut = true;
    }

    /// <summary>
    /// For a few seconds, slow the Ball's movement, and then stop it after <b>half of a minute</b>.
    /// When the Ball is stopped, measure the distance between it and the Bocce and execute subsequent functions.
    /// </summary>
    /// <returns>A <see cref="IEnumerator"/> for the Routine.</returns>
    private IEnumerator StopMovement()
    {
        SlowBy(0.05f);

        yield return new WaitForSeconds(3.0f);

        SlowBy(0.0f);

        yield return new WaitForSeconds(30.0f);

        Stop();

        CalculateBocce();

        /// <summary>Set the <see cref="Rigidbody.drag"/> of the current Ball to the given new <paramref name="drag"/>.</summary>
        /// <param name="drag">A new drag force to the Ball.</param>
        void SlowBy(float drag) => GetComponent<Rigidbody>().drag = drag;

        /// <summary>Force the <see cref="Rigidbody.velocity"/> to <b>zero</b> and stops all the movement.</summary>
        void Stop() => GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        /// <summary>By the <see cref="BocceBall"/>, measure the distance of the current Ball and execute the subsequent functions.</summary>
        void CalculateBocce() => GameObject.Find(GameObjects.BallBocce).GetComponent<BocceBall>().MeasureBallDistance(gameObject);
    }

    /// <summary>
    /// Store the actual position's <see cref="Vector3"/> as the Initial Position.
    /// </summary>
    private void SaveInitialPosition() => InitialPosition = transform.position;       
}
