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

using BadEcho.Extensions;
using BadEcho.Game.Pipeline.Properties;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

namespace BadEcho.Game.Pipeline.Tiles;

/// <summary>
/// Provides a processor of tile set asset data for the content pipeline.
/// </summary>
[ContentProcessor(DisplayName = "Tile Set Processor - Bad Echo")]
public sealed class TileSetProcessor : ContentProcessor<TileSetContent, TileSetContent>
{
    /// <inheritdoc />
    public override TileSetContent Process(TileSetContent input, ContentProcessorContext context)
    {
        Require.NotNull(input, nameof(input));
        Require.NotNull(context, nameof(context));

        context.Log(Strings.ProcessingTileSet.InvariantFormat(input.Identity.SourceFilename));

        TileSetAsset asset = input.Asset;

        if (asset.Image != null)
        {
            var processorParameters = new OpaqueDataDictionary
                                      {
                                          { nameof(TextureProcessor.ColorKeyColor), asset.Image.ColorKey },
                                          { nameof(TextureProcessor.ColorKeyEnabled), true }
                                      };
            
            input.AddReference<Texture2DContent>(context, asset.Image.Source, processorParameters);
        }

        context.Log(Strings.ProcessingFinished.InvariantFormat(input.Identity.SourceFilename));

        return input;
    }
}
