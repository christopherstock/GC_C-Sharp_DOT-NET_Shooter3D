/*  $Id: Face.cs,v 1.7 2006/11/17 06:46:13 jenetic.bytemare Exp $
 *  =================================================================================
 *  Face - an abstract super-class of all faces.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CsGL.OpenGL;

namespace Classes.Engine3D
{
    public abstract class Face
    {
        public  int         textureID   = Texture.TEXTURE_NONE;
        public  Vertex[]    vertices    = null;

        public abstract void draw();

    } //endclass

} //endnamespace

/*
 *  $Log: Face.cs,v $
 *  Revision 1.7  2006/11/17 06:46:13  jenetic.bytemare
 *  safe
 *
 *  Revision 1.4  2006/10/10 12:23:07  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.3  2006/10/10 11:28:30  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.6  2006/10/09 17:26:20  jenetic.bytemare
 *  elevated floors completed
 *
 *  Revision 1.5  2006/10/06 20:27:49  jenetic.bytemare
 *  completed 3dsmax-importer
 *
 *  Revision 1.4  2006/10/06 18:19:12  jenetic.bytemare
 *  completed unmasked faces
 *  repackaged classes
 *
 *  Revision 1.3  2006/10/06 11:41:50  jenetic.bytemare
 *  outsourced hud
 *  new class for masked quad-faces
 *
 */
