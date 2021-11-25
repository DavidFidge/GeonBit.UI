using System;
using System.Collections.Generic;
using System.Linq;

namespace GeonBit.UI.Entities
{
    public interface IPanel : IPanelBase
    {
        /// <summary>
        /// Get the scrollbar of this panel.
        /// </summary>
        VerticalScrollbar Scrollbar { get; }

        /// <summary>
        /// Set / get panel overflow behavior.
        /// Note: some modes require Render Targets, eg setting the 'UseRenderTarget' to true.
        /// </summary>
        PanelOverflowBehavior PanelOverflowBehavior { get; set; }

        /// <summary>
        /// Dispose unmanaged resources related to this panel (render target).
        /// </summary>
        void Dispose();
    }
}