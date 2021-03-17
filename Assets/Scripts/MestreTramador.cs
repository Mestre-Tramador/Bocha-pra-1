using UnityEngine;
using static MestreTramador.Util.Helper;

namespace MestreTramador
{
    namespace Constants
    {
        /// <summary>
        /// <see cref="Color"/> constants for general user.
        /// </summary>
        public sealed class Colors
        {
            /*
             * Default Colors.
             * ***************
             */
            /// <summary>
            /// Default Text Color.
            /// </summary>
            public static readonly Color DefaultText = new Color(FixRGB(50.0f), FixRGB(50.0f), FixRGB(50.0f), FullAlpha);

            /*
             * Player Colors.
             * **************
             */
            /// <summary>
            /// Player Main Color.
            /// </summary>
            public static readonly Color PlayerColor = new Color(FixRGB(57.0f), FixRGB(148.0f), FixRGB(245.0f), FullAlpha);

            /// <summary>
            /// Player Win's Text Color.
            /// </summary>
            public static readonly Color PlayerWinTextColor = new Color(FixRGB(74.0f), FixRGB(168.0f), FixRGB(72.0f), FullAlpha);

            /*
             * Rival Colors.
             * *************
             */
            /// <summary>
            /// Rival Main Color.
            /// </summary>
            public static readonly Color RivalColor = new Color(FixRGB(255.0f), FixRGB(107.0f), FixRGB(193.0f), FullAlpha);
            
            /// <summary>
            /// Rival Win's Text Color.
            /// </summary>
            public static readonly Color RivalWinTextColor = new Color(FixRGB(217.0f), FixRGB(53.0f), FixRGB(53.0f), FullAlpha);


            /*
             * Alpha constants.
             * ****************
             */
            /// <summary>
            /// For <b>100%</b> Alpha.
            /// </summary>
            private const float FullAlpha = 1.0f;

            /// <summary>
            /// For <b>50%</b> Alpha.
            /// </summary>
            private const float HalfAlpha = 0.5f;

            /// <summary>
            /// For <b>0%</b> Alpha.
            /// </summary>
            private const float NoneAlpha = 0.0f;
        }

        /// <summary>
        /// Name constants for <see cref="GameObject"/>.
        /// </summary>
        public sealed class GameObjects
        {
            /*
             * Cameras.
             * ********
             */
            /// <summary>
            /// The Camera wich follows the Player.
            /// </summary>
            public const string CameraPlayer = "Camera";


            /*
             * Camp.
             * *****
             */
            /// <summary>
            /// The Camp Group.
            /// </summary>
            public const string CampParent = "Camp";

            /// <summary>
            /// The Camp's Ground Child.
            /// </summary>
            public const string CampChildGround = "Ground";            

            /// <summary>
            /// The Camp's Wall Child Group.
            /// </summary>
            public const string CampChildWallParent = "Walls";


            /*
             * Camp's Walls.
             * *************
             */
            /// <summary>
            /// The Camp Left Wall.
            /// </summary>
            public const string WallLeft = "LWall";

            /// <summary>
            /// The Camp Right Wall.
            /// </summary>
            public const string WallRight = "RWall";

            /// <summary>
            /// The Camp Top Wall.
            /// </summary>
            public const string WallTop = "TWall";

            /// <summary>
            /// The Camp Bottom Wall.
            /// </summary>
            public const string WallBottom = "BWall";


            /*
             * Canvas.
             * *******
             */
            /// <summary>
            /// The Canvas as itself.
            /// </summary>
            public const string CanvasParent = "Canvas";

            /// <summary>
            /// The Canvas' Text Child Group.
            /// </summary>
            public const string CanvasEndTextChild = "EndText";


            /*
             * End Game Text.
             * **************
             */
            /// <summary>
            /// The End Game Text Title.
            /// </summary>
            public const string EndTextChildFinal = "ETFinal";

            /// <summary>
            /// The End Game Text Player's Distance Label.
            /// </summary>
            public const string EndTextChildPlayerDistance = "ETPlayerDistance";

            /// <summary>
            /// The End Game Text Player's Distance Value.
            /// </summary>
            public const string EndTextChildPlayerDistanceValue = "ETPlayerDistanceValue";

            /// <summary>
            /// The End Game Text Rival's Distance Label.
            /// </summary>
            public const string EndTextChildRivalDistance = "ETRivalDistance";

            /// <summary>
            /// The End Game Text Rival's Distance Value.
            /// </summary>
            public const string EndTextChildRivalDistanceValue = "ETRivalDistanceValue";


            /*
             * Balls.
             * ******
             */
            /// <summary>
            /// The Bocce Ball.
            /// </summary>
            public const string BallBocce = "Bocce";

            /// <summary>
            /// The Player's Ball.
            /// </summary>
            public const string BallPlayer = "Blue";

            /// <summary>
            /// The Rival's Ball.
            /// </summary>
            public const string BallRival = "Pink";
        }

        /// <summary>
        /// Number constants for general use.
        /// </summary>
        public sealed class Numbers
        {
            /*
             * Balls.
             * ******
             */
            /// <summary>
            /// The Speed of a <see cref="Ball"/>.
            /// </summary>
            public const float BallSpeed = 5.5f;
        }

        /// <summary>
        /// Name constants for <see cref="UnityEngine.SceneManagement.Scene"/>.
        /// </summary>
        public sealed class Scenes
        {
            /// <summary>
            /// The Main Bocce Scene.
            /// </summary>
            public const string MainScene = "BocceScene";
        }       

        /// <summary>
        /// Constants for the inner bodies of <see cref="UnityEngine.UI.Text"/> components.
        /// </summary>
        public sealed class Texts
        {
            /*
             * Distance Text Label.
             * ********************
             */
            /// <summary>
            /// The Player's Distance Text Label.
            /// </summary>
            public const string PlayerDistanceTextLabel = "Sua Distância: ";

            /// <summary>
            /// The Rival's Distance Text Label.
            /// </summary>
            public const string RivalDistanceTextLabel = "Distância Rival: ";


            /*
             * Victory Text.
             * *************
             */
            /// <summary>
            /// The Player's Victory Text.
            /// </summary>
            public const string PlayerVictoryText = "Ganhou!";

            /// <summary>
            /// The Rival's Victory Text.
            /// </summary>
            public const string RivalVictoryText = "Perdeu!";
        }        
    }

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
