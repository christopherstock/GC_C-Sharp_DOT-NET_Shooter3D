/*  $Id: KeySystem.cs,v 1.8 2006/11/17 06:46:15 jenetic.bytemare Exp $
 *  ==================================================================================
 *  Handles key-inputs.
 */

using System;
using System.Windows.Forms;
using CsGL.OpenGL;
using Classes.Game;
using Classes.Engine3D;

namespace Classes.IO
{
    public class KeySystem
    {
        public  const   int     KEY_NONE        = -999;

        public  static  int     keyToProcess    = KEY_NONE;

        public  static  bool    keyUpHold       = false;
        public  static  bool    keyDownHold     = false;
        public  static  bool    keyLeftHold     = false;
        public  static  bool    keyRightHold    = false;
        public  static  bool    keyAltLeftHold  = false;
        public  static  bool    keyAltRightHold = false;
        public  static  bool    keyPageUpHold   = false;
        public  static  bool    keyPageDownHold = false;

        public static void keyUp( object sender, KeyEventArgs e )
        {
            onKeyUp( e.KeyCode );
        } //endmethod

        public static void keyDown( object sender, KeyEventArgs e )
        {
            onKeyDown( e.KeyCode );
        } //endmethod

        public static void onKeyUp( Keys keyCode )
        {
            switch ( keyCode )
            {
                case Keys.Up:
                {
                    keyUpHold = false;
                    break;
                } //endcase

                case Keys.Down:
                {
                    keyDownHold = false;
                    break;
                } //endcase

                case Keys.Left:
                {
                    keyLeftHold     = false;
                    keyAltLeftHold  = false;
                    break;
                } //endcase

                case Keys.Right:
                {
                    keyRightHold    = false;
                    keyAltRightHold = false;
                    break;
                } //endcase

                case Keys.Menu:
                {
                    keyAltLeftHold  = false;
                    keyAltRightHold = false;
                    break;
                } //endcase

                case Keys.PageUp:
                {
                    keyPageUpHold = false;
                    break;
                } //endcase

                case Keys.PageDown:
                {
                    keyPageDownHold = false;
                    break;
                } //endcase

                case Keys.C:
                {
                    Character.cheat_clipping = !Character.cheat_clipping;
                    break;
                } //endcase
            } //endswitch
        } //endmethod

        public static void onKeyDown( Keys keyData )
        {
            switch ( keyData )
            {
                case Keys.Up:
                case ( Keys.Up | Keys.Alt ):
                {
                    keyUpHold = true;
                    break;
                } //endcase

                case Keys.Down:
                case ( Keys.Down | Keys.Alt ):
                 {
                    keyDownHold = true;
                    break;
                } //endcase

                case Keys.Left:
                {
                    keyLeftHold = true;
                    break;
                } //endcase

                case Keys.Right:
                {
                    keyRightHold = true;
                    break;
                } //endcase

                case ( Keys.Left | Keys.Alt ):
                {
                    keyAltLeftHold = true;
                    break;
                } //endcase

                case ( Keys.Right | Keys.Alt ):
                {
                    keyAltRightHold = true;
                    break;
                } //endcase

                case Keys.PageUp:
                case ( Keys.PageUp | Keys.Alt ):
                {
                    keyPageUpHold = true;
                    break;
                } //endcase

                case Keys.PageDown:
                case ( Keys.PageDown | Keys.Alt ):
                {
                    keyPageDownHold = true;
                    break;
                } //endcase
            } //endswitch
        } //endmethod

