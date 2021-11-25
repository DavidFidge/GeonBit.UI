using System.Collections.Generic;
using GeonBit.UI.DataTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GeonBit.UI.Entities
{
    public interface IEntity
    {
        /// <summary>
        /// Get / set children list.
        /// </summary>
        public IReadOnlyList<Entity> Children { get; }

        /// <summary>
        /// Get / set raw stylesheet.
        /// </summary>
        public StyleSheet RawStyleSheet { get; set; }

        /// <summary>
        /// If defined, will limit the minimum size of this entity when calculating size.
        /// This is especially useful for entities with size that depends on their parent entity size, for example
        /// if you define an entity to take 20% of its parent space but can't be less than 200 pixels width.
        /// </summary>
        public Vector2? MinSize { get; set; }

        /// <summary>
        /// If defined, will limit the maximum size of this entity when calculating size.
        /// This is especially useful for entities with size that depends on their parent entity size, for example
        /// if you define an entity to take 20% of its parent space but can't be more than 200 pixels width.
        /// </summary>
        public Vector2? MaxSize { get; set; }

        /// <summary>
        /// Set / get offset.
        /// </summary>
        public Vector2 Offset { get; set; }

        /// <summary>
        /// Set / get anchor.
        /// </summary>
        public Anchor Anchor { get; set; }

        /// <summary>Does this entity or one of its children currently focused?</summary>
        public bool IsFocused
        {
            // get if focused
            get;

            // set if focused
            set;
        }

        /// <summary>
        /// Get destination rect.
        /// </summary>
        public Rectangle DestRect { get; }

        /// <summary>
        /// Get internal destination rect.
        /// </summary>
        public Rectangle InternalDestRect { get; }

        /// <summary>
        /// Update dest rect and internal dest rect, but only if needed (eg if something changed since last update).
        /// </summary>
        public void UpdateDestinationRectsIfDirty();

        /// <summary>
        /// Return the default size for this entity.
        /// </summary>
        public Vector2 EntityDefaultSize { get; }

        /// <summary>
        /// Set / get visibility.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Is the entity draggable (eg can a user grab it and drag it around).
        /// </summary>
        public bool Draggable { get; set; }

        /// <summary>
        /// Optional background entity that will not respond to events and will always be rendered right behind this entity.
        /// </summary>
        public Entity Background { get; set; }

        /// <summary>
        /// Current entity state (default / mouse hover / mouse down..).
        /// </summary>
        public EntityState State { get; set; }

        /// <summary>
        /// Entity current size property.
        /// </summary>
        public Vector2 Size { get; set; }

        /// <summary>
        /// Extra space (in pixels) to reserve *after* this entity when using Auto Anchors.
        /// </summary>
        public Vector2 SpaceAfter { set; get; }

        /// <summary>
        /// Extra space (in pixels) to reserve *before* this entity when using Auto Anchors.
        /// </summary>
        public Vector2 SpaceBefore { set; get; }

        /// <summary>
        /// Entity fill color - this is just a sugarcoat to access the default fill color style property.
        /// </summary>
        public Color FillColor { set; get; }

        /// <summary>
        /// Entity fill color opacity - this is just a sugarcoat to access the default fill color alpha style property.
        /// </summary>
        public byte Opacity { set; get; }

        /// <summary>
        /// Entity outline color opacity - this is just a sugarcoat to access the default outline color alpha style property.
        /// </summary>
        public byte OutlineOpacity { set; get; }

        /// <summary>
        /// Entity padding - this is just a sugarcoat to access the default padding style property.
        /// </summary>
        public Vector2 Padding { set; get; }

        /// <summary>
        /// Entity shadow color - this is just a sugarcoat to access the default shadow color style property.
        /// </summary>
        public Color ShadowColor { set; get; }

        /// <summary>
        /// Entity shadow scale - this is just a sugarcoat to access the default shadow scale style property.
        /// </summary>
        public float ShadowScale { set; get; }

        /// <summary>
        /// Entity shadow offset - this is just a sugarcoat to access the default shadow offset style property.
        /// </summary>
        public Vector2 ShadowOffset { set; get; }

        /// <summary>
        /// Entity scale - this is just a sugarcoat to access the default scale style property.
        /// </summary>
        public float Scale { set; get; }

        /// <summary>
        /// Entity outline color - this is just a sugarcoat to access the default outline color style property.
        /// </summary>
        public Color OutlineColor { set; get; }

        /// <summary>
        /// Entity outline width - this is just a sugarcoat to access the default outline color style property.
        /// </summary>
        public int OutlineWidth { set; get; }

        /// <summary>
        /// Get the direct parent of this entity.
        /// </summary>
        public Entity Parent { get; }

        /// <summary>
        /// Return if the mouse is currently pressing on this entity (eg over it and left mouse button is down).
        /// </summary>
        public bool IsMouseDown { get; }

        /// <summary>
        /// Return if the mouse is currently over this entity (regardless of whether or not mouse button is down).
        /// </summary>
        public bool IsMouseOver { get; }

        /// <summary>
        /// Return stylesheet property for a given state.
        /// </summary>
        /// <param name="property">Property identifier.</param>
        /// <param name="state">State to get property for (if undefined will fallback to default state).</param>
        /// <param name="fallbackToDefault">If true and property not found for given state, will fallback to default state.</param>
        /// <returns>Style property value for given state or default, or null if undefined.</returns>
        public StyleProperty GetStyleProperty(string property, EntityState state = EntityState.Default, bool fallbackToDefault = true);

        /// <summary>
        /// Set a stylesheet property.
        /// </summary>
        /// <param name="property">Property identifier.</param>
        /// <param name="value">Property value.</param>
        /// <param name="state">State to set property for.</param>
        /// <param name="markAsDirty">If true, will mark this entity as dirty after this style change.</param>
        public void SetStyleProperty(string property, StyleProperty value, EntityState state = EntityState.Default, bool markAsDirty = true);

        /// <summary>
        /// Return stylesheet property for current entity state (or default if undefined for state).
        /// </summary>
        /// <param name="property">Property identifier.</param>
        /// <returns>Stylesheet property value for current entity state, or default if not defined.</returns>
        public StyleProperty GetActiveStyle(string property);

        /// <summary>
        /// Update the entire stylesheet from a different stylesheet.
        /// </summary>
        /// <param name="updates">Stylesheet to update from.</param>
        public void UpdateStyle(StyleSheet updates);

        /// <summary>
        /// Find and return first occurance of a child entity with a given identifier and specific type.
        /// </summary>
        /// <typeparam name="T">Entity type to get.</typeparam>
        /// <param name="identifier">Identifier to find.</param>
        /// <param name="recursive">If true, will search recursively in children of children. If false, will search only in direct children.</param>
        /// <returns>First found entity with given identifier and type, or null if nothing found.</returns>
        public T Find<T> (string identifier, bool recursive = false) where T : Entity;

        /// <summary>
        /// Find and return first occurance of a child entity with a given identifier.
        /// </summary>
        /// <param name="identifier">Identifier to find.</param>
        /// <param name="recursive">If true, will search recursively in children of children. If false, will search only in direct children.</param>
        /// <returns>First found entity with given identifier, or null if nothing found.</returns>
        public Entity Find(string identifier, bool recursive = false);

        /// <summary>
        /// Iterate over children and call 'callback' for every direct child of this entity.
        /// </summary>
        /// <param name="callback">Callback function to call with every child of this entity.</param>
        public void IterateChildren(EventCallback callback);

        /// <summary>
        /// Return if this entity is currently disabled, due to self or one of the parents / grandparents being disabled.
        /// </summary>
        /// <returns>True if entity is disabled.</returns>
        public bool IsDisabled();

        /// <summary>
        /// Check if this entity is a descendant of another entity.
        /// This goes up all the way to root.
        /// </summary>
        /// <param name="other">Entity to check if this entity is descendant of.</param>
        /// <returns>True if this entity is descendant of the other entity.</returns>
        public bool IsDeepChildOf(Entity other);

        /// <summary>
        /// Return if this entity is currently locked, due to self or one of the parents / grandparents being locked.
        /// </summary>
        /// <returns>True if entity is disabled.</returns>
        public bool IsLocked();

        /// <summary>
        /// Return if this entity is currently visible, eg this and all its parents and grandparents are visible.
        /// </summary>
        /// <returns>True if entity is really visible.</returns>
        public bool IsVisible();

        /// <summary>
        /// Set the position and anchor of this entity.
        /// </summary>
        /// <param name="anchor">New anchor to set.</param>
        /// <param name="offset">Offset from new anchor position.</param>
        public void SetAnchorAndOffset(Anchor anchor, Vector2 offset);

        /// <summary>
        /// Draw this entity and its children.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch to use for drawing.</param>
        public void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Create and return a dictionary of entities, where key is Identifier and value is the entity. 
        /// This will include self + all children (and their children), and will only include entities that have Identifier property defined.
        /// Note: if multiple entities share the same identifier, the deepest entity in hirarchy will end up in dict.
        /// </summary>
        /// <returns>Dictionary with entities by their identifiers.</returns>
        public Dictionary<string, Entity> ToEntitiesDictionary();

        /// <summary>
        /// Add a child entity.
        /// </summary>
        /// <param name="child">Entity to add as child.</param>
        /// <param name="inheritParentState">If true, this entity will inherit the parent's state (set InheritParentState property).</param>
        /// <param name="index">If provided, will be the index in the children array to push the new entity.</param>
        /// <returns>The newly added entity.</returns>
        public Entity AddChild(Entity child, bool inheritParentState = false, int index = -1);

        /// <summary>
        /// Bring this entity to be on front (inside its parent).
        /// </summary>
        public void BringToFront();

        /// <summary>
        /// Push this entity to the back (inside its parent).
        /// </summary>
        public void SendToBack();

        /// <summary>
        /// Remove child entity.
        /// </summary>
        /// <param name="child">Entity to remove.</param>
        public void RemoveChild(Entity child);

        /// <summary>
        /// Remove all children entities.
        /// </summary>
        public void ClearChildren();

        /// <summary>
        /// Add animator to this entity.
        /// </summary>
        /// <param name="animator">Animator to attach.</param>
        public Animators.IAnimator AttachAnimator(Animators.IAnimator animator);

        /// <summary>
        /// Remove animator from entity.
        /// </summary>
        /// <param name="animator">Animator to remove.</param>
        public void RemoveAnimator(Animators.IAnimator animator);

        /// <summary>
        /// Calculate and return the destination rectangle, eg the space this entity is rendered on.
        /// </summary>
        /// <returns>Destination rectangle.</returns>
        public Rectangle CalcDestRect();

        /// <summary>
        /// Return actual destination rectangle.
        /// This can be override and implemented by things like Paragraph, where the actual destination rect is based on
        /// text content, font and word-wrap.
        /// </summary>
        /// <returns>The actual destination rectangle.</returns>
        public Rectangle GetActualDestRect();

        /// <summary>
        /// Remove this entity from its parent.
        /// </summary>
        public void RemoveFromParent();

        /// <summary>
        /// Propagate all events trigger by this entity to a given other entity.
        /// For example, if "OnClick" will be called on this entity, it will trigger OnClick on 'other' as well.
        /// </summary>
        /// <param name="other">Entity to propagate events to.</param>
        public void PropagateEventsTo(Entity other);

        /// <summary>
        /// Return the relative offset, in pixels, from parent top-left corner.
        /// </summary>
        /// <remarks>
        /// This return the offset between the top left corner of this entity regardless of anchor type.
        /// </remarks>
        /// <returns>Calculated offset from parent top-left corner.</returns>
        public Vector2 GetRelativeOffset();

        /// <summary>
        /// Test if a given point is inside entity's boundaries.
        /// </summary>
        /// <remarks>This function result is affected by the 'UseActualSizeForCollision' flag.</remarks>
        /// <param name="point">Point to test.</param>
        /// <returns>True if point is in entity's boundaries (destination rectangle)</returns>
        public bool IsTouching(Vector2 point);

        /// <summary>
        /// Called every frame to update entity state and call events.
        /// </summary>
        /// <param name="targetEntity">The deepest child entity with highest priority that we point on and can be interacted with.</param>
        /// <param name="dragTargetEntity">The deepest child dragable entity with highest priority that we point on and can be drag if mouse down.</param>
        /// <param name="wasEventHandled">Set to true if current event was already handled by a deeper child.</param>
        /// <param name="scrollVal">Combined scrolling value (panels with scrollbar etc) of all parents.</param>
        public void Update(ref Entity targetEntity, ref Entity dragTargetEntity, ref bool wasEventHandled, Point scrollVal);
    }
}