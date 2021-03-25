using UnityEngine;

namespace MestreTramador
{   
    namespace Util
    {
        /// <summary>
        /// Helper and Utily functions.
        /// </summary>
        public sealed class Helper
        {
            /// <summary>
            /// Calculate a new <see cref="Vector3"/> for a <see cref="Rigidbody"/> force.
            /// </summary>
            /// <param name="x">The <b>X</b> Axis.</param>
            /// <param name="y">The <b>Y</b> Axis.</param>
            /// <param name="z">The <b>Z</b> Axis.</param>
            /// <param name="speed">The Speed modifier.</param>
            /// <returns>The Vector ready to apply a force by <see cref="Rigidbody.AddForce(Vector3)"/>.</returns>
            public static Vector3 CalculateVelocityForce(float x, float y, float z, float speed) => (new Vector3(x, y, z) * speed);

            /// <summary>
            /// Fix a <c>RGB</c> value.
            /// </summary>
            /// <param name="rgb">The <c>Red</c>|<c>Green</c>|<c>Blue</c> value.</param>
            /// <returns>The value fixed to assemble a <see cref="Color"/>, for example.</returns>
            public static float FixRGB(float rgb) => (rgb / 255.0f);

            /// <summary>
            /// Quick method to execute a <see cref="Resources.Load{T}(string)"/> call.
            /// </summary>
            /// <typeparam name="Type">A valid <see cref="Object"/> to load.</typeparam>
            /// <param name="path">The Path in the <b><c>/Assets/Resources/</c></b> folder.</param>
            /// <returns>The given <typeparamref name="Type"/> or <c>NULL</c>.</returns>            
            public static Type LoadResource<Type>(string path) where Type : Object => Resources.Load<Type>(path);
        }

        /// <summary>
        /// Path constants to use in <see cref="LoadResource{Type}(string)"/> calls.
        /// </summary>
        public sealed class Path
        {
            /*
             * Musics.
             * *******
             */
            /// <summary>
            /// Player's Victory Fanfarre.
            /// <br/><br/>
            /// <i>De Camino a La Vereda, by Buena Vista Social Club</i>
            /// <br/>
            /// Avaiable on <see href="https://www.youtube.com/watch?v=_RrVQ9mFjq8">Youtube</see>.
            /// </summary>
            public static readonly string MusicPlayerVictory = $"{Music}ACaminoDeLaVereda";

            /// <summary>
            /// Rival's Victory Fanfarre.
            /// <br/><br/>
            /// <i>Chan Chan, by Buena Vista Social Club</i>
            /// <br/>
            /// Avaiable on <see href="https://www.youtube.com/watch?v=o5cELP06Mik">Youtube</see>.
            /// </summary>
            public static readonly string MusicRivalVictory = $"{Music}ChanChan";


            /*
             * Prefixes.
             * *********
             */
            /// <summary>
            /// Prefix for <b>Music</b> <see cref="Resources"/> subfolder.
            /// </summary>
            private const string Music = "Music/";
        }        
    }
}
