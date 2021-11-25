using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GeonBit.UI.Entities
{
    public interface IPanelBase : IEntity
    {
        /// <summary>
        /// Set the panel's height to match its children automatically.
        /// Note: to make this happen on its own every frame, set the 'AdjustHeightAutomatically' property to true.
        /// </summary>
        /// <returns>True if succeed to adjust height, false if couldn't for whatever reason.</returns>
        bool SetHeightBasedOnChildren();

        /// <summary>
        /// Set / get current panel skin.
        /// </summary>
        PanelSkin Skin { get; set; }

        /// <summary>
        /// Override the default theme textures and set a custom skin for this specific button.
        /// </summary>
        /// <remarks>You must provide all state textures when overriding button skin.</remarks>
        /// <param name="customTexture">Texture to use for default state.</param>
        /// <param name="frameWidth">The width of the custom texture's frame, in percents of texture size.</param>
        void SetCustomSkin(Texture2D customTexture, Vector2? frameWidth = null);
    }
}