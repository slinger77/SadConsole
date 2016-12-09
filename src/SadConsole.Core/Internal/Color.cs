using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SadConsole.Internal
{
    public class Color
    {
#if SFML
#elif MONOGAME
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Microsoft.Xna.Framework.Color Create(byte red, byte green, byte blue, byte alpha)
        {
            return new Microsoft.Xna.Framework.Color(red, green, blue, alpha);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Microsoft.Xna.Framework.Color Multiply(Microsoft.Xna.Framework.Color color, float amount)
        {
            return Microsoft.Xna.Framework.Color.Multiply(color, amount);
        }

        public static Microsoft.Xna.Framework.Color Lerp(Microsoft.Xna.Framework.Color color1, Microsoft.Xna.Framework.Color color2, float amount)
        {
            return Microsoft.Xna.Framework.Color.Lerp(color1, color2, amount);
        }
#elif WINDOWS_UWP
        public static Windows.UI.Color Create(byte red, byte green, byte blue, byte alpha)
        {
            return Windows.UI.Color.FromArgb(alpha, red, green, blue);
        }

        public static Windows.UI.Color Multiply(Windows.UI.Color color, float amount)
        {
            return Windows.UI.Color.FromArgb((byte)(color.A * amount), (byte)(color.R * amount), (byte)(color.G * amount), (byte)(color.B * amount));
        }

        public static Windows.UI.Color Lerp(Windows.UI.Color color1, Windows.UI.Color color2, float amount)
        {
            return Windows.UI.Color.FromArgb((byte)MathHelper.Lerp(color1.A, color1.A, amount),
                                             (byte)MathHelper.Lerp(color1.R, color1.R, amount),
                                             (byte)MathHelper.Lerp(color1.G, color1.G, amount),
                                             (byte)MathHelper.Lerp(color1.B, color1.B, amount));
        }
#endif            

    }
}
