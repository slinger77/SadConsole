#if OPENTK

// Classes and types to support OpenTK versus MonoGame

using System;
using System.Collections.Generic;
using System.Text;

namespace SadConsole
{
    /// <summary>
    /// Defines sprite visual options for mirroring.
    /// </summary>
    [Flags]
    public enum SpriteEffects
    {
        /// <summary>
        /// No options specified.
        /// </summary>
		None = 0,
        /// <summary>
        /// Render the sprite reversed along the X axis.
        /// </summary>
        FlipHorizontally = 1,
        /// <summary>
        /// Render the sprite reversed along the Y axis.
        /// </summary>
        FlipVertically = 2
    }

    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class GameTime
    {
        private System.Diagnostics.Stopwatch timer;

        public TimeSpan TotalGameTime { get; set; }

        public TimeSpan ElapsedGameTime { get; set; }

        public bool IsRunningSlowly { get; set; }

        public GameTime()
        {
            TotalGameTime = TimeSpan.Zero;
            ElapsedGameTime = TimeSpan.Zero;
            IsRunningSlowly = false;

            timer = new System.Diagnostics.Stopwatch();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Update()
        {
            var currentTicks = timer.Elapsed.Ticks;
            ElapsedGameTime = new TimeSpan(currentTicks);
            TotalGameTime += ElapsedGameTime;
            timer.Restart();
        }
    }
}
#endif