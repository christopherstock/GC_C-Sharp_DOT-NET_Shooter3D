/*  $Id: WallFace.cs,v 1.1 2006/11/17 06:46:14 jenetic.bytemare Exp $
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
    public abstract class WallFace : SolidFace
    {
        public WallFace( ref float initTilingX, ref float initTilingY, float initWidth, float initHeight ) : base( 0, null, null )
        {
            //assign the tiling if default
            if ( initTilingX == Texture.TILING_DEFAULT ) initTilingX = initWidth    / Texture.DEFAULT_WIDTH;
            if ( initTilingY == Texture.TILING_DEFAULT ) initTilingY = initHeight   / Texture.DEFAULT_HEIGHT;

        } //endconstruct
    } //endclass
} //endnamespace

/*
 *  $Log: WallFace.cs,v $
 *  Revision 1.1  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.1  2006/10/31 00:03:17  Mr. jenetic.bytemare
 *  completed descending walls - fixed a bug
 *
 *  Revision 1.4  2006/10/10 12:23:08  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/10 11:28:32  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/09 17:26:22  jenetic.bytemare
 *  elevated floors completed
 *
 *  Revision 1.2  2006/10/06 20:27:50  jenetic.bytemare
 *  completed 3dsmax-importer
 *
 *  Revision 1.1  2006/10/06 18:22:41  jenetic.bytemare
 *  repackaged classes
 *
 *  Revision 1.2  2006/10/06 18:19:13  jenetic.bytemare
 *  completed unmasked faces
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
