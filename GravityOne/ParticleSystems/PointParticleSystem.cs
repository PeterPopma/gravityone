#region File Description
//-----------------------------------------------------------------------------
// ExplosionParticleSystem.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace Particle3DSample
{
    /// <summary>
    /// Custom particle system for creating the fiery part of the explosions.
    /// </summary>
    class PointParticleSystem : ParticleSystem
    {
        Random random = new Random();

        public PointParticleSystem(Game game, ContentManager content)
            : base(game, content)
        { }


        protected override void InitializeSettings(ParticleSettings settings)
        {
            settings.TextureName = "point";

            settings.MaxParticles = 12000;

            settings.Duration = TimeSpan.FromSeconds(2);

            settings.MinHorizontalVelocity = -40;
            settings.MaxHorizontalVelocity = 40;

            settings.MinVerticalVelocity = -10;
            settings.MaxVerticalVelocity = 160;

            int k = random.Next(3);

            if( k==0 ) // yellow
            {
                settings.MinColor = new Color(0, 0, 0, 1);
                settings.MaxColor = new Color(255, 255, 0, 255);
            }
            else if (k==1)   // red
            {
                settings.MinColor = new Color(0, 0, 0, 1);
                settings.MaxColor = new Color(255, 0, 0, 255);
            }
            else  // white
            {
                settings.MinColor = new Color(0, 0, 0, 1);
                settings.MaxColor = new Color(255, 255, 255, 255);
            }

            settings.Size = 10;

            // Use additive blending.
            settings.BlendState = BlendState.Additive;
        }
    }
}
