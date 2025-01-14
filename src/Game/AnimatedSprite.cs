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

using Microsoft.Xna.Framework;

namespace BadEcho.Game;

/// <summary>
/// Provides a canvas for a texture containing multiple smaller images arranged tabularly, allowing for the animation of a 2D entity
/// via selective image drawing of the frames found on a provided sprite sheet.
/// </summary>
public sealed class AnimatedSprite : Sprite
{
    private readonly SpriteSheet _sheet;

    // TODO: Replace with configurable initial value.
    private float _remainingFrameDistance = 15.0f;    
    private MovementDirection _direction;
    private int _currentFrame;

    /// <summary>
    /// Initializes a new instance of the <see cref="AnimatedSprite"/> class.
    /// </summary>
    /// <param name="sheet">The sprite sheet containing the various animation frames of the sprite.</param>
    /// <param name="movementSystem">The movement system controlling the sprite's movement.</param>
    public AnimatedSprite(SpriteSheet sheet, IMovementSystem movementSystem)
        : base(GetSheetTexture(sheet), movementSystem)
    {
        _sheet = sheet;
    }

    /// <inheritdoc/>
    public override void Update(GameState state)
    {
        base.Update(state);
        
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
            float frameDistanceDelta = newDirection is MovementDirection.Up or MovementDirection.Down
                ? Math.Abs(LastMovement.Y)
                : Math.Abs(LastMovement.X);

            _remainingFrameDistance -= frameDistanceDelta;

            if (_remainingFrameDistance <= 0)
            {   
                _currentFrame++;
                _remainingFrameDistance = 15.0f;
            }
        }

        if (_currentFrame == _sheet.ColumnCount)
            _currentFrame = 0;
    }

    /// <inheritdoc/>
    protected override Rectangle GetSourceArea() 
        => _sheet.GetFrameRectangle(_direction, _currentFrame);

    /// <inheritdoc/>
    protected override RectangleF GetTargetArea()
        => new(Position, _sheet.FrameSize);

    private static BoundedTexture GetSheetTexture(SpriteSheet sheet)
    {
        Require.NotNull(sheet, nameof(sheet));

        return new BoundedTexture(new RectangleF(PointF.Empty, sheet.FrameSize), sheet.Texture);
    }
}
