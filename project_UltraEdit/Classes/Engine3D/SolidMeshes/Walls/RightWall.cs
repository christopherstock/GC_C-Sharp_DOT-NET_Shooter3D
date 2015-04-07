/*  $Id: RightWall.cs,v 1.3 2006/10/09 17:26:22 jenetic.bytemare Exp $
 *  =================================================================================
 *  A left wall.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CsGL.OpenGL;
using Classes.Game;
using Classes.Engine3D;

namespace Classes.Engine3D.SolidMeshes.Walls
{
    public class RightWall : Wall
    {
        public RightWall( float initX, float initY, float initZ, float initWidth, float initHeight, float initDepth, int initTextureID, float initTilingX, float initTilingY ) : base( ref initTilingX, ref initTilingY, initWidth, initHeight, initDepth )
        {
            textureID = initTextureID;
            vertices  = new Vertex[]
            {
                new Vertex ( initX,             initY,                  initZ,                  initTilingX,    0.0f            ),
                new Vertex ( initX,             initY,                  initZ + initWidth,      0.0f,           0.0f            ),
                new Vertex ( initX,             initY + initHeight,     initZ + initWidth,      0.0f,           initTilingY     ),
                new Vertex ( initX,             initY + initHeight,     initZ,                  initTilingX,    initTilingY     ),
            }; //endarray
        } //endconstruct
    } //endclass
} //endnamespace

/*
 *  $Log: RightWall.cs,v $
 *  Revision 1.3  2006/10/09 17:26:22  jenetic.bytemare
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
 *  Revision 1.1  2006/10/04 12:23:57  jenetic.bytemare
 *  new wall-system completed
 *  pruned 2d-array-structure!
 *
 */
