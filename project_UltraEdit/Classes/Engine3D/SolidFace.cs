/*  $Id: SolidFace.cs,v 1.3 2006/11/17 06:46:13 jenetic.bytemare Exp $
 *  =================================================================================
 *  A solid face is a face without transparency.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CsGL.OpenGL;

namespace Classes.Engine3D
{
    public class SolidFace : Face
    {
        public      float[]     color       = null;

        public SolidFace( int initTextureID, float[] initColor, Vertex[] initVertices )
        {
            color       = initColor;
            textureID   = initTextureID;
            vertices    = initVertices;

        } //endconstruct

        public override void draw()
        {
            if ( textureID == Texture.TEXTURE_NONE )
            {
                //draw colored polygon

                //disable texture-mapping and set the desired color
                GL.glDisable(   GL.GL_TEXTURE_2D    );
                GL.glColor3fv(   color );

                //draw all vertices
                GL.glBegin( GL.GL_POLYGON );
                foreach ( Vertex currentVertex in vertices )
                {
                    GL.glVertex3f(      currentVertex.x, currentVertex.y, currentVertex.z );
                } //endforeach
                GL.glEnd();
            }
            else
            {
                //enable texture-mapping and reset colors
                GL.glEnable(    GL.GL_TEXTURE_2D    );
                GL.glColor3f(   1.0f, 1.0f, 1.0f    );

                //bind face's texture
                GL.glBindTexture( GL.GL_TEXTURE_2D, Texture.textureData[ textureID  ] );

                //draw all vertices
                GL.glBegin( GL.GL_POLYGON );
                foreach ( Vertex currentVertex in vertices )
                {
                    GL.glTexCoord2f(    currentVertex.u, currentVertex.v );
                    GL.glVertex3f(      currentVertex.x, currentVertex.y, currentVertex.z );
                } //endforeach
                GL.glEnd();

            } //endif
        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: SolidFace.cs,v $
 *  Revision 1.3  2006/11/17 06:46:13  jenetic.bytemare
 *  safe
 *
 *  Revision 1.4  2006/10/10 13:56:11  Mr. jenetic.bytemare
 *  bg implementation
 *
 *  Revision 1.3  2006/10/10 11:28:30  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.2  2006/10/06 20:27:49  jenetic.bytemare
 *  completed 3dsmax-importer
 *
 *  Revision 1.1  2006/10/06 18:19:13  jenetic.bytemare
 *  completed unmasked faces
 *  repackaged classes
 *
 *  Revision 1.9  2006/10/06 11:41:50  jenetic.bytemare
 *  outsourced hud
 *  new class for masked quad-faces
 *
 *  Revision 1.8  2006/10/05 19:05:26  jenetic.bytemare
 *  rearranged packages
 *  completed box-mesh
 *
 *  Revision 1.7  2006/10/04 12:23:56  jenetic.bytemare
 *  new wall-system completed
 *  pruned 2d-array-structure!
 *
 *  Revision 1.6  2006/10/03 20:29:38  jenetic.bytemare
 *  completed cell-system
 *  implemented cell-templates
 *
 *  Revision 1.5  2006/10/03 17:04:24  jenetic.bytemare
 *  completed floor, left and right wall
 *
 *  Revision 1.4  2006/10/03 15:14:35  jenetic.bytemare
 *  tyding all classes
 *
 *  Revision 1.3  2006/10/03 13:42:19  jenetic.bytemare
 *  completed floor-texturing
 *
 *  Revision 1.2  2006/10/02 21:54:59  jenetic.bytemare
 *  implemented point-colliding
 *  region-colliding in progress
 *
 *  Revision 1.1  2006/10/02 18:40:23  jenetic.bytemare
 *  2d-array and collisions completed
 */