        public static void processGameKey()
        {
            if ( keyUpHold )
            {
                //change character's position
                Character.newPosX = Character.posX - (float)Math.Sin( Character.rotY * Math.PI / 180.0 ) * Character.CHARACTER_WALKING_SPEED;
                Character.newPosZ = Character.posZ - (float)Math.Cos( Character.rotY * Math.PI / 180.0 ) * Character.CHARACTER_WALKING_SPEED;

                //increase walkY-axis-angle
                Character.walkingXangle += Character.CHARACTER_WALKING_Y_SPEED;
                Character.walkingXangle = Character.walkingXangle > 360.0f ? Character.walkingXangle - 360.0f : Character.walkingXangle;

            } //endif

            if ( keyDownHold )
            {
                //change character's position
                Character.newPosX = Character.posX + (float)Math.Sin( Character.rotY * Math.PI / 180.0 ) * Character.CHARACTER_WALKING_SPEED;
                Character.newPosZ = Character.posZ + (float)Math.Cos( Character.rotY * Math.PI / 180.0 ) * Character.CHARACTER_WALKING_SPEED;

                //decrease walkY-axis-angle
                Character.walkingXangle -= Character.CHARACTER_WALKING_Y_SPEED;
                Character.walkingXangle = Character.walkingXangle < 0.0f ? Character.walkingXangle + 360.0f : Character.walkingXangle;

            } //endif

            if ( keyLeftHold )
            {
                Character.rotY += Character.CHARACTER_TURNING_SPEED;
                Character.rotY = Character.rotY >= 360.0f ? Character.rotY - 360.0f : Character.rotY;
            } //endif

            if ( keyRightHold )
            {
                Character.rotY -= Character.CHARACTER_TURNING_SPEED;
                Character.rotY = Character.rotY < 0.0f ? Character.rotY + 360.0f : Character.rotY;
            } //endif

            if ( keyAltLeftHold )
            {
                Character.newPosX = Character.posX - (float)Math.Cos( Character.rotY * Math.PI / 180.0 ) * Character.CHARACTER_STRAFING_SPEED;
                Character.newPosZ = Character.posZ + (float)Math.Sin( Character.rotY * Math.PI / 180.0 ) * Character.CHARACTER_STRAFING_SPEED;
            } //endif

            if ( keyAltRightHold )
            {
                Character.newPosX = Character.posX + (float)Math.Cos( Character.rotY * Math.PI / 180.0 ) * Character.CHARACTER_STRAFING_SPEED;
                Character.newPosZ = Character.posZ - (float)Math.Sin( Character.rotY * Math.PI / 180.0 ) * Character.CHARACTER_STRAFING_SPEED;
            } //endif

            if ( keyPageUpHold )
            {
                Character.rotX -= Character.CHARACTER_LOOKING_SPEED;
                Character.rotX = Character.rotX < -Character.CHARACTER_MAX_Y_VIEW ? -Character.CHARACTER_MAX_Y_VIEW : Character.rotX;
            } //endif

            if ( keyPageDownHold )
            {
                Character.rotX += Character.CHARACTER_LOOKING_SPEED;
                Character.rotX = Character.rotX > Character.CHARACTER_MAX_Y_VIEW ? Character.CHARACTER_MAX_Y_VIEW : Character.rotX;
            } //endif
        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: KeySystem.cs,v $
 *  Revision 1.8  2006/11/17 06:46:15  jenetic.bytemare
 *  safe
 *
 *  Revision 1.3  2006/10/10 11:28:33  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.7  2006/10/09 17:26:22  jenetic.bytemare
 *  elevated floors completed
 *
 *  Revision 1.6  2006/10/04 21:10:05  jenetic.bytemare
 *  collisions in progress ..
 *
 *  Revision 1.5  2006/10/04 12:23:56  jenetic.bytemare
 *  new wall-system completed
 *  pruned 2d-array-structure!
 *
 *  Revision 1.4  2006/10/03 15:14:36  jenetic.bytemare
 *  tyding all classes
 *
 *  Revision 1.3  2006/10/03 13:42:19  jenetic.bytemare
 *  completed floor-texturing
 *
 *  Revision 1.2  2006/10/02 12:07:59  jenetic.bytemare
 *  2d-collision-level-system in progress
 *
 *  Revision 1.1  2006/10/02 11:23:41  jenetic.bytemare
 *  completed 3dsmax-importer.
 *  rearranged packages.
 *
 *  Revision 1.8  2006/10/01 19:01:00  jenetic.bytemare
 *  implemented strafing
 *  implemented frames-per-second debugging
 *
 *  Revision 1.7  2006/10/01 15:45:08  jenetic.bytemare
 *  3dsmax import in progress
 *
 *  Revision 1.6  2006/10/01 10:07:22  jenetic.bytemare
 *  pruned present code
 *  created class character
 *
 *  Revision 1.5  2006/09/29 21:07:56  jenetic.bytemare
 *  implemented multiple textures
 *
 *  Revision 1.4  2006/09/29 19:02:11  jenetic.bytemare
 *  implemented lighting, fading and blending
 *  implemented additional test-objects
 *
 *  Revision 1.3  2006/09/29 17:13:57  jenetic.bytemare
 *  implemented level-data
 *
 *  Revision 1.2  2006/09/29 15:08:34  jenetic.bytemare
 *  outsourcing key-system completed
 *
 *  Revision 1.1  2006/09/29 14:15:56  jenetic.bytemare
 *  outsourcing key-system in progress
 *
 *
 */
