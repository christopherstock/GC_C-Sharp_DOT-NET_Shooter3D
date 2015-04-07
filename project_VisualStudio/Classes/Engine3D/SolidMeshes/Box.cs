/*  $Id: Box.cs,v 1.5 2006/11/17 06:46:14 jenetic.bytemare Exp $
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
    public class Box : Mesh
    {
        public Box
        (
            float   posX,
            float   posY,
            float   posZ,
            float   width,
            float   height,
            float   depth,
            int     texture,
            float   textureTilingX,
            float   textureTilingY
        )
        :
        base
        (
            new Face[]
            {
                new LeftWallFace(   posX,           posY,           posZ,           height, depth,  texture, textureTilingX, textureTilingY ),
                new RightWallFace(  posX + width,   posY,           posZ,           height, depth,  texture, textureTilingX, textureTilingY ),
                new FrontWallFace(  posX,           posY,           posZ + height,  width,  depth,  texture, textureTilingX, textureTilingY ),
                new RearWallFace(   posX,           posY,           posZ,           width,  depth,  texture, textureTilingX, textureTilingY ),
                new FloorFace(      posX,           posY + depth,   posZ,           width,  height, texture, textureTilingX, textureTilingY ),
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
                    new PointF( 1000 * posX,                1000 * posZ                 ),
                    new PointF( 1000 * ( posX + width ),    1000 * posZ                 ),
                    new PointF( 1000 * ( posX + width ),    1000 * ( posZ + height )    ),
                    new PointF( 1000 * posX,                1000 * ( posZ + height )    ),
                }
            );
            insideRegion = new Region( graphicsPath );

        } //endconstruct
    } //endclass
} //endnamespace

/*
 *  $Log: Box.cs,v $
 *  Revision 1.5  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.5  2006/10/31 00:03:15  Mr. jenetic.bytemare
 *  completed descending walls - fixed a bug
 *
 *  Revision 1.4  2006/10/10 12:23:07  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/10 11:28:31  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.4  2006/10/09 17:26:20  jenetic.bytemare
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
