﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2023 Bad Echo LLC. All rights reserved.
//
//      Bad Echo Technologies are licensed under the
//      GNU Affero General Public License v3.0.
//
//      See accompanying file LICENSE.md or a copy at:
//      https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Xna.Framework.Content.Pipeline;

namespace BadEcho.Game.Pipeline;

/// <summary>
/// Provides a set of static methods intended to aid in matters related to an asset's importation and processing into the
/// content pipeline.
/// </summary>
internal static class ContentContextExtensions
{
    /// <summary>
    /// Logs a message during the importation of an asset to the content pipeline.
    /// </summary>
    /// <param name="context">The current game asset importer's context.</param>
    /// <param name="message">The message to log.</param>
    public static void Log(this ContentImporterContext context, string message)
    {
        Require.NotNull(context, nameof(context));

        context.Logger.LogMessage(message);
    }

    /// <summary>
    /// Logs a message during the processing of an asset to the content pipeline.
    /// </summary>
    /// <param name="context">The current game asset's processor's context.</param>
    /// <param name="message">The message to log.</param>
    public static void Log(this ContentProcessorContext context, string message)
    {
        Require.NotNull(context, nameof(context));

        context.Logger.LogMessage(message);
    }
}
