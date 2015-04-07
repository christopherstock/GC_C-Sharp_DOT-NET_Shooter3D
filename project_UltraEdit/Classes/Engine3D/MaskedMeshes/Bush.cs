/*  $Id: Bush.cs,v 1.5 2006/11/17 06:46:13 jenetic.bytemare Exp $
 *  =================================================================================
 *  A bush.
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

namespace Classes.Engine3D.MaskedMeshes
{
    public class Bush : Mesh
    {
        public Bush
        (
            float   posX,
            float   posY,
            float   posZ,
            float   width,
            float   height,
            float   depth,
            float   collisionRadius,
            int     mask,
            int     texture,
            float   textureTilingX,
            float   textureTilingY
        )
        :
        base
        (
            //define the faces
            new Face[]
            {
                new MaskedFace
                (
                    mask,
                    texture,
                    new Vertex[]
                    {
                        new Vertex( posX - width / 2,   posY,           posZ,   0.0f,           0.0f            ),
                        new Vertex( posX + width / 2,   posY,           posZ,   textureTilingX, 0.0f            ),
                        new Vertex( posX + width / 2,   posY + depth,   posZ,   textureTilingX, textureTilingY  ),
                        new Vertex( posX - width / 2,   posY + depth,   posZ,   0.0f,           textureTilingY  ),
                    }
                ),

                new MaskedFace
                (
                    mask,
                    texture,
                    new Vertex[]
                    {
                        new Vertex( posX,   posY,           posZ - height / 2,  0.0f,           0.0f            ),
                        new Vertex( posX,   posY,           posZ + height / 2,  textureTilingX, 0.0f            ),
                        new Vertex( posX,   posY + depth,   posZ + height / 2,  textureTilingX, textureTilingY  ),
                        new Vertex( posX,   posY + depth,   posZ - height / 2,  0.0f,           textureTilingY  ),
                    }
                ),
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
            graphicsPath.AddEllipse( 1000 * ( posX - collisionRadius ), 1000 * ( posZ - collisionRadius ), 2000 * collisionRadius, 2000 * collisionRadius );
            insideRegion = new Region( graphicsPath );

        } //endconstruct
    } //endclass
} //endnamespace

/*
 *  $Log: Bush.cs,v $
 *  Revision 1.5  2006/11/17 06:46:13  jenetic.bytemare
 *  safe
 *
 *  Revision 1.5  2006/10/31 00:03:14  Mr. jenetic.bytemare
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
 *  Revision 1.1  2006/10/06 15:50:56  jenetic.bytemare
 *  blending-problems in progress ..
 *
 *
 */
