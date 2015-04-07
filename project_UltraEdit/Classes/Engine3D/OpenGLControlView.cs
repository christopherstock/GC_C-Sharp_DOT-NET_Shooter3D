/*  $Id: OpenGLControlView.cs,v 1.15 2006/11/06 11:39:47 jenetic.bytemare Exp $
 *  =================================================================================
 *  The OpenGL-Control.
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using CsGL.OpenGL;
using Classes.IO;
using Classes.Game;
using Classes.EngineGame;

namespace Classes.Engine3D
{
    public class OpenGLControlView : OpenGLControl
    {
        public static   OpenGLControlView  openGLControlView      = null;

        public          bool        firstGlDrawSkipped  = false;            //first glDraw() shall be skipped!
        private const   float       GL_DEPTH_BUFFER     = 1.0f;             //depth-buffer

        public OpenGLControlView() : base()
        {
            Parent      = Shooter3DForm.shooter3DForm;
            ClientSize  = Shooter3DForm.shooter3DForm.ClientSize;
            Dock        = DockStyle.Fill;
            KeyUp       += new KeyEventHandler( KeySystem.keyUp     );
            KeyDown     += new KeyEventHandler( KeySystem.keyDown   );
        } //endconstruct

        public static void init()
        {
            openGLControlView = new OpenGLControlView();
        } //endmethod

        protected override void InitGLContext()
        {
            //initialize the GL
            GL.glShadeModel(    GL.GL_SMOOTH                );      //smooth Shading ( GL_FLAT: flat shading )
            GL.glClearDepth(    GL_DEPTH_BUFFER             );      //set depth-buffer's size
            GL.glEnable(        GL.GL_DEPTH_TEST            );      //enable depth-sorting
            GL.glDepthFunc(     GL.GL_LEQUAL                );      //less or equal depth-testing! GL.GL_LESS caused problems in combination with blending!
            GL.glHint(          GL.GL_PERSPECTIVE_CORRECTION_HINT, GL.GL_NICEST );   //really nice perspective-calculations
            GL.glDisable(       GL.GL_LIGHTING              );      //disable lighting

            //GL.glEnable ( GL.GL_POLYGON_SMOOTH );                 //smoothes polygon
            //GL.glOrtho( -2.0, 0.0, -2.0, 0.0, -2.0, 0.0);         //ortho-screen?
            //GL.gluOrtho2D( 0, 640, 0, 480 );

        } //endmethod

        public override void glDraw()
        {
            //clear GL
            GL.glClearColor(    0.0f, 0.0f, 0.0f, 0.0f );
            GL.glClear(         GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT );

            if ( firstGlDrawSkipped )
            {
                Level.drawBg();                         //draw the level-bg
                setPlayerViewport();                    //set the viewport
                Level.draw();                           //draw the level
                drawPlayerDebugCircle();                //draw the debug-circle
                Hud.draw();                             //draw the HUD
            }
            else
            {
                firstGlDrawSkipped = true;
            } //endif
        } //endmethod

        private static void setPlayerViewport()
        {
            //calculate player's y-modification based on his height and walking angle
            float modY = Character.CHARACTER_DEPTH + (float)( Math.Sin( Character.walkingXangle * Math.PI / 180.0) / Character.CHARACTER_WALKING_Y_RATIO );

            GL.glLoadIdentity();                                                    //reset modelview
            GL.glNormal3f( 0.0f, 0.0f, 0.0f );                                      //normalize
            GL.glRotatef(           Character.rotZ, 0.0f, 0.0f, 1.0f );             //rotate x
            GL.glRotatef(           Character.rotX, 1.0f, 0.0f, 0.0f );             //rotate y
            GL.glRotatef( 360.0f -  Character.rotY, 0.0f, 1.0f, 0.0f );             //rotate z
            GL.glTranslatef( -Character.posX, -Character.posY - modY, -Character.posZ );   //translate

        } //endmethod

        private static void drawPlayerDebugCircle()
        {
            //disable texture-mapping and set yellow color
            GL.glDisable( GL.GL_TEXTURE_2D );
            GL.glColor3f( 1.0f, 0.0f, 0.0f );

            GL.glBegin( GL.GL_POLYGON );
            for ( int angle = 0; angle < 360; angle += 5 )
            {
                GL.glVertex3f( Character.posX + (float)( Math.Cos( angle * Math.PI / 180.0f ) * Character.CHARACTER_RADIUS ), 0.0001f, Character.posZ + (float)( Math.Sin( angle * Math.PI / 180.0f ) * Character.CHARACTER_RADIUS ) );
            } //endfor
            GL.glEnd();

        } //endmethod

        protected override void OnSizeChanged( EventArgs e )
        {
            base.OnSizeChanged( e) ;
            Size s = Size;

            s.Width     = s.Width == 0 ? 1 : s.Width;
            s.Height    = s.Width / 4 * 3;

            GL.glViewport( 0, 0, s.Width, s.Height );   //redefine hiewport
            GL.glMatrixMode( GL.GL_PROJECTION );
            GL.glLoadIdentity();                    //reset modelview-matrix
            GL.gluPerspective( 45.0f, (double)s.Width / (double)s.Height, 0.1f, 100.0f );
            GL.glMatrixMode( GL.GL_MODELVIEW );
            GL.glLoadIdentity();                    //reset modelview-matrix
        } //endmethod

        protected override bool ProcessDialogKey( Keys keyData )
        {
            KeySystem.onKeyDown( keyData );
            return true;

        } //endmethod
    } //endclass
} //endnamespace

/*
 *  $Log: OpenGLControlView.cs,v $
 *  Revision 1.15  2006/11/06 11:39:47  jenetic.bytemare
 *  no message
 *
 *  Revision 1.5  2006/10/31 01:27:25  Mr. jenetic.bytemare
 *  new meshes
 *
 *  Revision 1.4  2006/10/10 13:56:11  Mr. jenetic.bytemare
 *  bg implementation
 *
 *  Revision 1.3  2006/10/10 11:28:30  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.14  2006/10/06 18:19:12  jenetic.bytemare
 *  completed unmasked faces
 *  repackaged classes
 *
 *  Revision 1.13  2006/10/06 15:50:30  jenetic.bytemare
 *  blending-problems in progress ..
 *
 *  Revision 1.12  2006/10/06 11:41:50  jenetic.bytemare
 *  outsourced hud
 *  new class for masked quad-faces
 *
 *  Revision 1.11  2006/10/05 23:01:42  jenetic.bytemare
 *  completed transparent bitmap-objects
 *  completed hud
 *
 *  Revision 1.10  2006/10/05 19:05:26  jenetic.bytemare
 *  rearranged packages
 *  completed box-mesh
 *
 *  Revision 1.9  2006/10/04 21:10:04  jenetic.bytemare
 *  collisions in progress ..
 *
 *  Revision 1.8  2006/10/04 12:23:55  jenetic.bytemare
 *  new wall-system completed
 *  pruned 2d-array-structure!
 *
 *  Revision 1.7  2006/10/03 17:04:24  jenetic.bytemare
 *  completed floor, left and right wall
 *
 *  Revision 1.6  2006/10/03 15:14:35  jenetic.bytemare
 *  tyding all classes
 *
 *  Revision 1.5  2006/10/03 13:42:19  jenetic.bytemare
 *  completed floor-texturing
 *
 *  Revision 1.4  2006/10/02 21:54:59  jenetic.bytemare
 *  implemented point-colliding
 *  region-colliding in progress
 *
 *  Revision 1.3  2006/10/02 18:40:23  jenetic.bytemare
 *  2d-array and collisions completed
 *
 *  Revision 1.2  2006/10/02 12:07:59  jenetic.bytemare
 *  2d-collision-level-system in progress
 *
 *  Revision 1.1  2006/10/02 11:23:41  jenetic.bytemare
 *  completed 3dsmax-importer.
 *  rearranged packages.
 *
 *  Revision 1.6  2006/10/02 10:23:35  jenetic.bytemare
 *  streaming 3dsmax texture-vertices and texture-faces
 *
 *  Revision 1.5  2006/10/01 21:01:04  jenetic.bytemare
 *  completed 3dsmax-importer [textures are to come!]
 *
 *  Revision 1.4  2006/10/01 20:16:54  jenetic.bytemare
 *  restructured face- and vertex-class
 *
 *  Revision 1.3  2006/10/01 19:01:00  jenetic.bytemare
 *  implemented strafing
 *  implemented frames-per-second debugging
 *
 *  Revision 1.2  2006/10/01 15:45:09  jenetic.bytemare
 *  3dsmax import in progress
 *
 *  Revision 1.1  2006/10/01 10:07:22  jenetic.bytemare
 *  pruned present code
 *  created class character
 *
 *  Revision 1.6  2006/09/29 21:07:56  jenetic.bytemare
 *  implemented multiple textures
 *
 *  Revision 1.5  2006/09/29 19:02:11  jenetic.bytemare
 *  implemented lighting, fading and blending
 *  implemented additional test-objects
 *
 *  Revision 1.4  2006/09/29 17:13:57  jenetic.bytemare
 *  implemented level-data
 *
 *  Revision 1.3  2006/09/29 15:08:34  jenetic.bytemare
 *  outsourcing key-system completed
 *
 *  Revision 1.2  2006/09/29 14:15:36  jenetic.bytemare
 *  outsourcing key-system in progress
 *
 *  Revision 1.1  2006/09/29 13:09:51  jenetic.bytemare
 *  initial commitment
 *  pruned present sources
 *
 */
