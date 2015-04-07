/*  $Id: Shooter3DForm.cs,v 1.6 2006/11/17 06:46:14 jenetic.bytemare Exp $
 *  =================================================================================
 *  Representing the form.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Classes.IO;

namespace Classes.EngineGame
{
    public class Shooter3DForm : Form
    {
        public  static  Shooter3DForm       shooter3DForm           = null;
        public  static  Graphics            aGraphicsObject         = null;

        public Shooter3DForm()
        {
            aGraphicsObject     = CreateGraphics();
            Text                = "Amy's Abduction";
            Icon                = new Icon(     "images/app.ico"    );
            Location            = new Point(    0,      0           );
            ClientSize          = new Size(     640,    480         );
            //AutoScaleBaseSize   = new Size( 4, 3 );
            //FormBorderStyle     = FormBorderStyle.None;
            //TopMost             = true;
            //ClientSize          = Screen.PrimaryScreen.Bounds.Size;
            //DoubleBuffered      = true;

            //attach key-listeners
            KeyUp           += new KeyEventHandler( KeySystem.keyUp     );
            KeyDown         += new KeyEventHandler( KeySystem.keyDown   );

            //show form
            Show();

        } //endconstruct

        public static void init()
        {
            shooter3DForm = new Shooter3DForm();
        } //endmethod
/*
        protected override void OnSizeChanged( EventArgs e )
        {
            base.OnSizeChanged( e) ;
            Size s = Size;

            s.Width     = s.Width == 0 ? 1 : s.Width;
            s.Height    = s.Width / 4 * 3;
        } //endmethod
        */
    } //endclass
} //endnamespace

/*
 *  $Log: Shooter3DForm.cs,v $
 *  Revision 1.6  2006/11/17 06:46:14  jenetic.bytemare
 *  safe
 *
 *  Revision 1.4  2006/10/10 13:56:12  Mr. jenetic.bytemare
 *  bg implementation
 *
 *  Revision 1.3  2006/10/10 11:28:33  Mr. jenetic.bytemare
 *  no message
 *
 *  Revision 1.5  2006/10/05 23:01:42  jenetic.bytemare
 *  completed transparent bitmap-objects
 *  completed hud
 *
 *  Revision 1.4  2006/10/04 21:10:05  jenetic.bytemare
 *  collisions in progress ..
 *
 *  Revision 1.3  2006/10/03 13:42:19  jenetic.bytemare
 *  completed floor-texturing
 *
 *  Revision 1.2  2006/10/02 21:54:59  jenetic.bytemare
 *  implemented point-colliding
 *  region-colliding in progress
 *
 *  Revision 1.1  2006/10/02 11:23:41  jenetic.bytemare
 *  completed 3dsmax-importer.
 *  rearranged packages.
 *
 *  Revision 1.4  2006/09/29 21:07:56  jenetic.bytemare
 *  implemented multiple textures
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
