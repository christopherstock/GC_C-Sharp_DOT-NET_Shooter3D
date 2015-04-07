/*  $Id: Texture.cs,v 1.12 2006/11/17 06:46:13 jenetic.bytemare Exp $
 *  ==================================================================================
 *  The texture-system.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Classes.EngineGame;
using CsGL.OpenGL;

namespace Classes.Engine3D
{
    public class Texture
    {
        public const    int             TEXTURE_FILE_ID             = 0;

        public const    int             TEXTURE_NONE                = -1;
        public const    int             TEXTURE_TEST                = 0;
        public const    int             TEXTURE_STONES_1            = 1;
        public const    int             TEXTURE_SAND_1              = 2;
        public const    int             TEXTURE_BRICKS_1            = 3;
        public const    int             TEXTURE_WOOD_1              = 4;
        public const    int             TEXTURE_WOOD_2              = 5;
        public const    int             TEXTURE_BRICKS_2            = 6;
        public const    int             TEXTURE_BRICKS_3            = 7;
        public const    int             TEXTURE_CRATE_1             = 8;
        public const    int             TEXTURE_TEST_1              = 9;
        public const    int             TEXTURE_TEST_MASK_1         = 10;
        public const    int             TEXTURE_PALM_1              = 11;
        public const    int             TEXTURE_PALM_MASK_1         = 12;
        public const    int             TEXTURE_TEST_2              = 13;
        public const    int             TEXTURE_TEST_MASK_2         = 14;
        public const    int             TEXTURE_KAKTUS_1            = 15;
        public const    int             TEXTURE_KAKTUS_MASK_1       = 16;
        public const    int             TEXTURE_BUSH_1              = 17;
        public const    int             TEXTURE_BUSH_MASK_1         = 18;
        public const    int             TEXTURE_BG_DESERT_CANYON    = 19;
        public const    int             TEXTURE_BG_DESERT_TOWN      = 20;
        public const    int             TEXTURE_BRICKS_4            = 21;
        public const    int             TEXTURE_WOOD_3              = 22;
        public const    int             TEXTURE_STAIRS_1            = 23;

        public  const   float           TILING_DEFAULT              = -1;
        public  const   float           TILING_0_15                 = 0.15f;
        public  const   float           TILING_0_25                 = 0.25f;
        public  const   float           TILING_0_30                 = 0.30f;
        public  const   float           TILING_1                    = 1.0f;
        public  const   float           TILING_2                    = 2.0f;
        public  const   float           TILING_3                    = 3.0f;
        public  const   float           TILING_4                    = 4.0f;
        public  const   float           TILING_5                    = 5.0f;
        public  const   float           TILING_6                    = 6.0f;
        public  const   float           TILING_7                    = 7.0f;
        public  const   float           TILING_8                    = 8.0f;
        public  const   float           TILING_9                    = 9.0f;
        public  const   float           TILING_10                   = 10.0f;
        public  const   float           TILING_20                   = 20.0f;
        public  const   float           TILING_40                   = 40.0f;
        public  const   float           TILING_80                   = 80.0f;

        public  const   float           DEFAULT_WIDTH               = 0.5f;
        public  const   float           DEFAULT_HEIGHT              = 0.5f;

        public static   uint[]          textureData                 = null;
        public static   Bitmap[]        bitmaps                     = null;

        public static   int[]           bitmap_data                 = new int[]
        {
        //                                          TEXTURE_FILE_ID
            /*  TEXTURE_TEST                    */  0,
            /*  TEXTURE_STONES_1                */  1,
            /*  TEXTURE_SAND_1                  */  2,
            /*  TEXTURE_BRICKS_1                */  3,
            /*  TEXTURE_WOOD_1                  */  4,
            /*  TEXTURE_WOOD_2                  */  5,
            /*  TEXTURE_BRICKS_2                */  6,
            /*  TEXTURE_BRICKS_3                */  7,
            /*  TEXTURE_CRATE_1                 */  8,
            /*  TEXTURE_TEST_1                  */  9,
            /*  TEXTURE_TEST_MASK_1             */  10,
            /*  TEXTURE_PALM_1                  */  11,
            /*  TEXTURE_PALM_MASK_1             */  12,
            /*  TEXTURE_TEST_2                  */  13,
            /*  TEXTURE_TEST_MASK_2             */  14,
            /*  TEXTURE_KAKTUS_1                */  15,
            /*  TEXTURE_KAKTUS_MASK_1           */  16,
            /*  TEXTURE_BUSH_1                  */  17,
            /*  TEXTURE_BUSH_MASK_1             */  18,
            /*  TEXTURE_BG_DESERT_CANYON        */  19,
            /*  TEXTURE_BG_DESERT_TOWN          */  20,
            /*  TEXTURE_BRICKS_4                */  21,
            /*  TEXTURE_WOOD_3                  */  22,
            /*  TEXTURE_STAIRS_1                */  23,
        }; //endarray

        public static void init()
        {
            //define number of bitmaps and textures
            bitmaps     = new Bitmap[   bitmap_data.Length ];
            textureData = new uint[     bitmap_data.Length ];

            //assign number of textures to GL
            GL.glGenTextures( textureData.Length, textureData );

            //browse all bitmaps
            for ( int currentBitmap = 0; currentBitmap < bitmaps.Length; ++currentBitmap )
            {
                //load the bitmap
                bitmaps[ currentBitmap ] = new Bitmap( "images/" + bitmap_data[ currentBitmap ] + ".bmp" );

                //avoid y-flipping
                bitmaps[ currentBitmap ].RotateFlip( RotateFlipType.RotateNoneFlipY );

                //get Bitmap's BitmapData
                BitmapData bitmapData = bitmaps[ currentBitmap ].LockBits( new Rectangle( 0, 0, bitmaps[ currentBitmap ].Width, bitmaps[ currentBitmap ].Height ), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb );
/*
                //assign Nearest Filtered Texture to GL [lowest performance]
                GL.glBindTexture(       GL.GL_TEXTURE_2D, textureData[ currentBitmap ] );
                GL.glTexParameteri(     GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_NEAREST );
                GL.glTexParameteri(     GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_NEAREST );
                GL.glTexImage2D(        GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB, bitmaps[ currentBitmap ].Width, bitmaps[ currentBitmap ].Height, 0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bitmapData.Scan0 );
*/

                //assign Linear Filtered Texture to GL [medium performance]
                GL.glBindTexture(       GL.GL_TEXTURE_2D, textureData[ currentBitmap ] );
                GL.glTexParameteri(     GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_LINEAR );
                GL.glTexParameteri(     GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_LINEAR );
                GL.glTexImage2D(        GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB, bitmaps[ currentBitmap ].Width, bitmaps[ currentBitmap ].Height, 0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bitmapData.Scan0 );

/*
                //assign MipMapped Texture to GL [fastest]
                GL.glBindTexture(       GL.GL_TEXTURE_2D, textureData[ currentBitmap ] );
                GL.glTexParameteri(     GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, GL.GL_LINEAR );
                GL.glTexParameteri(     GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_LINEAR_MIPMAP_NEAREST );
                GL.gluBuild2DMipmaps(   GL.GL_TEXTURE_2D, (int)GL.GL_RGB, bitmaps[ currentBitmap ].Width, bitmaps[ currentBitmap ].Height, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bitmapData.Scan0 );
*/
                //unlock bits and dispose bitmap
                bitmaps[ currentBitmap ].UnlockBits( bitmapData );
                bitmaps[ currentBitmap ].Dispose();

            } //endfor

        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: Texture.cs,v $
 *  Revision 1.12  2006/11/17 06:46:13  jenetic.bytemare
 *  safe
 *
 *  Revision 1.7  2006/10/31 01:27:25  Mr. jenetic.bytemare
 *  new meshes
 *
 *  Revision 1.6  2006/10/31 00:03:14  Mr. jenetic.bytemare
 *  completed descending walls - fixed a bug
 *
 *  Revision 1.5  2006/10/10 18:24:59  Mr. jenetic.bytemare
 *  completed bg
 *
 *  Revision 1.4  2006/10/10 13:56:11  Mr. jenetic.bytemare
 *  bg implementation
 *
 *  Revision 1.3  2006/10/10 11:28:31  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.11  2006/10/06 20:27:49  jenetic.bytemare
 *  completed 3dsmax-importer
 *
 *  Revision 1.10  2006/10/06 18:19:13  jenetic.bytemare
 *  completed unmasked faces
 *  repackaged classes
 *
 *  Revision 1.9  2006/10/06 15:50:30  jenetic.bytemare
 *  blending-problems in progress ..
 *
 *  Revision 1.8  2006/10/05 23:01:42  jenetic.bytemare
 *  completed transparent bitmap-objects
 *  completed hud
 *
 *  Revision 1.7  2006/10/05 19:05:27  jenetic.bytemare
 *  rearranged packages
 *  completed box-mesh
 *
 *  Revision 1.6  2006/10/04 14:23:07  jenetic.bytemare
 *  house-object completed
 *
 *  Revision 1.5  2006/10/04 12:23:56  jenetic.bytemare
 *  new wall-system completed
 *  pruned 2d-array-structure!
 *
 *  Revision 1.4  2006/10/03 20:29:38  jenetic.bytemare
 *  completed cell-system
 *  implemented cell-templates
 *
 *  Revision 1.3  2006/10/03 17:04:24  jenetic.bytemare
 *  completed floor, left and right wall
 *
 *  Revision 1.2  2006/10/03 15:14:36  jenetic.bytemare
 *  tyding all classes
 *
 *  Revision 1.1  2006/10/03 13:42:19  jenetic.bytemare
 *  completed floor-texturing
 *
 *
 */
