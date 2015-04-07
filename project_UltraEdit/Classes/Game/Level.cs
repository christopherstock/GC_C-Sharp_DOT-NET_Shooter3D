/*  $Id: Level.cs,v 1.15 2006/11/17 06:46:14 jenetic.bytemare Exp $
 *  ==================================================================================
 *  Holds all level-data.
 */

using System;
using System.Windows.Forms;
using Classes.Engine3D;
using System.Drawing;
using CsGL.OpenGL;
using Classes.Engine3D.MeshCollection;
using Classes.Engine3D.SolidMeshes;
using Classes.Engine3D.WallFaces;
using Classes.IO;

namespace Classes.Game
{
    public class Level
    {
        public  const   Boolean             PLAY_BG_SOUND       = true;

        public  const   int                 LEVEL_1             = 0;
        public  const   int                 LEVEL_2             = 1;
        public  const   int                 LEVEL_3             = 2;
        public  const   int                 LEVEL_4             = 3;
        public  const   int                 LEVEL_5             = 4;

        public  const   int                 LEVEL_WIDTH         = 0;
        public  const   int                 LEVEL_HEIGHT        = 1;
        public  const   int                 LEVEL_START_POS_X   = 2;
        public  const   int                 LEVEL_START_POS_Y   = 3;
        public  const   int                 LEVEL_START_POS_Z   = 4;
        public  const   int                 LEVEL_START_ROT_Y   = 5;
        public  const   int                 LEVEL_BG            = 6;

        //static variables
        public  static  int                 currentLevel        = 0;
        public  static  int                 bg                  = 0;

        public  static  float               levelWidth          = 0.0f;
        public  static  float               levelHeight         = 0.0f;
        public  static  float               startPosX           = 0;
        public  static  float               startPosY           = 0;
        public  static  float               startPosZ           = 0;
        public  static  float               startRotY           = 0;

        public  static  MeshCollection[]    meshCollections     = null;

        public static void init()
        {
            float[] floatData   = (float[])             LevelData.levelData[ currentLevel ][ 0 ];
            meshCollections     = (MeshCollection[])    LevelData.levelData[ currentLevel ][ 1 ];

            levelWidth          = floatData[ LEVEL_WIDTH ];
            levelHeight         = floatData[ LEVEL_HEIGHT ];
            startPosX           = floatData[ LEVEL_START_POS_X ];
            startPosY           = floatData[ LEVEL_START_POS_Y ];
            startPosZ           = floatData[ LEVEL_START_POS_Z ];
            startRotY           = floatData[ LEVEL_START_ROT_Y ];
            bg                  = (int)( floatData[ LEVEL_BG ] );

            //start the bg-loop
            if ( PLAY_BG_SOUND ) AudioSystem.startBgLoop();

        } //endconstruct

        public static void draw()
        {
            //draw all MeshCollections
            foreach ( MeshCollection meshCollection in meshCollections )
            {
                meshCollection.draw();
            } //endforeach
        } //endmethod

        public static void drawBg()
        {
            //assign texture's position on the bg-face
            float texX  = ( 360.0f - Character.rotY ) * 1.0f / 360.0f;
            float posY  = -0.3f;

            //posY  += ( Character.rotX * 1.0f / Character.CHARACTER_MAX_Y_VIEW );

            GL.glLoadIdentity();                        //new identity please
            GL.glEnable(    GL.GL_TEXTURE_2D    );      //enable texture-mapping
            GL.glColor3f(   1.0f, 1.0f, 1.0f    );      //reset colors
            GL.glDepthMask( 0 );                        //disable the depth-mask

            GL.glBindTexture( GL.GL_TEXTURE_2D, Texture.textureData[ bg ] );
            GL.glBegin( GL.GL_QUADS );
            GL.glTexCoord2f(    texX,           0.0f );   GL.glVertex3f(      -2.2f,    posY,           -3.75f );
            GL.glTexCoord2f(    texX + 0.2f,    0.0f );   GL.glVertex3f(      2.2f,     posY,           -3.75f );
            GL.glTexCoord2f(    texX + 0.2f,    1.0f );   GL.glVertex3f(      2.2f,     posY + 1.9f,    -3.75f );
            GL.glTexCoord2f(    texX,           1.0f );   GL.glVertex3f(      -2.2f,    posY + 1.90f,    -3.75f );
            GL.glEnd();

            GL.glDepthMask( 1 );                        //enable the depth-mask

        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: Level.cs,v $
 *  Revision 1.15  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.9  2006/10/12 14:12:08  Mr. jenetic.bytemare
 *  implemented directX sound-system
 *  levelEditor in progress
 *
 *  Revision 1.8  2006/10/31 00:03:18  Mr. jenetic.bytemare
 *  completed descending walls - fixed a bug
 *
 *  Revision 1.7  2006/10/10 18:25:00  Mr. jenetic.bytemare
 *  completed bg
 *
 *  Revision 1.6  2006/10/10 18:08:31  Mr. jenetic.bytemare
 *  completed bg
 *
 *  Revision 1.5  2006/10/10 13:56:12  Mr. jenetic.bytemare
 *  bg implementation
 *
 *  Revision 1.4  2006/10/10 12:23:08  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/10 11:28:33  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.14  2006/10/06 20:27:51  jenetic.bytemare
 *  completed 3dsmax-importer
 *
 *  Revision 1.13  2006/10/06 18:22:41  jenetic.bytemare
 *  repackaged classes
 *
 *  Revision 1.12  2006/10/06 18:19:14  jenetic.bytemare
 *  completed unmasked faces
 *  repackaged classes
 *
 *  Revision 1.11  2006/10/05 19:05:28  jenetic.bytemare
 *  rearranged packages
 *  completed box-mesh
 *
 *  Revision 1.10  2006/10/04 21:10:05  jenetic.bytemare
 *  collisions in progress ..
 *
 *  Revision 1.9  2006/10/04 14:23:07  jenetic.bytemare
 *  house-object completed
 *
 *  Revision 1.8  2006/10/04 12:23:56  jenetic.bytemare
 *  new wall-system completed
 *  pruned 2d-array-structure!
 *
 *  Revision 1.7  2006/10/03 20:29:38  jenetic.bytemare
 *  completed cell-system
 *  implemented cell-templates
 *
 *  Revision 1.6  2006/10/03 17:04:24  jenetic.bytemare
 *  completed floor, left and right wall
 *
 *  Revision 1.5  2006/10/03 15:14:36  jenetic.bytemare
 *  tyding all classes
 *
 *  Revision 1.4  2006/10/03 13:42:19  jenetic.bytemare
 *  completed floor-texturing
 *
 *  Revision 1.3  2006/10/02 21:54:59  jenetic.bytemare
 *  implemented point-colliding
 *  region-colliding in progress
 *
 *  Revision 1.2  2006/10/02 18:40:23  jenetic.bytemare
 *  2d-array and collisions completed
 *
 *  Revision 1.1  2006/10/02 12:08:41  jenetic.bytemare
 *  2d-collision-level-system in progress
 *
 */
