/*  $Id: House.cs,v 1.5 2006/11/17 06:46:14 jenetic.bytemare Exp $
 *  =================================================================================
 *  A house.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using CsGL.OpenGL;
using Classes.Game;
using Classes.Engine3D;
using Classes.Engine3D.WallFaces;

namespace Classes.Engine3D.SolidMeshes
{
    public class House : Mesh
    {
        public House
        (
            float   posX,
            float   posY,
            float   posZ,
            float   width,
            float   height,
            float   depth,
            float   wallSize,
            float   doorSize,
            int     textureOutside,
            float   textureOutsideTilingX,
            float   textureOutsideTilingY,
            int     textureInside,
            float   textureInsideTilingX,
            float   textureInsideTilingY,
            int     textureFloor,
            float   textureFloorTilingX,
            float   textureFloorTilingY,
            int     textureCeiling,
            float   textureCeilingTilingX,
            float   textureCeilingTilingY
        )
        :
        base
        (
            //define the walls
            new Face[]
            {
                //outside
                new LeftWallFace(   posX,                                       posY,           posZ,                       height,                                 depth,                  textureOutside, textureOutsideTilingX,  textureOutsideTilingY   ),
                new RightWallFace(  posX + width,                               posY,           posZ,                       height,                                 depth,                  textureOutside, textureOutsideTilingX,  textureOutsideTilingY   ),
                new FrontWallFace(  posX,                                       posY,           posZ + height,              width,                                  depth,                  textureOutside, textureOutsideTilingX,  textureOutsideTilingY   ),
                new RearWallFace(   posX,                                       posY,           posZ,                       ( width - doorSize ) / 2,               depth,                  textureOutside, textureOutsideTilingX,  textureOutsideTilingY   ),
                new RearWallFace(   posX + ( width - doorSize ) / 2 + doorSize, posY,           posZ,                       ( width - doorSize ) / 2,               depth,                  textureOutside, textureOutsideTilingX,  textureOutsideTilingY   ),
                new RightWallFace(  posX + ( width - doorSize ) / 2,            posY,           posZ,                       wallSize,                               depth,                  textureOutside, textureOutsideTilingX,  textureOutsideTilingY   ),
                new LeftWallFace(   posX + ( width + doorSize ) / 2,            posY,           posZ,                       wallSize,                               depth,                  textureOutside, textureOutsideTilingX,  textureOutsideTilingY   ),
                //inside
                new LeftWallFace(   posX + wallSize,                            posY,           posZ + wallSize,            height - 2 * wallSize,                  depth,                  textureInside,  textureInsideTilingX,   textureInsideTilingY    ),
                new RightWallFace(  posX + width - wallSize,                    posY,           posZ + wallSize,            height - 2 * wallSize,                  depth,                  textureInside,  textureInsideTilingX,   textureInsideTilingY    ),
                new FrontWallFace(  posX + wallSize,                            posY,           posZ + height - wallSize,   width  - 2 * wallSize,                  depth,                  textureInside,  textureInsideTilingX,   textureInsideTilingY    ),
                new RearWallFace(   posX + wallSize,                            posY,           posZ + wallSize,            ( width - doorSize ) / 2 - wallSize,    depth,                  textureInside,  textureInsideTilingX,   textureInsideTilingY    ),
                new RearWallFace(   posX + ( width - doorSize ) / 2 + doorSize, posY,           posZ + wallSize,            ( width - doorSize ) / 2 - wallSize,    depth,                  textureInside,  textureInsideTilingX,   textureInsideTilingY    ),
                //floor
                new FloorFace(      posX + wallSize,                            posY + 0.001f,  posZ + wallSize,            width - 2 * wallSize,                   height - 2 * wallSize,  textureFloor,   textureFloorTilingX,    textureFloorTilingY     ),
                new CeilingFace(    posX,                                       posY + depth,   posZ,                       width,                                  height,                 textureCeiling, textureCeilingTilingX,  textureCeilingTilingY   ),

            },
            posX,
            posY,
            posZ,
            width,
            height,
            depth
        )
        {
            //specify the base as a GraphicsPath
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLines
            (
                new PointF[]
                {
                    new PointF( 1000 * posX,                                1000 * posZ                         ),
                    new PointF( 1000 * ( posX + ( width - doorSize ) / 2 ), 1000 * posZ                         ),
                    new PointF( 1000 * ( posX + ( width - doorSize ) / 2 ), 1000 * ( posZ + wallSize )          ),
                    new PointF( 1000 * ( posX + wallSize ),                 1000 * ( posZ + wallSize )          ),
                    new PointF( 1000 * ( posX + wallSize ),                 1000 * ( posZ + height - wallSize ) ),
                    new PointF( 1000 * ( posX + width - wallSize ),         1000 * ( posZ + height - wallSize ) ),
                    new PointF( 1000 * ( posX + width - wallSize ),         1000 * ( posZ + wallSize )          ),
                    new PointF( 1000 * ( posX + ( width + doorSize ) / 2 ), 1000 * ( posZ + wallSize )          ),
                    new PointF( 1000 * ( posX + ( width + doorSize ) / 2 ), 1000 * posZ                         ),
                    new PointF( 1000 * ( posX + width ),                    1000 * posZ                         ),
                    new PointF( 1000 * ( posX + width ),                    1000 * ( posZ + height )            ),
                    new PointF( 1000 * posX,                                1000 * ( posZ + height )            ),
                    new PointF( 1000 * posX,                                1000 * posZ                         ),
                }
            );
            insideRegion = new Region( graphicsPath );

        } //endconstruct
    } //endclass
} //endnamespace

/*
 *  $Log: House.cs,v $
 *  Revision 1.5  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.5  2006/10/31 00:03:15  Mr. jenetic.bytemare
 *  completed descending walls - fixed a bug
 *
 *  Revision 1.4  2006/10/10 12:23:07  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/10 11:28:32  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.4  2006/10/09 17:26:21  jenetic.bytemare
 *  elevated floors completed
 *
 *  Revision 1.3  2006/10/06 20:27:49  jenetic.bytemare
 *  completed 3dsmax-importer
 *
 *  Revision 1.2  2006/10/06 18:22:41  jenetic.bytemare
 *  repackaged classes
 *
 *  Revision 1.1  2006/10/06 18:19:13  jenetic.bytemare
 *  completed unmasked faces
 *  repackaged classes
 *
 *  Revision 1.3  2006/10/06 15:50:30  jenetic.bytemare
 *  blending-problems in progress ..
 *
 *  Revision 1.2  2006/10/06 11:41:50  jenetic.bytemare
 *  outsourced hud
 *  new class for masked quad-faces
 *
 *  Revision 1.1  2006/10/05 19:05:27  jenetic.bytemare
 *  rearranged packages
 *  completed box-mesh
 *
 *  Revision 1.1  2006/10/04 14:23:07  jenetic.bytemare
 *  house-object completed
 *
 *
 */
