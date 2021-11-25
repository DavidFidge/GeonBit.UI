using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GeonBit.UI
{
    public interface IUserInterface
    {
        /// <summary>
        /// Get current game time value.
        /// </summary>
        GameTime CurrGameTime { get; }

        /// <summary>
        /// If true, will draw the UI on a render target before drawing on screen.
        /// This mode is required for some of the features.
        /// </summary>
        bool UseRenderTarget { get; set; }

        /// <summary>
        /// Get the main render target all the UI draws on.
        /// </summary>
        RenderTarget2D RenderTarget { get; }

        /// <summary>
        /// Get the root entity.
        /// </summary>
        IPanel Root { get; }

        /// <summary>Scale the entire UI and all the entities in it. This is useful for smaller device screens.</summary>
        float GlobalScale { get; set; }

        /// <summary>The current target entity, eg what cursor points on. Can be null if cursor don't point on any entity.</summary>
        Entity TargetEntity { get; }

        /// <summary>
        /// Dispose unmanaged resources of this user interface.
        /// </summary>
        void Dispose();

        /// <summary>
        /// Set cursor style.
        /// </summary>
        /// <param name="type">What type of cursor to show.</param>
        void SetCursor(CursorType type);

        /// <summary>
        /// Set cursor graphics from a custom texture.
        /// </summary>
        /// <param name="texture">Texture to use for cursor.</param>
        /// <param name="drawWidth">Width, in pixels to draw the cursor. Height will be calculated automatically to fit texture propotions.</param>
        /// <param name="offset">Cursor offset from mouse position (if not provided will draw cursor with top-left corner on mouse position).</param>
        void SetCursor(Texture2D texture, int drawWidth = 32, Point? offset = null);

        /// <summary>
        /// Draw the cursor.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch to draw the cursor.</param>
        void DrawCursor(SpriteBatch spriteBatch);

        /// <summary>
        /// Add an entity to screen.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        Entity AddEntity(Entity entity);

        /// <summary>
        /// Remove an entity from screen.
        /// </summary>
        /// <param name="entity">Entity to remove.</param>
        void RemoveEntity(Entity entity);

        /// <summary>
        /// Remove all entities from screen.
        /// </summary>
        void Clear();

        /// <summary>
        /// Update the UI manager. This function should be called from your Game 'Update()' function, as early as possible (eg before you update your game state).
        /// </summary>
        /// <param name="gameTime">Current game time.</param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Draw the UI. This function should be called from your Game 'Draw()' function.
        /// Note: if UseRenderTarget is true, this function should be called FIRST in your draw function.
        /// If UseRenderTarget is false, this function should be called LAST in your draw function.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch to draw on.</param>
        void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Finalize the draw frame and draw all the UI on screen.
        /// This function only works if we are in UseRenderTarget mode.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw on.</param>
        void DrawMainRenderTarget(SpriteBatch spriteBatch);

        /// <summary>
        /// Get transformed cursoer position for collision detection.
        /// If have transform matrix and curser is included in render target, will transform cursor position too.
        /// If don't use transform matrix or drawing cursor outside, will not transform cursor position.
        /// </summary>
        /// <returns>Transformed cursor position.</returns>
        Vector2 GetTransformedCursorPos(Vector2? addVector);

        /// <summary>
        /// Serialize the whole UI to stream.
        /// Note: serialization have some limitation and things that will not be included in xml,
        /// like even handlers. Please read docs carefuly to know what to expect.
        /// </summary>
        /// <param name="stream">Stream to serialize to.</param>
        void Serialize(System.IO.Stream stream);

        /// <summary>
        /// Serialize the whole UI to filename.
        /// Note: serialization have some limitation and things that will not be included in xml,
        /// like even handlers. Please read docs carefuly to know what to expect.
        /// </summary>
        /// <param name="path">Filename to serialize into.</param>
        void Serialize(string path);

        /// <summary>
        /// Deserialize the whole UI from stream.
        /// Note: serialization have some limitation and things that will not be included in xml,
        /// like even handlers. Please read docs carefuly to know what to expect.
        /// </summary>
        /// <param name="stream">Stream to deserialize from.</param>
        void Deserialize(System.IO.Stream stream);

        /// <summary>
        /// Deserialize the whole UI from filename.
        /// Note: serialization have some limitation and things that will not be included in xml,
        /// like even handlers. Please read docs carefuly to know what to expect.
        /// </summary>
        /// <param name="path">Filename to deserialize from.</param>
        void Deserialize(string path);

        /// <summary>
        /// If using render targets, should the curser be rendered inside of it?
        /// If false, cursor will draw outside the render target, when presenting it.
        /// </summary>
        bool IncludeCursorInRenderTarget { get; set; }


        /// <summary>Callback to execute when mouse button is pressed over an entity (called once when button is pressed).</summary>
        EventCallback OnMouseDown { get; set; }

        /// <summary>Callback to execute when right mouse button is pressed over an entity (called once when button is pressed).</summary>
        EventCallback OnRightMouseDown { get; set; }

        /// <summary>Callback to execute when mouse button is released over an entity (called once when button is released).</summary>
        EventCallback OnMouseReleased { get; set; }

        /// <summary>Callback to execute every frame while mouse button is pressed over an entity.</summary>
        EventCallback WhileMouseDown { get; set; }

        /// <summary>Callback to execute every frame while right mouse button is pressed over an entity.</summary>
        EventCallback WhileRightMouseDown { get; set; }

        /// <summary>Callback to execute every frame while mouse is hovering over an entity, unless mouse button is down.</summary>
        EventCallback WhileMouseHover { get; set; }

        /// <summary>Callback to execute every frame while mouse is hovering over an entity, even if mouse button is down.</summary>
        EventCallback WhileMouseHoverOrDown { get; set; }

        /// <summary>Callback to execute when user clicks on an entity (eg release mouse over it).</summary>
        EventCallback OnClick { get; set; }

        /// <summary>Callback to execute when user clicks on an entity with right mouse button (eg release mouse over it).</summary>
        EventCallback OnRightClick { get; set; }

        /// <summary>Callback to execute when any entity value changes (relevant only for entities with value).</summary>
        EventCallback OnValueChange { get; set; }

        /// <summary>Callback to execute when mouse start hovering over an entity (eg enters its region).</summary>
        EventCallback OnMouseEnter { get; set; }

        /// <summary>Callback to execute when mouse stop hovering over an entity (eg leaves its region).</summary>
        EventCallback OnMouseLeave { get; set; }

        /// <summary>Callback to execute when mouse wheel scrolls and an entity is the active entity.</summary>
        EventCallback OnMouseWheelScroll { get; set; }

        /// <summary>Called when entity starts getting dragged (only if draggable).</summary>
        EventCallback OnStartDrag { get; set; }

        /// <summary>Called when entity stop getting dragged (only if draggable).</summary>
        EventCallback OnStopDrag { get; set; }

        /// <summary>Called every frame while entity is being dragged.</summary>
        EventCallback WhileDragging { get; set; }

        /// <summary>Callback to execute every frame before entity update.</summary>
        EventCallback BeforeUpdate { get; set; }

        /// <summary>Callback to execute every frame after entity update.</summary>
        EventCallback AfterUpdate { get; set; }

        /// <summary>Callback to execute every frame before entity is rendered.</summary>
        EventCallback BeforeDraw { get; set; }

        /// <summary>Callback to execute every frame after entity is rendered.</summary>
        EventCallback AfterDraw { get; set; }

        /// <summary>Callback to execute every time the visibility property of an entity change.</summary>
        EventCallback OnVisiblityChange { get; set; }

        /// <summary>Callback to execute every time a new entity is spawned (note: spawn = first time Update() is called on this entity).</summary>
        EventCallback OnEntitySpawn { get; set; }

        /// <summary>Callback to execute every time an entity focus changes.</summary>
        EventCallback OnFocusChange { get; set; }

        /// <summary>Draw utils helper. Contain general drawing functionality and handle effects replacement.</summary>
        DrawUtils DrawUtils { get; set; }

        /// <summary>Current active entity, eg last entity user interacted with.</summary>
        Entity ActiveEntity { get; set; }

        /// <summary>Cursor rendering size.</summary>
        float CursorScale { get; set; }

        /// <summary>Screen width.</summary>
        int ScreenWidth { get; set; }

        /// <summary>Screen height.</summary>
        int ScreenHeight { get; set; }

        /// <summary>
        /// Blend state to use when rendering UI.
        /// </summary>
        BlendState BlendState { get; set; }

        /// <summary>
        /// Sampler state to use when rendering UI.
        /// </summary>
        SamplerState SamplerState { get; set; }

        /// <summary>
        /// The object that provide mouse input for GeonBit UI.
        /// By default it uses internal implementation that uses MonoGame mouse input.
        /// If you want to use things like Touch input, you can override and replace this instance
        /// with your own object that emulates mouse input from different sources.
        /// </summary>
        IMouseInput MouseInputProvider { get; set; }

        /// <summary>
        /// The object that provide keyboard and typing input for GeonBit UI.
        /// By default it uses internal implementation that uses MonoGame keyboard input.
        /// If you want to use alternative typing methods, you can override and replace this instance
        /// with your own object that emulates keyboard input.
        /// </summary>
        IKeyboardInput KeyboardInputProvider { get; set; }

        /// <summary>
        /// If true, GeonBit.UI will not raise exceptions on sanity checks, validations, and errors which are not critical.
        /// For example, trying to select a value that doesn't exist from a list would do nothing instead of throwing exception.
        /// </summary>
        bool SilentSoftErrors { get; set; }

        /// <summary>
        /// If true, will add debug rendering to UI.
        /// </summary>
        bool DebugDraw { get; set; }

        /// <summary>
        /// Optional transformation matrix to apply when drawing with render targets.
        /// </summary>
        Matrix? RenderTargetTransformMatrix { get; set; }

        bool IsDeserializing { get; }
    }
}