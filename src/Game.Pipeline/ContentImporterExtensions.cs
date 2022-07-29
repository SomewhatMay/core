﻿//-----------------------------------------------------------------------
// <copyright>
//      Created by Matt Weber <matt@badecho.com>
//      Copyright @ 2022 Bad Echo LLC. All rights reserved.
//
//		Bad Echo Technologies are licensed under a
//		GNU Affero General Public License v3.0.
//
//		See accompanying file LICENSE.md or a copy at:
//		https://www.gnu.org/licenses/agpl-3.0.html
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Xna.Framework.Content.Pipeline;

namespace BadEcho.Game.Pipeline;

/// <summary>
/// Provides a set of static methods intended to aid in matters related to asset importation into the content pipeline.
/// </summary>
internal static class ContentImporterExtensions
{
    /// <summary>
    /// Logs a message during the process of importing an asset to the content pipeline.
    /// </summary>
    /// <param name="context">The current game asset importer's context.</param>
    /// <param name="message">The message to log.</param>
    public static void Log(this ContentImporterContext context, string message)
    {
        Require.NotNull(context, nameof(context));

        context.Logger.LogMessage(message);
    }
}
