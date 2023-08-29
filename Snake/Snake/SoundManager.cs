using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;


namespace Snake
{
    class SoundManager
    {
        private SoundEffect move;

        private SoundEffect eat;

        private SoundEffect death;

        public void LoadContent(ContentManager Content)
        {
            move = Content.Load<SoundEffect>("Move");
            eat = Content.Load<SoundEffect>("PickUp");
            death = Content.Load<SoundEffect>("Death");
        }

        public void PlayEat(float Volume)
        {
            SoundEffectInstance effectInstance = eat.CreateInstance();

            effectInstance.Volume = Volume;

            effectInstance.IsLooped = false;

            effectInstance.Play();
        }

        public void PlayMove(float Volume)
        {
            SoundEffectInstance effectInstance = move.CreateInstance();

            effectInstance.Volume = Volume;

            effectInstance.IsLooped = false;

            effectInstance.Play();
        }

        public void PlayDead(float Volume)
        {
            SoundEffectInstance effectInstance = death.CreateInstance();

            effectInstance.Volume = Volume;

            effectInstance.Play();
        }
    }
}
