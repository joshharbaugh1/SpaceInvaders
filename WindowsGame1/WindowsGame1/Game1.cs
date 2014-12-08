using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Sprite background;
        private Sprite playerShip;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = new Sprite(Content.Load<Texture2D>("SpaceBackground"), Vector2.Zero);

            var shipTexture = Content.Load<Texture2D>("Spaceship Image");
            var yCoordinateofShip = graphics.GraphicsDevice.Viewport.Height - shipTexture.Height - 10;
            var xCoordinateOfShip = (graphics.GraphicsDevice.Viewport.Width / 2) - (shipTexture.Width / 2);

            playerShip = new Sprite(shipTexture, new Vector2(xCoordinateOfShip, yCoordinateofShip));

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            playerShip.Update(keyboardState, gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            background.Draw(spriteBatch);
            playerShip.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    public class Sprite
    {
        private readonly Texture2D texture;
        private Vector2 position;
        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        
        public void Update(KeyboardState keyboardState, GameTime gameTime)
        {


            if (keyboardState.IsKeyDown(Keys.Left))
                Velocity = new Vector2(-300, 0);
            if (keyboardState.IsKeyDown(Keys.Right))
                Velocity = new Vector2(300, 0);
            if (keyboardState.IsKeyDown(Keys.Up))
                Velocity = new Vector2(0, -300);
            if (keyboardState.IsKeyDown(Keys.Down))
                Velocity = new Vector2(0, 300);

            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    Velocity = new Vector2(0, -1000);
            //}


            position += (Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds);

        }
        protected Vector2 Velocity { get; set; }
    }
}
