/*  $Id: Hud.cs,v 1.2 2006/11/17 06:46:13 jenetic.bytemare Exp $
 *  ==================================================================================
 *  The image-system.
 */

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Classes.EngineGame;
using CsGL.OpenGL;

namespace Classes.Engine3D
{
    public class Hud
    {
        public static void draw()
        {
            //new identity please - translate in the screen
            GL.glLoadIdentity();
			GL.glTranslatef( -0.0f, -0.0f, -1.35f );

            //enable texture-mapping
            GL.glEnable( GL.GL_TEXTURE_2D );
            GL.glColor3f( 1.0f, 1.0f, 1.0f );

            //enable blending and disable the depth-test
            GL.glDisable(   GL.GL_DEPTH_TEST    );
			GL.glEnable(    GL.GL_BLEND         );

            //draw mask
            GL.glBlendFunc(GL.GL_DST_COLOR, GL.GL_ZERO);
            GL.glBindTexture( GL.GL_TEXTURE_2D, Texture.textureData[ Texture.TEXTURE_TEST_MASK_2 ] );
            GL.glBegin( GL.GL_QUADS );
            GL.glTexCoord2f( 0.0f,  0.0f    );  GL.glVertex3f(  0.6f,   -0.5f,  0.0f    );
            GL.glTexCoord2f( 1.0f,  0.0f    );  GL.glVertex3f(  0.7f,   -0.5f,  0.0f    );
            GL.glTexCoord2f( 1.0f,  1.0f    );  GL.glVertex3f(  0.7f,   -0.3f,  0.0f    );
            GL.glTexCoord2f( 0.0f,  1.0f    );  GL.glVertex3f(  0.6f,   -0.3f,  0.0f    );
            GL.glEnd();

            //draw transparent image
            GL.glBlendFunc(GL.GL_ONE, GL.GL_ONE);
            GL.glBindTexture( GL.GL_TEXTURE_2D, Texture.textureData[ Texture.TEXTURE_TEST_2 ] );
            GL.glBegin( GL.GL_QUADS );
            GL.glTexCoord2f( 0.0f,  0.0f    );  GL.glVertex3f(  0.6f,   -0.5f,  0.0f    );
            GL.glTexCoord2f( 1.0f,  0.0f    );  GL.glVertex3f(  0.7f,   -0.5f,  0.0f    );
            GL.glTexCoord2f( 1.0f,  1.0f    );  GL.glVertex3f(  0.7f,   -0.3f,  0.0f    );
            GL.glTexCoord2f( 0.0f,  1.0f    );  GL.glVertex3f(  0.6f,   -0.3f,  0.0f    );
            GL.glEnd();

            //disable blending and enable the depth-test
			GL.glDisable(   GL.GL_BLEND         );
            GL.glEnable(    GL.GL_DEPTH_TEST    );

        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: Hud.cs,v $
 *  Revision 1.2  2006/11/17 06:46:13  jenetic.bytemare
 *  safe
 *
 *  Revision 1.3  2006/10/10 11:28:30  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.1  2006/10/06 11:41:50  jenetic.bytemare
 *  outsourced hud
 *  new class for masked quad-faces
 *
 *
 */
