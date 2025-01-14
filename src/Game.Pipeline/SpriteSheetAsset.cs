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

namespace BadEcho.Game.Pipeline;

/// <summary>
/// Provides configuration data for a sprite sheet asset.
/// </summary>
public sealed class SpriteSheetAsset
{
    /// <summary>
    /// Gets or sets the path to the file containing the texture of the individual animation frames that compose the sprite sheet.
    /// </summary>
    public string TexturePath 
    { get; set; } = string.Empty;

    /// <summary>
    /// Gets the number of rows of frames in the sprite sheet.
    /// </summary>
    public int RowCount 
    { get; init; }

    /// <summary>
    /// Gets the number of columns of frames in the sprite sheet.
    /// </summary>
    public int ColumnCount 
    { get; init; }

    /// <summary>
    /// Gets the index of the row for upward movement.
    /// </summary>
    public int RowUp
    { get; init; }

    /// <summary>
    /// Gets the index of the row for downward movement.
    /// </summary>
    public int RowDown
    { get; init; }

    /// <summary>
    /// Gets the index of the row for leftward movement.
    /// </summary>
    public int RowLeft
    { get; init; }

    /// <summary>
    /// Gets the index of the row for rightward movement.
    /// </summary>
    public int RowRight
    { get; init; }

    /// <summary>
    /// Gets or sets the index of the row containing initially drawn frames, prior to any movement occurring.
    /// </summary>
    public int RowInitial
    { get; set; }
}
