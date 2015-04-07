/*  $Id: FrontWallMesh.cs,v 1.1 2006/11/17 06:46:14 jenetic.bytemare Exp $
 *  =================================================================================
 *  A front-wall.
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
    public class FrontWallMesh : Mesh
    {
        public FrontWallMesh
        (
            float   posX,
            float   posY,
            float   posZ,
            float   width,
            float   height,
            int     textureID,
            float   tilingX,
            float   tilingY
        )
        :
        base
        (
            new Face[]
            {
                new FrontWallFace(  posX, posY, posZ, width, height, textureID, tilingX, tilingY ),
            },
            posX,
            posY,
            posZ,
            width,
            height,
            0.0f
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
                    new PointF( 1000 * ( posX + width ),    1000 * ( posZ + 0.001f )    ),
                    new PointF( 1000 * posX,                1000 * ( posZ + 0.001f )    ),
                }
            );
            insideRegion = new Region( graphicsPath );

        } //endconstruct
    } //endclass
} //endnamespace

/*
 *  $Log: FrontWallMesh.cs,v $
 *  Revision 1.1  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.1  2006/10/31 00:03:15  Mr. jenetic.bytemare
 *  completed descending walls - fixed a bug
 *
 *  Revision 1.4  2006/10/10 12:23:07  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/10 11:28:32  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/09 17:26:21  jenetic.bytemare
 *  elevated floors completed
 *
 *  Revision 1.2  2006/10/06 20:27:50  jenetic.bytemare
 *  completed 3dsmax-importer
 *
 *  Revision 1.1  2006/10/06 18:22:41  jenetic.bytemare
 *  repackaged classes
 *
 *  Revision 1.1  2006/10/05 19:05:27  jenetic.bytemare
 *  rearranged packages
 *  completed box-mesh
 *
 *  Revision 1.1  2006/10/04 12:23:56  jenetic.bytemare
 *  new wall-system completed
 *  pruned 2d-array-structure!
 *
 */
