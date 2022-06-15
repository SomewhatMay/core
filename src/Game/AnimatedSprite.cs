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

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BadEcho.Game;

/// <summary>
/// Provides a canvas for a texture containing multiple smaller images arranged tabularly, allowing for the animation of a 2D entity
/// via selective image drawing of the frames found on a provided sprite sheet.
/// </summary>
public sealed class AnimatedSprite : Sprite
{
    private readonly IMovementSystem _movementSystem;
    private readonly SpriteSheet _sheet;
    // TODO: Replace with configurable initial state, or better approach period.
    private TimeSpan _frameLifetime = TimeSpan.FromSeconds(0.125);
    private MovementDirection _direction;
    private int _currentFrame;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatedSprite"/> class.
    /// </summary>
    /// <param name="sheet">The sprite sheet containing the various animation frames of the sprite.</param>
    /// <param name="position">The drawing location of the animated sprite.</param>
    /// <param name="movementSystem"></param>
    public AnimatedSprite(SpriteSheet sheet, Vector2 position, IMovementSystem movementSystem)
        : base(GetSheetTexture(sheet), position)
    {
        Require.NotNull(movementSystem, nameof(movementSystem));
        
        _sheet = sheet;
        _movementSystem = movementSystem;
    }

    /// <inheritdoc/>
    /// TODO: Review for correctness.
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        _movementSystem.UpdateMovement(this);
        MovementDirection newDirection = Velocity.ToDirection();
        
        if (_direction != newDirection)
        {
            _currentFrame = 0;

            // If no movement is occurring, then we want to preserve our current direction, reset back to its initial animation frame.
            if (newDirection != MovementDirection.None)
                _direction = newDirection;
        }
        else if(newDirection != MovementDirection.None)
        {
            _frameLifetime -= gameTime.ElapsedGameTime;
            if (_frameLifetime <= TimeSpan.Zero)
            {   // TODO: Replace with proper frame / distance system.
                _currentFrame++;
                _frameLifetime = TimeSpan.FromSeconds(0.25) / Math.Max(Math.Abs(Velocity.X), Math.Abs(Velocity.Y));
            }
        }

        if (_currentFrame == _sheet.Columns)
            _currentFrame = 0;
    }

    /// <inheritdoc/>
    protected override Rectangle GetSourceRectangle() 
        => _sheet.GetFrameRectangle(_direction, _currentFrame);

    /// <inheritdoc/>
    protected override Rectangle GetTargetRectangle()
        => new(Position.ToPoint(), _sheet.FrameSize);

    private static Texture2D GetSheetTexture(SpriteSheet sheet)
    {
        Require.NotNull(sheet, nameof(sheet));

        return sheet.Texture;
    }
}