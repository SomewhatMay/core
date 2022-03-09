﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2022 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under the
//		GNU Affero General Public License v3.0.
//
//		See accompanying file LICENSE.md or a copy at:
//		https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

using BadEcho.Extensions;
using BadEcho.Vision.Apocalypse.Properties;

namespace BadEcho.Vision.Apocalypse;

/// <summary>
/// Provides a base description for an event generated by the Player Apocalypse subsystem in an Omnified game.
/// </summary>
/// <remarks>
/// <para>
/// The Player Apocalypse subsystem is executed to handle incoming damage to the player. It is the more punishing of
/// the two subsystems that compose the Apocalypse system, which shouldn't come as a big surprise given that Omnified
/// games are games hacked to be harder, not easier.
/// </para>
/// <para>
/// Upon receiving damage, the player is subjected to a randomly determined effect, some effects being much worse than others.
/// This random effect is determined through the most critical bit of data associated with the event: the primary die roll.
/// </para>
/// <para>
/// For every possible random effect, a corresponding <see cref="PlayerApocalypseEvent"/>-derived type exists, each of which
/// does the job of providing all the details in regards to what just happened to our poor player.
/// </para>
/// </remarks>
public abstract class PlayerApocalypseEvent : ApocalypseEvent
{
    /// <summary>
    /// Gets the primary die roll for this Player Apocalypse event, which acts as the main determinant in what punishing effect
    /// gets applied to the player.
    /// </summary>
    public int DieRoll
    { get; init; }

    /// <summary>
    /// Gets the total amount of damage done to the player due to the event.
    /// </summary>
    public int Damage
    { get; init; }

    /// <summary>
    /// Gets the player's health after being subjected to the Player Apocalypse event's random effect.
    /// </summary>
    public int HealthAfter
    { get; init; }

    /// <inheritdoc/>
    public override string ToString()
        => EffectMessages.PlayerApocalypseAddendum.CulturedFormat(Damage, HealthAfter);
}