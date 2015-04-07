/*  $Id: FloorFace.cs,v 1.1 2006/11/17 06:46:14 jenetic.bytemare Exp $
 *  =================================================================================
 *  Abstract class Wall.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CsGL.OpenGL;
using Classes.Game;
using Classes.Engine3D;

namespace Classes.Engine3D.WallFaces
{
    public class FloorFace : WallFace
    {
        public FloorFace( float initX, float initY, float initZ, float initWidth, float initHeight, int initTextureID, float initTilingX, float initTilingY ) : base( ref initTilingX, ref initTilingY, initWidth, initHeight )
        {
            textureID = initTextureID;
            vertices  = new Vertex[]
            {
                new Vertex ( initX,             initY, initZ,               0.0f,           initTilingY ),
                new Vertex ( initX + initWidth, initY, initZ,               initTilingX,    initTilingY ),
                new Vertex ( initX + initWidth, initY, initZ + initHeight,  initTilingX,    0.0f        ),
                new Vertex ( initX,             initY, initZ + initHeight,  0.0f,           0.0f        ),
            }; //endarray
        } //endconstruct
    } //endclass
} //endnamespace

/*
 *  $Log: FloorFace.cs,v $
 *  Revision 1.1  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.1  2006/10/31 00:03:17  Mr. jenetic.bytemare
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
 *  Revision 1.2  2006/10/06 20:27:49  jenetic.bytemare
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
