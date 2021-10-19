﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2021 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under a
//		Creative Commons Attribution-NonCommercial 4.0 International License.
//
//		See accompanying file LICENSE.md or a copy at:
//		http://creativecommons.org/licenses/by-nc/4.0/
// </copyright>
//-----------------------------------------------------------------------

namespace BadEcho.Omnified.Vision.Apocalypse.ViewModels
{
    /// <summary>
    /// Provides a view model that facilitates the display of an event generated by the Player Apocalypse subsystem in
    /// an Omnified game.
    /// </summary>
    /// <typeparam name="TPlayerApocalypseEvent">
    /// The type of Player Apocalypse event bound to the view model for display on a view.
    /// </typeparam>
    internal class PlayerApocalypseEventViewModel<TPlayerApocalypseEvent> : ApocalypseEventViewModel<TPlayerApocalypseEvent>,
                                                                            IPlayerApocalypseEventViewModel
        where TPlayerApocalypseEvent : PlayerApocalypseEvent
    {
        private int _dieRoll;

        /// <inheritdoc/>
        public int DieRoll
        {
            get => _dieRoll;
            set => NotifyIfChanged(ref _dieRoll, value);
        }

        /// <inheritdoc/>
        protected override void OnBinding(TPlayerApocalypseEvent model)
        {
            base.OnBinding(model);

            DieRoll = model.DieRoll;
        }

        /// <inheritdoc/>
        protected override void OnUnbound(TPlayerApocalypseEvent model)
        {
            base.OnUnbound(model);

            DieRoll = default;
        }
    }
}
