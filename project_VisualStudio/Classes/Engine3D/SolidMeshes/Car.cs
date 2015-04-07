/*  $Id: Car.cs,v 1.4 2006/11/17 06:46:14 jenetic.bytemare Exp $
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
    public class Car : Mesh
    {
        public Car
        (
            float   posX,
            float   posY,
            float   posZ
        )
        :
        base
        (
            MeshData.getMeshData( MeshData.MESH_CAR, posX, posY, posZ ),
            posX,
            posY,
            posZ,
            0.0f,
            0.0f,
            0.0f
        )
    {

/*
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
*/
        } //endconstruct
    } //endclass
} //endnamespace

/*
 *  $Log: Car.cs,v $
 *  Revision 1.4  2006/11/17 06:46:14  jenetic.bytemare
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
 *  Revision 1.3  2006/10/09 17:26:21  jenetic.bytemare
 *  elevated floors completed
 *
 *  Revision 1.2  2006/10/08 20:50:27  jenetic.bytemare
 *  completed multi-object 3ds implementation
 *
 *  Revision 1.1  2006/10/06 20:29:02  jenetic.bytemare
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
